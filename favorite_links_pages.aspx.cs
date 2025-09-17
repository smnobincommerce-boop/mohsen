using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class favorite_links_pages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["ID"] != null)
            {
                panel_table.Visible = true;
                panel_pages.Visible = false;
                DataClasses1DataContext Db = new DataClasses1DataContext();
                var name_page = Db.exact_url_Tables.Where(c => c.id == Convert.ToInt32(Request.QueryString["ID"]));
                lbl_name_page.InnerHtml = name_page.Single().group_page.ToString();
                
                if (IsPostBack)
                {
                    if (success_message.Visible == true)
                    {
                        success_message.Visible = true;
                        warning_message.Visible = false;
                    }
                    else if (warning_message.Visible == true)
                    {
                        success_message.Visible = false;
                        warning_message.Visible = true;
                    }
                }
            }
            else
            {
                panel_table.Visible = false;
                panel_pages.Visible = true;
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            if (Request.QueryString["ID"] != null) 
            {
                var page11 = db.tbl_relation_page_to_weblog_news.Where(c => c.id_exact_url == Convert.ToInt32(Request.QueryString["ID"].ToString()));
                if (page11.Count() == 1)
                {
                    txt_group_news.SelectedItem.Text = page11.Single().main_group_news;
                    txt_group_weblog.SelectedItem.Text = page11.Single().main_group_weblog;
                }
                var table = db.recive_link_tbls.Where(c => c.id_exact_url == Convert.ToInt32(Request.QueryString["ID"].ToString()));
               
                if (table.Count() > 0)
                {
                    DataTable Tablegroup = new DataTable();
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name_page" });
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "link" });


                    foreach (var element in table)
                    {
                        var row = Tablegroup.NewRow();
                        row["id"] = element.id.ToString();
                        row["Name_page"] = element.title.ToString();
                        var page_link = db.exact_url_Tables.Where(c => c.id == element.id_second_recive_exact_url);
                        row["link"] = page_link.Single().exact_url;

                        Tablegroup.Rows.Add(row);
                    }
                    ListView_table_link.DataSource = Tablegroup;
                    ListView_table_link.DataBind();
                }

            }
                

            var First_pages = db.exact_url_Tables.Where(c => c.folder1 == "" && c.folder2 == "" && c.group_page != null);
            var Blogs = db.exact_url_Tables.Where(c => c.folder1 == "blog" && c.folder2 == "").OrderByDescending(c => c.id);
            var News = db.exact_url_Tables.Where(c => c.folder1 == "news" && c.folder2 == "").OrderByDescending(c => c.id);
            var rebars = db.exact_url_Tables.Where(c => c.folder1 == "steel-store" && c.folder2 == "rebar" && c.text != " کالا" && (c.text != ""));
            var bars = db.exact_url_Tables.Where(c => c.folder1 == "steel-store" && c.folder2 == "bar" && c.text != " کالا" && (c.text != ""));
            var sheets = db.exact_url_Tables.Where(c => c.folder1 == "steel-store" && c.folder2 == "sheet" && c.text != " کالا" && (c.text != ""));
            var beams = db.exact_url_Tables.Where(c => c.folder1 == "steel-store" && c.folder2 == "beam" && c.text != " کالا" && (c.text != ""));
            var pipes = db.exact_url_Tables.Where(c => c.folder1 == "steel-store" && c.folder2 == "pipe" && c.text != " کالا" && (c.text != ""));
            var profiles = db.exact_url_Tables.Where(c => c.folder1 == "steel-store" && c.folder2 == "profiles" && c.text != " کالا" && (c.text != ""));
            var Consulting = db.exact_url_Tables.Where(c => c.folder1 == "specialized-services" && c.folder2 == "Consulting");
            var design = db.exact_url_Tables.Where(c => c.folder1 == "specialized-services" && c.folder2 == "design");
            var executive = db.exact_url_Tables.Where(c => c.folder1 == "specialized-services" && c.folder2 == "executive");
            var legal = db.exact_url_Tables.Where(c => c.folder1 == "specialized-services" && c.folder2 == "legal");




            int conter = 0;
            if (First_pages.Count() > 0)
            {
                DataTable Table_First_pages = new DataTable();
                Table_First_pages.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_First_pages.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });

                foreach (var element in First_pages)
                {
                    conter++;
                    var row = Table_First_pages.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_First_pages.Rows.Add(row);
                }
                Repeater_first_pages.DataSource = Table_First_pages;
                Repeater_first_pages.DataBind();


            }

            if (Blogs.Count() > 0)
            {
                DataTable Table_blog = new DataTable();
                Table_blog.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_blog.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });

                conter = 0;
                foreach (var element in Blogs)
                {
                    conter++;
                    var row = Table_blog.NewRow();
                    if (element.text == "")
                    {
                        row["name_page"] = element.group_page.ToString();
                    }
                    else
                    {
                        row["name_page"] = element.text.ToString();
                    }

                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_blog.Rows.Add(row);
                }
                Repeater_blog.DataSource = Table_blog;
                Repeater_blog.DataBind();

            }

            if (News.Count() > 0)
            {
                DataTable Table_news = new DataTable();
                Table_news.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_news.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });

                conter = 0;
                foreach (var element in News)
                {
                    conter++;
                    var row = Table_news.NewRow();
                    if (element.text == "")
                    {
                        row["name_page"] = element.group_page.ToString();
                    }
                    else
                    {
                        row["name_page"] = element.text.ToString();
                    }

                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_news.Rows.Add(row);
                }
                Repeater_news.DataSource = Table_news;
                Repeater_news.DataBind();
            }

            if (rebars.Count() > 0)
            {
                DataTable Table_rebar = new DataTable();
                Table_rebar.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_rebar.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in rebars)
                {
                    conter++;
                    var row = Table_rebar.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_rebar.Rows.Add(row);
                }
                Repeater_milgerd.DataSource = Table_rebar;
                Repeater_milgerd.DataBind();
            }

            if (sheets.Count() > 0)
            {
                DataTable Table_sheet = new DataTable();
                Table_sheet.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_sheet.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in sheets)
                {
                    conter++;
                    var row = Table_sheet.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_sheet.Rows.Add(row);
                }
                Repeater_varagh.DataSource = Table_sheet;
                Repeater_varagh.DataBind();
            }

            if (profiles.Count() > 0)
            {
                DataTable Table_profiles = new DataTable();
                Table_profiles.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_profiles.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in profiles)
                {
                    conter++;
                    var row = Table_profiles.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_profiles.Rows.Add(row);
                }
                Repeater_profil.DataSource = Table_profiles;
                Repeater_profil.DataBind();
            }

            if (pipes.Count() > 0)
            {
                DataTable Table_pipe = new DataTable();
                Table_pipe.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_pipe.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in pipes)
                {
                    conter++;
                    var row = Table_pipe.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_pipe.Rows.Add(row);
                }
                Repeater_loole.DataSource = Table_pipe;
                Repeater_loole.DataBind();
            }

            if (bars.Count() > 0)
            {
                DataTable Table_bar = new DataTable();
                Table_bar.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_bar.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in bars)
                {
                    conter++;
                    var row = Table_bar.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_bar.Rows.Add(row);
                }
                Repeater_bar.DataSource = Table_bar;
                Repeater_bar.DataBind();
            }

            if (beams.Count() > 0)
            {
                DataTable Table_beam = new DataTable();
                Table_beam.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_beam.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in beams)
                {
                    conter++;
                    var row = Table_beam.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_beam.Rows.Add(row);
                }
                Repeater_tir.DataSource = Table_beam;
                Repeater_tir.DataBind();
            }

            if (Consulting.Count() > 0)
            {
                DataTable Table_Consulting = new DataTable();
                Table_Consulting.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_Consulting.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in Consulting)
                {
                    conter++;
                    var row = Table_Consulting.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_Consulting.Rows.Add(row);
                }
                Repeater_s_consult.DataSource = Table_Consulting;
                Repeater_s_consult.DataBind();
            }

            if (design.Count() > 0)
            {
                DataTable Table_design = new DataTable();
                Table_design.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_design.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in design)
                {
                    conter++;
                    var row = Table_design.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_design.Rows.Add(row);
                }
                Repeater_s_design.DataSource = Table_design;
                Repeater_s_design.DataBind();
            }

            if (executive.Count() > 0)
            {
                DataTable Table_executive = new DataTable();
                Table_executive.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_executive.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in executive)
                {
                    conter++;
                    var row = Table_executive.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_executive.Rows.Add(row);
                }
                Repeater_s_executive.DataSource = Table_executive;
                Repeater_s_executive.DataBind();
            }

            if (legal.Count() > 0)
            {
                DataTable Table_legal = new DataTable();
                Table_legal.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "url" });
                Table_legal.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "name_page" });


                conter = 0;
                foreach (var element in legal)
                {
                    conter++;
                    var row = Table_legal.NewRow();
                    row["name_page"] = element.group_page.ToString();
                    row["url"] = "favorite_links_pages?ID=" + element.id.ToString();
                    Table_legal.Rows.Add(row);
                }
                Repeater_s_legal.DataSource = Table_legal;
                Repeater_s_legal.DataBind();
            }


        }

        protected void ListView_table_link_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            ListViewItem row = ListView_table_link.Items[e.Item.DataItemIndex];
            Label id2 = (Label)row.FindControl("idLabel");
            string _id = id2.Text;
            int id_page = Convert.ToInt32(_id);
            Db.P_del_recive_link_tbl(id_page);
            var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
            Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " یک آیتم از جدول لینک دهی صفحات مرتبط " + Request.QueryString["ID"].ToString() +" توسط " + user.Single().Name + " حذف گردید.");
            success_message.Visible = true;
            warning_message.Visible = false;
            ListView_table_link.DataBind();
            success_Label.Text = "با موفقیت حذف شد.";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            string _ID = Request.QueryString["ID"].ToString();
            //string link = txt_link.Text.Replace("https://", "").Replace("http://", "").Replace("ImportXpress.ir/", "");
            var link = Db.exact_url_Tables.Where(c => c.exact_url == txt_link.Text.Replace(" ", ""));
            if (link.Count() == 1)
            {
                string name_show = "";
                if (link.Single().text == "")
                {
                    name_show = link.Single().group_page;
                }
                else
                {
                    name_show = link.Single().text;
                }
                Db.P_Insert_recive_link_tbl(Convert.ToInt32(_ID), name_show, link.Single().id, null, null, null, null);
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " یک آیتم به جدول لینک دهی صفحات مرتبط " + Request.QueryString["ID"].ToString() + " توسط " + user.Single().Name + " اضافه گردید.");
                warning_message.Visible = false;
                success_message.Visible = true;
                success_Label.Visible = true;
                success_Label.Text = "لینک " + " با موفقیت ثبت گردید.";
                txt_link.Text = "";
            }
            else
            {
                warning_message.Visible = true;
                success_message.Visible = false;
                warning_Label.Visible = true;
                warning_Label.Text = "لینک " + " با موفقیت ثبت نشد.";
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            DataClasses1DataContext Db = new DataClasses1DataContext();
            string _ID = Request.QueryString["ID"].ToString();
            var main_groups = Db.tbl_relation_page_to_weblog_news.Where(c => c.id_exact_url == Convert.ToInt32(_ID));
            if (main_groups.Count() == 0)
            {
                string title_main_group_news = "";
                string title_main_group_weblog = "";
                if (txt_group_news.Text == "بازار فولاد")
                {
                    title_main_group_news = "اخبار تحلیلی بازار فولاد";
                }
                else if (txt_group_news.Text == "بازار مسکن")
                {
                    title_main_group_news = "اخبار تحلیلی بازار مسکن";
                }
                else if (txt_group_news.Text == "حوزه فنی مهندسی")
                {
                    title_main_group_news = "اخبار تحلیلی حوزه فنی مهندسی";
                }
                if (txt_group_weblog.Text == "معماری")
                {
                    title_main_group_weblog = "آخرین مقالات معماری";
                }
                else if (txt_group_weblog.Text == "عمران")
                {
                    title_main_group_weblog = "آخرین مقالات عمران";
                }
                else if (txt_group_weblog.Text == "آهن آلات")
                {
                    title_main_group_weblog = "آخرین مقالات آهن آلات";
                }

                Db.P_Insert_tbl_relation_page_to_weblog_news(Convert.ToInt32(_ID), txt_group_weblog.Text, txt_group_news.Text, title_main_group_weblog, title_main_group_news);
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " یک آیتم به جدول دسته بندی صفحات مرتبط " + Request.QueryString["ID"].ToString() + " توسط " + user.Single().Name + " اضافه گردید.");
                warning_message.Visible = false;
                success_message.Visible = true;
                success_Label.Visible = true;
                success_Label.Text = " با موفقیت ثبت گردید.";
               
            }
            else if (main_groups.Count() == 1)
            {
                string title_main_group_news = "";
                string title_main_group_weblog = "";
                if (txt_group_news.Text == "بازار فولاد")
                {
                    title_main_group_news = "اخبار تحلیلی بازار فولاد";
                }
                else if (txt_group_news.Text == "بازار مسکن")
                {
                    title_main_group_news = "اخبار تحلیلی بازار مسکن";
                }
                else if (txt_group_news.Text == "حوزه فنی مهندسی")
                {
                    title_main_group_news = "اخبار تحلیلی حوزه فنی مهندسی";
                }
                if (txt_group_weblog.Text == "معماری")
                {
                    title_main_group_weblog = "آخرین مقالات معماری";
                }
                else if (txt_group_weblog.Text == "عمران")
                {
                    title_main_group_weblog = "آخرین مقالات عمران";
                }
                else if (txt_group_weblog.Text == "آهن آلات")
                {
                    title_main_group_weblog = "آخرین مقالات آهن آلات";
                }

                Db.P_UPDATE_tbl_relation_page_to_weblog_news(Convert.ToInt32(_ID), txt_group_weblog.Text, txt_group_news.Text, title_main_group_weblog, title_main_group_news);
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " یک آیتم به جدول دسته بندی صفحات مرتبط " + Request.QueryString["ID"].ToString() + " توسط " + user.Single().Name + " آپدیت گردید.");
                warning_message.Visible = false;
                success_message.Visible = true;
                success_Label.Visible = true;
                success_Label.Text = " با موفقیت آپدیت گردید.";
               
            }
            else
            {
                warning_message.Visible = true;
                success_message.Visible = false;
                warning_Label.Visible = true;
                warning_Label.Text =" با موفقیت ثبت نشد.";
            }
           
        }
    }
}