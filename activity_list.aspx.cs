using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class activity_list : System.Web.UI.Page
    {
        protected Dictionary<string, string> ChartX = new Dictionary<string, string>();
        protected Dictionary<string, string> ChartY = new Dictionary<string, string>();
        protected Dictionary<string, string> ChartZ = new Dictionary<string, string>();

        private const string QueryParamIdStaff = "id_staff";
        private const string QueryParamType = "type";
        private const string LoginPageUrl = "~/account/Login.aspx";
        private const string BackUrl = "~/panel/maneger/staff_list.aspx";
        private static readonly string[] AllowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"] == null || Session["mobile"] == null)
                {
                    Session.Abandon();
                    ResponseRedirect(LoginPageUrl);
                    return;
                }

                LoadActivities();
            }
        }

        private void LoadActivities()
        {
            try
            {
                string userRole;
                if (!ValidateUserRole(out userRole))
                {
                    ShowErrorMessage("شما قادر به مشاهده فعالیت‌های این کارمند نیستید.");
                    return;
                }

                int idStaff;
                if (!GetStaffId(out idStaff))
                {
                    ShowErrorMessage("شناسه کارمند نامعتبر یا ارائه نشده است.");
                    return;
                }

                DateTime startDate;
                string chartType = GetChartType(out startDate);
                using (var db = new DataClasses1DataContext())
                {
                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
                    if (staff == null)
                    {
                        ShowErrorMessage("کارمند با این شناسه یافت نشد.");
                        return;
                    }

                    lblStaffName.Text = string.Format("{0} {1}", staff.Name ?? "", staff.Lastname ?? "").Trim();
                    lblChartType.Text = chartType == "week" ? "هفتگی" : chartType == "month" ? "ماهانه" : "فصلی";

                    var activities = FetchActivities(db, idStaff);
                    if (!activities.Any())
                    {
                        ShowInfoMessage("هیچ فعالیتی برای این کارمند یافت نشد.");
                        lvActivities.DataSource = new List<object>();
                        lvActivities.DataBind();
                        return;
                    }

                    var formattedActivities = FormatActivities(activities);
                    lvActivities.DataSource = formattedActivities;
                    lvActivities.DataBind();

                    PopulateChartData(db, idStaff, startDate);
                }
            }
            catch (ArgumentException ex)
            {
                if (ex.Source == "PersianDate")
                {
                    ShowErrorMessage("خطا در تبدیل تاریخ شمسی.");
                }
                else
                {
                    ShowErrorMessage(string.Format("خطای آرگومان: {0}", Server.HtmlEncode(ex.Message)));
                }
            }
            //catch (Exception ex)
            //{
            //    ShowErrorMessage(string.Format("خطا در بارگذاری کارکردها: {0}", Server.HtmlEncode(ex.Message)));
            //    System.Diagnostics.Debug.WriteLine(string.Format("Error in LoadActivities: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
            //}
        }

        private bool ValidateUserRole(out string userRole)
        {
            userRole = Session["role"] == null ? string.Empty : Session["role"].ToString();
            return !string.IsNullOrEmpty(userRole) && AllowedRoles.Contains(userRole);
        }

        private bool GetStaffId(out int idStaff)
        {
            string idStaffStr = Request.QueryString[QueryParamIdStaff];
            idStaff = 0;
            return !string.IsNullOrEmpty(idStaffStr) && int.TryParse(idStaffStr, out idStaff);
        }

        private string GetChartType(out DateTime startDate)
        {
            string chartType = Request.QueryString[QueryParamType] == null ? "week" : Request.QueryString[QueryParamType].ToLower();
            switch (chartType)
            {
                case "month":
                    startDate = DateTime.Now.AddMonths(-1);
                    return "month";
                case "season":
                    startDate = DateTime.Now.AddMonths(-3);
                    return "season";
                default:
                    startDate = DateTime.Now.AddDays(-7);
                    return "week";
            }
        }

        private IEnumerable<dynamic> FetchActivities(DataClasses1DataContext db, int idStaff)
        {
            return (from a in db.ActivityLog_tbls
                    join u in db.User_tbls on a.id_user equals u.id
                    where a.id_user == idStaff
                    orderby a.date descending, a.timeopen descending
                    select new
                    {
                        a.id,
                        a.date,
                        a.timeopen,
                        a.timeclose,
                        a.followup_count,
                        a.created_companies_count,
                        a.descriptionofday
                    }).ToList();
        }

        private IEnumerable<dynamic> FormatActivities(IEnumerable<dynamic> activities)
        {
            return activities.Select(a => new
            {
                a.id,
                PersianDate = Formatter.ToPersianDate(a.date),
                timeopen = Formatter.ToHourMinute(a.timeopen),
                timeclose = Formatter.ToHourMinute(a.timeclose),
                followup_count = ParseToInt(a.followup_count),
                created_companies_count = ParseToInt(a.created_companies_count),
                descriptionofday = a.descriptionofday ?? ""
            }).ToList();
        }

        private int ParseToInt(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                System.Diagnostics.Debug.WriteLine("ParseToInt: Input is null or whitespace");
                return 0;
            }

            string strValue = value.ToString().Trim();

            // تبدیل اعداد فارسی به لاتین
            strValue = strValue
                .Replace("۰", "0").Replace("۱", "1").Replace("۲", "2")
                .Replace("۳", "3").Replace("۴", "4").Replace("۵", "5")
                .Replace("۶", "6").Replace("۷", "7").Replace("۸", "8")
                .Replace("۹", "9");

            // حذف کاراکترهای غیر عددی به جز نقطه (.)
            char[] allowedChars = strValue.ToCharArray();
            List<char> digitsOnly = new List<char>();
            foreach (char c in allowedChars)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    digitsOnly.Add(c);
                }
            }

            strValue = new string(digitsOnly.ToArray());

            int result;
            if (int.TryParse(strValue, out result))
            {
                return result;
            }

            double doubleResult;
            if (double.TryParse(strValue, out doubleResult))
            {
                System.Diagnostics.Debug.WriteLine(string.Format("ParseToInt: Parsed as double '{0}' to {1}", strValue, (int)Math.Floor(doubleResult)));
                return (int)Math.Floor(doubleResult);
            }

            System.Diagnostics.Debug.WriteLine(string.Format("ParseToInt: Failed to parse '{0}' to int", strValue));
            return 0;
        }

        private void PopulateChartData(DataClasses1DataContext db, int idStaff, DateTime startDate)
        {
            try
            {
                var rawActivities = (from a in db.ActivityLog_tbls
                                     where a.id_user == idStaff && a.date >= startDate
                                     select new
                                     {
                                         Date = a.date,
                                         RawCompanies = a.created_companies_count,
                                         RawFollowups = a.followup_count,
                                         Companies = ParseToInt(a.created_companies_count),
                                         Followups = ParseToInt(a.followup_count)
                                     }).ToList();

                // Log raw data for debugging
                foreach (var a in rawActivities)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format(
                        "Activity: Date={0}, RawCompanies={1}, Companies={2}, RawFollowups={3}, Followups={4}",
                        Formatter.ToPersianDate(a.Date),
                        a.RawCompanies,
                        a.Companies,
                        a.RawFollowups,
                        a.Followups));
                }

                var chartActivities = rawActivities
                    .GroupBy(a => Formatter.ToPersianDate(a.Date))
                    .Select(g => new
                    {
                        PersianDate = g.Key,
                        Companies = g.Sum(x => x.Companies),
                        Followups = g.Sum(x => x.Followups)
                    })
                    .OrderBy(a => a.PersianDate)
                    .Take(30)
                    .ToList();

                // Pad data to ensure 30 entries
                for (int i = 1; i <= 30; i++)
                {
                    string key = i.ToString();
                    if (i <= chartActivities.Count)
                    {
                        ChartX[key] = chartActivities[i - 1].PersianDate;
                        ChartY[key] = chartActivities[i - 1].Companies.ToString();
                        ChartZ[key] = chartActivities[i - 1].Followups.ToString();
                    }
                    else
                    {
                        ChartX[key] = "";
                        ChartY[key] = "0";
                        ChartZ[key] = "0";
                    }
                }

                var companies = chartActivities.Select(a => a.Companies).ToArray();
                var followups = chartActivities.Select(a => a.Followups).ToArray();

                Lbl_company_total.Text = string.Format("جمع: {0}", companies.Any() ? companies.Sum() : 0);
                Lbl_company_avg.Text = string.Format("میانگین: {0:F2}", companies.Any() ? companies.Average() : 0.0);
                Lbl_company_highlight.Text = string.Format("بیشترین: {0}", companies.Any() ? companies.Max() : 0);
                Lbl_followup_total.Text = string.Format("جمع: {0}", followups.Any() ? followups.Sum() : 0);
                Lbl_followup_avg.Text = string.Format("میانگین: {0:F2}", followups.Any() ? followups.Average() : 0.0);
                Lbl_followup_highlight.Text = string.Format("بیشترین: {0}", followups.Any() ? followups.Max() : 0);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error in PopulateChartData: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
                ShowErrorMessage(string.Format("خطا در بارگذاری داده‌های نمودار: {0}", Server.HtmlEncode(ex.Message)));
            }
        }

        public string GetTruncatedDescription(object descriptionObj)
        {
            string description = descriptionObj == null ? string.Empty : descriptionObj.ToString();
            const int maxLength = 100;
            return description.Length <= maxLength ? description : description.Substring(0, maxLength) + "...";
        }

        protected void lnkTab_Click(object sender, EventArgs e)
        {
            var lnk = (LinkButton)sender;
            string type = lnk.CommandArgument;
            string idStaff = Request.QueryString[QueryParamIdStaff];
            ResponseRedirect(string.Format("activity_list.aspx?{0}={1}&{2}={3}", QueryParamIdStaff, idStaff, QueryParamType, type));
        }

        protected void lvActivities_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var pager = (DataPager)lvActivities.FindControl("DataPager1");
            if (pager != null)
            {
                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                LoadActivities();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ResponseRedirect(BackUrl);
        }

        private void ShowErrorMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = "text-danger-message";
        }

        private void ShowInfoMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = "text-info";
        }

        private void ResponseRedirect(string url)
        {
            Response.Redirect(url, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using WebApplicationImpora2222025.Helper;

//namespace WebApplicationImpora2222025.panel.maneger
//{
//    public partial class activity_list : System.Web.UI.Page
//    {
//        // Instance dictionary for chart data
//        protected Dictionary<string, string> ChartX = new Dictionary<string, string>();
//        protected Dictionary<string, string> ChartY = new Dictionary<string, string>();
//        protected Dictionary<string, string> ChartZ = new Dictionary<string, string>();

//        private const string QueryParamIdStaff = "id_staff";
//        private const string QueryParamType = "type";
//        private const string LoginPageUrl = "~/account/Login.aspx";
//        private const string BackUrl = "~/panel/maneger/staff_list.aspx";
//        private static readonly string[] AllowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                if (Session["role"] == null || Session["mobile"] == null)
//                {
//                    Session.Abandon();
//                    ResponseRedirect(LoginPageUrl);
//                    return;
//                }

//                LoadActivities();
//            }
//        }

//        private void LoadActivities()
//        {
//            try
//            {
//                string userRole;
//                if (!ValidateUserRole(out userRole))
//                {
//                    ShowErrorMessage("شما قادر به مشاهده فعالیت‌های این کارمند نیستید.");
//                    return;
//                }

//                int idStaff;
//                if (!GetStaffId(out idStaff))
//                {
//                    ShowErrorMessage("شناسه کارمند نامعتبر یا ارائه نشده است.");
//                    return;
//                }

//                DateTime startDate;
//                string chartType = GetChartType(out startDate);
//                using (var db = new DataClasses1DataContext())
//                {
//                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//                    if (staff == null)
//                    {
//                        ShowErrorMessage("کارمند با این شناسه یافت نشد.");
//                        return;
//                    }

//                    lblStaffName.Text = string.Format("{0} {1}", staff.Name ?? "", staff.Lastname ?? "").Trim();
//                    lblChartType.Text = chartType == "week" ? "هفتگی" : chartType == "month" ? "ماهانه" : "فصلی";

//                    var activities = FetchActivities(db, idStaff);
//                    if (!activities.Any())
//                    {
//                        ShowInfoMessage("هیچ فعالیتی برای این کارمند یافت نشد.");
//                        lvActivities.DataSource = new List<object>();
//                        lvActivities.DataBind();
//                        return;
//                    }

//                    var formattedActivities = FormatActivities(activities);
//                    lvActivities.DataSource = formattedActivities;
//                    lvActivities.DataBind();

//                    PopulateChartData(db, idStaff, startDate);
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                if (ex.Source == "PersianDate")
//                {
//                    ShowErrorMessage("خطا در تبدیل تاریخ شمسی.");
//                }
//                else
//                {
//                    ShowErrorMessage(string.Format("خطای آرگومان: {0}", Server.HtmlEncode(ex.Message)));
//                }
//            }
//            catch (Exception ex)
//            {
//                ShowErrorMessage(string.Format("خطا در بارگذاری کارکردها: {0}", Server.HtmlEncode(ex.Message)));
//                System.Diagnostics.Debug.WriteLine(string.Format("Error in LoadActivities: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
//            }
//        }

//        private bool ValidateUserRole(out string userRole)
//        {
//            userRole = Session["role"] == null ? string.Empty : Session["role"].ToString();
//            return !string.IsNullOrEmpty(userRole) && AllowedRoles.Contains(userRole);
//        }

//        private bool GetStaffId(out int idStaff)
//        {
//            string idStaffStr = Request.QueryString[QueryParamIdStaff];
//            idStaff = 0;
//            return !string.IsNullOrEmpty(idStaffStr) && int.TryParse(idStaffStr, out idStaff);
//        }

//        private string GetChartType(out DateTime startDate)
//        {
//            string chartType = Request.QueryString[QueryParamType] == null ? "week" : Request.QueryString[QueryParamType].ToLower();
//            switch (chartType)
//            {
//                case "month":
//                    startDate = DateTime.Now.AddMonths(-1);
//                    return "month";
//                case "season":
//                    startDate = DateTime.Now.AddMonths(-3);
//                    return "season";
//                default:
//                    startDate = DateTime.Now.AddDays(-7);
//                    return "week";
//            }
//        }

//        private IEnumerable<dynamic> FetchActivities(DataClasses1DataContext db, int idStaff)
//        {
//            return (from a in db.ActivityLog_tbls
//                    join u in db.User_tbls on a.id_user equals u.id
//                    where a.id_user == idStaff
//                    orderby a.date descending, a.timeopen descending
//                    select new
//                    {
//                        a.id,
//                        a.date,
//                        a.timeopen,
//                        a.timeclose,
//                        a.followup_count,
//                        a.created_companies_count,
//                        a.descriptionofday
//                    }).ToList();
//        }

//        private IEnumerable<dynamic> FormatActivities(IEnumerable<dynamic> activities)
//        {
//            return activities.Select(a => new
//            {
//                a.id,
//                PersianDate = Formatter.ToPersianDate(a.date),
//                timeopen = Formatter.ToHourMinute(a.timeopen),
//                timeclose = Formatter.ToHourMinute(a.timeclose),
//                followup_count = Formatter.SafeInt(a.followup_count),
//                created_companies_count = Formatter.SafeInt(a.created_companies_count),
//                descriptionofday = a.descriptionofday ?? ""
//            }).ToList();
//        }

//       private int ParseToInt(string value)
//{
//    if (string.IsNullOrWhiteSpace(value))
//    {
//        System.Diagnostics.Debug.WriteLine("ParseToInt: Input string is null or whitespace");
//        return 0;
//    }

//    // تبدیل اعداد فارسی به لاتین
//    value = value.Trim()
//        .Replace("۰", "0").Replace("۱", "1").Replace("۲", "2")
//        .Replace("۳", "3").Replace("۴", "4").Replace("۵", "5")
//        .Replace("۶", "6").Replace("۷", "7").Replace("۸", "8")
//        .Replace("۹", "9");

//    int result;
//    if (int.TryParse(value, out result))
//    {
//        return result;
//    }

//    // در صورت نیاز تبدیل اعشار به عدد صحیح
//    double doubleResult;
//    if (double.TryParse(value, out doubleResult))
//    {
//        System.Diagnostics.Debug.WriteLine(string.Format(
//            "ParseToInt: Parsed as double '{0}' to {1}", value, Math.Floor(doubleResult)));
//        return (int)Math.Floor(doubleResult);
//    }

//    System.Diagnostics.Debug.WriteLine(string.Format(
//        "ParseToInt: Failed to parse '{0}' to int", value));
//    return 0;
//}

//       private List<object> GetFormattedActivities(DataClasses1DataContext db, int idStaff)
//       {
//           // Fetches and formats in one step. No "dynamic", no complex parsing.
//           var activities = (from a in db.ActivityLog_tbls
//                             where a.id_user == idStaff
//                             orderby a.date descending, a.timeopen descending
//                             select new
//                             {
//                                 id = a.id,
//                                 PersianDate = Formatter.ToPersianDate(a.date),
//                                 timeopen = Formatter.ToHourMinute(a.timeopen),
//                                 timeclose = Formatter.ToHourMinute(a.timeclose),
//                                 followup_count = a.followup_count, // It's already an int!
//                                 created_companies_count = a.created_companies_count, // It's already an int!
//                                 descriptionofday = a.descriptionofday ?? ""
//                             }).Cast<object>().ToList();

//           return activities;
//       }

//        private void PopulateChartData(DataClasses1DataContext db, int idStaff, DateTime startDate)
//        {
//            try
//            {
//                var rawActivities = (from a in db.ActivityLog_tbls
//                                     where a.id_user == idStaff && a.date >= startDate
//                                     select new
//                                     {
//                                         Date = a.date,
//                                         RawCompanies = a.created_companies_count,
//                                         RawFollowups = a.followup_count,
//                                         Companies = a.created_companies_count != null ? ParseToInt(a.created_companies_count.ToString()) : 0,
//                                         Followups = a.followup_count != null ? ParseToInt(a.followup_count.ToString()) : 0
//                                     }).ToList();

//                foreach (var a in rawActivities)
//                {
//                    System.Diagnostics.Debug.WriteLine(string.Format(
//                        "Activity: Date={0}, RawCompanies={1}, Companies={2}, RawFollowups={3}, Followups={4}",
//                        Formatter.ToPersianDate(a.Date),
//                         a.RawCompanies != null ? a.RawCompanies.ToString() : "null",
//                        a.Companies,
//                        a.RawFollowups != null ? a.RawFollowups.ToString() : "null",
//                        a.Followups));
//                }

//                // This query is now simple and efficient.
//                // It groups by date and sums the integer columns directly.
//                var chartActivities = (from a in db.ActivityLog_tbls
//                                       where a.id_user == idStaff && a.date >= startDate
//                                       group a by a.date into g // Group by the actual date
//                                       orderby g.Key
//                                       select new
//                                       {
//                                           PersianDate = Formatter.ToPersianDate(g.Key),
//                                           Companies = g.Sum(x => x.created_companies_count),
//                                           Followups = g.Sum(x => x.followup_count)
//                                       })
//                               .Take(30)
//                               .ToList();

//                // Pad data to ensure 30 entries
//                for (int i = 1; i <= 30; i++)
//                {
//                    string key = i.ToString();
//                    if (i <= chartActivities.Count)
//                    {
//                        ChartX[key] = chartActivities[i - 1].PersianDate;
//                        ChartY[key] = chartActivities[i - 1].Companies.ToString();
//                        ChartZ[key] = chartActivities[i - 1].Followups.ToString();
//                    }
//                    else
//                    {
//                        ChartX[key] = "";
//                        ChartY[key] = "0";
//                        ChartZ[key] = "0";
//                    }
//                }

//                var companies = chartActivities.Select(a => a.Companies).ToArray();
//                var followups = chartActivities.Select(a => a.Followups).ToArray();

//               Lbl_company_total.Text = string.Format("جمع: {0}", companies.Any() ? companies.Sum() : 0);
//                Lbl_company_avg.Text = string.Format("میانگین: {0:F2}", companies.Any() ? companies.Average() : 0.0);
//                Lbl_company_highlight.Text = string.Format("بیشترین: {0}", companies.Any() ? companies.Max() : 0);
//                Lbl_followup_total.Text = string.Format("جمع: {0}", followups.Any() ? followups.Sum() : 0);
//                Lbl_followup_avg.Text = string.Format("میانگین: {0:F2}", followups.Any() ? followups.Average() : 0.0);
//                Lbl_followup_highlight.Text = string.Format("بیشترین: {0}", followups.Any() ? followups.Max() : 0);
//            }
//            catch (FormatException ex)
//            {
//                System.Diagnostics.Debug.WriteLine(string.Format("FormatException in PopulateChartData: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
//                ShowErrorMessage("داده‌های عددی در فعالیت‌ها نامعتبر هستند. لطفاً با مدیر سیستم تماس بگیرید.");
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine(string.Format("Error in PopulateChartData: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
//                ShowErrorMessage("خطا در بارگذاری داده‌های نمودار: " + Server.HtmlEncode(ex.Message));
//            }
//        }

//        public string GetTruncatedDescription(object descriptionObj)
//        {
//             string description = descriptionObj == null ? string.Empty : descriptionObj.ToString();
//            const int maxLength = 100;
//            return description.Length <= maxLength ? description : description.Substring(0, maxLength) + "...";
//        }

//        protected void lnkTab_Click(object sender, EventArgs e)
//        {
//            var lnk = (LinkButton)sender;
//            string type = lnk.CommandArgument;
//            string idStaff = Request.QueryString[QueryParamIdStaff];
//            ResponseRedirect(string.Format("activity_list.aspx?{0}={1}&{2}={3}", QueryParamIdStaff, idStaff, QueryParamType, type));
//        }

//        protected void lvActivities_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
//        {
//            var pager = (DataPager)lvActivities.FindControl("DataPager1");
//            if (pager != null)
//            {
//                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
//                LoadActivities();
//            }
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            ResponseRedirect(BackUrl);
//        }

//        private void ShowErrorMessage(string message)
//        {
//            lblMessage.Text = message;
//            lblMessage.CssClass = "text-danger-message";
//        }

//        private void ShowInfoMessage(string message)
//        {
//            lblMessage.Text = message;
//            lblMessage.CssClass = "text-info";
//        }

//        private void ResponseRedirect(string url)
//        {
//            Response.Redirect(url, false);
//            Context.ApplicationInstance.CompleteRequest();
//        }
//    }
//}


//////using System;
//////using System.Collections.Generic;
//////using System.Linq;
//////using System.Web;
//////using System.Web.UI;
//////using System.Web.UI.WebControls;
//////using WebApplicationImpora2222025.Helper;

//////namespace WebApplicationImpora2222025.panel.maneger
//////{
//////    public partial class activity_list : System.Web.UI.Page
//////    {
//////        // Instance dictionary for chart data
//////        protected Dictionary<string, string> ChartX = new Dictionary<string, string>();
//////        protected Dictionary<string, string> ChartY = new Dictionary<string, string>();
//////        protected Dictionary<string, string> ChartZ = new Dictionary<string, string>();

//////        private const string QueryParamIdStaff = "id_staff";
//////        private const string QueryParamType = "type";
//////        private const string LoginPageUrl = "~/account/Login.aspx";
//////        private const string BackUrl = "~/panel/maneger/staff_list.aspx";
//////        private static readonly string[] AllowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };

//////        protected void Page_Load(object sender, EventArgs e)
//////        {
//////            if (!IsPostBack)
//////            {
//////                if (Session["role"] == null || Session["mobile"] == null)
//////                {
//////                    Session.Abandon();
//////                    ResponseRedirect(LoginPageUrl);
//////                    return;
//////                }

//////                LoadActivities();
//////            }
//////        }

//////        private void LoadActivities()
//////        {
//////            try
//////            {
//////                string userRole;
//////                if (!ValidateUserRole(out userRole))
//////                {
//////                    ShowErrorMessage("شما قادر به مشاهده فعالیت‌های این کارمند نیستید.");
//////                    return;
//////                }

//////                int idStaff;
//////                if (!GetStaffId(out idStaff))
//////                {
//////                    ShowErrorMessage("شناسه کارمند نامعتبر یا ارائه نشده است.");
//////                    return;
//////                }

//////                DateTime startDate;
//////                string chartType = GetChartType(out startDate);
//////                using (var db = new DataClasses1DataContext())
//////                {
//////                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//////                    if (staff == null)
//////                    {
//////                        ShowErrorMessage("کارمند با این شناسه یافت نشد.");
//////                        return;
//////                    }

//////                    lblStaffName.Text = string.Format("{0} {1}", staff.Name ?? "", staff.Lastname ?? "").Trim();

//////                    lblChartType.Text = chartType == "week" ? "هفتگی" : chartType == "month" ? "ماهانه" : "فصلی";

//////                    var activities = FetchActivities(db, idStaff);
//////                    if (!activities.Any())
//////                    {
//////                        ShowInfoMessage("هیچ فعالیتی برای این کارمند یافت نشد.");
//////                        lvActivities.DataSource = new List<object>();
//////                        lvActivities.DataBind();
//////                        return;
//////                    }

//////                    var formattedActivities = FormatActivities(activities);
//////                    lvActivities.DataSource = formattedActivities;
//////                    lvActivities.DataBind();

//////                    PopulateChartData(db, idStaff, startDate);
//////                }
//////            }
//////            catch (ArgumentException ex)
//////            {
//////                if (ex.Source == "PersianDate")
//////                {
//////                    ShowErrorMessage("خطا در تبدیل تاریخ شمسی.");
//////                }
//////                else
//////                {
//////                    ShowErrorMessage(string.Format("خطای آرگومان: {0}", Server.HtmlEncode(ex.Message)));
//////                }
//////            }
//////            catch (Exception ex)
//////            {
//////                ShowErrorMessage(string.Format("خطا در بارگذاری کارکردها: {0}", Server.HtmlEncode(ex.Message)));
//////                System.Diagnostics.Debug.WriteLine(string.Format("Error in LoadActivities: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
//////            }
//////        }

//////        private bool ValidateUserRole(out string userRole)
//////        {
//////            userRole = Session["role"] == null ? string.Empty : Session["role"].ToString();
//////            return !string.IsNullOrEmpty(userRole) && AllowedRoles.Contains(userRole);
//////        }

//////        private bool GetStaffId(out int idStaff)
//////        {
//////            string idStaffStr = Request.QueryString[QueryParamIdStaff];
//////            idStaff = 0;
//////            return !string.IsNullOrEmpty(idStaffStr) && int.TryParse(idStaffStr, out idStaff);
//////        }

//////        private string GetChartType(out DateTime startDate)
//////        {
//////            string chartType = Request.QueryString[QueryParamType] == null ? "week" : Request.QueryString[QueryParamType].ToLower();
//////            switch (chartType)
//////            {
//////                case "month":
//////                    startDate = DateTime.Now.AddMonths(-1);
//////                    return "month";
//////                case "season":
//////                    startDate = DateTime.Now.AddMonths(-3);
//////                    return "season";
//////                default:
//////                    startDate = DateTime.Now.AddDays(-7);
//////                    return "week";
//////            }
//////        }

//////        private IEnumerable<dynamic> FetchActivities(DataClasses1DataContext db, int idStaff)
//////        {
//////            return (from a in db.ActivityLog_tbls
//////                    join u in db.User_tbls on a.id_user equals u.id
//////                    where a.id_user == idStaff
//////                    orderby a.date descending, a.timeopen descending
//////                    select new
//////                    {
//////                        a.id,
//////                        a.date,
//////                        a.timeopen,
//////                        a.timeclose,
//////                        a.followup_count,
//////                        a.created_companies_count,
//////                        a.descriptionofday
//////                    }).ToList();
//////        }

//////        private IEnumerable<dynamic> FormatActivities(IEnumerable<dynamic> activities)
//////        {
//////            return activities.Select(a => new
//////            {
//////                a.id,
//////                PersianDate = Formatter.ToPersianDate(a.date),
//////                timeopen = Formatter.ToHourMinute(a.timeopen),
//////                timeclose = Formatter.ToHourMinute(a.timeclose),
//////                followup_count = Formatter.SafeInt(a.followup_count),
//////                created_companies_count = Formatter.SafeInt(a.created_companies_count),
//////                descriptionofday = a.descriptionofday ?? ""
//////            }).ToList();
//////        }

//////        public class ActivityDto
//////        {
//////            public DateTime Date { get; set; }
//////            public object RawCompanies { get; set; }
//////            public object RawFollowups { get; set; }
//////            public int Companies { get; set; }
//////            public int Followups { get; set; }
//////        }

//////        private int ParseToInt(string value)
//////        {
//////            if (string.IsNullOrWhiteSpace(value))
//////            {
//////                System.Diagnostics.Debug.WriteLine("ParseToInt: Input string is null or whitespace");
//////                return 0;
//////            }

//////            int result;
//////            if (int.TryParse(value.Trim(), out result))
//////            {
//////                return result;
//////            }
//////            else
//////            {
//////                System.Diagnostics.Debug.WriteLine(string.Format("ParseToInt: Failed to parse '{0}' to int", value));
//////                return 0;
//////            }
//////        }
//////        private void PopulateChartData(DataClasses1DataContext db, int idStaff, DateTime startDate)
//////        {
//////            try
//////            {
//////                var rawActivities = (from a in db.ActivityLog_tbls
//////                                     where a.id_user == idStaff && a.date >= startDate
//////                                     select new
//////                                     {
//////                                         Date = a.date,
//////                                         RawCompanies = a.created_companies_count,
//////                                         RawFollowups = a.followup_count,
//////                                         Companies = a.created_companies_count != null ? ParseToInt(a.created_companies_count.ToString()) : 0,
//////                                         Followups = a.followup_count != null ? ParseToInt(a.followup_count.ToString()) : 0
//////                                     }).ToList();

//////                foreach (var a in rawActivities)
//////                {
//////                    System.Diagnostics.Debug.WriteLine(string.Format(
//////                        "Activity: Date={0}, RawCompanies={1}, Companies={2}, RawFollowups={3}, Followups={4}",
//////                        Formatter.ToPersianDate(a.Date),
//////                        a.RawCompanies != null ? a.RawCompanies.ToString() : "null",
//////                        a.Companies,
//////                        a.RawFollowups != null ? a.RawFollowups.ToString() : "null",
//////                        a.Followups));
//////                }

//////                var chartActivities = rawActivities
//////                    .GroupBy(a => Formatter.ToPersianDate(a.Date))
//////                    .Select(g => new
//////                    {
//////                        PersianDate = g.Key,
//////                        Companies = g.Sum(x => x.Companies),
//////                        Followups = g.Sum(x => x.Followups)
//////                    })
//////                    .OrderBy(a => a.PersianDate)
//////                    .Take(30)
//////                    .ToList();

//////                for (int i = 1; i <= 30; i++)
//////                {
//////                    string key = string.Format("{0}", i);
//////                    if (i <= chartActivities.Count)
//////                    {
//////                        ChartX[key] = chartActivities[i - 1].PersianDate;
//////                        ChartY[key] = chartActivities[i - 1].Companies.ToString();
//////                        ChartZ[key] = chartActivities[i - 1].Followups.ToString();
//////                    }
//////                    else
//////                    {
//////                        ChartX[key] = "";
//////                        ChartY[key] = "0";
//////                        ChartZ[key] = "0";
//////                    }
//////                }

//////                var companies = chartActivities.Select(a => a.Companies).ToArray();
//////                var followups = chartActivities.Select(a => a.Followups).ToArray();

//////                Lbl_company_total.Text = string.Format("جمع: {0}", companies.Any() ? companies.Sum() : 0);
//////                Lbl_company_avg.Text = string.Format("میانگین: {0:F2}", companies.Any() ? companies.Average() : 0.0);
//////                Lbl_company_highlight.Text = string.Format("بیشترین: {0}", companies.Any() ? companies.Max() : 0);
//////                Lbl_followup_total.Text = string.Format("جمع: {0}", followups.Any() ? followups.Sum() : 0);
//////                Lbl_followup_avg.Text = string.Format("میانگین: {0:F2}", followups.Any() ? followups.Average() : 0.0);
//////                Lbl_followup_highlight.Text = string.Format("بیشترین: {0}", followups.Any() ? followups.Max() : 0);
//////            }
//////            catch (FormatException ex)
//////            {
//////                System.Diagnostics.Debug.WriteLine(string.Format("FormatException in PopulateChartData: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
//////                ShowErrorMessage("داده‌های عددی در فعالیت‌ها نامعتبر هستند. لطفاً با مدیر سیستم تماس بگیرید.");
//////            }
//////            catch (Exception ex)
//////            {
//////                System.Diagnostics.Debug.WriteLine(string.Format("Error in PopulateChartData: {0} | StackTrace: {1}", ex.Message, ex.StackTrace));
//////                ShowErrorMessage("خطا در بارگذاری داده‌های نمودار: " + Server.HtmlEncode(ex.Message));
//////            }
//////        }  
        
//////        public string GetTruncatedDescription(object descriptionObj)
//////        {
//////            string description = descriptionObj == null ? string.Empty : descriptionObj.ToString();
//////            const int maxLength = 100;
//////            return description.Length <= maxLength ? description : description.Substring(0, maxLength) + "...";
//////        }

//////        protected void lnkTab_Click(object sender, EventArgs e)
//////        {
//////            var lnk = (LinkButton)sender;
//////            string type = lnk.CommandArgument;
//////            string idStaff = Request.QueryString[QueryParamIdStaff];
//////            ResponseRedirect(string.Format("activity_list.aspx?{0}={1}&{2}={3}", QueryParamIdStaff, idStaff, QueryParamType, type));
//////        }

//////        protected void lvActivities_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
//////        {
//////            var pager = (DataPager)lvActivities.FindControl("DataPager1");
//////            if (pager != null)
//////            {
//////                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
//////                LoadActivities();
//////            }
//////        }

//////        protected void btnBack_Click(object sender, EventArgs e)
//////        {
//////            ResponseRedirect(BackUrl);
//////        }

//////        private void ShowErrorMessage(string message)
//////        {
//////            lblMessage.Text = message;
//////            lblMessage.CssClass = "text-danger-message";
//////        }

//////        private void ShowInfoMessage(string message)
//////        {
//////            lblMessage.Text = message;
//////            lblMessage.CssClass = "text-info";
//////        }

//////        private void ResponseRedirect(string url)
//////        {
//////            Response.Redirect(url, false);
//////            Context.ApplicationInstance.CompleteRequest();
//////        }
//////    }
//////}
//using System;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.Script.Serialization;
//using System.Collections.Generic;
//using WebApplicationImpora2222025.Helper;

//namespace WebApplicationImpora2222025.panel.maneger
//{
//    public partial class activity_list : System.Web.UI.Page
//    {
//        private const string LoginPageUrl = "~/account/Login.aspx";
//        private const string BackUrl = "~/panel/maneger/staff_list.aspx";

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

//                LoadActivities();
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

//        private void LoadActivities()
//        {
//            // ================================================================================================
//            // بخش تست با داده‌های استاتیک - به طور پیش‌فرض فعال است
//            // برای استفاده از کد اصلی (خواندن از دیتابیس)، این بخش را از /* تا */ کامنت کنید.
//            // ================================================================================================
//            /* // Start of static data test block - COMMENT THIS LINE TO DISABLE
//            try
//            {
//                lblStaffName.Text = "کارمند تستی"; // نام نمایشی برای تست
//                imgStaff.ImageUrl = "../../img/default-user.png"; // تصویر پیش‌فرض

//                // داده‌های استاتیک برای ListView
//                var testActivitiesForListView = new List<object>
//                {
//                    new { id = 1, PersianDate = "1403/03/10", timeopen = "09:00", timeclose = "17:00", followup_count = 5, created_companies_count = 2, descriptionofday = "توضیحات تست ۱ برای ListView.", StaffName = "کارمند تستی" },
//                    new { id = 2, PersianDate = "1403/03/11", timeopen = "09:30", timeclose = "17:30", followup_count = 3, created_companies_count = 1, descriptionofday = "این یک متن طولانی تستی برای توضیحات است تا عملکرد نمایش بیشتر و کمتر بررسی شود. این متن باید بیش از صد کاراکتر داشته باشد.", StaffName = "کارمند تستی" }
//                };
//                lvActivities.DataSource = testActivitiesForListView;
//                lvActivities.DataBind();

//                // داده‌های استاتیک ساده‌شده برای نمودارها
//                var test_dates_array = new[] { "1403/03/10", "1403/03/11", "1403/03/12" };
//                var test_companies_array = new[] { 12, 19, 3 }; // مقادیر نمونه
//                var test_followups_array = new[] { 20, 5, 13 };  // مقادیر نمونه

//                var testChartDataSimplified = new
//                {
//                    dates = test_dates_array,
//                    companies = test_companies_array,
//                    followups = test_followups_array
//                };

//                var serializer = new JavaScriptSerializer();
//                litChartData.Text = string.Format(
//                    "<input type='hidden' id='chartData' value='{0}' />",
//                    Server.HtmlEncode(serializer.Serialize(testChartDataSimplified))
//                );

//                string chartTypeForTest = Request.QueryString["type"] ?? "week";
//                if (chartTypeForTest == "week") lblChartType.Text = "هفتگی (تستی)";
//                else if (chartTypeForTest == "month") lblChartType.Text = "ماهانه (تستی)";
//                else if (chartTypeForTest == "season") lblChartType.Text = "فصلی (تستی)";
//                else lblChartType.Text = "هفتگی (تستی)";

//                lblMessage.Text = "توجه: در حال نمایش داده‌های تستی استاتیک. برای دیدن داده‌های واقعی، کد تست را در بک‌اند کامنت کنید.";
//                lblMessage.CssClass = "text-warning";
//                return; // مهم: از ادامه اجرای متد جلوگیری می‌کند تا فقط داده‌های تستی نمایش داده شوند
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = "خطا در بخش تست استاتیک: " + Server.HtmlEncode(ex.Message);
//                lblMessage.CssClass = "text-danger";
//                return;
//            }
//            */
//            // End of static data test block - COMMENT THIS LINE TO DISABLE
//            // ================================================================================================
//            // پایان بخش تست با داده‌های استاتیک
//            // ================================================================================================


//            // کد اصلی شما برای خواندن از دیتابیس (اگر بخش تست بالا کامنت شده باشد، این بخش اجرا می‌شود)

//            try
//            {
//                string userRole = Session["role"] != null ? Session["role"].ToString() : string.Empty;
//                string[] allowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };
//                if (string.IsNullOrEmpty(userRole) || !allowedRoles.Contains(userRole))
//                {
//                    lblMessage.Text = "شما قادر به مشاهده فعالیت‌های این کارمند نیستید.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }

//                string idStaffStr = HttpUtility.HtmlEncode(Request.QueryString["id_staff"]);
//                int idStaff;
//                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
//                {
//                    lblMessage.Text = "شناسه کارمند نامعتبر یا ارائه نشده است.";
//                    lblMessage.CssClass = "text-danger";
//                    return;
//                }



//                string chartType = Request.QueryString["type"];
//                if (string.IsNullOrEmpty(chartType))
//                {
//                    chartType = "week";
//                }
//                if (chartType == "week")
//                {
//                    lblChartType.Text = "هفتگی";
//                }
//                else if (chartType == "month")
//                {
//                    lblChartType.Text = "ماهانه";
//                }
//                else if (chartType == "season")
//                {
//                    lblChartType.Text = "فصلی";
//                }
//                else
//                {
//                    chartType = "week";
//                    lblChartType.Text = "هفتگی";
//                }

//                DateTime startDate;
//                if (chartType == "week")
//                {
//                    startDate = DateTime.Now.AddDays(-7);
//                }
//                else if (chartType == "month")
//                {
//                    startDate = DateTime.Now.AddMonths(-1);
//                }
//                else
//                {
//                    startDate = DateTime.Now.AddMonths(-3);
//                }

//                using (var db = new DataClasses1DataContext())
//                {
//                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//                    if (staff == null)
//                    {
//                        lblMessage.Text = "کارمند با این شناسه یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        return;
//                    }

//                    lblStaffName.Text = (staff.Name != null ? staff.Name : "") + " " + (staff.Lastname != null ? staff.Lastname : "");

//                    bool hasActivities = db.ActivityLog_tbls.Any(a => a.id_user == idStaff);
//                    if (!hasActivities)
//                    {
//                        lblMessage.Text = "هیچ فعالیتی برای این کارمند یافت نشد.";
//                        lblMessage.CssClass = "text-danger";
//                        lvActivities.DataSource = new List<object>();
//                        lvActivities.DataBind();
//                        return;
//                    }

//                    var activitiesRaw = (from a in db.ActivityLog_tbls
//                                         join u in db.User_tbls on a.id_user equals u.id
//                                         where a.id_user == idStaff
//                                         select new
//                                         {
//                                             a.id,
//                                             a.id_user,
//                                             a.date,
//                                             a.timeopen,
//                                             a.timeclose,
//                                             a.followup_count,
//                                             a.created_companies_count,
//                                             a.descriptionofday,
//                                             StaffName = (u.Name ?? "") + " " + (u.Lastname ?? "")
//                                         }).ToList();

//                    var activities = activitiesRaw.Select(a => new
//                    {
//                        a.id,
//                        a.id_user,
//                        PersianDate = Formatter.ToPersianDate(a.date),
//                        timeopen = Formatter.ToHourMinute(a.timeopen),
//                        timeclose = Formatter.ToHourMinute(a.timeclose),
//                        followup_count = Formatter.SafeInt(a.followup_count),
//                        created_companies_count = Formatter.SafeInt(a.created_companies_count),
//                        descriptionofday = a.descriptionofday ?? "",
//                        a.StaffName
//                    }).ToList();

//                    var chartRaw = db.ActivityLog_tbls
//                        .Where(a => a.id_user == idStaff && a.date >= startDate)
//                        .ToList();

//                    var chartActivities = chartRaw
//                        .GroupBy(a => Formatter.ToPersianDate(a.date))
//                        .Select(g => new
//                        {
//                            PersianDate = g.Key,
//                            Companies = g.Sum(a => Formatter.SafeInt(a.created_companies_count)),
//                            Followups = g.Sum(a => Formatter.SafeInt(a.followup_count))
//                        })
//                        .OrderBy(a => a.PersianDate)
//                        .ToList();

//                    var chartData = new
//                    {
//                        dates = chartActivities.Select(a => a.PersianDate).ToArray(),
//                        companies = chartActivities.Select(a => a.Companies).ToArray(),
//                        followups = chartActivities.Select(a => a.Followups).ToArray()
//                    };

//                    var serializer = new JavaScriptSerializer();
//                    litChartData.Text = string.Format(
//                        "<input type='hidden' id='chartData' value='{0}' />", Server.HtmlEncode(serializer.Serialize(chartData))
//                    );

//                    lvActivities.DataSource = activities;
//                    lvActivities.DataBind();
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
//                    lblMessage.Text = "خطا در بارگذاری کارکردها: " + Server.HtmlEncode(ex.Message);
//                    lblMessage.CssClass = "text-danger";
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = "خطا در بارگذاری کارکردها: " + Server.HtmlEncode(ex.Message);
//                lblMessage.CssClass = "text-danger";
//            }
//        }

//        protected void lnkTab_Click(object sender, EventArgs e)
//        {
//            LinkButton lnk = (LinkButton)sender;
//            string type = lnk.CommandArgument;
//            string idStaff = HttpUtility.HtmlEncode(Request.QueryString["id_staff"]);
//            ResponseRedirect("activity_list.aspx?id_staff=" + idStaff + "&type=" + type);
//        }

//        protected void lvActivities_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
//        {
//            DataPager pager = lvActivities.FindControl("DataPager1") as DataPager;
//            if (pager != null)
//            {
//                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
//                LoadActivities();
//            }
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            ResponseRedirect(BackUrl);
//        }

//        private void ResponseRedirect(string url)
//        {
//            Response.Redirect(url, false);
//            HttpContext.Current.ApplicationInstance.CompleteRequest();
//        }
//    }
//}
//using System;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.Script.Serialization;
//using System.Collections.Generic;
//using WebApplicationImpora2222025.Helper;

//namespace WebApplicationImpora2222025.panel.maneger
//{
//    public partial class activity_list : System.Web.UI.Page
//    {
//        public static string y_1 = null;
//        public static string y_2 = null;
//        public static string y_3 = null;
//        public static string y_4 = null;
//        public static string y_5 = null;
//        public static string y_6 = null;
//        public static string y_7 = null;
//        public static string y_8 = null;
//        public static string y_9 = null;
//        public static string y_10 = null;
//        public static string y_11 = null;
//        public static string y_12 = null;
//        public static string y_13 = null;
//        public static string y_14 = null;
//        public static string y_15 = null;
//        public static string y_16 = null;
//        public static string y_17 = null;
//        public static string y_18 = null;
//        public static string y_19 = null;
//        public static string y_20 = null;
//        public static string y_21 = null;
//        public static string y_22 = null;
//        public static string y_23 = null;
//        public static string y_24 = null;
//        public static string y_25 = null;
//        public static string y_26 = null;
//        public static string y_27 = null;
//        public static string y_28 = null;
//        public static string y_29 = null;
//        public static string y_30 = null;

//        public static string x_1 = null;
//        public static string x_2 = null;
//        public static string x_3 = null;
//        public static string x_4 = null;
//        public static string x_5 = null;
//        public static string x_6 = null;
//        public static string x_7 = null;
//        public static string x_8 = null;
//        public static string x_9 = null;
//        public static string x_10 = null;
//        public static string x_11 = null;
//        public static string x_12 = null;
//        public static string x_13 = null;
//        public static string x_14 = null;
//        public static string x_15 = null;
//        public static string x_16 = null;
//        public static string x_17 = null;
//        public static string x_18 = null;
//        public static string x_19 = null;
//        public static string x_20 = null;
//        public static string x_21 = null;
//        public static string x_22 = null;
//        public static string x_23 = null;
//        public static string x_24 = null;
//        public static string x_25 = null;
//        public static string x_26 = null;
//        public static string x_27 = null;
//        public static string x_28 = null;
//        public static string x_29 = null;
//        public static string x_30 = null;

//        public static string z_1 = null;
//        public static string z_2 = null;
//        public static string z_3 = null;
//        public static string z_4 = null;
//        public static string z_5 = null;
//        public static string z_6 = null;
//        public static string z_7 = null;
//        public static string z_8 = null;
//        public static string z_9 = null;
//        public static string z_10 = null;
//        public static string z_11 = null;
//        public static string z_12 = null;
//        public static string z_13 = null;
//        public static string z_14 = null;
//        public static string z_15 = null;
//        public static string z_16 = null;
//        public static string z_17 = null;
//        public static string z_18 = null;
//        public static string z_19 = null;
//        public static string z_20 = null;
//        public static string z_21 = null;
//        public static string z_22 = null;
//        public static string z_23 = null;
//        public static string z_24 = null;
//        public static string z_25 = null;
//        public static string z_26 = null;
//        public static string z_27 = null;
//        public static string z_28 = null;
//        public static string z_29 = null;
//        public static string z_30 = null;

//        public const string QueryParamIdStaff = "id_staff";
//        public const string QueryParamType = "type";
//        private const string LoginPageUrl = "~/account/Login.aspx";
//        private const string BackUrl = "~/panel/maneger/staff_list.aspx";
//        private static readonly string[] AllowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };

//        protected void Page_Load(object sender, EventArgs e)
//        {
          

//            if (!IsPostBack)
//            {
//                if (Session["role"] == null || Session["mobile"] == null)
//                {
//                    Session.Abandon();
//                    ResponseRedirect(LoginPageUrl);
//                    return;
//                }

//                LoadActivities();
//            }
//        }

//        private void LoadActivities()
//        {
//            try
//            {
//                string userRole = Session["role"] != null ? Session["role"].ToString() : string.Empty;
//                if (string.IsNullOrEmpty(userRole) || !AllowedRoles.Contains(userRole))
//                {
//                    lblMessage.Text = "شما قادر به مشاهده فعالیت‌های این کارمند نیستید.";
//                    lblMessage.CssClass = "text-danger-message";
//                    return;
//                }

//                string idStaffStr = Request.QueryString[QueryParamIdStaff];

//                // --- C# 5 COMPATIBLE 'out' VARIABLE ---
//                // 1. Declare the variable first.
//                int idStaff;
//                // 2. Use it in TryParse.
//                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
//                {
//                    lblMessage.Text = "شناسه کارمند نامعتبر یا ارائه نشده است.";
//                    lblMessage.CssClass = "text-danger-message";
//                    return;
//                }
//                // --- End of fix ---

//                string chartType = Request.QueryString[QueryParamType] ?? "week";
//                DateTime startDate;
//                switch (chartType.ToLower())
//                {
//                    case "month":
//                        lblChartType.Text = "ماهانه";
//                        startDate = DateTime.Now.AddMonths(-1);
//                        break;
//                    case "season":
//                        lblChartType.Text = "فصلی";
//                        startDate = DateTime.Now.AddMonths(-3);
//                        break;
//                    default:
//                        lblChartType.Text = "هفتگی";
//                        startDate = DateTime.Now.AddDays(-7);
//                        chartType = "week";
//                        break;
//                }

//                using (var db = new DataClasses1DataContext())
//                {
//                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//                    if (staff == null)
//                    {
//                        lblMessage.Text = "کارمند با این شناسه یافت نشد.";
//                        lblMessage.CssClass = "text-danger-message";
//                        return;
//                    }

//                    lblStaffName.Text = string.Format("{0} {1}", staff.Name ?? "", staff.Lastname ?? "").Trim();
//                    // imgStaff.ImageUrl = !string.IsNullOrEmpty(staff.ProfileImageUrl) ? ResolveUrl(staff.ProfileImageUrl) : ResolveUrl("~/img/default-user.png");

//                    if (!db.ActivityLog_tbls.Any(a => a.id_user == idStaff))
//                    {
//                        lblMessage.Text = "هیچ فعالیتی برای این کارمند یافت نشد.";
//                        lblMessage.CssClass = "text-info";
//                        lvActivities.DataSource = new List<object>();
//                        lvActivities.DataBind();
//                        //litChartData.Text = "<input type='hidden' id='chartData' value='{\"dates\":[],\"companies\":[],\"followups\":[]}' />";
//                        return;
//                    }

//                    var activitiesRaw = (from a in db.ActivityLog_tbls
//                                         join u in db.User_tbls on a.id_user equals u.id
//                                         where a.id_user == idStaff
//                                         orderby a.date descending, a.timeopen descending
//                                         select new
//                                         {
//                                             a.id,
//                                             a.date,
//                                             a.timeopen,
//                                             a.timeclose,
//                                             a.followup_count,
//                                             a.created_companies_count,
//                                             a.descriptionofday
//                                         }).ToList();

//                    var activities = activitiesRaw.Select(a => new
//                    {
//                        a.id,
//                        PersianDate = Formatter.ToPersianDate(a.date),
//                        timeopen = Formatter.ToHourMinute(a.timeopen),
//                        timeclose = Formatter.ToHourMinute(a.timeclose),
//                        followup_count = Formatter.SafeInt(a.followup_count),
//                        created_companies_count = Formatter.SafeInt(a.created_companies_count),
//                        descriptionofday = a.descriptionofday ?? ""
//                    }).ToList();

//                    //lvActivities.DataSource = activities;
//                    //lvActivities.DataBind();
//                    ///////////////////////////////////////////////////////////////////////////////////////////
//                //////    // داده‌های استاتیک برای ListView و نمودارها
//                //////    var testActivities = new List<object>
//                //////{
//                //////    new { id = 1, PersianDate = "1404/03/15", timeopen = "09:00", timeclose = "17:00", followup_count = 8, created_companies_count = 3, descriptionofday = "پیگیری مشتریان و ثبت شرکت جدید", StaffName = "کارمند تستی" },
//                //////    new { id = 2, PersianDate = "1404/03/16", timeopen = "08:30", timeclose = "16:30", followup_count = 12, created_companies_count = 5, descriptionofday = "جلسه با مشتریان و ثبت دو شرکت", StaffName = "کارمند تستی" },
//                //////    new { id = 3, PersianDate = "1404/03/17", timeopen = "09:15", timeclose = "17:15", followup_count = 10, created_companies_count = 4, descriptionofday = "کار روی قراردادها و پیگیری‌های روزانه", StaffName = "کارمند تستی" }
//                //////};

//                //////    lvActivities.DataSource = testActivities;
//                //////    lvActivities.DataBind();

//                //////    // داده‌های استاتیک برای نمودارها
//                //////    var testChartActivities = new[]
//                //////{
//                //////    new { PersianDate = "1404/03/15", Companies = 3, Followups = 8 },
//                //////    new { PersianDate = "1404/03/16", Companies = 5, Followups = 12 },
//                //////    new { PersianDate = "1404/03/17", Companies = 4, Followups = 10 }
//                //////};

//                //////    var serializer = new JavaScriptSerializer();
//                //////    ChartLabelsJson = serializer.Serialize(testChartActivities.Select(a => a.PersianDate));
//                //////    CompaniesDataJson = serializer.Serialize(testChartActivities.Select(a => a.Companies));
//                //////    FollowupsDataJson = serializer.Serialize(testChartActivities.Select(a => a.Followups));

//                //////    var chartData = new
//                //////    {
//                //////        dates = testChartActivities.Select(a => a.PersianDate).ToArray(),
//                //////        companies = testChartActivities.Select(a => a.Companies).ToArray(),
//                //////        followups = testChartActivities.Select(a => a.Followups).ToArray()
//                //////    };


//                //////    // --- بخش جدید: مقداردهی پراپرتی‌های عمومی ---
//                //////    var chartRawData = activitiesRaw.Where(a => a.date >= startDate).ToList();
//                //////    var chartActivities = chartRawData
//                //////        .GroupBy(a => Formatter.ToPersianDate(a.date))
//                //////        .Select(g => new
//                //////        {
//                //////            PersianDate = g.Key,
//                //////            Companies = g.Sum(a => Formatter.SafeInt(a.created_companies_count)),
//                //////            Followups = g.Sum(a => Formatter.SafeInt(a.followup_count))
//                //////        })
//                //////        .OrderBy(a => a.PersianDate).ToList();
//                    ////////////////////////////////////////////////////////////////////////////////
//                    // سریالایز کردن داده‌ها و ریختن در پراپرتی‌های عمومی
//                    var serializer = new JavaScriptSerializer();
//                    ChartLabelsJson = serializer.Serialize(chartActivities.Select(a => a.PersianDate));
//                    CompaniesDataJson = serializer.Serialize(chartActivities.Select(a => a.Companies));
//                    FollowupsDataJson = serializer.Serialize(chartActivities.Select(a => a.Followups));




//                    var chartData = new
//                    {
//                        dates = chartActivities.Select(a => a.PersianDate).ToArray(),
//                        companies = chartActivities.Select(a => a.Companies).ToArray(),
//                        followups = chartActivities.Select(a => a.Followups).ToArray()
//                    };

//                    var serializer = new JavaScriptSerializer();
//                    litChartData.Text = string.Format(
//                        "<input type='hidden' id='chartData' value='{0}' />",
//                        Server.HtmlEncode(serializer.Serialize(chartData))
//                    );
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                if (ex.Source == "PersianDate")
//                {
//                    lblMessage.Text = "خطا در تبدیل تاریخ شمسی.";
//                    lblMessage.CssClass = "text-danger-message";
//                }
//                else
//                {
//                    lblMessage.Text = "خطای آرگومان: " + Server.HtmlEncode(ex.Message);
//                    lblMessage.CssClass = "text-danger-message";
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = "خطا در بارگذاری کارکردها: " + Server.HtmlEncode(ex.Message);
//                lblMessage.CssClass = "text-danger-message";
//            }
//        }

//        public string GetTruncatedDescription(object descriptionObj)
//        {
//            string description = descriptionObj == null ? string.Empty : descriptionObj.ToString();
//            const int maxLength = 100;
//            if (description.Length <= maxLength)
//            {
//                return description;
//            }
//            return description.Substring(0, maxLength) + "...";
//        }

//        protected void lnkTab_Click(object sender, EventArgs e)
//        {
//            var lnk = (LinkButton)sender;
//            string type = lnk.CommandArgument;
//            string idStaff = Request.QueryString[QueryParamIdStaff];
//            ResponseRedirect(string.Format("activity_list.aspx?{0}={1}&{2}={3}", QueryParamIdStaff, idStaff, QueryParamType, type));
//        }

//        protected void lvActivities_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
//        {
//            var pager = (DataPager)lvActivities.FindControl("DataPager1");
//            if (pager != null)
//            {
//                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
//                LoadActivities();
//            }
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            ResponseRedirect(BackUrl);
//        }

//        private void ResponseRedirect(string url)
//        {
//            Response.Redirect(url, false);
//            Context.ApplicationInstance.CompleteRequest();
//        }
//    }
//}
//using System;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Collections.Generic;
//using WebApplicationImpora2222025.Helper;

//namespace WebApplicationImpora2222025.panel.maneger
//{
//    public partial class activity_list : System.Web.UI.Page
//    {
//        public static string y_1 = null, y_2 = null, y_3 = null, y_4 = null, y_5 = null, y_6 = null, y_7 = null, y_8 = null, y_9 = null, y_10 = null,
//                            y_11 = null, y_12 = null, y_13 = null, y_14 = null, y_15 = null, y_16 = null, y_17 = null, y_18 = null, y_19 = null, y_20 = null,
//                            y_21 = null, y_22 = null, y_23 = null, y_24 = null, y_25 = null, y_26 = null, y_27 = null, y_28 = null, y_29 = null, y_30 = null;

//        public static string x_1 = null, x_2 = null, x_3 = null, x_4 = null, x_5 = null, x_6 = null, x_7 = null, x_8 = null, x_9 = null, x_10 = null,
//                            x_11 = null, x_12 = null, x_13 = null, x_14 = null, x_15 = null, x_16 = null, x_17 = null, x_18 = null, x_19 = null, x_20 = null,
//                            x_21 = null, x_22 = null, x_23 = null, x_24 = null, x_25 = null, x_26 = null, x_27 = null, x_28 = null, x_29 = null, x_30 = null;

//        public static string z_1 = null, z_2 = null, z_3 = null, z_4 = null, z_5 = null, z_6 = null, z_7 = null, z_8 = null, z_9 = null, z_10 = null,
//                            z_11 = null, z_12 = null, z_13 = null, z_14 = null, z_15 = null, z_16 = null, z_17 = null, z_18 = null, z_19 = null, z_20 = null,
//                            z_21 = null, z_22 = null, z_23 = null, z_24 = null, z_25 = null, z_26 = null, z_27 = null, z_28 = null, z_29 = null, z_30 = null;

//        public const string QueryParamIdStaff = "id_staff";
//        public const string QueryParamType = "type";
//        private const string LoginPageUrl = "~/account/Login.aspx";
//        private const string BackUrl = "~/panel/maneger/staff_list.aspx";
//        private static readonly string[] AllowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                if (Session["role"] == null || Session["mobile"] == null)
//                {
//                    Session.Abandon();
//                    ResponseRedirect(LoginPageUrl);
//                    return;
//                }

//                LoadActivities();
//            }
//        }

//        private void LoadActivities()
//        {
//            try
//            {
//                string userRole = Session["role"] != null ? Session["role"].ToString() : string.Empty;
//                if (string.IsNullOrEmpty(userRole) || !AllowedRoles.Contains(userRole))
//                {
//                    lblMessage.Text = "شما قادر به مشاهده فعالیت‌های این کارمند نیستید.";
//                    lblMessage.CssClass = "text-danger-message";
//                    return;
//                }

//                string idStaffStr = Request.QueryString[QueryParamIdStaff];
//                int idStaff;
//                if (string.IsNullOrEmpty(idStaffStr) || !int.TryParse(idStaffStr, out idStaff))
//                {
//                    lblMessage.Text = "شناسه کارمند نامعتبر یا ارائه نشده است.";
//                    lblMessage.CssClass = "text-danger-message";
//                    return;
//                }

//                string chartType = Request.QueryString[QueryParamType] ?? "week";
//                DateTime startDate;
//                switch (chartType.ToLower())
//                {
//                    case "month":
//                        lblChartType.Text = "ماهانه";
//                        startDate = DateTime.Now.AddMonths(-1);
//                        break;
//                    case "season":
//                        lblChartType.Text = "فصلی";
//                        startDate = DateTime.Now.AddMonths(-3);
//                        break;
//                    default:
//                        lblChartType.Text = "هفتگی";
//                        startDate = DateTime.Now.AddDays(-7);
//                        chartType = "week";
//                        break;
//                }

//                using (var db = new DataClasses1DataContext())
//                {
//                    var staff = db.User_tbls.SingleOrDefault(u => u.id == idStaff);
//                    if (staff == null)
//                    {
//                        lblMessage.Text = "کارمند با این شناسه یافت نشد.";
//                        lblMessage.CssClass = "text-danger-message";
//                        return;
//                    }

//                    lblStaffName.Text = string.Format("{0} {1}", staff.Name ?? "", staff.Lastname ?? "").Trim();

//                    if (!db.ActivityLog_tbls.Any(a => a.id_user == idStaff))
//                    {
//                        lblMessage.Text = "هیچ فعالیتی برای این کارمند یافت نشد.";
//                        lblMessage.CssClass = "text-info";
//                        lvActivities.DataSource = new List<object>();
//                        lvActivities.DataBind();
//                        return;
//                    }

//                    var activitiesRaw = (from a in db.ActivityLog_tbls
//                                         join u in db.User_tbls on a.id_user equals u.id
//                                         where a.id_user == idStaff
//                                         orderby a.date descending, a.timeopen descending
//                                         select new
//                                         {
//                                             a.id,
//                                             a.date,
//                                             a.timeopen,
//                                             a.timeclose,
//                                             a.followup_count,
//                                             a.created_companies_count,
//                                             a.descriptionofday
//                                         }).ToArray();

//                    var activities = activitiesRaw.Select(a => new
//                    {
//                        a.id,
//                        PersianDate = Formatter.ToPersianDate(a.date),
//                        timeopen = Formatter.ToHourMinute(a.timeopen),
//                        timeclose = Formatter.ToHourMinute(a.timeclose),
//                        followup_count = Formatter.SafeInt(a.followup_count),
//                        created_companies_count = Formatter.SafeInt(a.created_companies_count),
//                        descriptionofday = a.descriptionofday ?? ""
//                    }).ToList();
//                    lvActivities.DataSource = activities;
//                    lvActivities.DataBind();

//                    // Chart data
//                    var chartRawData = activitiesRaw.Where(a => a.date >= startDate).ToList();
//                    var chartActivities = chartRawData
//                        .GroupBy(a => Formatter.ToPersianDate(a.date))
//                        .Select(g => new
//                        {
//                            PersianDate = g.Key,
//                            Companies = g.Sum(a => Formatter.SafeInt(a.created_companies_count)),
//                            Followups = g.Sum(a => Formatter.SafeInt(a.followup_count))
//                        })
//                        .OrderBy(a => a.PersianDate)
//                        .Take(30) // Limit to 30 days
//                        .ToList();

//                    // Initialize x_1 to x_30, y_1 to y_30, z_1 to z_30 (C# 5 compatible)
//                    for (int i = 1; i <= 30; i++)
//                    {
//                        var fieldX = typeof(activity_list).GetField(string.Format("x_{0}", i));
//                        var fieldY = typeof(activity_list).GetField(string.Format("y_{0}", i));
//                        var fieldZ = typeof(activity_list).GetField(string.Format("z_{0}", i));

//                        if (i <= chartActivities.Count)
//                        {
//                            fieldX.SetValue(null, chartActivities[i - 1].PersianDate);
//                            fieldY.SetValue(null, chartActivities[i - 1].Companies.ToString());
//                            fieldZ.SetValue(null, chartActivities[i - 1].Followups.ToString());
//                        }
//                        else
//                        {
//                            fieldX.SetValue(null, null);
//                            fieldY.SetValue(null, "0");
//                            fieldZ.SetValue(null, "0");
//                        }
//                    }

//                    // Populate chart summary labels (C# 5 compatible)
//                    var companies = chartActivities.Select(a => a.Companies).ToArray();
//                    var followups = chartActivities.Select(a => a.Followups).ToArray();
//                    Lbl_company_total.Text = string.Format("جمع: {0}", companies.Any() ? companies.Sum() : 0);
//                    Lbl_company_avg.Text = string.Format("میانگین: {0:F2}", companies.Any() ? companies.Average() : 0);
//                    Lbl_company_highlight.Text = string.Format("بیشترین: {0}", companies.Any() ? companies.Max() : 0);
//                    Lbl_followup_total.Text = string.Format("جمع: {0}", followups.Any() ? followups.Sum() : 0);
//                    Lbl_followup_avg.Text = string.Format("میانگین: {0:F2}", followups.Any() ? followups.Average() : 0);
//                    Lbl_followup_highlight.Text = string.Format("بیشترین: {0}", followups.Any() ? followups.Max() : 0);
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                if (ex.Source == "PersianDate")
//                {
//                    lblMessage.Text = "خطا در تبدیل تاریخ شمسی.";
//                    lblMessage.CssClass = "text-danger-message";
//                }
//                else
//                {
//                    lblMessage.Text = "خطای آرگومان: " + Server.HtmlEncode(ex.Message);
//                    lblMessage.CssClass = "text-danger-message";
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = "خطا در بارگذاری کارکردها: " + Server.HtmlEncode(ex.Message);
//                lblMessage.CssClass = "text-danger-message";
//            }
//        }

//        public string GetTruncatedDescription(object descriptionObj)
//        {
//            string description = descriptionObj == null ? string.Empty : descriptionObj.ToString();
//            const int maxLength = 100;
//            if (description.Length <= maxLength)
//            {
//                return description;
//            }
//            return description.Substring(0, maxLength) + "...";
//        }

//        protected void lnkTab_Click(object sender, EventArgs e)
//        {
//            var lnk = (LinkButton)sender;
//            string type = lnk.CommandArgument;
//            string idStaff = Request.QueryString[QueryParamIdStaff];
//            ResponseRedirect(string.Format("activity_list.aspx?{0}={1}&{2}={3}", QueryParamIdStaff, idStaff, QueryParamType, type));
//        }

//        protected void lvActivities_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
//        {
//            var pager = (DataPager)lvActivities.FindControl("DataPager1");
//            if (pager != null)
//            {
//                pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
//                LoadActivities();
//            }
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            ResponseRedirect(BackUrl);
//        }

//        private void ResponseRedirect(string url)
//        {
//            Response.Redirect(url, false);
//            Context.ApplicationInstance.CompleteRequest();
//        }
//    }
//}

