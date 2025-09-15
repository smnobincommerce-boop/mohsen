<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="my-page.aspx.cs" Inherits="WebApplicationImpora2222025.my_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="genre" itemprop="genre" content="Profile, CV" />
    <meta itemprop="inLanguage" content="fa" />
    <meta http-equiv="Content-Language" content="fa" />
    <meta http-equiv="content-language" content="fa" />
    <meta property="article:modified_time" content="<%= date_last_edit %>" />
    <link rel="canonical" href="<%=canonical_url%>" />
    <meta itemprop="datePublished" property="article:published_time" content="<%= date_publich %>" />
    <meta id="authorpage" runat="server" content="بازرگانی نوبین | Nobin Commerce" name="author" />
    <meta name="thumbnail" itemprop="thumbnailUrl" content="<%=pic_url%>" />
    <meta name="generator" content="https://nobincommerce.com" />
    <meta name="language" content="fa" />
    <meta name="rating" content="General" />
    <meta name="copyright" content="© 2021 Nobin Commerce (https://nobincommerce.com). All rights reserved" />
    <meta name="expires" content="never" />
    <meta name="robots" content="<%= robot_index%>,<%=robot_follow %>" />
    <meta name="publisher" content="بازرگانی نوبین | Nobin Commerce" />
    <meta name="dc.publisher" content="بازرگانی نوبین | Nobin Commerce" />
    <meta name="date" content="<%= date_last_edit %>" />
    <meta property="og:locale" content="fa_IR">
    <meta property="og:title" itemprop="headline" content="<%= title_pg %>" />
    <meta property="og:type" content="article" />
    <meta property="og:description" content="<%= Page.MetaDescription %>" />
    <meta property="og:site_name" content="بازرگانی نوبین | Nobin Commerce" />
    <meta property="article:author" content="https://www.facebook.com/Impora-group-345846069509658/" />
    <meta property="article:section" content="<%=page_name %>" />
    <meta property="og:url" content="<%= Request.Url %>" />
    <meta property="og:image" content="<%=pic_url%>" />
    <meta property="og:image:alt" content=" <%=alt_main_image %> " />
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:site" content="@Impora1" />
    <meta name="twitter:title" content="<%= title_pg %>" />
    <meta name="twitter:description" content="<%= Page.MetaDescription %>" />
    <meta name="twitter:creator" content="@Impora1" />
    <meta name="twitter:image:src" content="<%=pic_url%>" />
    <meta name="twitter:image:alt" content="نوبین - خدمات تخصصی واردات و ترخیص کالا" />
    <meta name="twitter:domain" content="https://nobincommerce.com" />
    <style type="text/css">
        .container11 > * {
            position: absolute;
        }

        .container11, .crop11 {
            height: 21px;
        }

        .crop11 {
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title" class="bg-black">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h1 class="mainTitle title-white" dir="rtl"><%= namepersonal %></h1>
                    <span class="mainDescription" dir="rtl"><%= description_about_me %></span>
                </div>
                <div class="col-sm-12">
                    <div class="pull-right">
                        <ol class="breadcrumb" dir="rtl">
                            <li>
                                <span>پروفایل</span>
                            </li>
                            <li class="active">
                                <span><%= namepersonal %></span>
                            </li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="portfolio-title">
                <div class="row">
                    <div class="col-md-12 center">
                        <h2 class="shorter"><%= "رزومه  "+ namepersonal %></h2>
                    </div>
                </div>
            </div>
            <hr class="tall">
            <div class="row">
                <div class="col-md-4">
                    <div class="swiper-container margin-bottom-10 gallery-top">
                       <div title="افراد یا شرکت هایی که این نماد را دارند مورد تایید نوبین می باشند." id="tik_comfirm" runat="server"  class="sale-flash"><span class="fa-stack "><i class="fa fa-square fa-stack-2x text-success"></i><i class="fa fa-check-square fa-stack-1x fa-inverse"></i></span></div>
                        <div class="swiper-wrapper">
                            <div class="swiper-slide">
                                <img src="<%=main_image %>" alt="<%= "تصویر "+ namepersonal %>" class="img-responsive" />
                            </div>
                        </div>
                    </div>
                    <div class="swiper-container margin-bottom-10 gallery-top">
                        <div class="swiper-wrapper">
                            <div class="swiper-slide">
                                <asp:PlaceHolder ID="plBarCode" runat="server" />
                                <%--<img src="<%=main_image_qr %>" alt="<%= "تصویر QR کد "+ namepersonal %>" class="img-responsive" height="100" width="100" />--%>
                            </div>
                        </div>
                    </div>
                    <table class="table table-condensed" dir="rtl">
                        <tbody>
                            <tr>
                                <td>آدرس این صفحه: </td>
                                <td class="text-left">
                                    <a id="txt_website" runat="server" target="_blank" class="text-left" href="#"></a></td>
                            </tr>
                            <tr id="Email_tr" runat="server">
                                <td>ایمیل:</td>
                                <td class="text-left">
                                    <a id="txt_email" runat="server" target="_blank" class="text-left" href="#">Impora@example.com</a></td>
                            </tr>
                            <asp:Repeater ID="repeater_tel" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>تلفن:</td>
                                        <td class="text-left"><a id="txt_phone1" runat="server" class="text-left" href='<%# Eval("tel_href") %>'><%# Eval("tel") %></a><a href='<%# Eval("tel_href") %>' style="color: #000000"><%# Eval("tel_internal") %></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr id="add_ress" runat="server">
                                <td>آدرس:</td>
                                <td class="text-right">
                                    <p id="add_ress_a" runat="server" class="text-right" href="#">Impora@example.com</p>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td>تلفن:</td>
                                <td class="text-left"><a id="txt_phone1" target="_blank" runat="server" class="text-left" href="#">09124950875</a></td>

                            </tr>
                            <tr>
                                <td>تلفن:</td>
                                <td class="text-left"><a id="txt_phone2" target="_blank" runat="server" class="text-left" href="#">09124950875</a></td>

                            </tr>--%>
                        </tbody>
                    </table>
                </div>
                <div class="col-md-8" dir="rtl">
                    <%--<div class="">
                        <div class="container11">
                            <img src="../img/star_0.png" />
                            <div class="crop11" id="rate_ave" runat="server">
                                <img src="../img/star_5.png" />
                            </div>
                        </div>
                        <div class="text-center">
                            &nbsp;<asp:Label ID="Label2" runat="server" Text="Vote:"></asp:Label>&nbsp;<asp:Label ID="person_vote" runat="server"></asp:Label>&nbsp;<asp:Label ID="Label5" runat="server" Text="person"></asp:Label>
                        </div>
                    </div>--%>
                    <div class="portfolio-info">
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="pull-right">
                                    <li>
                                        <i class="fa fa-calendar"></i><%= date_last_edit %>
                                    </li>
                                    <li>
                                        <i class="fa fa-tags"></i>
                                        <a href="#"><%= tags1 %></a>
                                        ,
														&nbsp;<a href="#"><%= tags2 %></a>
                                        ,
														&nbsp;<a href="#"><%= tags3 %></a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <h4 dir="rtl">توضیحات</h4>
                    <p class="taller margin-bottom-25">
                        <%= description_personal %>
                    </p>
                    <ul class="portfolio-details list-unstyled margin-top-25 text-right" dir="rtl">
                        <li>
                            <p dir="rtl">
                                <strong style="font-size: x-large">مدارک و گواهینامه ها : </strong>
                            </p>
                            <hr />
                            <ul class="timeline-xs margin-top-15 margin-bottom-15">
                                <asp:Repeater ID="repeater_education" runat="server">
                                    <ItemTemplate>
                                        <li class="timeline-item success pri">
                                            <div class="margin-right-15">
                                                <div class="text-muted text-small">
                                                    <asp:Label ID="datestartLabel" runat="server" Text='<%# Eval("date_start") %>'></asp:Label>, &nbsp;<asp:Label ID="dateendtLabel" runat="server" Text='<%# Eval("date_end") %>'></asp:Label>&nbsp; <%# Eval("city") %>
                                                </div>
                                                <p>
                                                </p>
                                                <p>
                                                    <strong style="font-size: large"><%# Eval("education") %></strong>   &nbsp;&nbsp;&nbsp;      <%# Eval("university") %>
                                                </p>
                                                <p>
                                                </p>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        <hr />
                                    </SeparatorTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                        <li>
                            <blockquote dir="rtl" class="text-right">
                                <%= about_me %>
                            </blockquote>
                        </li>
                    </ul>
                    <a href="#send_message_for_me" class="btn btn-primary btn-squared">ثبت نظر</a>
                    <div class="row">
                        <div class="padding-bottom-30 padding-top-30">
                            <div dir="rtl">
                                <p dir="rtl">
                                    <strong style="font-size: x-large">مهارت ها:</strong>
                                </p>
                                <asp:Repeater ID="repeater_skills" runat="server">
                                    <ItemTemplate>
                                        <div class="col-md-6" dir="rtl">
                                            <div class="progress progress-xs progress-animated progress-tooltip">
                                                <span style="font-size: large;"><%# Eval("skill") %></span>
                                                <div class="progress-bar" style="float: left; width: 90%;" data-percentage='<%# Convert.ToInt32(Eval("percentskill")) %>'>
                                                    <div class="progress-percent"><%# Eval("percentskill")+"%" %></div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-black">
        <div class="container">
            <div class="panel panel-white" id="activities" runat="server" dir="rtl">
                <div class="panel-heading border-light">
                    <h2 class="panel-title text-primary">رزومه</h2>
                    <paneltool class="panel-tools" tool-collapse="tool-collapse" tool-refresh="load1" tool-dismiss="tool-dismiss"></paneltool>
                </div>
                <div collapse="activities" ng-init="activities=false" class="panel-wrapper">
                    <div class="panel-body">
                        <ul class="timeline-xs margin-top-15 margin-bottom-15">
                            <asp:Repeater ID="Repeater_des_cv" runat="server">
                                <ItemTemplate>
                                    <li class="timeline-item success">
                                        <div class="margin-right-15">
                                            <div class="text-muted text-small">
                                                <asp:Label ID="datestartLabel" runat="server" Text='<%# Eval("date_start") %>'></asp:Label>, &nbsp;<asp:Label ID="dateendtLabel" runat="server" Text='<%# Eval("date_end") %>'></asp:Label>
                                            </div>
                                            <p>
                                                <strong><%# Eval("company") %></strong>  &nbsp;&nbsp;&nbsp;  <strong style="font-size: large"><%# Eval("position") %></strong>
                                            </p>
                                            <asp:Literal runat="server" Text='<%# Eval("des_project".Replace( "\r\n", "<br />" ).Replace( "\n", "<br />" )) %>' Mode="PassThrough"></asp:Literal>
                                            
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
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
                        <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="WebApplicationImpora2222025.DataClasses1DataContext" TableName="image__tbls" Where="id_user == @id_user">
                            <WhereParameters>
                                <asp:ControlParameter ControlID="user_id" PropertyName="Text" Name="id_user" Type="Int32"></asp:ControlParameter>
                            </WhereParameters>
                        </asp:LinqDataSource>
                        <asp:Label ID="user_id" runat="server" Text="" Visible="false"></asp:Label>
                        <div class="swiper-pagination swiper-pagination-white"></div>
                        <div class="swiper-button-next swiper-button-white"></div>
                        <div class="swiper-button-prev swiper-button-white"></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="post-media post-author well" dir="rtl">
            <h4>تجربیات و موضوعات مرتبط </h4>
            <asp:Repeater ID="repeater_practic" runat="server">
                <ItemTemplate>
                    <em class="padding-5">
                        <a id="LinkButton1" target="_blank" runat="server" class="btn btn-lg btn-grey" href='<%# Eval("link") %>'><%# Eval("name_page") %></a>
                    </em>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="blog-posts" dir="rtl">
                <div class="row" dir="rtl">
                    <div class="col-md-12">
                        <div class="post-media post-comments margin-top-30">
                            <div class="media">
                                <asp:ListView ID="ListView_message_messeges" runat="server">
                                    <EmptyDataTemplate>
                                        <td dir="rtl"></td>
                                    </EmptyDataTemplate>
                                    <ItemSeparatorTemplate>
                                        <br />
                                    </ItemSeparatorTemplate>
                                    <ItemTemplate>
                                        <a href="#" class="pull-right">
                                            <img loading="lazy" id="img_user_request" runat="server" src='<%# Eval("Pic") %>' alt="" class="media-object img-circle padding-15 " style="width: 80px; height: 100%">
                                        </a>
                                        <div class="media-body">
                                            <h5 class="media-heading" id="name_user_request" runat="server"><%# Eval("Name") %> </h5>
                                            <h5 class="media-heading" visible='<%# Eval("Role_visible") %>' id="role_user_request" runat="server" style="color: #0000FF"><%# Eval("Role") %> </h5>
                                            <p id="txt_message_" runat="server">
                                                <%# Eval("message") %>
                                            </p>
                                            <span id="txt_date_and_time" runat="server" class="date" style="font-size: small"><%# Eval("date_create") %> در ساعت <%# Eval("time_create") %></span>
                                            <hr>
                                            <div class="media" visible='<%# Eval("address_file_visible_reply1") %>' runat="server">
                                                <a href="#" class=" pull-right">
                                                    <img loading="lazy" id="img_user_request_reply1" runat="server" src='<%# Eval("Pic_reply1") %>' alt="" class="media-object img-circle padding-15 " style="width: 80px; height: 100%">
                                                </a>
                                                <div class="media-body">
                                                    <h5 class="media-heading" id="name_user_request_reply1" runat="server"><%# Eval("Name_reply1") %> </h5>
                                                    <h5 class="media-heading" visible='<%# Eval("Role_visible_reply1") %>' id="role_user_request_reply1" runat="server" style="color: #0000FF"><%# Eval("Role_reply1") %> </h5>
                                                    <p id="txt_message__reply1" runat="server">
                                                        <%# Eval("message_reply1") %>
                                                    </p>
                                                    <span id="txt_date_and_time_reply1" runat="server" class="date" style="font-size: small"><%# Eval("date_create_reply1") %> در ساعت <%# Eval("time_create_reply1") %></span>
                                                    <hr>
                                                </div>
                                            </div>
                                            <div class="media" visible='<%# Eval("address_file_visible_reply2") %>' runat="server">
                                                <a href="#" class=" pull-right">
                                                    <img loading="lazy" id="img_user_request_reply2" runat="server" src='<%# Eval("Pic_reply2") %>' alt="" class="media-object img-circle padding-15 " style="width: 80px; height: 100%">
                                                </a>
                                                <div class="media-body">
                                                    <h5 class="media-heading" id="name_user_request_reply2" runat="server"><%# Eval("Name_reply2") %> </h5>
                                                    <h5 class="media-heading" visible='<%# Eval("Role_visible_reply2") %>' id="role_user_request_reply2" runat="server" style="color: #0000FF"><%# Eval("Role_reply2") %> </h5>
                                                    <p id="txt_message__reply2" runat="server">
                                                        <%# Eval("message_reply2") %>
                                                    </p>
                                                    <span id="txt_date_and_time_reply2" runat="server" class="date" style="font-size: small"><%# Eval("date_create_reply2") %> در ساعت <%# Eval("time_create_reply2") %></span>
                                                    <hr>
                                                </div>
                                            </div>

                                        </div>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <div runat="server" id="itemPlaceholderContainer" style="">
                                            <div runat="server" id="itemPlaceholder" />
                                        </div>
                                        <div style="">
                                        </div>
                                    </LayoutTemplate>
                                    <SelectedItemTemplate>
                                        <li style="">
                                            <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /><br />
                                            <asp:Label Text='<%# Eval("Pic") %>' runat="server" ID="PicLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role") %>' runat="server" ID="RoleLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role_visible") %>' runat="server" ID="Role_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("des_service") %>' runat="server" ID="des_serviceLabel" /><br />
                                            <asp:Label Text='<%# Eval("subject") %>' runat="server" ID="subjectLabel" /><br />
                                            <asp:Label Text='<%# Eval("datechoosecontact") %>' runat="server" ID="datechoosecontactLabel" /><br />
                                            <asp:Label Text='<%# Eval("message") %>' runat="server" ID="messageLabel" /><br />
                                            <asp:Label Text='<%# Eval("time_create") %>' runat="server" ID="time_createLabel" /><br />
                                            <asp:Label Text='<%# Eval("date_create") %>' runat="server" ID="date_createLabel" /><br />
                                            <asp:Label Text='<%# Eval("address_file_visible") %>' runat="server" ID="address_file_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("address_file") %>' runat="server" ID="address_fileLabel" /><br />
                                            <asp:Label Text='<%# Eval("Name_reply1") %>' runat="server" ID="_reply1NameLabel" /><br />
                                            <asp:Label Text='<%# Eval("Pic_reply1") %>' runat="server" ID="_reply1PicLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role_reply1") %>' runat="server" ID="_reply1RoleLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role_visible_reply1") %>' runat="server" ID="_reply1Role_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("des_service_reply1") %>' runat="server" ID="_reply1des_serviceLabel" /><br />
                                            <asp:Label Text='<%# Eval("subject_reply1") %>' runat="server" ID="_reply1subjectLabel" /><br />
                                            <asp:Label Text='<%# Eval("datechoosecontact_reply1") %>' runat="server" ID="_reply1datechoosecontactLabel" /><br />
                                            <asp:Label Text='<%# Eval("message_reply1") %>' runat="server" ID="_reply1messageLabel" /><br />
                                            <asp:Label Text='<%# Eval("time_create_reply1") %>' runat="server" ID="_reply1time_createLabel" /><br />
                                            <asp:Label Text='<%# Eval("date_create_reply1") %>' runat="server" ID="_reply1date_createLabel" /><br />
                                            <asp:Label Text='<%# Eval("address_file_visible_reply1") %>' runat="server" ID="_reply1address_file_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("address_file_reply1") %>' runat="server" ID="_reply1address_fileLabel" /><br />
                                            <asp:Label Text='<%# Eval("Name_reply2") %>' runat="server" ID="_reply2NameLabel" /><br />
                                            <asp:Label Text='<%# Eval("Pic_reply2") %>' runat="server" ID="_reply2PicLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role_reply2") %>' runat="server" ID="_reply2RoleLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role_visible_reply2") %>' runat="server" ID="_reply2Role_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("des_service_reply2") %>' runat="server" ID="_reply2des_serviceLabel" /><br />
                                            <asp:Label Text='<%# Eval("subject_reply2") %>' runat="server" ID="_reply2subjectLabel" /><br />
                                            <asp:Label Text='<%# Eval("datechoosecontact_reply2") %>' runat="server" ID="_reply2datechoosecontactLabel" /><br />
                                            <asp:Label Text='<%# Eval("message_reply2") %>' runat="server" ID="_reply2messageLabel" /><br />
                                            <asp:Label Text='<%# Eval("time_create_reply2") %>' runat="server" ID="_reply2time_createLabel" /><br />
                                            <asp:Label Text='<%# Eval("date_create_reply2") %>' runat="server" ID="_reply2date_createLabel" /><br />
                                            <asp:Label Text='<%# Eval("address_file_visible_reply2") %>' runat="server" ID="_reply2address_file_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("address_file_reply2") %>' runat="server" ID="_reply2address_fileLabel" /><br />

                                        </li>
                                    </SelectedItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div id="send_message_for_me" class=" margin-top-20 ">
                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <div class=" margin-top-30"></div>
                        <div dir="rtl">
                            <div class=" margin-top-30">
                                <h3 dir="rtl">ارسال پیام</h3>
                                <div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-6 ">
                                                <label>نام و نام خانوادگی * </label>
                                                <asp:TextBox ID="txt_name" runat="server" MaxLength="50" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفا تکمیل نمایید" ControlToValidate="txt_name" ValidationGroup="qqqq"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6">
                                                <label>تلفن همراه * </label>
                                                <asp:TextBox ID="txt_mobile" runat="server" MaxLength="11" class="form-control" TextMode="Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفا تکمیل نمایید" ControlToValidate="txt_mobile" ValidationGroup="qqqq"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>متن پیام * </label>
                                                <asp:TextBox ID="txt_message" runat="server" MaxLength="500" class="form-control" TextMode="MultiLine" Height="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="لطفا تکمیل نمایید" ControlToValidate="txt_message" ValidationGroup="qqqq"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="Large" Visible="False"></asp:Label>
                                            <asp:Button ID="send_message" runat="server" Text="ارسال پیام" CssClass="btn btn-primary btn-wide" OnClick="send_message_Click" ValidationGroup="qqqq" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
