<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="favorite_links_pages.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.favorite_links_pages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../bower_components/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("button[name=first_pages]").click(function () {
                if ($(this).val() == "first_pages1") {
                    $("#divall").show();
                    $("#divfirst_pages").show();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=steel]").click(function () {
                if ($(this).val() == "steel1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").show();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=s_design]").click(function () {
                if ($(this).val() == "s_design1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").show();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=s_executive]").click(function () {
                if ($(this).val() == "s_executive1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").show();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=s_legal]").click(function () {
                if ($(this).val() == "s_legal1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").show();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=s_consult]").click(function () {
                if ($(this).val() == "s_consult1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").show();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=blog]").click(function () {
                if ($(this).val() == "blog1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").show();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=news]").click(function () {
                if ($(this).val() == "news1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").show();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=milgerd]").click(function () {
                if ($(this).val() == "milgerd1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").show();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }

            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=bar]").click(function () {
                if ($(this).val() == "bar1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").show();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=varagh]").click(function () {
                if ($(this).val() == "varagh1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").show();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=loole]").click(function () {
                if ($(this).val() == "loole1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").show();
                    $("#divtir").hide();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=tir]").click(function () {

                if ($(this).val() == "tir1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").show();
                    $("#divprofil").hide();
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("button[name=profil]").click(function () {
                if ($(this).val() == "profil1") {
                    $("#divall").show();
                    $("#divfirst_pages").hide();
                    $("#divs_design").hide();
                    $("#divs_executive").hide();
                    $("#divs_s_legal").hide();
                    $("#divs_consult").hide();
                    $("#divs_blog").hide();
                    $("#divs_news").hide();
                    $("#divsteel").hide();
                    $("#divmilgerd").hide();
                    $("#divvaragh").hide();
                    $("#divbar").hide();
                    $("#divloole").hide();
                    $("#divtir").hide();
                    $("#divprofil").show();
                }
            });
        });
    </script>
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">تعیین لینک مرتبط صفحات</h1>
                <span class="mainDescription">تولید لینک های مرتبط با خدمات تخصصی</span>
            </div>
        </div>
    </section>
    <asp:Panel ID="panel_pages" runat="server">
        <div id="panel_overview" class="tab-pane fade in active">
            <div role="form">
                <fieldset>
                    <legend>لیست
                    </legend>
                    <div class="row">
                        <div class="row space20">
                            <div id="divall">
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="first_pages" value="first_pages1" name="first_pages">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        صفحات اولیه
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="steel" value="steel1" name="steel">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        فروشگاه 
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="s_design" value="s_design1" name="s_design">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        خدمات طراحی
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="s_executive" value="s_executive1" name="s_executive">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        خدمات اجرایی
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="s_legal" value="s_legal1" name="s_legal">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        خدمات حقوقی ساختمان
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="s_consult" value="s_consult1" name="s_consult">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        خدمات مشاوره ای ساختمان
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="blog" value="blog1" name="blog">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        وبلاگ
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="news" value="news1" name="news">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        اخبار
                                    </button>
                                </div>
                            </div>
                            <div id="divfirst_pages" style="display: none">
                                <asp:Repeater ID="Repeater_first_pages" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 ">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divs_design" style="display: none">
                                <asp:Repeater ID="Repeater_s_design" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 ">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divs_executive" style="display: none">
                                <asp:Repeater ID="Repeater_s_executive" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 ">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divs_s_legal" style="display: none">
                                <asp:Repeater ID="Repeater_s_legal" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 ">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divs_consult" style="display: none">
                                <asp:Repeater ID="Repeater_s_consult" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-3 ">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divs_blog" style="display: none">
                                <asp:Repeater ID="Repeater_blog" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12 ">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divs_news" style="display: none">
                                <asp:Repeater ID="Repeater_news" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divsteel" style="display: none">
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="milgerd2" value="milgerd1" name="milgerd">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        میلگرد
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="varagh2" value="varagh1" name="varagh">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        ورق
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="profil2" value="profil1" name="profil">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        پروفیل
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="bar2" value="bar1" name="bar">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        بار
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="loole2" value="loole1" name="loole">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        لوله
                                    </button>
                                </div>
                                <div class="col-sm-6">
                                    <button type="button" class="btn btn-icon margin-bottom-5 btn-block" id="tir2" value="tir1" name="tir">
                                        <i class=" ti-list block text-primary text-extra-large margin-bottom-10"></i>
                                        تیر
                                    </button>
                                </div>
                            </div>
                            <div id="divmilgerd" style="display: none">
                                <asp:Repeater ID="Repeater_milgerd" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divprofil" style="display: none">
                                <asp:Repeater ID="Repeater_profil" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divloole" style="display: none">
                                <asp:Repeater ID="Repeater_loole" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divtir" style="display: none">
                                <asp:Repeater ID="Repeater_tir" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divbar" style="display: none">
                                <asp:Repeater ID="Repeater_bar" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divvaragh" style="display: none">
                                <asp:Repeater ID="Repeater_varagh" runat="server">
                                    <ItemTemplate>
                                        <div class="col-sm-12">
                                            <a class="btn btn-icon margin-bottom-5 btn-block " href='<%# Eval("url") %>'>
                                                <i class=" ti-bolt block text-primary text-extra-large margin-bottom-10"></i>
                                                <%# Eval("name_page") %> 
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panel_table" runat="server">
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
                                    <asp:TextBox ID="txt_link" runat="server" class="form-control input"></asp:TextBox>
                                </div>
                                <div class="form-group" dir="rtl">
                                    <asp:Button ID="Button4" runat="server" Text="ذخیره" CssClass="btn btn-success" OnClick="Button4_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="form">
                        <div class="panel panel-white no-radius">
                            <div class="panel-body">
                                <div class="form-group" id="Div1" runat="server">
                                    دسته بندی دانشنامه
                                    <asp:DropDownList ID="txt_group_weblog" runat="server" class="form-control" ValidationGroup="1">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>معماری</asp:ListItem>
                                        <asp:ListItem>عمران</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="txt_group_weblog" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group" id="Div2" runat="server">
                                    دسته بندی اخبار
                                <asp:DropDownList ID="txt_group_news" runat="server" class="form-control" ValidationGroup="1">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>بازار مسکن</asp:ListItem>
                                    <asp:ListItem>بازار فولاد</asp:ListItem>
                                    <asp:ListItem>حوزه فنی مهندسی</asp:ListItem>
                                </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="txt_group_news" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group" dir="rtl">
                                    <asp:Button ID="Button1" runat="server" Text="ذخیره دسته بندی ها" CssClass="btn btn-success" OnClick="Button1_Click" ValidationGroup="1" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div id="div_choose" runat="server" class="panel-body">
                        <div class="form">
                            <div class="text-right col-sm-12 " dir="rtl">
                                <div class="panel panel-white no-radius">
                                    <div class="panel-body">
                                        <div class="margin-bottom-20">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:ListView ID="ListView_table_link" OnItemCommand="ListView_table_link_ItemCommand" runat="server">
                                                        <EmptyDataTemplate>
                                                            <table runat="server" style="">
                                                                <tr dir="rtl">
                                                                    <td dir="rtl">هیچ اطلاعاتی جهت آپدیت وجود ندارد.
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EmptyDataTemplate>
                                                        <ItemTemplate>
                                                            <tr class=" text-center" style="border-style: solid none solid none; border-width: thin; border-color: #FFFFFF; height: 80px">
                                                                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" ForeColor="#F7F6F3"></asp:Label>
                                                                <td>
                                                                    <div class="CartDescription text-center">
                                                                        <asp:Label ID="Name_pageLabel" runat="server"><%# Eval("Name_page") %></asp:Label>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="CartDescription text-center">
                                                                        <asp:Label ID="linkLabel" runat="server"><%# Eval("link") %></asp:Label>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="ImageButton1" runat="server" CommandName="delet" ToolTip="حذف"><img src="../../img/delete_icon.png" style="height:20px; width:20px;"/></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <LayoutTemplate>
                                                            <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                                                <tr class=" text-center" dir="rtl">
                                                                    <td style="width: 20%">نام صفحه</td>
                                                                    <td style="width: 168%">لینک</td>
                                                                    <td style="width: 12%">حذف</td>
                                                                </tr>
                                                                <tr runat="server" id="itemPlaceholder"></tr>
                                                            </table>
                                                        </LayoutTemplate>
                                                        <SelectedItemTemplate>
                                                            <tr style="">
                                                                <td>
                                                                    <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /></td>
                                                                <td>
                                                                    <asp:Label Text='<%# Eval("Name_page") %>' runat="server" ID="Name_pageLabel" /></td>
                                                                <td>
                                                                    <asp:Label Text='<%# Eval("linkLabel") %>' runat="server" ID="linkLabel" /></td>
                                                            </tr>
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
                </section>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
