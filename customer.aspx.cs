using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }



        private void BindListView()
        {
            if (Session["mobile"] == null || string.IsNullOrEmpty(Session["mobile"].ToString()))
            {
                main_title.InnerText = "خطا: کاربر وارد نشده است";
                return;
            }

            using (var Db = new DataClasses1DataContext())
            {
                var user = Db.User_tbls.SingleOrDefault(a => a.Phone == Session["mobile"].ToString());
                if (user == null)
                {
                    main_title.InnerText = "خطا: کاربر یافت نشد";
                    return;
                }

                int idstaff = user.id;
                var query = from c in Db.Company_tbls
                            join u in Db.User_tbls on c.id_Staff equals u.id into staff
                            from u in staff.DefaultIfEmpty()
                            select new
                            {
                                c.id,
                                c.id_Staff,
                                c.Date_Create,
                                c.Company_Name,
                                c.Person_Name,
                                c.Phone_Number,
                                c.Mobile_Number,
                                c.Email,
                                StaffName = u != null ? (u.Name ?? "") + " " + (u.Lastname ?? "") : ""
                            };

                // Handle id_staff and date_day query strings
                bool hasStaffDateFilter = false;
                int filterIdStaff = 0;
                string filterDateDay = null;
                if (Request.QueryString["id_staff"] != null && Request.QueryString["date_day"] != null)
                {
                    string idStaffStr = Request.QueryString["id_staff"].ToString();
                    filterDateDay = Server.UrlDecode(Request.QueryString["date_day"].ToString());
                    if (int.TryParse(idStaffStr, out filterIdStaff) &&
                        System.Text.RegularExpressions.Regex.IsMatch(filterDateDay, @"^\d{4}/\d{2}/\d{2}$"))
                    {
                        query = query.Where(c => c.id_Staff == filterIdStaff && c.Date_Create == filterDateDay);
                        hasStaffDateFilter = true;

                        // Update title with staff name and date
                        var staff = Db.User_tbls.SingleOrDefault(u => u.id == filterIdStaff);
                        string staffName = staff != null ? (staff.Name ?? "") + " " + (staff.Lastname ?? "") : "کارمند ناشناس";
                        main_title.InnerText = string.Format("شرکت‌های ثبت‌شده توسط {0} در تاریخ {1}", staffName, filterDateDay);
                    }
                    else
                    {
                        main_title.InnerText = "خطا: شناسه کارمند یا تاریخ نامعتبر است";
                        return;
                    }
                }

                // Apply search filter if present and no staff/date filter
                if (!hasStaffDateFilter && Request.QueryString["search"] != null)
                {
                    string search = Request.QueryString["search"].ToString();
                    main_title.InnerText = "نتایج جستجو: " + HttpUtility.HtmlEncode(search);
                    query = query.Where(c => c.Company_Name.Contains(search) || c.Person_Name.Contains(search) ||
                                            c.Phone_Number.Contains(search) || c.Mobile_Number.Contains(search));
                }
                else if (!hasStaffDateFilter)
                {
                    main_title.InnerText = "لیست همه شرکت‌ها";
                }

                var Company__ = query.OrderByDescending(c => c.id).ToList();

                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(int), ColumnName = "id", AllowDBNull = false });
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Company_Name", MaxLength = 100, AllowDBNull = true });
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Person_Name", MaxLength = 100, AllowDBNull = true });
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Phone_Number", MaxLength = 20, AllowDBNull = true });
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Mobile_Number", MaxLength = 20, AllowDBNull = true });
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "StaffName", MaxLength = 200, AllowDBNull = true });
                MyDataTable.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "Email", MaxLength = 100, AllowDBNull = true });

                foreach (var element in Company__)
                {
                    var row = MyDataTable.NewRow();
                    row["id"] = element.id;
                    row["Company_Name"] = element.Company_Name;
                    row["Person_Name"] = element.Person_Name;
                    row["Phone_Number"] = element.Phone_Number;
                    row["Mobile_Number"] = element.Mobile_Number;
                    row["StaffName"] = element.StaffName;
                    row["Email"] = element.Email;
                    MyDataTable.Rows.Add(row);
                }

                ListView_customer.DataSource = MyDataTable;
                ListView_customer.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("customer" + "?search=" + txtsearch.Text);
        }

        protected void ListView_customer_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "list")
            {
                ListViewItem row = ListView_customer.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                Response.Redirect("Project_company?ID=" + id2.Text.ToString());

            }

            if (e.CommandName == "info")
            {
                ListViewItem row = ListView_customer.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                Response.Redirect("Edit_Info_Company?ID=" + id2.Text.ToString());

            }
            if (e.CommandName == "email")
            {
                ListViewItem row = ListView_customer.Items[e.Item.DataItemIndex];
                Label emailLabel = (Label)row.FindControl("EmailLabel");
                string emailAddress = emailLabel.Text;

                if (!string.IsNullOrEmpty(emailAddress))
                {
                    Response.Redirect("mailto:" + emailAddress);
                }


            }

            if (e.CommandName == "reminder")
            {
                ListViewItem row = ListView_customer.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                Response.Redirect("Create_Reminder?ID=" + id2.Text.ToString());

            }

            if (e.CommandName == "SMS")
            {
                ListViewItem row = ListView_customer.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                TextBox Company_Name = (TextBox)row.FindControl("Company_NameLabel");
                TextBox Person_Name = (TextBox)row.FindControl("Person_NameLabel");
                TextBox Phone_Number = (TextBox)row.FindControl("Phone_NumberLabel");
                TextBox Mobile_Number = (TextBox)row.FindControl("Mobile_NumberLable");
                TextBox Email = (TextBox)row.FindControl("EmailLabel");


                string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + Mobile_Number.Text + "&text=" + "Nobin Gostar Paya\n" + Company_Name.Text + " گرامی " + Person_Name.Text + "\n" + "لطفا به پنل کاربری خودتان مراجعه نمایید." + "\n https://nobincommerce.com/account/login_pages" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                var st = resp.GetResponseStream();
                var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                string _responseStr = sr.ReadToEnd();
                sr.Close();
                resp.Close();
            }

        }

        protected void seo_Click(object sender, EventArgs e)
        {
            Response.Redirect("user.aspx" + "?role=" + "کارشناس تولید محتوا");
        }

        protected void ListView_customer_PagePropertiesChanging1(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView_customer.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }
    }
}