using System;
using System.Globalization;

namespace WebApplicationImpora2222025.Helper
{
    public static class Formatter
    {
        public static string ToPersianDate(DateTime? date)
        {
            try
            {
                return date.HasValue ? PersianDate.GetPersianDate(date.Value) : "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error in ToPersianDate: {0}", ex.Message));
                return date.HasValue ? date.Value.ToString("yyyy/MM/dd") : "";
            }
        }

        public static string ToHourMinute(TimeSpan? time)
        {
            if (!time.HasValue)
            {
                return "";
            }

            try
            {
                TimeSpan ts = time.Value;
                // Validate TimeSpan is within valid range (0 to 23:59:59.9999999)
                if (ts < TimeSpan.Zero || ts >= TimeSpan.FromDays(1))
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("ToHourMinute: Invalid TimeSpan '{0}'", ts));
                    return "";
                }

                // Manual formatting to avoid FormatException
                int hours = ts.Hours;
                int minutes = ts.Minutes;
                return string.Format("{0:D2}:{1:D2}", hours, minutes);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error in ToHourMinute: {0}", ex.Message));
                return "";
            }
        }

        public static string ToHourMinute(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("HH:mm") : "";
        }

        public static int SafeInt(int? value)
        {
            return value.HasValue ? value.Value : 0;
        }
    }
    ///////// <summary>
    ///////// Utility class for formatting dates and times, including Persian (Jalali) dates.
    ///////// </summary>
    //////public static class Formatter
    //////{
    //////    /// <summary>
    //////    /// Converts a nullable DateTime to Persian date format (YYYY/MM/DD).
    //////    /// </summary>
    //////    /// <param name="date">The Gregorian date to convert.</param>
    //////    /// <returns>Persian date string (e.g., "1404/03/18") or empty string if null or invalid.</returns>
    //////    public static string ToPersianDate(DateTime? date)
    //////    {
    //////        try
    //////        {
    //////            return date.HasValue ? PersianDate.GetPersianDate(date.Value) : "";
    //////        }
    //////        catch (Exception ex)
    //////        {
    //////            // Log error for debugging (C# 5.0 compatible)
    //////            System.Diagnostics.Debug.WriteLine(string.Format("Error in ToPersianDate: {0}", ex.Message));
    //////            return date.HasValue ? date.Value.ToString("yyyy/MM/dd") : ""; // Fallback to Gregorian
    //////        }
    //////    }

    //////    /// <summary>
    //////    /// Formats a nullable TimeSpan to 24-hour time (hh:mm).
    //////    /// </summary>
    //////    /// <param name="time">The TimeSpan to format.</param>
    //////    /// <returns>Time string (e.g., "14:30") or empty string if null.</returns>
    //////    public static string ToHourMinute(TimeSpan? time)
    //////    {
    //////        // CORRECT: Use lowercase "hh" for TimeSpan hours (00-23).
    //////        // The rest of the format string is correct.
    //////        return time.HasValue ? time.Value.ToString(@"hh\:mm") : "";
    //////    }

    //////    /// <summary>
    //////    /// Formats a nullable DateTime to 24-hour time (HH:mm).
    //////    /// </summary>
    //////    /// <param name="date">The DateTime to format.</param>
    //////    /// <returns>Time string (e.g., "14:30") or empty string if null.</returns>
    //////    public static string ToHourMinute(DateTime? date)
    //////    {
    //////        return date.HasValue ? date.Value.ToString("HH:mm") : "";
    //////    }

    //////    /// <summary>
    //////    /// Converts a nullable int to 0 if null.
    //////    /// </summary>
    //////    /// <param name="value">The nullable integer.</param>
    //////    /// <returns>The integer value or 0 if null.</returns>
    //////    public static int SafeInt(int? value)
    //////    {
    //////        return value.HasValue ? value.Value : 0;
    //////    }
    //////}

    /// <summary>
    /// کلاسی برای مدیریت و تبدیل تاریخ‌های شمسی (جلالی) و میلادی
    /// </summary>
    public static class PersianDate
    {
        private static readonly PersianCalendar PersianCal = new PersianCalendar();
        private static readonly CultureInfo PersianCulture = new CultureInfo("fa-IR");

        /// <summary>
        /// تاریخ فعلی سیستم را به فرمت شمسی (YYYY/MM/DD) برمی‌گرداند
        /// </summary>
        /// <returns>رشته‌ای با فرمت YYYY/MM/DD (مثل 1404/03/18)</returns>
        /// <exception cref="Exception">در صورت بروز خطا در تبدیل تاریخ</exception>
        public static string GetPersianDate()
        {
            try
            {
                DateTime now = DateTime.Now;
                return GetPersianDate(now);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در دریافت تاریخ شمسی", ex);
            }
        }

        /// <summary>
        /// تاریخ میلادی را به فرمت شمسی (YYYY/MM/DD) تبدیل می‌کند
        /// </summary>
        /// <param name="date">تاریخ میلادی</param>
        /// <returns>رشته‌ای با فرمت YYYY/MM/DD (مثل 1404/03/18)</returns>
        /// <exception cref="ArgumentException">اگر تاریخ خارج از محدوده تقویم شمسی باشد</exception>
        /// <exception cref="Exception">در صورت بروز خطا در تبدیل</exception>
        public static string GetPersianDate(DateTime date)
        {
            try
            {
                if (date < PersianCal.MinSupportedDateTime || date > PersianCal.MaxSupportedDateTime)
                {
                    throw new ArgumentException("تاریخ ورودی خارج از محدوده تقویم شمسی است.");
                }

                string persianDate = string.Format("{0}/{1:D2}/{2:D2}",
                    PersianCal.GetYear(date),
                    PersianCal.GetMonth(date),
                    PersianCal.GetDayOfMonth(date));
                return persianDate;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در تبدیل تاریخ میلادی به شمسی", ex);
            }
        }

        /// <summary>
        /// تاریخ شمسی را به تاریخ میلادی تبدیل می‌کند
        /// </summary>
        /// <param name="persianDate">رشته تاریخ شمسی با فرمت YYYY/MM/DD (مثل 1404/03/18)</param>
        /// <returns>رشته تاریخ میلادی با فرمت YYYY-MM-DD (مثل 2025-06-08)</returns>
        /// <exception cref="ArgumentNullException">اگر ورودی null یا خالی باشد</exception>
        /// <exception cref="ArgumentException">اگر فرمت یا مقادیر تاریخ نامعتبر باشد</exception>
        /// <exception cref="Exception">در صورت بروز خطا در تبدیل</exception>
        public static string ConvertPersianToGregorian(string persianDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(persianDate))
                    throw new ArgumentNullException("persianDate", "تاریخ شمسی نمی‌تواند خالی یا null باشد.");

                string[] parts = persianDate.Split('/');
                if (parts.Length != 3)
                    throw new ArgumentException("فرمت تاریخ باید YYYY/MM/DD باشد.");

                int year, month, day;
                if (!int.TryParse(parts[0], out year) ||
                    !int.TryParse(parts[1], out month) ||
                    !int.TryParse(parts[2], out day))
                    throw new ArgumentException("مقادیر سال، ماه یا روز نامعتبر است.");

                if (year < 1300 || year > 1500 || month < 1 || month > 12 || day < 1)
                    throw new ArgumentException("مقادیر سال، ماه یا روز خارج از محدوده است.");

                int daysInMonth = month <= 6 ? 31 : (month <= 11 ? 30 : (IsPersianLeapYear(year) ? 30 : 29));
                if (day > daysInMonth)
                    throw new ArgumentException("روز واردشده برای ماه موردنظر معتبر نیست.");

                DateTime gregorianDate = PersianCal.ToDateTime(year, month, day, 0, 0, 0, 0);
                return string.Format("{0:yyyy-MM-dd}", gregorianDate);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در تبدیل تاریخ شمسی به میلادی", ex); // Fixed trailing space
            }
        }

        /// <summary>
        /// نام روز هفته را به فارسی برای تاریخ مشخص برمی‌گرداند
        /// </summary>
        /// <param name="date">تاریخ موردنظر</param>
        /// <returns>نام روز هفته به فارسی (مثل شنبه)</returns>
        public static string GetDayOfWeekName(DateTime date)
        {
            return PersianCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }

        /// <summary>
        /// نام روز هفته فعلی را به فارسی برمی‌گرداند
        /// </summary>
        /// <returns>نام روز هفته به فارسی</returns>
        public static string GetCurrentDayOfWeekName()
        {
            return GetDayOfWeekName(DateTime.Now);
        }

        /// <summary>
        /// نام ماه شمسی را بر اساس شماره ماه برمی‌گرداند
        /// </summary>
        /// <param name="month">شماره ماه (1 تا 12 یا به‌صورت رشته مثل "01")</param>
        /// <returns>نام ماه به فارسی یا رشته خالی در صورت نامعتبر بودن</returns>
        public static string GetMonthName(string month)
        {
            int monthNumber;
            if (!int.TryParse(month, out monthNumber) || monthNumber < 1 || monthNumber > 12)
            {
                return string.Empty;
            }
            return PersianCulture.DateTimeFormat.GetMonthName(monthNumber);
        }

        /// <summary>
        /// نام ماه فعلی شمسی را برمی‌گرداند
        /// </summary>
        /// <returns>نام ماه به فارسی (مثل خرداد)</returns>
        public static string GetCurrentMonthName()
        {
            int currentMonth = PersianCal.GetMonth(DateTime.Now);
            return GetMonthName(currentMonth.ToString());
        }

        /// <summary>
        /// بررسی می‌کند که آیا سال شمسی کبیسه است یا خیر
        /// </summary>
        /// <param name="year">سال شمسی</param>
        /// <returns>True اگر سال کبیسه باشد، در غیر این صورت False</returns>
        private static bool IsPersianLeapYear(int year)
        {
            try
            {
                bool isLeap = PersianCal.IsLeapYear(year);
                return isLeap;
            }
            catch (Exception ex)
            {
                // Log error for debugging (C# 5.0 compatible)
                System.Diagnostics.Debug.WriteLine(string.Format("Error in IsPersianLeapYear: {0}", ex.Message));
                return false;
            }
        }
    }
}

