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
    public partial class create_project : System.Web.UI.Page
    {
        protected void Page_LoadCompelet(object sender, EventArgs e)
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
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
        protected void Button_project_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
            string folder = Dateshamsi1400().Replace("/", "");
            string directoryPath = Server.MapPath(string.Format("/files/project/{0}/", folder.Trim()));
            string address_file = string.Format("/files/project/{0}/", folder.Trim());
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string group_ = "";
            if (RadioButtonList2.SelectedValue == "1")
            {
                group_ = "معماری";
            }
            else if (RadioButtonList2.SelectedValue == "0")
            {
                group_ = "عمران";
            }
            else if (RadioButtonList2.SelectedValue == "2")
            {
                group_ = "مکانیک";
            }
            else if (RadioButtonList2.SelectedValue == "3")
            {
                group_ = "برق";
            }
            var engineer = Db.User_tbls.Where(c => c.Role == "متخصص");
            
            if (File_project.HasFile)
            {

                string fileName = Path.GetFileName(File_project.PostedFile.FileName);
                File_project.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                #region شرط اعمال مهندس
                if (CheckBox1.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id,Convert.ToInt32(Label1.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                    var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label1.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");

                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label1.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();                      
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox2.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label2.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label2.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label2.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox3.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label3.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label3.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label3.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox4.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label4.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label4.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label4.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox5.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label5.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label5.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label5.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox6.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label6.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label6.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label6.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox7.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label7.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label7.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label7.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox8.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label8.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label8.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label8.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox9.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label9.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label9.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label9.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox10.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label10.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label10.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label10.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox11.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label11.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label11.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label11.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox12.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label12.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label12.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label12.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox13.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label13.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label13.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label13.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox14.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label14.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label14.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label14.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox15.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label15.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label15.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label15.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox16.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label16.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label16.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label16.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox17.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label17.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label17.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label17.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox18.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label18.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label18.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label18.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox19.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label19.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label19.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label19.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox20.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label20.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label20.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label20.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox21.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label21.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label21.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label21.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox22.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label22.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label22.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label22.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox23.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label23.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label23.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label23.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox24.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label24.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label24.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label24.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox25.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label25.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label25.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label25.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox26.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label26.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label26.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label26.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox27.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label27.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label27.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label27.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox28.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label28.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label28.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label28.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox29.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label29.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label29.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label29.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox30.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label30.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label30.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label30.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox31.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label31.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label31.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label31.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox32.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label32.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label32.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label32.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox33.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label33.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label33.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label33.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox34.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label34.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label34.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label34.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox35.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label35.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label35.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label35.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox36.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label36.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label36.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label36.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox37.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label37.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label37.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label37.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox38.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label38.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label38.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label38.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox39.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label39.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label39.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label39.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox40.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label40.Text), txt_project_subject.Value, txt_project_message.Value, address_file + fileName, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label40.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true); Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label40.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                #endregion
                Response.Redirect("list_project.aspx");
            }
            else
            {
                
                #region شرط اعمال مهندس
                if (CheckBox1.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label1.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label1.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label1.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox2.Checked)
                {
                     Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label1.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label2.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label2.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox3.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label3.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label3.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label3.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox4.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label4.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label4.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label4.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox5.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label5.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label5.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label5.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox6.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label6.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label6.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label6.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox7.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label7.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label7.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label7.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox8.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label8.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label8.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label8.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox9.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label9.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label9.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label9.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox10.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label10.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label10.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label10.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox11.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label11.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label11.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label11.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox12.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label12.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label12.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label12.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox13.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label13.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label13.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label13.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox14.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label14.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label14.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label14.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox15.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label15.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label15.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label15.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox16.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label16.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label16.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label16.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox17.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label17.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label17.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label17.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox18.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label18.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label18.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label18.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox19.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label19.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label19.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label19.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox20.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label20.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label20.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label20.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox21.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label21.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label21.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label21.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox22.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label22.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label22.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label22.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox23.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label23.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label23.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label23.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox24.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label24.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label24.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label24.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox25.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label25.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label25.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label25.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox26.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label26.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label26.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label26.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox27.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label27.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label27.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label27.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox28.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label28.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label28.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label28.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox29.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label29.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label29.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label29.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox30.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label30.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label30.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label30.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox31.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label31.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label31.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label31.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox32.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label32.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label32.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label32.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox33.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label33.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label33.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label33.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox34.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label34.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label34.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label34.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox35.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label35.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label35.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label35.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox36.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label36.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label36.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label36.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox37.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label37.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label37.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label37.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox38.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label38.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label38.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label38.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox39.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label39.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label39.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label39.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                if (CheckBox40.Checked)
                {
                    Db.P_Insert_project_tbl(user.Single().id, Convert.ToInt32(Label40.Text), txt_project_subject.Value, txt_project_message.Value, null, DateTime.Now.Date, group_, true);
                   var message = Db.project_tbls.Where(c => c.id_user_creator == user.Single().id && c.id_user_engineer== Convert.ToInt32(Label40.Text)).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, null, message.Take(1).Single().id, null, user.Single().id, null, txt_project_message.Value, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک پروژه ایجاد کرد");
                    var user_out = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Label40.Text));
                    if (user_out.Count() == 1)
                    {
                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + user_out.Single().Phone + "&text=" + "Nobin Gostar Paya\n" + "متخصص گرامی یک پروژه برای شما تعریف شده است لطفا به پنل خود مراجعه نمایید." + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        var st = resp.GetResponseStream();
                        var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                        string _responseStr = sr.ReadToEnd();
                        sr.Close();
                        resp.Close();
                    }
                }
                #endregion
                Response.Redirect("list_project.aspx");
            }


        }
        protected void choose_engineer_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = true;

            DataClasses1DataContext Db = new DataClasses1DataContext();
            string engin = "";
            if (RadioButtonList2.SelectedValue == "0")
            {
                engin = "مهندس عمران";
            }
            else if (RadioButtonList2.SelectedValue == "1")
            {
                engin = "مهندس معماری";
            }
            else if (RadioButtonList2.SelectedValue == "2")
            {
                engin = "مهندس مکانیک";
            }
            else if (RadioButtonList2.SelectedValue == "3")
            {
                engin = "مهندس برق";
            }
            var engineer = Db.User_tbls.Where(c => c.Role == "متخصص" && c.project_recive_ability == true && c.professionalism == engin);
            int conter = 0;
            foreach (var element in engineer)
            {
                #region شرط انتخاب مهندس
                conter++;
                if (conter == 1)
                {
                    div1.Visible = true;
                    Strong1.InnerText = element.Name;
                    Label1.Text = element.id.ToString();

                }
                else if (conter == 2)
                {
                    div2.Visible = true;
                    Strong2.InnerText = element.Name;
                    Label2.Text = element.id.ToString();
                }
                else if (conter == 3)
                {
                    div3.Visible = true;
                    Strong3.InnerText = element.Name;
                    Label3.Text = element.id.ToString();
                }
                else if (conter == 4)
                {
                    div4.Visible = true;
                    Strong4.InnerText = element.Name;
                    Label4.Text = element.id.ToString();
                }
                else if (conter == 5)
                {
                    div5.Visible = true;
                    Strong5.InnerText = element.Name;
                    Label5.Text = element.id.ToString();
                }
                else if (conter == 6)
                {
                    div6.Visible = true;
                    Strong6.InnerText = element.Name;
                    Label6.Text = element.id.ToString();
                }
                else if (conter == 7)
                {
                    div7.Visible = true;
                    Strong7.InnerText = element.Name;
                    Label7.Text = element.id.ToString();
                }
                else if (conter == 8)
                {
                    div8.Visible = true;
                    Strong8.InnerText = element.Name;
                    Label8.Text = element.id.ToString();
                }
                else if (conter == 9)
                {
                    div9.Visible = true;
                    Strong9.InnerText = element.Name;
                    Label9.Text = element.id.ToString();
                }
                else if (conter == 10)
                {
                    div10.Visible = true;
                    Strong10.InnerText = element.Name;
                    Label10.Text = element.id.ToString();
                }
                else if (conter == 11)
                {
                    div11.Visible = true;
                    Strong11.InnerText = element.Name;
                    Label11.Text = element.id.ToString();
                }
                else if (conter == 12)
                {
                    div12.Visible = true;
                    Strong12.InnerText = element.Name;
                    Label12.Text = element.id.ToString();
                }
                else if (conter == 13)
                {
                    div13.Visible = true;
                    Strong13.InnerText = element.Name;
                    Label13.Text = element.id.ToString();
                }
                else if (conter == 14)
                {
                    div14.Visible = true;
                    Strong14.InnerText = element.Name;
                    Label14.Text = element.id.ToString();
                }
                else if (conter == 15)
                {
                    div15.Visible = true;
                    Strong15.InnerText = element.Name;
                    Label15.Text = element.id.ToString();
                }
                else if (conter == 16)
                {
                    div16.Visible = true;
                    Strong16.InnerText = element.Name;
                    Label16.Text = element.id.ToString();
                }
                else if (conter == 17)
                {
                    div17.Visible = true;
                    Strong17.InnerText = element.Name;
                    Label17.Text = element.id.ToString();
                }
                else if (conter == 18)
                {
                    div18.Visible = true;
                    Strong18.InnerText = element.Name;
                    Label18.Text = element.id.ToString();
                }
                else if (conter == 19)
                {
                    div19.Visible = true;
                    Strong19.InnerText = element.Name;
                    Label19.Text = element.id.ToString();
                }
                else if (conter == 20)
                {
                    div20.Visible = true;
                    Strong20.InnerText = element.Name;
                    Label20.Text = element.id.ToString();
                }
                else if (conter == 21)
                {
                    div21.Visible = true;
                    Strong21.InnerText = element.Name;
                    Label21.Text = element.id.ToString();
                }
                else if (conter == 22)
                {
                    div22.Visible = true;
                    Strong22.InnerText = element.Name;
                    Label22.Text = element.id.ToString();
                }
                else if (conter == 23)
                {
                    div23.Visible = true;
                    Strong23.InnerText = element.Name;
                    Label23.Text = element.id.ToString();
                }
                else if (conter == 24)
                {
                    div24.Visible = true;
                    Strong24.InnerText = element.Name;
                    Label24.Text = element.id.ToString();
                }
                else if (conter == 25)
                {
                    div25.Visible = true;
                    Strong25.InnerText = element.Name;
                    Label25.Text = element.id.ToString();
                }
                else if (conter == 26)
                {
                    div26.Visible = true;
                    Strong26.InnerText = element.Name;
                    Label26.Text = element.id.ToString();
                }
                else if (conter == 27)
                {
                    div27.Visible = true;
                    Strong27.InnerText = element.Name;
                    Label27.Text = element.id.ToString();
                }
                else if (conter == 28)
                {
                    div28.Visible = true;
                    Strong28.InnerText = element.Name;
                    Label28.Text = element.id.ToString();
                }
                else if (conter == 29)
                {
                    div29.Visible = true;
                    Strong29.InnerText = element.Name;
                    Label29.Text = element.id.ToString();
                }
                else if (conter == 30)
                {
                    div30.Visible = true;
                    Strong30.InnerText = element.Name;
                    Label30.Text = element.id.ToString();
                }
                else if (conter == 31)
                {
                    div31.Visible = true;
                    Strong31.InnerText = element.Name;
                    Label31.Text = element.id.ToString();
                }
                else if (conter == 32)
                {
                    div32.Visible = true;
                    Strong32.InnerText = element.Name;
                    Label32.Text = element.id.ToString();
                }
                else if (conter == 33)
                {
                    div33.Visible = true;
                    Strong33.InnerText = element.Name;
                    Label33.Text = element.id.ToString();
                }
                else if (conter == 34)
                {
                    div34.Visible = true;
                    Strong34.InnerText = element.Name;
                    Label34.Text = element.id.ToString();
                }
                else if (conter == 35)
                {
                    div35.Visible = true;
                    Strong35.InnerText = element.Name;
                    Label35.Text = element.id.ToString();
                }
                else if (conter == 36)
                {
                    div36.Visible = true;
                    Strong36.InnerText = element.Name;
                    Label36.Text = element.id.ToString();
                }
                else if (conter == 37)
                {
                    div37.Visible = true;
                    Strong37.InnerText = element.Name;
                    Label37.Text = element.id.ToString();
                }
                else if (conter == 38)
                {
                    div38.Visible = true;
                    Strong38.InnerText = element.Name;
                    Label38.Text = element.id.ToString();
                }
                else if (conter == 39)
                {
                    div39.Visible = true;
                    Strong39.InnerText = element.Name;
                    Label39.Text = element.id.ToString();
                }
                else if (conter == 40)
                {
                    div40.Visible = true;
                    Strong40.InnerText = element.Name;
                    Label40.Text = element.id.ToString();
                }
                #endregion
            }


        }
        protected void save_engineer_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel3.Visible = true;
        }
    }
}