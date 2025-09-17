<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="exact_page.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.exact_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">تنظیم صفحات سایت</h1>
            </div>
            <ol class="breadcrumb" dir="rtl">

                <li class="active">
                    <span>درج صفحات سایت</span>
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
                    تنظیم صفحات سایت 
                </div>
                <div id="div_newpost" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 class="panel-title">لطفا اطلاعات مورد نیاز را وارد نمایید </h5>
                                </div>
                                <div class="panel-body">
                                    <div class="margin-bottom-20">
                                        <div class="form-group" dir="rtl">
                                            دسته بندی
    <asp:DropDownList ID="txt_folder1" runat="server" class="form-control" ValidationGroup="1">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>account</asp:ListItem>
        <asp:ListItem>blog</asp:ListItem>
        <asp:ListItem>news</asp:ListItem>
        <asp:ListItem>specialized-services</asp:ListItem>
        <asp:ListItem>steel-store</asp:ListItem>

    </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_folder1" ValidationGroup="1"></asp:RequiredFieldValidator>--%>

                                        </div>
                                        <div class="form-group" dir="rtl">
                                            دسته بندی
    <asp:DropDownList ID="txt_folder2" runat="server" class="form-control" ValidationGroup="1">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Consulting</asp:ListItem>
        <asp:ListItem>design</asp:ListItem>
        <asp:ListItem>executive</asp:ListItem>
        <asp:ListItem>legal</asp:ListItem>
        <asp:ListItem>bar</asp:ListItem>
        <asp:ListItem>beam</asp:ListItem>
        <asp:ListItem>pipe</asp:ListItem>
        <asp:ListItem>profiles</asp:ListItem>
        <asp:ListItem>rebar</asp:ListItem>
        <asp:ListItem>sheet</asp:ListItem>
    </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_folder2" ValidationGroup="1"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="form-group" dir="rtl">
                                            تیتر صفحه
                                              <em>ورق گالوانیزه چیست و چه عاملی بر قیمت آن مؤثر است؟</em><asp:TextBox ID="txt_title" runat="server" class="form-control input" ValidationGroup="1" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_title" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group" dir="rtl">
                                            آدرس صفحه بدون تکست
                                              <asp:TextBox ID="txt_address" runat="server" class="form-control input" ValidationGroup="1" MaxLength="1000"></asp:TextBox>
                                           <em>https://nobincommerce.com/steel-store/sheet/galvanized-sheet</em> <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_address" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group" dir="rtl">
                                            آدرس  صفحه با تکست
                                              <asp:TextBox ID="txt_address_with_text" runat="server" class="form-control input" ValidationGroup="1" MaxLength="4000" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                           <em>https://nobincommerce.com/steel-store/sheet/galvanized-sheet?T=ورق-گالوانیزه-چیست-و-چه-عاملی-بر-قیمت-آن-مؤثر-است؟</em> <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_address_with_text" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group " dir="ltr">
                                            <asp:Button ID="save_newpage" runat="server" Text="ثبت  یا آپدیت یک صفحه در دیتا بیس" ValidationGroup="1" CssClass="btn btn-success" OnClick="save_newpage_Click" Width="200" />
                                        </div>
                                        <div class="form-group " dir="ltr">
                                            <asp:Button ID="update_newpage" runat="server" Text="آپدیت صفحات بر اساس دیتا بیس"  CssClass="btn btn-danger" OnClick="update_newpage_Click" Width="200" />
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
</asp:Content>



