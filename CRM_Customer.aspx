<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="CRM_Customer.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.CRM_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">ارسال پیامک به مشتریان CRM</h1>
            </div>
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
                    ارسال پیامک به مشتریان CRM 
                </div>
                <div id="div_choose" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 id="txt_matn" runat="server" class="panel-title">صفحه مورد نیاز خود را از ساید بار انتخاب نمایید </h5>
                                </div>
                                <div class="panel-body">
                                    <div class="margin-bottom-20">
                                        <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                            <tr class=" text-center" dir="rtl">
                                                <td style="width: 20%">نام کالا</td>
                                                <td style="width: 7%">ابعاد/سایز</td>
                                                <td style="width: 7%">برند</td>
                                                <td style="width: 15%">قیمت</td>
                                            </tr>
                                            <tr class=" text-center"  runat="server" id="Tr1">
                                                <td runat="server" id="Tdi1" style="width: 20%">نام کالا</td>
                                                <td runat="server" id="Tdi2" style="width: 20%">ابعاد/سایز</td>
                                                <td runat="server" id="Tdi3" style="width: 20%">برند</td>
                                                <td runat="server" id="Tdi4" style="width: 20%">
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr class=" text-center"  runat="server" id="Tr2">
                                                <td runat="server" id="Tdk1" style="width: 20%">نام کالا</td>
                                                <td runat="server" id="Tdk2" style="width: 20%">ابعاد/سایز</td>
                                                <td runat="server" id="Tdk3" style="width: 20%">برند</td>
                                                <td runat="server" id="Tdk4" style="width: 20%">
                                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr class=" text-center"  runat="server" id="Tr3">
                                                <td runat="server" id="Tdj1" style="width: 20%">نام کالا</td>
                                                <td runat="server" id="Tdj2" style="width: 20%">ابعاد/سایز</td>
                                                <td runat="server" id="Tdj3" style="width: 20%">برند</td>
                                                <td runat="server" id="Tdj4" style="width: 20%">
                                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class=" text-center"  runat="server" id="Tr4">
                                                <td runat="server" id="Td1" style="width: 30%">
                                                    <asp:Button ID="test" runat="server" Text="Test" OnClick="test_Click" CssClass="btn btn-success" />
                                                </td>
                                                <td runat="server" id="Td2" style="width: 20%"></td>
                                                <td runat="server" id="Td3" style="width: 20%"></td>
                                                <td runat="server" id="Td4" style="width: 30%">
                                                    <asp:Button ID="save" runat="server" Text="Send all" OnClick="send_Click" CssClass="btn btn-success" />

                                                </td>
                                            </tr>

                                        </table>
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
