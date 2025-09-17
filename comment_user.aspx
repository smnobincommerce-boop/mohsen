<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="comment_user.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.comment_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="panel_tickets" class="tab-pane fade in active">
        <asp:ListView ID="ListView_ticket" OnPagePropertiesChanging="OnPagePropertiesChanging" runat="server">

            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>هیچ اطلاعاتی وجود ندارد.</td>
                    </tr>
                </table>

            </EmptyDataTemplate>
            <ItemTemplate>
                <tr dir="rtl" class='<%# Eval("color") %>'>
                    <td style="width: 6%" class="text-center padding-bottom-15"><%# Eval("date").ToString() %></td>
                    <td style="width: 50%" class="text-center padding-bottom-15"><%# Eval("subject") %></td>
                    <td style="width: 15%" class="text-center padding-bottom-15"><%# Eval("Name") %></td>
                   <%-- <td style="width: 3%" class="text-center padding-bottom-15">
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("seen") %>' /></td>--%>
                    <td style="width: 7%" class="text-center padding-bottom-15"><a href="detail_comment.aspx?comment=<%# Eval("id") %>">جزئيات</a></td>
                    <td style="width: 8%" class="text-center padding-bottom-15"><%# Eval("status")  %></td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" id="itemPlaceholderContainer" style="" border="0" class="table">
                    <tr class=" text-center" dir="rtl">
                        <td style="width: 6%" class="text-center padding-bottom-15">تاریخ</td>
                        <td style="width: 50%" class="text-center padding-bottom-15">پیام</td>
                        <td style="width: 15%" class="text-center padding-bottom-15">نام کاربر</td>
                        <%--<td style="width: 3%" class="text-center padding-bottom-15">چک شده</td>--%>
                        <td style="width: 7%" class="text-center padding-bottom-15">جزيیات</td>
                        <td style="width: 8%" class="text-center padding-bottom-15">وضعیت</td>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
                <table>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager runat="server" ID="DataPager1" PageSize="20">
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
                        <asp:Label Text='<%# Eval("subject") %>' runat="server" ID="subjectLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("date") %>' runat="server" ID="dateLabel" /></td>
                    <td>
                        <asp:CheckBox Checked='<%# Eval("seen") %>' runat="server" ID="seenCheckBox" Enabled="false" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("color") %>' runat="server" ID="colorLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("status") %>' runat="server" ID="statusLabel" /></td>
                    <%--  --%>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>


        <%--<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ImporaConnectionString %>' SelectCommand="SELECT * FROM [Message_to_maneger_tbl] ORDER BY [date] DESC"></asp:SqlDataSource>--%>
    </div>

</asp:Content>
