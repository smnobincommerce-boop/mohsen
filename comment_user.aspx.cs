using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class comment_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
            }

        }
        private void BindListView()
        {
            if (Request.QueryString["IDPAPER"] == null && Request.QueryString["staffid"] == null) 
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                var ticket = from a in Db.User_tbls
                             join c in Db.Message_user_in_paper_tbls on a.id equals c.id_user
                             where (c.id_reply == null)
                             orderby c.id descending
                             select new { c.id, c.message, c.date, a.Name, c.comfirm };

                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "color" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "status" });

                int conter = 0;
                foreach (var element in ticket)
                {
                    conter++;
                    var row = MyDataTable.NewRow();

                    row["id"] = element.id.ToString();
                    if (element.message.Length < 50)
                    {
                        row["subject"] = element.message;
                    }
                    else
                    {
                        row["subject"] = element.message.Substring(0, 50);
                    }
                    row["date"] = element.date;
                    row["Name"] = element.Name;


                    if (element.comfirm == false)
                    {
                        row["color"] = "btn-success";
                    }
                    else
                    {
                        row["color"] = "";
                    }
                    if (element.comfirm == false)
                    {
                        row["status"] = "منتشر نشده";
                    }
                    else if (element.comfirm == true)
                    {
                        row["status"] = "منتشر شده";
                    }
                    else
                    {
                        row["status"] = "شرایط انتشار ندارد";
                    }
                    MyDataTable.Rows.Add(row);
                }
                ListView_ticket.DataSource = MyDataTable;
                ListView_ticket.DataBind();
            }
            else if(Request.QueryString["IDPAPER"] != null)
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                var ticket = from a in Db.User_tbls
                             join c in Db.Message_user_in_paper_tbls on a.id equals c.id_user
                             where (c.id_reply == null && c.id_paper == Convert.ToInt32(Request.QueryString["IDPAPER"]))
                             orderby c.id descending
                             select new { c.id, c.message, c.date, a.Name, c.comfirm };

                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "color" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "status" });

                int conter = 0;
                foreach (var element in ticket)
                {
                    conter++;
                    var row = MyDataTable.NewRow();

                    row["id"] = element.id.ToString();
                    if (element.message.Length < 50)
                    {
                        row["subject"] = element.message;
                    }
                    else
                    {
                        row["subject"] = element.message.Substring(0, 50);
                    }
                    row["date"] = element.date;
                    row["Name"] = element.Name;


                    if (element.comfirm == false)
                    {

                        row["color"] = "btn-success";

                    }
                    else
                    {

                        row["color"] = "";
                    }
                    if (element.comfirm == false)
                    {
                        row["status"] = "منتشر نشده";
                    }
                    else if (element.comfirm == true)
                    {
                        row["status"] = "منتشر شده";
                    }
                    else
                    {
                        row["status"] = "شرایط انتشار ندارد";
                    }
                    MyDataTable.Rows.Add(row);
                }

                ListView_ticket.DataSource = MyDataTable;
                ListView_ticket.DataBind();
            }
            else if (Request.QueryString["staffid"] != null)
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                var ticket = from a in Db.User_tbls
                             join c in Db.Message_user_in_paper_tbls on a.id equals c.id_user
                             where (c.id_reply == null && c.id_staff == Convert.ToInt32(Request.QueryString["staffid"]))
                             orderby c.id descending
                             select new { c.id, c.message, c.date, a.Name, c.comfirm };

                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "color" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "status" });

                int conter = 0;
                foreach (var element in ticket)
                {
                    conter++;
                    var row = MyDataTable.NewRow();

                    row["id"] = element.id.ToString();
                    if (element.message.Length < 50)
                    {
                        row["subject"] = element.message;
                    }
                    else
                    {
                        row["subject"] = element.message.Substring(0, 50);
                    }
                    row["date"] = element.date;
                    row["Name"] = element.Name;


                    if (element.comfirm == false)
                    {

                        row["color"] = "btn-success";

                    }
                    else
                    {

                        row["color"] = "";
                    }
                    if (element.comfirm == false)
                    {
                        row["status"] = "منتشر نشده";
                    }
                    else if (element.comfirm == true)
                    {
                        row["status"] = "منتشر شده";
                    }
                    else
                    {
                        row["status"] = "شرایط انتشار ندارد";
                    }
                    MyDataTable.Rows.Add(row);
                }

                ListView_ticket.DataSource = MyDataTable;
                ListView_ticket.DataBind();
            }


        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView_ticket.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }
        public static string Dateshamsi1400()
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
        public static String Dateshamsi(DateTime a)
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
    }
}