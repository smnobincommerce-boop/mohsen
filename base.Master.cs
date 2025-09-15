using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025
{
    public partial class _base : System.Web.UI.MasterPage
    {
        public static string text_tel = "";
        public static string number_tel = "";
        public static string t1 = "";
        public static string t2 = "";
        public static string t3 = "";
        public static string t4 = "";
        public static string t5 = "";
        public static string t6 = "";
        public static string t7 = "";
        public static string t8 = "";
        public static string t9 = "";
        public static string t10 = "";
        public static string t11 = "";
        public static string h1 = "";
        public static string h2 = "";
        public static string h3 = "";
        public static string h4 = "";
        public static string h5 = "";
        public static string h6 = "";
        public static string h7 = "";
        public static string h8 = "";
        public static string h9 = "";
        public static string h10 = "";
        public static string h11 = "";

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/result-search?search=" + txtsearch.Text.Replace(" ", "-"));

        }
        
       
        protected void Page_Load(object sender, EventArgs e)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            var tel = db.tel_contact_tbls.Where(c => c.active == true);
            if (tel.Count() == 1)
            {
                text_tel = tel.Single().tel_show_text;
                number_tel = "Tel:" + tel.Single().tel_contact_co;
            }
            else
            {
                text_tel = "تماس بگیرید";
                number_tel = "Tel:02166396090";
            }
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string rawurlx = HttpContext.Current.Request.RawUrl;
            string urlx = HttpContext.Current.Request.Url.AbsoluteUri;
            string pathx = HttpContext.Current.Request.Url.AbsolutePath;

            //var pagexx = ddb.exact_url_Tables.Where(c => c.exact_url == urlx || c.url_with_text == rawurlx);
            //if (urlx.StartsWith("http://www."))
            //{
            //    Response.Redirect(urlx.Replace("http://www.", "https://"));
            //}
            //else if (urlx.StartsWith("http://"))
            //{
            //    Response.Redirect(urlx.Replace("http://", "https://"));
            //}
            //else if (urlx.StartsWith("https://www."))
            //{
            //    Response.Redirect(urlx.Replace("https://www.", "https://"));
            //}


            DataClasses1DataContext Db = new DataClasses1DataContext();


            Db.P_Insert_url_tbl(urlx, Commonlyusedcodes.code(), Commonlyusedcodes.GetUserIPAddress(), DateTime.Now.Date, DateTime.Now.TimeOfDay);



            var paper = from c in db.Paper_tbls
                        where (c.delet_ == false && c.publish_or_not == "انتشار" && c.news == null)
                        orderby (c.id) descending
                        select new { c.id, c.subject_paper, c.p_description, c.img, c.alt_img };
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "id" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject_paper" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "p_description" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "img" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "alt_img" });

            int conter = 0;
            foreach (var element in paper)
            {
                conter++;
                if (conter < 3)
                {
                    var row = MyDataTable.NewRow();
                    row["id"] = element.id.ToString();
                    row["subject_paper"] = element.subject_paper;
                    row["p_description"] = element.p_description;
                    row["img"] = element.img;
                    row["alt_img"] = element.alt_img;
                    MyDataTable.Rows.Add(row);
                }

            }
            ListView1.DataSource = MyDataTable;
            ListView1.DataBind();

            var visit = db.url_tbls.Select(c => c.ip).Distinct();
            //var url_ = ddb.url_tbls;
            var url_day = db.url_tbls.Where(c => c.date == DateTime.Now.Date);
            var visit_day = url_day.Select(c => c.ip).Distinct();
            //lbl_alluniqevisit.Text = "بازدید کل یکتا: " + visit.Count().ToString();
            //lbl_allvisit.Text = "کل بازدید: " + url_.Count().ToString();
            lbl_lastdayvisit.Text = "بازدید امروز: " + url_day.Count().ToString();
            lbl_lastuniqevisitday.Text = "بازدید یکتا امروز: " + visit_day.Count().ToString();


            //var newsSS = from c in Db.Paper_tbls
            //             where ((c.main_group == "بازار مسکن" || c.main_group == "بازار فولاد" || c.main_group == "حوزه فنی مهندسی") && c.delet_ == false && c.publish_or_not == "انتشار" && c.news == true)
            //             orderby (c.id) descending
            //             select new { c.id, c.subject_paper, c.p_description, c.img, c.alt_img };
            //newsSS = newsSS.Take(10);

            //t11 = "لیست اخبار بازار فولاد و مسکن ایران";
            //h11 = "https://nobincommerce.com/news/listnews";

            //conter = 0;
            //foreach (var element in newsSS)
            //{
            //    conter++;
            //    if (conter == 1)
            //    {
            //        t1 = element.subject_paper.ToString();
            //        h1 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 2)
            //    {
            //        t2 = element.subject_paper.ToString();
            //        h2 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 3)
            //    {
            //        t3 = element.subject_paper.ToString();
            //        h3 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 4)
            //    {
            //        t4 = element.subject_paper.ToString();
            //        h4 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 5)
            //    {
            //        t5 = element.subject_paper.ToString();
            //        h5 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 6)
            //    {
            //        t6 = element.subject_paper.ToString();
            //        h6 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 7)
            //    {
            //        t7 = element.subject_paper.ToString();
            //        h7 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 8)
            //    {
            //        t8 = element.subject_paper.ToString();
            //        h8 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 9)
            //    {
            //        t9 = element.subject_paper.ToString();
            //        h9 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }
            //    if (conter == 10)
            //    {
            //        t10 = element.subject_paper.ToString();
            //        h10 = "https://nobincommerce.com/news/detailnews?I=" + element.id.ToString();
            //    }



            //}
        }
    }
}