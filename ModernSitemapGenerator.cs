using System;
using System.Collections.Generic;
using System.Globalization; // برای PersianCalendar
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

// اطمینان حاصل کنید که این using وجود دارد
using WebApplicationImpora2222025.Helper;

namespace WebApplicationImpora2222025.Helper
{
    /// <summary>
    /// A modern sitemap generator fully compatible with C# 5.
    /// Handles Persian date strings from the database by converting them to Gregorian dates.
    /// </summary>
    public static class ModernSitemapGenerator
    {
        private static System.Timers.Timer _timer;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static string _physicalRootPath;
        private static readonly string _baseUrl = "https://nobincommerce.com/";
        private static readonly XNamespace _xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";

        public static void Start(string physicalRootPath)
        {
            if (_timer != null) return;
            if (physicalRootPath == null) throw new ArgumentNullException("physicalRootPath");

            _physicalRootPath = physicalRootPath;
            Task.Run(() => GenerateSitemapAsync());

            _timer = new System.Timers.Timer(TimeSpan.FromHours(24).TotalMilliseconds);
            _timer.Elapsed += TimerCallback;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private static void TimerCallback(object sender, ElapsedEventArgs e)
        {
            Task.Run(() => GenerateSitemapAsync());
        }

        public static void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            _semaphore.Dispose();
        }

        public static async Task GenerateSitemapAsync()
        {
            if (!await _semaphore.WaitAsync(0)) return;

            try
            {
                var sitemapEntries = new List<SitemapEntry>();
                sitemapEntries.AddRange(GetStaticPages());

                using (var db = new DataClasses1DataContext())
                {
                    // Fetch blog posts
                    var blogPosts = db.Paper_tbls
                        .Where(p => p.subject_paper != null && p.delet_ == false && p.news == null)
                        .Select(p => new { p.id, p.date_edit })
                        .ToList();

                    foreach (var post in blogPosts)
                    {
                        // *** FIX: Convert Persian date string to DateTime? ***
                        DateTime? lastModifiedDate = ParsePersianDateString(post.date_edit);
                        sitemapEntries.Add(new SitemapEntry(
                            string.Format("{0}blog/paper?I={1}", _baseUrl, post.id),
                            "daily",
                            "0.7",
                            lastModifiedDate // پاس دادن تاریخ میلادی تبدیل شده
                        ));
                    }

                    // Fetch news articles
                    var newsArticles = db.Paper_tbls
                        .Where(p => p.subject_paper != null && p.delet_ == false && p.news == true)
                        .Select(p => new { p.id, p.date_edit })
                        .ToList();

                    foreach (var news in newsArticles)
                    {
                        // *** FIX: Convert Persian date string to DateTime? ***
                        DateTime? lastModifiedDate = ParsePersianDateString(news.date_edit);
                        sitemapEntries.Add(new SitemapEntry(
                            string.Format("{0}news/detailnews?I={1}", _baseUrl, news.id),
                            "daily",
                            "0.8",
                            lastModifiedDate
                        ));
                    }

                    // Fetch user profiles
                    var userProfiles = db.User_tbls
                        .Where(u => u.Comfirm == true && u.Access == true && u.show_profile == true)
                        .Select(u => new { u.id, u.Lastedit }) // فرض می‌کنیم Lastedit هم رشته شمسی است
                        .ToList();

                    foreach (var profile in userProfiles)
                    {
                        // *** FIX: Convert Persian date string to DateTime? ***
                        DateTime? lastModifiedDate = ParsePersianDateString(profile.Lastedit);
                        sitemapEntries.Add(new SitemapEntry(
                            string.Format("{0}my-page?staff={1}", _baseUrl, profile.id),
                            "monthly",
                            "0.6",
                            lastModifiedDate
                        ));
                    }
                }

                var sitemapDocument = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement(_xmlns + "urlset",
                        from entry in sitemapEntries
                        select new XElement(_xmlns + "url",
                            new XElement(_xmlns + "loc", Uri.EscapeUriString(entry.Location)),
                            new XElement(_xmlns + "lastmod", entry.LastModified.ToString("yyyy-MM-dd")),
                            new XElement(_xmlns + "changefreq", entry.ChangeFrequency),
                            new XElement(_xmlns + "priority", entry.Priority)
                        )
                    )
                );

                string filePath = Path.Combine(_physicalRootPath, "sitemap.xml");
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                {
                    using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
                    {
                        await writer.WriteAsync(sitemapDocument.ToString());
                    }
                }

                ErrorLogger.LogError(new Exception(string.Format("Sitemap generated successfully at {0}", DateTime.Now)), "SitemapGenerator");
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "SitemapGenerator");
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// متد کمکی برای تبدیل رشته تاریخ شمسی به تاریخ میلادی
        /// از کلاس PersianDate که خودتان ارائه دادید استفاده می‌کند
        /// </summary>
        /// <param name="persianDateStr">رشته تاریخ شمسی مانند "1403/03/18"</param>
        /// <returns>یک شی DateTime? یا null در صورت خطا</returns>
        private static DateTime? ParsePersianDateString(string persianDateStr)
        {
            if (string.IsNullOrWhiteSpace(persianDateStr))
            {
                return null;
            }

            try
            {
                // از متد کمکی شما برای تبدیل به تاریخ میلادی استفاده می‌کنیم
                // توجه: متد شما یک رشته برمی‌گرداند، پس باید آن را به DateTime پارس کنیم
                string gregorianString = PersianDate.ConvertPersianToGregorian(persianDateStr);
                return DateTime.Parse(gregorianString, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                // اگر تبدیل تاریخ با خطا مواجه شد، آن را لاگ می‌کنیم ولی کل فرآیند را متوقف نمی‌کنیم
                ErrorLogger.LogError(ex, "Failed to parse Persian date for sitemap: " + persianDateStr);
                return null; // در صورت خطا، مقدار null برمی‌گردانیم
            }
        }

        private static IEnumerable<SitemapEntry> GetStaticPages()
        {
            // این بخش بدون تغییر باقی می‌ماند
            return new List<SitemapEntry>
            {
                new SitemapEntry(_baseUrl, "daily", "1.0"),
                new SitemapEntry(string.Format("{0}about_us", _baseUrl), "yearly", "0.8"),
                // ... بقیه صفحات استاتیک
            };
        }
    }

    // کلاس SitemapEntry بدون تغییر باقی می‌ماند
    public class SitemapEntry
    {
        public string Location { get; private set; }
        public string ChangeFrequency { get; private set; }
        public string Priority { get; private set; }
        public DateTime LastModified { get; private set; }

        public SitemapEntry(string location, string changeFrequency, string priority, DateTime? lastModified = null)
        {
            Location = location;
            ChangeFrequency = changeFrequency;
            Priority = priority;
            LastModified = lastModified.HasValue ? lastModified.Value : DateTime.UtcNow;
        }
    }
}