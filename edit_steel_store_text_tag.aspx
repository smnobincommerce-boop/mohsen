<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="edit_steel_store_text_tag.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.edit_steel_store_text_tag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">افزودن کلمه کلیدی</h1>
                <span class="mainDescription">کلمه کلیدی های  مورد نظر را وارد نمایید</span>
            </div>
             <ol class="breadcrumb" dir="rtl">
                <li>
                    <span>فرم ها</span>
                </li>
                <li class="active">
                    <span>افزودن کلمه کلیدی</span>
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
                <div id="div_tags" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 runat="server" id="H1" class="panel-title">تگ های مورد نیاز را وارد نمایید </h5>
                                </div>
                                <div class="panel-body">



                                    <div class="margin-bottom-20">
                                        <div class="form-group" dir="rtl">
                                            تگ ها
                                             <asp:TextBox ID="txt_tags" runat="server" class="form-control input" ValidationGroup="1" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt_tags" ValidationGroup="2"></asp:RequiredFieldValidator>

                                        </div>



                                        <div class="form-group" dir="rtl">

                                            <asp:Button ID="Button3" runat="server" Text="ثبت" ValidationGroup="2" CssClass="btn btn-success" OnClick="Button3_Click" />
                                        </div>


                                        <div class="margin-bottom-20">

                                            <asp:ListView ID="ListView_tag" runat="server" OnItemCommand="ListView_tag_ItemCommand1" DataKeyNames="id">

                                                <EmptyDataTemplate>
                                                    <table runat="server" style="">
                                                        <tr>
                                                            <td>هیچ اطلاعاتی وجود ندارد</td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>

                                                <ItemTemplate>

                                                    <div class="col-sm-6">
                                                        <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" Visible="False" />
                                                        <div class="panel panel-white" id="panel3">
                                                            <div class="panel-heading">
                                                                <i class=" fa fa-tag" style="color: #33CC33" dir="rtl"></i>&nbsp;
											            		<h4 class="panel-title text-primary"><%# Eval("tag") %></h4>
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
                                                                                    
                                                   <asp:Label Text='<%# Eval("tag") %>' runat="server" ID="tagLabel" /><br />
                                                                                    
                                                                                    
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
