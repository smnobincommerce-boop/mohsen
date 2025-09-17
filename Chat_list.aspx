<%@ Page Title="" ValidateRequest="false"  Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Chat_list.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Chat_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">لیست افراد برای چت</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span>کارمندان</span>
                    </li>
                    <li class="active">
                        <span>لیست چت</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="blog-posts">
                <div class="row">
                    <div class="col-md-12">
                        <div class="post-media post-comments margin-top-30">
                            <div class="media">
                                <asp:ListView ID="StaffListView" runat="server">
                                    <LayoutTemplate>
                                        <div class="row" dir="rtl">
                                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                        </div>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div class="col-md-6" style="margin-bottom: 20px;">
                                            <div class="tile" style="border: 1px solid #ddd; border-radius: 5px; padding: 15px; background-color: #f9f9f9; direction: rtl;">
                                                <div class="media">
                                                    <a href="#" class="pull-right">
                                                        <img src='<%# string.IsNullOrEmpty(Eval("Pic").ToString()) ? "../../img/default-user.png" : Eval("Pic") %>'
                                                            alt="عکس کارمند" class="media-object img-circle padding-15" style="width: 80px; height: 80px;" />
                                                    </a>
                                                    <div class="media-body">
                                                        <h5 class="media-heading"><%# Eval("Name") %> <%# Eval("Lastname") %></h5>
                                                        <h5 class="media-heading" style="color: #0000FF"><%# Eval("Role") %></h5>
                                                        <div class="form-group" style="margin-top: 10px;">
                                                            <asp:Button ID="btnChat" runat="server" Text="چت"
                                                                CssClass="btn btn-success pull-left" CommandArgument='<%# Eval("id") %>'
                                                                OnClick="btnChat_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <div class="text-center" style="padding: 20px;">
                                            هیچ فردی برای چت یافت نشد.
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
