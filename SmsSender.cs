using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

namespace WebApplicationImpora2222025.Helper
{


    public static class SmsSender
    {
        // تنظیمات ثابت سرویس SMS
        private const string FromNumber = "5000267458";
        private const string Signature = "D4A5AF4F-DC56-4EB4-8AD7-A4DDE8C542C8";
        private const string BaseUrl = "http://login.parsgreen.com/UrlService/sendSMS.ashx";

        /// <summary>
        /// ارسال پیامک به یک شماره خاص
        /// </summary>
        /// <param name="toNumber">شماره مقصد (مثلاً 09124950875)</param>
        /// <param name="message">متن پیامک</param>
        public static void SendSms(string toNumber, string message)
        {
            try
            {
                // کدگذاری پیام برای URL
                string encodedMessage = Uri.EscapeDataString(message);

                // ساخت URL با string.Format
                string url = string.Format("{0}?from={1}&to={2}&text={3}&signature={4}",
                    BaseUrl, FromNumber, toNumber, encodedMessage, Signature);

                // برای دیباگ (اختیاری)
                // System.Diagnostics.Debug.WriteLine("URL: " + url);

                // ارسال درخواست به سرویس SMS
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";

                using (WebResponse resp = req.GetResponse())
                {
                    using (Stream st = resp.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(st, Encoding.UTF8))
                        {
                            string _responseStr = sr.ReadToEnd();
                            // می‌تونید پاسخ رو لاگ کنید
                            // System.Diagnostics.Debug.WriteLine("Response: " + _responseStr);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception("خطا در ارسال پیامک: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("خطای عمومی: " + ex.Message);
            }
        }
    }
}