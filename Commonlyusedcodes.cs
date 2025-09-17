using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Net;
using System.IO;
using System.Text;


namespace WebApplicationImpora2222025.Helper
{
    public class Commonlyusedcodes
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
        public static string GetUserIPAddress()
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            return ip;
        }
        public static int GetUsermanger()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var manger = db.User_tbls.Where(c => c.Role == "مدیر" || c.Role== "مدیر فنی").OrderByDescending(c=> c.id);
            if (manger.Count() > 0)
            {
                int Id_manger = manger.First().id;

                return Id_manger;
            }
            else
            {
                return 0;
            }

        }
        //public static string Dateshamsi()
        //{
        //   try
        //{
        //    DateTime now = DateTime.Now;
        //    PersianCalendar pc = new PersianCalendar();
        //    int year = pc.GetYear(now);
        //    int month = pc.GetMonth(now);
        //    int day = pc.GetDayOfMonth(now);
        //    return string.Format("{0:0000}/{1:00}/{2:00}", year, month, day);
        //}
        //catch 
        //{
        //    // در صورت بروز خطا، پیام خطا را برمی‌گرداند
        //    return "0";
        //}

          
        //}
        //public static string Dateshamsiconverter(DateTime a)
        //{
        //    try
        //    {
        //        PersianCalendar pc = new PersianCalendar();
        //        int year = pc.GetYear(a);
        //        int month = pc.GetMonth(a);
        //        int day = pc.GetDayOfMonth(a);
        //        return string.Format("{0:0000}/{1:00}/{2:00}", year, month, day);
        //    }
        //    catch 
        //    {
        //        // در صورت بروز خطا، پیام خطا را برمی‌گرداند
        //        return "0";
        //    }
        //}
       
        public static string code()
        {
            try
            {
                string numbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                string characters = numbers;

                int length = 10;
                string otp = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }


                return otp;
            }
            catch
            {
                return "0";
            }
        }       
        public static string dahgan()
        {
            try
            {
                string numbers = "123456789";

                string characters = numbers;

                int length = 1;
                string otp = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }


                return otp;
            }
            catch
            {
                return "0";
            }
        }
        public static string yekan()
        {
            try
            {
                string numbers = "1234567890";

                string characters = numbers;

                int length = 1;
                string otp = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }


                return otp;
            }
            catch
            {
                return "0";
            }
        }
        public static string Number_pic(string a)
        {
            string consept = string.Empty;
            int number = Convert.ToInt32(a) - 10;
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "number_pic" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "consept_pic" });

            MyDataTable.Rows.Add("10", "97");
            MyDataTable.Rows.Add("11", "104");
            MyDataTable.Rows.Add("12", "77");
            MyDataTable.Rows.Add("13", "72");
            MyDataTable.Rows.Add("14", "43");
            MyDataTable.Rows.Add("15", "51");
            MyDataTable.Rows.Add("16", "40");
            MyDataTable.Rows.Add("17", "56");
            MyDataTable.Rows.Add("18", "58");
            MyDataTable.Rows.Add("19", "20");
            MyDataTable.Rows.Add("20", "69");
            MyDataTable.Rows.Add("21", "43");
            MyDataTable.Rows.Add("22", "82");
            MyDataTable.Rows.Add("23", "13");
            MyDataTable.Rows.Add("24", "74");
            MyDataTable.Rows.Add("25", "71");
            MyDataTable.Rows.Add("26", "18");
            MyDataTable.Rows.Add("27", "51");
            MyDataTable.Rows.Add("28", "80");
            MyDataTable.Rows.Add("29", "95");
            MyDataTable.Rows.Add("30", "46");
            MyDataTable.Rows.Add("31", "13");
            MyDataTable.Rows.Add("32", "91");
            MyDataTable.Rows.Add("33", "104");
            MyDataTable.Rows.Add("34", "18");
            MyDataTable.Rows.Add("35", "38");
            MyDataTable.Rows.Add("36", "54");
            MyDataTable.Rows.Add("37", "94");
            MyDataTable.Rows.Add("38", "74");
            MyDataTable.Rows.Add("39", "46");
            MyDataTable.Rows.Add("40", "13");
            MyDataTable.Rows.Add("41", "24");
            MyDataTable.Rows.Add("42", "45");
            MyDataTable.Rows.Add("43", "68");
            MyDataTable.Rows.Add("44", "30");
            MyDataTable.Rows.Add("45", "31");
            MyDataTable.Rows.Add("46", "70");
            MyDataTable.Rows.Add("47", "72");
            MyDataTable.Rows.Add("48", "74");
            MyDataTable.Rows.Add("49", "14");
            MyDataTable.Rows.Add("50", "20");
            MyDataTable.Rows.Add("51", "21");
            MyDataTable.Rows.Add("52", "23");
            MyDataTable.Rows.Add("53", "24");
            MyDataTable.Rows.Add("54", "25");
            MyDataTable.Rows.Add("55", "33");
            MyDataTable.Rows.Add("56", "41");
            MyDataTable.Rows.Add("57", "50");
            MyDataTable.Rows.Add("58", "59");
            MyDataTable.Rows.Add("59", "62");
            MyDataTable.Rows.Add("60", "66");
            MyDataTable.Rows.Add("61", "68");
            MyDataTable.Rows.Add("62", "68");
            MyDataTable.Rows.Add("63", "69");
            MyDataTable.Rows.Add("64", "75");
            MyDataTable.Rows.Add("65", "75");
            MyDataTable.Rows.Add("66", "79");
            MyDataTable.Rows.Add("67", "84");
            MyDataTable.Rows.Add("68", "99");
            MyDataTable.Rows.Add("69", "94");
            MyDataTable.Rows.Add("70", "59");
            MyDataTable.Rows.Add("71", "33");
            MyDataTable.Rows.Add("72", "84");
            MyDataTable.Rows.Add("73", "98");
            MyDataTable.Rows.Add("74", "49");
            MyDataTable.Rows.Add("75", "103");
            MyDataTable.Rows.Add("76", "26");
            MyDataTable.Rows.Add("77", "69");
            MyDataTable.Rows.Add("78", "102");
            MyDataTable.Rows.Add("79", "27");
            MyDataTable.Rows.Add("80", "72");
            MyDataTable.Rows.Add("81", "48");
            MyDataTable.Rows.Add("82", "45");
            MyDataTable.Rows.Add("83", "87");
            MyDataTable.Rows.Add("84", "49");
            MyDataTable.Rows.Add("85", "73");
            MyDataTable.Rows.Add("86", "80");
            MyDataTable.Rows.Add("87", "36");
            MyDataTable.Rows.Add("88", "21");
            MyDataTable.Rows.Add("89", "46");
            MyDataTable.Rows.Add("90", "28");
            MyDataTable.Rows.Add("91", "35");
            MyDataTable.Rows.Add("92", "92");
            MyDataTable.Rows.Add("93", "69");
            MyDataTable.Rows.Add("94", "81");
            MyDataTable.Rows.Add("95", "82");
            MyDataTable.Rows.Add("96", "41");
            MyDataTable.Rows.Add("97", "84");
            MyDataTable.Rows.Add("98", "69");
            MyDataTable.Rows.Add("99", "61");

            consept = MyDataTable.Rows[number].ItemArray[1].ToString();

            return consept;
        }
        public static string code_6number()
        {
            try
            {
                //string numbers = "1234567890";

                string characters = "0987654321";

                int length = 6;
                string otp = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }


                return otp;
            }
            catch
            {
                return "0";
            }
        }
        public static string TrimString(string str)
        {
            if (str.Length > 5)
            {
                return str.Substring(str.Length - 5); // گرفتن 5 کاراکتر آخر
            }
            return str; // اگر طول رشته کمتر یا مساوی 5 باشد، همان رشته را برمی‌گرداند
        }
        //public string GetUserIp()
        //{
        //    var visitorsIpAddr = string.Empty;

        //    if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        //    {
        //        visitorsIpAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    }
        //    else if (!string.IsNullOrEmpty(Request.UserHostAddress))
        //    {
        //        visitorsIpAddr = Request.UserHostAddress;
        //    }

        //    return visitorsIpAddr;
        //}
    }
}