using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class edit_steel_store_text_group : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            success_message.Visible = false;
            warning_message.Visible = false;
            //div_choose.Visible = false;
            //div_edit.Visible = false;
            div_grouping.Visible = true;
            //div_tags.Visible = false;

            

            //if (Session["group"] != null)
            //{
            //    Session.Remove("group");
            //    success_message.Visible = false;
            //    warning_message.Visible = false;
            //    //div_choose.Visible = false;
            //    //div_edit.Visible = false;
            //    div_grouping.Visible = true;
            //    //div_tags.Visible = false;

               
            //    var group = from a in Db.Grouping_tbls
            //                join b in Db.Paper_group_tbls on a.id equals b.idgrouping
            //                where (b.idtextforstore == Convert.ToInt32(Request.QueryString["ID"].ToString()))
            //                orderby (a.id)
            //                select new { a.Grouping, a.id, b.idgrouping };
            //    DataTable Tablegroup = new DataTable();
            //    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
            //    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "group" });
            //    int conter = 0;
            //    foreach (var element in group)
            //    {
            //        conter++;
            //        var row = Tablegroup.NewRow();
            //        row["id"] = element.idgrouping.ToString();
            //        row["group"] = element.Grouping.ToString();

            //        Tablegroup.Rows.Add(row);
            //    }
            //    ListView_grouping.DataSource = Tablegroup;
            //    ListView_grouping.DataBind();
            //}

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var group = from a in Db.Grouping_tbls
                        join b in Db.Paper_group_tbls on a.id equals b.idgrouping
                        where (b.idtextforstore == Convert.ToInt32(Request.QueryString["ID"].ToString()))
                        orderby (a.id)
                        select new { a.Grouping, a.id, b.idgrouping };
            DataTable Tablegroup = new DataTable();
            Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
            Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "group" });
            int conter = 0;
            foreach (var element in group)
            {
                conter++;
                var row = Tablegroup.NewRow();
                row["id"] = element.id.ToString();
                row["group"] = element.Grouping.ToString();

                Tablegroup.Rows.Add(row);
            }
            ListView_grouping.DataSource = Tablegroup;
            ListView_grouping.DataBind();
            var paper_ = Db.Text_for_store_steels.Where(c => c.id == Convert.ToInt32(Request.QueryString["ID"])).Single();
            main_title.InnerText = "افزودن دسته بندی به : " + paper_.name_page;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
            Db.P_Insert_Grouping_tbl2(txt_grouping.Text);
            string page_id = Request.QueryString["ID"].ToString();
            var id_grouping = Db.Grouping_tbls.Where(c => c.Grouping == txt_grouping.Text).OrderByDescending(c => c.id).Take(1);
            if (id_grouping.Count() == 1)
            {
                
                Db.P_Insert_Paper_group_tbl(id_grouping.Single().id, null, Convert.ToInt32(page_id));
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک گروه  صفحه ی "+ Request.QueryString["T"].Replace("-"," ")+" اضافه کرد.");
                txt_grouping.Text = "";
                Response.Redirect("edit_steel_store_text_group.aspx?T=" + Request.QueryString["T"] + "&ID=" + Request.QueryString["ID"]);

            }
            else
            {
                Db.P_del_Grouping_tbl(id_grouping.Single().id);
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک گروه  صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " حذف کرد.");
                Response.Redirect("edit_steel_store_text_group.aspx?T=" + Request.QueryString["T"] + "&ID=" + Request.QueryString["ID"]);

            }
            //var title_page = Request.QueryString["T"].ToString();
            //Response.Redirect("~/panel/edit_steel_store_text.aspx?T=" + title_page);
            //Session["group"] = title_page;


            //(from a in Db.Grouping_tbls
            //               where (a.Grouping == txt_grouping.Text)
            //               orderby descending 
            //               select

        }

        

        protected void ListView_grouping_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                ListViewItem row = ListView_grouping.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                string idd = id2.Text;
                int id_grouping = Convert.ToInt32(idd);
                DataClasses1DataContext Db = new DataClasses1DataContext();
                string page_id = Request.QueryString["ID"].ToString();

                Db.P_del_Grouping_tbl(id_grouping);
                Db.SubmitChanges();

                Db.P_del_Paper_group_tbl(id_grouping, Convert.ToInt32(page_id));
                Db.SubmitChanges();
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
               
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Single().Name + " یک گروه  صفحه ی " + Request.QueryString["T"].Replace("-", " ") + " حذف کرد.");

            }
        }
    }
}