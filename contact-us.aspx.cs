using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025
{
    public partial class contact_us : System.Web.UI.Page
    {
        private static string Dateshamsi1403()
        {
            try
            {
                string date = string.Empty;
               DateTime nowshamsi = DateTime.Parse("1/1/1403 00:00:00 AM");
                //DateTime now = DateTime.Parse("12/28/2022 00:00:00 AM");
                DateTime now = DateTime.Now;
                DateTime miladi = DateTime.Parse("3/20/2024 00:00:00 AM");
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
        private static string code()
        {
            try
            {
                //string numbers = "1234567890";

                string characters = "0987654321";

                int length = 6;
                string otp = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }


                return otp;
            }
            catch
            {
                return "0";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MetaDescription = "لوکیشن نوبین به همراه اطلاعات تماس";
            Page.Title = "نوبین | تماس با نوبین";

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var phone1 = email.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

            if (phone1.Length == 11)
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                 var user_exist = Db.User_tbls.Where(c => c.Phone == phone1);
                if (phone1.Length == 11 && user_exist.Count() == 0)
                {
                    string pass = code();
                    Db.P_Insert_User_tbl(name.Text, null, Dateshamsi1403(), pass, "", phone1, "", "", "", "/img/default-user.png", Dateshamsi1403(), "", "کاربر معمولی", true, true, "", "", "", "", true, "");
                    var user = Db.User_tbls.Where(c => c.Phone == phone1);
                    Db.P_Insert_Message_to_maneger_tbl(name.Text, phone1, null, subject.Text, message.Text, DateTime.Now.ToShortDateString().ToString(), false, null, null, user.Single().id, null);

                    var message1 = Db.Message_to_maneger_tbls.Where(c => c.id_user_sender == user.Single().id).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, message1.Take(1).Single().id, null, null, user.Single().id, null, message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);
                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "Nobin Gostar Paya\n" + "کلمه عبور:" + pass + "\n برای دریافت پاسخ این رمز عبور شما برای ورود به سامانه نوبین می باشد."+ "\n https://nobincommerce.com/account/login_pages" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                    string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک تیکت  در سامانه ثبت شد." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    System.Net.WebResponse resp = req.GetResponse();
                    var st = resp.GetResponseStream();
                    var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                    string _responseStr = sr.ReadToEnd();
                    sr.Close();
                    resp.Close();
                    HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(url2);
                    System.Net.WebResponse resp2 = req2.GetResponse();
                    var st2 = resp2.GetResponseStream();
                    var sr2 = new System.IO.StreamReader(st2, Encoding.UTF8);
                    string _responseStr2 = sr2.ReadToEnd();
                    sr2.Close();
                    resp2.Close();

                    contactSuccess.Visible = true;
                    Label1.Visible = true;
                    Label1.Text = "پیام شما با موفقیت ثبت شد. و پنل کاربری ایجاد شد. برای دریافت پاسخ از پنل کاربری پیگیری نمایید.";


                }
                else if (email.Text.Length == 11 && user_exist.Count() == 1)
                {
                   
                    var user1 = Db.User_tbls.Where(c => c.Phone == phone1);
                    Db.P_Insert_Message_to_maneger_tbl(name.Text, phone1, null, subject.Text, message.Text, DateTime.Now.ToShortDateString().ToString(), false, null, null, user1.Single().id, null);

                    var message1 = Db.Message_to_maneger_tbls.Where(c => c.id_user_sender == user_exist.Single().id).OrderByDescending(c => c.id);
                    Db.P_Insert_all_message_tbl(null, message1.Take(1).Single().id, null, null, user_exist.Single().id, null, message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);

                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "Nobin Gostar Paya\n" + "\n برای دریافت پاسخ به سامانه نوبین مراجعه نمایید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                    string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" +"09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک تیکت  در سامانه ثبت شد." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    System.Net.WebResponse resp = req.GetResponse();
                    var st = resp.GetResponseStream();
                    var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                    string _responseStr = sr.ReadToEnd();
                    sr.Close();
                    resp.Close();
                    HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(url2);
                    System.Net.WebResponse resp2 = req2.GetResponse();
                    var st2 = resp2.GetResponseStream();
                    var sr2 = new System.IO.StreamReader(st2, Encoding.UTF8);
                    string _responseStr2 = sr2.ReadToEnd();
                    sr2.Close();
                    resp2.Close();

                    contactSuccess.Visible = true;
                    Label1.Visible = true;
                    Label1.Text = "پیام شما با موفقیت ثبت شد. برای دریافت پاسخ از پنل کاربری پیگیری نمایید.";

                }
                else
                {
                    contactError.Visible = true;
                    Label2.Text = "لطفا شماره صحیح وارد کنید";
                    Label2.Visible = true;
                }

               
            }
            else
            {
                contactError.Visible = true;
                Label2.Text = "لطفا شماره صحیح وارد کنید";
                Label2.Visible = true;
            }
           
        }
    }
}