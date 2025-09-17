using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Configuration;
using System.Xml;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class edit_steel_store_text1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = Request.QueryString["T"].ToString();
            div_edit.Visible = true;
            title_edit.InnerHtml = "اطلاعات مورد نیاز" + page.ToString().Replace("-", " ") + " را وارد نمایید";
            main_title.InnerHtml = "ادیت متن صفحه  " + "(" + page.ToString().Replace("-", " ") + ")";
            //DataClasses1DataContext Db = new DataClasses1DataContext();
            //var title_page = Request.QueryString["T"].ToString().Replace("-", " ");
            //var page1 = Db.Text_for_store_steels.Where(c => c.name_page == title_page).Single();

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var page11 = Db.Text_for_store_steels.Where(c => c.id == Convert.ToInt32(Request.QueryString["ID"]));
            if (page11.Count() == 1)
            {
                txt_title.Text = page11.Single().title_page;
                txt_description.Text = page11.Single().P_description;
                txt_Canonical_url.Text = page11.Single().Canonical_url;
                if (page11.Single().full_text != null)
                {
                    txt_full_text.Text = page11.Single().full_text.Replace("../", "../../");
                }
                else
                {
                    txt_full_text.Text = "هیچ اطلاعاتی برای بارگذاری موجود نمی باشد.";
                }
                txt_pub_or_notpub.Text = page11.Single().publich_or_not;
                if (page11.Single().follow == true)
                {

                    txt_robots_f.SelectedItem.Text = "FOLLOW";
                }
                else
                {
                    txt_robots_f.SelectedItem.Text = "NOFOLLOW";
                }
                if (page11.Single().index_ == true)
                {

                    txt_robots_I.SelectedItem.Text = "INDEX";
                }
                else
                {
                    txt_robots_I.SelectedItem.Text = "NOINDEX";
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var title_page = Request.QueryString["T"].ToString().Replace("-", " ");
            var page = Db.Text_for_store_steels.Where(c => c.name_page == title_page).Single();
            string folder = (page.id).ToString();

            string directoryPath = Server.MapPath(string.Format("/img/page_steel_and_services/{0}/", folder.Trim()));
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);

            }
            string addressfile3= "";
            if (page.pic != "" || page.pic != null)
            {
                addressfile3 = page.pic;
            }
            if (FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".jpg"))
            {
                Stream st = FileUpload1.PostedFile.InputStream;
                System.Drawing.Image myImage = System.Drawing.Image.FromStream(st);
                 addressfile3 = "/img/page_steel_and_services/" + folder + "/" + txt_title.Text.ToString().Replace(" ", "-") + ".jpg";
                myImage.Save(Server.MapPath(addressfile3));
            }
           
            bool robotsfollow;
            bool robotsindex;
            string date_pub;
            if (txt_pub_or_notpub.SelectedItem.Text == "انتشار" && page.publich_or_not == "پیش نویس")
            {
                date_pub = DateTime.Now.ToShortDateString().ToString();
            }
            else if (page.date_publish == null || Convert.ToDateTime(page.date_publish) < Convert.ToDateTime("4/28/2021"))
            {
                date_pub = DateTime.Now.ToShortDateString().ToString();
            }
            else if (txt_pub_or_notpub.SelectedItem.Text == "پیش نویس")
            {
                date_pub = DateTime.Now.ToShortDateString().ToString();
            }
            else
            {
                date_pub = page.date_publish;
            }

            if (txt_robots_f.SelectedItem.Text == "FOLLOW")
            {
                robotsfollow = true;
            }
            else
            {
                robotsfollow = false;
            }
            if (txt_robots_I.SelectedItem.Text == "INDEX")
            {
                robotsindex = true;
            }
            else
            {
                robotsindex = false;
            }

            //Db.P_insert_Text_for_store_steel(null, null, txt_title.Text, txt_full_text.Text, addressfile3, DateTime.Now.ToShortDateString().ToString(), date_pub, txt_Canonical_url.Text, robotsfollow, robotsindex, page.name_page, txt_description.Text, txt_pub_or_notpub.Text);
            //Db.P_del_Text_for_store_steel(page.id, page.name_page);
            Db.P_Update_Text_for_store_steel(Convert.ToInt32(Request.QueryString["ID"]), null,Convert.ToInt32(page.id_group), txt_title.Text, txt_full_text.Text.Replace("../../", "../"), addressfile3, DateTime.Now.ToShortDateString().ToString(), date_pub, txt_Canonical_url.Text, robotsfollow, robotsindex, page.name_page, txt_description.Text, txt_pub_or_notpub.Text);
            var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());

            Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " ویرایش کرد.");

            Db.SubmitChanges();
            warning_message.Visible = false;
            success_message.Visible = true;
            success_Label.Visible = true;
            success_Label.Text = "اطلاعات " + title_page + " با موفقیت ثبت گردید.";

          

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit_steel_store_text_tag.aspx?T=" + Request.QueryString["T"] + "&ID=" + Request.QueryString["ID"]);

        }
        
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("/panel/maneger/text.aspx?T=" + Request.QueryString["T"]);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit_steel_store_text_group.aspx?T=" + Request.QueryString["T"] + "&ID=" + Request.QueryString["ID"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("list_pic_for_page.aspx?T=" + Request.QueryString["T"] + "&page_id=" + Request.QueryString["ID"]);
        }
    }
}