using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Chat : System.Web.UI.Page
    {
        public class MessageViewModel
        {
            public int Id { get; set; }
            public string SenderName { get; set; }
            public string SenderRole { get; set; }
            public string SenderPic { get; set; }
            public string MessageText { get; set; }
            public string PersianDate { get; set; }
            public string Time { get; set; }
            public bool IsSenderCurrentUser { get; set; }
            public bool IsRead { get; set; }
            public string AttachmentFilePath { get; set; }
            public string AttachmentFileName { get; set; }
        }

        private const string LoginPageUrl = "~/account/Login.aspx";
        private const string StaffListUrl = "~/panel/maneger/staff_list.aspx";
        private const string UploadsPath = "~/Uploads/Attachments/";
        private const int MessagesPerPage = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["mobile"] == null || Session["role"] == null)
                {
                    Session.Abandon();
                    ResponseRedirect(LoginPageUrl);
                    return;
                }

                LoadChat();
            }
        }

        private void LoadChat()
        {
            try
            {
                string idStaffStr = HttpUtility.HtmlEncode(Request.QueryString["id_staff"]);
                int idStaff;
                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
                {
                    lblMessage.Text = "شناسه کارمند نامعتبر یا ارائه نشده است.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                using (var db = new DataClasses1DataContext())
                {
                    string mobile = Session["mobile"] != null ? Session["mobile"].ToString() : null;
                    if (string.IsNullOrEmpty(mobile))
                    {
                        lblMessage.Text = "اطلاعات جلسه کاربر یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    var currentUser = db.User_tbls.SingleOrDefault(u => u.Phone == mobile);
                    if (currentUser == null)
                    {
                        lblMessage.Text = "کاربر جاری در پایگاه داده یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    var recipient = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
                    if (recipient == null)
                    {
                        lblMessage.Text = "کارمند با شناسه " + idStaff + " یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    lblRecipientName.Text = (recipient.Name ?? "") + " " + (recipient.Lastname ?? "");

                    var conversation = db.Conversation_tbls
                        .SingleOrDefault(c => (c.user1_id == currentUser.id && c.user2_id == idStaff) ||
                                             (c.user1_id == idStaff && c.user2_id == currentUser.id));

                    int? conversationId = null;
                    if (conversation == null)
                    {
                        db.Conversation_Insert(currentUser.id, idStaff, DateTime.Now, true, ref conversationId);
                        if (!conversationId.HasValue)
                        {
                            lblMessage.Text = "خطا در ایجاد گفتگو جدید.";
                            lblMessage.CssClass = "text-danger";
                            return;
                        }
                    }
                    else
                    {
                        conversationId = conversation.id;
                    }

                    var messagesRaw = (from m in db.Message_tbls
                                       join u in db.User_tbls on m.sender_id equals u.id
                                       join a in db.Attachment_tbls on m.id equals a.message_id into attachments
                                       from a in attachments.DefaultIfEmpty()
                                       where m.conversation_id == conversationId
                                       orderby m.sent_date descending
                                       select new
                                       {
                                           m.id,
                                           m.sender_id,
                                           SenderName = (u.Name ?? "") + " " + (u.Lastname ?? ""),
                                           SenderRole = u.Role ?? "",
                                           SenderPic = u.Pic ?? "",
                                           m.message_text,
                                           m.sent_date,
                                           m.is_read,
                                           AttachmentFilePath = a != null ? a.file_path : "",
                                           AttachmentFileName = a != null ? a.file_name : ""
                                       })
                                       .Take(MessagesPerPage)
                                       .ToList();

                    var messages = messagesRaw
                        .OrderBy(m => m.sent_date)
                        .Select(m => new MessageViewModel
                        {
                            Id = m.id,
                            SenderName = m.SenderName,
                            SenderRole = m.SenderRole,
                            SenderPic = m.SenderPic,
                            MessageText = m.message_text,
                            PersianDate = Formatter.ToPersianDate(m.sent_date),
                            Time = Formatter.ToHourMinute(m.sent_date),
                            IsSenderCurrentUser = m.sender_id == currentUser.id,
                            IsRead = m.is_read,
                            AttachmentFilePath = m.AttachmentFilePath,
                            AttachmentFileName = m.AttachmentFileName
                        })
                        .ToList();

                    MessagesListView.DataSource = messages;
                    MessagesListView.DataBind();

                    if (messages.Any())
                    {
                        hfOldestMessageId.Value = messages.First().Id.ToString();
                    }

                    foreach (var message in db.Message_tbls
                        .Where(m => m.conversation_id == conversationId && m.sender_id == idStaff && !m.is_read))
                    {
                        db.Message_Update(message.id, null, true);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در بارگذاری گفتگو: " + HttpUtility.HtmlEncode(ex.Message) + " | StackTrace: " + HttpUtility.HtmlEncode(ex.StackTrace);
                lblMessage.CssClass = "text-danger";
            }
        }

        [WebMethod]
        public static string LoadOlderMessages(int oldestMessageId)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    string mobile = HttpContext.Current.Session["mobile"] != null
                        ? HttpContext.Current.Session["mobile"].ToString()
                        : null;

                    if (string.IsNullOrEmpty(mobile))
                        throw new Exception("کاربر وارد نشده است.");

                    string idStaffStr = HttpUtility.HtmlEncode(HttpContext.Current.Request.QueryString["id_staff"]);
                    int idStaff;
                    if (!int.TryParse(idStaffStr, out idStaff))
                        throw new Exception("شناسه کارمند نامعتبر است.");

                    var currentUser = db.User_tbls.SingleOrDefault(u => u.Phone == mobile);
                    if (currentUser == null)
                        throw new Exception("کاربر جاری یافت نشد.");

                    var conversation = db.Conversation_tbls
                        .SingleOrDefault(c => (c.user1_id == currentUser.id && c.user2_id == idStaff) ||
                                             (c.user1_id == idStaff && c.user2_id == currentUser.id));
                    if (conversation == null)
                        throw new Exception("گفتگو یافت نشد.");

                    var messagesRaw = (from m in db.Message_tbls
                                       join u in db.User_tbls on m.sender_id equals u.id
                                       join a in db.Attachment_tbls on m.id equals a.message_id into attachments
                                       from a in attachments.DefaultIfEmpty()
                                       where m.conversation_id == conversation.id && m.id < oldestMessageId
                                       orderby m.sent_date descending
                                       select new
                                       {
                                           m.id,
                                           m.sender_id,
                                           SenderName = (u.Name ?? "") + " " + (u.Lastname ?? ""),
                                           SenderRole = u.Role ?? "",
                                           SenderPic = u.Pic ?? "",
                                           m.message_text,
                                           m.sent_date,
                                           m.is_read,
                                           AttachmentFilePath = a != null ? a.file_path : "", // Fixed: Use empty string
                                           AttachmentFileName = a != null ? a.file_name : "" // Fixed: Use empty string
                                       })
                                       .Take(10)
                                       .ToList();

                    var messages = messagesRaw
                        .OrderBy(m => m.sent_date) // Fixed: Type inference should work with correct types
                        .Select(m => new MessageViewModel
                        {
                            Id = m.id,
                            SenderName = m.SenderName,
                            SenderRole = m.SenderRole,
                            SenderPic = m.SenderPic,
                            MessageText = m.message_text,
                            PersianDate = Formatter.ToPersianDate(m.sent_date),
                            Time = Formatter.ToHourMinute(m.sent_date), // Fixed: Use valid string
                            IsSenderCurrentUser = m.sender_id == currentUser.id,
                            IsRead = m.is_read,
                            AttachmentFilePath = m.AttachmentFilePath,
                            AttachmentFileName = m.AttachmentFileName
                        })
                        .ToList();

                    return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(messages);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در بارگذاری پیام‌های قدیمی‌تر: " + HttpUtility.HtmlEncode(ex.Message));
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMessage.Text) && !fileUpload.HasFile)
                {
                    lblMessage.Text = "لطفاً پیام یا فایلی وارد کنید.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                string idStaffStr = HttpUtility.HtmlEncode(Request.QueryString["id_staff"]);
                int idStaff;
                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
                {
                    lblMessage.Text = "شناسه کارمند نامعتبر است.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                using (var db = new DataClasses1DataContext())
                {
                    string mobile = Session["mobile"] != null ? Session["mobile"].ToString() : null;
                    if (string.IsNullOrEmpty(mobile))
                    {
                        lblMessage.Text = "اطلاعات جلسه کاربر یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    var currentUser = db.User_tbls.SingleOrDefault(u => u.Phone == mobile);
                    if (currentUser == null)
                    {
                        lblMessage.Text = "کاربر جاری یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    var conversation = db.Conversation_tbls
                        .SingleOrDefault(c => (c.user1_id == currentUser.id && c.user2_id == idStaff) ||
                                             (c.user1_id == idStaff && c.user2_id == currentUser.id));
                    if (conversation == null)
                    {
                        lblMessage.Text = "گفتگو یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    int? messageId = null;
                    db.Message_Insert(conversation.id, currentUser.id, txtMessage.Text, DateTime.Now, false, ref messageId);

                    if (!messageId.HasValue)
                    {
                        lblMessage.Text = "خطا در ارسال پیام.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    if (fileUpload.HasFile)
                    {
                        string fileName = Path.GetFileName(fileUpload.FileName);
                        string filePath = Path.Combine(UploadsPath, messageId + "_" + fileName);
                        fileUpload.SaveAs(Server.MapPath(filePath));
                        int fileSize = fileUpload.FileBytes.Length;

                        int? attachmentId = null;
                        db.Attachment_Insert(messageId, filePath, fileName, fileSize, DateTime.Now, ref attachmentId);
                    }

                    txtMessage.Text = "";
                    lblMessage.Text = "پیام ارسال شد.";
                    lblMessage.CssClass = "text-success";

                    LoadChat();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در ارسال: " + HttpUtility.HtmlEncode(ex.Message);
                lblMessage.CssClass = "text-danger";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ResponseRedirect(StaffListUrl);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LoadChat();
        }

        private void ResponseRedirect(string url)
        {
            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}


//using System;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Services;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Collections.Generic;
//using WebApplicationImpora2222025.Helper;

//namespace WebApplicationImpora2222025.panel.maneger
//{
//    public partial class Chat : System.Web.UI.Page
//    {
//        public class MessageViewModel
//        {
//            public int Id { get; set; }
//            public string SenderName { get; set; }
//            public string SenderRole { get; set; }
//            public string SenderPic { get; set; }
//            public string MessageText { get; set; }
//            public string PersianDate { get; set; }
//            public string Time { get; set; }
//            public bool IsSenderCurrentUser { get; set; }
//            public bool IsRead { get; set; }
//            public string AttachmentFilePath { get; set; }
//            public string AttachmentFileName { get; set; }
//        }

//        private const string LoginPageUrl = "~/account/Login.aspx";
//        private const string StaffListUrl = "~/panel/maneger/staff_list.aspx";
//        private const string UploadsPath = "~/Uploads/Attachments/";
//        private const int MessagesPerPage = 10;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                if (Session["mobile"] == null || Session["role"] == null)
//                {
//                    Session.Abandon();
//                    ResponseRedirect(LoginPageUrl);
//                    return;
//                }

//                string userRole = Session["role"].ToString();
//                string[] allowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };
//                if (!allowedRoles.Contains(userRole))
//                {
//                    lblMessage.Text = "شما اجازه دسترسی به این صفحه را ندارید.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                LoadChat();
//            }
//        }

//        private void LoadChat()
//        {
//            try
//            {
//                string idStaffStr = HttpUtility.HtmlEncode(Request.QueryString["id_staff"]);
//                int idStaff;
//                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
//                {
//                    lblMessage.Text = "شناسه کارمند نامعتبر یا ارائه نشده است.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                using (var db = new DataClasses1DataContext())
//                {
//                    string mobile = Session["mobile"].ToString();
//                    var currentUser = db.User_tbls.SingleOrDefault(u => u.Phone == mobile);
//                    if (currentUser == null)
//                    {
//                        lblMessage.Text = "کاربر جاری یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    var recipient = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//                    if (recipient == null)
//                    {
//                        lblMessage.Text = "کارمند با این شناسه یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    lblRecipientName.Text = recipient.Name + " " + recipient.Lastname ?? "";

//                    var conversation = db.Conversation_tbls
//                        .SingleOrDefault(c => (c.user1_id == currentUser.id && c.user2_id == idStaff) ||
//                                             (c.user1_id == idStaff && c.user2_id == currentUser.id));

//                    int? conversationId = null;
//                    if (conversation == null)
//                    {
//                        db.Conversation_Insert(currentUser.id, idStaff, DateTime.Now, true, ref conversationId);
//                    }
//                    else
//                    {
//                        conversationId = conversation.id;
//                    }

//                    if (!conversationId.HasValue)
//                    {
//                        lblMessage.Text = "خطا در ایجاد یا یافتن گفتگو.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    var messagesRaw = (from m in db.Message_tbls
//                                       join u in db.User_tbls on m.sender_id equals u.id
//                                       join a in db.Attachment_tbls on m.id equals a.message_id into attachments
//                                       from a in attachments.DefaultIfEmpty()
//                                       where m.conversation_id == conversationId
//                                       orderby m.sent_date descending
//                                       select new
//                                       {
//                                           m.id,
//                                           m.sender_id,
//                                           SenderName = (u.Name ?? "") + " " + (u.Lastname ?? ""),
//                                           SenderRole = u.Role ?? "",
//                                           SenderPic = u.Pic ?? "",
//                                           m.message_text,
//                                           m.sent_date,
//                                           m.is_read,
//                                           AttachmentFilePath = a != null ? a.file_path : null,
//                                           AttachmentFileName = a != null ? a.file_name : null
//                                       })
//                                       .Take(MessagesPerPage)
//                                       .ToList();

//                    var messages = messagesRaw
//                        .OrderBy(m => m.sent_date)
//                        .Select(m => new MessageViewModel
//                        {
//                            Id = m.id,
//                            SenderName = m.SenderName,
//                            SenderRole = m.SenderRole,
//                            SenderPic = m.SenderPic,
//                            MessageText = m.message_text,
//                            PersianDate = Formatter.ToPersianDate(m.sent_date),
//                            Time = Formatter.ToHourMinute(m.sent_date),
//                            IsSenderCurrentUser = m.sender_id == currentUser.id,
//                            IsRead = m.is_read,
//                            AttachmentFilePath = m.AttachmentFilePath,
//                            AttachmentFileName = m.AttachmentFileName
//                        })
//                        .ToList();

//                    MessagesListView.DataSource = messages;
//                    MessagesListView.DataBind();

//                    if (messages.Any())
//                    {
//                        hfOldestMessageId.Value = messages.First().Id.ToString();
//                    }

//                    foreach (var message in db.Message_tbls
//                        .Where(m => m.conversation_id == conversationId && m.sender_id == idStaff && !m.is_read))
//                    {
//                        db.Message_Update(message.id, null, true);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = "خطا در بارگذاری گفتگو: " + HttpUtility.HtmlEncode(ex.Message);
//                lblMessage.CssClass = "text-danger";
//            }
//        }

//        [WebMethod]
//        public static string LoadOlderMessages(int oldestMessageId)
//        {
//            try
//            {
//                using (var db = new DataClasses1DataContext())
//                {
//                    string mobile = HttpContext.Current.Session["mobile"] != null
//    ? HttpContext.Current.Session["mobile"].ToString()
//    : null;

//                    if (string.IsNullOrEmpty(mobile))
//                        throw new Exception("کاربر وارد نشده است.");

//                    string idStaffStr = HttpUtility.HtmlEncode(HttpContext.Current.Request.QueryString["id_staff"]);
//                    int idStaff;
//                    if (!int.TryParse(idStaffStr, out idStaff))
//                        throw new Exception("شناسه کارمند نامعتبر است.");

//                    var currentUser = db.User_tbls.SingleOrDefault(u => u.Phone == mobile);
//                    if (currentUser == null)
//                        throw new Exception("کاربر جاری یافت نشد.");

//                    var conversation = db.Conversation_tbls
//                        .SingleOrDefault(c => (c.user1_id == currentUser.id && c.user2_id == idStaff) ||
//                                             (c.user1_id == idStaff && c.user2_id == currentUser.id));
//                    if (conversation == null)
//                        throw new Exception("گفتگو یافت نشد.");

//                    var messagesRaw = (from m in db.Message_tbls
//                                       join u in db.User_tbls on m.sender_id equals u.id
//                                       join a in db.Attachment_tbls on m.id equals a.message_id into attachments
//                                       from a in attachments.DefaultIfEmpty()
//                                       where m.conversation_id == conversation.id && m.id < oldestMessageId
//                                       orderby m.sent_date descending
//                                       select new
//                                       {
//                                           m.id,
//                                           m.sender_id,
//                                           SenderName = (u.Name ?? "") + " " + (u.Lastname ?? ""),
//                                           SenderRole = u.Role ?? "",
//                                           SenderPic = u.Pic ?? "",
//                                           m.message_text,
//                                           m.sent_date,
//                                           m.is_read,
//                                           AttachmentFilePath = a != null ? a.file_path : null,
//                                           AttachmentFileName = a != null ? a.file_name : null
//                                       })
//                                       .Take(10)
//                                       .ToList();

//                    var messages = messagesRaw
//                        .OrderBy(m => m.sent_date)
//                        .Select(m => new MessageViewModel
//                        {
//                            Id = m.id,
//                            SenderName = m.SenderName,
//                            SenderRole = m.SenderRole,
//                            SenderPic = m.SenderPic,
//                            MessageText = m.message_text,
//                            PersianDate = Formatter.ToPersianDate(m.sent_date),
//                            Time = Formatter.ToHourMinute(m.sent_date),
//                            IsSenderCurrentUser = m.sender_id == currentUser.id,
//                            IsRead = m.is_read,
//                            AttachmentFilePath = m.AttachmentFilePath,
//                            AttachmentFileName = m.AttachmentFileName
//                        })
//                        .ToList();

//                    return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(messages);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("خطا در بارگذاری پیام‌های قدیمی‌تر: " + HttpUtility.HtmlEncode(ex.Message));
//            }
//        }

//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(txtMessage.Text) && !fileUpload.HasFile)
//                {
//                    lblMessage.Text = "لطفاً پیام یا فایلی وارد کنید.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                string idStaffStr = HttpUtility.HtmlEncode(Request.QueryString["id_staff"]);
//                int idStaff;
//                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
//                {
//                    lblMessage.Text = "شناسه کارمند نامعتبر است.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                using (var db = new DataClasses1DataContext())
//                {
//                    string mobile = Session["mobile"].ToString();
//                    var currentUser = db.User_tbls.SingleOrDefault(u => u.Phone == mobile);
//                    if (currentUser == null)
//                    {
//                        lblMessage.Text = "کاربر جاری یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    var conversation = db.Conversation_tbls
//                        .SingleOrDefault(c => (c.user1_id == currentUser.id && c.user2_id == idStaff) ||
//                                             (c.user1_id == idStaff && c.user2_id == currentUser.id));
//                    if (conversation == null)
//                    {
//                        lblMessage.Text = "گفتگو یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    int? messageId = null;
//                    db.Message_Insert(conversation.id, currentUser.id, txtMessage.Text, DateTime.Now, false, ref messageId);

//                    if (!messageId.HasValue)
//                    {
//                        lblMessage.Text = "خطا در ارسال پیام.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }


//                    // Handle file upload
//                    if (fileUpload.HasFile)
//                    {
//                        string fileName = Path.GetFileName(fileUpload.FileName);
//                        string filePath = Path.Combine(UploadsPath, messageId + "_" + fileName);
//                        fileUpload.SaveAs(Server.MapPath(filePath));
//                        int fileSize = fileUpload.FileBytes.Length;

//                        int? attachmentId = null;
//                        db.Attachment_Insert(messageId, filePath, fileName, fileSize, DateTime.Now, ref attachmentId);
//                    }

//                    // Clear inputs
//                    txtMessage.Text = "";
//                    lblMessage.Text = "پیام ارسال شد.";
//                    lblMessage.CssClass = "text-success";

//                    // Reload messages
//                    LoadChat();
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = "خطا در ارسال: " + ex.Message;
//                lblMessage.CssClass = "text-danger";
//            }
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            ResponseRedirect(StaffListUrl);
//        }

//        protected void Timer1_Tick(object sender, EventArgs e)
//        {
//            LoadChat();
//        }

//        private void ResponseRedirect(string url)
//        {
//            Response.Redirect(url, false);
//            HttpContext.Current.ApplicationInstance.CompleteRequest();
//        }
//    }
//}