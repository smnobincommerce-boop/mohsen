using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class edit_profile : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Session["mobile"] = phone;
            //Session["name"] = login.Single().Name;
            //Session["role"] = login.Single().Role;


            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                if (user.Count() == 1)
                {
                    var user_uniq = user.Single();

                    //name_user.InnerText = user_uniq.Name;
                    //txt_address.InnerText = user_uniq.Address;
                    //txt_des_user.InnerText = user_uniq.About_me;
                    //txt_education.InnerText = user_uniq.Education;
                    //txt_email.InnerText = user_uniq.Email;
                    //txt_Expertise.InnerText = user_uniq.cv;
                    //txt_last_visit.InnerText = user_uniq.Lastedit;
                    //txt_name_user.InnerText = user_uniq.Name;
                    //txt_phone.InnerText = user_uniq.Phone;
                    //txt_postal_code.InnerText = user_uniq.Post_code;
                    //txt_type_user.InnerText = user_uniq.Role;
                    if (user_uniq.Pic == "" || user_uniq.Pic == null)
                    {
                        //img_over_view.Src = "../../img/default-user.png";
                        img_edit.Src = "../../img/default-user.png";

                    }
                    else
                    {
                        //img_over_view.Src = "../../" + user_uniq.Pic;
                        img_edit.Src = "../../" + user_uniq.Pic;

                    }

                    //txt_website.InnerText=user_uniq.
                    lbl_about_us.Value = user_uniq.About_me;

                    lbl_address.Value = user_uniq.Address;
                    //lbl_city.Value = "";

                    if (user_uniq.personality == true)
                    {

                        RadioButtonList1.SelectedValue = "1";
                    }
                    else
                    {

                        RadioButtonList1.SelectedValue = "0";

                    }
                    lbl_cv.Value = user_uniq.cv;
                    lbl_economic_code.Value = user_uniq.economic_code;
                    lbl_email.Value = user_uniq.Email;
                    lbl_firstname.Value = user_uniq.Name;
                    lbl_national_code.Value = user_uniq.national_code;
                    Txt_lbl_phone.Text = user_uniq.Phone;
                    lbl_postcode.Value = user_uniq.Post_code;
                    //lbl_education.Value = user_uniq.Education;
                    lbl_Password.Text = user_uniq.Password;
                    lbl_ConfirmPassword.Text = user_uniq.Password;

                    var exist_user_data = Db.Staff_tbls.Where(c => c.Mobile == user.Single().Phone);
                    if (exist_user_data.Count() == 0)
                    {
                        lbl_complete_cv.Text = "";
                    }
                    else if (exist_user_data.Count() == 1)
                    {
                        lbl_complete_cv.Text = exist_user_data.Single().Description_activity;
                    }
                }
            }
            if (Request.QueryString["ID"] != null && Session["mobile"] != null) 
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                var user = Db.User_tbls.Where(c => c.id == Convert.ToInt32( Request.QueryString["ID"]));
                if (user.Count() == 1)
                {
                    var user_uniq = user.Single();

                    //name_user.InnerText = user_uniq.Name;
                    //txt_address.InnerText = user_uniq.Address;
                    //txt_des_user.InnerText = user_uniq.About_me;
                    //txt_education.InnerText = user_uniq.Education;
                    //txt_email.InnerText = user_uniq.Email;
                    //txt_Expertise.InnerText = user_uniq.cv;
                    //txt_last_visit.InnerText = user_uniq.Lastedit;
                    //txt_name_user.InnerText = user_uniq.Name;
                    //txt_phone.InnerText = user_uniq.Phone;
                    //txt_postal_code.InnerText = user_uniq.Post_code;
                    //txt_type_user.InnerText = user_uniq.Role;
                    if (user_uniq.Pic == "" || user_uniq.Pic == null)
                    {
                        //img_over_view.Src = "../../img/default-user.png";
                        img_edit.Src = "../../img/default-user.png";
                    }
                    else
                    {
                        //img_over_view.Src = "../../" + user_uniq.Pic;
                        img_edit.Src = "../../" + user_uniq.Pic;
                    }

                    //txt_website.InnerText=user_uniq.
                    
                   

                    if (user_uniq.About_me == null)
                    {
                       
                        lbl_about_us.Value = user_uniq.About_me;
                        lbl_about_us.Visible = true;
                    }
                    else
                    {
                        lbl_about_us.Value = " :" + user_uniq.About_me.ToString();
                        lbl_about_us.Visible = true;
                    }
                    lbl_address.Value = user_uniq.Address;
                    //lbl_city.Value = "";

                    if (user_uniq.personality == true)
                    {

                        RadioButtonList1.SelectedValue = "1";
                    }
                    else
                    {

                        RadioButtonList1.SelectedValue = "0";

                    }
                    lbl_cv.Value = user_uniq.cv;
                    lbl_economic_code.Value = user_uniq.economic_code;
                    lbl_email.Value = user_uniq.Email;
                    lbl_firstname.Value = user_uniq.Name;
                    lbl_national_code.Value = user_uniq.national_code;
                    Txt_lbl_phone.Text = user_uniq.Phone;
                    lbl_postcode.Value = user_uniq.Post_code;
                    //lbl_education.Value = user_uniq.Education;
                    lbl_Password.Text = user_uniq.Password;
                    lbl_ConfirmPassword.Text = user_uniq.Password;
                    SAVE_Button.Visible = true;
                    File_upload_img1.Visible = true;
                    var exist_user_data = Db.Staff_tbls.Where(c => c.Mobile == user.Single().Phone);
                    if (exist_user_data.Count() == 0)
                    {
                        lbl_complete_cv.Text = "";
                    }
                    else if (exist_user_data.Count() == 1)
                    {
                        lbl_complete_cv.Text = exist_user_data.Single().Description_activity;
                    }
                }
            }
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

        [Obsolete]
        protected void SAVE_Button_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();

            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                bool show_my_page = false;
                string folder = (user.Single().id).ToString();
                string directoryPath = Server.MapPath(string.Format("/img/user/{0}/", folder.Trim()));
                string address_file = string.Format("/img/user/{0}/", folder.Trim());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                bool personality;
                if (File_upload_img1.HasFile)
                {
                    //string fileName = Path.GetFileName(File_upload_img1.PostedFile.FileName);
                    //File_upload_img1.PostedFile.SaveAs(Server.MapPath("~" + address_file) + fileName);
                    string uploadFolder = Server.MapPath("~" + address_file);
                    File_upload_img1.SaveAs(uploadFolder + File_upload_img1.FileName);
                    ResizeSettings resizeCropSettings = new ResizeSettings("width=300&height=300&format=jpg&crop=auto");
                    string guid = System.Guid.NewGuid().ToString();
                    string fileName = Path.Combine(uploadFolder, guid);
                    fileName = ImageBuilder.Current.Build(uploadFolder + File_upload_img1.FileName, fileName, resizeCropSettings, false, true);

                    string filePath = Server.MapPath(string.Format("~" + address_file + "{0}", File_upload_img1.PostedFile.FileName));
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    if (user.Single().Pic == null) 
                    {
                       
                    }
                    else if (user.Single().Pic.Contains("/"))
                    {
                        string filePathlast = Server.MapPath("~" + string.Format(user.Single().Pic));
                        if (File.Exists(filePathlast))
                        {
                            File.Delete(filePathlast);
                        }
                    }

                    if (RadioButtonList1.SelectedValue == "1")
                    {
                        personality = true;
                    }
                    else
                    {
                        personality = false;
                    }

                    string phone;
                    if (Txt_lbl_phone.Text.StartsWith("09"))
                    {
                        phone = Txt_lbl_phone.Text;
                    }
                    else
                    {
                        phone = "0" + Txt_lbl_phone.Text;
                    }
                    var exist_user_data = Db.Staff_tbls.Where(c => c.Mobile == user.Single().Phone);
                    if (exist_user_data.Count() == 0)
                    {
                        Db.P_Insert_Staff_tbl(user.Single().Name, null, null, null, null, null, null, null, null, user.Single().Phone, null, null, null, null, null, null, null, null, lbl_complete_cv.Text);
                    }
                    else if (exist_user_data.Count() == 1)
                    {
                        Db.P_Update_Staff_tbl_Description_activity(user.Single().Phone, lbl_complete_cv.Text);
                    }
                    Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " اطلاعات پنل خود را ویرایش کرد.");
                    Db.P_Update_user_tbl(user.Single().id, lbl_firstname.Value, "", user.Single().Registration_date, lbl_Password.Text, lbl_email.Value, phone, lbl_address.Value, lbl_postcode.Value, lbl_about_us.Value, address_file + guid + ".jpg", Dateshamsi1400(), "", user.Single().Role, user.Single().Comfirm, user.Single().Access, "", "", lbl_national_code.Value, lbl_cv.Value, personality, lbl_economic_code.Value, show_my_page);
                }
                else
                {
                    if (RadioButtonList1.SelectedValue == "1")
                    {
                        personality = true;
                    }
                    else
                    {
                        personality = false;
                    }
                    string phone;
                    if (Txt_lbl_phone.Text.StartsWith("09"))
                    {
                        phone = Txt_lbl_phone.Text;
                    }
                    else
                    {
                        phone = "0" + Txt_lbl_phone.Text;
                    }
                    var exist_user_data = Db.Staff_tbls.Where(c => c.Mobile == user.Single().Phone);
                    if (exist_user_data.Count() == 0)
                    {
                        Db.P_Insert_Staff_tbl(user.Single().Name, null, null, null, null, null, null, null, null, user.Single().Phone, null, null, null, null, null, null, null, null, lbl_complete_cv.Text);
                    }
                    else if (exist_user_data.Count() == 1)
                    {
                        Db.P_Update_Staff_tbl_Description_activity(user.Single().Phone, lbl_complete_cv.Text);
                    }
                    Db.P_Update_user_tbl(user.Single().id, lbl_firstname.Value, "", user.Single().Registration_date, lbl_Password.Text, lbl_email.Value, phone, lbl_address.Value, lbl_postcode.Value, lbl_about_us.Value, user.Single().Pic, Dateshamsi1400(), "", user.Single().Role, user.Single().Comfirm, user.Single().Access, "", "", lbl_national_code.Value, lbl_cv.Value, personality, lbl_economic_code.Value, show_my_page);
                    Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " اطلاعات پنل خود را ویرایش کرد.");
                }



            }
            else if (Request.QueryString["ID"] != null)
            {
                var user = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Request.QueryString["ID"]));
                string folder = Request.QueryString["ID"].ToString();
                string directoryPath = Server.MapPath(string.Format("/img/user/{0}/", folder.Trim()));
                string address_file = string.Format("/img/user/{0}/", folder.Trim());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                bool personality;
                if (File_upload_img1.HasFile)
                {
                   
                    string uploadFolder = Server.MapPath("~" + address_file);
                    File_upload_img1.SaveAs(uploadFolder + File_upload_img1.FileName);                    
                    ResizeSettings resizeCropSettings = new ResizeSettings("width=300&height=300&format=jpg&crop=auto");
                    string guid = System.Guid.NewGuid().ToString();
                    string fileName = Path.Combine(uploadFolder, guid);                   
                    fileName = ImageBuilder.Current.Build(uploadFolder + File_upload_img1.FileName, fileName, resizeCropSettings, false, true);

                    string filePath = Server.MapPath(string.Format("~" + address_file + "{0}", File_upload_img1.PostedFile.FileName));
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    if (user.Single().Pic == null)
                    {

                    }
                    else if (user.Single().Pic.Contains("/"))
                    {
                        string filePathlast = Server.MapPath("~" + string.Format(user.Single().Pic));
                        if (File.Exists(filePathlast))
                        {
                            File.Delete(filePathlast);
                        }
                    }

                    if (RadioButtonList1.SelectedValue == "1")
                    {
                        personality = true;
                    }
                    else
                    {
                        personality = false;
                    }

                    string phone;
                    if (Txt_lbl_phone.Text.StartsWith("09"))
                    {
                        phone = Txt_lbl_phone.Text;
                    }
                    else
                    {
                        phone = "0" + Txt_lbl_phone.Text;
                    }
                    var exist_user_data = Db.Staff_tbls.Where(c => c.Mobile == user.Single().Phone);
                    if (exist_user_data.Count() == 0)
                    {
                        Db.P_Insert_Staff_tbl(user.Single().Name, null, null, null, null, null, null, null, null, user.Single().Phone, null, null, null, null, null, null, null, null, lbl_complete_cv.Text);
                    }
                    else if (exist_user_data.Count() == 1)
                    {
                        Db.P_Update_Staff_tbl_Description_activity(user.Single().Phone, lbl_complete_cv.Text);
                    }

                    Db.P_Insert_activity_tbl(Convert.ToInt32(Request.QueryString["ID"]), DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " اطلاعات پنل خود را ویرایش کرد.");
                    Db.P_Update_user_tbl(user.Single().id, lbl_firstname.Value, "", user.Single().Registration_date, lbl_Password.Text, lbl_email.Value, phone, lbl_address.Value, lbl_postcode.Value, lbl_about_us.Value, address_file + guid + ".jpg", Dateshamsi1400(), "", user.Single().Role, user.Single().Comfirm, user.Single().Access, "", "", lbl_national_code.Value, lbl_cv.Value, personality, lbl_economic_code.Value, user.Single().show_profile);
                }
                else
                {
                    if (RadioButtonList1.SelectedValue == "1")
                    {
                        personality = true;
                    }
                    else
                    {
                        personality = false;
                    }
                    string phone;
                    if (Txt_lbl_phone.Text.StartsWith("09"))
                    {
                        phone = Txt_lbl_phone.Text;
                    }
                    else
                    {
                        phone = "0" + Txt_lbl_phone.Text;
                    }
                    var exist_user_data = Db.Staff_tbls.Where(c => c.Mobile == user.Single().Phone);
                    if (exist_user_data.Count() == 0)
                    {
                        Db.P_Insert_Staff_tbl(user.Single().Name, null, null, null, null, null, null, null, null, user.Single().Phone, null, null, null, null, null, null, null, null, lbl_complete_cv.Text);
                    }
                    else if (exist_user_data.Count() == 1)
                    {
                        Db.P_Update_Staff_tbl_Description_activity(user.Single().Phone, lbl_complete_cv.Text);
                    }
                    Db.P_Update_user_tbl(user.Single().id, lbl_firstname.Value, "", user.Single().Registration_date, lbl_Password.Text, lbl_email.Value, phone, lbl_address.Value, lbl_postcode.Value, lbl_about_us.Value, user.Single().Pic, Dateshamsi1400(), "", user.Single().Role, user.Single().Comfirm, user.Single().Access, "", "", lbl_national_code.Value, lbl_cv.Value, personality, lbl_economic_code.Value, user.Single().show_profile);
                    Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " اطلاعات پنل خود را ویرایش کرد.");
                }
            }
            //string a;
            //a = lbl_firstname.Value;
            //Response.Redirect("profile.aspx?t=" + a);
        }

        protected void edu_edit_Click(object sender, EventArgs e)
        {
            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                Response.Redirect("user-edu");
            }
            else if (Session["mobile"] != null && Request.QueryString["ID"] != null)
            {
                Response.Redirect("user-edu?staffid="+ Request.QueryString["ID"].ToString());

            }

        }

        protected void skill_edit_Click(object sender, EventArgs e)
        {
            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                Response.Redirect("user-skill");
            }
            else if (Session["mobile"] != null && Request.QueryString["ID"] != null)
            {
                Response.Redirect("user-skill?staffid=" + Request.QueryString["ID"].ToString());

            }
        }

        protected void job_or_project_Click(object sender, EventArgs e)
        {
            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                Response.Redirect("user-project-or-job");
            }
            else if (Session["mobile"] != null && Request.QueryString["ID"] != null)
            {
                Response.Redirect("user-project-or-job?staffid=" + Request.QueryString["ID"].ToString());

            }
        }

        protected void slider_Click(object sender, EventArgs e)
        {
            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                Response.Redirect("user-image-project-or-job");
            }
            else if (Session["mobile"] != null && Request.QueryString["ID"] != null)
            {
                Response.Redirect("user-image-project-or-job?staffid=" + Request.QueryString["ID"].ToString());

            }
        }

        protected void practical_Click(object sender, EventArgs e)
        {
            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                Response.Redirect("user_experiment");
            }
            else if (Session["mobile"] != null && Request.QueryString["ID"] != null)
            {
                Response.Redirect("user_experiment?staffid=" + Request.QueryString["ID"].ToString());

            }
        }

        protected void cv_Click(object sender, EventArgs e)
        {
            if (Session["mobile"] != null && Request.QueryString["ID"] == null)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var user = db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                if (user.Count() == 1)
                {
                    Response.Redirect("https://nobincommerce.com/my-page?staff=" + user.Single().id.ToString());
                }
                
            }
            else if (Session["mobile"] != null && Request.QueryString["ID"] != null)
            {
                Response.Redirect("https://nobincommerce.com/my-page?staff=" + Request.QueryString["ID"].ToString());

            }
        }
    }
}