//using System;
//using System.Globalization;

//namespace WebApplicationImpora2222025.Helper
//{

//    public static class Formatter
//    {
//        public static string ToPersianDate(DateTime? date)
//        {
//            try
//            {
//                return date.HasValue ? PersianDate.GetPersianDate(date.Value) : "";
//            }
//            catch
//            {
//                return "";
//            }
//        }

//        public static string ToHourMinute(TimeSpan? time)
//        {
//            return time.HasValue ? time.Value.ToString(@"hh\:mm") : "";
//        }

//        public static string ToHourMinute(DateTime? date)
//        {
//            return date.HasValue ? date.Value.ToString("HH:mm") : "";
//        }

//        public static int SafeInt(int? value)
//        {
//            return value.HasValue ? value.Value : 0;
//        }
//    }
//    /// <summary>
//    /// کلاسی برای مدیریت و تبدیل تاریخ‌های شمسی (جلالی) و میلادی
//    /// </summary>
//    public static class PersianDate
//    {
//        private static readonly PersianCalendar PersianCal = new PersianCalendar();
//        private static readonly CultureInfo PersianCulture = new CultureInfo("fa-IR");

//        /// <summary>
//        /// تاریخ فعلی سیستم را به فرمت شمسی (YYYY/MM/DD) برمی‌گرداند
//        /// </summary>
//        /// <returns>رشته‌ای با فرمت YYYY/MM/DD (مثل 1404/03/11)</returns>
//        /// <exception cref="Exception">در صورت بروز خطا در تبدیل تاریخ</exception>
//        public static string GetPersianDate()
//        {
//            try
//            {
//                DateTime now = DateTime.Now;
//                int year = PersianCal.GetYear(now);
//                int month = PersianCal.GetMonth(now);
//                int day = PersianCal.GetDayOfMonth(now);
//                return string.Format("{0}/{1:D2}/{2:D2}", year, month, day);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("خطا در دریافت تاریخ شمسی", ex);
//            }
//        }

