using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class detail_request : System.Web.UI.Page
    {
        private static string Dateshamsi1400()
        {
            try
            {
                string date = string.Empty;
                DateTime nowshamsi = DateTime.Parse("1/1/1400 00:00:00 AM");
                //DateTime now = DateTime.Parse("12/28/2022 00:00:00 AM");
                DateTime now = DateTime.Now;
                DateTime miladi = DateTime.Parse("3/21/2021 00:00:00 AM");
                TimeSpan delta = now - miladi;
                int yy = (int)(delta.TotalDays / 365);
                if (yy < 4)
                {
                    double yyyy = delta.TotalDays - (yy * 365);
                    int yy2 = yy + 1400;
                    if (yyyy <= 365)
                    {
                        if (yyyy <= 186)
                        {
                            double d2 = yyyy / 31;
                            double mm = (int)(d2) + 1;
                            double dd = yyyy - ((mm - 1) * 31);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (186 < yyyy || yyyy <= 336)
                        {
                            double d2 = (yyyy - 186) / 30;
                            double mm = (int)d2 + 7;
                            double dd = (yyyy - 186) - ((mm - 7) * 30);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (336 < yyyy || yyyy <= 365)
                        {
                            double dd = yyyy - 336;
                            double ddd = (int)(dd) + 1;
                            double mm = 12;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                    }

                }
                else
                {
                    double yyyy = delta.TotalDays - ((yy - 1) * 365) - 366;
                    int yy2 = yy + 1400;
                    if (yyyy <= 365)
                    {
                        if (yyyy <= 186)
                        {
                            double d2 = yyyy / 31;
                            double mm = (int)(d2) + 1;
                            double dd = yyyy - ((mm - 1) * 31);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (186 < yyyy || yyyy <= 336)
                        {
                            double d2 = (yyyy - 186) / 30;
                            double mm = (int)d2 + 7;
                            double dd = (yyyy - 186) - ((mm - 7) * 30);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (336 < yyyy || yyyy <= 365)
                        {
                            double dd = yyyy - 336;
                            double ddd = (int)(dd) + 1;
                            double mm = 12;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                    }

                }


                return date;
            }
            catch
            {
                return "0";
            }
        }
        private static string Dateshamsi(DateTime a)
        {
            try
            {
                string date = string.Empty;
                DateTime nowshamsi = DateTime.Parse("1/1/1400 00:00:00 AM");
                //DateTime now = DateTime.Parse("12/28/2022 00:00:00 AM");
                DateTime now = a;
                DateTime miladi = DateTime.Parse("3/21/2021 00:00:00 AM");



                int year_shmsi = 1400;
                if (a < miladi)
                {
                    year_shmsi = 1399;
                    miladi = DateTime.Parse("3/20/2020 00:00:00 AM");

                }

                TimeSpan delta = now - miladi;
                int yy = (int)(delta.TotalDays / 365);
                if (yy < 4)
                {
                    double yyyy = delta.TotalDays - (yy * 365);
                    int yy2 = yy + year_shmsi;
                    if (yyyy <= 365)
                    {
                        if (yyyy <= 186)
                        {
                            double d2 = yyyy / 31;
                            double mm = (int)(d2) + 1;
                            double dd = yyyy - ((mm - 1) * 31);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (186 < yyyy || yyyy <= 336)
                        {
                            double d2 = (yyyy - 186) / 30;
                            double mm = (int)d2 + 7;
                            double dd = (yyyy - 186) - ((mm - 7) * 30);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (336 < yyyy || yyyy <= 365)
                        {
                            double dd = yyyy - 336;
                            double ddd = (int)(dd) + 1;
                            double mm = 12;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                    }

                }
                else
                {
                    double yyyy = delta.TotalDays - ((yy - 1) * 365) - 366;
                    int yy2 = yy + 1395;
                    if (yyyy <= 365)
                    {
                        if (yyyy <= 186)
                        {
                            double d2 = yyyy / 31;
                            double mm = (int)(d2) + 1;
                            double dd = yyyy - ((mm - 1) * 31);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (186 < yyyy || yyyy <= 336)
                        {
                            double d2 = (yyyy - 186) / 30;
                            double mm = (int)d2 + 7;
                            double dd = (yyyy - 186) - ((mm - 7) * 30);
                            double ddd = (int)(dd) + 1;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                        else if (336 < yyyy || yyyy <= 365)
                        {
                            double dd = yyyy - 336;
                            double ddd = (int)(dd) + 1;
                            double mm = 12;
                            date = yy2.ToString() + "/" + mm.ToString() + "/" + ddd.ToString();
                            return date;
                        }
                    }

                }


                return date;
            }
            catch
            {
                return "0";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_rquest_query = Convert.ToInt32(Request.QueryString["request"]);
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var requestt = Db.Request_tbls.Where(c => c.id == id_rquest_query);
            var user_ = Db.User_tbls.Where(c => c.id == requestt.Single().id_user);
            txt_date_.InnerHtml = " <b> " + "تاریخ ثبت درخواست: " + " </b> " + requestt.Single().date_request.ToString();
            txt_date_want_contact.InnerHtml = " <b> " + "زمان تماس تلفنی: " + " </b> " + requestt.Single().datechoosecontact;
            txt_subject_.InnerHtml = " <b> " + "موضوع: " + " </b> " + requestt.Single().subject;
            txt_description.InnerText = requestt.Single().des_service;
            txt_phone_want_contact.InnerHtml = " <b> " + "تلفن: " + " </b> " + user_.Single().Phone;
            txt_name_user.InnerHtml= " <b> " + "نام کاربر: " + " </b> " + user_.Single().Name;
            var message_request = from a in Db.all_message_tbls
                                  join c in Db.User_tbls on a.id_user equals c.id
                                  join b in Db.Request_tbls on a.id_request equals b.id
                                  where (b.id == id_rquest_query)
                                  orderby (a.id)

                                  select new { c.Pic, c.Name, c.Role, b.des_service, b.subject, b.datechoosecontact, a.message, a.time_create, a.date_create, a.address_file };


            DataTable MyDataTable = new DataTable();

            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Pic" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Role" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "Role_visible" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "des_service" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "datechoosecontact" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "message" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "time_create" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date_create" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "address_file" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "address_file_visible" });

            int conter = 0;
            foreach (var element in message_request)
            {

                conter++;
                var row = MyDataTable.NewRow();

                row["Name"] = element.Name.ToString();
                row["Pic"] = element.Pic;
                if (element.Role == "مدیر" || element.Role == "کارشناس بخش خدمات تخصصی")
                {
                    row["Role_visible"] = true;
                }
                else
                {
                    row["Role_visible"] = false;
                }
                row["Role"] = element.Role;
                row["des_service"] = element.des_service;
                row["subject"] = element.subject;
                row["datechoosecontact"] = element.datechoosecontact;
                row["message"] = element.message;
                row["time_create"] = element.time_create;
                row["date_create"] = Dateshamsi(Convert.ToDateTime(element.date_create));
                row["address_file"] = element.address_file;
                if (element.address_file == null || element.address_file == "")
                {
                    row["address_file_visible"] = false;
                }
                else
                {
                    row["address_file_visible"] = true;
                }

                MyDataTable.Rows.Add(row);
            }

            ListView_message_request.DataSource = MyDataTable;
            ListView_message_request.DataBind();


            var seen = Db.seen_message_tbls.Where(c => c.id_request == id_rquest_query && c.seen == false && c.role_user_rciver == "مدیر");
            foreach (var element in seen)
            {
                Db.P_Update_seen_message_tbl(element.id, element.id_all_message, element.id_user_sender, element.id_user_reciver, element.date_send, element.time_send, DateTime.Now.Date, DateTime.Now.TimeOfDay, true, true, element.role_user_sender, element.role_user_rciver, element.id_request, element.id_ticket, element.id_project);
            }
        }
        protected void Button_send_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
            string folder = Dateshamsi1400().Replace("/", "");
            string directoryPath = Server.MapPath(string.Format("/files/request/{0}/", folder.Trim()));
            string address_file = string.Format("/files/request/{0}/", folder.Trim());
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //string type = "";
            //string service = "";
            //string day = "";

            if (file_upload_request.HasFile)
            {

                string fileName = Path.GetFileName(file_upload_request.PostedFile.FileName);
                file_upload_request.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                // Db.P_Insert_Request_tbl(type + service, user.Single().id, day, txt_request_message.Value, address_file + fileName, Dateshamsi1400(), user.Single().Name, user.Single().Phone);

                //var message = Db.Request_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);
                Db.P_Insert_all_message_tbl(null, null, null, Convert.ToInt32(Request.QueryString["request"]), user.Single().id, null, txt_message_ticket.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true);
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پاسخ برای درخواست ثبت کرد");
                txt_message_ticket.InnerText = "";
                var user_pro = Db.Request_tbls.Where(c => c.id == Convert.ToInt32(Request.QueryString["request"]));
                var user_out = Db.User_tbls.Where(c => c.id == user_pro.Single().id_user);
                if (user_out.Count() == 1)
                {
                    //string sms = "نوبین\n" + name.Text + " گرامی \n" + "به درخواست شما پاسخ داده شد. از طریق لینک زیر به پنل کاربری خود وارد شده و سپس به قسمت لیست درخواست ها در پنل کاربری خود مراجعه نمایید." + "\n https://nobincommerce.com/account/login";
                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "نوبین\n" + user_out.Single().Name + " گرامی \n" + "به درخواست شما پاسخ داده شد. از طریق لینک زیر به پنل کاربری خود وارد شده و سپس به قسمت لیست درخواست ها در پنل کاربری خود مراجعه نمایید." + "\n https://nobincommerce.com/account/login" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    System.Net.WebResponse resp = req.GetResponse();
                    var st = resp.GetResponseStream();
                    var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                    string _responseStr = sr.ReadToEnd();                   
                    sr.Close();
                    resp.Close();
                }

                Response.Redirect("detail_request.aspx?request=" + Convert.ToInt32(Request.QueryString["request"]).ToString());
            }
            else
            {
                //Db.P_Insert_Request_tbl(type + service, user.Single().id, day, txt_request_message.Value, null, Dateshamsi1400(), user.Single().Name, user.Single().Phone);
                //var message = Db.Request_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);
                Db.P_Insert_all_message_tbl(null, null, null, Convert.ToInt32(Request.QueryString["request"]), user.Single().id, null, txt_message_ticket.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پاسخ برای درخواست ثبت کرد");
                txt_message_ticket.InnerText = "";
                var user_pro = Db.Request_tbls.Where(c => c.id == Convert.ToInt32(Request.QueryString["request"]));
                var user_out = Db.User_tbls.Where(c => c.id == user_pro.Single().id_user);
                if (user_out.Count() == 1)
                {
                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "نوبین\n" + user_out.Single().Name + " گرامی \n" + "به درخواست شما پاسخ داده شد. از طریق لینک زیر به پنل کاربری خود وارد شده و سپس به قسمت لیست درخواست ها در پنل کاربری خود مراجعه نمایید." + "\n https://nobincommerce.com/account/login" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    System.Net.WebResponse resp = req.GetResponse();
                    var st = resp.GetResponseStream();
                    var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                    string _responseStr = sr.ReadToEnd();
                    sr.Close();
                    resp.Close();
                }

                Response.Redirect("detail_request.aspx?request=" + Convert.ToInt32(Request.QueryString["request"]).ToString());
            }
        }
    }
}