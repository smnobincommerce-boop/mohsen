using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class delete_data_from_table_price_steel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (success_message.Visible == true)
                {
                    success_message.Visible = true;
                    //    success_Label
                    warning_message.Visible = false;
                    //    warning_Label
                }
                else if (warning_message.Visible == true)
                {
                    success_message.Visible = false;
                    //    success_Label
                    warning_message.Visible = true;
                    //    warning_Label
                }
            }
            
           
        }
        protected void Btn_search(object sender, EventArgs e)
        {
            Response.Redirect("~/panel/maneger/delete_data_from_table_price_steel?idproduct=" + txtsearch.Text);
        }

        
        private static string Dateshamsi(DateTime a)
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
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();

            if (Request.QueryString["idproduct"] != null)
            {
               
                txt_list_price.InnerText = "";
                string id_product = Request.QueryString["idproduct"];
                var item_product = Db.Product_tables.Where(a => a.id == Convert.ToInt32(id_product));

                #region name product
                if (item_product.Single().Name_product == "نبشی")
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Brand + " " + " ضخامت " + item_product.Single().Thickness + " سایز " + item_product.Single().Dimensions + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product == "ناودانی")
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " سایز " + item_product.Single().Dimensions + " " + item_product.Single().Brand + " " + " شاخه " + item_product.Single().Length + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product == "سپری")
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + " سایز " + item_product.Single().Dimensions + " شاخه " + item_product.Single().Length + " " + "محل تحویل " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("هاش"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + " سایز " + item_product.Single().Dimensions + " " + item_product.Single().Brand + " شاخه 12 متری " + item_product.Single().Length + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("تیرآهن"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Brand + " " + " ضخامت " + item_product.Single().Thickness + " سایز " + item_product.Single().Dimensions + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("لوله مانیسمان"))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Brand + " " + " ضخامت " + item_product.Single().Thickness + " سایز " + item_product.Single().Dimensions + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("لوله داربستی"))
                {
                  
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Brand + " " + " ضخامت " + item_product.Single().Thickness + " سایز " + item_product.Single().Dimensions + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("لوله اسپیرال"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Brand + " سایز " + item_product.Single().Dimensions + " اینچ " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("پروفیل") && item_product.Single().Mode.Contains("ساختمانی"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Mode + " " + item_product.Single().Brand + " " + " سایز " + item_product.Single().Dimensions + " ضخامت " + item_product.Single().Thickness + " شاخه 6 متری " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("پروفیل") && item_product.Single().Mode.Contains("مبلی"))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Mode + " " + item_product.Single().Brand + " " + " سایز " + item_product.Single().Dimensions + " ضخامت " + item_product.Single().Thickness + " شاخه 6 متری " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("پروفیل زد"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Mode + " " + item_product.Single().Brand + " " + item_product.Single().Dimensions + " ضخامت " + item_product.Single().Thickness + " شاخه 6 متری " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("میلگرد") && ((item_product.Single().Brand.Contains("نیشابور") || item_product.Single().Brand.Contains("میانه") || item_product.Single().Brand.Contains("ذوب اهن اصفهان") || item_product.Single().Brand.Contains("پرشین") || item_product.Single().Brand.Contains("ابهر") || item_product.Single().Brand.Contains("امیر کبیر") || item_product.Single().Brand.Contains("فایکو") || item_product.Single().Brand.Contains("آناهیتا گیلان") || item_product.Single().Brand.Contains("راد همدان"))))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " آجدار " + item_product.Single().Dimensions + " " + item_product.Single().Brand + " " + item_product.Single().Mode + " " + item_product.Single().Length + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("میلگرد ") && ((item_product.Single().Brand.Contains("یزد") || item_product.Single().Brand.Contains("کویر کاشان"))))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Dimensions + " " + item_product.Single().Brand + " " + item_product.Single().Mode + " " + item_product.Single().Length + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("ورق آلومینیوم"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Thickness + " ▪️ " + " آلیاژ " + item_product.Single().Length + " در ابعاد " + item_product.Single().Dimensions + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("ورق سیاه"))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Thickness + " ▪️ " + item_product.Single().Length.Replace("متری", "").Replace("-", "رول") + " * " + item_product.Single().Width + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("ورق آجدار"))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Thickness + " ▪️ " + item_product.Single().Length.Replace("متری", "").Replace("-", "رول") + " * " + item_product.Single().Width + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("ورق گالوانیزه"))
                {
                   
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Thickness + " " + item_product.Single().Brand + " " + item_product.Single().Mode + " * " + item_product.Single().Width + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("ورق ضد سایش"))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Thickness + " ▪️ " + item_product.Single().Length.Replace("متری", "").Replace("-", "رول") + " * " + item_product.Single().Width + " " + item_product.Single().Place_deliver;
                }
                else if (item_product.Single().Name_product.Contains("ورق اسید شویی"))
                {
                    
                    txt_list_price.InnerText = item_product.Single().Name_product.ToString() + " " + item_product.Single().Thickness + " " + item_product.Single().Brand + " ▪️ " + item_product.Single().Mode + " ▪️ " + "عرض " + item_product.Single().Width + " mm " + item_product.Single().Place_deliver;
                }
                #endregion

                if (Db.Price_tbls.Where(a => a.id_product == Convert.ToInt32(id_product) && a.Price != "تماس بگیرید").Count() > 0)
                {
                    var table = Db.Price_tbls.Where(a => a.id_product == Convert.ToInt32(id_product) && a.Price != "تماس بگیرید").OrderByDescending(c => c.Date);
                    DataTable Tablegroup = new DataTable();
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date_product" });
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "price_product" });

                    foreach (var element in table)
                    {
                        var row = Tablegroup.NewRow();
                        row["id"] = element.id.ToString();
                        row["date_product"] = (Dateshamsi(Convert.ToDateTime(element.Date))).ToString();
                        row["price_product"] = element.Price.ToString();

                        Tablegroup.Rows.Add(row);
                    }
                    ListView1.DataSource = Tablegroup;
                    ListView1.DataBind();
                }
                else
                {
                    DataTable Tablegroup = new DataTable();
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date_product" });
                    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "price_product" });
                    ListView1.DataSource = Tablegroup;
                    ListView1.DataBind();
                }
            }
        }
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "delet")
            {
                DataClasses1DataContext Db = new DataClasses1DataContext();
                ListViewItem row = ListView1.Items[e.Item.DataItemIndex];
                Label id2 = (Label)row.FindControl("idLabel");
                //TextBox date_ = (TextBox)row.FindControl("date_productLabel");
                //TextBox price_ = (TextBox)row.FindControl("price_productLabel");
                Db.P_del_Price_tbl(Convert.ToInt32(id2.Text));
                var user = Db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                Db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " یک آیتم از جدول قیمت " + Request.QueryString["idproduct"] + " توسط " + user.Single().Name + " حذف گردید.");

                success_message.Visible = true;
                warning_message.Visible = false;
                success_Label.Text = "با موفقیت حذف شد.";

            }
        }
    }
}