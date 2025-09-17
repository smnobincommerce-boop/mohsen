<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="chang_number_contact.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.chang_number_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">تغییر شماره وب سایت</h1>
                <span class="mainDescription">تغییر شماره وب سایت به صورت آنی </span>
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
                <div id="lbl_name_page" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                </div>
                <div class="form">
                    <div class="panel panel-white no-radius">
                        <div class="panel-body">
                            <div class="form-group" id="address_file" runat="server">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem>66396090</asp:ListItem>
                                    <asp:ListItem>90000011</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="form-group" dir="rtl">
                                <asp:Button ID="Button4" runat="server" Text="فعال سازی" CssClass="btn btn-success" OnClick="Button4_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>


</asp:Content>
