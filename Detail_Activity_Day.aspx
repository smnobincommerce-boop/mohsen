<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Detail_Activity_Day.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Detail_Activity_Day" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tile {
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 15px;
            width: 100%;
            background-color: #f9f9f9;
            direction: rtl;
            margin-bottom: 20px;
        }
        .description {
            display: inline-block;
        }
        .show-more {
            margin-right: 5px;
            color: #007bff;
            text-decoration: none;
        }
        .show-more:hover {
            text-decoration: underline;
        }
        .staff-activity {
            background-color: #333333;
            color: #ffffff;
            padding: 20px;
            border-radius: 5px;
            margin-bottom: 20px;
            direction: rtl;
            display: flex;
            align-items: center;
        }
        .staff-activity img {
            width: 60px;
            height: 60px;
            border-radius: 50%;
            margin-left: 15px;
        }
        .staff-activity .details {
            flex-grow: 1;
        }
        .company-tile {
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 15px;
            background-color: #ffffff;
            direction: rtl;
            margin-bottom: 15px;
        }
        .company-tile h5 {
            margin-top: 0;
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">جزئیات فعالیت روزانه</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li><span>کارکردها</span></li>
                    <li class="active"><span>جزئیات فعالیت روزانه</span></li>
                </ol>
            </div>
        </div>
    </section>

    <section class="panel panel-white no-radius">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Style="display: block; margin-bottom: 20px;" />

        <!-- Staff and Activity Details -->
        <div class="staff-activity">
            <asp:Image ID="imgStaff" runat="server" ImageUrl="../../img/default-user.png" AlternateText="تصویر کارمند" />
            <div class="details">
                <h4><asp:Label ID="lblStaffName" runat="server" /></h4>
                <p><strong>تاریخ:</strong> <asp:Label ID="lblDate" runat="server" /></p>
            </div>
        </div>

        <!-- Activity Details -->
        <div class="tile">
            <div><strong>تاریخ فعالیت:</strong> <asp:Label ID="lblActivityDate" runat="server" /></div>
            <div>
                <div><strong>زمان شروع:</strong> <asp:Label ID="lblTimeOpen" runat="server" /></div>
                <div><strong>زمان پایان:</strong> <asp:Label ID="lblTimeClose" runat="server" /></div>
                <div><strong>تعداد پیگیری‌ها:</strong> <asp:Label ID="lblFollowupCount" runat="server" /></div>
                <div><strong>تعداد شرکت‌ها:</strong> <asp:Label ID="lblCompanyCount" runat="server" /></div>
                <strong>توضیحات:</strong>
                <span class="description" id="description" runat="server">
                    <asp:Label ID="lblDescription" runat="server" />
                </span>
                <asp:HyperLink ID="lnkShowMore" runat="server" CssClass="show-more" NavigateUrl="#" Text="نمایش بیشتر" Visible="false" />
            </div>
        </div>

        <!-- Companies and Follow-ups -->
        <h3>لیست شرکت‌ها و پیگیری‌ها</h3>
      <asp:ListView ID="lvCompanies" runat="server" DataKeyNames="id_company">
    <LayoutTemplate>
        <div class="row">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <div class="col-md-4 col-sm-6">
            <div class="company-tile">
                <h5><%# Eval("Company_Name") %></h5>
                <div><strong>تاریخ:</strong> <%# Eval("datecreate") %></div>
                <div><strong>جزئیات پیگیری:</strong>
                    <span class="description" data-full-text='<%# Eval("lastdescription") %>'>
                        <%# GetTruncatedDescription(Eval("lastdescription").ToString()) %>
                    </span>
                    <%# string.IsNullOrEmpty(Eval("lastdescription").ToString()) || Eval("lastdescription").ToString().Length <= 100 ? "" : "<a href='#' class='show-more'>نمایش بیشتر</a>" %>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <EmptyDataTemplate>
        <div class="text-center" style="padding: 20px;">
            هیچ شرکت یا پیگیری‌ای برای این روز یافت نشد.
        </div>
    </EmptyDataTemplate>
</asp:ListView>
        <div class="form-group" style="margin-top: 20px;">
            <asp:Button ID="btnBack" runat="server" Text="بازگشت" CssClass="btn btn-primary pull-right" OnClick="btnBack_Click" />
        </div>
    </section>

    <!-- jQuery (Local) -->
    <script src="../../Scripts/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.show-more').click(function (e) {
                e.preventDefault();
                var $this = $(this);
                var $description = $this.prev('.description');
                var fullText = $description.data('full-text');
                var truncatedText = $description.text();
                if ($this.text() === 'نمایش بیشتر') {
                    $description.text(fullText);
                    $this.text('نمایش کمتر');
                } else {
                    $description.text(truncatedText);
                    $this.text('نمایش بیشتر');
                }
            });
        });
    </script>
