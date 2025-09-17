using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class exact_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void update_newpage_Click(object sender, EventArgs e)
        {
            string url = "https://nobincommerce.com";
            DataClasses1DataContext db = new DataClasses1DataContext();
            string folder1 = "";
            string folder2 = "";
            string name_page = "";
            


            var product_steel_page = db.Text_for_store_steels.Where(c => c.name_page != null && (c.address_ != null || c.address_ != ""));
            foreach (var element in product_steel_page)
            {
                folder1 = "";
                folder2 = "";
                name_page = ""; 

                if (element.address_.Contains("/steel-store/"))
                {
                    folder1 = "steel-store";
                    if (element.address_.Contains("/bar/"))
                    {
                        folder2 = "bar"; 
                    }
                    else if (element.address_.Contains("/beam/"))
                    {
                        folder2 = "beam"; 
                    }
                    else if (element.address_.Contains("/pipe/"))
                    {
                        folder2 = "pipe"; 
                    }
                    else if (element.address_.Contains("/profiles/"))
                    {
                        folder2 = "profiles"; 
                    }
                   
                    else if (element.address_.Contains("/sheet/"))
                    {
                        folder2 = "sheet"; 
                    }
                   else if (element.address_.Contains("/rebar/"))
                    {
                        folder2 = "rebar";
                    }

                }
                else if (element.address_.Contains("/specialized-services/"))
                {
                    folder1 = "specialized-services";
                    if (element.address_.Contains("/Consulting/"))
                    {
                        folder2 = "Consulting";
                    }
                    else if (element.address_.Contains("/design/"))
                    {
                        folder2 = "design";
                    }
                    else if (element.address_.Contains("/executive/"))
                    {
                        folder2 = "executive";
                    }
                    else if (element.address_.Contains("/legal/"))
                    {
                        folder2 = "legal";
                    }
                }
                name_page = element.address_.Replace("/" + folder1 + "/" + folder2 + "/", "");
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + element.address_);
               
                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + element.address_, url + element.address_ + "?T=" + element.title_page.Replace(" ", "-"), element.title_page, folder1, folder2, name_page, true, element.name_page);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + element.address_, url + element.address_ + "?T=" + element.title_page.Replace(" ", "-"), element.title_page, folder1, folder2, name_page, true, element.name_page);
                }

            }

            var news = db.Paper_tbls.Where(c => c.subject_paper != null && c.delet_ == false && c.news == true);
            foreach (var element in news)
            {
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/news/detailnews?I=" + element.id.ToString());
                folder1 = "news";
                folder2 = "";
                name_page = "detailnews?I=" + element.id.ToString();
                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/news/detailnews?I=" + element.id.ToString(), url + "/news/detailnews" + "?T=" + element.subject_paper.Replace(" ", "-") + "&I=" + element.id.ToString(), element.subject_paper, folder1, folder2, name_page, true, "اخبار");
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/news/detailnews?I=" + element.id.ToString(), url + "/news/detailnews" + "?T=" + element.subject_paper.Replace(" ", "-") + "&I=" + element.id.ToString(), element.subject_paper, folder1, folder2, name_page, true, "اخبار");
                }
            }

            var blog = db.Paper_tbls.Where(c => c.subject_paper != null && c.delet_ == false && c.news == null);
            foreach (var element in blog)
            {
                //https://nobincommerce.com/blog/paper.aspx?I=1052
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/blog/paper?I=" + element.id.ToString());
                folder1 = "blog";
                folder2 = "";
                name_page = "paper?I=" + element.id.ToString();
                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/blog/paper?I=" + element.id.ToString(), url + "/blog/paper" + "?T=" + element.subject_paper.Replace(" ", "-") + "&I=" + element.id.ToString(), element.subject_paper, folder1, folder2, name_page, true, "وبلاگ");
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/blog/paper?I=" + element.id.ToString(), url + "/blog/paper" + "?T=" + element.subject_paper.Replace(" ", "-") + "&I=" + element.id.ToString(), element.subject_paper, folder1, folder2, name_page, true, "وبلاگ");
                }
            }

            var productbar = db.Product_tables.Where(c => c.Name_product.Contains("نیشی") || c.Name_product.Contains("ناودانی") || c.Name_product.Contains("سپری"));
            foreach (var element in productbar)
            {
                folder1 = "steel-store";
                folder2 = "bar";
                name_page = "Product?product=" + element.id.ToString();
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + "/" + folder2 + "/" + name_page);

                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
            }

            var prodactbeam = db.Product_tables.Where(c => c.Name_product.Contains("هاش") || c.Name_product.Contains("تیرآهن"));
            foreach (var element in prodactbeam)
            {
                folder1 = "steel-store";
                folder2 = "beam";
                name_page = "Product?product=" + element.id.ToString();
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + "/" + folder2 + "/" + name_page);

                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
            }

            var productprofile = db.Product_tables.Where(c => c.Name_product.Contains("پروفیل"));
            foreach (var element in productprofile)
            {
                folder1 = "steel-store";
                folder2 = "profiles";
                name_page = "Product?product=" + element.id.ToString();
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + "/" + folder2 + "/" + name_page);

                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
            }

            var productpipe = db.Product_tables.Where(c => c.Name_product.Contains("لوله"));
            foreach (var element in productpipe)
            {
                folder1 = "steel-store";
                folder2 = "pipe";
                name_page = "Product?product=" + element.id.ToString();
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + "/" + folder2 + "/" + name_page);

                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
            }

            var productrebar = db.Product_tables.Where(c => c.Name_product.Contains("میلگرد"));
            foreach (var element in productrebar)
            {
                folder1 = "steel-store";
                folder2 = "rebar";
                name_page = "Product?product=" + element.id.ToString();
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + "/" + folder2 + "/" + name_page);

                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
            }

            var productsheet = db.Product_tables.Where(c => c.Name_product.Contains("ورق"));
            foreach (var element in productsheet)
            {
                folder1 = "steel-store";
                folder2 = "sheet";
                name_page = "Product?product=" + element.id.ToString();
                var pages = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + "/" + folder2 + "/" + name_page);

                if (pages.Count() == 1)
                {
                    db.P_Update_exact_url_Table(pages.Single().id, url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
                else if (pages.Count() == 0)
                {
                    db.P_Insert_exact_url_Table(url + "/" + folder1 + "/" + folder2 + "/" + name_page, url + "/" + folder1 + "/" + folder2 + "/" + name_page, " کالا", folder1, folder2, name_page, true, element.Name_product + " " + element.Dimensions);
                }
            }

            string pathfile = "/index";
            var single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile);
            folder1 = "";
            folder2 = "";
            name_page = "index";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile, url + pathfile, "", folder1, folder2, name_page, true, "صفحه اول");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile, url + pathfile, "", folder1, folder2, name_page, true, "صفحه اول");
            }

            string pathfile_about_us = "/about_us";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_about_us);
            folder1 = "";
            folder2 = "";
            name_page = "about_us";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_about_us, url + pathfile_about_us, "", folder1, folder2, name_page, true, "درباره ما");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_about_us, url + pathfile_about_us, "", folder1, folder2, name_page, true, "درباره ما");
            }

           
            string pathfile_careers = "/careers";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_careers);
            folder1 = "";
            folder2 = "";
            name_page = "careers";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_careers, url + pathfile_careers, "", folder1, folder2, name_page, true, "همکاری و استخدام");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_careers, url + pathfile_careers, "", folder1, folder2, name_page, true, "همکاری و استخدام");
            }

            string pathfile_contact = "/contact-us";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_contact);
            folder1 = "";
            folder2 = "";
            name_page = "contact-us";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_contact, url + pathfile_contact, "", folder1, folder2, name_page, true, "تماس با ما");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_contact, url + pathfile_contact, "", folder1, folder2, name_page, true, "تماس با ما");
            }

            string pathfile_Company = "/Company";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_Company);
            folder1 = "";
            folder2 = "";
            name_page = "Company";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_Company, url + pathfile_Company, "", folder1, folder2, name_page, true, "دیده شوید");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_Company, url + pathfile_Company, "", folder1, folder2, name_page, true, "دیده شوید");
            }

            string pathfile_my_team = "/my-team";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_my_team);
            folder1 = "";
            folder2 = "";
            name_page = "my-team";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_my_team, url + pathfile_my_team, "", folder1, folder2, name_page, true, "تیم نوبین");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_my_team, url + pathfile_my_team, "", folder1, folder2, name_page, true, "تیم نوبین");
            }


            string pathfile_design_services = "/design_services";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_design_services);
            folder1 = "";
            folder2 = "";
            name_page = "design_services";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_design_services, url + pathfile_design_services, "", folder1, folder2, name_page, true, "خدمات طراحی");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_design_services, url + pathfile_design_services, "", folder1, folder2, name_page, true, "خدمات طراحی");
            }

            string pathfile_executive_services = "/executive_services";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_executive_services);
            folder1 = "";
            folder2 = "";
            name_page = "executive_services";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_executive_services, url + pathfile_executive_services, "", folder1, folder2, name_page, true, "خدمات اجرایی");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_executive_services, url + pathfile_executive_services, "", folder1, folder2, name_page, true, "خدمات اجرایی");
            }

            string pathfile_legal_services = "/legal_services";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_legal_services);
            folder1 = "";
            folder2 = "";
            name_page = "legal_services";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_legal_services, url + pathfile_legal_services, "", folder1, folder2, name_page, true, "خدمات حقوقی ساختمان");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_legal_services, url + pathfile_legal_services, "", folder1, folder2, name_page, true, "خدمات حقوقی ساختمان");
            }

            string pathfile_search = "/result-search";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_search);
            folder1 = "";
            folder2 = "";
            name_page = "result-search";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_search, url + pathfile_search, "", folder1, folder2, name_page, true, "جستجو");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_search, url + pathfile_search, "", folder1, folder2, name_page, true, "جستجو");
            }

            string pathfile_steel_stor = "/steel_stor";
             single_page = db.exact_url_Tables.Where(c => c.exact_url == url + pathfile_steel_stor);
            folder1 = "";
            folder2 = "";
            name_page = "steel_stor";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + pathfile_steel_stor, url + pathfile_steel_stor, "", folder1, folder2, name_page, true, "فروشگاه آهن آلات");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + pathfile_steel_stor, url + pathfile_steel_stor, "", folder1, folder2, name_page, true, "فروشگاه آهن آلات");
            }

            string pathfile_steel = "/steel";
            folder1 = "blog";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + pathfile_steel);
            
            name_page = "steel";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + "/" + folder1 + pathfile_steel,  url + "/" + folder1 +pathfile_steel, "", folder1, folder2, name_page, true, "وبلاگ آهن آلات");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 +pathfile_steel,  url + "/" + folder1 +pathfile_steel, "", folder1, folder2, name_page, true, "وبلاگ آهن آلات");
            }

            string pathfile_architecture = "/architecture";
            folder1 = "blog";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url ==  url + "/" + folder1 +pathfile_architecture);
            
            name_page = "architecture";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id,  url + "/" + folder1 + pathfile_architecture,  url + "/" + folder1 + pathfile_architecture, "", folder1, folder2, name_page, true, "وبلاگ معماری");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 + pathfile_architecture,  url + "/" + folder1 + pathfile_architecture, "", folder1, folder2, name_page, true, "وبلاگ معماری");
            }

            string pathfile_construction_civil = "/construction_civil";
            folder1 = "blog";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + pathfile_construction_civil);

            name_page = "construction_civil";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + "/" + folder1 + pathfile_construction_civil, url + "/" + folder1 + pathfile_construction_civil, "", folder1, folder2, name_page, true, "وبلاگ ساخت و ساز و عمران");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + "/" + folder1 + pathfile_construction_civil, url + "/" + folder1 + pathfile_construction_civil, "", folder1, folder2, name_page, true, "وبلاگ ساخت و ساز و عمران");
            }
            
            string pathfile_listnews = "/listnews";
            folder1 = "news";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url == url + "/" + folder1 + pathfile_listnews);

            name_page = "listnews";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, url + "/" + folder1 + pathfile_listnews, url + "/" + folder1 + pathfile_listnews, "", folder1, folder2, name_page, true, "اخبار تحلیلی");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(url + "/" + folder1 + pathfile_listnews, url + "/" + folder1 + pathfile_listnews, "", folder1, folder2, name_page, true, "اخبار تحلیلی");
            }

            //string pathfile_team = "/team";

            string pathfile_Login = "/Login";
            folder1 = "account";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url ==  url + "/" + folder1 + pathfile_Login);
            
            name_page = "Login";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id,  url + "/" + folder1 + pathfile_Login,  url + "/" + folder1 + pathfile_Login, "", folder1, folder2, name_page, true, "لاگین");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 + pathfile_Login,  url + "/" + folder1 + pathfile_Login, "", folder1, folder2, name_page, true, "لاگین");
            }

            string pathfile_Login_engineer = "/Login_engineer";
            folder1 = "account";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url ==  url + "/" + folder1 + pathfile_Login_engineer);
           
            name_page = "Login_engineer";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id,  url + "/" + folder1 + pathfile_Login_engineer,  url + "/" + folder1 + pathfile_Login_engineer, "", folder1, folder2, name_page, true, "لاگین مهندسین");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 + pathfile_Login_engineer,  url + "/" + folder1 + pathfile_Login_engineer, "", folder1, folder2, name_page, true, "لاگین مهندسین");
            }

            string pathfile_Login_user = "/Login_user";
            folder1 = "account";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url ==  url + "/" + folder1 + pathfile_Login_user);
            
            name_page = "Login_user";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id,  url + "/" + folder1 + pathfile_Login_user,  url + "/" + folder1 + pathfile_Login_user, "", folder1, folder2, name_page, true, "لاگین کارفرمایان");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 + pathfile_Login_user,  url + "/" + folder1 + pathfile_Login_user, "", folder1, folder2, name_page, true, "لاگین کارفرمایان");
            }

            string pathfile_Login_pages = "/Login_single_page";
            folder1 = "account";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url ==  url + "/" + folder1 + pathfile_Login_pages);
            folder1 = "account";
            folder2 = "";
            name_page = "Login_pages";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id,  url + "/" + folder1 + pathfile_Login_pages,  url + "/" + folder1 + pathfile_Login_pages, "", folder1, folder2, name_page, true, "صفحات لاگین");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 + pathfile_Login_pages,  url + "/" + folder1 + pathfile_Login_pages, "", folder1, folder2, name_page, true, "صفحات لاگین");
            }
            string pathfile_Regisration = "/Regisration";
            folder1 = "account";
            folder2 = "";
            single_page = db.exact_url_Tables.Where(c => c.exact_url ==  url + "/" + folder1 + pathfile_Regisration);
            
            name_page = "Regisration";
            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id,  url + "/" + folder1 + pathfile_Regisration,  url + "/" + folder1 + pathfile_Regisration, "", folder1, folder2, name_page, true, "صفحه ثبت نام");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table( url + "/" + folder1 + pathfile_Regisration,  url + "/" + folder1 + pathfile_Regisration, "", folder1, folder2, name_page, true, "صفحه ثبت نام");
            }

            success_message.Visible = true;
            warning_message.Visible = false;
            success_Label.Text = "  با موفقیت ثبت شد.";
        }

        protected void save_newpage_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string folder1 = txt_folder1.Text;
            string folder2 = txt_folder2.Text;
            string title = txt_title.Text;
            string address = txt_address.Text;
            string address_with_text = txt_address_with_text.Text;
            string url = "https://nobincommerce.com";
            var single_page = db.exact_url_Tables.Where(c => c.exact_url == address || c.url_with_text == address_with_text);


            if (single_page.Count() == 1)
            {
                db.P_Update_exact_url_Table(single_page.Single().id, address, address_with_text, title, folder1, folder2, address.Replace(url + "/" + folder1 + "/" + folder2 + "/", ""), true, "");
            }
            else if (single_page.Count() == 0)
            {
                db.P_Insert_exact_url_Table(address, address_with_text, title, folder1, folder2, address.Replace(url + "/" + folder1 + "/" + folder2 + "/", ""), true, "");
            }
            success_message.Visible = true;
            warning_message.Visible = false;
            success_Label.Text = "  با موفقیت ثبت شد.";
        }
    }
}