<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Comprehensive-Guide-to-International-Transportation.aspx.cs" Inherits="WebApplicationImpora2222025.Comprehensive_Guide_to_International_Transportation" %>

<asp:Content ID="Content5" ContentPlaceHolderID="head" runat="server">
    <meta name="genre" itemprop="genre" content="Logistics, Transportation" />
    <meta itemprop="inLanguage" content="fa" />
    <meta http-equiv="Content-Language" content="fa" />
    <meta http-equiv="content-language" content="fa" />
    <meta property="article:modified_time" content="<%= date_last_edit %>" />
    <link rel="canonical" href="<%=canonical_url%>" />
    <meta itemprop="datePublished" property="article:published_time" content="<%= date_publich %>" />
    <meta itemprop="dateModified" property="article:modified" content="<%= date_last_edit_utc%>" />
    <meta id="authorpage" runat="server" content="بازرگانی نوبین | Nobin Commerce" name="author" />
    <meta name="thumbnail" itemprop="thumbnailUrl" content="<%=pic_url%>" />
    <meta name="generator" content="https://nobincommerce.com" />
    <meta name="language" content="fa" />
    <meta name="rating" content="General" />
    <meta name="copyright" content="© 2025 Nobin Commerce (https://nobincommerce.com). All rights reserved" />
    <meta name="expires" content="never" />
    <meta name="robots" content="<%= robot_index%>,<%=robot_follow %>" />
    <meta name="publisher" content="بازرگانی نوبین | Nobin Commerce" />
    <meta name="dc.publisher" content="بازرگانی نوبین | Nobin Commerce" />
    <meta name="date" content="<%= date_last_edit %>" />
    <meta property="og:locale" content="fa_IR">
    <meta property="og:title" itemprop="headline" content="راهنمای جامع حمل و نقل بین‌المللی | Comprehensive Guide to International Transportation" />
    <meta property="og:type" content="article" />
    <meta property="og:description" content="<%= Page.MetaDescription %>" />
    <meta property="og:site_name" content="بازرگانی نوبین | Nobin Commerce" />
    <meta property="article:author" content="https://www.facebook.com/Impora-group-345846069509658/" />
    <meta property="article:section" content="حمل و نقل بین‌المللی" />
    <meta property="og:url" content="<%= Request.Url %>" />
    <meta property="og:image" content="<%=pic_url%>" />
    <meta property="og:image:alt" content="حمل و نقل بین‌المللی" />
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:site" content="@Imporaa" />
    <meta name="twitter:title" content="راهنمای جامع حمل و نقل بین‌المللی | Comprehensive Guide to International Transportation" />
    <meta name="twitter:description" content="<%= Page.MetaDescription %>" />
    <meta name="twitter:creator" content="@Imporaa" />
    <meta name="twitter:image:src" content="<%=pic_url%>" />
    <meta name="twitter:image:alt" content="حمل و نقل بین‌المللی - خدمات تخصصی نوبین" />
    <meta name="twitter:domain" content="https://nobincommerce.com" />
    <script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "Article",
  "mainEntityOfPage": {
    "@type": "WebPage",
    "@id": "http://www.nobincommerce.com/international-shipping-guide"
  },
  "headline": "راهنمای جامع حمل و نقل بین‌المللی | انواع روش‌ها، اینکوترمز و انتخاب شرکت حمل",
  "description": "این مقاله یک راهنمای جامع حمل و نقل بین‌المللی است که روش‌های حمل (دریایی، هوایی، زمینی و ترکیبی)، قوانین اینکوترمز 2020، انواع شرکت‌های حمل (کریر و فورواردر) و فرآیند انتخاب شریک لجستیکی را بررسی می‌کند. خدمات تخصصی نوبین گستر پایا برای مدیریت لجستیک و بهینه‌سازی هزینه‌ها ارائه شده است.",
  "author": {
    "@type": "Organization",
    "name": "نوبین گستر پایا",
    "url": "http://www.nobincommerce.com/"
  },
  "publisher": {
    "@type": "Organization",
    "name": "نوبین گستر پایا",
    "logo": {
      "@type": "ImageObject",
         "url": "http://www.nobincommerce.com/img/NLogo-En.svg"
    }
  },
  "datePublished": "2025-08-27",
  "dateModified": "2025-08-27"
}
    </script>
    <script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
    {
      "@type": "Question",
      "name": "روش‌های اصلی حمل و نقل بین‌المللی کدامند؟",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "روش‌های اصلی شامل حمل دریایی (FCL, LCL, فله، Ro-Ro)، حمل هوایی، حمل زمینی (جاده‌ای و ریلی) و حمل ترکیبی یا چندوجهی هستند."
      }
    },
    {
      "@type": "Question",
      "name": "اینکوترمز 2020 چیست و چه کاربردی دارد؟",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "اینکوترمز مجموعه قوانین استاندارد بین‌المللی است که مسئولیت‌ها، هزینه‌ها و ریسک‌ها بین فروشنده و خریدار در معاملات بین‌المللی را مشخص می‌کند. شامل گروه‌های E، F، C و D است."
      }
    },
    {
      "@type": "Question",
      "name": "تفاوت کریر و فورواردر در حمل و نقل بین‌المللی چیست؟",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "کریرها مالک وسایل حمل مانند کشتی، هواپیما یا کامیون هستند و بارنامه اصلی صادر می‌کنند. فورواردرها متصدیان حمل‌اند که خدمات رزرو، تجمیع بار، امور اسنادی و مدیریت کل فرآیند لجستیک را ارائه می‌دهند."
      }
    },
    {
      "@type": "Question",
      "name": "چه اطلاعاتی برای استعلام قیمت حمل لازم است؟",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "برای دریافت نرخ حمل باید اطلاعاتی مانند شرح کالا، HS Code، وزن و حجم، نوع بسته‌بندی، شرایط خاص کالا، اینکوترم معامله، آدرس دقیق مبدأ و مقصد و بنادر یا فرودگاه‌های بارگیری و تخلیه ارائه شود."
      }
    },
    {
      "@type": "Question",
      "name": "مزایا و معایب حمل دریایی چیست؟",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "مزایا: هزینه پایین، ظرفیت بالا، پوشش جهانی و سازگاری با محیط زیست. معایب: سرعت پایین و احتمال تأخیر به دلیل شرایط جوی یا تراکم بندری."
      }
    },
    {
      "@type": "Question",
      "name": "شرکت نوبین گستر پایا چه خدماتی در حمل و نقل بین‌المللی ارائه می‌دهد؟",
      "acceptedAnswer": {
        "@type": "Answer",
        "text": "این شرکت خدماتی شامل مشاوره انتخاب روش حمل و اینکوترم، معرفی شرکای لجستیکی معتبر، مدیریت کامل فرآیند حمل و اسناد، هماهنگی بازرسی و بیمه، و بهینه‌سازی هزینه‌های لجستیک ارائه می‌دهد."
      }
    }
  ]
}
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../bower_components/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("button[name=estelam]").click(function () {
                if ($(this).val() == "estelam1") {
                    $("#panela").hide();
                    $("#text_servises").hide();
                    $("#panelb").hide();
                    $("#panelc").show();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=reqservices]").click(function () {
                if ($(this).val() == "reqservices1") {
                    $("#panela").hide();
                    $("#text_servises").hide();
                    $("#panelb").show();
                    $("#panelc").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=back11]").click(function () {
                if ($(this).val() == "back1") {
                    $("#panela").show();
                    $("#text_servises").show();
                    $("#panelb").hide();
                    $("#panelc").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=back22]").click(function () {
                if ($(this).val() == "back2") {
                    $("#panela").show();
                    $("#text_servises").show();
                    $("#panelb").hide();
                    $("#panelc").hide();
                }
            });
        });
    </script>
    <section id="page-title" class="page-title-background" style="display: block; background-image: url('<%=pic_url2%>'); height: 300px;">
        <div class="container">
            <div class="row">
                <div class="col-sm-12" dir="rtl">
                    <span id="mainTitle_" runat="server" class="mainTitle title-white" style="font-size: 30px">Page Title with Image</span>
                    <span class="mainDescription" id="mainDescription_" runat="server" dir="rtl">قیمت روز  نبشی و قیمت لحظه ای نبشی رو می توانید در پایین مطالب ملاحظه نمایید</span>
                </div>
                <div class=" pull-right">
                    <ol class="breadcrumb" dir="rtl">
                        <li>
                            <span id="base_address" runat="server" class=" title-white ">فروشگاه</span>
                        </li>

                        <li class="active">
                            <span id="other_address" runat="server" class=" title-white ">انواع نبشی</span>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <asp:Label ID="corect" runat="server" Text="" Visible="false"></asp:Label>
    <div class="alert alert-success text-center" dir="rtl" id="contactSuccess2" runat="server" style="display: none">
        <asp:Label ID="Label12" runat="server" Text="" ForeColor="Lime" Font-Size="Large"></asp:Label>
    </div>
    <div class="alert alert-warning text-center" dir="rtl" id="contactError2" runat="server" style="display: none">
        <asp:Label ID="Label22" runat="server" Text="" ForeColor="Red" Font-Size="Large"></asp:Label>
    </div>
    <section class="container-fluid container-fullw-desgin bg-white no-border" id="panela" style="display: block">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-justify padding-top-15" dir="rtl" style="font-size: 19px">
                    <p dir="rtl">
                        خدمات قابل ارائه در این سرویس
                    </p>
                    <div class="row buttons-widget">
                        <div class="col-md-12 margin-bottom-30">
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    <button type="button" class="btn btn-wide btn-info btn-block" name="estelam" value="estelam1">
                                        استعلام 
                                    </button>
                                </div>
                                <div class="col-sm-8">
                                    <button type="button" class="btn btn-wide btn-success btn-block" value="reqservices1" name="reqservices">
                                        درخواست خدمات
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white" dir="rtl" id="panelb" style="display: none">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <h2 id="head_estelam" runat="server">درخواست خدمات </h2>
                    <div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-6 ">
                                    <label>نام و نام خانوادگی <span class="symbol required"></span></label>
                                    <asp:TextBox ID="name" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your name." ControlToValidate="name" ValidationGroup="oooo"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    <label>شماره موبایل <span class="symbol required"></span></label>
                                    <asp:TextBox ID="phone" CssClass="form-control" runat="server" MaxLength="11" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter mobile number." ControlToValidate="phone" ValidationGroup="oooo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>نوع خدمات <span class="symbol required"></span></label>
                                    <asp:TextBox ID="subject" runat="server" MaxLength="100" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the subject." ControlToValidate="subject" ValidationGroup="oooo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>شرح خدمات درخواستی <span class="symbol required"></span></label>
                                    <asp:TextBox ID="message" runat="server" MaxLength="5000" TextMode="MultiLine" CssClass="form-control" Height="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your message." ValidationGroup="oooo" ControlToValidate="message"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>بهترین زمان تماس  <span class="symbol required"></span></label>
                                    <asp:DropDownList CssClass="form-control" ID="date_contact" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter time" ValidationGroup="oooo" ControlToValidate="date_contact"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>بارگذاری فایل </label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="btn btn-o btn-primary" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="padding-15">
                        </div>
                        <div class="row">
                            <div class=" form-group ">
                                <div class="col-md-12">
                                    <label>حاصل عبارت داخل تصویر را وارد نمایید.</label>
                                </div>
                                <asp:ScriptManager ID="ScriptManager1"
                                    runat="server" />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-6">
                                            <asp:Image ID="Image1_captcha" runat="server" />
                                            <asp:ImageButton ID="ImageButton1_refresh" runat="server" ImageUrl="../../img/refresh_img.png" OnClick="ImageButton1_refresh_Click" Height="20" ImageAlign="Middle" />
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="TextBox_captcha" runat="server" TextMode="Number" CssClass=" no-border form-group" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please enter the text." ForeColor="Red" ControlToValidate="TextBox_captcha" ValidationGroup="CreateUserWizard1" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:Label ID="txt_captcha" runat="server" Text="" Visible="False"></asp:Label>
                                            <asp:Label ID="Label_captcha" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div data-caption-delay="900" data-caption-class="fadeIn">
                                    <asp:Button ID="Button1" runat="server" Text="ثبت" CssClass="btn btn-primary margin-top-15 btn-wide " OnClick="Button1_Click" ValidationGroup="oooo" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div data-caption-delay="900" data-caption-class="fadeIn">
                                    <button type="button" class="btn btn btn-green btn-o margin-top-15 btn-wide" name="back11" value="back1">
                                        بازگشت
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="padding-15">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white" dir="rtl" id="panelc" style="display: none">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3 ">
                    <h2 id="head_estelam2" runat="server">درخواست خدمات </h2>
                    <div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-6 ">
                                    <label>نام و نام خانوادگی <span class="symbol required"></span></label>
                                    <asp:TextBox ID="name2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please enter your name." ControlToValidate="name2" ValidationGroup="xxxx"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    <label>شماره موبایل <span class="symbol required"></span></label>
                                    <asp:TextBox ID="phone2" CssClass="form-control" runat="server" MaxLength="11" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="Please enter mobile number." ControlToValidate="phone2" ValidationGroup="xxxx"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>نوع خدمات <span class="symbol required"></span></label>
                                    <asp:TextBox ID="subject2" runat="server" MaxLength="100" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Please enter the subject." ControlToValidate="subject2" ValidationGroup="xxxx"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>شرح خدمات درخواستی <span class="symbol required"></span></label>
                                    <asp:TextBox ID="message2" runat="server" MaxLength="5000" TextMode="MultiLine" CssClass="form-control" Height="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="Please enter your message." ValidationGroup="xxxx" ControlToValidate="message2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label>بهترین زمان تماس  <span class="symbol required"></span></label>
                                    <asp:DropDownList CssClass="form-control" ID="date_contact2" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ErrorMessage="Please enter time" ValidationGroup="xxxx" ControlToValidate="date_contact2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>بارگذاری فایل </label>
                                <asp:FileUpload ID="FileUpload2" CssClass="btn btn-o btn-primary" runat="server" />
                            </div>
                        </div>
                        <div class="form-group" dir="rtl">
                            <div class="row">
                                <div class=" form-group ">
                                    <div class="col-md-12">
                                        <label>حاصل عبارت داخل تصویر را وارد نمایید.</label>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-6">
                                                <asp:Image ID="Image1_captcha2" runat="server" />
                                                <asp:ImageButton ID="ImageButton1_refresh2" runat="server" ImageUrl="../../img/refresh_img.png" OnClick="ImageButton1_refresh_Click" Height="20" ImageAlign="Middle" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextBox_captcha2" runat="server" TextMode="Number" CssClass=" no-border form-group" Visible="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator132" runat="server" ErrorMessage="Please enter the text." ForeColor="Red" ControlToValidate="TextBox_captcha" ValidationGroup="CreateUserWizard1" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:Label ID="txt_captcha2" runat="server" Text="" Visible="False"></asp:Label>
                                                <asp:Label ID="Label_captcha2" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div data-caption-delay="900" data-caption-class="fadeIn">
                                    <asp:Button ID="Button2" runat="server" Text="ثبت" CssClass="btn btn-primary margin-top-15 btn-wide " OnClick="Button2_Click" ValidationGroup="xxxx" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div data-caption-delay="900" data-caption-class="fadeIn">
                                    <button type="button" class="btn btn btn-green btn-o margin-top-15 btn-wide" name="back22" value="back2">
                                        بازگشت
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="padding-15">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="text_servises" runat="server" class="container-fluid container-fullw-desgin bg-white no-border" dir="rtl" style="display: block">
        <div class="container">
            <div class="row">
                <h1 id="titr_page" runat="server" class="text-dark padding-bottom-20"></h1>
                <div class="col-sm-12 online_text text-size-all " dir="rtl">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class=" col-md-offset-2 col-md-8 col-xs-12">
                    <div class="horizontal-slider swiper-default swiper-container margin-bottom-30">
                        <div class="swiper-wrapper">
                            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                                <ItemTemplate>
                                    <div class="swiper-slide">
                                        <img loading="lazy" class="img-responsive" src='<%# "../../"+ Eval("pic") %>' alt='<%# Eval("alt") %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="WebApplicationImpora2222025.DataClasses1DataContext" TableName="image__tbls" Where="id_page == @id_page">
                            <WhereParameters>
                                <asp:ControlParameter ControlID="page_id" PropertyName="Text" Name="id_page" Type="Int32"></asp:ControlParameter>
                            </WhereParameters>
                        </asp:LinqDataSource>
                        <asp:Label ID="page_id" runat="server" Text="" Visible="false"></asp:Label>
                        <div class="swiper-pagination swiper-pagination-white"></div>
                        <div class="swiper-button-next swiper-button-white"></div>
                        <div class="swiper-button-prev swiper-button-white"></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-black">
        <div class="container">
            <div class="row">
                <div data-appears-group-delay="0" data-appears-delay-increase="300">
                    <div class="col-md-6 col-xs-6">
                        <div class="panel panel-dark no-radius text-center no-visible fadeIn animated" data-appears-class="fadeIn" data-appears-delay="0">
                            <div class="panel-body">
                                <a data-toggle="modal" data-target="#bd-example-modal-lg">
                                    <span class="fa-stack fa-5x"><i class="fa fa-square fa-stack-2x text-primary"></i><i class="fa fa-edit fa-stack-1x fa-inverse"></i></span>
                                    <h2 class="StepTitle">فرآیند ثبت سفارش </h2>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-xs-6">
                        <div class="panel panel-dark no-radius text-center no-visible fadeIn animated" data-appears-class="fadeIn" data-appears-delay="300">
                            <div class="panel-body">
                                <a href="../../about_us"><span class="fa-stack fa-5x"><i class="fa fa-square fa-stack-2x text-primary"></i><i class="fa fa-gift fa-stack-1x fa-inverse"></i></span>
                                    <h2 class="StepTitle">ارزش های پیشنهادی</h2>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div id="bd-example-modal-lg" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center">فرآیند سفارش از نوبین</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class=" hidden-xs">
                                    <img loading="lazy" src="../../img/فرآیند-سفارش-طراحی-از-ایمپورا.png" alt="فرآیند سفارش طراحی از نوبین" class="img-responsive" />
                                </div>
                                <div class=" hidden-lg hidden-md hidden-sm">
                                    <img loading="lazy" src="../../img/فرآیند-سفارش-طراحی-از-نوبین۲.png" alt="فرآیند سفارش طراحی از نوبین" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
