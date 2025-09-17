<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">همه مشتریان سیستم</h1>
            </div>
            <div class=" pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span>فرم ها</span>
                    </li>
                    <li class="active">
                        <span>همه مشتریان سیستم</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>
    <div id="success_message" runat="server" role="alert" class="alert alert-success padding-40" visible="false">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">×</span>
        </button>
        <strong>موفق!</strong>
        <asp:Label ID="success_Label" runat="server" Text=""></asp:Label>
    </div>
    <div id="warning_message" runat="server" class="alert alert-warning padding-40" visible="false">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">×</span>
        </button>
        <strong>توجه!</strong>
        <asp:Label ID="warning_Label" runat="server" Text=""></asp:Label>
    </div>
    <div class="right ">
        <div class="col-sm-12">
            <section class="panel panel-white no-radius">
                <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                    مشتریان
                </div>
                <div class="">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="search-classic ">
                                <div>
                                    <div class="input-group well">
                                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="" ImageUrl="~/img/UC_SEARCH_ICON_170616.PNG" ImageAlign="Middle" OnClick="ImageButton1_Click" Width="30" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               
                <div id="div1" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 id="H1" runat="server" class="panel-title"></h5>
                                </div>
                                <div class="panel-body">
                                    <div class="margin-bottom-20">
                                        <div class="table-responsive">
                                            <asp:ListView ID="ListView_customer" OnItemCommand="ListView_customer_ItemCommand" runat="server" OnPagePropertiesChanging="ListView_customer_PagePropertiesChanging1">
                                                <EmptyDataTemplate>
                                                    <table runat="server" style="">
                                                        <tr dir="rtl">
                                                            <td dir="rtl"></td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                                <ItemTemplate>
                                                    <tr class=" text-center" style="border-style: solid none solid none; border-width: thin; border-color: #FFFFFF; height: 80px">
                                                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" ForeColor="#F7F6F3"></asp:Label>
                                                        <td class="padding-5">
                                                            <div class="CartDescription text-center">
                                                                <asp:TextBox ID="Person_NameLabel" runat="server" Text='<%# Eval("Person_Name") %>' ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="padding-5">
                                                            <div class="CartDescription text-center">
                                                                <asp:TextBox ID="Name_CompanyLable" runat="server" Text='<%# Eval("Company_Name") %>' ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="padding-5">
                                                            <div class="CartDescription text-center">
                                                                <asp:TextBox ID="Phone_NumberLabel" runat="server" Text='<%# Eval("Phone_Number") %>' ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="padding-5">
                                                            <div class="CartDescription text-center">
                                                                <asp:TextBox ID="Mobile_NumberLabel" runat="server" Text='<%# Eval("Mobile_Number") %>' ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="padding-5">
                                                            <asp:Label Text='<%# Eval("StaffName") %>' runat="server" ID="StaffNameLabel" />
                                                        </td>
                                                        <td class="padding-5">
                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="list" ToolTip="لیست پروژه ها"><img src="../../img/edit.png" style="height:20px; width:20px;"/></asp:LinkButton>
                                                        </td>
                                                        <td class="padding-5">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="info" ToolTip="اطلاعات"><img src="../../img/info.png" style="height:20px; width:20px;"/></asp:LinkButton>
                                                        </td>
                                                        <%--<td class="padding-5">
                                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="SMS" ToolTip="پیامک"><img src="../../img/send_sms.png" style="height:20px; width:20px;"/></asp:LinkButton>
                                                        </td>--%>
                                                        <td class="padding-5">
                                                            <asp:HyperLink ID="EmailLink" runat="server" NavigateUrl='<%# "mailto:" + Eval("Email") %>' Text="ایمیل" />
                                                        </td>
                                                       <%-- <td class="padding-5">
                                                            <asp:LinkButton ID="reminder" runat="server" CommandName="reminder" ToolTip="ایجاد یادآوری"><img src= "../../img/send_sms.png" style="height:20px; width:20px;"/></asp:LinkButton>
                                                        </td>--%>
                                                           <td class="padding-5">
                                                            <asp:HyperLink ID="WhatsAppLink" runat="server" NavigateUrl='<%# "https://api.whatsapp.com/send/?phone=" + (Eval("Mobile_Number") != null && Eval("Mobile_Number").ToString().Length > 0 ? ("+98" + (Eval("Mobile_Number").ToString().StartsWith("0") ? Eval("Mobile_Number").ToString().Substring(1) : (Eval("Mobile_Number").ToString().StartsWith("00") ? Eval("Mobile_Number").ToString().Substring(2) : Eval("Mobile_Number").ToString()))) : "") + "&text=" + HttpUtility.UrlEncode("سلام، عرض ادب.") + "&app_absent=0" %>' Text="واتساپ" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <LayoutTemplate>
                                                    <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                                        <tr class=" text-center" dir="rtl">
                                                            <td style="width: 13%">نام فرد</td>
                                                            <td style="width: 13%">نام شرکت</td>
                                                            <td style="width: 13%">شماره تلفن</td>
                                                            <td style="width: 13%">موبایل</td>
                                                            <td style="width: 13%">ثبت کننده</td>
                                                            <td style="width: 7%">لیست پروژه ها</td>
                                                            <td style="width: 7%">اطلاعات</td>
                                                            <%--<td style="width: 7%">پیامک</td>--%>
                                                            <td style="width: 7%">ایمیل</td>
                                                            <%--<td style="width: 7%">ایجاد یادآوری</td>--%>
                                                            <td style="width: 7%">واتساپ</td>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                    <table>
                                                        <tr runat="server">
                                                            <td runat="server" style="">
                                                                <asp:DataPager runat="server" ID="DataPager1" PageSize="100" PagedControlID="ListView_customer">
                                                                    <Fields>
                                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" ButtonCssClass="btn btn-o"></asp:NextPreviousPagerField>
                                                                    </Fields>
                                                                </asp:DataPager>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>
                                                <SelectedItemTemplate>
                                                    <tr style="">
                                                        <td>
                                                            <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Company_Name") %>' runat="server" ID="Company_NameLabel" />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Person_Name") %>' runat="server" ID="Person_NameLabel" />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Phone_Number") %>' runat="server" ID="Phone_NumberLabel" />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Mobile_Number") %>' runat="server" ID="Mobile_NumberLable" />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("StaffName") %>' runat="server" ID="StaffNameLabel" />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Email") %>' runat="server" ID="EmailLabel" />
                                                        </td>
                                                    </tr>
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