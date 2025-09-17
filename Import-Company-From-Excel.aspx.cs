
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Import_Company_From_Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check user session
                if (Session["mobile"] == null || string.IsNullOrEmpty(Session["mobile"].ToString()))
                {
                    Response.Redirect("~/exit_panel");
                    return;
                }
            }
            // Note: LicenseContext is not needed for EPPlus 4.5.3.3 or 4.5.3.2
            // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate file upload
                if (!Page.IsValid || !fileUploadExcel.HasFile)
                {
                    lblMessage.Text = "لطفاً یک فایل اکسل معتبر انتخاب کنید.";
                    return;
                }

                // Check file extension
                if (!fileUploadExcel.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    lblMessage.Text = "فقط فایل‌های با فرمت .xlsx مجاز هستند.";
                    return;
                }

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // Validate user
                    User_tbl user = db.User_tbls.SingleOrDefault(u => u.Phone == Session["mobile"].ToString());
                    if (user == null)
                    {
                        lblMessage.Text = "خطا: کاربر یافت نشد.";
                        return;
                    }

                    // Read Excel file
                    using (Stream stream = fileUploadExcel.PostedFile.InputStream)
                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet == null || worksheet.Dimension == null)
                        {
                            lblMessage.Text = "فایل اکسل خالی یا نامعتبر است.";
                            return;
                        }

                        // Validate headers
                        string[] expectedHeaders = new string[] { 
                            "نام شرکت", "نام فرد شرکت", "سمت فرد", "شماره‌های ثابت شرکت", 
                            "شماره موبایل", "ایمیل", "وب‌سایت", "آدرس", 
                            "حوزه فعالیت", "شرحی مختصری از شرکت" 
                        };
                        for (int i = 1; i <= expectedHeaders.Length; i++)
                        {
                            string header = worksheet.Cells[1, i].Text != null ? worksheet.Cells[1, i].Text.Trim() : string.Empty;
                            if (header != expectedHeaders[i - 1])
                            {
                                lblMessage.Text = string.Format("هدر ستون {0} باید '{1}' باشد.", i, expectedHeaders[i - 1]);
                                return;
                            }
                        }

                     

                        // Process rows
                        int rowCount = worksheet.Dimension.Rows;
                        int importedCount = 0;
                        List<object> errors = new List<object>();
                        string currentDate = PersianDate.GetPersianDate(DateTime.Now);

                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                // Read row data
                                string companyName = worksheet.Cells[row, 1].Text != null ? worksheet.Cells[row, 1].Text.Trim() : string.Empty;
                                string personName = worksheet.Cells[row, 2].Text != null ? worksheet.Cells[row, 2].Text.Trim() : string.Empty;
                                string position = worksheet.Cells[row, 3].Text != null ? worksheet.Cells[row, 3].Text.Trim() : string.Empty;
                                string phoneNumber = worksheet.Cells[row, 4].Text != null ? worksheet.Cells[row, 4].Text.Trim() : string.Empty;
                                string mobileNumber = worksheet.Cells[row, 5].Text != null ? worksheet.Cells[row, 5].Text.Trim() : string.Empty;
                                string email = worksheet.Cells[row, 6].Text != null ? worksheet.Cells[row, 6].Text.Trim() : string.Empty;
                                string website = worksheet.Cells[row, 7].Text != null ? worksheet.Cells[row, 7].Text.Trim() : string.Empty;
                                string address = worksheet.Cells[row, 8].Text != null ? worksheet.Cells[row, 8].Text.Trim() : string.Empty;
                                string fieldOfActivity = worksheet.Cells[row, 9].Text != null ? worksheet.Cells[row, 9].Text.Trim() : string.Empty;
                                string description = worksheet.Cells[row, 10].Text != null ? worksheet.Cells[row, 10].Text.Trim() : null;

                                // Validate data
                                if (string.IsNullOrEmpty(companyName))
                                {
                                    errors.Add(new { Row = row, Error = "نام شرکت الزامی است." });
                                    continue;
                                }

                                if (companyName.Length > 100)
                                {
                                    errors.Add(new { Row = row, Error = "نام شرکت بیش از 100 کاراکتر است." });
                                    continue;
                                }

                                // Check for duplicate company name (case-insensitive)
                                if (db.Company_tbls.Any(c => c.Company_Name != null && c.Company_Name.ToLower() == companyName.ToLower()))
                                {
                                    errors.Add(new { Row = row, Error = "نام شرکت قبلاً ثبت شده است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(personName) && personName.Length > 100)
                                {
                                    errors.Add(new { Row = row, Error = "نام فرد بیش از 100 کاراکتر است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(position) && position.Length > 50)
                                {
                                    errors.Add(new { Row = row, Error = "سمت فرد بیش از 50 کاراکتر است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length > 20)
                                {
                                    errors.Add(new { Row = row, Error = "شماره ثابت بیش از 20 کاراکتر است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(mobileNumber))
                                {
                                    if (mobileNumber.Length > 20)
                                    {
                                        errors.Add(new { Row = row, Error = "شماره موبایل بیش از 20 کاراکتر است." });
                                        continue;
                                    }
                                    if (!Regex.IsMatch(mobileNumber, @"^09\d{9}$"))
                                    {
                                        errors.Add(new { Row = row, Error = "فرمت شماره موبایل نامعتبر است (باید با 09 شروع شود و 11 رقم باشد)." });
                                        continue;
                                    }
                                }

                                if (!string.IsNullOrEmpty(email))
                                {
                                    if (email.Length > 100)
                                    {
                                        errors.Add(new { Row = row, Error = "ایمیل بیش از 100 کاراکتر است." });
                                        continue;
                                    }
                                    if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                                    {
                                        errors.Add(new { Row = row, Error = "فرمت ایمیل نامعتبر است." });
                                        continue;
                                    }
                                }

                                if (!string.IsNullOrEmpty(website) && website.Length > 200)
                                {
                                    errors.Add(new { Row = row, Error = "وب‌سایت بیش از 200 کاراکتر است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(address) && address.Length > 500)
                                {
                                    errors.Add(new { Row = row, Error = "آدرس بیش از 500 کاراکتر است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(fieldOfActivity) && fieldOfActivity.Length > 200)
                                {
                                    errors.Add(new { Row = row, Error = "حوزه فعالیت بیش از 200 کاراکتر است." });
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(description) && description.Length > 1000)
                                {
                                    errors.Add(new { Row = row, Error = "توضیحات بیش از 1000 کاراکتر است." });
                                    continue;
                                }

                                // Insert record
                                Company_tbl company = new Company_tbl();
                                company.id_Staff = user.id;
                                company.id_Manger = null;
                                company.Date_Create = currentDate;
                                company.Date_last_Edit = currentDate;
                                company.Company_Name = companyName;
                                company.Person_Name = string.IsNullOrEmpty(personName) ? null : personName;
                                company.Position = string.IsNullOrEmpty(position) ? null : position;
                                company.Phone_Number = string.IsNullOrEmpty(phoneNumber) ? null : phoneNumber;
                                company.Mobile_Number = string.IsNullOrEmpty(mobileNumber) ? null : mobileNumber;
                                company.Email = string.IsNullOrEmpty(email) ? null : email;
                                company.Website = string.IsNullOrEmpty(website) ? null : website;
                                company.Address = string.IsNullOrEmpty(address) ? null : address;
                                company.Field_of_Activity = string.IsNullOrEmpty(fieldOfActivity) ? null : fieldOfActivity;
                                company.Description = string.IsNullOrEmpty(description) ? null : description;

                                db.Company_tbls.InsertOnSubmit(company);
                                db.SubmitChanges();

                                importedCount++;

                                // Optional: Log activity
                                db.P_Insert_activity_tbl(user.id, DateTime.Now.Date, DateTime.Now.TimeOfDay,
                                    user.Name + " شرکت " + rowCount.ToString() + " را از طریق فایل اکسل وارد کرد");
                            }
                            catch (SqlException sqlEx)
                            {
                                if (sqlEx.Number == 2601 || sqlEx.Number == 2627) // Unique constraint violation
                                {
                                    errors.Add(new { Row = row, Error = "نام شرکت قبلاً ثبت شده است." });
                                }
                                else
                                {
                                    errors.Add(new { Row = row, Error = "خطا در پایگاه داده: " + sqlEx.Message });
                                }
                            }
                            catch (Exception ex)
                            {
                                errors.Add(new { Row = row, Error = "خطا: " + ex.Message });
                            }
                        }

                        // Display results
                        lblMessage.ForeColor = errors.Any() ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                        lblMessage.Text = string.Format("وارد شدن {0} شرکت با موفقیت.", importedCount);
                        if (errors.Any())
                        {
                            lvErrors.DataSource = errors;
                            lvErrors.DataBind();
                            lvErrors.Visible = true;
                        }
                        else
                        {
                            lvErrors.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در پردازش فایل: " + ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_customer");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // مسیر فایل اکسل در سرور
            string filePath = Server.MapPath("~/files/Sample.xlsx");

            // بررسی وجود فایل
            if (File.Exists(filePath))
            {
                // تنظیم هدرهای پاسخ برای دانلود فایل
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=Sample.xlsx");

                // ارسال فایل به کاربر
                Response.TransmitFile(filePath);
                Response.Flush();
                Response.End();
            }
            else
            {
                // نمایش پیام خطا در صورت نبود فایل
                Response.Write("<script>alert('فایل یافت نشد!');</script>");
            }
        }
    }
}
