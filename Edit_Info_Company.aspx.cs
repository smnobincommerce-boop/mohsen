using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Edit_Info_Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Initialize button visibility
                btn_create.Style["display"] = "block";
                btn_edit.Style["display"] = "none";

                // Check if user is logged in
                if (Session["mobile"] == null || string.IsNullOrEmpty(Session["mobile"].ToString()))
                {
                    lblMessage.Text = "خطا: لطفاً ابتدا وارد سیستم شوید.";
                    btnCreateCompany.Enabled = false;
                    btn_create.Style["display"] = "block";
                    btn_edit.Style["display"] = "none";
                    main_title.InnerText = "ایجاد شرکت جدید";
                    return;
                }

                // Check for ID in QueryString
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int companyId;
                    if (!int.TryParse(Request.QueryString["ID"], out companyId))
                    {
                        lblMessage.Text = "خطا: شناسه شرکت نامعتبر است.";
                        btn_create.Style["display"] = "block";
                        btn_edit.Style["display"] = "none";
                        btnUpdateCompany.Enabled = false;
                        main_title.InnerText = "ایجاد شرکت جدید";
                        return;
                    }

                    // Edit mode: Hide create button, show edit buttons
                    btn_create.Style["display"] = "none";
                    btn_edit.Style["display"] = "block";
                    btnUpdateCompany.Enabled = true;
                    main_title.InnerText = "ویرایش شرکت";
                    LoadCompanyData(companyId);
                }
                else
                {
                    // Create mode: Show create button, hide edit buttons
                    btn_create.Style["display"] = "block";
                    btn_edit.Style["display"] = "none";
                    btnCreateCompany.Enabled = true;
                    main_title.InnerText = "ایجاد شرکت جدید";
                }
            }
        }

        private void LoadCompanyData(int companyId)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var user = db.User_tbls.SingleOrDefault(a => a.Phone == Session["mobile"].ToString());
                    if (user == null)
                    {
                        lblMessage.Text = "خطا: کاربر یافت نشد.";
                        btnUpdateCompany.Enabled = false;
                        btn_edit.Style["display"] = "block";
                        return;
                    }

                    var company = db.Company_tbls.SingleOrDefault(c => c.id == companyId);
                    if (company == null)
                    {
                        lblMessage.Text = "خطا: شرکت یافت نشد.";
                        btnUpdateCompany.Enabled = false;
                        btn_edit.Style["display"] = "block";
                        return;
                    }

                    // Check user permission
                  

                    string userRole = Session["role"] != null ? Session["role"].ToString() : "";
                    string[] allowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };
                    if (!allowedRoles.Contains(userRole))
                    {
                        // Non-manager: Must be staff or manager of the company
                        if (company.id_Staff != user.id )
                        {
                            lblMessage.Text = "خطا: شما مجاز به ویرایش این شرکت نیستید.";
                            btnUpdateCompany.Enabled = false;
                            btn_edit.Style["display"] = "block";
                            return;
                        }
                    }

                    // Populate fields
                    txtCompanyName.Text = company.Company_Name;
                    txtPersonName.Text = company.Person_Name;
                    txtPosition.Text = company.Position;
                    txtPhoneNumber.Text = company.Phone_Number;
                    txtMobileNumber.Text = company.Mobile_Number;
                    txtEmail.Text = company.Email;
                    txtWebsite.Text = company.Website;
                    txtAddress.Text = company.Address;
                    txtFieldOfActivity.Text = company.Field_of_Activity;
                    txtDescription.Text = company.Description;
                    txtManagerId.Text = company.id_Manger.HasValue ? company.id_Manger.ToString() : "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا در بارگذاری اطلاعات: " + ex.Message;
                btnUpdateCompany.Enabled = false;
                btn_edit.Style["display"] = "block";
            }
        }

        protected void btnCreateCompany_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid) return;

                using (var db = new DataClasses1DataContext())
                {
                    // Retrieve id_Staff
                    var user = db.User_tbls.SingleOrDefault(a => a.Phone == Session["mobile"].ToString());
                    if (user == null)
                    {
                        lblMessage.Text = "خطا: کاربر یافت نشد.";
                        return;
                    }

                    // Validate id_Manger
                    int? managerId = null;
                    if (!string.IsNullOrEmpty(txtManagerId.Text.Trim()))
                    {
                        int parsedManagerId;
                        if (!int.TryParse(txtManagerId.Text.Trim(), out parsedManagerId))
                        {
                            lblMessage.Text = "خطا: شناسه مدیر باید یک عدد باشد.";
                            return;
                        }
                        managerId = parsedManagerId;

                        if (!db.User_tbls.Any(u => u.id == managerId))
                        {
                            lblMessage.Text = "خطا: مدیر با این شناسه وجود ندارد.";
                            return;
                        }
                    }

                    // Validate Company_Name
                    if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
                    {
                        lblMessage.Text = "خطا: نام شرکت الزامی است.";
                        return;
                    }

                    // Generate Persian date
                    string persianDate = PersianDate.GetPersianDate(DateTime.Now).ToString();

                    // Create new record
                    var newCompany = new Company_tbl
                    {
                        id_Staff = user.id,
                        id_Manger = managerId,
                        Date_Create = persianDate,
                        Date_last_Edit = persianDate,
                        Company_Name = txtCompanyName.Text.Trim(),
                        Person_Name = string.IsNullOrEmpty(txtPersonName.Text.Trim()) ? null : txtPersonName.Text.Trim(),
                        Position = string.IsNullOrEmpty(txtPosition.Text.Trim()) ? null : txtPosition.Text.Trim(),
                        Phone_Number = string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) ? null : txtPhoneNumber.Text.Trim(),
                        Mobile_Number = string.IsNullOrEmpty(txtMobileNumber.Text.Trim()) ? null : txtMobileNumber.Text.Trim(),
                        Email = string.IsNullOrEmpty(txtEmail.Text.Trim()) ? null : txtEmail.Text.Trim(),
                        Website = string.IsNullOrEmpty(txtWebsite.Text.Trim()) ? null : txtWebsite.Text.Trim(),
                        Address = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? null : txtAddress.Text.Trim(),
                        Field_of_Activity = string.IsNullOrEmpty(txtFieldOfActivity.Text.Trim()) ? null : txtFieldOfActivity.Text.Trim(),
                        Description = string.IsNullOrEmpty(txtDescription.Text.Trim()) ? null : txtDescription.Text.Trim()
                    };

                    db.Company_tbls.InsertOnSubmit(newCompany);
                    db.SubmitChanges();
                    db.P_Insert_activity_tbl(user.id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Name + " " + "شرکت با موفقیت ایجاد شد (شناسه: " + newCompany.id + ").");
                    db.SubmitChanges();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "شرکت با موفقیت ایجاد شد (شناسه: " + newCompany.id + ").";

                    // Redirect to edit mode
                    Response.Redirect("Edit_Info_Company.aspx?ID=" + newCompany.id);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key violation
                {
                    lblMessage.Text = "خطا: شناسه مدیر نامعتبر است.";
                }
                else
                {
                    lblMessage.Text = "خطا در ایجاد شرکت: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا: " + ex.Message;
            }
        }

        protected void btnUpdateCompany_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid) return;

                using (var db = new DataClasses1DataContext())
                {
                    // Retrieve id_Company
                    int companyId;
                    if (!int.TryParse(Request.QueryString["ID"], out companyId))
                    {
                        lblMessage.Text = "خطا: شناسه شرکت نامعتبر است.";
                        return;
                    }

                    // Retrieve user
                    var user = db.User_tbls.SingleOrDefault(a => a.Phone == Session["mobile"].ToString());
                    if (user == null)
                    {
                        lblMessage.Text = "خطا: کاربر یافت نشد.";
                        return;
                    }

                    // Retrieve company
                    var company = db.Company_tbls.SingleOrDefault(c => c.id == companyId);
                    if (company == null)
                    {
                        lblMessage.Text = "خطا: شرکت یافت نشد.";
                        return;
                    }

                    // Check permission
                    string userRole = Session["role"] != null ? Session["role"].ToString() : "";
                    string[] allowedRoles = { "مدیر", "مدیر فنی", "مدیر کل" };
                    if (!allowedRoles.Contains(userRole))
                    {
                        // Non-manager: Must be staff or manager of the company
                        if (company.id_Staff != user.id)
                        {
                            lblMessage.Text = "خطا: شما مجاز به ویرایش این شرکت نیستید.";
                            btnUpdateCompany.Enabled = false;
                            btn_edit.Style["display"] = "block";
                            return;
                        }
                    }

                    // Validate id_Manger
                    int? managerId = null;
                    if (!string.IsNullOrEmpty(txtManagerId.Text.Trim()))
                    {
                        int parsedManagerId;
                        if (!int.TryParse(txtManagerId.Text.Trim(), out parsedManagerId))
                        {
                            lblMessage.Text = "خطا: شناسه مدیر باید یک عدد باشد.";
                            return;
                        }
                        managerId = parsedManagerId;

                        if (!db.User_tbls.Any(u => u.id == managerId))
                        {
                            lblMessage.Text = "خطا: مدیر با این شناسه وجود ندارد.";
                            return;
                        }
                    }

                    // Validate Company_Name
                    if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
                    {
                        lblMessage.Text = "خطا: نام شرکت الزامی است.";
                        return;
                    }

                    // Update information
                    company.id_Manger = managerId;
                    company.Date_last_Edit = PersianDate.GetPersianDate(DateTime.Now).ToString();
                    company.Company_Name = txtCompanyName.Text.Trim();
                    company.Person_Name = string.IsNullOrEmpty(txtPersonName.Text.Trim()) ? null : txtPersonName.Text.Trim();
                    company.Position = string.IsNullOrEmpty(txtPosition.Text.Trim()) ? null : txtPosition.Text.Trim();
                    company.Phone_Number = string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) ? null : txtPhoneNumber.Text.Trim();
                    company.Mobile_Number = string.IsNullOrEmpty(txtMobileNumber.Text.Trim()) ? null : txtMobileNumber.Text.Trim();
                    company.Email = string.IsNullOrEmpty(txtEmail.Text.Trim()) ? null : txtEmail.Text.Trim();
                    company.Website = string.IsNullOrEmpty(txtWebsite.Text.Trim()) ? null : txtWebsite.Text.Trim();
                    company.Address = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? null : txtAddress.Text.Trim();
                    company.Field_of_Activity = string.IsNullOrEmpty(txtFieldOfActivity.Text.Trim()) ? null : txtFieldOfActivity.Text.Trim();
                    company.Description = string.IsNullOrEmpty(txtDescription.Text.Trim()) ? null : txtDescription.Text.Trim();

                    db.SubmitChanges();
                    db.P_Insert_activity_tbl(user.id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Name + " " + company.id.ToString() + " " + " شرکت با موفقیت به‌روزرسانی شد.");
                    db.SubmitChanges();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "شرکت با موفقیت به‌روزرسانی شد.";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key violation
                {
                    lblMessage.Text = "خطا: شناسه مدیر نامعتبر است.";
                }
                else
                {
                    lblMessage.Text = "خطا در به‌روزرسانی: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا: " + ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Project_company.aspx");
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("my_customer");
        }
    }
}