//        /// <summary>
//        /// تاریخ شمسی را به تاریخ میلادی تبدیل می‌کند
//        /// </summary>
//        /// <param name="persianDate">رشته تاریخ شمسی با فرمت YYYY/MM/DD (مثل 1404/03/11)</param>
//        /// <returns>رشته تاریخ میلادی با فرمت YYYY-MM-DD (مثل 2025-06-01)</returns>
//        /// <exception cref="ArgumentNullException">اگر ورودی null یا خالی باشد</exception>
//        /// <exception cref="ArgumentException">اگر فرمت یا مقادیر تاریخ نامعتبر باشد</exception>
//        /// <exception cref="Exception">در صورت بروز خطا در تبدیل</exception>
//        public static string ConvertPersianToGregorian(string persianDate)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(persianDate))
//                {
//                    throw new ArgumentNullException("persianDate", "تاریخ شمسی نمی‌تواند خالی یا null باشد.");
//                }

//                // تجزیه رشته ورودی
//                string[] parts = persianDate.Split('/');
//                if (parts.Length != 3)
//                {
//                    throw new ArgumentException("فرمت تاریخ شمسی باید YYYY/MM/DD باشد.");
//                }

//                // تبدیل به عدد
//                int year, month, day;
//                if (!int.TryParse(parts[0], out year) ||
//                    !int.TryParse(parts[1], out month) ||
//                    !int.TryParse(parts[2], out day))
//                {
//                    throw new ArgumentException("مقادیر سال، ماه یا روز نامعتبر است.");
//                }

