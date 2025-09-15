<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="careers.aspx.cs" Inherits="WebApplicationImpora2222025.careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>نوبین | همکاری با نوبین</title>
    <link rel="shortcut icon" href="favicon.ico" />
    <meta name="genre" itemprop="genre" content="information" />
    <meta itemprop="inLanguage" content="fa" />
    <meta http-equiv="Content-Language" content="fa" />
    <meta http-equiv="content-language" content="fa" />
    <meta property="article:modified_time" content="21/6/2021" />
    <meta itemprop="datePublished" property="article:published_time" content="21/6/2021" />
    <meta itemprop="dateModified" property="article:modified" content="21/6/2021" />
    <meta id="authorpage" content="بازرگانی نوبین   | Nobin Commerce" name="author" />
    <meta name="thumbnail" itemprop="thumbnailUrl" content="https://nobincommerce.com/img/NLogo-Fa.svg" />
    <meta name="generator" content="https://nobincommerce.com" />
    <meta name="language" content="fa" />
    <meta name="rating" content="General" />
    <meta name="copyright" content="© 2021 Nobin Commerce (https://nobincommerce.com). All rights reserved" />
    <meta name="expires" content="never" />
    <meta name="robots" content="INDEX,FOLLOW" />
    <meta name="publisher" content="بازرگانی نوبین   | Nobin Commerce" />
    <meta name="dc.publisher" content="بازرگانی نوبین   | Nobin Commerce" />
    <meta name="date" content="21/6/2021" />
    <meta property="og:locale" content="fa_IR">
    <meta property="og:title" itemprop="headline" content="" />
    <meta property="og:type" content="article" />
    <meta property="og:description" content="نیرو های مورد نیاز نوبین" />
    <meta property="og:site_name" content="بازرگانی نوبین   | Nobin Commerce" />
    <meta property="article:author" content="https://www.facebook.com/Impora-group-345846069509658/" />
    <meta property="article:section" content="درباره نوبین" />
    <meta property="og:url" content="https://nobincommerce.com" />
    <meta property="og:image" content="https://nobincommerce.com/img/NLogo-Fa.svg" />
    <meta property="og:image:alt" content="نوبین ارایه دهنده خدمات ترخیص و ثبت سفارش کالا " />
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:site" content="@Imporaa" />
    <meta name="twitter:title" content="همکاری با نوبین" />
    <meta name="twitter:description" content="نیرو های مورد نیاز نوبین" />
    <meta name="twitter:creator" content="@Imporaa" />
    <meta name="twitter:image:src" content="https://nobincommerce.com/img/NLogo-Fa.svg" />
    <meta name="twitter:image:alt" content="نوبین - خدمات تخصصی واردات و ترخیص کالا" />
    <meta name="twitter:domain" content="https://nobincommerce.com" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="container">
            <div class="row">
                <div class="col-sm-12" dir="rtl">
                    <h1 class="mainTitle title-white text-dark" dir="rtl">همکاری و استخدام</h1>
                    <span dir="rtl" class="mainDescription text-dark">حرفه های مورد نیاز نوبین</span>
                </div>
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span style="font-size: 14px;">نوبین</span>
                    </li>
                    <li class="active">
                        <span style="font-size: 14px;">همکاری و استخدام</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class="col-md-4" dir="rtl">
                    <div class="alert alert-success " id="contactSuccess" runat="server" visible="false">
                        <asp:Label ID="Label1" runat="server" Text="" Visible="False" ForeColor="Lime" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="alert alert-error " id="contactError" runat="server" visible="false">
                        <asp:Label ID="Label2" runat="server" Text="" Visible="False" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <h2 dir="rtl">فرم پیگیری
                    </h2>
                    <p dir="rtl">
                        در صورتی که طی مدت 5 روز کاری پس از تایید برای مصاحبه تماسی با شما گرفته نشد این فرم را پر نمایید. 
                    </p>
                    <div dir="rtl" style="font-size: 14px;">
                        <div class="form-group" dir="rtl">
                            <label class="control-label" style="font-size: 14px">نام و نام خانوادگی <span class="symbol required"></span></label>
                            <asp:TextBox ID="txt_name" runat="server" Text="نام و نام خانوادگی خود را وارد کنید" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your name." ControlToValidate="txt_name" ValidationGroup="oooo"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" dir="rtl">
                            <label class="control-label" style="font-size: 14px">گروه شغلی <span class="symbol required"></span></label>
                            <asp:DropDownList ID="txt_DropDownList1" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True"></asp:ListItem>
                                <asp:ListItem>مدیر فروش</asp:ListItem>
                                <asp:ListItem>کارشناس فروش</asp:ListItem>
                                <asp:ListItem>گرافیست</asp:ListItem>
                                <asp:ListItem>حسابدار</asp:ListItem>
                                <asp:ListItem>تولید محتوا</asp:ListItem>
                                <asp:ListItem>اپراتور مهندسی</asp:ListItem>
                                <asp:ListItem>عکاس/فیلمبردار</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="form-field-22">شماره موبایل <span class="symbol required"></span></label>
                            <asp:TextBox ID="txt_mobile" runat="server" CssClass="form-control" Text="شماره همراه خود را وارد نمایید."></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="form-field-22">پیام <span class="symbol required"></span></label>
                            <asp:TextBox ID="txt_message" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div data-caption-delay="900" data-caption-class="fadeIn">
                            <asp:Button ID="Button1" runat="server" Text="ارسال" CssClass="btn btn-primary margin-top-15" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
                <div class="padding-top-10"></div>
                <div class="col-md-8" dir="rtl" style="font-size: 18px">
                    <h2 dir="rtl">مشاغل و مهارتها</h2>
                    <p dir="rtl">
                        اگر ذهن قدرتمند و یا از تجربه‌ی کاری خوبی در زمینه های زیر برخوردار هستید و مهمتر اینکه علاقه مندید در گروه‌های کاری حرفه‌ای، خلاق و چابک  نوبین فعالیت نمایید؛ لازم است بدانید که ما هم اکنون در حال جذب نیروی حرفه ای و نیمه حرفه ای  می باشیم. پس فرصت را برای مشاغل زیر از دست ندهید.
                          
                        در صورت داشتن هر یک از شرایط زیر فرم استخدام نوبین را تکمیل و ارسال نمایید.
                    </p>
                    <hr />
                    <div class="panel-group accordion-custom" id="accordion">
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl"><a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#mnm"><i class="icon-arrow"></i>مدیر بازاریابی </a></h4>
                            </div>
                            <div id="mnm" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - <strong>بخش:</strong> فروش و بازاریابی</p>
                                    <p>متخصص در زمینه بازاریابی و دارای 10 سال سابقه در بازاریابی</p>
                                    <p>توانایی گسترش سهم از بازار</p>
                                    <p>شناخت بازار هدف</p>
                                    <p>توانایی مدیریت ورهبری تیمی</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="a" runat="server">پر کردن فرم استخدام </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl">
                                    <a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseCustoms">
                                        <i class="icon-arrow"></i>کارشناس امور گمرکی و ترخیص کالا
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseCustoms" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - بندرعباس - بوشهر - مشهد - اصفهان - تبریز - اهواز <strong>بخش:</strong> امور گمرکی و ترخیص</p>
                                    <p>شرایط مورد نیاز:</p>
                                    <p>تسلط کامل بر **قوانین و مقررات گمرکی** و رویه‌های ترخیص کالا</p>
                                    <p>آشنایی با **سیستم EPL گمرک** و سامانه‌های مرتبط</p>
                                    <p>مهارت در **مکاتبات رسمی با سازمان‌های مرتبط** (گمرک، وزارت صمت و بانک مرکزی)</p>
                                    <p>تجربه در **ارزیابی اسناد تجاری و حل مشکلات گمرکی**</p>
                                    <p>توانایی **مدیریت فرآیند ترخیص از بنادر و فرودگاه‌ها**</p>
                                    <p>دارای روحیه **دقیق، پیگیر و منظم**</p>
                                    <p>استخدام به صورت **تمام وقت و پروژه‌ای**</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="b" runat="server">پر کردن فرم استخدام</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl">
                                    <a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseLogistics">
                                        <i class="icon-arrow"></i>کارشناس حمل‌ونقل بین‌المللی
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseLogistics" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - بندرعباس - بوشهر - تبریز - مشهد <strong>بخش:</strong> لجستیک و حمل‌ونقل</p>
                                    <p>شرایط مورد نیاز:</p>
                                    <p>آشنایی با **انواع روش‌های حمل‌ونقل بین‌المللی** (هوایی، دریایی، زمینی و ریلی)</p>
                                    <p>تسلط بر **اصطلاحات حمل‌ونقل (اینکوترمز)** و قوانین بین‌المللی</p>
                                    <p>مهارت در **هماهنگی با شرکت‌های حمل‌ونقل و فورواردرها**</p>
                                    <p>توانایی **مدیریت هزینه‌های حمل و بهینه‌سازی فرآیندهای لجستیکی**</p>
                                    <p>آشنا با **اسناد حمل (BL، CMR، AWB) و بیمه بار**</p>
                                    <p>دارای توانایی حل مشکلات لجستیکی و برنامه‌ریزی مؤثر</p>
                                    <p>استخدام به صورت **تمام وقت و پروژه‌ای**</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="A1" runat="server">پر کردن فرم استخدام</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl">
                                    <a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseProcurement">
                                        <i class="icon-arrow"></i>کارشناس خرید خارجی
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseProcurement" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - دبی - استانبول - شنژن <strong>بخش:</strong> خرید و تأمین</p>
                                    <p>شرایط مورد نیاز:</p>
                                    <p>تسلط بر **فرآیندهای خرید خارجی و انتخاب تأمین‌کنندگان معتبر**</p>
                                    <p>آشنا با **بازارهای بین‌المللی و پلتفرم‌های تأمین (Alibaba، Tradekey و... )**</p>
                                    <p>مهارت در **مذاکرات تجاری و عقد قراردادهای خرید**</p>
                                    <p>آشنایی با **روش‌های پرداخت بین‌المللی (LC، TT، حواله و رمزارز)**</p>
                                    <p>توانایی **بررسی کیفیت کالاها و اخذ مجوزهای لازم**</p>
                                    <p>مسلط به **زبان انگلیسی یا زبان کشور تأمین‌کننده**</p>
                                    <p>استخدام به صورت **تمام وقت و پروژه‌ای**</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="A2" runat="server">پر کردن فرم استخدام</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl">
                                    <a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseContracts">
                                        <i class="icon-arrow"></i>کارشناس قراردادهای بین‌المللی
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseContracts" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - استانبول - دبی - شنژن - مسکو <strong>بخش:</strong> حقوقی و قراردادها</p>
                                    <p>شرایط مورد نیاز:</p>
                                    <p>آشنایی کامل با **قوانین تجارت بین‌المللی** و **کنوانسیون‌های تجاری**</p>
                                    <p>مهارت در **تنظیم، بررسی و مذاکره قراردادهای خرید، حمل و پرداخت**</p>
                                    <p>تسلط بر **شرایط INCOTERMS 2020** و نحوه اعمال آن در قراردادها</p>
                                    <p>توانایی **تحلیل ریسک‌های حقوقی و مالی قراردادهای بین‌المللی**</p>
                                    <p>آشنایی با **قوانین تحریم‌ها و نحوه مدیریت نقل و انتقالات ارزی**</p>
                                    <p>مسلط به **زبان انگلیسی و مکاتبات حقوقی بین‌المللی**</p>
                                    <p>استخدام به صورت **تمام وقت و پروژه‌ای**</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="A3" runat="server">پر کردن فرم استخدام</a>
                                    </p>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl"><a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse3"><i class="icon-arrow"></i>متخصص تولید محتوا و  سئو  </a></h4>
                            </div>
                            <div id="collapse3" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - <strong>بخش:</strong> امور بازرگانی و ترخیص کالا</p>
                                    <p>دانشجویان، فارغ‌التحصیلان و افرادی که به دنبال کار پروژه‌ای، پاره‌وقت یا تمام‌وقت در حوزه بازرگانی بین‌المللی هستند.</p>
                                    <p>کسانی که علاقه‌مند به فعالیت در زمینه واردات، صادرات، ترخیص کالا و مدیریت زنجیره تأمین هستند.</p>
                                    <p>کسانی که تمایل به تحلیل ریسک‌های تجاری، امور ارزی، تنظیم قراردادهای بین‌المللی و مذاکره با شرکت‌های خارجی دارند.</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="k" runat="server">پر کردن فرم استخدام</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl"><a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse4"><i class="icon-arrow"></i>حسابدار  </a></h4>
                            </div>
                            <div id="collapse4" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - <strong>بخش:</strong> مالی</p>
                                    <p>دانشجویان ، فارغ التحصیلان رشته های حسابداری و مدیریت</p>
                                    <p>تسلط بر نرم افزار سپیدار</p>
                                    <p>تسلط بر امور مالیاتی و اظهار نامه فصلی</p>
                                    <p>دارای سابقه حسابداری و یا حسابرسی باشد.</p>
                                    <p>پاره وقت و تمام وقت.</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="l" runat="server">پر کردن فرم استخدام </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                      
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl"><a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse1"><i class="icon-arrow"></i>عکاس و فیلم بردار </a></h4>
                            </div>
                            <div id="collapse1" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - اصفهان - شیراز - تبریز - مشهد - اهواز - کرج- <strong>بخش:</strong> طراحی و گرافیک</p>
                                    <p>افرادی که علاقه مند به عکاسی، فیلم برداری و تدوین در زمینه تولید محتوا هستند.</p>
                                    <p>ویا افرادی که در این زمینه حرفه ای هستند.</p>
                                    <p>استخدام به صورت پروژه ای می باشد.</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="c" runat="server">پر کردن فرم استخدام </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-transparent">
                            <div class="panel-heading">
                                <h4 class="panel-title" dir="rtl"><a style="font-size: 18px" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"><i class="icon-arrow"></i>گرافیست </a></h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse">
                                <div class="panel-body" dir="rtl">
                                    <p><strong>مکان:</strong> تهران - <strong>بخش:</strong> طراحی و گرافیک</p>
                                    <p>افرادی که با یکی از نرم افزار های زیر آشنایی قابل قبولی دارند فرم استخدام را تکمیل نمایند.</p>
                                    <p>Photoshop-Freehand-Flash-Corel-Premiere-Illustrator-Fireworks-InDesign-Visio-3D Studio MAX</p>
                                    <p>
                                        <a href="register-staff.aspx" class="btn btn-primary btn-wide" id="d" runat="server">پر کردن فرم استخدام </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
