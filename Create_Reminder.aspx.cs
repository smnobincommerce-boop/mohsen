using System;
using System.Linq;
using System.Web.UI;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Create_Reminder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check session
                if (Session["mobile"] == null || string.IsNullOrEmpty(Session["mobile"].ToString()))
                {
                    Response.Redirect("~/exit_panel");
                    return;
                }

                // Get company ID from query string
                string companyId = Request.QueryString["ID"];
                int id;
                if (string.IsNullOrEmpty(companyId) || !int.TryParse(companyId, out id))
                {
                    lblMessage.Text = "شناسه شرکت نامعتبر است.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    btnCreate.Enabled = false;
                    return;
                }

                // Load company details
                using (var db = new DataClasses1DataContext())
                {
                    var company = db.Company_tbls.SingleOrDefault(c => c.id == id);
                    if (company == null)
                    {
                        lblMessage.Text = "شرکت یافت نشد.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        btnCreate.Enabled = false;
                        return;
                    }

                    txtCompanyName.Text = company.Company_Name;
                    hfCompanyId.Value = company.id.ToString();
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    // Get user
                    var user = db.User_tbls.SingleOrDefault(u => u.Phone == Session["mobile"].ToString());
                    if (user == null)
                    {
                        lblMessage.Text = "کاربر یافت نشد.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // Get company ID
                    int companyId;
                    if (!int.TryParse(hfCompanyId.Value, out companyId))
                    {
                        lblMessage.Text = "شناسه شرکت نامعتبر است.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // Validate Persian date
                    string persianDate = txtDateRemind.Text.Trim();
                    if (!System.Text.RegularExpressions.Regex.IsMatch(persianDate, @"^\d{4}/\d{2}/\d{2}$"))
                    {
                        lblMessage.Text = "فرمت تاریخ شمسی نامعتبر است (مثال: 1404/03/08).";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }


                    try
                    {
                        // بررسی HiddenField که باید حاوی تاریخ میلادی باشد
                        string gregorianDate = hfGregorianDate.Value;
                        DateTime dateRemind;

                        if (string.IsNullOrWhiteSpace(gregorianDate))
                        {
                            // اگر HiddenField خالی باشد، از تکست‌باکس تاریخ شمسی را تبدیل می‌کنیم
                            if (string.IsNullOrWhiteSpace(txtDateRemind.Text))
                            {
                                lblMessage.Text = "تاریخ واردشده خالی است.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                return;
                            }

                            gregorianDate = PersianDate.ConvertPersianToGregorian(txtDateRemind.Text);
                        }

                        // تلاش برای تبدیل رشته تاریخ میلادی به DateTime
                        if (!DateTime.TryParse(gregorianDate, out dateRemind))
                        {
                            lblMessage.Text = "تبدیل به تاریخ میلادی ناموفق بود.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        // در اینجا dateRemind یک تاریخ میلادی معتبر است و می‌توانید از آن استفاده کنید
                        // مثلاً: ذخیره در دیتابیس یا پردازش‌های دیگر

                        TimeSpan timeRemind;
                        if (!TimeSpan.TryParse(txtTimeRemind.Text, out timeRemind))
                        {
                            lblMessage.Text = "فرمت زمان یادآوری نامعتبر است.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        // Validate title length
                        string title = txtTitle.Text.Trim();
                        if (title.Length > 200)
                        {
                            lblMessage.Text = "عنوان یادآوری نمی‌تواند بیش از 200 کاراکتر باشد.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        // Create reminder

                        var reminder = new Reminder_tbl
                        {
                            id_staff = user.id,
                            id_company = companyId,
                            id_manger = null,
                            date_remind = dateRemind.Date,
                            time_remind = timeRemind,
                            date_create = PersianDate.GetPersianDate(DateTime.Now),
                            title_reminder = title
                        };

                        db.Reminder_tbls.InsertOnSubmit(reminder);
                        db.SubmitChanges();

                        lblMessage.Text = "یادآوری با موفقیت ایجاد شد.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        btnCreate.Enabled = false;

                        // Optional: Log activity
                        try
                        {
                            db.P_Insert_activity_tbl(user.id, DateTime.Now, DateTime.Now.TimeOfDay,
                                user.Name + " یادآوری '" + reminder.title_reminder + "' برای شرکت با شناسه " + companyId + " ایجاد کرد");
                        }
                        catch
                        {
                            // Log failure silently
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        // مدیریت خطاهای مربوط به فرمت نادرست یا مقادیر نامعتبر
                        lblMessage.Text = "فرمت تاریخ نامعتبر است: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    catch (Exception ex)
                    {
                        // مدیریت سایر خطاها
                        lblMessage.Text = "خطایی در پردازش تاریخ رخ داد: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }

                    // Validate time
                  
                 
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در ایجاد یادآوری: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }






        
    }
}