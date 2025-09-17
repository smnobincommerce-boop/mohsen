using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class CRM_Customer : System.Web.UI.Page
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
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            DataClasses1DataContext Db = new DataClasses1DataContext();
            var milgerd = Db.Product_tables.Where(a => a.Name_product == "میلگرد" && (a.date_update == DateTime.Now.Date) && a.price != "تماس بگیرید").OrderBy(a => a.price);
            var profil = Db.Product_tables.Where(a => a.Name_product.Contains("پروفیل") && a.Mode == "ساختمانی" && (a.date_update == DateTime.Now.Date) && a.price != "تماس بگیرید").OrderBy(a => a.price);
            var varagh = Db.Product_tables.Where(a => a.Name_product.Contains("ورق سیاه") && (a.date_update == DateTime.Now.Date) && a.price != "تماس بگیرید").OrderBy(a => a.price);

            //میلگرد
            if (milgerd.Count() > 0)
            {
                Tdi1.InnerHtml = milgerd.Take(1).Single().Name_product.ToString();
                Tdi2.InnerHtml = milgerd.Take(1).Single().Dimensions.ToString();
                Tdi3.InnerHtml = milgerd.Take(1).Single().Brand.ToString();
                TextBox1.Text = milgerd.Take(1).Single().price.Replace(" ", "").Replace("تومان", "").ToString();

            }


            //پروفیل
            if (profil.Count() > 0)
            {
                Tdk1.InnerHtml = profil.Take(1).Single().Name_product.ToString();
                Tdk2.InnerHtml = profil.Take(1).Single().Dimensions.ToString();
                Tdk3.InnerHtml = profil.Take(1).Single().Brand.ToString();
                TextBox2.Text = profil.Take(1).Single().price.Replace(" ", "").Replace("تومان", "").ToString();
            }

            //ورق سیاه
            if (varagh.Count() > 0)
            {
                Tdj1.InnerHtml = varagh.Take(1).Single().Name_product.ToString();
                Tdj2.InnerHtml = varagh.Take(1).Single().Dimensions.ToString();
                Tdj3.InnerHtml = varagh.Take(1).Single().Brand.ToString();
                TextBox3.Text = varagh.Take(1).Single().price.Replace(" ", "").Replace("تومان", "").ToString();
            }
            else
            {
                itemPlaceholderContainer.Visible = false;
                main_title.InnerText = "ناقص";
                txt_matn.InnerText = "جداول را کامل آپدیت کنید.";
                div_choose.Visible = false;
            }

            //if (table.Count() > 0)
            //{

            //DataTable Tablegroup = new DataTable();
            //Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
            //Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "phone" });
            //Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "brand" });
            //    Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "price" });

            //    int conter = 0;
            //    foreach (var element in table)
            //    {
            //        conter++;
            //        var row = Tablegroup.NewRow();
            //        row["id"] = element.id.ToString();
            //        row["Name_product"] = element.Name_product.ToString();
            //        row["brand"] = element.Brand.ToString();                       
            //        row["price"] = element.price.Replace(" ","").Replace("تومان","").ToString();
            //        Tablegroup.Rows.Add(row);
            //    }






        }

        protected void send_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var crm = db.CRM_Customer_tbls.Where(c => c.phone != "").OrderBy(c => c.sex);
            var crm2 = db.CRM_Customer_tbls.Where(c => c.phone2 != "").OrderBy(c => c.sex);
            var crm3 = db.CRM_Customer_tbls.Where(c => c.phone3 != "").OrderBy(c => c.sex);
            string phonee = "";

            int conter = 0;
            DataTable Tablegroup = new DataTable();
            Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.Int32"), ColumnName = "id" });
            Tablegroup.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "phone" });

            foreach (var element in crm)
            {               

                if (element.phone.StartsWith("09"))
                {
                    phonee = element.phone;
                }
                else
                {
                    phonee = "0" + element.phone;
                }
                //phone = phone + "," + phonee;
                conter++;
                var row = Tablegroup.NewRow();
                row["id"] = conter;
                row["phone"] = phonee;
                Tablegroup.Rows.Add(row);
            }           
            foreach (var element in crm2)
            {               
                if (element.phone.StartsWith("09"))
                {
                    phonee = element.phone;
                }
                else
                {
                    phonee = "0" + element.phone;
                }
                //phone = phone + "," + phonee;
                conter++;
                var row = Tablegroup.NewRow();
                row["id"] = conter;
                row["phone"] = phonee;
                Tablegroup.Rows.Add(row);

            }
            foreach (var element in crm3)
            {
                if (element.phone.StartsWith("09"))
                {
                    phonee = element.phone;
                }
                else
                {
                    phonee = "0" + element.phone;
                }
                //phone = phone + "," + phonee;
                conter++;
                var row = Tablegroup.NewRow();
                row["id"] = conter;
                row["phone"] = phonee;
                Tablegroup.Rows.Add(row);
            }

            for (int i = 0; i < (((int)(conter / 100)) + 1); i++)
            {
                string phone = "";
                foreach (DataRow row in Tablegroup.Rows)
                {
                    if(Convert.ToInt32(row["id"])>(i*100) && Convert.ToInt32(row["id"]) < ((i + 1) * 100))
                    {
                        phone = phone + row["phone"].ToString() + ",";

                    }
                   
                }
                string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + phone + "&text=" + "نوبین\n" + Tdi1.InnerHtml + " " + TextBox1.Text + " ت\n" + Tdj1.InnerHtml + " " + TextBox3.Text + " ت\n" + Tdk1.InnerHtml + " " + TextBox2.Text + " ت" + "\n" + "02166396090" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                var st = resp.GetResponseStream();
                var sr = new System.IO.StreamReader(st, Encoding.UTF8);
                string _responseStr = sr.ReadToEnd();
                sr.Close();
                resp.Close();

            }


            success_message.Visible = true;
            warning_message.Visible = false;
            success_Label.Text = " آیتم های بروز رسانی شده ی جداول با موفقیت ارسال شد.";

        }

        protected void test_Click(object sender, EventArgs e)
        {
            string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09124950875" + "&text=" + "نوبین\n" + Tdi1.InnerHtml + " " + TextBox1.Text + " ت\n" + Tdj1.InnerHtml + " " + TextBox3.Text + " ت\n" + Tdk1.InnerHtml + " " + TextBox2.Text + " ت" + "\n" + "02166396090" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
            string url2 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09385999006" + "&text=" + "نوبین\n" + Tdi1.InnerHtml + " " + TextBox1.Text + " ت\n" + Tdj1.InnerHtml + " " + TextBox3.Text + " ت\n" + Tdk1.InnerHtml + " " + TextBox2.Text + " ت" + "\n" + "02166396090" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
            string url3 = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + "09122022897" + "&text=" + "نوبین\n" + Tdi1.InnerHtml + " " + TextBox1.Text + " ت\n" + Tdj1.InnerHtml + " " + TextBox3.Text + " ت\n" + Tdk1.InnerHtml + " " + TextBox2.Text + " ت" + "\n" + "02166396090" + "&signature=" + "60E0C35A-2F80-4F69-9B22-88C6A1854900";
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
            HttpWebRequest req3 = (HttpWebRequest)WebRequest.Create(url3);
            System.Net.WebResponse resp3 = req3.GetResponse();
            var st3 = resp3.GetResponseStream();
            var sr3 = new System.IO.StreamReader(st3, Encoding.UTF8);
            string _responseStr3 = sr3.ReadToEnd();
            sr3.Close();
            resp3.Close();
            success_message.Visible = true;
            warning_message.Visible = false;
            success_Label.Text = " آیتم های تست و بروز رسانی شده ی جداول با موفقیت ارسال شد.";
        }
    }
}