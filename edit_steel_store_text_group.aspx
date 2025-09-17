<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="edit_steel_store_text_group.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.edit_steel_store_text_group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">افزودن دسته بندی</h1>
                <span class="mainDescription">دسته بندی های  مورد نظر را وارد نمایید</span>
            </div>
             <ol class="breadcrumb" dir="rtl">
                <li>
                    <span>فرم ها</span>
                </li>
                <li class="active">
                    <span>افزودن دسته بندی</span>
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

                <div id="div_grouping" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 runat="server" id="H2" class="panel-title">دسته بندی های مورد نیاز را وارد نمایید </h5>
                                </div>
                                <div class="panel-body">

                                    <div class="margin-bottom-20">
                                        <div class="form-group" dir="rtl">
                                            دسته بندی
                                            <asp:TextBox ID="txt_grouping" runat="server" class="form-control input" ValidationGroup="1" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_grouping" ValidationGroup="3"></asp:RequiredFieldValidator>

                                        </div>


                                        <div class="form-group" dir="rtl">

                                            <asp:Button ID="Button4" runat="server" Text="ثبت" ValidationGroup="3" CssClass="btn btn-success" OnClick="Button4_Click" />

                                        </div>



                                        <div class="margin-bottom-20">

                                            <asp:ListView ID="ListView_grouping" runat="server" OnItemCommand="ListView_grouping_ItemCommand1" DataKeyNames="id">
                                                <EmptyDataTemplate>
                                                    <table runat="server" style="">
                                                        <tr>
                                                            <td>هیچ اطلاعاتی وجود ندارد</td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" Visible="False" />
                                                    <div class="col-sm-6">
                                                        <div class="panel panel-white" id="panel3">
                                                            <div class="panel-heading">
                                                                <i class=" fa fa-tag" style="color: #33CC33" dir="rtl"></i>&nbsp;
													<h4 class="panel-title text-primary"><%# Eval("group") %></h4>
                                                                <div class="panel-tools">
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" CommandName="del" ImageUrl="../../img/close.png" ToolTip="حذف" Height="20" CssClass="" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>



                                                </ItemTemplate>
                                                <LayoutTemplate>
                                                    <table runat="server">
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">

                                                                    <tr runat="server" id="itemPlaceholder"></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" style=""></td>
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>
                                                <SelectedItemTemplate>
                                                    <selecteditemtemplate>
                                                                                <td runat="server" style="">
                <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /><br />
                                                                                    
                <asp:Label Text='<%# Eval("group") %>' runat="server" ID="groupLabel" /><br />
                                                                                    
                                                                                    
                                                                                </td>
                                                                            </selecteditemtemplate>


                                                </SelectedItemTemplate>
                                            </asp:ListView>


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
