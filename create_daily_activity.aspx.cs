using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class create_daily_activity : System.Web.UI.Page
    {
        // Constants for redirect URLs
        private const string LoginPageUrl = "~/account/Login.aspx";
        private const string ActivityListUrl = "~/panel/maneger/activity_list.aspx";
        private const string BackUrl = "~/panel/maneger/profile.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is authenticated
                if (Session["mobile"] == null || Session["role"] == null)
                {
                    Session.Abandon();
                    ResponseRedirect(LoginPageUrl);
                    return;
                }

                // Set today's Persian date (read-only)
                try
                {
                    txtDate.Text = Helper.PersianDate.GetPersianDate();
                    // Populate follow-up and company counts for today
                    PopulateActivityCounts(DateTime.Today);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "خطا در بارگذاری تاریخ یا تعداد فعالیت‌ها: " + ex.Message;
                    lblMessage.CssClass = "text-danger";
                }
            }
        }

        private void PopulateActivityCounts(DateTime activityDate)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    string mobile = Session["mobile"].ToString();
                    var user = db.User_tbls.SingleOrDefault(c => c.Phone == mobile);
                    if (user == null)
                    {
                        lblMessage.Text = "کاربر یافت نشد.";
                        return;
                    }

                    // Get today's Persian date for comparison
                    string persianDate = Helper.PersianDate.GetPersianDate(activityDate);

                    // Count follow-ups from Project_Commerce_Log_tbl
                    int followupCount = db.Project_Commerce_Log_tbls
                        .Count(log => log.id_Staff == user.id && log.datecreate == persianDate);

                    // Count companies created from Company_tbl
                    int createdCompaniesCount = db.Company_tbls
                        .Count(c => c.id_Staff == user.id && c.Date_Create == persianDate);

                    txtFollowupCount.Text = followupCount.ToString();
                    txtCreatedCompaniesCount.Text = createdCompaniesCount.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log error (e.g., using Serilog)
                lblMessage.Text = "خطا در محاسبه تعداد پیگیری‌ها یا شرکت‌ها: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        string mobile = Session["mobile"].ToString();
                        var user = db.User_tbls.SingleOrDefault(c => c.Phone == mobile);
                        if (user == null)
                        {
                            lblMessage.Text = "کاربر یافت نشد.";
                            return;
                        }

                        // Use today's date
                        DateTime activityDate = DateTime.Today;

                        // Check if user already logged activity for today
                        var existingActivity = db.ActivityLog_tbls
                            .SingleOrDefault(a => a.id_user == user.id && a.date == activityDate);

                        if (existingActivity != null)
                        {
                            lblMessage.Text = "شما قبلاً برای امروز کارکرد ثبت کرده‌اید.";
                            return;
                        }

                        // Parse time inputs
                        TimeSpan timeOpen;
                        TimeSpan timeClose;
                        if (!TimeSpan.TryParse(txtTimeOpen.Text, out timeOpen) || !TimeSpan.TryParse(txtTimeClose.Text, out timeClose))
                        {
                            lblMessage.Text = "فرمت زمان نامعتبر است.";
                            return;
                        }

                        // Parse numeric inputs (read-only, populated by PopulateActivityCounts)
                        int followupCount;
                        int createdCompaniesCount;
                        if (!int.TryParse(txtFollowupCount.Text, out followupCount) || !int.TryParse(txtCreatedCompaniesCount.Text, out createdCompaniesCount))
                        {
                            lblMessage.Text = "تعداد پیگیری‌ها یا شرکت‌ها باید عددی معتبر باشد.";
                            return;
                        }

                        // Insert new activity
                        var activity = new ActivityLog_tbl
                        {
                            id_user = user.id,
                            date = activityDate,
                            descriptionofday = txtDescription.Value.Trim(),
                            timeopen = timeOpen,
                            timeclose = timeClose,
                            followup_count = followupCount,
                            created_companies_count = createdCompaniesCount
                        };

                        db.ActivityLog_tbls.InsertOnSubmit(activity);
                        db.SubmitChanges();

                        lblMessage.Text = "کارکرد روزانه با موفقیت ثبت شد.";
                        lblMessage.CssClass = "text-success";
                    }
                }
                catch (Exception ex)
                {
                    // Log error (e.g., using Serilog)
                    lblMessage.Text = "خطایی رخ داد: " + ex.Message;
                    lblMessage.CssClass = "text-danger";
                }
            }
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            ResponseRedirect(ActivityListUrl);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ResponseRedirect(BackUrl);
        }

        private void ResponseRedirect(string url)
        {
            Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}