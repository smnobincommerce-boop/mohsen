<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="list_pic_for_page.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.list_pic_for_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">افزودن تصویر</h1>
                <span class="mainDescription">تصاویر مورد نظر برای اسلایدر را وارد نمایید</span>
            </div>
            <ol class="breadcrumb" dir="rtl">
                <li>
                    <span>فرم ها</span>
                </li>
                <li class="active">
                    <span>افزودن تصویر</span>
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
                    ادیت تصاویر اسلایدر
                </div>

                <div id="div_grouping" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 runat="server" id="H2" class="panel-title">تصاویر مورد نظر برای اسلایدر را وارد نمایید</h5>
                                </div>
                                <div class="panel-body">
                                    <div class="margin-bottom-20">
                                        <div class="form-group" dir="rtl">
                                            افزودن تصویر با فرمت jpg
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="پر کردن این ایتم ضروری می باشد." ControlToValidate="FileUpload1" ValidationGroup="3"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group" dir="rtl">
                                            توضیح تصویر
                                             <asp:TextBox ID="txt_alt" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100" Visible="True" MaxLength="300"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="پر کردن این ایتم ضروری می باشد." ControlToValidate="txt_alt" ValidationGroup="3"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="form-group" dir="rtl">
                                            <asp:Button ID="Button_upload" runat="server" Text="بارگذاری" ValidationGroup="3" CssClass="btn btn-success" OnClick="Button_upload_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="panel panel-white no-radius">
                <div id="Div1" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                    لیست تصاویر اسلایدر
                </div>
                <div id="div2" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 runat="server" id="H1" class="panel-title">لیست تصاویر</h5>
                                </div>
                                <div class="panel-body">
                                    <div class="margin-bottom-20">
                                        <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" DataSourceID="SqlDataSource1">
                                            <EmptyDataTemplate>
                                                <table runat="server" style="">
                                                    <tr>
                                                        <td>هیچ اطلاعاتی وجود ندارد.</td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                            <ItemTemplate>
                                                <tr class=" text-center" style="border-style: solid none solid none; border-width: thin; border-color: #FFFFFF; height: 80px">
                                                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>

                                                    <td style="width: 30%">
                                                        <div class="CartDescription text-center">
                                                            <%--<asp:Label ID="Name_productLabel" runat="server"><%# Eval("pic") %></asp:Label>--%>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../../"  + Eval("pic") %>' ImageAlign="Middle" Height="100" Visible="True" />
                                                        </div>
                                                    </td>
                                                    <td style="width: 60%">
                                                        <div class="CartDescription text-center">
                                                            <asp:Label Text='<%# Eval("alt") %>' runat="server" ID="altLabel" />
                                                        </div>
                                                    </td>

                                                    <td style="width: 10%">
                                                        <asp:Button ID="Button2" runat="server" Text="حذف" CommandName="delet" CssClass="btn btn-danger" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <LayoutTemplate>
                                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                                    <tr class=" text-center padding-15" dir="rtl">

                                                        <td style="width: 30%" class="padding-15">تصویر</td>
                                                        <td style="width: 60%" class="padding-15">توضیح تصویر</td>
                                                        <td style="width: 10%" class="padding-15">حذف</td>
                                                    </tr>
                                                    <tr runat="server" id="itemPlaceholder"></tr>
                                                </table>

                                            </LayoutTemplate>
                                            <SelectedItemTemplate>
                                                <tr style="">
                                                    <td>
                                                        <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /></td>
                                                    <td>
                                                        <asp:Label Text='<%# Eval("id_page") %>' runat="server" ID="id_pageLabel" /></td>
                                                    <td>
                                                        <asp:Label Text='<%# Eval("date") %>' runat="server" ID="dateLabel" /></td>
                                                    <td>
                                                        <asp:Label Text='<%# Eval("time") %>' runat="server" ID="timeLabel" /></td>
                                                    <td>
                                                        <asp:Label Text='<%# Eval("pic") %>' runat="server" ID="picLabel" /></td>
                                                    <td>
                                                        <asp:Label Text='<%# Eval("alt") %>' runat="server" ID="altLabel" /></td>
                                                </tr>
                                            </SelectedItemTemplate>
                                        </asp:ListView>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ImporaConnectionString %>' SelectCommand="SELECT * FROM [image__tbl] WHERE ([id_page] = @id_page) ORDER BY [date] DESC">
                                            <SelectParameters>
                                                <asp:QueryStringParameter QueryStringField="page_id" Name="id_page" Type="Int32"></asp:QueryStringParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
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
