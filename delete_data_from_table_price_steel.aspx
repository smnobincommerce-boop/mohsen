<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="delete_data_from_table_price_steel.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.delete_data_from_table_price_steel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    کالا با تاریخ و قیمت های ثبت شده
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="search-classic ">
                            <div>
                                <div class="input-group well">

                                    <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>

                                    <span class="input-group-btn">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="" ImageUrl="~/img/UC_SEARCH_ICON_170616.PNG" ImageAlign="Middle" OnClick="Btn_search" Width="30" />
                                    </span>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <div class="col-md-12">
        <div class=" margin-bottom-10 ">
            <div class="panel  panel-dark radius-10 ">
                <div class="panel-heading border-dark text-center head_tab" dir="rtl" style="font-size: x-large">
                    <div>
                        <div id="txt_list_price" runat="server">
                            قیمت وتاریخ های ثبت شده
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:ListView ID="ListView1" OnItemCommand="ListView1_ItemCommand" runat="server">
                        <EmptyDataTemplate>
                            <table runat="server" style="">
                                <tr dir="rtl">
                                    <td dir="rtl">هیچ اطلاعاتی جهت آپدیت وجود ندارد.
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tr class=" text-center" style="height: 80px">
                                <td id="th1" style="width: 20%; color: #c1b3b3" runat="server" class="text-center "><asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /></td>
                                  <td id="th3" style="width: 50%; color: #c1b3b3" runat="server" class="text-center "><%# Eval("price_product") %></td>
                             
                                <td id="th2" style="width: 50%; color: #c1b3b3" runat="server" class="text-center "><%# Eval("date_product") %></td>
                                 <td>
                                     <asp:LinkButton ID="ImageButton1" runat="server" CommandName="delet" ToolTip="حذف"><img src="../../img/delete_icon.png" style="height:20px; width:20px;"/></asp:LinkButton>
                                    <%--<asp:Button ID="Button2" runat="server" Text="حذف" CommandName="delet" style="width: 50%; color: #c1b3b3" CssClass="btn btn-danger" />--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table class="text-center" runat="server" id="itemPlaceholderContainer" >
                                <tr class=" text-center" style="border-style: solid none solid none; border-width: thin; border-color: #FFFFFF; height: 80px">
                                    <td id="th1" style="width: 20%; color: #c1b3b3"  class="text-center ">شماره</td>
                                    <td id="th3" style="width: 50%; color: #c1b3b3"  class="text-center ">قیمت</td>
                                    <td id="th2" style="width: 50%; color: #c1b3b3"  class="text-center ">تاریخ</td>                                    
                                    <td id="th4" style="width: 50%; color: #c1b3b3"  class="text-center ">حذف</td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("date_product") %>' runat="server" ID="date_productLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("price_product") %>' runat="server" ID="price_productLabel" /></td>
                            </tr>
                        </SelectedItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
