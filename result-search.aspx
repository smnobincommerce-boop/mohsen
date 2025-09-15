<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="result-search.aspx.cs" Inherits="WebApplicationImpora2222025.result_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" href="favicon.ico" />
    <meta name="genre" itemprop="genre" content="information" />
    <meta itemprop="inLanguage" content="fa" />
    <meta http-equiv="Content-Language" content="fa" />
    <meta http-equiv="content-language" content="fa" />
    <meta property="article:modified_time" content="21/6/2021" />
    <meta itemprop="datePublished" property="article:published_time" content="21/6/2021" />
    <meta itemprop="dateModified" property="article:modified" content="21/6/2021" />
    <meta id="authorpage" content="بازرگانی نوبین   | Nobin Commerce" name="author" />
    <meta name="thumbnail" itemprop="thumbnailUrl" content="https://nobincommerce.com/img/NLogo-Fa.svg" />
    <meta name="generator" content="https://nobincommerce.com" />
    <meta name="language" content="fa" />
    <meta name="rating" content="General" />
    <meta name="copyright" content="© 2021 Nobin Commerce (https://nobincommerce.com). All rights reserved" />
    <meta name="expires" content="never" />
    <meta name="robots" content="INDEX,FOLLOW" />
    <meta name="publisher" content="بازرگانی نوبین   | Nobin Commerce" />
    <meta name="dc.publisher" content="بازرگانی نوبین   | Nobin Commerce" />
    <meta name="date" content="21/6/2021" />
    <meta property="og:locale" content="fa_IR">
    <meta property="og:title" itemprop="headline" content="<%= title_pg %>" />
    <meta property="og:type" content="article" />
    <meta property="og:description" content="<%= description_pg %>" />
    <meta property="og:site_name" content="بازرگانی نوبین   | Nobin Commerce" />
    <meta property="article:author" content="https://www.facebook.com/Impora-group-345846069509658/" />
    <meta property="article:section" content="جستجو در نوبین" />
    <meta property="og:url" content="https://nobincommerce.com" />
    <meta property="og:image" content="https://nobincommerce.com/img/NLogo-Fa.svg" />
    <meta property="og:image:alt" content="نوبین | تخصص در واردات و تامین کالاهای بازرگانی" />
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:site" content="@Impora1" />
    <meta name="twitter:title" content="<%= title_pg %>" />
    <meta name="twitter:description" content="<%= description_pg %>" />
    <meta name="twitter:creator" content="@Impora1" />
    <meta name="twitter:image:src" content="https://nobincommerce.com/img/NLogo-Fa.svg" />
    <meta name="twitter:image:alt" content="نوبین - خدمات تخصصی واردات و ترخیص کالا" />
    <meta name="twitter:domain" content="https://nobincommerce.com" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="margin-bottom-30">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="search-classic" dir="rtl">
                                    <div>
                                        <div class="input-group well" dir="rtl">
                                            <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>

                                            <span class="input-group-btn">
                                                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="" ImageUrl="~/img/UC_SEARCH_ICON_170616.PNG" ImageAlign="Middle" OnClick="ImageButton1_Click" Width="30" />
                                            </span>
                                        </div>
                                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="clip-check  check-success" Text=" از موتور جستجو گوگل کمک بگیر" Font-Names="b koodak" Font-Size="Large" TextAlign="Right" />
                                    </div>

                                    <h3 id="head" runat="server" dir="rtl"></h3>
                                    <hr>
                                    <div id="Div2" runat="server">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:ListView ID="ListView2" runat="server" GroupItemCount="3">
                                                    <EmptyDataTemplate>
                                                        <table runat="server" style="">
                                                            <tr>
                                                                <td></td>
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
                                                        <div dir="rtl" id="Div17" runat="server" class="search-result">

                                                            <h4><a target="_blank" href='<%#Eval("address") %>' id="A17" runat="server">'<%#Eval("title") %>'</a></h4>
                                                            <a target="_blank" href='<%#Eval("address") %>' id="B17" runat="server">مشاهده جزئیات</a>
                                                            <p id="P17" runat="server" style="color: #008000">
                                                                '<%#Eval("address") %>' 
                                                            </p>
                                                        </div>
                                                        <hr />
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
                                                                <td runat="server" style="">
                                                                    <asp:DataPager runat="server" PageSize="100" ID="DataPager2">
                                                                        <Fields>
                                                                        </Fields>
                                                                    </asp:DataPager>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <SelectedItemTemplate>
                                                        <td runat="server" style="">
                                                            <asp:Label Text='<%# Eval("title") %>' runat="server" ID="id_CompanyLabel" /><br />

                                                            <asp:Label Text='<%# Eval("address") %>' runat="server" ID="name_company_faLabel" /><br />
                                                        </td>
                                                    </SelectedItemTemplate>
                                                </asp:ListView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
