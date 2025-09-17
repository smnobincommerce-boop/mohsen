using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class Follow_up_Project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["mobile"] == null || string.IsNullOrEmpty(Session["mobile"].ToString()))
                {
                    Response.Redirect("~/exit_panel");
                    return;
                }

                if (string.IsNullOrEmpty(Request.QueryString["IDPROJECT"]))
                {
                    Response.Redirect("~/panel/maneger/Project_company");
                    return;
                }

                int projectId;
                if (!int.TryParse(Request.QueryString["IDPROJECT"], out projectId))
                {
                    Response.Redirect("~/panel/maneger/Project_company");
                    return;
                }

                using (var db = new DataClasses1DataContext())
                {
                    // Retrieve project details
                    var project = (from p in db.Project_Commerce_tbls
                                   join c in db.Company_tbls on p.id_Company equals c.id into companies
                                   from c in companies.DefaultIfEmpty()
                                   where p.id == projectId
                                   select new
                                   {
                                       p.id,
                                       p.Project_Name,
                                       p.Date_Create,
                                       p.Date_last_Edit,
                                       p.Project_Description,
                                       CompanyName = c != null ? c.Company_Name : "بدون شرکت"
                                   }).SingleOrDefault();

                    if (project == null)
                    {
                        Response.Redirect("~/panel/maneger/Project_company");
                        return;
                    }

                    // Populate project details
                    txt_project_name.InnerHtml = "<b>نام پروژه: </b>" + project.Project_Name;
                    txt_company_name.InnerHtml = "<b>شرکت: </b>" + project.CompanyName;
                    txt_date_create.InnerHtml = "<b>تاریخ ایجاد: </b>" + (project.Date_Create != null ? PersianDate.GetPersianDate((DateTime)project.Date_Create) : "نامشخص");
                    txt_date_last_edit.InnerHtml = "<b>آخرین ویرایش: </b>" + (project.Date_last_Edit != null ? PersianDate.GetPersianDate((DateTime)project.Date_last_Edit) : "نامشخص");
                    if (!string.IsNullOrEmpty(project.Project_Description))
                    {
                        txt_project_description.InnerText = project.Project_Description;
                        txt_project_description.Visible = true;
                    }

                    // Retrieve logs
                    var logs = from l in db.Project_Commerce_Log_tbls
                               join u in db.User_tbls on l.id_Staff equals u.id
                               where l.Project_Commerce_id == projectId
                               orderby l.id
                               select new
                               {
                                   u.Name,
                                   u.Pic,
                                   u.Role,
                                   l.lastdescription,
                                   l.datecreate
                               };

                    // Create DataTable for ListView
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Name" });
                    dt.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Pic" });
                    dt.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Role" });
                    dt.Columns.Add(new DataColumn { DataType = typeof(bool), ColumnName = "Role_visible" });
                    dt.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "lastdescription" });
                    dt.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "datecreate" });

                    int logCount = 0;
                    foreach (var log in logs)
                    {
                        logCount++;
                        var row = dt.NewRow();
                        row["Name"] = log.Name;
                        row["Pic"] = log.Pic;
                        row["Role"] = log.Role;
                        row["Role_visible"] = log.Role == "کارشناس";
                        row["lastdescription"] = log.lastdescription;
                        row["datecreate"] = log.datecreate;
                        dt.Rows.Add(row);
                    }

                    ListView_project_logs.DataSource = dt;
                    ListView_project_logs.DataBind();

                    txt_log_count.InnerHtml = "<b>تعداد پیگیری‌ها: </b>"+logCount.ToString();
                }
            }
        }

        protected void btnSubmitLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid) return;

                using (var db = new DataClasses1DataContext())
                {
                    // Validate user
                    var user = db.User_tbls.SingleOrDefault(u => u.Phone == Session["mobile"].ToString());
                    if (user == null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('خطا: کاربر یافت نشد.');", true);
                        return;
                    }

                    // Validate project
                    int projectId = int.Parse(Request.QueryString["IDPROJECT"]);
                    var project = db.Project_Commerce_tbls.SingleOrDefault(p => p.id == projectId);
                    if (project == null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('خطا: پروژه یافت نشد.');", true);
                        return;
                    }

                    // Insert log
                    db.usp_Insert_Project_Commerce_Log(
                        user.id,
                        project.id_Company,
                        projectId,
                        PersianDate.GetPersianDate(DateTime.Now),
                        txt_log_description.Value
                    );
                    db.SubmitChanges();
                    db.P_Insert_activity_tbl(user.id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Name + " یک پیگیری برای شرکت" + project.id_Company.ToString() + "ثبت کرد.");
                    db.SubmitChanges();
                    // Clear form
                    txt_log_description.Value = "";

                    // Redirect to refresh
                    Response.Redirect("Follow-up-Project?IDPROJECT=" + projectId.ToString());
                }
            }
            catch 
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('خطا در ثبت پیگیری ');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_customer");
        }

        
    }
}