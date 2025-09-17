using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class chart_view_page : System.Web.UI.Page
    {
        #region
        public static string y_1 = null;
        public static string y_2 = null;
        public static string y_3 = null;
        public static string y_4 = null;
        public static string y_5 = null;
        public static string y_6 = null;
        public static string y_7 = null;
        public static string y_8 = null;
        public static string y_9 = null;
        public static string y_10 = null;
        public static string y_11 = null;
        public static string y_12 = null;
        public static string y_13 = null;
        public static string y_14 = null;
        public static string y_15 = null;
        public static string y_16 = null;
        public static string y_17 = null;
        public static string y_18 = null;
        public static string y_19 = null;
        public static string y_20 = null;
        public static string y_21 = null;
        public static string y_22 = null;
        public static string y_23 = null;
        public static string y_24 = null;
        public static string y_25 = null;
        public static string y_26 = null;
        public static string y_27 = null;
        public static string y_28 = null;
        public static string y_29 = null;
        public static string y_30 = null;
        
        public static string x_1 = null;
        public static string x_2 = null;
        public static string x_3 = null;
        public static string x_4 = null;
        public static string x_5 = null;
        public static string x_6 = null;
        public static string x_7 = null;
        public static string x_8 = null;
        public static string x_9 = null;
        public static string x_10 = null;
        public static string x_11 = null;
        public static string x_12 = null;
        public static string x_13 = null;
        public static string x_14 = null;
        public static string x_15 = null;
        public static string x_16 = null;
        public static string x_17 = null;
        public static string x_18 = null;
        public static string x_19 = null;
        public static string x_20 = null;
        public static string x_21 = null;
        public static string x_22 = null;
        public static string x_23 = null;
        public static string x_24 = null;
        public static string x_25 = null;
        public static string x_26 = null;
        public static string x_27 = null;
        public static string x_28 = null;
        public static string x_29 = null;
        public static string x_30 = null;

        public static string z_1 = null;
        public static string z_2 = null;
        public static string z_3 = null;
        public static string z_4 = null;
        public static string z_5 = null;
        public static string z_6 = null;
        public static string z_7 = null;
        public static string z_8 = null;
        public static string z_9 = null;
        public static string z_10 = null;
        public static string z_11 = null;
        public static string z_12 = null;
        public static string z_13 = null;
        public static string z_14 = null;
        public static string z_15 = null;
        public static string z_16 = null;
        public static string z_17 = null;
        public static string z_18 = null;
        public static string z_19 = null;
        public static string z_20 = null;
        public static string z_21 = null;
        public static string z_22 = null;
        public static string z_23 = null;
        public static string z_24 = null;
        public static string z_25 = null;
        public static string z_26 = null;
        public static string z_27 = null;
        public static string z_28 = null;
        public static string z_29 = null;
        public static string z_30 = null;

        #endregion
        #region x,y,z
        public static string y1 = null;
        public static string y2 = null;
        public static string y3 = null;
        public static string y4 = null;
        public static string y5 = null;
        public static string y6 = null;
        public static string y7 = null;
        public static string y8 = null;
        public static string y9 = null;
        public static string y10 = null;
        public static string y11 = null;
        public static string y12 = null;
        public static string y13 = null;
        public static string y14 = null;
        public static string y15 = null;
        public static string y16 = null;
        public static string y17 = null;
        public static string y18 = null;
        public static string y19 = null;
        public static string y20 = null;
        public static string y21 = null;
        public static string y22 = null;
        public static string y23 = null;
        public static string y24 = null;
        public static string y25 = null;
        public static string y26 = null;
        public static string y27 = null;
        public static string y28 = null;
        public static string y29 = null;
        public static string y30 = null;
        public static string y31 = null;
        public static string y32 = null;
        public static string y33 = null;
        public static string y34 = null;
        public static string y35 = null;
        public static string y36 = null;
        public static string y37 = null;
        public static string y38 = null;
        public static string y39 = null;
        public static string y40 = null;
        public static string y41 = null;
        public static string y42 = null;
        public static string y43 = null;
        public static string y44 = null;
        public static string y45 = null;
        public static string y46 = null;
        public static string y47 = null;
        public static string y48 = null;
        public static string y49 = null;
        public static string y50 = null;
        public static string y51 = null;
        public static string y52 = null;
        public static string y53 = null;
        public static string y54 = null;
        public static string y55 = null;
        public static string y56 = null;
        public static string y57 = null;
        public static string y58 = null;
        public static string y59 = null;
        public static string y60 = null;
        public static string y61 = null;
        public static string y62 = null;
        public static string y63 = null;
        public static string y64 = null;
        public static string y65 = null;
        public static string y66 = null;
        public static string y67 = null;
        public static string y68 = null;
        public static string y69 = null;
        public static string y70 = null;
        public static string y71 = null;
        public static string y72 = null;
        public static string y73 = null;
        public static string y74 = null;
        public static string y75 = null;
        public static string y76 = null;
        public static string y77 = null;
        public static string y78 = null;
        public static string y79 = null;
        public static string y80 = null;
        public static string y81 = null;
        public static string y82 = null;
        public static string y83 = null;
        public static string y84 = null;
        public static string y85 = null;
        public static string y86 = null;
        public static string y87 = null;
        public static string y88 = null;
        public static string y89 = null;
        public static string y90 = null;
        public static string x1 = null;
        public static string x2 = null;
        public static string x3 = null;
        public static string x4 = null;
        public static string x5 = null;
        public static string x6 = null;
        public static string x7 = null;
        public static string x8 = null;
        public static string x9 = null;
        public static string x10 = null;
        public static string x11 = null;
        public static string x12 = null;
        public static string x13 = null;
        public static string x14 = null;
        public static string x15 = null;
        public static string x16 = null;
        public static string x17 = null;
        public static string x18 = null;
        public static string x19 = null;
        public static string x20 = null;
        public static string x21 = null;
        public static string x22 = null;
        public static string x23 = null;
        public static string x24 = null;
        public static string x25 = null;
        public static string x26 = null;
        public static string x27 = null;
        public static string x28 = null;
        public static string x29 = null;
        public static string x30 = null;
        public static string x31 = null;
        public static string x32 = null;
        public static string x33 = null;
        public static string x34 = null;
        public static string x35 = null;
        public static string x36 = null;
        public static string x37 = null;
        public static string x38 = null;
        public static string x39 = null;
        public static string x40 = null;
        public static string x41 = null;
        public static string x42 = null;
        public static string x43 = null;
        public static string x44 = null;
        public static string x45 = null;
        public static string x46 = null;
        public static string x47 = null;
        public static string x48 = null;
        public static string x49 = null;
        public static string x50 = null;
        public static string x51 = null;
        public static string x52 = null;
        public static string x53 = null;
        public static string x54 = null;
        public static string x55 = null;
        public static string x56 = null;
        public static string x57 = null;
        public static string x58 = null;
        public static string x59 = null;
        public static string x60 = null;
        public static string x61 = null;
        public static string x62 = null;
        public static string x63 = null;
        public static string x64 = null;
        public static string x65 = null;
        public static string x66 = null;
        public static string x67 = null;
        public static string x68 = null;
        public static string x69 = null;
        public static string x70 = null;
        public static string x71 = null;
        public static string x72 = null;
        public static string x73 = null;
        public static string x74 = null;
        public static string x75 = null;
        public static string x76 = null;
        public static string x77 = null;
        public static string x78 = null;
        public static string x79 = null;
        public static string x80 = null;
        public static string x81 = null;
        public static string x82 = null;
        public static string x83 = null;
        public static string x84 = null;
        public static string x85 = null;
        public static string x86 = null;
        public static string x87 = null;
        public static string x88 = null;
        public static string x89 = null;
        public static string x90 = null;
        public static string z1 = null;
        public static string z2 = null;
        public static string z3 = null;
        public static string z4 = null;
        public static string z5 = null;
        public static string z6 = null;
        public static string z7 = null;
        public static string z8 = null;
        public static string z9 = null;
        public static string z10 = null;
        public static string z11 = null;
        public static string z12 = null;
        public static string z13 = null;
        public static string z14 = null;
        public static string z15 = null;
        public static string z16 = null;
        public static string z17 = null;
        public static string z18 = null;
        public static string z19 = null;
        public static string z20 = null;
        public static string z21 = null;
        public static string z22 = null;
        public static string z23 = null;
        public static string z24 = null;
        public static string z25 = null;
        public static string z26 = null;
        public static string z27 = null;
        public static string z28 = null;
        public static string z29 = null;
        public static string z30 = null;
        public static string z31 = null;
        public static string z32 = null;
        public static string z33 = null;
        public static string z34 = null;
        public static string z35 = null;
        public static string z36 = null;
        public static string z37 = null;
        public static string z38 = null;
        public static string z39 = null;
        public static string z40 = null;
        public static string z41 = null;
        public static string z42 = null;
        public static string z43 = null;
        public static string z44 = null;
        public static string z45 = null;
        public static string z46 = null;
        public static string z47 = null;
        public static string z48 = null;
        public static string z49 = null;
        public static string z50 = null;
        public static string z51 = null;
        public static string z52 = null;
        public static string z53 = null;
        public static string z54 = null;
        public static string z55 = null;
        public static string z56 = null;
        public static string z57 = null;
        public static string z58 = null;
        public static string z59 = null;
        public static string z60 = null;
        public static string z61 = null;
        public static string z62 = null;
        public static string z63 = null;
        public static string z64 = null;
        public static string z65 = null;
        public static string z66 = null;
        public static string z67 = null;
        public static string z68 = null;
        public static string z69 = null;
        public static string z70 = null;
        public static string z71 = null;
        public static string z72 = null;
        public static string z73 = null;
        public static string z74 = null;
        public static string z75 = null;
        public static string z76 = null;
        public static string z77 = null;
        public static string z78 = null;
        public static string z79 = null;
        public static string z80 = null;
        public static string z81 = null;
        public static string z82 = null;
        public static string z83 = null;
        public static string z84 = null;
        public static string z85 = null;
        public static string z86 = null;
        public static string z87 = null;
        public static string z88 = null;
        public static string z89 = null;
        public static string z90 = null;

        public static string maxy = null;
        public static string miny = null;
        #endregion
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

        protected void Page_Load(object sender, EventArgs e)
        {
            maintitle.InnerHtml = "";
            mainDescription.InnerHtml = "";
            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                #region x,y,z
                y_1 = null;
                y_2 = null;
         y_3 = null;
         y_4 = null;
         y_5 = null;
         y_6 = null;
         y_7 = null;
         y_8 = null;
         y_9 = null;
         y_10 = null;
         y_11 = null;
         y_12 = null;
         y_13 = null;
         y_14 = null;
         y_15 = null;
         y_16 = null;
         y_17 = null;
         y_18 = null;
         y_19 = null;
         y_20 = null;
         y_21 = null;
         y_22 = null;
         y_23 = null;
         y_24 = null;
         y_25 = null;
         y_26 = null;
         y_27 = null;
         y_28 = null;
         y_29 = null;
         y_30 = null;

         x_1 = null;
         x_2 = null;
         x_3 = null;
         x_4 = null;
         x_5 = null;
         x_6 = null;
         x_7 = null;
         x_8 = null;
         x_9 = null;
         x_10 = null;
         x_11 = null;
         x_12 = null;
         x_13 = null;
         x_14 = null;
         x_15 = null;
         x_16 = null;
         x_17 = null;
         x_18 = null;
         x_19 = null;
         x_20 = null;
         x_21 = null;
         x_22 = null;
         x_23 = null;
         x_24 = null;
         x_25 = null;
         x_26 = null;
         x_27 = null;
         x_28 = null;
         x_29 = null;
         x_30 = null;

         z_1 = null;
         z_2 = null;
         z_3 = null;
         z_4 = null;
         z_5 = null;
         z_6 = null;
         z_7 = null;
         z_8 = null;
         z_9 = null;
         z_10 = null;
         z_11 = null;
         z_12 = null;
         z_13 = null;
         z_14 = null;
         z_15 = null;
         z_16 = null;
         z_17 = null;
         z_18 = null;
         z_19 = null;
         z_20 = null;
         z_21 = null;
         z_22 = null;
         z_23 = null;
         z_24 = null;
         z_25 = null;
         z_26 = null;
         z_27 = null;
         z_28 = null;
         z_29 = null;
         z_30 = null;
                #endregion
                #region x,y,z
         y1 = null;
         y2 = null;
         y3 = null;
         y4 = null;
         y5 = null;
         y6 = null;
         y7 = null;
         y8 = null;
         y9 = null;
         y10 = null;
         y11 = null;
         y12 = null;
         y13 = null;
         y14 = null;
         y15 = null;
         y16 = null;
         y17 = null;
         y18 = null;
         y19 = null;
         y20 = null;
         y21 = null;
         y22 = null;
         y23 = null;
         y24 = null;
         y25 = null;
         y26 = null;
         y27 = null;
         y28 = null;
         y29 = null;
         y30 = null;
         y31 = null;
         y32 = null;
         y33 = null;
         y34 = null;
         y35 = null;
         y36 = null;
         y37 = null;
         y38 = null;
         y39 = null;
         y40 = null;
         y41 = null;
         y42 = null;
         y43 = null;
         y44 = null;
         y45 = null;
         y46 = null;
         y47 = null;
         y48 = null;
         y49 = null;
         y50 = null;
         y51 = null;
         y52 = null;
         y53 = null;
         y54 = null;
         y55 = null;
         y56 = null;
         y57 = null;
         y58 = null;
         y59 = null;
         y60 = null;
         y61 = null;
         y62 = null;
         y63 = null;
         y64 = null;
         y65 = null;
         y66 = null;
         y67 = null;
         y68 = null;
         y69 = null;
         y70 = null;
         y71 = null;
         y72 = null;
         y73 = null;
         y74 = null;
         y75 = null;
         y76 = null;
         y77 = null;
         y78 = null;
         y79 = null;
         y80 = null;
         y81 = null;
         y82 = null;
         y83 = null;
         y84 = null;
         y85 = null;
         y86 = null;
         y87 = null;
         y88 = null;
         y89 = null;
         y90 = null;
         x1 = null;
         x2 = null;
         x3 = null;
         x4 = null;
         x5 = null;
         x6 = null;
         x7 = null;
         x8 = null;
         x9 = null;
         x10 = null;
         x11 = null;
         x12 = null;
         x13 = null;
         x14 = null;
         x15 = null;
         x16 = null;
         x17 = null;
         x18 = null;
         x19 = null;
         x20 = null;
         x21 = null;
         x22 = null;
         x23 = null;
         x24 = null;
         x25 = null;
         x26 = null;
         x27 = null;
         x28 = null;
         x29 = null;
         x30 = null;
         x31 = null;
         x32 = null;
         x33 = null;
         x34 = null;
         x35 = null;
         x36 = null;
         x37 = null;
         x38 = null;
         x39 = null;
         x40 = null;
         x41 = null;
         x42 = null;
         x43 = null;
         x44 = null;
         x45 = null;
         x46 = null;
         x47 = null;
         x48 = null;
         x49 = null;
         x50 = null;
         x51 = null;
         x52 = null;
         x53 = null;
         x54 = null;
         x55 = null;
         x56 = null;
         x57 = null;
         x58 = null;
         x59 = null;
         x60 = null;
         x61 = null;
         x62 = null;
         x63 = null;
         x64 = null;
         x65 = null;
         x66 = null;
         x67 = null;
         x68 = null;
         x69 = null;
         x70 = null;
         x71 = null;
         x72 = null;
         x73 = null;
         x74 = null;
         x75 = null;
         x76 = null;
         x77 = null;
         x78 = null;
         x79 = null;
         x80 = null;
         x81 = null;
         x82 = null;
         x83 = null;
         x84 = null;
         x85 = null;
         x86 = null;
         x87 = null;
         x88 = null;
         x89 = null;
         x90 = null;
         z1 = null;
         z2 = null;
         z3 = null;
         z4 = null;
         z5 = null;
         z6 = null;
         z7 = null;
         z8 = null;
         z9 = null;
         z10 = null;
         z11 = null;
         z12 = null;
         z13 = null;
         z14 = null;
         z15 = null;
         z16 = null;
         z17 = null;
         z18 = null;
         z19 = null;
         z20 = null;
         z21 = null;
         z22 = null;
         z23 = null;
         z24 = null;
         z25 = null;
         z26 = null;
         z27 = null;
         z28 = null;
         z29 = null;
         z30 = null;
         z31 = null;
         z32 = null;
         z33 = null;
         z34 = null;
         z35 = null;
         z36 = null;
         z37 = null;
         z38 = null;
         z39 = null;
         z40 = null;
         z41 = null;
         z42 = null;
         z43 = null;
         z44 = null;
         z45 = null;
         z46 = null;
         z47 = null;
         z48 = null;
         z49 = null;
         z50 = null;
         z51 = null;
         z52 = null;
         z53 = null;
         z54 = null;
         z55 = null;
         z56 = null;
         z57 = null;
         z58 = null;
         z59 = null;
         z60 = null;
         z61 = null;
         z62 = null;
         z63 = null;
         z64 = null;
         z65 = null;
         z66 = null;
         z67 = null;
         z68 = null;
         z69 = null;
         z70 = null;
         z71 = null;
         z72 = null;
         z73 = null;
         z74 = null;
         z75 = null;
         z76 = null;
         z77 = null;
         z78 = null;
         z79 = null;
         z80 = null;
         z81 = null;
         z82 = null;
         z83 = null;
         z84 = null;
         z85 = null;
         z86 = null;
         z87 = null;
         z88 = null;
         z89 = null;
         z90 = null;

         maxy = null;
         miny = null;
        #endregion

        DataClasses1DataContext db = new DataClasses1DataContext();
                string ID_ = Request.QueryString["ID"];
                if (ID_ == "0")
                {
                    Button1.Visible = false;
                    Update_all.Visible = true;
                    maintitle.InnerHtml = "بازدید کل وب سایت";
                    mainDescription.InnerHtml = "";
                    mainurl.InnerText = "";
                    //var visit = db.record_visitors_tbls.Select(c => c.ip).Distinct();
                    //var url_ = db.record_visitors_tbls;
                    //var url_day = db.record_visitors_tbls.Where(c => c.date == DateTime.Now.Date);
                    //var visit_day = db.record_visitors_tbls.Where(c => c.date == DateTime.Now.Date).Select(c => c.ip).Distinct();
                    //lbl_alluniqevisit.Text = "بازدید کل یکتا: " + visit.Count().ToString();
                    //lbl_allvisit.Text = "کل بازدید: " + url_.Count().ToString();
                    //lbl_lastdayvisit.Text = "بازدید امروز: " + url_day.Count().ToString();
                    //lbl_lastuniqevisitday.Text = "بازدید یکتا امروز: " + visit_day.Count().ToString();
                    //var exact_url_visit = db.exact_url_Tables.Where(c => c.id == Convert.ToInt32(ID_));
                    //string folder1 = Request.QueryString["f1"];
                    //string folder2 = Request.QueryString["f2"];
                    //string id_record = Request.QueryString["id"];
                    //string name_page = "";

                   

                      
                        var view_exact_url_visit = db.View_exact_page_Tables.Where(c => c.id_exact_url == 0 && c.number_view != "0");

                        int all_view = 0; int all_uniq_view = 0;
                        int all_view_month = 0; int all_uniq_view_month = 0;
                        //int all_view_month_av = 0; int all_uniq_view_month_av = 0;
                        int all_view_3month = 0; int all_uniq_view_3month = 0;
                        //int all_view_3month_av = 0; int all_uniq_view_3month_av = 0;

                        foreach (var element in view_exact_url_visit)
                        {
                            all_uniq_view = all_uniq_view + Convert.ToInt32(element.number_uniq_view);

                            all_view = all_view + Convert.ToInt32(element.number_view);
                        }
                        lbl_user_all.Text = "بازدید کاربر کل: " + all_uniq_view.ToString();
                        lbl_user_all90.Text = "بازدید کاربر کل: " + all_uniq_view.ToString();
                        Lbl_view_all.Text = "بازدید کل: " + all_view.ToString();
                        Lbl_view_all90.Text = "بازدید کل: " + all_view.ToString();
                        //
                        int conter_ = 0;
                        if (view_exact_url_visit.Count() > 30)
                        {
                            var view_exact_url_visit_30 = view_exact_url_visit.OrderByDescending(c => c.date).Take(30);
                            view_exact_url_visit_30 = view_exact_url_visit_30.OrderBy(c => c.date);
                            conter_ = 0;
                            foreach (var element in view_exact_url_visit_30)
                            {
                                conter_++;
                                if (conter_ == 1 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_1 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_1 = element.number_uniq_view.ToString();
                                    z_1 = element.number_view.ToString();
                                }
                                if (conter_ == 2 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_2 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_2 = element.number_uniq_view.ToString();
                                    z_2 = element.number_view.ToString();
                                }
                                if (conter_ == 3 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_3 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_3 = element.number_uniq_view.ToString();
                                    z_3 = element.number_view.ToString();
                                }
                                if (conter_ == 4 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_4 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_4 = element.number_uniq_view.ToString();
                                    z_4 = element.number_view.ToString();
                                }
                                if (conter_ == 5 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_5 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_5 = element.number_uniq_view.ToString();
                                    z_5 = element.number_view.ToString();
                                }
                                if (conter_ == 6 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_6 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_6 = element.number_uniq_view.ToString();
                                    z_6 = element.number_view.ToString();
                                }
                                if (conter_ == 7 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_7 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_7 = element.number_uniq_view.ToString();
                                    z_7 = element.number_view.ToString();
                                }
                                if (conter_ == 8 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_8 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_8 = element.number_uniq_view.ToString();
                                    z_8 = element.number_view.ToString();
                                }
                                if (conter_ == 9 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_9 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_9 = element.number_uniq_view.ToString();
                                    z_9 = element.number_view.ToString();
                                }
                                if (conter_ == 10 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_10 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_10 = element.number_uniq_view.ToString();
                                    z_10 = element.number_view.ToString();
                                }
                                if (conter_ == 11 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_11 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_11 = element.number_uniq_view.ToString();
                                    z_11 = element.number_view.ToString();
                                }
                                if (conter_ == 12 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_12 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_12 = element.number_uniq_view.ToString();
                                    z_12 = element.number_view.ToString();
                                }
                                if (conter_ == 13 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_13 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_13 = element.number_uniq_view.ToString();
                                    z_13 = element.number_view.ToString();
                                }
                                if (conter_ == 14 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_14 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_14 = element.number_uniq_view.ToString();
                                    z_14 = element.number_view.ToString();
                                }
                                if (conter_ == 15 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_15 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_15 = element.number_uniq_view.ToString();
                                    z_15 = element.number_view.ToString();
                                }
                                if (conter_ == 16 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_16 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_16 = element.number_uniq_view.ToString();
                                    z_16 = element.number_view.ToString();
                                }
                                if (conter_ == 17 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_17 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_17 = element.number_uniq_view.ToString();
                                    z_17 = element.number_view.ToString();
                                }
                                if (conter_ == 18 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_18 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_18 = element.number_uniq_view.ToString();
                                    z_18 = element.number_view.ToString();
                                }
                                if (conter_ == 19 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_19 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_19 = element.number_uniq_view.ToString();
                                    z_19 = element.number_view.ToString();
                                }
                                if (conter_ == 20 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_20 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_20 = element.number_uniq_view.ToString();
                                    z_20 = element.number_view.ToString();
                                }
                                if (conter_ == 21 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_21 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_21 = element.number_uniq_view.ToString();
                                    z_21 = element.number_view.ToString();
                                }
                                if (conter_ == 22 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_22 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_22 = element.number_uniq_view.ToString();
                                    z_22 = element.number_view.ToString();
                                }
                                if (conter_ == 23 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_23 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_23 = element.number_uniq_view.ToString();
                                    z_23 = element.number_view.ToString();
                                }
                                if (conter_ == 24 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_24 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_24 = element.number_uniq_view.ToString();
                                    z_24 = element.number_view.ToString();
                                }
                                if (conter_ == 25 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_25 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_25 = element.number_uniq_view.ToString();
                                    z_25 = element.number_view.ToString();
                                }
                                if (conter_ == 26 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_26 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_26 = element.number_uniq_view.ToString();
                                    z_26 = element.number_view.ToString();
                                }
                                if (conter_ == 27 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_27 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_27 = element.number_uniq_view.ToString();
                                    z_27 = element.number_view.ToString();
                                }
                                if (conter_ == 28 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_28 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_28 = element.number_uniq_view.ToString();
                                    z_28 = element.number_view.ToString();
                                }
                                if (conter_ == 29 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_29 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_29 = element.number_uniq_view.ToString();
                                    z_29 = element.number_view.ToString();
                                }
                                if (conter_ == 30 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_30 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_30 = element.number_uniq_view.ToString();
                                    z_30 = element.number_view.ToString();
                                }
                                //int all_view = 0; int all_uniq_view = 0;
                                //int all_view_month = 0; int all_uniq_view_month = 0;
                                //int all_view_month_av = 0; int all_uniq_view_month_av = 0;
                                //int all_view_3month = 0; int all_uniq_view_3month = 0;
                                //int all_view_3month_av = 0; int all_uniq_view_3month_av = 0;

                                all_uniq_view_month = all_uniq_view_month + Convert.ToInt32(element.number_uniq_view);
                                all_view_month = all_view_month + Convert.ToInt32(element.number_view);



                            }
                            Lbl_user_av.Text = "میانگین کاریر ماهیانه :" + ((float)(all_uniq_view_month / (conter_ - 1))).ToString();
                            Lbl_view_av.Text = "میانگین بازدید ماهیانه :" + ((float)(all_view_month / (conter_ - 1))).ToString();

                            if (view_exact_url_visit.Count() > 89)
                            {
                                var view_exact_url_visit_90 = view_exact_url_visit.OrderByDescending(c => c.date).Take(90);
                                view_exact_url_visit_90 = view_exact_url_visit_90.OrderBy(c => c.date);
                                conter_ = 0;
                                foreach (var element in view_exact_url_visit_90)
                                {
                                    conter_++;
                                    if (conter_ == 1 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x1 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y1 = element.number_uniq_view.ToString();
                                        z1 = element.number_view.ToString();
                                    }
                                    if (conter_ == 2 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x2 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y2 = element.number_uniq_view.ToString();
                                        z2 = element.number_view.ToString();
                                    }
                                    if (conter_ == 3 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x3 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y3 = element.number_uniq_view.ToString();
                                        z3 = element.number_view.ToString();
                                    }
                                    if (conter_ == 4 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x4 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y4 = element.number_uniq_view.ToString();
                                        z4 = element.number_view.ToString();
                                    }
                                    if (conter_ == 5 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x5 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y5 = element.number_uniq_view.ToString();
                                        z5 = element.number_view.ToString();
                                    }
                                    if (conter_ == 6 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x6 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y6 = element.number_uniq_view.ToString();
                                        z6 = element.number_view.ToString();
                                    }
                                    if (conter_ == 7 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x7 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y7 = element.number_uniq_view.ToString();
                                        z7 = element.number_view.ToString();
                                    }
                                    if (conter_ == 8 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x8 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y8 = element.number_uniq_view.ToString();
                                        z8 = element.number_view.ToString();
                                    }
                                    if (conter_ == 9 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x9 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y9 = element.number_uniq_view.ToString();
                                        z9 = element.number_view.ToString();
                                    }
                                    if (conter_ == 10 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x10 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y10 = element.number_uniq_view.ToString();
                                        z10 = element.number_view.ToString();
                                    }
                                    if (conter_ == 11 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x11 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y11 = element.number_uniq_view.ToString();
                                        z11 = element.number_view.ToString();
                                    }
                                    if (conter_ == 12 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x12 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y12 = element.number_uniq_view.ToString();
                                        z12 = element.number_view.ToString();
                                    }
                                    if (conter_ == 13 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x13 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y13 = element.number_uniq_view.ToString();
                                        z13 = element.number_view.ToString();
                                    }
                                    if (conter_ == 14 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x14 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y14 = element.number_uniq_view.ToString();
                                        z14 = element.number_view.ToString();
                                    }
                                    if (conter_ == 15 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x15 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y15 = element.number_uniq_view.ToString();
                                        z15 = element.number_view.ToString();
                                    }
                                    if (conter_ == 16 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x16 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y16 = element.number_uniq_view.ToString();
                                        z16 = element.number_view.ToString();
                                    }
                                    if (conter_ == 17 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x17 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y17 = element.number_uniq_view.ToString();
                                        z17 = element.number_view.ToString();
                                    }
                                    if (conter_ == 18 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x18 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y18 = element.number_uniq_view.ToString();
                                        z18 = element.number_view.ToString();
                                    }
                                    if (conter_ == 19 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x19 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y19 = element.number_uniq_view.ToString();
                                        z19 = element.number_view.ToString();
                                    }
                                    if (conter_ == 20 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x20 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y20 = element.number_uniq_view.ToString();
                                        z20 = element.number_view.ToString();
                                    }
                                    if (conter_ == 21 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x21 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y21 = element.number_uniq_view.ToString();
                                        z21 = element.number_view.ToString();
                                    }
                                    if (conter_ == 22 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x22 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y22 = element.number_uniq_view.ToString();
                                        z22 = element.number_view.ToString();
                                    }
                                    if (conter_ == 23 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x23 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y23 = element.number_uniq_view.ToString();
                                        z23 = element.number_view.ToString();
                                    }
                                    if (conter_ == 24 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x24 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y24 = element.number_uniq_view.ToString();
                                        z24 = element.number_view.ToString();
                                    }
                                    if (conter_ == 25 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x25 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y25 = element.number_uniq_view.ToString();
                                        z25 = element.number_view.ToString();
                                    }
                                    if (conter_ == 26 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x26 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y26 = element.number_uniq_view.ToString();
                                        z26 = element.number_view.ToString();
                                    }
                                    if (conter_ == 27 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x27 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y27 = element.number_uniq_view.ToString();
                                        z27 = element.number_view.ToString();
                                    }
                                    if (conter_ == 28 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x28 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y28 = element.number_uniq_view.ToString();
                                        z28 = element.number_view.ToString();
                                    }
                                    if (conter_ == 29 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x29 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y29 = element.number_uniq_view.ToString();
                                        z29 = element.number_view.ToString();
                                    }
                                    if (conter_ == 30 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x30 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y30 = element.number_uniq_view.ToString();
                                        z30 = element.number_view.ToString();
                                    }
                                    if (conter_ == 31 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x31 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y31 = element.number_uniq_view.ToString();
                                        z31 = element.number_view.ToString();
                                    }
                                    if (conter_ == 32 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x32 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y32 = element.number_uniq_view.ToString();
                                        z32 = element.number_view.ToString();
                                    }
                                    if (conter_ == 33 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x33 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y33 = element.number_uniq_view.ToString();
                                        z33 = element.number_view.ToString();
                                    }
                                    if (conter_ == 34 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x34 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y34 = element.number_uniq_view.ToString();
                                        z34 = element.number_view.ToString();
                                    }
                                    if (conter_ == 35 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x35 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y35 = element.number_uniq_view.ToString();
                                        z35 = element.number_view.ToString();
                                    }
                                    if (conter_ == 36 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x36 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y36 = element.number_uniq_view.ToString();
                                        z36 = element.number_view.ToString();
                                    }
                                    if (conter_ == 37 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x37 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y37 = element.number_uniq_view.ToString();
                                        z37 = element.number_view.ToString();
                                    }
                                    if (conter_ == 38 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x38 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y38 = element.number_uniq_view.ToString();
                                        z38 = element.number_view.ToString();
                                    }
                                    if (conter_ == 39 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x39 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y39 = element.number_uniq_view.ToString();
                                        z39 = element.number_view.ToString();
                                    }
                                    if (conter_ == 40 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x40 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y40 = element.number_uniq_view.ToString();
                                        z40 = element.number_view.ToString();
                                    }
                                    if (conter_ == 41 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x41 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y41 = element.number_uniq_view.ToString();
                                        z41 = element.number_view.ToString();
                                    }
                                    if (conter_ == 42 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x42 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y42 = element.number_uniq_view.ToString();
                                        z42 = element.number_view.ToString();
                                    }
                                    if (conter_ == 43 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x43 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y43 = element.number_uniq_view.ToString();
                                        z43 = element.number_view.ToString();
                                    }
                                    if (conter_ == 44 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x44 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y44 = element.number_uniq_view.ToString();
                                        z44 = element.number_view.ToString();
                                    }
                                    if (conter_ == 45 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x45 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y45 = element.number_uniq_view.ToString();
                                        z45 = element.number_view.ToString();
                                    }
                                    if (conter_ == 46 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x46 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y46 = element.number_uniq_view.ToString();
                                        z46 = element.number_view.ToString();
                                    }
                                    if (conter_ == 47 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x47 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y47 = element.number_uniq_view.ToString();
                                        z47 = element.number_view.ToString();
                                    }
                                    if (conter_ == 48 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x48 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y48 = element.number_uniq_view.ToString();
                                        z48 = element.number_view.ToString();
                                    }
                                    if (conter_ == 49 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x49 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y49 = element.number_uniq_view.ToString();
                                        z49 = element.number_view.ToString();
                                    }
                                    if (conter_ == 50 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x50 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y50 = element.number_uniq_view.ToString();
                                        z50 = element.number_view.ToString();
                                    }
                                    if (conter_ == 51 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x51 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y51 = element.number_uniq_view.ToString();
                                        z51 = element.number_view.ToString();
                                    }
                                    if (conter_ == 52 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x52 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y52 = element.number_uniq_view.ToString();
                                        z52 = element.number_view.ToString();
                                    }
                                    if (conter_ == 53 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x53 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y53 = element.number_uniq_view.ToString();
                                        z53 = element.number_view.ToString();
                                    }
                                    if (conter_ == 54 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x54 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y54 = element.number_uniq_view.ToString();
                                        z54 = element.number_view.ToString();
                                    }
                                    if (conter_ == 55 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x55 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y55 = element.number_uniq_view.ToString();
                                        z55 = element.number_view.ToString();
                                    }
                                    if (conter_ == 56 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x56 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y56 = element.number_uniq_view.ToString();
                                        z56 = element.number_view.ToString();
                                    }
                                    if (conter_ == 57 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x57 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y57 = element.number_uniq_view.ToString();
                                        z57 = element.number_view.ToString();
                                    }
                                    if (conter_ == 58 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x58 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y58 = element.number_uniq_view.ToString();
                                        z58 = element.number_view.ToString();
                                    }
                                    if (conter_ == 59 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x59 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y59 = element.number_uniq_view.ToString();
                                        z59 = element.number_view.ToString();
                                    }
                                    if (conter_ == 60 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x60 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y60 = element.number_uniq_view.ToString();
                                        z60 = element.number_view.ToString();
                                    }
                                    if (conter_ == 61 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x61 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y61 = element.number_uniq_view.ToString();
                                        z61 = element.number_view.ToString();
                                    }
                                    if (conter_ == 62 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x62 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y62 = element.number_uniq_view.ToString();
                                        z62 = element.number_view.ToString();
                                    }
                                    if (conter_ == 63 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x63 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y63 = element.number_uniq_view.ToString();
                                        z63 = element.number_view.ToString();
                                    }
                                    if (conter_ == 64 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x64 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y64 = element.number_uniq_view.ToString();
                                        z64 = element.number_view.ToString();
                                    }
                                    if (conter_ == 65 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x65 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y65 = element.number_uniq_view.ToString();
                                        z65 = element.number_view.ToString();
                                    }
                                    if (conter_ == 66 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x66 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y66 = element.number_uniq_view.ToString();
                                        z66 = element.number_view.ToString();
                                    }
                                    if (conter_ == 67 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x67 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y67 = element.number_uniq_view.ToString();
                                        z67 = element.number_view.ToString();
                                    }
                                    if (conter_ == 68 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x68 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y68 = element.number_uniq_view.ToString();
                                        z68 = element.number_view.ToString();
                                    }
                                    if (conter_ == 69 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x69 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y69 = element.number_uniq_view.ToString();
                                        z69 = element.number_view.ToString();
                                    }
                                    if (conter_ == 70 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x70 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y70 = element.number_uniq_view.ToString();
                                        z70 = element.number_view.ToString();
                                    }
                                    if (conter_ == 71 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x71 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y71 = element.number_uniq_view.ToString();
                                        z71 = element.number_view.ToString();
                                    }
                                    if (conter_ == 72 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x72 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y72 = element.number_uniq_view.ToString();
                                        z72 = element.number_view.ToString();
                                    }
                                    if (conter_ == 73 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x73 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y73 = element.number_uniq_view.ToString();
                                        z73 = element.number_view.ToString();
                                    }
                                    if (conter_ == 74 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x74 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y74 = element.number_uniq_view.ToString();
                                        z74 = element.number_view.ToString();
                                    }
                                    if (conter_ == 75 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x75 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y75 = element.number_uniq_view.ToString();
                                        z75 = element.number_view.ToString();
                                    }
                                    if (conter_ == 76 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x76 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y76 = element.number_uniq_view.ToString();
                                        z76 = element.number_view.ToString();
                                    }
                                    if (conter_ == 77 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x77 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y77 = element.number_uniq_view.ToString();
                                        z77 = element.number_view.ToString();
                                    }
                                    if (conter_ == 78 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x78 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y78 = element.number_uniq_view.ToString();
                                        z78 = element.number_view.ToString();
                                    }
                                    if (conter_ == 79 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x79 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y79 = element.number_uniq_view.ToString();
                                        z79 = element.number_view.ToString();
                                    }
                                    if (conter_ == 80 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x80 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y80 = element.number_uniq_view.ToString();
                                        z80 = element.number_view.ToString();
                                    }
                                    if (conter_ == 81 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x81 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y81 = element.number_uniq_view.ToString();
                                        z81 = element.number_view.ToString();
                                    }
                                    if (conter_ == 82 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x82 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y82 = element.number_uniq_view.ToString();
                                        z82 = element.number_view.ToString();
                                    }
                                    if (conter_ == 83 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x83 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y83 = element.number_uniq_view.ToString();
                                        z83 = element.number_view.ToString();
                                    }
                                    if (conter_ == 84 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x84 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y84 = element.number_uniq_view.ToString();
                                        z84 = element.number_view.ToString();
                                    }
                                    if (conter_ == 85 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x85 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y85 = element.number_uniq_view.ToString();
                                        z85 = element.number_view.ToString();
                                    }
                                    if (conter_ == 86 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x86 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y86 = element.number_uniq_view.ToString();
                                        z86 = element.number_view.ToString();
                                    }
                                    if (conter_ == 87 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x87 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y87 = element.number_uniq_view.ToString();
                                        z87 = element.number_view.ToString();
                                    }
                                    if (conter_ == 88 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x88 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y88 = element.number_uniq_view.ToString();
                                        z88 = element.number_view.ToString();
                                    }
                                    if (conter_ == 89 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x89 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y89 = element.number_uniq_view.ToString();
                                        z89 = element.number_view.ToString();
                                    }
                                    if (conter_ == 90 && view_exact_url_visit_90.Count() > 0)
                                    {
                                        x90 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                        y90 = element.number_uniq_view.ToString();
                                        z90 = element.number_view.ToString();
                                    }
                                    all_uniq_view_3month = all_uniq_view_3month + Convert.ToInt32(element.number_uniq_view);
                                    all_view_3month = all_view_3month + Convert.ToInt32(element.number_view);
                                }
                                Lbl_user90.Text = "تعداد کاربر ۹۰ رکورد: " + all_uniq_view_3month.ToString();
                                Lbl_view90.Text = "تعداد بازدید ۹۰ رکورد: " + all_view_3month;
                                Lbl_user_av3.Text = "میانگین کاربر ۳ ماهه :" + ((float)(all_uniq_view_3month / (conter_ - 1))).ToString();
                                Lbl_view_av3.Text = "میانگین بازدید ۳ ماهه :" + ((float)(all_view_3month / (conter_ - 1))).ToString();
                            }
                            

                        }
                       

                    
                }
                else
                {
                    Button1.Visible = true;
                    Update_all.Visible = false;
                    var exact_url_visit = db.exact_url_Tables.Where(c => c.id == Convert.ToInt32(ID_));
                    //string folder1 = Request.QueryString["f1"];
                    //string folder2 = Request.QueryString["f2"];
                    //string id_record = Request.QueryString["id"];
                    string name_page = "";

                    if (exact_url_visit.Count() == 1)
                    {

                        maintitle.InnerHtml = "";
                        mainDescription.InnerHtml = exact_url_visit.Single().group_page;
                        if (exact_url_visit.Single().name_page.Contains("paper"))
                        {
                            name_page = exact_url_visit.Single().name_page;
                            maintitle.InnerHtml = "مقاله";
                            mainDescription.InnerHtml = exact_url_visit.Single().text;

                        }
                        else if (exact_url_visit.Single().name_page.Contains("Product"))
                        {
                            name_page = exact_url_visit.Single().name_page;
                            maintitle.InnerHtml = "کالا";
                            mainDescription.InnerHtml = exact_url_visit.Single().group_page;
                        }
                        else if (exact_url_visit.Single().name_page.Contains("detailnews"))
                        {
                            name_page = exact_url_visit.Single().name_page;
                            maintitle.InnerHtml = "خبر";
                            mainDescription.InnerHtml = exact_url_visit.Single().text;
                        }


                        mainurl.InnerText = exact_url_visit.Single().exact_url;
                        var view_exact_url_visit = db.View_exact_page_Tables.Where(c => c.id_exact_url == Convert.ToInt32(ID_) && c.number_view != "0");
                        if (view_exact_url_visit.Count() > 0)
                        {
                            int all_view = 0; int all_uniq_view = 0;
                            int all_view_month = 0; int all_uniq_view_month = 0;
                            //int all_view_month_av = 0; int all_uniq_view_month_av = 0;
                            int all_view_3month = 0; int all_uniq_view_3month = 0;
                            //int all_view_3month_av = 0; int all_uniq_view_3month_av = 0;

                            foreach (var element in view_exact_url_visit)
                            {
                                all_uniq_view = all_uniq_view + Convert.ToInt32(element.number_uniq_view);

                                all_view = all_view + Convert.ToInt32(element.number_view);
                            }
                           
                            lbl_user_all.Text = "بازدید کاربر کل: " + all_uniq_view.ToString();
                            lbl_user_all90.Text = "بازدید کاربر کل: " + all_uniq_view.ToString();
                            Lbl_view_all.Text = "بازدید کل: " + all_view.ToString();
                            Lbl_view_all90.Text = "بازدید کل: " + all_view.ToString();
                           
                            int conter_ = 0;

                            var view_exact_url_visit_30 = view_exact_url_visit.OrderByDescending(c => c.date).Take(30);
                            view_exact_url_visit_30 = view_exact_url_visit_30.OrderBy(c => c.date);
                            conter_ = 0;
                            foreach (var element in view_exact_url_visit_30)
                            {
                                conter_++;
                                if (conter_ == 1 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_1 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_1 = element.number_uniq_view.ToString();
                                    z_1 = element.number_view.ToString();
                                }
                                if (conter_ == 2 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_2 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_2 = element.number_uniq_view.ToString();
                                    z_2 = element.number_view.ToString();
                                }
                                if (conter_ == 3 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_3 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_3 = element.number_uniq_view.ToString();
                                    z_3 = element.number_view.ToString();
                                }
                                if (conter_ == 4 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_4 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_4 = element.number_uniq_view.ToString();
                                    z_4 = element.number_view.ToString();
                                }
                                if (conter_ == 5 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_5 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_5 = element.number_uniq_view.ToString();
                                    z_5 = element.number_view.ToString();
                                }
                                if (conter_ == 6 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_6 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_6 = element.number_uniq_view.ToString();
                                    z_6 = element.number_view.ToString();
                                }
                                if (conter_ == 7 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_7 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_7 = element.number_uniq_view.ToString();
                                    z_7 = element.number_view.ToString();
                                }
                                if (conter_ == 8 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_8 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_8 = element.number_uniq_view.ToString();
                                    z_8 = element.number_view.ToString();
                                }
                                if (conter_ == 9 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_9 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_9 = element.number_uniq_view.ToString();
                                    z_9 = element.number_view.ToString();
                                }
                                if (conter_ == 10 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_10 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_10 = element.number_uniq_view.ToString();
                                    z_10 = element.number_view.ToString();
                                }
                                if (conter_ == 11 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_11 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_11 = element.number_uniq_view.ToString();
                                    z_11 = element.number_view.ToString();
                                }
                                if (conter_ == 12 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_12 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_12 = element.number_uniq_view.ToString();
                                    z_12 = element.number_view.ToString();
                                }
                                if (conter_ == 13 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_13 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_13 = element.number_uniq_view.ToString();
                                    z_13 = element.number_view.ToString();
                                }
                                if (conter_ == 14 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_14 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_14 = element.number_uniq_view.ToString();
                                    z_14 = element.number_view.ToString();
                                }
                                if (conter_ == 15 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_15 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_15 = element.number_uniq_view.ToString();
                                    z_15 = element.number_view.ToString();
                                }
                                if (conter_ == 16 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_16 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_16 = element.number_uniq_view.ToString();
                                    z_16 = element.number_view.ToString();
                                }
                                if (conter_ == 17 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_17 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_17 = element.number_uniq_view.ToString();
                                    z_17 = element.number_view.ToString();
                                }
                                if (conter_ == 18 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_18 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_18 = element.number_uniq_view.ToString();
                                    z_18 = element.number_view.ToString();
                                }
                                if (conter_ == 19 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_19 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_19 = element.number_uniq_view.ToString();
                                    z_19 = element.number_view.ToString();
                                }
                                if (conter_ == 20 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_20 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_20 = element.number_uniq_view.ToString();
                                    z_20 = element.number_view.ToString();
                                }
                                if (conter_ == 21 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_21 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_21 = element.number_uniq_view.ToString();
                                    z_21 = element.number_view.ToString();
                                }
                                if (conter_ == 22 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_22 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_22 = element.number_uniq_view.ToString();
                                    z_22 = element.number_view.ToString();
                                }
                                if (conter_ == 23 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_23 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_23 = element.number_uniq_view.ToString();
                                    z_23 = element.number_view.ToString();
                                }
                                if (conter_ == 24 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_24 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_24 = element.number_uniq_view.ToString();
                                    z_24 = element.number_view.ToString();
                                }
                                if (conter_ == 25 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_25 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_25 = element.number_uniq_view.ToString();
                                    z_25 = element.number_view.ToString();
                                }
                                if (conter_ == 26 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_26 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_26 = element.number_uniq_view.ToString();
                                    z_26 = element.number_view.ToString();
                                }
                                if (conter_ == 27 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_27 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_27 = element.number_uniq_view.ToString();
                                    z_27 = element.number_view.ToString();
                                }
                                if (conter_ == 28 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_28 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_28 = element.number_uniq_view.ToString();
                                    z_28 = element.number_view.ToString();
                                }
                                if (conter_ == 29 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_29 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_29 = element.number_uniq_view.ToString();
                                    z_29 = element.number_view.ToString();
                                }
                                if (conter_ == 30 && view_exact_url_visit_30.Count() > 0)
                                {
                                    x_30 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y_30 = element.number_uniq_view.ToString();
                                    z_30 = element.number_view.ToString();
                                }

                            }
                            foreach (var element in view_exact_url_visit_30)
                            {
                                all_uniq_view_month = all_uniq_view_month + Convert.ToInt32(element.number_uniq_view);

                                all_view_month = all_view_month + Convert.ToInt32(element.number_view);
                            }
                            Lbl_user30.Text = "تعداد کاربر ۳۰ رکورد: " + (all_uniq_view_month).ToString();
                            Lbl_view30.Text = "تعداد بازدید ۳۰ رکورد: " + all_view_month.ToString();
                            Lbl_user_av.Text = "میانگین  روزانه کاربر در ۳۰ رکورد :" + ((float)(all_uniq_view_month / (view_exact_url_visit_30.Count()))).ToString();
                            Lbl_view_av.Text = "میانگین روزانه بازدید ۳۰ رکورد :" + ((float)(all_view_month / (view_exact_url_visit_30.Count()))).ToString();

                            var view_exact_url_visit_90 = view_exact_url_visit.OrderByDescending(c => c.date).Take(90);
                            view_exact_url_visit_90 = view_exact_url_visit_90.OrderBy(c => c.date);
                            conter_ = 0;
                            foreach (var element in view_exact_url_visit_90)
                            {
                                conter_++;
                                if (conter_ == 1 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x1 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y1 = element.number_uniq_view.ToString();
                                    z1 = element.number_view.ToString();
                                }
                                if (conter_ == 2 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x2 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y2 = element.number_uniq_view.ToString();
                                    z2 = element.number_view.ToString();
                                }
                                if (conter_ == 3 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x3 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y3 = element.number_uniq_view.ToString();
                                    z3 = element.number_view.ToString();
                                }
                                if (conter_ == 4 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x4 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y4 = element.number_uniq_view.ToString();
                                    z4 = element.number_view.ToString();
                                }
                                if (conter_ == 5 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x5 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y5 = element.number_uniq_view.ToString();
                                    z5 = element.number_view.ToString();
                                }
                                if (conter_ == 6 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x6 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y6 = element.number_uniq_view.ToString();
                                    z6 = element.number_view.ToString();
                                }
                                if (conter_ == 7 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x7 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y7 = element.number_uniq_view.ToString();
                                    z7 = element.number_view.ToString();
                                }
                                if (conter_ == 8 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x8 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y8 = element.number_uniq_view.ToString();
                                    z8 = element.number_view.ToString();
                                }
                                if (conter_ == 9 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x9 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y9 = element.number_uniq_view.ToString();
                                    z9 = element.number_view.ToString();
                                }
                                if (conter_ == 10 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x10 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y10 = element.number_uniq_view.ToString();
                                    z10 = element.number_view.ToString();
                                }
                                if (conter_ == 11 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x11 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y11 = element.number_uniq_view.ToString();
                                    z11 = element.number_view.ToString();
                                }
                                if (conter_ == 12 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x12 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y12 = element.number_uniq_view.ToString();
                                    z12 = element.number_view.ToString();
                                }
                                if (conter_ == 13 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x13 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y13 = element.number_uniq_view.ToString();
                                    z13 = element.number_view.ToString();
                                }
                                if (conter_ == 14 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x14 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y14 = element.number_uniq_view.ToString();
                                    z14 = element.number_view.ToString();
                                }
                                if (conter_ == 15 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x15 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y15 = element.number_uniq_view.ToString();
                                    z15 = element.number_view.ToString();
                                }
                                if (conter_ == 16 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x16 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y16 = element.number_uniq_view.ToString();
                                    z16 = element.number_view.ToString();
                                }
                                if (conter_ == 17 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x17 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y17 = element.number_uniq_view.ToString();
                                    z17 = element.number_view.ToString();
                                }
                                if (conter_ == 18 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x18 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y18 = element.number_uniq_view.ToString();
                                    z18 = element.number_view.ToString();
                                }
                                if (conter_ == 19 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x19 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y19 = element.number_uniq_view.ToString();
                                    z19 = element.number_view.ToString();
                                }
                                if (conter_ == 20 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x20 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y20 = element.number_uniq_view.ToString();
                                    z20 = element.number_view.ToString();
                                }
                                if (conter_ == 21 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x21 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y21 = element.number_uniq_view.ToString();
                                    z21 = element.number_view.ToString();
                                }
                                if (conter_ == 22 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x22 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y22 = element.number_uniq_view.ToString();
                                    z22 = element.number_view.ToString();
                                }
                                if (conter_ == 23 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x23 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y23 = element.number_uniq_view.ToString();
                                    z23 = element.number_view.ToString();
                                }
                                if (conter_ == 24 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x24 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y24 = element.number_uniq_view.ToString();
                                    z24 = element.number_view.ToString();
                                }
                                if (conter_ == 25 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x25 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y25 = element.number_uniq_view.ToString();
                                    z25 = element.number_view.ToString();
                                }
                                if (conter_ == 26 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x26 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y26 = element.number_uniq_view.ToString();
                                    z26 = element.number_view.ToString();
                                }
                                if (conter_ == 27 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x27 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y27 = element.number_uniq_view.ToString();
                                    z27 = element.number_view.ToString();
                                }
                                if (conter_ == 28 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x28 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y28 = element.number_uniq_view.ToString();
                                    z28 = element.number_view.ToString();
                                }
                                if (conter_ == 29 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x29 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y29 = element.number_uniq_view.ToString();
                                    z29 = element.number_view.ToString();
                                }
                                if (conter_ == 30 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x30 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y30 = element.number_uniq_view.ToString();
                                    z30 = element.number_view.ToString();
                                }
                                if (conter_ == 31 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x31 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y31 = element.number_uniq_view.ToString();
                                    z31 = element.number_view.ToString();
                                }
                                if (conter_ == 32 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x32 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y32 = element.number_uniq_view.ToString();
                                    z32 = element.number_view.ToString();
                                }
                                if (conter_ == 33 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x33 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y33 = element.number_uniq_view.ToString();
                                    z33 = element.number_view.ToString();
                                }
                                if (conter_ == 34 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x34 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y34 = element.number_uniq_view.ToString();
                                    z34 = element.number_view.ToString();
                                }
                                if (conter_ == 35 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x35 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y35 = element.number_uniq_view.ToString();
                                    z35 = element.number_view.ToString();
                                }
                                if (conter_ == 36 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x36 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y36 = element.number_uniq_view.ToString();
                                    z36 = element.number_view.ToString();
                                }
                                if (conter_ == 37 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x37 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y37 = element.number_uniq_view.ToString();
                                    z37 = element.number_view.ToString();
                                }
                                if (conter_ == 38 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x38 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y38 = element.number_uniq_view.ToString();
                                    z38 = element.number_view.ToString();
                                }
                                if (conter_ == 39 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x39 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y39 = element.number_uniq_view.ToString();
                                    z39 = element.number_view.ToString();
                                }
                                if (conter_ == 40 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x40 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y40 = element.number_uniq_view.ToString();
                                    z40 = element.number_view.ToString();
                                }
                                if (conter_ == 41 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x41 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y41 = element.number_uniq_view.ToString();
                                    z41 = element.number_view.ToString();
                                }
                                if (conter_ == 42 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x42 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y42 = element.number_uniq_view.ToString();
                                    z42 = element.number_view.ToString();
                                }
                                if (conter_ == 43 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x43 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y43 = element.number_uniq_view.ToString();
                                    z43 = element.number_view.ToString();
                                }
                                if (conter_ == 44 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x44 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y44 = element.number_uniq_view.ToString();
                                    z44 = element.number_view.ToString();
                                }
                                if (conter_ == 45 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x45 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y45 = element.number_uniq_view.ToString();
                                    z45 = element.number_view.ToString();
                                }
                                if (conter_ == 46 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x46 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y46 = element.number_uniq_view.ToString();
                                    z46 = element.number_view.ToString();
                                }
                                if (conter_ == 47 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x47 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y47 = element.number_uniq_view.ToString();
                                    z47 = element.number_view.ToString();
                                }
                                if (conter_ == 48 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x48 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y48 = element.number_uniq_view.ToString();
                                    z48 = element.number_view.ToString();
                                }
                                if (conter_ == 49 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x49 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y49 = element.number_uniq_view.ToString();
                                    z49 = element.number_view.ToString();
                                }
                                if (conter_ == 50 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x50 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y50 = element.number_uniq_view.ToString();
                                    z50 = element.number_view.ToString();
                                }
                                if (conter_ == 51 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x51 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y51 = element.number_uniq_view.ToString();
                                    z51 = element.number_view.ToString();
                                }
                                if (conter_ == 52 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x52 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y52 = element.number_uniq_view.ToString();
                                    z52 = element.number_view.ToString();
                                }
                                if (conter_ == 53 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x53 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y53 = element.number_uniq_view.ToString();
                                    z53 = element.number_view.ToString();
                                }
                                if (conter_ == 54 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x54 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y54 = element.number_uniq_view.ToString();
                                    z54 = element.number_view.ToString();
                                }
                                if (conter_ == 55 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x55 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y55 = element.number_uniq_view.ToString();
                                    z55 = element.number_view.ToString();
                                }
                                if (conter_ == 56 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x56 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y56 = element.number_uniq_view.ToString();
                                    z56 = element.number_view.ToString();
                                }
                                if (conter_ == 57 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x57 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y57 = element.number_uniq_view.ToString();
                                    z57 = element.number_view.ToString();
                                }
                                if (conter_ == 58 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x58 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y58 = element.number_uniq_view.ToString();
                                    z58 = element.number_view.ToString();
                                }
                                if (conter_ == 59 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x59 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y59 = element.number_uniq_view.ToString();
                                    z59 = element.number_view.ToString();
                                }
                                if (conter_ == 60 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x60 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y60 = element.number_uniq_view.ToString();
                                    z60 = element.number_view.ToString();
                                }
                                if (conter_ == 61 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x61 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y61 = element.number_uniq_view.ToString();
                                    z61 = element.number_view.ToString();
                                }
                                if (conter_ == 62 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x62 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y62 = element.number_uniq_view.ToString();
                                    z62 = element.number_view.ToString();
                                }
                                if (conter_ == 63 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x63 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y63 = element.number_uniq_view.ToString();
                                    z63 = element.number_view.ToString();
                                }
                                if (conter_ == 64 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x64 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y64 = element.number_uniq_view.ToString();
                                    z64 = element.number_view.ToString();
                                }
                                if (conter_ == 65 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x65 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y65 = element.number_uniq_view.ToString();
                                    z65 = element.number_view.ToString();
                                }
                                if (conter_ == 66 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x66 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y66 = element.number_uniq_view.ToString();
                                    z66 = element.number_view.ToString();
                                }
                                if (conter_ == 67 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x67 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y67 = element.number_uniq_view.ToString();
                                    z67 = element.number_view.ToString();
                                }
                                if (conter_ == 68 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x68 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y68 = element.number_uniq_view.ToString();
                                    z68 = element.number_view.ToString();
                                }
                                if (conter_ == 69 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x69 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y69 = element.number_uniq_view.ToString();
                                    z69 = element.number_view.ToString();
                                }
                                if (conter_ == 70 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x70 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y70 = element.number_uniq_view.ToString();
                                    z70 = element.number_view.ToString();
                                }
                                if (conter_ == 71 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x71 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y71 = element.number_uniq_view.ToString();
                                    z71 = element.number_view.ToString();
                                }
                                if (conter_ == 72 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x72 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y72 = element.number_uniq_view.ToString();
                                    z72 = element.number_view.ToString();
                                }
                                if (conter_ == 73 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x73 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y73 = element.number_uniq_view.ToString();
                                    z73 = element.number_view.ToString();
                                }
                                if (conter_ == 74 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x74 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y74 = element.number_uniq_view.ToString();
                                    z74 = element.number_view.ToString();
                                }
                                if (conter_ == 75 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x75 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y75 = element.number_uniq_view.ToString();
                                    z75 = element.number_view.ToString();
                                }
                                if (conter_ == 76 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x76 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y76 = element.number_uniq_view.ToString();
                                    z76 = element.number_view.ToString();
                                }
                                if (conter_ == 77 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x77 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y77 = element.number_uniq_view.ToString();
                                    z77 = element.number_view.ToString();
                                }
                                if (conter_ == 78 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x78 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y78 = element.number_uniq_view.ToString();
                                    z78 = element.number_view.ToString();
                                }
                                if (conter_ == 79 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x79 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y79 = element.number_uniq_view.ToString();
                                    z79 = element.number_view.ToString();
                                }
                                if (conter_ == 80 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x80 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y80 = element.number_uniq_view.ToString();
                                    z80 = element.number_view.ToString();
                                }
                                if (conter_ == 81 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x81 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y81 = element.number_uniq_view.ToString();
                                    z81 = element.number_view.ToString();
                                }
                                if (conter_ == 82 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x82 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y82 = element.number_uniq_view.ToString();
                                    z82 = element.number_view.ToString();
                                }
                                if (conter_ == 83 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x83 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y83 = element.number_uniq_view.ToString();
                                    z83 = element.number_view.ToString();
                                }
                                if (conter_ == 84 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x84 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y84 = element.number_uniq_view.ToString();
                                    z84 = element.number_view.ToString();
                                }
                                if (conter_ == 85 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x85 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y85 = element.number_uniq_view.ToString();
                                    z85 = element.number_view.ToString();
                                }
                                if (conter_ == 86 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x86 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y86 = element.number_uniq_view.ToString();
                                    z86 = element.number_view.ToString();
                                }
                                if (conter_ == 87 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x87 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y87 = element.number_uniq_view.ToString();
                                    z87 = element.number_view.ToString();
                                }
                                if (conter_ == 88 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x88 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y88 = element.number_uniq_view.ToString();
                                    z88 = element.number_view.ToString();
                                }
                                if (conter_ == 89 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x89 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y89 = element.number_uniq_view.ToString();
                                    z89 = element.number_view.ToString();
                                }
                                if (conter_ == 90 && view_exact_url_visit_90.Count() > 0)
                                {
                                    x90 = (Dateshamsi(Convert.ToDateTime(element.date))).ToString();
                                    y90 = element.number_uniq_view.ToString();
                                    z90 = element.number_view.ToString();
                                }
                               
                            }
                            foreach (var element in view_exact_url_visit_90)
                            {
                                all_uniq_view_3month = all_uniq_view_3month + Convert.ToInt32(element.number_uniq_view);

                                all_view_3month = all_view_3month + Convert.ToInt32(element.number_view);
                            }
                            Lbl_user90.Text = "تعداد کاربر ۹۰ رکورد: " + all_uniq_view_3month.ToString();
                            Lbl_view90.Text = "تعداد بازدید ۹۰ رکورد: " + all_view_3month.ToString();
                            Lbl_user_av3.Text = "میانگین  روزانه کاربر در ۹۰ رکورد :" + ((float)(all_uniq_view_3month / (view_exact_url_visit_90.Count()))).ToString();
                            Lbl_view_av3.Text = "میانگین روزانه بازدید ۹۰ رکورد :" + ((float)(all_view_3month / (view_exact_url_visit_90.Count()))).ToString();


                        }

                    }
                }                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var url_visit = db.exact_url_Tables.Where(c => c.id==Convert.ToInt32(Request.QueryString["ID"]));
            foreach (var element in url_visit)
            {

                if (element.name_page.Contains("paper"))
                {
                    var result = db.url_tbls.Where(a => a.url.Contains("paper") && a.url.Contains(element.name_page.Replace("paper?=I", "")));
                    //var result = from a in db.url_tbls
                    //             join b in db.record_visitors_tbls
                    //             on a.id equals b.id_address_url
                    //             where (a.url.Contains("paper") && a.url.Contains(element.name_page.Replace("paper?=I", "")))

                    //             select new
                    //             {
                    //                 b.date,
                    //                 b.ip,
                    //                 b.id
                    //             };
                    for (int i = 1; i <= 365; i++)
                    {
                        DateTime date_view = DateTime.Now.AddDays(-i);
                        var resultdate = result.Where(c => c.date == date_view);
                        var resultip = resultdate.Select(c => c.ip).Distinct();
                        var view_record = db.View_exact_page_Tables.Where(c => c.date == date_view && c.id_exact_url == element.id);
                        if (view_record.Count() == 0)
                        {
                            db.P_Insert_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        }
                        //else if (view_record.Count() == 1)
                        //{
                        //    db.P_Update_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        //}
                    }
                }
                else if (element.name_page.Contains("Product"))
                {
                    var result = db.url_tbls.Where(a => a.url.Contains("Product") && a.url.Contains(element.name_page.Replace("Product?=product", "")));
                   
                    for (int i = 1; i <= 365; i++)
                    {
                        DateTime date_view = DateTime.Now.AddDays(-i);
                        var resultdate = result.Where(c => c.date == date_view);
                        var resultip = resultdate.Select(c => c.ip).Distinct();
                        var view_record = db.View_exact_page_Tables.Where(c => c.date == date_view && c.id_exact_url == element.id);
                        if (view_record.Count() == 0)
                        {
                            db.P_Insert_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        }
                       
                    }
                }
                else if (element.name_page.Contains("detailnews"))
                {
                    var result = db.url_tbls.Where(a => a.url.Contains("detailnews") && a.url.Contains(element.name_page.Replace("detailnews?=I", "")));

                                
                    for (int i = 1; i <= 365; i++)
                    {
                        DateTime date_view = DateTime.Now.AddDays(-i);
                        var resultdate = result.Where(c => c.date == date_view);
                        var resultip = resultdate.Select(c => c.ip).Distinct();
                        var view_record = db.View_exact_page_Tables.Where(c => c.date == date_view && c.id_exact_url == element.id);
                        if (view_record.Count() == 0)
                        {
                            db.P_Insert_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        }
                        
                    }
                }
                else if (element.group_page=="صفحه اول")
                {
                    var result = db.url_tbls.Where(a => a.url.Contains("index") || a.url == "https://nobincommerce.com/" || a.url == "http://ImportXpress.ir/" || a.url == "https://www.ImportXpress.ir/" || a.url == "http://www.ImportXpress.ir/");
                    //var result = from a in db.url_tbls
                    //             join b in db.record_visitors_tbls
                    //             on a.id equals b.id_address_url
                    //             where (a.url.Contains("index") || a.url == "https://nobincommerce.com/" || a.url == "http://ImportXpress.ir/" || a.url == "https://www.ImportXpress.ir/" || a.url == "http://www.ImportXpress.ir/")

                    //             select new
                    //             {
                    //                 b.date,
                    //                 b.ip,
                    //                 b.id
                    //             };
                    for (int i = 1; i <= 365; i++)
                    {
                        DateTime date_view = DateTime.Now.AddDays(-i);
                        var resultdate = result.Where(c => c.date == date_view);
                        var resultip = resultdate.Select(c => c.ip).Distinct();
                        var view_record = db.View_exact_page_Tables.Where(c => c.date == date_view && c.id_exact_url == element.id);
                        if (view_record.Count() == 0)
                        {
                            db.P_Insert_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        }
                        
                    }
                }
                else
                {
                    var result = db.url_tbls.Where(a => a.url.Contains(element.name_page));
                    //var result = from a in db.url_tbls
                    //             join b in db.record_visitors_tbls
                    //             on a.id equals b.id_address_url
                    //             where (a.url.Contains(element.name_page))

                    //             select new
                    //             {
                    //                 b.date,
                    //                 b.ip,
                    //                 b.id
                    //             };
                    for (int i = 1; i <= 365; i++)
                    {
                        DateTime date_view = DateTime.Now.AddDays(-i);
                        var resultdate = result.Where(c => c.date == date_view);
                        var resultip = resultdate.Select(c => c.ip).Distinct();
                        var view_record = db.View_exact_page_Tables.Where(c => c.date == date_view && c.id_exact_url == element.id);
                        if (view_record.Count() == 0)
                        {
                            db.P_Insert_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        }
                        //else if (view_record.Count() == 1)
                        //{
                        //    db.P_Update_View_exact_page_Table(element.id, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                        //}
                    }
                }

                //DateTime firstday = Convert.ToDateTime(result.OrderByDescending(c => c.date).Last().date);
                //TimeSpan date_mines = DateTime.Now - DateTime.Now.AddDays(-365);

            }
        }

        protected void Update_all_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.url_tbls;
           
            string ID_ = Request.QueryString["ID"];
            if (ID_ == "0")
            {
                for (int i = 1; i <= 365; i++)
                {
                    DateTime date_view = DateTime.Now.AddDays(-i);
                    var resultdate = result.Where(c => c.date == date_view);
                    var resultip = resultdate.Select(c => c.ip).Distinct();
                    var view_record = db.View_exact_page_Tables.Where(c => c.date == date_view && c.id_exact_url == 0);

                    if (view_record.Count() == 0)
                    {
                        db.P_Insert_View_exact_page_Table(0, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                    }
                    //else if (view_record.Count() == 1)
                    //{
                    //    db.P_Update_View_exact_page_Table(0, date_view, resultip.Count().ToString(), resultdate.Count().ToString());
                    //}
                }
            }

        }
    }
}