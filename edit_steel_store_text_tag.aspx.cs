using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class edit_steel_store_text_tag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //if (Session["tag"] != null)
            //{
            //    Session.Remove("tag");
            //    success_message.Visible = false;
            //    warning_message.Visible = false;
            //    //div_choose.Visible = false;
            //    //div_edit.Visible = false;
            //    //div_grouping.Visible = false;
            //    div_tags.Visible = true;
               
            //    var group = from a in Db.Tags_tbls
            //                join b in Db.Paper_tag_tbls on a.id equals b.idtag
            //                where (b.idtextforstore == Convert.ToInt32(Request.QueryString["ID"].ToString()))
            //                orderby (a.id)
            //                select new { a.tag, b.idtag };
            //    DataTable Tabletag = new DataTable();
            //    Tabletag.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
            //    Tabletag.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "tag" });
            //    int conter = 0;
            //    foreach (var element in group)
            //    {
            //        conter++;
            //        var row = Tabletag.NewRow();
            //        row["id"] = element.idtag.ToString();
            //        row["tag"] = element.tag.ToString();

            //        Tabletag.Rows.Add(row);
            //    }
            //    ListView_tag.DataSource = Tabletag;
            //    ListView_tag.DataBind();
            }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var tag = from a in Db.Tags_tbls
                      join b in Db.Paper_tag_tbls on a.id equals b.idtag
                      where (b.idtextforstore == Convert.ToInt32(Request.QueryString["ID"].ToString()))
                      orderby (a.id)
                      select new { a.tag, a.id };
            DataTable Tabletag = new DataTable();
            Tabletag.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
            Tabletag.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "tag" });
            int conter = 0;
            foreach (var element in tag)
            {
                conter++;
                var row = Tabletag.NewRow();
                row["id"] = element.id.ToString();
                row["tag"] = element.tag.ToString();

                Tabletag.Rows.Add(row);
            }
            ListView_tag.DataSource = Tabletag;
            ListView_tag.DataBind();
            var paper_ = Db.Text_for_store_steels.Where(c => c.id == Convert.ToInt32(Request.QueryString["ID"])).Single();
            main_title.InnerText = "افزودن کلمه کلیدی به : " + paper_.name_page;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();

            Db.P_Insert_Tags_tbl(txt_tags.Text);
            string page_id = Request.QueryString["ID"].ToString();

            var id_tag = Db.Tags_tbls.Where(c => c.tag == txt_tags.Text).OrderByDescending(c => c.id).Take(1);
            if (id_tag.Count() == 1)
            {
                Db.P_Insert_Paper_tag_tbl(null, id_tag.Single().id, Convert.ToInt32(page_id));
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());

                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک تگ  صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " اضافه کرد.");
                txt_tags.Text = "";
            }
            else
            {
                Db.P_del_Tags_tbl(id_tag.Single().id);
            }
           

        }

        protected void ListView_tag_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                ListViewItem row = ListView_tag.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                string idd = id2.Text;
                int id_tag = Convert.ToInt32(idd);
                DataClasses1DataContext Db = new DataClasses1DataContext();
                string page_id = Request.QueryString["ID"].ToString();

                Db.P_del_Tags_tbl(id_tag);
                Db.SubmitChanges();

                Db.P_del_Paper_tag_tbl(id_tag, Convert.ToInt32(page_id));
                Db.SubmitChanges();
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());

                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک تگ  صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " حذف کرد.");
            }
        }
    }


    
    }
