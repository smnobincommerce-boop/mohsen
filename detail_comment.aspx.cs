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
    public partial class detail_comment : System.Web.UI.Page
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
           
            int id_comment_query = Convert.ToInt32(Request.QueryString["comment"]);
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var commentt = Db.Message_user_in_paper_tbls.Where(c => c.id == id_comment_query);
            var user_ = Db.User_tbls.Where(c => c.id == commentt.Single().id_user);
            if (commentt.Single().id_staff != null)
            {
                var staff = Db.User_tbls.Where(c => c.id == commentt.Single().id_staff);
                txt_date_.InnerHtml = " <b> " + "تاریخ ثبت کامنت: " + " </b> " + commentt.Single().date;
                txt_date_want_contact.InnerHtml = " <b> " + "نام کاربر : " + " </b> " + user_.Single().Name;
                txt_subject_.InnerHtml = " <b> " + "شخص: " + " </b> " + staff.Single().Name;
                txt_description.InnerText = commentt.Single().message;
                string status = "";
                if (commentt.Single().comfirm == false)
                {
                    status = "منتشر نشده";
                }
                else if (commentt.Single().comfirm == true)
                {
                    status = "منتشر شده";
                }
                else
                {
                    status = "شرایط انتشار ندارد";
                }
                txt_phone_want_contact.InnerHtml = " <b> " + "وضعیت: " + " </b> " + status;
                txt_name_user.InnerHtml = " <b> " + "نام کاربر: " + " </b> " + user_.Single().Name;


                var message_comment = from a in Db.User_tbls
                                      join b in Db.Message_user_in_paper_tbls on a.id equals b.id_user
                                      where (b.id_staff == commentt.Single().id_staff && (b.id == id_comment_query || b.id_reply == id_comment_query))
                                      orderby (b.id)

                                      select new
                                      {
                                          a.Pic,
                                          a.Name,
                                          a.Role,
                                          b.id,
                                          b.message,
                                          b.date,
                                          b.time,
                                          b.comfirm,
                                          b.id_reply
                                      };


                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Pic" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Role" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "Role_visible" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "datechoosecontact" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "message" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "time_create" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date_create" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "address_file" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "address_file_visible" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "show_item" });
                int conter = 0;
                foreach (var element in message_comment)
                {

                    conter++;
                    var row = MyDataTable.NewRow();
                    row["id"] = element.id.ToString();
                    row["Name"] = element.Name.ToString();
                    row["Pic"] = element.Pic;
                    if (element.id_reply == null)
                    {
                        row["show_item"] = false;
                    }
                    else
                    {
                        row["show_item"] = true;
                    }
                    if (element.Role == "مدیر" || element.Role == "کارشناس تولید محتوا")
                    {
                        row["Role_visible"] = true;
                    }
                    else
                    {
                        row["Role_visible"] = false;
                    }
                    row["Role"] = element.Role;
                    //row["des_service"] = element.description;
                    row["subject"] = "";
                    row["datechoosecontact"] = element.date;
                    row["message"] = element.message;
                    row["time_create"] = element.time;
                    row["date_create"] = element.date;
                    row["address_file"] = "";
                    row["address_file_visible"] = false;


                    MyDataTable.Rows.Add(row);
                }

                ListView_message_comment.DataSource = MyDataTable;
                ListView_message_comment.DataBind();

            }
            else
            {
                var paper_ = Db.Paper_tbls.Where(c => c.id == commentt.Single().id_paper);
                txt_date_.InnerHtml = " <b> " + "تاریخ ثبت کامنت: " + " </b> " + commentt.Single().date;
                txt_date_want_contact.InnerHtml = " <b> " + "نام کاربر : " + " </b> " + user_.Single().Name;
                txt_subject_.InnerHtml = " <b> " + "موضوع مقاله: " + " </b> " + paper_.Single().subject_paper;
                txt_description.InnerText = commentt.Single().message;
                string status = "";
                if (commentt.Single().comfirm == false)
                {
                    status = "منتشر نشده";
                }
                else if (commentt.Single().comfirm == true)
                {
                    status = "منتشر شده";
                }
                else
                {
                    status = "شرایط انتشار ندارد";
                }
                txt_phone_want_contact.InnerHtml = " <b> " + "وضعیت: " + " </b> " + status;
                txt_name_user.InnerHtml = " <b> " + "نام کاربر: " + " </b> " + user_.Single().Name;


                var message_comment = from a in Db.User_tbls
                                      join b in Db.Message_user_in_paper_tbls on a.id equals b.id_user
                                      where (b.id_paper == commentt.Single().id_paper && (b.id == id_comment_query || b.id_reply == id_comment_query))
                                      orderby (b.id)

                                      select new
                                      {
                                          a.Pic,
                                          a.Name,
                                          a.Role,
                                          b.id,
                                          b.message,
                                          b.date,
                                          b.time,
                                          b.comfirm,
                                          b.id_reply
                                      };


                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Pic" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Role" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "Role_visible" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "datechoosecontact" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "message" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "time_create" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date_create" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "address_file" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "address_file_visible" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Boolean"), ColumnName = "show_item" });
                int conter = 0;
                foreach (var element in message_comment)
                {

                    conter++;
                    var row = MyDataTable.NewRow();
                    row["id"] = element.id.ToString();
                    row["Name"] = element.Name.ToString();
                    row["Pic"] = element.Pic;
                    if (element.id_reply == null)
                    {
                        row["show_item"] = false;
                    }
                    else
                    {
                        row["show_item"] = true;
                    }
                    if (element.Role == "مدیر" || element.Role == "کارشناس تولید محتوا")
                    {
                        row["Role_visible"] = true;
                    }
                    else
                    {
                        row["Role_visible"] = false;
                    }
                    row["Role"] = element.Role;
                    //row["des_service"] = element.description;
                    row["subject"] = "";
                    row["datechoosecontact"] = element.date;
                    row["message"] = element.message;
                    row["time_create"] = element.time;
                    row["date_create"] = element.date;
                    row["address_file"] = "";
                    row["address_file_visible"] = false;


                    MyDataTable.Rows.Add(row);
                }

                ListView_message_comment.DataSource = MyDataTable;
                ListView_message_comment.DataBind();


            }


        }
        protected void Button_send_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
            int id_comment_query = Convert.ToInt32(Request.QueryString["comment"]);
            var commentt = Db.Message_user_in_paper_tbls.Where(c => c.id == id_comment_query);
            if (commentt.Count() == 1)
            {

                int id_staff_comment = Convert.ToInt32(commentt.Single().id_staff);
                int id_paper_comment = Convert.ToInt32(commentt.Single().id_paper);
                int user_id = Convert.ToInt32(user.Single().id);
                if (commentt.Single().id_staff != null)
                {
                    Db.P_Insert_Message_user_in_paper_tbl(null, user_id, id_comment_query, txt_message_comment.Value, Dateshamsi1400(), DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), true, id_staff_comment);
                }
                else
                {
                    Db.P_Insert_Message_user_in_paper_tbl(id_paper_comment, user_id, id_comment_query, txt_message_comment.Value, Dateshamsi1400(), DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), true, null);
                }
                
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پاسخ برای کامنت " + id_comment_query.ToString() + " ثبت کرد.");
                txt_message_comment.InnerText = "";
                var user_out = Db.Message_user_in_paper_tbls.Where(c => c.id == id_comment_query);
                if (user_out.Count() == 1)
                {
                    var user_out2 = Db.User_tbls.Where(c => c.id == user_out.Single().id_user);
                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out2.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "کاربر گرامی به کامنت شما پاسخ داده شد." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    System.Net.WebResponse resp = req.GetResponse();
                    var st = resp.GetResponseStream();
                    var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                    string _responseStr = sr.ReadToEnd();
                    sr.Close();
                    resp.Close();
                }
            }

            Response.Redirect("detail_comment.aspx?comment=" + id_comment_query.ToString());



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            int id_comment_query = Convert.ToInt32(Request.QueryString["comment"]);
            var commentt = Db.Message_user_in_paper_tbls.Where(c => c.id == id_comment_query);
            if (commentt.Single().id_staff != null)
            {
                Db.P_Update_Message_user_in_paper_tbl_comfirm(id_comment_query, null, null);
            }
            else
            {
                Db.P_Update_Message_user_in_paper_tbl_comfirm(id_comment_query, commentt.Single().id_paper, null);
            }
           
            Response.Redirect("detail_comment.aspx?comment=" + Convert.ToInt32(Request.QueryString["comment"]).ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            int id_comment_query = Convert.ToInt32(Request.QueryString["comment"]);
            var commentt = Db.Message_user_in_paper_tbls.Where(c => c.id == id_comment_query);
            if (commentt.Single().id_staff != null)
            {
                Db.P_Update_Message_user_in_paper_tbl_comfirm(id_comment_query, null, true);
            }
            else
            {
                Db.P_Update_Message_user_in_paper_tbl_comfirm(id_comment_query, commentt.Single().id_paper, true);
            }
            
            Response.Redirect("detail_comment.aspx?comment=" + Convert.ToInt32(Request.QueryString["comment"]).ToString());
        }

        protected void ListView_message_comment_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                ListViewItem row = ListView_message_comment.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                string _id = id2.Text;
                int id_comment = Convert.ToInt32(_id);
                int id_comment_query = Convert.ToInt32(Request.QueryString["comment"]);
                Db.P_del_Message_user_in_paper_tbl(id_comment);
                var commentt = Db.Message_user_in_paper_tbls.Where(c => c.id == id_comment_query);
                var paper_ = Db.Paper_tbls.Where(c => c.id == commentt.Single().id_paper);
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " یک کامنت از مقاله  " + paper_.Single().subject_paper + " توسط " + user.Single().Name + " حذف گردید.");
                Response.Redirect("detail_comment.aspx?comment=" + Request.QueryString["comment"]);
            }
        }
    }
}