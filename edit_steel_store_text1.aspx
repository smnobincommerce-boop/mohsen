<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="edit_steel_store_text1.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.edit_steel_store_text1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/sweetalert/sweet-alert.css" rel="stylesheet" media="screen">
    <link href="vendor/sweetalert/ie9.css" rel="stylesheet" media="screen">
    <link href="vendor/toastr/toastr.min.css" rel="stylesheet" media="screen">
    <script type="text/javascript" src="../../Scripts/tinymce/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            selector: "textarea",
            language: 'fa',
            plugins: 'link',
            menubar: true,
            statusbar: true,
            directionality: 'rtl', // تنظیم راست‌به‌چپ
            toolbar: 'ltr rtl', // دکمه‌های تغییر جهت در تولبار
            plugins: 'advlist autolink link image lists charmap print preview',
            paste_auto_cleanup_on_paste: true,
            paste_postprocess: function (pl, o) {
                o.node.innerHTML = o.node.innerHTML.replace(/&nbsp;/ig, " ");
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">ادیت صفحات خدمات</h1>
                <span class="mainDescription">صفحه مورد نظر را انتخاب نمایید</span>
            </div>
             <ol class="breadcrumb" dir="rtl">
                <li>
                    <span>فرم ها</span>
                </li>
                <li class="active">
                    <span>ادیت صفحات خدمات</span>
                </li>
            </ol>
        </div>
    </section>

    <div id="success_message" runat="server" role="alert" class="alert alert-success padding-40" visible="false">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        <strong>موفق!</strong>
        <asp:Label ID="success_Label" runat="server" Text=""></asp:Label>
    </div>

    <div id="warning_message" runat="server" class="alert alert-warning padding-40" visible="false">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        <strong>توجه!</strong>
        <asp:Label ID="warning_Label" runat="server" Text=""></asp:Label>



    </div>

    <div class="right ">
        <div class="col-sm-12">
            <section class="panel panel-white no-radius">
                <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                    ادیت متن صفحات
                </div>
                <div id="div_edit" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 runat="server" id="title_edit" class="panel-title">اطلاعات مورد نیاز را وارد نمایید </h5>
                                </div>
                                <div class="panel-body">

                                    <div class="form-group " dir="rtl">
                                        <asp:Button ID="Button6" runat="server" Text="دسته بندی ها" CssClass="btn btn-primary btn-lg" OnClick="Button6_Click" Width="200" />

                                        <asp:Button ID="Button5" runat="server" Text="تگ ها" CssClass="btn btn-primary btn-lg" OnClick="Button5_Click" Width="200" />
                                        <asp:Button ID="Button7" runat="server" Text="مشاهده متن بارگذاری شده" CssClass="btn  btn-success btn-lg" OnClick="Button7_Click" Width="300" />
                                         <asp:Button ID="Button2" runat="server" Text="اسلایدر" CssClass="btn btn-primary btn-lg" OnClick="Button2_Click" Width="200" />

                                    </div>

                                    <div class="margin-bottom-20">
                                        <div class="form-group" dir="rtl">
                                            تیتر صفحه
                                              <asp:TextBox ID="txt_title" runat="server" class="form-control input" ValidationGroup="1" MaxLength="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_title" ValidationGroup="1"></asp:RequiredFieldValidator>

                                        </div>

                                        <div class="form-group" dir="rtl">
                                            توضیحات  صفحه
                                              <asp:TextBox ID="txt_description" runat="server" class="form-control input" ValidationGroup="1" MaxLength="300"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_description" ValidationGroup="1"></asp:RequiredFieldValidator>

                                        </div>





                                        <%--  <div class="main-content">
                                            <div class="wrap-content container" id="container">
                                                <!-- start: PAGE TITLE -->

                                                <!-- end: PAGE TITLE -->
                                                <!-- start: TEXT EDITOR -->
                                                <div class="container-fluid container-fullw bg-white">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h5 class="over-title">WYSIWYG <span class="text-bold">Editor</span></h5>
                                                            <p class="margin-bottom-30">
                                                                CKEditor is a ready-for-use HTML text editor designed to simplify web content creation. It's a WYSIWYG editor that brings common word processor features directly to your web pages. Enhance your website experience with our community maintained editor.
                                                            </p>
                                                            <textarea class="ckeditor form-control" cols="20" rows="10"></textarea>

                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- end: TEXT EDITOR -->
                                            </div>
                                        </div>
                                        --%>






                                        <div class="form-group" dir="rtl">
                                            متن اصلی
    <asp:TextBox ID="txt_full_text" runat="server" class="form-control " TextMode="MultiLine" ValidationGroup="1" Height="500" Visible="True" CssClass=" text-right"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_full_text" ValidationGroup="1"></asp:RequiredFieldValidator>--%>
                                        </div>

                                        <%-- <div class="form-group" dir="rtl"  >
                                            تاریخ انتشار:<br />
                                            <asp:Label ID="txt_date_publish_" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>

                                        </div>
                                        <div class="form-group" dir="rtl">
                                            تاریخ آخرین ادیت:<br />
                                            <asp:Label ID="txt_date_edit_" runat="server" Text="" Font-Size="X-Large"></asp:Label>

                                        </div>--%>
                                        <em>لینک کنونیکال در صورت نیاز پر شود</em>
                                        <div class="form-group" dir="rtl">
                                            لینک کنونیکال
    <asp:TextBox ID="txt_Canonical_url" runat="server" class="form-control " ValidationGroup="1" TextMode="Url"></asp:TextBox>

                                        </div>
                                        <div class="form-group" dir="rtl">
                                            انتشار/پیش نویس
    <asp:DropDownList ID="txt_pub_or_notpub" runat="server" class="form-control " ValidationGroup="1">
         <asp:ListItem ></asp:ListItem>
        <asp:ListItem >انتشار</asp:ListItem>
        <asp:ListItem>پیش نویس</asp:ListItem>
    </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_pub_or_notpub" ValidationGroup="1"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="form-group" dir="rtl">
                                            ربات
    <asp:DropDownList ID="txt_robots_I" runat="server" class="form-control" ValidationGroup="1">
         <asp:ListItem ></asp:ListItem>
        <asp:ListItem >INDEX</asp:ListItem>
        <asp:ListItem>NOINDEX</asp:ListItem>

    </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_robots_I" ValidationGroup="1"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="form-group" dir="rtl">
                                            ربات
    <asp:DropDownList ID="txt_robots_f" runat="server" class="form-control" ValidationGroup="1">
         <asp:ListItem ></asp:ListItem>
        <asp:ListItem >FOLLOW</asp:ListItem>
        <asp:ListItem>NOFOLLOW</asp:ListItem>

    </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_robots_f" ValidationGroup="1"></asp:RequiredFieldValidator>

                                        </div>
                                          <em>اندازه تصویر 2000*1333 px
                                        </em>
                                        <div class="form-group" dir="rtl">
                                            بارگذاری تصویر
    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control " />
                                              </div>
                                        <%--         <div class="form-group" dir="rtl">
                        بارگذاری تصویر کم حجم
    <asp:FileUpload ID="FileUpload2"  runat="server"  class="form-control " />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="FileUpload2" ValidationGroup="1"></asp:RequiredFieldValidator>

                    </div>--%>

                                        <div class="form-group pull-left" dir="ltr">
                                            <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="1" CssClass="btn btn-success" OnClick="Button1_Click" Width="200" />
                                            <%--با هر بار ادیت عکس صفحه را هم بارگذاری نمایید--%>
                                        </div>
                                    </div>










                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </section>
        </div>
    </div>

     <script src="vendor/sweetalert/sweet-alert.min.js"></script>
    <script src="vendor/toastr/toastr.min.js"></script>
    <script>
        jQuery(document).ready(function () {
            Main.init();

        });
    </script>
</asp:Content>
