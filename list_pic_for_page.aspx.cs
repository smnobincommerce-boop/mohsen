using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class list_pic_for_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = Request.QueryString["T"].ToString();        
            main_title.InnerHtml = "بارگذاری تصاویر اسلایدر  " + "(" + page.ToString().Replace("-", " ") + ")";


            if (Request.QueryString["correct"]!= null && Request.QueryString["correct"]=="1")
            {
                warning_message.Visible = false;
                success_message.Visible = true;
                success_Label.Visible = true;
                success_Label.Text = "تصویر " + " با موفقیت بارگذاری گردید.";
            }
            else if (Request.QueryString["correct"] != null && Request.QueryString["correct"] == "2")
            {
                success_message.Visible = true;
                warning_message.Visible = false;
                success_Label.Text = "با موفقیت حذف شد.";
            }
        }

        protected void Button_upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                Stream st = FileUpload1.PostedFile.InputStream;
                System.Drawing.Image myImage = System.Drawing.Image.FromStream(st);
                string addressfile = "/img/" + (DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day).ToString() + "/" + FileUpload1.FileName;
                string directoryPath = Server.MapPath(string.Format("/img/{0}/", (DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day).ToString().Trim()));
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);

                }
                myImage.Save(Server.MapPath(addressfile));
                Db.P_Insert_image__tbl(Convert.ToInt32(Request.QueryString["page_id"]), DateTime.Now.Date, DateTime.Now.TimeOfDay, addressfile, txt_alt.Text,null);
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());

                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " به صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " یک اسلایدر اضافه کرد.");
                warning_message.Visible = false;
                success_message.Visible = true;
                success_Label.Visible = true;
                success_Label.Text = "تصویر " + " با موفقیت بارگذاری گردید.";
                Response.Redirect("list_pic_for_page.aspx?T=" + Request.QueryString["T"] + "&page_id=" + Request.QueryString["page_id"]+"&correct=1");
                //FileUpload1.Visible = false;
                //Button4.Visible = false;
                //string url = HttpContext.Current.Request.Url.AbsoluteUri;
                //string path = HttpContext.Current.Request.Url.AbsolutePath;
                //TextBox1.Text = url.Replace(path, "") + addressfile;
                //address_file.Visible = true;
                //h_txt.InnerText = "عکس مورد نظر در سرور بارگذاری شد آدرس زیر را کپی نمایید و در قسمت دلخواه قرار دهید.";

            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "delet")
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                ListViewItem row = ListView1.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                string _id = id2.Text;
                int id_page = Convert.ToInt32(_id);
                Db.P_del_image__tbl(id_page);
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());

                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " یک اسلایدر حذف کرد.");
                Response.Redirect("list_pic_for_page.aspx?T=" + Request.QueryString["T"] + "&page_id=" + Request.QueryString["page_id"] + "&correct=2");

                
            }
        }
    }
}