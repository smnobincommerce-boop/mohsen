using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web;
using System.Web.Hosting;
using System.Xml;

namespace WebApplicationImpora2222025.Helper
{
    public class SitemapGenerator
    {
        private static readonly object _lock = new object();
        private static bool _isRunning = false;
        private static Timer _timer;

        /// <summary>
        /// Starts the sitemap generation timer.
        /// </summary>
        public static void Start()
        {
            if (_timer == null)
            {
                // Generate sitemap immediately on start
                GenerateSitemap();

                // Set up timer to run every 24 hours
                _timer = new Timer(TimeSpan.FromDays(1).TotalMilliseconds); // 24 hours
                _timer.Elapsed += TimerCallback;
                _timer.AutoReset = true;
                _timer.Start();
            }
        }

        /// <summary>
        /// Stops the sitemap generation timer.
        /// </summary>
        public static void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
        }

        private static void TimerCallback(object sender, ElapsedEventArgs e)
        {
            GenerateSitemap();
        }

        /// <summary>
        /// Generates a sitemap XML file for the website.
        /// </summary>
        public static void GenerateSitemap()
        {
            lock (_lock)
            {
                if (_isRunning) return;
                _isRunning = true;

                try
                {
                    string filePath = HostingEnvironment.MapPath("~/Sitemap_Index.xml");
                    if (string.IsNullOrEmpty(filePath))
                    {
                        ErrorLogger.LogError(new Exception("HostingEnvironment.MapPath returned null for ~/Sitemap_Index.xml"), "SitemapGenerator - MapPath");
                        return;
                    }

                    if (File.Exists(filePath))
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (IOException ex)
                        {
                            ErrorLogger.LogError(ex, "SitemapGenerator - File Deletion");
                        }
                    }

                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Encoding = new UTF8Encoding(false),
                        Indent = true,
                        IndentChars = "    "
                    };

                    using (XmlWriter writer = XmlWriter.Create(filePath, settings))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                        string baseUrl = "https://nobincommerce.com/";

                        using (DataClasses1DataContext db = new DataClasses1DataContext())
                        {
                            // صفحه اصلی
                            AddUrl(writer, baseUrl, "~/index", "daily", "1.0", null);

                            AddUrl(writer, string.Format("{0}about_us", baseUrl), "~/about_us", "yearly", "0.8", null);
                            AddUrl(writer, string.Format("{0}careers", baseUrl), "~/careers", "monthly", "0.7", null);
                            AddUrl(writer, string.Format("{0}contact-us", baseUrl), "~/contact-us", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}Customs-Clearance", baseUrl), "~/Customs-Clearance", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}International-Shipping-Logistics", baseUrl), "~/International-Shipping-Logistics", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}Risk-Management", baseUrl), "~/Risk-Management", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}result-search", baseUrl), "~/result-search", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}rules", baseUrl), "~/rules", "yearly", "0.5", null);
                            AddUrl(writer, string.Format("{0}Sourcing-and-Procurement", baseUrl), "~/Sourcing-and-Procurement", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}Registering-an-imported-car-with-a-national-code", baseUrl), "~/Registering-an-imported-car-with-a-national-code", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}Trade-Academy", baseUrl), "~/Trade-Academy", "monthly", "0.9", null);

                            // اصلاح ناسازگاری مسیر وبلاگ (loc و filePath یکسان شد)
                            AddUrl(writer, string.Format("{0}blog/Educational-and-How-To-Content", baseUrl), "~/blog/Educational-and-How-To-Content", "weekly", "0.8", null);

                            AddUrl(writer, string.Format("{0}account/Login", baseUrl), "~/account/Login", "yearly", "0.6", null);
                            AddUrl(writer, string.Format("{0}account/Regisration", baseUrl), "~/account/Regisration", "monthly", "0.8", null);

                            // --- New pages ---
                            AddUrl(writer, string.Format("{0}Currency-Allocation-for-Imports", baseUrl), "~/Currency-Allocation-for-Imports", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}Purchasing-and-Allocating-Foreign-Exchange-for-Imports", baseUrl), "~/Purchasing-and-Allocating-Foreign-Exchange-for-Imports", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}Goods-Import-Registration", baseUrl), "~/Goods-Import-Registration", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}Comprehensive-Guide-to-International-Transportation", baseUrl), "~/Comprehensive-Guide-to-International-Transportation", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}Foreign-Exchange-Commitment-Clearance-for-Imports-and-Exports", baseUrl), "~/Foreign-Exchange-Commitment-Clearance-for-Imports-and-Exports", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}Obtaining-a-Commercial-Card", baseUrl), "~/Obtaining-a-Commercial-Card", "monthly", "0.9", null);

                            // --- English (En) pages ---
                            AddUrl(writer, string.Format("{0}En/indexEn", baseUrl), "~/En/indexEn", "weekly", "1.0", null);

                            AddUrl(writer, string.Format("{0}En/about_us", baseUrl), "~/En/about_us", "yearly", "0.8", null);
                            AddUrl(writer, string.Format("{0}En/careers", baseUrl), "~/En/careers", "monthly", "0.7", null);
                            AddUrl(writer, string.Format("{0}En/contact-us", baseUrl), "~/En/contact-us", "monthly", "0.8", null);

                            AddUrl(writer, string.Format("{0}En/Sourcing-and-Procurement", baseUrl), "~/En/Sourcing-and-Procurement", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}En/International-Shipping-Logistics", baseUrl), "~/En/International-Shipping-Logistics", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}En/Customs-Clearance", baseUrl), "~/En/Customs-Clearance", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}En/Risk-Management", baseUrl), "~/En/Risk-Management", "monthly", "0.8", null);
                            AddUrl(writer, string.Format("{0}En/Registering-an-imported-car-with-a-national-code", baseUrl), "~/En/Registering-an-imported-car-with-a-national-code", "monthly", "0.9", null);
                            AddUrl(writer, string.Format("{0}En/Obtaining-a-Commercial-Card", baseUrl), "~/En/Obtaining-a-Commercial-Card", "monthly", "0.9", null);

                            // صفحات داینامیک
                            db.Paper_tbls
                                .Where(c => c.subject_paper != null && c.delet_ == false && c.news == null)
                                .ToList()
                                .ForEach(item =>
                                {
                                    DateTime? lastMod = null;
                                    try
                                    {
                                        if (item.date_edit != null)
                                            lastMod = Convert.ToDateTime(item.date_edit);
                                    }
                                    catch { }

                                    AddUrl(writer, string.Format("{0}blog/paper?I={1}", baseUrl, item.id), null, "daily", "0.64", lastMod);
                                });

                            db.Paper_tbls
                                .Where(c => c.subject_paper != null && c.delet_ == false && c.news == true)
                                .ToList()
                                .ForEach(item =>
                                {
                                    DateTime? lastMod = null;
                                    try
                                    {
                                        if (item.date_edit != null)
                                            lastMod = Convert.ToDateTime(item.date_edit);
                                    }
                                    catch { }

                                    AddUrl(writer, string.Format("{0}news/detailnews?I={1}", baseUrl, item.id), null, "daily", "0.64", lastMod);
                                });

                            db.User_tbls
                                .Where(c => c.Comfirm == true && c.Access == true && c.show_profile == true)
                                .ToList()
                                .ForEach(item =>
                                {
                                    DateTime? lastMod = null;
                                    try
                                    {
                                        if (item.Lastedit != null)
                                            lastMod = Convert.ToDateTime(item.Lastedit);
                                    }
                                    catch { }

                                    AddUrl(writer, string.Format("{0}my-page?staff={1}", baseUrl, item.id), null, "monthly", "0.7", lastMod);
                                });
                        }

                        writer.WriteEndElement();   // </urlset>
                        writer.WriteEndDocument();
                        writer.Flush();
                    }

                    // توجه: بهتر است متد جدا برای لاگ موفقیت داشته باشی
                    ErrorLogger.LogError(new Exception(string.Format("Sitemap با موفقیت در {0} ساخته شد", DateTime.Now)), "SitemapGenerator");
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError(ex, "SitemapGenerator");
                }
                finally
                {
                    _isRunning = false;
                }
            }
        }

        private static void AddUrl(XmlWriter writer, string loc, string filePath, string changeFreq, string priority, DateTime? lastMod = null)
        {
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", loc);

            bool wroteLastMod = false;

            if (filePath != null)
            {
                try
                {
                    string physicalPath = HostingEnvironment.MapPath(filePath);
                    if (!string.IsNullOrEmpty(physicalPath) && File.Exists(physicalPath))
                    {
                        DateTime dt = File.GetLastWriteTimeUtc(physicalPath);
                        writer.WriteElementString("lastmod", dt.ToString("yyyy-MM-dd"));
                        wroteLastMod = true;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError(ex, string.Format("SitemapGenerator - AddUrl for {0}", filePath));
                }
            }

            if (!wroteLastMod)
            {
                if (lastMod.HasValue)
                {
                    writer.WriteElementString("lastmod", lastMod.Value.ToUniversalTime().ToString("yyyy-MM-dd"));
                }
                else
                {
                    // fallback: اگر تاریخ دیگری نداریم
                    writer.WriteElementString("lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"));
                }
            }

            writer.WriteElementString("changefreq", changeFreq);
            writer.WriteElementString("priority", priority);
            writer.WriteEndElement(); // </url>
        }
    }
}