//                // بررسی محدوده معتبر
//                if (year < 1300 || year > 1500 || month < 1 || month > 12 || day < 1)
//                {
//                    throw new ArgumentException("مقادیر سال، ماه یا روز خارج از محدوده معتبر است.");
//                }

//                // بررسی تعداد روزهای ماه
//                int daysInMonth = month <= 6 ? 31 : (month <= 11 ? 30 : (IsPersianLeapYear(year) ? 30 : 29));
//                if (day > daysInMonth)
//                {
//                    throw new ArgumentException("روز واردشده برای ماه موردنظر معتبر نیست.");
//                }

//                // تبدیل به تاریخ میلادی
//                DateTime gregorianDate = PersianCal.ToDateTime(year, month, day, 0, 0, 0, 0);

//                // فرمت خروجی YYYY-MM-DD
//                return string.Format("{0:yyyy-MM-dd}", gregorianDate);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("خطا در تبدیل تاریخ شمسی به میلادی", ex);
//            }
//        }

//        /// <summary>
//        /// تاریخ میلادی را به فرمت شمسی (YYYY/MM/DD) تبدیل می‌کند
//        /// </summary>
//        /// <param name="date">تاریخ میلادی</param>
//        /// <returns>رشته‌ای با فرمت YYYY/MM/DD (مثل 1404/03/11)</returns>
//        /// <exception cref="ArgumentException">اگر تاریخ خارج از محدوده تقویم شمسی باشد</exception>
//        /// <exception cref="Exception">در صورت بروز خطا در تبدیل</exception>
//        public static string GetPersianDate(DateTime date)
//        {
//            try
//            {
//                // بررسی محدوده تاریخ
//                if (date < PersianCal.MinSupportedDateTime || date > PersianCal.MaxSupportedDateTime)
//                {
//                    throw new ArgumentException("تاریخ ورودی خارج از محدوده تقویم شمسی است.");
//                }

//                int year = PersianCal.GetYear(date);
//                int month = PersianCal.GetMonth(date);
//                int day = PersianCal.GetDayOfMonth(date);
//                return string.Format("{0}/{1:D2}/{2:D2}", year, month, day);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("خطا در تبدیل تاریخ میلادی به شمسی", ex);
//            }
//        }

//        /// <summary>
//        /// نام روز هفته را به فارسی برای تاریخ مشخص برمی‌گرداند
//        /// </summary>
//        /// <param name="date">تاریخ موردنظر</param>
//        /// <returns>نام روز هفته به فارسی (مثل شنبه)</returns>
//        public static string GetDayOfWeekName(DateTime date)
//        {
//            return PersianCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
//        }

//        /// <summary>
//        /// نام روز هفته فعلی را به فارسی برمی‌گرداند
//        /// </summary>
//        /// <returns>نام روز هفته به فارسی</returns>
//        public static string GetCurrentDayOfWeekName()
//        {
//            return GetDayOfWeekName(DateTime.Now);
//        }

//        /// <summary>
//        /// نام ماه شمسی را بر اساس شماره ماه برمی‌گرداند
//        /// </summary>
//        /// <param name="month">شماره ماه (1 تا 12 یا به‌صورت رشته مثل "01")</param>
//        /// <returns>نام ماه به فارسی یا رشته خالی در صورت نامعتبر بودن</returns>
//        public static string GetMonthName(string month)
//        {
//            int monthNumber;
//            if (!int.TryParse(month, out monthNumber) || monthNumber < 1 || monthNumber > 12)
//            {
//                return string.Empty;
//            }
//            return PersianCulture.DateTimeFormat.GetMonthName(monthNumber);
//        }

//        /// <summary>
//        /// نام ماه فعلی شمسی را برمی‌گرداند
//        /// </summary>
//        /// <returns>نام ماه به فارسی (مثل خرداد)</returns>
//        public static string GetCurrentMonthName()
//        {
//            int currentMonth = PersianCal.GetMonth(DateTime.Now);
//            return GetMonthName(currentMonth.ToString());
//        }

//        /// <summary>
//        /// بررسی می‌کند که آیا سال شمسی کبیسه است یا خیر
//        /// </summary>
//        /// <param name="year">سال شمسی</param>
//        /// <returns>True اگر سال کبیسه باشد، در غیر این صورت False</returns>
//        private static bool IsPersianLeapYear(int year)
//        {
//            try
//            {
//                return PersianCal.IsLeapYear(year);
//            }
//            catch
//            {
//                return false; // در صورت خطا، فرض می‌کنیم کبیسه نیست
//            }
//        }
//    }
//}