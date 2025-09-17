<%@ Page Title=""  ValidateRequest="false"  Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="create_daily_activity.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.create_daily_activity" %>

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
                <h1 class="mainTitle">ثبت کارکرد روزانه</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span>کارکردها</span>
                    </li>
                    <li class="active">
                        <span>ثبت کارکرد روزانه</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>
    <section class="panel panel-white no-radius">
        <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
            ثبت کارکرد روزانه
        </div>
        <div class="right">
            <div class="col-sm-12">
                <div class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                    فرم ثبت کارکرد
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>توضیحات روز:</label>
                                    <textarea id="txtDescription" runat="server" class="form-control" cols="20" rows="5" style="width: 100%; height: 200px;" maxlength="950"></textarea>

                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                        ErrorMessage="توضیحات روز الزامی است." CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>تاریخ (شمسی):</label>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>زمان شروع کار:</label>
                                    <asp:TextBox ID="txtTimeOpen" runat="server" CssClass="form-control" Type="time" />
                                    <asp:RequiredFieldValidator ID="rfvTimeOpen" runat="server" ControlToValidate="txtTimeOpen"
                                        ErrorMessage="زمان شروع الزامی است." CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>زمان پایان کار :</label>
                                    <asp:TextBox ID="txtTimeClose" runat="server" CssClass="form-control" Type="time" />
                                    <asp:RequiredFieldValidator ID="rfvTimeClose" runat="server" ControlToValidate="txtTimeClose"
                                        ErrorMessage="زمان پایان الزامی است." CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6" style="display: none">
                                <div class="form-group">
                                    <label>تعداد پیگیری‌ها:</label>
                                    <asp:TextBox ID="txtFollowupCount" runat="server" CssClass="form-control" Type="number" min="0" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="col-md-6" style="display: none">
                                <div class="form-group">
                                    <label>تعداد شرکت‌های ایجاد شده:</label>
                                    <asp:TextBox ID="txtCreatedCompaniesCount" runat="server" CssClass="form-control" Type="number" min="0" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button ID="btnCreate" runat="server" Text="ثبت کارکرد" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
                                </div>
                            </div>
                            
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-primary pull-right" ID="btnBack" runat="server" Text="بازگشت" OnClick="btnBack_Click" />
                                </div>
                            </div>
                            <div class="col-md-4" style="display:none">
                                <div class="form-group">
                                    <asp:Button ID="btnList" runat="server" Text="لیست کارکردها" CssClass="btn btn-primary" OnClick="btnList_Click" />
                                </div>
                            </div>
                            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