</asp:Content>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tile {
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 15px;
            width: 100%;
            background-color: #f9f9f9;
            direction: rtl;
            margin-bottom: 20px;
        }
        .description {
            display: inline-block;
        }
        .show-more {
            margin-right: 5px;
            color: #007bff;
            text-decoration: none;
        }
        .show-more:hover {
            text-decoration: underline;
        }
        .staff-activity {
            background-color: #333333;
            color: #ffffff;
            padding: 20px;
            border-radius: 5px;
            margin-bottom: 20px;
            direction: rtl;
            display: flex;
            align-items: center;
        }
        .staff-activity img {
            width: 60px;
            height: 60px;
            border-radius: 50%;
            margin-left: 15px;
        }
        .staff-activity .details {
            flex-grow: 1;
        }
        .company-tile {
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 15px;
            background-color: #ffffff;
            direction: rtl;
            margin-bottom: 15px;
        }
        .company-tile h5 {
            margin-top: 0;
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">جزئیات فعالیت روزانه</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li><span>کارکردها</span></li>
                    <li class="active"><span>جزئیات فعالیت روزانه</span></li>
                </ol>
            </div>
        </div>
    </section>

    <section class="panel panel-white no-radius">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" style="display: block; margin-bottom: 20px;" />

        <!-- Staff and Activity Details -->
        <div class="staff-activity">
            <asp:Image ID="imgStaff" runat="server" ImageUrl="../../img/default-user.png" AlternateText="تصویر کارمند" />
            <div class="details">
                <h4><asp:Label ID="lblStaffName" runat="server" /></h4>
                <p><strong>تاریخ:</strong> <asp:Label ID="lblDate" runat="server" /></p>
            </div>
        </div>

        <!-- Activity Details -->
        <div class="tile">
            <div><strong>تاریخ فعالیت:</strong> <asp:Label ID="lblActivityDate" runat="server" /></div>
            <div>
                <div><strong>زمان شروع:</strong> <asp:Label ID="lblTimeOpen" runat="server" /></div>
                <div><strong>زمان پایان:</strong> <asp:Label ID="lblTimeClose" runat="server" /></div>
                <div><strong>تعداد پیگیری‌ها:</strong> <asp:Label ID="lblFollowupCount" runat="server" /></div>
                <div><strong>تعداد شرکت‌ها:</strong> <asp:Label ID="lblCompanyCount" runat="server" /></div>
                <strong>توضیحات:</strong>
                <span class="description" id="description" runat="server">
                    <asp:Label ID="lblDescription" runat="server" />
                </span>
                <asp:HyperLink ID="lnkShowMore" runat="server" CssClass="show-more" NavigateUrl="#" Text="نمایش بیشتر" Visible="false" />
            </div>
        </div>

        <!-- Companies and Follow-ups -->
        <h3>لیست شرکت‌ها و پیگیری‌ها</h3>
        <asp:ListView ID="lvCompanies" runat="server" DataKeyNames="id_company">
            <LayoutTemplate>
                <div class="row">
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="col-md-4 col-sm-6">
                    <div class="company-tile">
                        <h5><%# Eval("Company_Name") %></h5>
                        <div><strong>تاریخ:</strong> <%# Eval("datecreate") %></div>
                        <div><strong>جزئیات پیگیری:</strong>
                            <span class="description" data-full-text='<%# Eval("lastdescription") %>'>
                                <%# GetTruncatedDescription(Eval("lastdescription").ToString()) %>
                            </span>
                            <%# string.IsNullOrEmpty(Eval("lastdescription").ToString()) || Eval("lastdescription").ToString().Length <= 100 ? "" : "<a href='#' class='show-more'>نمایش بیشتر</a>" %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div class="text-center" style="padding: 20px;">
                    هیچ شرکت یا پیگیری‌ای برای این روز یافت نشد.
                </div>
            </EmptyDataTemplate>
        </asp:ListView>

        <div class="form-group" style="margin-top: 20px;">
            <asp:Button ID="btnBack" runat="server" Text="بازگشت" CssClass="btn btn-primary pull-right" OnClick="btnBack_Click" />
        </div>
    </section>

    <!-- jQuery (Local) -->
    <script src="../../Scripts/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.show-more').click(function (e) {
                e.preventDefault();
                var $this = $(this);
                var $description = $this.prev('.description');
                var fullText = $description.data('full-text');
                var truncatedText = $description.text();
                if ($this.text() === 'نمایش بیشتر') {
                    $description.text(fullText);
                    $this.text('نمایش کمتر');
                } else {
                    $description.text(truncatedText);
                    $this.text('نمایش بیشتر');
                }
            });
        });
    </script>
</asp:Content>--%>
