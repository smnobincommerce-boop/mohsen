<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Edit_Info_Company.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Edit_Info_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">ایجاد یا ویرایش شرکت</h1>
            </div>
            <div class=" pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span>شرکت‌ها</span>
                    </li>
                    <li class="active">
                        <span>ایجاد یا ویرایش شرکت</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>

    <div class="right">
        <div class="col-sm-12">
            <section class="panel panel-white no-radius">
                <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                </div>

                <div class="right">
                    <div class="col-sm-12">
                        <div id="panel_overview" class="tab-pane fade in active">
                            <div role="form">
                                <fieldset>
                                    <legend>اطلاعات شرکت و افراد مرتبط با آن</legend>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>نام شرکت <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="txtCompanyName"
                                                    ErrorMessage="نام شرکت الزامی است." CssClass="error-message" Display="Dynamic" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>نام شخص</label>
                                                <asp:TextBox ID="txtPersonName" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>سمت</label>
                                                <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>شماره تلفن</label>
                                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>شماره موبایل</label>
                                                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>ایمیل</label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>وب‌سایت</label>
                                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>آدرس</label>
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" MaxLength="500"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>زمینه فعالیت</label>
                                                <asp:TextBox ID="txtFieldOfActivity" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>توضیحات</label>
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" MaxLength="1000"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group" id="shenase" runat="server">
                                                <label>شناسه مدیر (اختیاری)</label>
                                                <asp:TextBox ID="txtManagerId" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revManagerId" runat="server" ControlToValidate="txtManagerId"
                                                    ValidationExpression="^\d+$" ErrorMessage="شناسه مدیر باید عدد باشد." CssClass="error-message" Display="Dynamic" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group" id="btn_create" runat="server">
                                                <asp:Button ID="btnCreateCompany" runat="server" Text="ایجاد شرکت" CssClass="btn btn-primary" OnClick="btnCreateCompany_Click" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group" id="btn_edit" runat="server">
                                                <asp:Button ID="btnUpdateCompany" runat="server" Text="به‌روزرسانی شرکت" CssClass="btn btn-primary" OnClick="btnUpdateCompany_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="لغو" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false" />
                                            </div>
                                            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="بازگشت به لیست شرکت های من" OnClick="Button1_Click1" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

