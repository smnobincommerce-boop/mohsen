using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025
{
    public partial class indexEn : System.Web.UI.Page
    {
        public static string canonical_url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            canonical_url = "https://nobincommerce.com/";
            Page.Title = "Nobin | Direct Import | Sourcing and Customs Clearance from Around the World";
            Page.MetaDescription = "Nobin, a specialized system for importing and sourcing goods, offers direct import services, customs clearance, and expert consultation. With Nobin, procure the goods you need from the most reputable global suppliers at the best prices and in the shortest time."; 
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var paper = Db.Paper_tbls.Where(c => c.delet_ == false && c.publish_or_not == "انتشار" && c.news == null).OrderBy(c => c.id);

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
                var row = MyDataTable.NewRow();
                row["id"] = element.id.ToString();
                row["subject_paper"] = element.subject_paper;
                row["p_description"] = element.p_description;
                row["img"] = element.img;
                row["alt_img"] = element.alt_img;

                MyDataTable.Rows.Add(row);
            }


            if (conter > 0)
            {
                section_Impora_total.Visible = true;
                //div Aval
                if (conter > 0)
                {
                    int i = 0;
                    div_Impora_1.Visible = true;
                    Impora_img1.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());

                    Impora_img1.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();
                    Impora_txt1.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    Impora_txtdez_1.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    a_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();

                }
                else
                {
                    div_Impora_1.Visible = false;
                }
                //div dovom
                if (conter > 1)
                {
                    int i = 1;
                    div_Impora_2.Visible = true;
                    Impora_img2.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    Impora_txt2.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    Impora_txtdez_2.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    b_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();

                    Impora_img2.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div_Impora_2.Visible = false;

                }
                //3
                if (conter > 2)
                {
                    int i = 2;
                    div_Impora_3.Visible = true;
                    Impora_img3.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    Impora_txt3.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    Impora_txtdez_3.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    c_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Impora_img3.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div_Impora_3.Visible = false;

                }
                //4
                if (conter > 3)
                {
                    int i = 3;
                    div_Impora_4.Visible = true;
                    Impora_img4.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    Impora_txt4.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    Impora_txtdez_4.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    d_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Impora_img4.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div_Impora_4.Visible = false;


                }
                //5
                if (conter > 4)
                {
                    int i = 4;
                    div1.Visible = true;
                    Img1.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    H1.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    P1.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    e_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Img1.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div1.Visible = false;


                }
                //6
                if (conter > 5)
                {
                    int i = 5;
                    div2.Visible = true;
                    Img2.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    H2.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    P2.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    f_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Img2.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();


                }
                else
                {
                    div2.Visible = false;


                }
                //7
                if (conter > 6)
                {
                    int i = 6;
                    div3.Visible = true;
                    Img3.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    H3.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    P3.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    g_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Img3.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();


                }
                else
                {
                    div3.Visible = false;

                }
                //8
                if (conter > 7)
                {
                    int i = 7;
                    div4.Visible = true;
                    Img4.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    H4.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    P4.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    h_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Img4.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div4.Visible = false;


                }
                //9
                if (conter > 8)
                {
                    int i = 8;
                    div5.Visible = true;
                    Img5.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    H5.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    P5.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    i_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();



                    Img5.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div5.Visible = false;


                }
                //10


                if (conter > 9)
                {
                    int i = 9;
                    div6.Visible = true;
                    Img6.Src = Page.ResolveUrl(MyDataTable.Rows[i].ItemArray[3].ToString());
                    H6.InnerText = MyDataTable.Rows[i].ItemArray[2].ToString();
                    P6.InnerText = MyDataTable.Rows[i].ItemArray[1].ToString();
                    j_.HRef = "~/blog/paper.aspx?I=" + MyDataTable.Rows[i].ItemArray[0].ToString();


                    Img6.Alt = MyDataTable.Rows[i].ItemArray[4].ToString();

                }
                else
                {
                    div6.Visible = false;


                }
            }

            else
            {
                section_Impora_total.Visible = false;
            }
        }
    }
}