using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Detail_Activity_Day : System.Web.UI.Page
    {
        private const string LoginPageUrl = "~/account/Login.aspx";
        private const string BackUrl = "~/panel/maneger/activity_list.aspx";

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

                LoadActivityDetails();
            }
        }

        protected string GetTruncatedDescription(string description)
        {
            if (string.IsNullOrEmpty(description) || description.Length <= 100)
            {
                return description;
            }
            return description.Substring(0, 100) + "...";
        }

        private void LoadActivityDetails()
        {
            try
            {
                string userRole = Session["role"] != null ? Session["role"].ToString() : string.Empty;
                string[] allowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };
                if (string.IsNullOrEmpty(userRole) || !allowedRoles.Contains(userRole))
                {
                    lblMessage.Text = "شما قادر به مشاهده جزئیات فعالیت نیستید.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                string idStaffStr = Request.QueryString["id_staff"];
                int idStaff;
                string dateDay = Server.UrlDecode(Request.QueryString["date_day"]);
                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff) || string.IsNullOrEmpty(dateDay))
                {
                    lblMessage.Text = "شناسه کارمند یا تاریخ نامعتبر است.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                // Validate Persian date format (yyyy/MM/dd)
                if (!System.Text.RegularExpressions.Regex.IsMatch(dateDay, @"^\d{4}/\d{2}/\d{2}$"))
                {
                    lblMessage.Text = "فرمت تاریخ نامعتبر است.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                using (var db = new DataClasses1DataContext())
                {
                    // Load staff details
                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
                    if (staff == null)
                    {
                        lblMessage.Text = "کارمند با این شناسه یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }
                    lblStaffName.Text = (staff.Name != null ? staff.Name : "") + " " + (staff.Lastname != null ? staff.Lastname : "");
                    lblDate.Text = dateDay;

                    // Convert Persian date to Gregorian for ActivityLog_tbls
                    string gregorianDateStr = Helper.PersianDate.ConvertPersianToGregorian(dateDay);
                    DateTime gregorianDate;
                    if (!DateTime.TryParse(gregorianDateStr, out gregorianDate))
                    {
                        lblMessage.Text = "خطا در تبدیل تاریخ شمسی به میلادی.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    // Load activity details
                    var activity = db.ActivityLog_tbls
                        .Where(a => a.id_user == idStaff && a.date.Date == gregorianDate.Date)
                        .Select(a => new
                        {
                            Date = a.date,
                            a.descriptionofday,
                            a.timeopen,
                            a.timeclose,
                            a.followup_count,
                            a.created_companies_count
                        })
                        .FirstOrDefault();

                    if (activity == null)
                    {
                        lblMessage.Text = "هیچ فعالیتی برای این کارمند در تاریخ مشخص یافت نشد.";
                        lblMessage.CssClass = "text-danger";
                        return;
                    }

                    lblActivityDate.Text = Helper.PersianDate.GetPersianDate(activity.Date);
                    lblTimeOpen.Text = activity.timeopen.HasValue ? activity.timeopen.Value.ToString(@"hh\:mm") : "";
                    lblTimeClose.Text = activity.timeclose.HasValue ? activity.timeclose.Value.ToString(@"hh\:mm") : "";
                    lblFollowupCount.Text = activity.followup_count.ToString();
                    lblCompanyCount.Text = activity.created_companies_count.ToString();
                    lblDescription.Text = activity.descriptionofday;
                    description.Attributes["data-full-text"] = activity.descriptionofday;
                    lnkShowMore.Visible = !string.IsNullOrEmpty(activity.descriptionofday) && activity.descriptionofday.Length > 100;

                    // Load companies and follow-ups
                    var companiesFollowups = (from c in db.Company_tbls
                                              join pcl in db.Project_Commerce_Log_tbls
                                              on c.id equals pcl.id_Company
                                              where c.id_Staff == idStaff && pcl.id_Staff == idStaff && c.Date_Create == dateDay
                                              orderby c.Company_Name
                                              select new
                                              {
                                                  id_company = c.id,
                                                  c.Company_Name,
                                                  datecreate = c.Date_Create, // Already in Persian format
                                                  lastdescription = pcl.lastdescription // Corrected column name
                                              }).ToList();

                    lvCompanies.DataSource = companiesFollowups;
                    lvCompanies.DataBind();
                }
            }
            catch (ArgumentException ex)
            {
                if (ex.Source == "PersianDate")
                {
                    lblMessage.Text = "خطا در تبدیل تاریخ شمسی.";
                }
                else
                {
                    lblMessage.Text = "خطا در بارگذاری جزئیات: " + Server.HtmlEncode(ex.Message);
                }
                lblMessage.CssClass = "text-danger";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در بارگذاری جزئیات: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "text-danger";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string idStaff = Request.QueryString["id_staff"];
            ResponseRedirect(BackUrl + "?id_staff=" + idStaff);
        }

        private void ResponseRedirect(string url)
        {
            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}

//using System;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace WebApplicationImpora2222025.panel.maneger
//{
//    public partial class Detail_Activity_Day : System.Web.UI.Page
//    {
//        private const string LoginPageUrl = "~/account/Login.aspx";
//        private const string BackUrl = "~/panel/maneger/activity_list.aspx";

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

//                LoadActivityDetails();
//            }
//        }

//        protected string GetTruncatedDescription(string description)
//        {
//            if (string.IsNullOrEmpty(description) || description.Length <= 100)
//            {
//                return description;
//            }
//            return description.Substring(0, 100) + "...";
//        }

//        private void LoadActivityDetails()
//        {
//            try
//            {
//                string userRole = Session["role"] != null ? Session["role"].ToString() : string.Empty;
//                string[] allowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };
//                if (string.IsNullOrEmpty(userRole) || !allowedRoles.Contains(userRole))
//                {
//                    lblMessage.Text = "شما قادر به مشاهده جزئیات فعالیت نیستید.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                string idStaffStr = Request.QueryString["id_staff"];
//                int idStaff;
//                string dateDay = Server.UrlDecode(Request.QueryString["date_day"]);
//                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff) || string.IsNullOrEmpty(dateDay))
//                {
//                    lblMessage.Text = "شناسه کارمند یا تاریخ نامعتبر است.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                // Validate Persian date format (yyyy/MM/dd)
//                if (!System.Text.RegularExpressions.Regex.IsMatch(dateDay, @"^\d{4}/\d{2}/\d{2}$"))
//                {
//                    lblMessage.Text = "فرمت تاریخ نامعتبر است.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                using (var db = new DataClasses1DataContext())
//                {
//                    // Load staff details
//                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//                    if (staff == null)
//                    {
//                        lblMessage.Text = "کارمند با این شناسه یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }
//                    lblStaffName.Text = (staff.Name != null ? staff.Name : "") + " " + (staff.Lastname != null ? staff.Lastname : "");
//                    lblDate.Text = dateDay;

//                    // Load activity details
//                    var activity = db.ActivityLog_tbls
//                        .Where(a => a.id_user == idStaff && Helper.PersianDate.GetPersianDate(a.date) == dateDay)
//                        .Select(a => new
//                        {
//                            PersianDate = Helper.PersianDate.GetPersianDate(a.date),
//                            a.descriptionofday,
//                            a.timeopen,
//                            a.timeclose,
//                            a.followup_count,
//                            a.created_companies_count
//                        })
//                        .FirstOrDefault();

//                    if (activity == null)
//                    {
//                        lblMessage.Text = "هیچ فعالیتی برای این کارمند در تاریخ مشخص یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    lblActivityDate.Text = activity.PersianDate;
//                    if (activity.timeopen != null)
//                    {
//                        lblTimeOpen.Text = activity.timeopen.Value.ToString(@"hh\:mm");
//                    }
//                    else
//                    {
//                        lblTimeOpen.Text = "";
//                    }
//                    if (activity.timeclose != null)
//                    {
//                        lblTimeClose.Text = activity.timeclose.Value.ToString(@"hh\:mm");
//                    }
//                    else
//                    {
//                        lblTimeClose.Text = "";
//                    }
//                    lblFollowupCount.Text = activity.followup_count.ToString();
//                    lblCompanyCount.Text = activity.created_companies_count.ToString();
//                    lblDescription.Text = activity.descriptionofday;
//                    description.Attributes["data-full-text"] = activity.descriptionofday;
//                    lnkShowMore.Visible = !string.IsNullOrEmpty(activity.descriptionofday) && activity.descriptionofday.Length > 100;

//                    // Load companies and follow-ups
//                    var companiesFollowups = (from c in db.Company_tbls
//                                              join pcl in db.Project_Commerce_Log_tbls
//                                              on c.id equals pcl.id_Company
//                                              where c.id_Staff == idStaff && pcl.id_Staff == idStaff && pcl.datecreate == dateDay
//                                              orderby c.Company_Name
//                                              select new
//                                              {
//                                                  id_company = c.id,
//                                                  c.Company_Name,
//                                                  pcl.datecreate,
//                                                  pcl.lastdescription
//                                              }).ToList();

//                    lvCompanies.DataSource = companiesFollowups;
//                    lvCompanies.DataBind();
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                if (ex.Source == "PersianDate")
//                {
//                    lblMessage.Text = "خطا در تبدیل تاریخ شمسی.";
//                    lblMessage.CssClass = "text-danger";
//                }
//                else
//                {
//                    lblMessage.Text = "خطا در بارگذاری جزئیات: " + Server.HtmlEncode(ex.Message);
//                    lblMessage.CssClass = "text-danger";
//                }
//            }
//            catch (Exception ex)    
//            {
//                lblMessage.Text = "خطا در بارگذاری جزئیات: " + Server.HtmlEncode(ex.Message);
//                lblMessage.CssClass = "text-danger";
//            }
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            string idStaff = Request.QueryString["id_staff"];
//            ResponseRedirect(BackUrl + "?id_staff=" + idStaff);
//        }

//        private void ResponseRedirect(string url)
//        {
//            Response.Redirect(url, false);
//            HttpContext.Current.ApplicationInstance.CompleteRequest();
//        }
//    }
//}