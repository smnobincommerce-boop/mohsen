using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplicationImpora2222025.Helper
{
    public static class ErrorLogger
    {
        public static void LogToFile(Exception ex, string pageUrl = null)
        {
            string path = HttpContext.Current.Server.MapPath("~/Logs/errors.txt");

            try
            {
                // ایجاد پوشه Logs اگه وجود نداشته باشه
                string logDirectory = HttpContext.Current.Server.MapPath("~/Logs");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // نوشتن اطلاعات خطا توی فایل
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("تاریخ و زمان: " + DateTime.Now);
                    if (!string.IsNullOrEmpty(pageUrl))
                    {
                        writer.WriteLine("صفحه: " + pageUrl);
                    }
                    writer.WriteLine("پیام خطا: " + ex.Message);
                    writer.WriteLine("منبع: " + ex.Source);
                    writer.WriteLine("متد: " + ex.TargetSite);
                    writer.WriteLine("جزئیات (Stack Trace): " + ex.StackTrace);

                    // ثبت Inner Exception اگه وجود داشته باشه
                    if (ex.InnerException != null)
                    {
                        writer.WriteLine("--- Inner Exception ---");
                        writer.WriteLine("پیام: " + ex.InnerException.Message);
                        writer.WriteLine("منبع: " + ex.InnerException.Source);
                        writer.WriteLine("متد: " + ex.InnerException.TargetSite);
                        writer.WriteLine("جزئیات: " + ex.InnerException.StackTrace);
                    }

                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine();
                }
            }
            catch (Exception logEx)
            {
                // لاگ کردن خطای خود لاگینگ (مثلاً توی کنسول یا یه فایل دیگه)
                System.Diagnostics.Debug.WriteLine("خطا در ثبت لاگ: " + logEx.Message);
            }
        }

        public static void LogError(Exception ex, string pageUrl = null)
        {
            LogToFile(ex, pageUrl);
        }
    }
    //public static class ErrorLogger
    //{
    //    public static void LogToFile(Exception ex)
    //    {
    //        string path = HttpContext.Current.Server.MapPath("~/Logs/errors.txt");

    //        try
    //        {
    //            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Logs")))
    //            {
    //                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Logs"));
    //            }

    //            using (StreamWriter writer = new StreamWriter(path, true))
    //            {
    //                writer.WriteLine("--------------------------------------------------");
    //                writer.WriteLine("تاریخ: " + DateTime.Now);
    //                writer.WriteLine("پیام خطا: " + ex.Message);
    //                writer.WriteLine("منبع: " + ex.Source);
    //                writer.WriteLine("متد: " + ex.TargetSite);
    //                writer.WriteLine("جزئیات: " + ex.StackTrace);
    //                writer.WriteLine("--------------------------------------------------");
    //                writer.WriteLine();
    //            }
    //        }
    //        catch { /* در صورت بروز خطا در ثبت لاگ، خطا نادیده گرفته شود */ }
    //    }

    //    public static void LogError(Exception ex)
    //    {
    //        LogToFile(ex);
    //    }
    //}
}