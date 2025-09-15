<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Trade-Academy.aspx.cs" Inherits="WebApplicationImpora2222025.Trade_Academy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Base -->
    <meta charset="utf-8" />
    <meta http-equiv="content-language" content="fa-IR" />
    <meta name="language" content="fa-IR" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="robots" content="INDEX,FOLLOW,MAX-IMAGE-PREVIEW:LARGE" />
    <link rel="canonical" href="https://www.nobincommerce.com/Trade-Academy" />

    <!-- SEO -->
    <meta name="description" content="دوره‌های کاربردی و مرحله‌به‌مرحله برای سامانه جامع تجارت، ثبت سفارش، تخصیص/منشأ ارز، حمل، بیمه، EPL و ترخیص؛ همراه چک‌لیست، تمپلیت اسناد و پشتیبانی ۳۰ روزه." />
    <meta name="format-detection" content="telephone=no" />

    <!-- Open Graph -->
    <meta property="og:title" content="آموزش سامانه‌های تجارت و گمرک | نوبین گستر پایا" />
    <meta property="og:description" content="از ثبت سفارش تا رفع تعهد ارزی را استاندارد اجرا کنید؛ آموزش‌های عملی NTSW/EPL با چک‌لیست و تمپلیت اسناد." />
    <meta property="og:type" content="website" />
    <meta property="og:site_name" content="Nobin Gostar Paya Group | Nobin Commerce" />
    <meta property="og:url" content="https://www.nobincommerce.com/Trade-Academy" />
    <meta property="og:image" content="https://www.nobincommerce.com/img/NLogo-En.svg" />
    <meta property="og:image:alt" content="آموزش سامانه‌های تجارت و گمرک نوبین گستر پایا" />
    <meta property="og:locale" content="fa_IR" />

    <!-- Twitter -->
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:title" content="آموزش سامانه‌های تجارت و گمرک | نوبین گستر پایا" />
    <meta name="twitter:description" content="آموزش مرحله‌به‌مرحله NTSW/EPL با چک‌لیست و تمپلیت اسناد—از ثبت سفارش تا ترخیص و رفع تعهد ارزی." />
    <meta name="twitter:site" content="@Impora1" />

    <!-- WebPage JSON-LD -->
    <script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "WebPage",
  "name": "آموزش سامانه‌های تجارت و گمرک | نوبین گستر پایا",
  "url": "https://www.nobincommerce.com/Trade-Academy",
  "inLanguage": "fa-IR",
  "description": "آموزش‌های کاربردی و نتیجه‌محور برای سامانه جامع تجارت (NTSW)، ثبت سفارش، تخصیص/منشأ ارز، حمل و بیمه، اظهار در EPL و ترخیص—همراه چک‌لیست‌های اجرایی، تمپلیت اسناد و پشتیبانی ۳۰ روزه.",
  "isPartOf": {
    "@type": "WebSite",
    "name": "Nobin Gostar Paya",
    "url": "https://www.nobincommerce.com"
  }
}
    </script>

    <!-- BreadcrumbList JSON-LD -->
    <script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "BreadcrumbList",
  "itemListElement": [
    {
      "@type": "ListItem",
      "position": 1,
      "name": "خانه",
      "item": "https://www.nobincommerce.com"
    },
    {
      "@type": "ListItem",
      "position": 2,
      "name": "آموزش",
      "item": "https://www.nobincommerce.com/Trade-Academy"
    }
  ]
}
    </script>

    <!-- FAQPage JSON-LD -->
    <script type="application/ld+json">
{
  "@context":"https://schema.org",
  "@type":"FAQPage",
  "mainEntity":[
    {"@type":"Question","name":"سامانه جامع تجارت چیست و از کجا شروع کنم؟","acceptedAnswer":{"@type":"Answer","text":"«سامانه جامع تجارت» درگاه یکپارچه تجارت خارجی است که از ایجاد نقش تا پیگیری وضعیت ثبت سفارش و گزارش‌گیری را پوشش می‌دهد."}},
    {"@type":"Question","name":"مراحل فعال‌سازی کارت بازرگانی چیست؟","acceptedAnswer":{"@type":"Answer","text":"آماده‌سازی مدارک ثبتی/هویتی و مالیاتی، ثبت درخواست در اتاق بازرگانی و اتصال به سامانه‌ها."}},
    {"@type":"Question","name":"برای ایجاد نمایندگی معتبر چه مدارکی لازم است؟","acceptedAnswer":{"@type":"Answer","text":"قرارداد دو‌زبانه، احراز اصالت، تعیین قلم کالا و ثبت محدوده فعالیت."}},
    {"@type":"Question","name":"شناسه کالای وارداتی چگونه اخذ/به‌روزرسانی می‌شود؟","acceptedAnswer":{"@type":"Answer","text":"بر پایه HS و مشخصات فنی؛ با ثبت برند/مدل، استانداردها و کاتالوگ فنی."}},
    {"@type":"Question","name":"شناسه فروشنده خارجی به چه کار می‌آید؟","acceptedAnswer":{"@type":"Answer","text":"برای اعتبارسنجی تأمین‌کننده و تسهیل ثبت سفارش و پرداخت‌ها ضروری است."}},
    {"@type":"Question","name":"سهمیه واردات چگونه بررسی و افزایش داده می‌شود؟","acceptedAnswer":{"@type":"Answer","text":"با کنترل سقف‌ها و محدودیت‌های تعرفه، و ارائه مستندات برای افزایش سقف."}},
    {"@type":"Question","name":"ثبت سفارش کالا شامل چه مراحلی است؟","acceptedAnswer":{"@type":"Answer","text":"تعریف مشخصات کالا، Incoterms، مبدا/مقصد و بارگذاری پیش‌فاکتور بدون خطا."}},
    {"@type":"Question","name":"تخصیص ارز چگونه انجام می‌شود؟","acceptedAnswer":{"@type":"Answer","text":"انتخاب مسیر LC/TT/ارز صادراتی و پیگیری کارتابل بانکی."}},
    {"@type":"Question","name":"منشأ ارز چیست و چگونه مستندسازی می‌شود؟","acceptedAnswer":{"@type":"Answer","text":"بانکی/صادراتی/آزاد؛ باید با اسناد پرداخت و سفارش هم‌خوانی داشته باشد."}},
    {"@type":"Question","name":"رفع تعهد ارزی با چه اسنادی انجام می‌شود؟","acceptedAnswer":{"@type":"Answer","text":"ارائه پروانه گمرکی، قبض انبار، BL/AWB و بیمه‌نامه و تطبیق ارزش‌ها."}},
    {"@type":"Question","name":"در عملیات بارنامه به چه نکاتی توجه کنیم؟","acceptedAnswer":{"@type":"Answer","text":"Consignee/Notify صحیح، Free Time، اصلاحیه‌ها و Telex Release."}},
    {"@type":"Question","name":"چه کلوز بیمه‌ای مناسب محموله من است؟","acceptedAnswer":{"@type":"Answer","text":"انتخاب بین ICC (A/B/C) براساس ریسک مسیر، نوع کالا و ارزش محموله."}},
    {"@type":"Question","name":"بررسی سابقه ترخیص چه کمکی به ما می‌کند؟","acceptedAnswer":{"@type":"Answer","text":"پیش‌بینی ریسک و بهینه‌سازی هزینه/زمان بر پایه مسیرها و ارزش‌های عرف."}},
    {"@type":"Question","name":"چه گزارش‌هایی برای مدیریت مفیدتر است؟","acceptedAnswer":{"@type":"Answer","text":"داشبورد وضعیت سفارش/ارز/حمل با خروجی اکسل/PDF و KPIهای کلیدی."}},
    {"@type":"Question","name":"شاخه فعالیت کارت بازرگانی چگونه تعیین می‌شود؟","acceptedAnswer":{"@type":"Answer","text":"هم‌خوانی شاخه‌ها با اقلام و مجوزها؛ و مدارک لازم برای تغییرات."}},
    {"@type":"Question","name":"کدام مُد حمل برای محموله من بهتر است؟","acceptedAnswer":{"@type":"Answer","text":"انتخاب بین دریایی/هوایی/زمینی/ریلی براساس هزینه–زمان–ریسک."}},
    {"@type":"Question","name":"چه اسناد بازرگانی‌ای ضروری هستند؟","acceptedAnswer":{"@type":"Answer","text":"PI/CI، پکینگ، گواهی مبدأ، استاندارد/بهداشت، BL/AWB و بیمه‌نامه."}},
    {"@type":"Question","name":"سامانه EPL چه مسیری را پوشش می‌دهد؟","acceptedAnswer":{"@type":"Answer","text":"از اظهار تا صدور پروانه الکترونیک و مدیریت مسیرهای سبز/زرد/قرمز."}}
  ]
}
    </script>

    <!-- Minimal Page-level Styles (می‌توانید به فایل CSS منتقل کنید) -->
    <style>
        html {
            scroll-behavior: smooth;
        }

        .faq-intro {
            font-size: 18px;
        }

        .faq-register {
            margin-top: 12px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="page-title">
        <div class="container">
            <div class="row">
                <div class="col-sm-12" dir="rtl">
                    <h1 class="mainTitle title-white text-dark">آموزش سامانه‌های تجارت و گمرک</h1>
                    <span class="mainDescription title-white text-dark">از ثبت سفارش و ارزی تا EPL و ترخیص — آموزش کاربردی قدم‌به‌قدم</span>
                    <ol class="breadcrumb">
                        <li><span style="font-size: 14px;">Nobin Gostar Paya</span></li>
                        <li class="active"><span style="font-size: 14px;">Training</span></li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section id="training-highlight" role="region" aria-labelledby="training-headline" style="background: linear-gradient(135deg,#0e1a2b 0%,#17324f 55%,#1f4973 100%); color: #fff; padding: 36px 0; border-radius: 14px; margin: 16px 0;">
        <div class="container">
            <div class="row" dir="rtl">
                <div class="col-sm-12">
                    <h2 id="training-headline" class="mainTitle" style="color: #fff; margin-top: 0; margin-bottom: 10px;">آموزش سامانه‌های تجارت و گمرک
                    </h2>

                    <p class="mainDescription" style="color: #dbe7ff; font-size: 18px; margin-bottom: 18px;">
                        مسیر استاندارد از <strong>ثبت سفارش</strong> و <strong>تخصیص/منشأ ارز</strong> تا <strong>EPL</strong> و <strong>ترخیص/رفع تعهد ارزی</strong> — آموزش کاملاً کاربردی، قدم‌به‌قدم و نتیجه‌محور.
                    </p>

                    <ul class="list-inline" style="margin: 0 0 16px 0;">
                        <li class="list-inline-item" style="display: inline-block; margin: 6px 6px 6px 0;">
                            <span style="display: inline-block; padding: 8px 12px; border: 1px solid rgba(255,255,255,.18); background: rgba(255,255,255,.08); border-radius: 10px; font-size: 14px;">۱۸ سرفصل کلیدی
                            </span>
                        </li>
                        <li class="list-inline-item" style="display: inline-block; margin: 6px 6px 6px 0;">
                            <span style="display: inline-block; padding: 8px 12px; border: 1px solid rgba(255,255,255,.18); background: rgba(255,255,255,.08); border-radius: 10px; font-size: 14px;">۹۳٪ رضایت شرکت‌کنندگان
                            </span>
                        </li>
                        <li class="list-inline-item" style="display: inline-block; margin: 6px 6px 6px 0;">
                            <span style="display: inline-block; padding: 8px 12px; border: 1px solid rgba(255,255,255,.18); background: rgba(255,255,255,.08); border-radius: 10px; font-size: 14px;">پشتیبانی کتبی ۳۰ روزه
                            </span>
                        </li>
                    </ul>

                    <div class="hero-cta" style="margin-top: 8px;">
                        <a href="account/Regisration" class="btn btn-lg btn-primary" aria-label="ثبت‌نام سریع در دوره‌های آموزش سامانه‌های تجارت و گمرک">ثبت‌نام سریع</a>
                        <a href="#accordionFAQ" class="btn btn-lg btn-default" aria-label="مشاهده سرفصل‌ها و سوالات پرتکرار">مشاهده سرفصل‌ها</a>
                    </div>
                </div>
            </div>
        </div>
    </section>



    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">

                <!-- SLIDER -->
                <div class="col-md-12">
                    <div class="horizontal-slider swiper-default swiper-container margin-bottom-30" aria-label="اسلایدر آموزشی">
                        <div class="swiper-wrapper">
                           
                          
                           
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/fN603qcEA7g-unsplash_524722.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/kyCNGGKCvyw-unsplash_944779.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/RJjY5Hpnifk-unsplash_545661.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/Q47eNv_UvfM-unsplash_975818.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/SPPUHSsaT-8-unsplash_500190.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/xewrfLD8emE-unsplash_201458.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>
                            <div class="swiper-slide">
                                <img loading="lazy" src="img/slide/slide2/YWhknHgWovE-unsplash_294973.jpg" alt="ترخیص کالا نوبین گستر پایا" class="img-responsive" />
                            </div>

                        </div>
                        <div class="swiper-pagination swiper-pagination-white"></div>
                        <div class="swiper-button-next swiper-button-white" aria-label="بعدی"></div>
                        <div class="swiper-button-prev swiper-button-white" aria-label="قبلی"></div>
                    </div>
                </div>

                <!-- TEXT (styled like your previous section) -->
                <div class="col-md-12 text-justify" dir="rtl" style="font-size: 20px">
                    <div class="container">

                        <div class="highlight">
                            <p>
                                اسلایدر بالا، نقشهٔ مسیر آموزش‌های ماست: از
              <a href="http://www.nobincommerce.com/Goods-Import-Registration"><strong>ثبت سفارش</strong></a>
                                →
              <a href="http://www.nobincommerce.com/Comprehensive-Guide-to-International-Transportation"><strong>تأمین و حمل</strong></a>
                                →
              <a href="http://www.nobincommerce.com/Risk-Management"><strong>بیمه و اسناد</strong></a>
                                →
              <strong>EPL و ارزیابی</strong>
                                →
              <a href="http://www.nobincommerce.com/Foreign-Exchange-Commitment-Clearance-for-Imports-and-Exports"><strong>ترخیص و رفع تعهد ارزی</strong></a>.
              هر مرحله به زبان ساده، با مثال واقعی و چک‌لیست اجرایی ارائه می‌شود تا همان روز در پروژه‌تان پیاده‌سازی کنید.
                            </p>
                            <p>
                                <strong>نوبین گستر پایا</strong> با اتکاء به ۱۸ سال میدان‌داری، دوره‌ها را دقیقاً بر اساس جریان‌های فعلی <strong>NTSW/EPL</strong> و رویه‌های واقعی ایران طراحی کرده است تا
              ریسک، زمان و هزینهٔ شما کاهش یابد و خطاهای پرتکرار به حداقل برسد. اگر به برنامهٔ اختصاصی نیاز دارید، همین حالا
              <a href="http://www.nobincommerce.com/contact-us">درخواست دمو/مشاوره</a>
                                ثبت کنید.
                            </p>
                        </div>

                        <h2>چرا این آموزش برای شما «مفید و نتیجه‌محور» است؟</h2>
                        <ul>
                            <li><strong>مسیر استاندارد و عملیاتی:</strong> از ورود به سامانه جامع تجارت تا رفع تعهد؛ قدم‌به‌قدم با چک‌لیست‌های اجرا و تمپلیت اسناد.</li>
                            <li><strong>کاهش خطا و ریجکت:</strong> شناسایی فیلدهای حساس، مغایرت‌های پرتکرار و راه‌های پیشگیری قبل از ارسال.</li>
                            <li><strong>صرفه‌جویی زمان/هزینه:</strong> انتخاب مُد حمل، کلوز بیمه و زمان‌بندی هماهنگ با ترخیص—بدون اتلاف.</li>
                            <li><strong>به‌روز و بومی:</strong> منطبق با جریان‌های فعلی NTSW/EPL و نیازهای واقعی کسب‌وکارهای ایرانی.</li>
                        </ul>

                        <h2>مسیر یادگیری پیشنهادی</h2>
                        <ol>
                            <li><a href="#faq1">آشنایی با سامانه جامع تجارت</a> → نقش‌ها، اتصال کارت، کارتابل‌ها</li>
                            <li><a href="#faq7">ثبت سفارش</a> → <a href="#faq8">تخصیص ارز</a> → <a href="#faq9">منشأ ارز</a></li>
                            <li><a href="#faq11">عملیات بارنامه</a> + <a href="#faq12">بیمه‌نامه</a> → <a href="#faq18">EPL</a> → <a href="#faq10">رفع تعهد ارزی</a></li>
                        </ol>

                        <div class="cta" style="margin-top: 18px;">
                            <a href="/En/register" class="btn btn-primary btn-wide" aria-label="ثبت‌نام در دوره‌های آموزشی">ثبت‌نام سریع</a>
                            <a href="#accordionFAQ" class="btn btn-default btn-wide" aria-label="مشاهده سرفصل‌ها">مشاهده سرفصل‌ها</a>
                            <a href="http://www.nobincommerce.com/about_us" class="btn btn-link">درباره نوبین گستر پایا</a>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </section>


    <!-- FAQ (۱۸ سرفصل با دکمه ثبت‌نام در هر آکاردئون) -->
    <section class="container-fluid container-fullw bg-white" id="modules">
        <div class="container">
            <div class="row" dir="rtl">
                <div class="col-md-12">
                    <h2>سرفصل‌ها و سوالات پرتکرار</h2>
                    <p class="faq-intro">برای ثبت‌نام در هر بخش، روی «ثبت نام» همان آکاردئون کلیک کنید.</p>
                    <hr />
                </div>

                <div class="col-md-12" style="font-size: 18px">
                    <div class="panel-group accordion-custom" id="accordionFAQ">

                        <!-- 01 -->
                        <div class="panel panel-transparent" id="t1">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq1"><i class="icon-arrow"></i>۱) سامانه جامع تجارت چیست و از کجا شروع کنم؟</a></h4>
                            </div>
                            <div id="faq1" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>«سامانه جامع تجارت» درگاه یکپارچه تجارت خارجی است؛ نقشه راه نقش‌ها، اتصال کارت بازرگانی، کارتابل‌ها و گزارش‌ها را پوشش می‌دهد.</p>
                                    <ul>
                                        <li>ایجاد/ورود کاربر و احراز هویت</li>
                                        <li>تعریف نقش‌ها و دسترسی‌ها</li>
                                        <li>اتصال زیرسامانه‌ها و پیگیری سفارش</li>
                                    </ul>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام دوره سامانه جامع تجارت">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 02 -->
                        <div class="panel panel-transparent" id="t2">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq2"><i class="icon-arrow"></i>۲) مراحل فعال‌سازی کارت بازرگانی چیست؟</a></h4>
                            </div>
                            <div id="faq2" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>از مدارک ثبتی/هویتی و مالیاتی تا ثبت در اتاق بازرگانی و تعریف شاخه فعالیت—همه مرحله‌به‌مرحله.</p>
                                    <ul>
                                        <li>چک‌لیست مدارک و استعلام‌ها</li>
                                        <li>پرهیز از خطاهای پرتکرار و ریجکت</li>
                                    </ul>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام فعال‌سازی کارت">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 03 -->
                        <div class="panel panel-transparent" id="t3">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq3"><i class="icon-arrow"></i>۳) برای ایجاد نمایندگی معتبر چه مدارکی لازم است؟</a></h4>
                            </div>
                            <div id="faq3" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>قرارداد دو‌زبانه، احراز اصالت فروشنده و تعیین قلم کالا؛ به‌همراه الگوی KPI فروش.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام ایجاد نمایندگی">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 04 -->
                        <div class="panel panel-transparent" id="t4">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq4"><i class="icon-arrow"></i>۴) شناسه کالای وارداتی چگونه اخذ/به‌روزرسانی می‌شود؟</a></h4>
                            </div>
                            <div id="faq4" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>شناسه کالا بر پایه HS و مشخصات فنی یکتا می‌شود؛ با کاتالوگ و نمونه‌های مشابه.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام شناسه کالا">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 05 -->
                        <div class="panel panel-transparent" id="t5">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq5"><i class="icon-arrow"></i>۵) شناسه فروشنده خارجی به چه کار می‌آید؟</a></h4>
                            </div>
                            <div id="faq5" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>پروفایلینگ و اعتبارسنجی تأمین‌کننده برای ثبت سفارش و کانال‌های پرداخت.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام شناسه فروشنده خارجی">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 06 -->
                        <div class="panel panel-transparent" id="t6">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq6"><i class="icon-arrow"></i>۶) سهمیه واردات چگونه بررسی و افزایش داده می‌شود؟</a></h4>
                            </div>
                            <div id="faq6" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>کنترل سقف‌ها و محدودیت‌ها + مستندات درخواست افزایش سهمیه.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام سهمیه واردات">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 07 -->
                        <div class="panel panel-transparent" id="t7">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq7"><i class="icon-arrow"></i>۷) ثبت سفارش کالا شامل چه مراحلی است؟</a></h4>
                            </div>
                            <div id="faq7" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>تعریف مشخصات، Incoterms، ارزش/وزن، و بارگذاری PI بدون مغایرت.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام ثبت سفارش">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 08 -->
                        <div class="panel panel-transparent" id="t8">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq8"><i class="icon-arrow"></i>۸) تخصیص ارز چگونه انجام می‌شود؟</a></h4>
                            </div>
                            <div id="faq8" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>انتخاب مسیر LC/TT/صادراتی، کارتابل بانکی و هم‌خوانی با سفارش.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام تخصیص ارز">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 09 -->
                        <div class="panel panel-transparent" id="t9">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq9"><i class="icon-arrow"></i>۹) منشأ ارز چیست و چگونه مستندسازی می‌شود؟</a></h4>
                            </div>
                            <div id="faq9" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>بانکی/صادراتی/آزاد؛ تطبیق حواله/LC با پروفرما و شرایط تحویل.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام منشأ ارز">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 10 -->
                        <div class="panel panel-transparent" id="t10">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq10"><i class="icon-arrow"></i>۱۰) رفع تعهد ارزی با چه اسنادی انجام می‌شود؟</a></h4>
                            </div>
                            <div id="faq10" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>پروانه گمرکی، قبض انبار، BL/AWB، بیمه‌نامه و تطبیق ارزش نهایی.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام رفع تعهد ارزی">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 11 -->
                        <div class="panel panel-transparent" id="t11">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq11"><i class="icon-arrow"></i>۱۱) در عملیات بارنامه به چه نکاتی توجه کنیم؟</a></h4>
                            </div>
                            <div id="faq11" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>اصلاح/صدور BL/AWB، سوییچ، Telex Release، Consignee/Notify صحیح.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام عملیات بارنامه">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 12 -->
                        <div class="panel panel-transparent" id="t12">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq12"><i class="icon-arrow"></i>۱۲) چه کلوز بیمه‌ای مناسب محموله من است؟</a></h4>
                            </div>
                            <div id="faq12" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>مقایسه ICC (A/B/C)، اعلام ارزش، فرانشیز و روند اعلام خسارت.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام بیمه‌نامه حمل">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 13 -->
                        <div class="panel panel-transparent" id="t13">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq13"><i class="icon-arrow"></i>۱۳) بررسی سابقه ترخیص چه کمکی به ما می‌کند؟</a></h4>
                            </div>
                            <div id="faq13" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>تحلیل مسیرهای سبز/زرد/قرمز، ارزش‌های عرف و مستندسازی کاهش ریسک.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام سابقه ترخیص">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 14 -->
                        <div class="panel panel-transparent" id="t14">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq14"><i class="icon-arrow"></i>۱۴) چه گزارش‌هایی برای مدیریت مفیدتر است؟</a></h4>
                            </div>
                            <div id="faq14" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>داشبورد سفارش/ارز/حمل، خروجی اکسل/PDF و KPIهای تصمیم‌ساز.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام گزارش‌گیری">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 15 -->
                        <div class="panel panel-transparent" id="t15">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq15"><i class="icon-arrow"></i>۱۵) شاخه فعالیت کارت بازرگانی چگونه تعیین می‌شود؟</a></h4>
                            </div>
                            <div id="faq15" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>هم‌راستایی شاخه‌ها با اقلام و مجوزها؛ مدارک لازم برای تغییر/افزودن.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام شاخه فعالیت کارت">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 16 -->
                        <div class="panel panel-transparent" id="t16">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq16"><i class="icon-arrow"></i>۱۶) کدام مُد حمل برای محموله من بهتر است؟</a></h4>
                            </div>
                            <div id="faq16" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>انتخاب بین دریایی/هوایی/زمینی/ریلی بر اساس هزینه–زمان–ریسک و ماهیت کالا.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام حمل">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 17 -->
                        <div class="panel panel-transparent" id="t17">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq17"><i class="icon-arrow"></i>۱۷) چه اسناد بازرگانی‌ای ضروری هستند؟</a></h4>
                            </div>
                            <div id="faq17" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>چک‌لیست کامل PI/CI، پکینگ، CO، استاندارد/بهداشت، BL/AWB و Policy.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام اسناد بازرگانی">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                        <!-- 18 -->
                        <div class="panel panel-transparent" id="t18">
                            <div class="panel-heading">
                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordionFAQ" href="#faq18"><i class="icon-arrow"></i>۱۸) سامانه EPL چه مسیری را پوشش می‌دهد؟</a></h4>
                            </div>
                            <div id="faq18" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>EPL از اظهار تا پروانه الکترونیک و مدیریت مسیرهای سبز/زرد/قرمز را پوشش می‌دهد.</p>
                                    <p class="faq-register"><a href="account/Regisration" class="btn btn-primary btn-wide" aria-label="ثبت نام EPL">ثبت نام</a></p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- /panel-group -->
                </div>
            </div>
        </div>
    </section>

    <!-- FINAL CTA -->
    <section class="container-fluid container-fullw">
        <div class="container" dir="rtl">
            <div class="row">
                <div class="col-md-8">
                    <h2>آماده‌اید مسیر استاندارد را اجرا کنید؟</h2>
                    <p style="font-size: 18px">همین امروز ثبت‌نام کنید و از اولین درس، اجرا را شروع کنید. هر سرفصل، واضح، کوتاه و نتیجه‌محور طراحی شده است.</p>
                    <a href="account/Regisration" class="btn btn-lg btn-primary">ثبت‌نام سریع</a>
                    <a href="#accordionFAQ" class="btn btn-lg btn-default">دیدن سرفصل‌ها</a>
                </div>
                <div class="col-md-4">
                    <div class="section-muted">
                        <h4 style="margin-top: 0">شامل چه چیزهایی می‌شود؟</h4>
                        <ul style="padding-right: 18px">
                            <li>ویدئوهای کوتاه و دقیق</li>
                            <li>چک‌لیست‌های PDF و تمپلیت اسناد</li>
                            <li>نمونه‌های واقعی و سناریوهای پرتکرار</li>
                            <li>پشتیبانی کتبی ۳۰ روزه</li>
                        </ul>
                        <a href="account/Regisration" class="btn btn-block btn-primary">رزرو جایگاه</a>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
