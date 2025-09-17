<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="edit_steel_store_text.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.edit_steel_store_text" ValidateRequest="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <div id="div_choose" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 class="panel-title">صفحه مورد نیاز را انتخاب نمایید </h5>
                                </div>
                                <div class="panel-body">
                                    <div class="margin-bottom-20">
                                        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="3" DataKeyNames="id">
                                            <EmptyDataTemplate>
                                                <table runat="server" style="">
                                                    <tr>
                                                        <td>هیچ اطلاعاتی وجود ندارد.</td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                            <EmptyItemTemplate>
                                                <td runat="server" />
                                            </EmptyItemTemplate>
                                            <GroupTemplate>
                                                <tr runat="server" id="itemPlaceholderContainer">
                                                    <td runat="server" id="itemPlaceholder"></td>
                                                </tr>
                                            </GroupTemplate>
                                            <ItemTemplate>
                                                <span class=" margin-bottom-15 padding-bottom-20 text-center">
                                                    <asp:Button ID="Button2" runat="server" BorderStyle="Solid" Text='<%# Eval("name_page") %>' Class="btn btn-wide btn-default  btn-primary " Width="150" PostBackUrl='<%#"~/panel/maneger/edit_steel_store_text1.aspx?T="+ Eval("name_page").ToString().Replace(" ","-")+"&ID="+ Eval("id")  %>' BorderWidth="5" BorderColor="White" />
                                                    <%-- <button runat="server" ID="name_pageLabel" type="button" class="btn btn-wide btn-default btn-dark-grey ">
								
									</button>--%></span>
                                            </ItemTemplate>
                                            <LayoutTemplate>
                                                <table runat="server">
                                                    <tr runat="server">
                                                        <td runat="server">
                                                            <table runat="server" id="groupPlaceholderContainer" style="" border="0">
                                                                <tr runat="server" id="groupPlaceholder"></tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server">
                                                        <td runat="server" style=""></td>
                                                    </tr>
                                                </table>
                                            </LayoutTemplate>
                                            <SelectedItemTemplate>
                                                <td runat="server" style="">name_page:
                                                    <asp:Label Text='<%# Eval("name_page") %>' runat="server" ID="name_pageLabel" /><br />
                                                    id:
                                                    <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /><br />
                                                </td>
                                            </SelectedItemTemplate>
                                        </asp:ListView>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ImporaConnectionString %>' SelectCommand="SELECT [name_page], [id] FROM [Text_for_store_steel] ORDER BY [date_last_edit]"></asp:SqlDataSource>
                                        <div class="form-group" dir="rtl">
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
