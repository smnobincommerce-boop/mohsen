using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Chat_list : System.Web.UI.Page
    {
        private const string LoginPageUrl = "~/account/Login.aspx";
        private const string ChatPageUrl = "Chat.aspx";
        private static readonly string[] ValidStaffRoles = { "مدیر", "مدیر فنی", "مدیر کل", "کارشناس", "نویسنده", "کارشناس تولید محتوا" };
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check authentication
                if (Session["mobile"] == null || Session["role"] == null)
                {
                    Session.Abandon();
                    ResponseRedirect(LoginPageUrl);
                    return;
                }

              

                LoadStaffList();
            }
        }

        private void LoadStaffList()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    // Get current user
                    string mobile = Session["mobile"] != null ? Session["mobile"].ToString() : null;
                    if (string.IsNullOrEmpty(mobile))
                    {
                        lblMessage.Text = "کاربر وارد نشده است.";
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

                    // Load confirmed and active staff
                    var staff = db.User_tbls
                        .Where(u => ValidStaffRoles.Contains(u.Role) && u.Comfirm == true && u.Access == true)
                        .Select(u => new
                        {
                            id = u.id,
                            Name = u.Name ?? "",
                            Lastname = u.Lastname ?? "",
                            Role = u.Role ?? "",
                            Pic = u.Pic ?? "../../img/default-user.png"
                        })
                        .ToList();

                    if (!staff.Any())
                    {
                        lblMessage.Text = "هیچ کارمندی با شرایط مورد نظر یافت نشد.";
                        lblMessage.CssClass = "text-warning";
                    }

                    StaffListView.DataSource = staff;
                    StaffListView.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در بارگذاری لیست افراد: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "text-danger";
                // TODO: Log exception (e.g., Serilog)
            }
        }

        protected void btnChat_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idStaff;
                if (int.TryParse(btn.CommandArgument, out idStaff))
                {
                    ResponseRedirect(string.Format("{0}?id_staff={1}", ChatPageUrl, idStaff));
                }
                else
                {
                    lblMessage.Text = "شناسه کارمند نامعتبر است.";
                    lblMessage.CssClass = "text-danger";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در انتقال به صفحه چت: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "text-danger";
            }
        }

        protected void StaffListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                var pager = StaffListView.FindControl("Data") as DataPager;
                if (pager != null)
                {
                    pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                    LoadStaffList();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در تغییر صفحه: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "text-danger";
            }
        }

        private void ResponseRedirect(string url)
        {
            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}