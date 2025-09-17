using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class activity : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            if(Request.QueryString["id_user"]!= null)
            {
                var user = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Request.QueryString["id_user"]));
           
            if (user.Count() == 1)
            {
                var activity = Db.activity_tbls.Where(c => c.id_user == user.Single().id).OrderByDescending(c => c.id);

                DataTable MyDataTable = new DataTable();
                  MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "time" });
                MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "des_activity" });

                int conter = 201;
                foreach (var element in activity)
                {
                    conter--;
                    if (conter > 0)
                    {
                        var row = MyDataTable.NewRow();
                        row["date"] = element.date;
                        row["time"] = element.time;
                        row["des_activity"] = element.des_activity;

                        MyDataTable.Rows.Add(row);
                    }

                }

                Repeater1.DataSource = MyDataTable;
                Repeater1.DataBind();
            }
            }
        }

        protected string Dateshamsi(DateTime a)
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
                    int yy2 = yy + 1399;
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