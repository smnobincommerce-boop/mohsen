<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="editpicture.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.editpicture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">ویرایش تصاویر</h1>
                <span class="mainDescription">عکس های خود را در سرور بارگذاری نمایید</span>
            </div>
            <ol class="breadcrumb" dir="rtl">
                <li>
                    <span>فرم ها</span>
                </li>
                <li class="active">
                    <span>ویرایش تصاویر</span>
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
                    ویرایش تصاویر
                </div>

                <div id="div_choose" runat="server" class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12 " dir="rtl">
                            <div class="panel panel-white no-radius">
                                <div class="panel-heading">
                                    <h5 runat="server" id="h_txt" class="panel-title">تصاویر مورد نظر خود را در سرور بارگذاری نمایید </h5>
                                </div>

                                <h2>آپلود و پردازش تصاویر</h2>

                                <br />
                                <br />


                                <div class="panel-body">
                                    <div class="input-group">
                                        <label>عرض تصویر (پیکسل):</label>
                                        <asp:TextBox ID="txtWidth" runat="server" class="form-control input" Text="600"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <label>ارتفاع تصویر (پیکسل):</label>
                                        <asp:TextBox ID="txtHeight" runat="server" class="form-control input" Text="900"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <label>حداکثر حجم (کیلوبایت):</label>
                                        <asp:TextBox ID="txtMaxSize" runat="server" class="form-control input" Text="400"></asp:TextBox>
                                    </div><br />
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUploadImages" runat="server" AllowMultiple="true" />
                                    </div>
                                    <div class="form-group" dir="rtl">
                                        <asp:Button ID="btnProcess" CssClass="btn-success" runat="server" Text="پردازش و دانلود" OnClick="btnProcess_Click" />
                                        <br />
                                        <br />
                                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
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
