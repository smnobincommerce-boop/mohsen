<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Import-Company-From-Excel.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Import_Company_From_Excel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/sweetalert/sweet-alert.css" rel="stylesheet" media="screen">
    <link href="vendor/sweetalert/ie9.css" rel="stylesheet" media="screen">
    <link href="vendor/toastr/toastr.min.css" rel="stylesheet" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">وارد کردن  شرکت ها</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span>شرکت‌ها</span>
                    </li>
                    <li class="active">
                        <span>وارد کردن  شرکت ها با استفاده از فایل اکسل</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>


    <section class="container-fluid container-fullw bg-white">
        <div class="panel panel-dark padding-20">
            <div class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                وارد کردن شرکت‌ها با استفاده از فایل اکسل
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>فایل اکسل</label>
                        <asp:FileUpload ID="fileUploadExcel" runat="server" CssClass="form-control" Accept=".xlsx" />
                        <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ControlToValidate="fileUploadExcel"
                            ErrorMessage="انتخاب فایل اکسل الزامی است." ForeColor="Red" Display="Dynamic" ValidationGroup="import" />
                    </div>
                    <div class="row">
                          <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button ID="btnImport" runat="server" Text="بارگذاری فایل اکسل" CssClass="btn btn-primary"
                                    OnClick="btnImport_Click" ValidationGroup="import" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="دانلود نمونه فایل اکسل" OnClick="Button2_Click" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="بازگشت به لیست شرکت های من" OnClick="Button1_Click" />
                            </div>
                        </div>
                      
                    </div>

                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <asp:ListView ID="lvErrors" runat="server" Visible="false">
                        <EmptyDataTemplate>
                            <p dir="rtl">هیچ خطایی وجود ندارد.</p>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <p dir="rtl" style="color: red;">
                                ردیف <%# Eval("Row") %>: <%# Eval("Error") %>
                            </p>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div id="itemPlaceholderContainer" runat="server">
                                <div id="itemPlaceholder" runat="server"></div>
                            </div>
                        </LayoutTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
