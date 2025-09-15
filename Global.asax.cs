using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // ---------- App init ----------
            // اگر از Route/Bundle استفاده می‌کنید، نگه دارید
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // توجه: چون WebForms خالص است، نیازی به Ignore("{resource}.axd/{*pathInfo}") نیست
            // و اگر MVC رفرنس نشده باشد، می‌تواند خطا بدهد. بنابراین حذف شد.

            // ---------- Sitemap ----------
            try
            {
                SitemapGenerator.Start();
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "Global.Application_Start - SitemapGenerator.Start");
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            // در خاموشی برنامه، تایمر نقشه سایت را متوقف می‌کنیم
            try
            {
                SitemapGenerator.Stop();
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "Global.Application_End - SitemapGenerator.Stop");
            }
        }

        // در صورت نیاز، هندلر خطا را فعال کنید
        // void Application_Error(object sender, EventArgs e)
        // {
        //     // لاگ خطا و سایر اقدامات
        // }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Optimization;
//using System.Web.Routing;
//using System.Web.Security;
//using System.Web.SessionState;
//using Microsoft.AspNet.SignalR;
//using System.Net;
//using System.Text;
//using WebApplicationImpora2222025.Helper;
//using System.IO;

//namespace WebApplicationImpora2222025
//{
//    public class Global : HttpApplication
//    {
//        void Application_Start(object sender, EventArgs e)
//        {
//            // Code that runs on application startup
//            RouteConfig.RegisterRoutes(RouteTable.Routes);
//            BundleConfig.RegisterBundles(BundleTable.Bundles);
//            SitemapGenerator.Start();
//            //RouteTable.Routes.MapHubs();  // ثبت مسیر SignalR
//            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");
//        }
//        //void Application_Error(object sender, EventArgs e)
//        //{
//        //    //WebApplicationImpora2222025\App_Code\ErrorLogger.cs
//        //    Exception ex = Server.GetLastError();
//        //    if (ex != null)
//        //    {
//        //        ErrorLogger.LogError(ex);
//        //    }
//        //    Server.ClearError();
//        //    string url = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "5000267458" + "&to=" + 09124950875 + "&text=" + "نوبین\n" +  "یک خطا در سامانه" +"&signature=" + "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
           
//        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
//        //    System.Net.WebResponse resp = req.GetResponse();
//        //    var st = resp.GetResponseStream();
//        //    var sr = new System.IO.StreamReader(st, Encoding.UTF8);
//        //    string _responseStr = sr.ReadToEnd();
//        //    sr.Close();
//        //    resp.Close();
          
//        //    // هدایت به صفحه خطا
//        //    Response.Redirect("~/ErrorPage.aspx");
//        //}
//        public class MvcApplication : System.Web.HttpApplication
//        {
//            protected void Application_Start()
//            {
//                // ... other startup code like AreaRegistration.RegisterAllAreas();

//                // Start the sitemap generator
//                string rootPath = Server.MapPath("~");
//                ModernSitemapGenerator.Start(rootPath);
//            }

//            protected void Application_End()
//            {
//                // Properly stop the timer when the application shuts down
//                ModernSitemapGenerator.Stop();
//            }
//        }

//        //void Application_Error(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        // گرفتن خطای اصلی
//        //        Exception ex = Server.GetLastError();
//        //        if (ex != null)
//        //        {
//        //            // گرفتن آدرس صفحه
//        //            string pageUrl = HttpContext.Current.Request.Url.ToString();

//        //            // لاگ کردن خطا با آدرس صفحه
//        //            ErrorLogger.LogError(ex, pageUrl);

//        //            // پاک کردن خطا از سرور
//        //            Server.ClearError();

//        //            // ارسال SMS با اطلاعات خطا و آدرس صفحه
//        //            string errorMessage = "نوبین\nیک خطا در سامانه";
//        //            SmsSender.SendSms("09124950875", errorMessage);

//        //        }

//        //        // هدایت به صفحه خطا
//        //        Response.Redirect("~/ErrorPage.aspx");
//        //    }
//        //    catch (Exception unexpectedEx)
//        //    {
//        //        // لاگ کردن خطای خود Application_Error
//        //        ErrorLogger.LogError(unexpectedEx, "Application_Error");
//        //        Response.Redirect("~/ErrorPage.aspx");
//        //    }
//        //}
//    }
//}