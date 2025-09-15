using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025
{
    public partial class Comprehensive_Guide_to_International_Transportation : System.Web.UI.Page
    {
        public static string pic_url = ""; public static string pic_url2 = "";
        public static string title_pg = "";
        public static string date_publich = "";
        public static string date_last_edit = "";
        public static string date_last_edit_utc = "";
        public static string canonical_url = "";
        public static string robot_follow = "";
        public static string robot_index = "";
        public static string page_name = "";
        public static string alt_main_image = "";


        protected void Page_Load(object sender, EventArgs e)
        {


            DataClasses1DataContext Db = new DataClasses1DataContext();
            string page_name_ = "راهنمای جامع حمل و نقل بین المللی";
            var page = Db.Text_for_store_steels.Where(c => c.name_page == page_name_);
            subject.Text = "درخواست " + page_name_; page_id.Text = page.Single().id.ToString();
            subject2.Text = "استعلام " + page_name_;
            head_estelam2.InnerText = "درخواست استعلام " + page_name_;
            head_estelam.InnerText = "درخواست خدمات " + page_name_;
            if (page.Count() > 0)
            {
                var page_ = page.Take(1).Single();
                //page_title.Style["background-image"] = Page.ResolveUrl("/../.." + page_.pic);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                string url_path = url.Replace(path, "");
                pic_url = url_path + page_.pic; pic_url2 = "../../" + page_.pic;
                //if (Request.QueryString["T"] == null) { Response.Redirect(url + "?T=" + page_.title_page.Replace(" ", "-")); }
                title_pg = page_.title_page;
                if (page_.title_page == "" || page_.title_page == null)
                {
                    mainTitle_.InnerText = page_name_;
                }
                else
                {
                    mainTitle_.InnerText = page_name_;

                }
                if (page_.P_description == null)
                {
                    mainDescription_.InnerText = " ثبت درخواست " + page_name_;
                }
                else
                {
                    mainDescription_.InnerText = "";
                }

                if (page_.date_publish == null)
                {
                    date_publich = DateTime.Now.ToShortDateString().ToString();

                }
                else
                {
                    date_publich = page_.date_publish;
                }
                if (page_.date_last_edit == null)
                {
                    date_last_edit_utc = DateTime.Now.ToShortDateString().ToString();
                }
                else
                {
                    date_last_edit = page_.date_last_edit;

                    DateTime date_utc = Convert.ToDateTime(date_last_edit).AddHours(-4).AddMinutes(30);
                    date_last_edit_utc = date_utc.ToString();
                }

                canonical_url = page_.Canonical_url;
                if (page_.follow == true)
                {
                    robot_follow = "FOLLOW";

                }
                else
                {
                    robot_follow = "NOFOLLOW";

                }

                if (page_.index_ == true)
                {
                    robot_index = "INDEX";

                }
                else
                {
                    robot_index = "NOINDEX";

                }
                page_name = "خدمات تخصصی" + "/" + page_name_;
                alt_main_image = "عکس " + page_.title_page;
                Page.Title = "نوبین | " + page_.title_page;
                Page.MetaDescription = page_.P_description;
                var keyword = Db.Paper_tag_tbls.Where(c => c.idtextforstore == page_.id);
                int conter_keyword;
                string text_keyword = "";
                if (keyword.Count() > 0)
                {
                    foreach (var element in keyword)
                    {
                        conter_keyword = Convert.ToInt32(element.idtag);
                        var a = Db.Tags_tbls.Where(c => c.id == conter_keyword);
                        if (a.Count() > 0)
                        {
                            text_keyword = text_keyword + " " + "," + a.Single().tag;
                        }
                    }
                }
                Page.MetaKeywords = text_keyword;

                if (page_.full_text == null)
                {
                    text_servises.Visible = false;
                }
                else
                {
                    text_servises.Visible = true;
                    Literal1.Text = page_.full_text.Replace("../", "/").Replace("<img", "<img class=img-responsive").Replace("<img", "<img loading=lazy"); titr_page.InnerText = page_.title_page;
                }


                date_contact.Items.Add("شنبه ساعت 9-12");
                date_contact.Items.Add("شنبه ساعت 13-17");
                date_contact.Items.Add("یکشنبه ساعت 9-12");
                date_contact.Items.Add("یکشنبه ساعت 13-17");
                date_contact.Items.Add("دوشنبه ساعت 9-12");
                date_contact.Items.Add("دوشنبه ساعت 13-17");
                date_contact.Items.Add("سه شنبه ساعت 9-12");
                date_contact.Items.Add("سه شنبه ساعت 13-17");
                date_contact.Items.Add("چهارشنبه ساعت 9-12");
                date_contact.Items.Add("چهارشنبه ساعت 13-17");
                date_contact.Items.Add("پنج شنبه ساعت 9-12");

                date_contact2.Items.Add("شنبه ساعت 9-12");
                date_contact2.Items.Add("شنبه ساعت 13-17");
                date_contact2.Items.Add("یکشنبه ساعت 9-12");
                date_contact2.Items.Add("یکشنبه ساعت 13-17");
                date_contact2.Items.Add("دوشنبه ساعت 9-12");
                date_contact2.Items.Add("دوشنبه ساعت 13-17");
                date_contact2.Items.Add("سه شنبه ساعت 9-12");
                date_contact2.Items.Add("سه شنبه ساعت 13-17");
                date_contact2.Items.Add("چهارشنبه ساعت 9-12");
                date_contact2.Items.Add("چهارشنبه ساعت 13-17");
                date_contact2.Items.Add("پنج شنبه ساعت 9-12");




                base_address.InnerText = "خدمات تخصصی";
                other_address.InnerText = page_name_;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var a = 1;
            if (a == 1)
            {
                String q1 = TextBox_captcha.Text.ToString();
                String q2 = txt_captcha.Text;
                if (Equals(q1, q2))
                {
                    DataClasses1DataContext Db = new DataClasses1DataContext();

                    var phone1 = phone.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
                    var user_exist = Db.User_tbls.Where(c => c.Phone == phone1);
                    if (phone1.Length == 11 && user_exist.Count() == 0)
                    {
                        #region ایجاد کاربر و پنل
                        string pass = Commonlyusedcodes.code_6number(); Db.P_Insert_User_tbl(name.Text, null, PersianDate.GetPersianDate(), pass, null, phone1, null, null, null, null, PersianDate.GetPersianDate(), null, "کاربر معمولی", true, true, null, null, null, null, true, null);
                        var user = Db.User_tbls.Where(c => c.Phone == phone1);
                        if (user.Count() == 1)
                        {
                            var Reques = Db.Request_tbls.OrderByDescending(c => c.id);
                            if (Reques.Count() > 0)
                            {
                                #region ایجاد درخواست

                                if (FileUpload1.HasFile)
                                {

                                    int fileSize = FileUpload1.PostedFile.ContentLength;
                                    if (fileSize < 20000000)
                                    {
                                        string folder = (Reques.Take(1).Single().id + 1).ToString();
                                        string directoryPath = Server.MapPath(string.Format("/files/request/{0}/", folder.Trim()));
                                        string address_file = string.Format("/files/request/{0}/", folder.Trim());
                                        if (!Directory.Exists(directoryPath))
                                        {
                                            Directory.CreateDirectory(directoryPath);
                                        }
                                        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                                        Db.P_Insert_Request_tbl(" درخواست " + mainTitle_.InnerText.ToString(), user.Single().id, date_contact.Text, message.Text, address_file + fileName, PersianDate.GetPersianDate(), name.Text, phone1);
                                        var message1 = Db.Request_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);
                                        Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user.Single().id, null, message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true);
                                        corect.Text = "1";

                                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + name.Text + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "\n" + "رمز عبور شما" + "\n" + pass + "برای ورود به سامانه می باشد.\n" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                        string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک درخواست خدمات در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                        name.Text = "";
                                        phone.Text = "";
                                        message.Text = "";
                                        date_contact.Text = "";
                                        string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                        if (Request.QueryString["T"] == null)
                                        {
                                            Response.Redirect(url_ + "?corect=1");
                                        }
                                        else
                                        {
                                            Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=1");
                                        }

                                    }
                                    else
                                    {
                                        corect.Text = "4";
                                        string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                        if (Request.QueryString["T"] == null)
                                        {
                                            Response.Redirect(url_ + "?corect=4");
                                        }
                                        else
                                        {
                                            Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=4");
                                        }

                                    }



                                }
                                else
                                {
                                    Db.P_Insert_Request_tbl(" درخواست " + mainTitle_.InnerText.ToString(), user.Single().id, date_contact.Text, message.Text, null, PersianDate.GetPersianDate(), name.Text, phone1);
                                    var message1 = Db.Request_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);
                                    Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user.Single().id, null, message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);
                                    corect.Text = "1";

                                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + name.Text + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "\n" + "رمز عبور شما" + "\n" + pass + "برای ورود به سامانه می باشد.\n" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                    string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک درخواست خدمات در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                    name.Text = "";
                                    phone.Text = "";
                                    message.Text = "";
                                    date_contact.Text = "";
                                    string url_ = HttpContext.Current.Request.Url.AbsolutePath;

                                    if (Request.QueryString["T"] == null)
                                    {
                                        Response.Redirect(url_ + "?corect=1");
                                    }
                                    else
                                    {
                                        Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=1");
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                corect.Text = "5";
                                string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                if (Request.QueryString["T"] == null)
                                {
                                    Response.Redirect(url_ + "?corect=5");
                                }
                                else
                                {
                                    Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=5");
                                }
                            }
                        }
                        else
                        {
                            corect.Text = "6";
                            string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                            if (Request.QueryString["T"] == null)
                            {
                                Response.Redirect(url_ + "?corect=6");
                            }
                            else
                            {
                                Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=6");
                            }
                        }


                        #endregion
                    }
                    else if (phone.Text.Length == 11 && user_exist.Count() == 1)
                    {
                        var Reques = Db.Request_tbls.OrderByDescending(c => c.id);
                        if (Reques.Count() > 0)
                        {
                            #region ایجاد درخواست
                            string folder = (Reques.Take(1).Single().id + 1).ToString();
                            string directoryPath = Server.MapPath(string.Format("/files/request/{0}/", folder.Trim()));
                            string address_file = string.Format("/files/request/{0}/", folder.Trim());
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            if (FileUpload1.HasFile)
                            {
                                int fileSize = FileUpload1.PostedFile.ContentLength;
                                if (fileSize < 20000000)
                                {
                                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                                    Db.P_Insert_Request_tbl(" درخواست " + mainTitle_.InnerText.ToString(), user_exist.Single().id, date_contact.Text, message.Text, address_file + fileName, PersianDate.GetPersianDate(), name.Text, phone1);
                                    var message1 = Db.Request_tbls.Where(c => c.id_user == user_exist.Single().id).OrderByDescending(c => c.id);
                                    Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user_exist.Single().id, null, message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true);
                                    corect.Text = "1";
                                    //"نوبین\n" + user_exist.Single().Name + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید"  + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login"
                                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + user_exist.Single().Name + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                    string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک درخواست خدمات در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                    name.Text = "";
                                    phone.Text = "";
                                    message.Text = "";
                                    date_contact.Text = "";
                                    string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                    if (Request.QueryString["T"] == null)
                                    {
                                        Response.Redirect(url_ + "?corect=1");
                                    }
                                    else
                                    {
                                        Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=1");
                                    }
                                }
                                else
                                {
                                    corect.Text = "4";
                                    string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                    if (Request.QueryString["T"] == null)
                                    {
                                        Response.Redirect(url_ + "?corect=4");
                                    }
                                    else
                                    {
                                        Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=4");
                                    }
                                }

                            }
                            else
                            {
                                Db.P_Insert_Request_tbl(" درخواست " + mainTitle_.InnerText.ToString(), user_exist.Single().id, date_contact.Text, message.Text, null, PersianDate.GetPersianDate(), name.Text, phone1);
                                var message1 = Db.Request_tbls.Where(c => c.id_user == user_exist.Single().id).OrderByDescending(c => c.id);
                                Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user_exist.Single().id, null, message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);
                                corect.Text = "1";
                                string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + user_exist.Single().Name + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک درخواست خدمات در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                name.Text = "";
                                phone.Text = "";
                                message.Text = "";
                                date_contact.Text = "";
                                string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                if (Request.QueryString["T"] == null)
                                {
                                    Response.Redirect(url_ + "?corect=1");
                                }
                                else
                                {
                                    Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=1");
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            corect.Text = "5";
                            string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                            if (Request.QueryString["T"] == null)
                            {
                                Response.Redirect(url_ + "?corect=5");
                            }
                            else
                            {
                                Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=5");
                            }
                        }
                    }
                    else
                    {
                        corect.Text = "2";
                        string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                        if (Request.QueryString["T"] == null)
                        {
                            Response.Redirect(url_ + "?corect=2");
                        }
                        else
                        {
                            Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=2");
                        }
                    }
                }
                else
                {
                    String number_pic_captcha = Commonlyusedcodes.dahgan() + Commonlyusedcodes.yekan();
                    String consept_pic_captcha = Commonlyusedcodes.Number_pic(number_pic_captcha);
                    txt_captcha.Text = consept_pic_captcha;
                    Image1_captcha.ImageUrl = "/captcha/" + Convert.ToInt32(number_pic_captcha) + ".jpg";
                    Label_captcha.Text = "حاصل عبارت را به طور صحیح وارد نمایید.";
                    Label_captcha.Visible = true;

                }
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var a = 1;
            if (a == 1)
            {

                String q1 = TextBox_captcha2.Text.ToString();
                String q2 = txt_captcha2.Text;
                if (Equals(q1, q2))
                {



                    var phone1 = phone2.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
                    var user_exist = Db.User_tbls.Where(c => c.Phone == phone1);
                    if (phone1.Length == 11 && user_exist.Count() == 0)
                    {
                        #region ایجاد کاربر و پنل
                        string pass = Commonlyusedcodes.code_6number(); Db.P_Insert_User_tbl(name2.Text, null, PersianDate.GetPersianDate(), pass, null, phone1, null, null, null, null, PersianDate.GetPersianDate(), null, "کاربر معمولی", true, true, null, null, null, null, true, null);
                        var user = Db.User_tbls.Where(c => c.Phone == phone1);
                        if (user.Count() == 1)
                        {
                            var Reques = Db.Request_tbls.OrderByDescending(c => c.id);
                            if (Reques.Count() > 0)
                            {
                                #region ایجاد استعلام

                                if (FileUpload2.HasFile)
                                {
                                    int fileSize = FileUpload2.PostedFile.ContentLength;
                                    if (fileSize < 20000000)
                                    {
                                        string folder = (Reques.Take(1).Single().id + 1).ToString();
                                        string directoryPath = Server.MapPath(string.Format("/files/request/{0}/", folder.Trim()));
                                        string address_file = string.Format("/files/request/{0}/", folder.Trim());
                                        if (!Directory.Exists(directoryPath))
                                        {
                                            Directory.CreateDirectory(directoryPath);
                                        }
                                        string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                                        FileUpload2.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                                        Db.P_Insert_Request_tbl(" استعلام " + mainTitle_.InnerText.ToString(), user.Single().id, date_contact2.Text, message2.Text, address_file + fileName, PersianDate.GetPersianDate(), name2.Text, phone1);
                                        var message1 = Db.Request_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);
                                        Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user.Single().id, null, message2.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true);
                                        corect.Text = "3";
                                        //string sms = "نوبین\n" + name.Text + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "\n" + "رمز عبور شما" + "\n" + pass + "برای ورود به سامانه می باشد.\n" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login";
                                        string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + name.Text + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "\n" + "رمز عبور شما" + "\n" + pass + "برای ورود به سامانه می باشد.\n" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                        string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک درخواست استعلام در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                        name2.Text = "";
                                        phone2.Text = "";
                                        message2.Text = "";
                                        date_contact2.Text = "";
                                        string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                        if (Request.QueryString["T"] == null)
                                        {
                                            Response.Redirect(url_ + "?corect=3");
                                        }
                                        else
                                        {
                                            Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=3");
                                        }
                                    }
                                    else
                                    {
                                        corect.Text = "4";
                                        string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                        if (Request.QueryString["T"] == null)
                                        {
                                            Response.Redirect(url_ + "?corect=4");
                                        }
                                        else
                                        {
                                            Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=4");
                                        }
                                    }

                                }
                                else
                                {
                                    Db.P_Insert_Request_tbl(" استعلام " + mainTitle_.InnerText.ToString(), user.Single().id, date_contact2.Text, message2.Text, null, PersianDate.GetPersianDate(), name2.Text, phone1);
                                    var message1 = Db.Request_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);
                                    Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user.Single().id, null, message2.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);
                                    corect.Text = "3";

                                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + name.Text + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "\n" + "رمز عبور شما" + "\n" + pass + "برای ورود به سامانه می باشد.\n" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                    string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک درخواست استعلام در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                    name2.Text = "";
                                    phone2.Text = "";
                                    message2.Text = "";
                                    date_contact2.Text = "";
                                    string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                    if (Request.QueryString["T"] == null)
                                    {
                                        Response.Redirect(url_ + "?corect=3");
                                    }
                                    else
                                    {
                                        Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=3");
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                corect.Text = "5";
                                string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                if (Request.QueryString["T"] == null)
                                {
                                    Response.Redirect(url_ + "?corect=5");
                                }
                                else
                                {
                                    Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=5");
                                }
                            }

                        }
                        else
                        {
                            corect.Text = "6";
                            string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                            if (Request.QueryString["T"] == null)
                            {
                                Response.Redirect(url_ + "?corect=6");
                            }
                            else
                            {
                                Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=6");
                            }
                        }


                        #endregion
                    }
                    else if (phone1.Length == 11 && user_exist.Count() == 1)
                    {
                        var Reques = Db.Request_tbls.OrderByDescending(c => c.id);
                        if (Reques.Count() > 0)
                        {
                            #region ایجاد استعلام
                            string folder = (Reques.Take(1).Single().id + 1).ToString();
                            string directoryPath = Server.MapPath(string.Format("/files/request/{0}/", folder.Trim()));
                            string address_file = string.Format("/files/request/{0}/", folder.Trim());
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            if (FileUpload2.HasFile)
                            {
                                int fileSize = FileUpload2.PostedFile.ContentLength;
                                if (fileSize < 20000000)
                                {
                                    string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                                    FileUpload2.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                                    Db.P_Insert_Request_tbl(" استعلام " + mainTitle_.InnerText.ToString(), user_exist.Single().id, date_contact2.Text, message2.Text, address_file + fileName, PersianDate.GetPersianDate(), name2.Text, phone1);
                                    var message1 = Db.Request_tbls.Where(c => c.id_user == user_exist.Single().id).OrderByDescending(c => c.id);
                                    Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user_exist.Single().id, null, message2.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, address_file + fileName, true);
                                    corect.Text = "3";
                                    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + user_exist.Single().Name + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                    string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک استعلام خدمات در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                    name2.Text = "";
                                    phone2.Text = "";
                                    message2.Text = "";
                                    date_contact2.Text = "";
                                    string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                    if (Request.QueryString["T"] == null)
                                    {
                                        Response.Redirect(url_ + "?corect=3");
                                    }
                                    else
                                    {
                                        Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=3");
                                    }
                                }
                                else
                                {
                                    corect.Text = "4";
                                    string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                    if (Request.QueryString["T"] == null)
                                    {
                                        Response.Redirect(url_ + "?corect=4");
                                    }
                                    else
                                    {
                                        Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=4");
                                    }
                                }
                            }
                            else
                            {
                                Db.P_Insert_Request_tbl(" استعلام " + mainTitle_.InnerText.ToString(), user_exist.Single().id, date_contact2.Text, message2.Text, null, PersianDate.GetPersianDate(), name2.Text, phone1);
                                var message1 = Db.Request_tbls.Where(c => c.id_user == user_exist.Single().id).OrderByDescending(c => c.id);
                                Db.P_Insert_all_message_tbl(null, null, null, message1.Take(1).Single().id, user_exist.Single().id, null, message2.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);
                                corect.Text = "3";
                                string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone1 + "&text=" + "نوبین\n" + user_exist.Single().Name + " گرامی \n" + ".پنل کاربری شما در سامانه ایجاد گردید.برای پیگیری درخواست خود از طریق لینک زیر اقدام نمایید" + "لینک ورود به سامانه\n" + "\n https://nobincommerce.com/account/login" + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
                                string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09120328839" + "&text=" + "Nobin Gostar Paya\n" + "\n یک استعلام خدمات در سامانه ثبت گردید." + "&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";

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
                                name2.Text = "";
                                phone2.Text = "";
                                message2.Text = "";
                                date_contact2.Text = "";
                                string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                                if (Request.QueryString["T"] == null)
                                {
                                    Response.Redirect(url_ + "?corect=3");
                                }
                                else
                                {
                                    Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=3");
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            corect.Text = "5";
                            string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                            if (Request.QueryString["T"] == null)
                            {
                                Response.Redirect(url_ + "?corect=5");
                            }
                            else
                            {
                                Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=5");
                            }
                        }
                    }
                    else
                    {
                        corect.Text = "2";
                        string url_ = HttpContext.Current.Request.Url.AbsolutePath;
                        if (Request.QueryString["T"] == null)
                        {
                            Response.Redirect(url_ + "?corect=2");
                        }
                        else
                        {
                            Response.Redirect(url_ + "?T=" + Request.QueryString["T"] + "&corect" + "=3");
                        }

                    }
                }
                else
                {
                    String number_pic_captcha = Commonlyusedcodes.dahgan() + Commonlyusedcodes.yekan();
                    String consept_pic_captcha = Commonlyusedcodes.Number_pic(number_pic_captcha);
                    txt_captcha2.Text = consept_pic_captcha;
                    Image1_captcha2.ImageUrl = "/captcha/" + Convert.ToInt32(number_pic_captcha) + ".jpg";
                    Label_captcha2.Text = "حاصل عبارت را به طور صحیح وارد نمایید.";
                    Label_captcha2.Visible = true;
                }
            }


        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            String number_pic_captcha = Commonlyusedcodes.dahgan() + Commonlyusedcodes.yekan();
            String consept_pic_captcha = Commonlyusedcodes.Number_pic(number_pic_captcha);
            txt_captcha.Text = consept_pic_captcha;
            Image1_captcha.ImageUrl = "/captcha/" + Convert.ToInt32(number_pic_captcha) + ".jpg";
            TextBox_captcha.Visible = true;

            String number_pic_captcha2 = Commonlyusedcodes.dahgan() + Commonlyusedcodes.yekan();
            String consept_pic_captcha2 = Commonlyusedcodes.Number_pic(number_pic_captcha2);
            txt_captcha2.Text = consept_pic_captcha2;
            Image1_captcha2.ImageUrl = "/captcha/" + Convert.ToInt32(number_pic_captcha2) + ".jpg";
            TextBox_captcha2.Visible = true;
            if (Request.QueryString["T"] == null)
            {
                contactSuccess2.Style["display"] = "none";
                contactError2.Style["display"] = "none";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }


            else if (Request.QueryString["corect"] == "1")
            {
                contactSuccess2.Style["display"] = "block";
                contactError2.Style["display"] = "none";
                contactSuccess2.Visible = true;
                Label12.Visible = true;
                Label12.Text = " درخواست " + mainTitle_.InnerText.ToString() + " با موفقیت ارسال گردید.";
                contactError2.Visible = false;
                corect.Text = "";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }
            else if (Request.QueryString["corect"] == "3")
            {
                contactSuccess2.Style["display"] = "block";
                contactError2.Style["display"] = "none";
                contactSuccess2.Visible = true;
                Label12.Visible = true;
                Label12.Text = " استعلام " + mainTitle_.InnerText.ToString() + " با موفقیت ارسال گردید.";
                contactError2.Visible = false;
                corect.Text = "";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }
            else if (Request.QueryString["corect"] == "2")
            {
                contactSuccess2.Style["display"] = "none";
                contactError2.Style["display"] = "block";
                contactError2.Visible = true;
                Label22.Text = "لطفا شماره همراه خود را به طور صحیح وارد نمایید.";
                contactSuccess2.Visible = false;
                corect.Text = "";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }
            else if (Request.QueryString["corect"] == "4")
            {
                contactSuccess2.Style["display"] = "none";
                contactError2.Style["display"] = "block";
                contactError2.Visible = true;
                Label22.Text = "حداکثر سایز فایل ارسالی 20 mb باید باشد.";
                contactSuccess2.Visible = false;
                corect.Text = "";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }
            else if (Request.QueryString["corect"] == "5")
            {
                contactSuccess2.Style["display"] = "none";
                contactError2.Style["display"] = "block";
                contactError2.Visible = true;
                Label22.Text = "خطا در دیتابیس روی داده است.";
                contactSuccess2.Visible = false;
                corect.Text = "";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }
            else if (Request.QueryString["corect"] == "6")
            {
                contactSuccess2.Style["display"] = "none";
                contactError2.Style["display"] = "block";
                contactError2.Visible = true;
                Label22.Text = "با این شماره موبایل دو کاربر وجود دارد.";
                contactSuccess2.Visible = false;
                corect.Text = "";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }

            else
            {
                contactSuccess2.Style["display"] = "none";
                contactError2.Style["display"] = "none";
                name2.Text = "";
                phone2.Text = "";
                message2.Text = "";
                date_contact2.Text = "";
                name.Text = "";
                phone.Text = "";
                message.Text = "";
                date_contact.Text = "";
            }
        }

        protected void ImageButton1_refresh_Click(object sender, ImageClickEventArgs e)
        {

            string number_pic_captcha = Commonlyusedcodes.dahgan() + Commonlyusedcodes.yekan();
            string consept_pic_captcha = Commonlyusedcodes.Number_pic(number_pic_captcha);
            txt_captcha.Text = consept_pic_captcha;
            Image1_captcha.ImageUrl = "/captcha/" + Convert.ToInt32(number_pic_captcha) + ".jpg";

        }

        protected void ImageButton1_refresh2_Click(object sender, ImageClickEventArgs e)
        {
            string number_pic_captcha2 = Commonlyusedcodes.dahgan() + Commonlyusedcodes.yekan();
            string consept_pic_captcha2 = Commonlyusedcodes.Number_pic(number_pic_captcha2);
            txt_captcha2.Text = consept_pic_captcha2;
            Image1_captcha2.ImageUrl = "/captcha/" + Convert.ToInt32(number_pic_captcha2) + ".jpg";
        }
    }
}