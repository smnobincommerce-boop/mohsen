<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="list_project.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.list_project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="right ">
        <div class="col-sm-12">
            <section class="panel panel-white no-radius">
                <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                </div>


                <div class="">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="search-classic ">
                                <div>
                                    <div class="input-group well">
                                        <%-- <input type="text" id="txt_search" runat="server" class="form-control" placeholder="Search...">
                                        <span class="input-group-btn">
                                            <button class="btn btn-primary" type="button">
                                                <i class="fa fa-search"></i>Search
                                            </button>
                                        </span>--%>

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

                <div class="row">
                    <div dir="rtl" class="col-lg-12">
                        <div class="col-md-6 padding-10">
                            <asp:Button ID="all_user" runat="server" Text="پروژه های مختومه" CssClass="btn btn-primary btn-lg btn-block" PostBackUrl="~/panel/maneger/list_project.aspx?active=0" />
                        </div>
                        <div class="col-md-6 padding-10">
                            <asp:Button ID="engineer" runat="server" Text="پروژه های باز" CssClass="btn btn-primary btn-lg btn-block" PostBackUrl="~/panel/maneger/list_project.aspx?active=1" />
                        </div>
                    </div>
                </div>
                <div id="panel_overview" class="tab-pane fade in active">
                    <div role="form">
                        <fieldset>
                            <legend>لیست پروژه ها 
                            </legend>

                            <asp:ListView ID="ListView_project" runat="server" OnPagePropertiesChanging="OnPagePropertiesChanging" OnItemCommand="ListView_project_ItemCommand">
                                <EmptyDataTemplate>
                                    <table runat="server" style="">
                                        <tr>
                                            <td>هیچ اطلاعاتی وجود ندارد.</td>
                                        </tr>
                                    </table>

                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr dir="rtl" class='<%# Eval("color") %>'>
                                        <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" Visible="False" />
                                        <td style="width: 6%" class="text-center padding-bottom-15"><%# Eval("id") %></td>
                                      
                                        <td style="width: 20%" class="text-center padding-bottom-15"><%# Eval("Name") %></td>
                                        <td style="width: 40%" class="text-center padding-bottom-15"><%# Eval("subject_project") %></td>
                                        <td style="width: 15%" class="text-center padding-bottom-15"><%# Eval("group_") %></td>
                                       
                                        <td style="width: 7%" class="text-center padding-bottom-15"><a href="detail_project.aspx?project=<%# Eval("id") %>">جزئيات</a></td>
                                        <td style="width: 8%" class="text-center padding-bottom-15">
                                            <asp:Button ID="Button2" runat="server" Text='<%# Eval("buttom") %>' CommandName="active" CssClass="btn " /></td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table runat="server" id="itemPlaceholderContainer" style="" border="0" class="table">
                                        <tr class=" text-center" dir="rtl">
                                            <td style="width: 6%" class="text-center padding-bottom-15">شماره</td>

                                            <td style="width: 20%" class="text-center padding-bottom-15">نام مهندس</td>
                                            <td style="width: 40%" class="text-center padding-bottom-15">موضوع</td>
                                            <td style="width: 15%" class="text-center padding-bottom-15">گروه</td>
                                            <%--<td style="width: 3%" class="text-center padding-bottom-15">چک شده</td>--%>
                                            <td style="width: 7%" class="text-center padding-bottom-15">جزيیات</td>
                                            <td style="width: 8%" class="text-center padding-bottom-15">وضعیت</td>
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </table>
                                    <table>
                                        <tr runat="server">
                                            <td runat="server" style="">
                                                <asp:DataPager runat="server" ID="DataPager1" PageSize="30" PagedControlID="ListView_project">
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
                                            <asp:Label Text='<%# Eval("subject_project") %>' runat="server" ID="subject_projectLabel" /></td>
                                        <td>
                                            <asp:Label Text='<%# Eval("date_seen") %>' runat="server" ID="date_seenLabel" /></td>
                                        <td>
                                            <asp:Label Text='<%# Eval("group_") %>' runat="server" ID="group_Label" /></td>
                                        <td>
                                            <asp:Label Text='<%# Eval("color") %>' runat="server" ID="colorLabel" /></td>
                                    </tr>
                                </SelectedItemTemplate>
                            </asp:ListView>
                            <%--<asp:LinqDataSource ID="LinqDataSource1" runat="server"></asp:LinqDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>--%>

                            <%--<asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ImporaConnectionString %>' SelectCommand="SELECT * FROM [project_tbl] ORDER BY [id] DESC"></asp:SqlDataSource>
                            --%>    <%--<asp:Label ID="lbl_phone_list_project" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="id_user" runat="server" Text="10" Visible="False"></asp:Label>--%>
                        </fieldset>
                    </div>
                </div>

            </section>
        </div>
    </div>
</asp:Content>
