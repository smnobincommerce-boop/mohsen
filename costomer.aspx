<%@ Page Title="" Language="C#" MasterPageFile="~/panel/introducer/introducer.Master" AutoEventWireup="true" CodeBehind="costomer.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.costomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="panel_overview" class="tab-pane fade in active">
        <div role="form">
            <fieldset>
                <legend>لیست معرفی شدگان  
                </legend>

                <asp:Listview ID="ListView_costomer" runat="server" onpagepropertieschanging="OnPagePropertiesChanging">
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>هیچ اطلاعاتی وجود ندارد.</td>
                            </tr>
                        </table>

                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr dir="rtl" >
                            <td style="width: 10%" class="text-center padding-bottom-15"><%# Eval("id") %></td>                          
                            <td style="width: 25%" class="text-center padding-bottom-15"><%# Eval("Name") %></td>                           
                            <td style="width: 25%" class="text-center padding-bottom-15"><%# Eval("Name_introducer") %></td>
                            <td style="width: 15%" class="text-center padding-bottom-15"><%# Eval("date") %></td>
                            <td style="width: 12%" class="text-center padding-bottom-15"><a href="contract.aspx?costomer=<%# Eval("id") %>">جزئيات</a></td>
                            <td style="width: 13%" class="text-center padding-bottom-15"><a href="deposit.aspx?costomer=<%# Eval("id") %>">جزئيات</a></td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server" id="itemPlaceholderContainer" style="" border="0" class="table">
                            <tr class=" text-center" dir="rtl">
                                <td style="width: 10%" class="text-center padding-bottom-15">شماره</td>
                                <td style="width: 25%" class="text-center padding-bottom-15">نام کارفرما</td>
                                <td style="width: 25%" class="text-center padding-bottom-15">معرف</td>
                                <td style="width: 15%" class="text-center padding-bottom-15">تاریخ</td>                                
                                <td style="width: 12%" class="text-center padding-bottom-15">قرارداد</td>
                                <td style="width: 13%" class="text-center padding-bottom-15">واریز</td>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                        <table>
                            <tr runat="server">
                                <td runat="server" style="">
                                    <asp:DataPager runat="server" ID="DataPager1" PageSize="30" PagedControlID="ListView_costomer">
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
                                <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /></td>
                            <td>
                                <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>                      
                                                        <td>
                                <asp:Label Text='<%# Eval("date") %>' runat="server" ID="dateLabel" /></td>
                            <td>
                                <asp:Label Text='<%# Eval("Name_introducer") %>' runat="server" ID="Name_introducerLabel" /></td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:Listview>

            </fieldset>
        </div>
    </div>

</asp:Content>
