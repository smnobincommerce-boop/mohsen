<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="activity_list.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.activity_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="vendor/select2/select2.min.css" rel="stylesheet" media="screen">
    <link href="vendor/DataTables/css/DT_bootstrap.css" rel="stylesheet" media="screen">
    <style>
        .description-text {
            display: inline;
        }

        .show-more {
            color: #007bff;
            cursor: pointer;
        }

        canvas {
            max-height: 400px;
        }

        .text-danger-message {
            color: #ff0000;
        }

        .text-info {
            color: #3170f7;
        }

        .padding-5 {
            padding: 5px;
        }

        .panel-heading {
            font-size: x-large;
        }

        .table-responsive {
            overflow-x: auto;
        }

        .tile {
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 15px;
            height: 200px;
            width: 100%;
            background-color: #f9f9f9;
            direction: rtl;
            overflow: hidden;
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

        .chart-container {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            direction: rtl;
        }

        .staff-info {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            direction: rtl;
            display: flex;
            align-items: center;
        }

            .staff-info img {
                width: 50px;
                height: 50px;
                border-radius: 50%;
                margin-left: 10px;
            }

        .nav-tabs li.active a {
            background-color: #007bff;
            color: white;
        }

        .text-danger {
            display: block;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">لیست کارکردهای روزانه</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li><span>کارها</span></li>
                    <li class="active"><span>لیست کارکردهای روزانه</span></li>
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
        <asp:Label ID="warning_label" runat="server" Text=""></asp:Label>
    </div>
    <div class="right">
        <div class="col-sm-12">
            <section class="panel panel-white no-radius">
                <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl">
                    کارکردهای روزانه:
                    <asp:Label ID="lblStaffName" runat="server" />
                    (<asp:Label ID="lblChartType" runat="server" Text="هفتگی"></asp:Label>)
                </div>
                <div class="panel-body">
                    <div class="form">
                        <div class="text-right col-sm-12" dir="rtl">
                            <asp:LinkButton ID="lnkWeek" runat="server" CommandArgument="week" OnClick="lnkTab_Click" Text="هفتگی" CssClass="btn btn-default"></asp:LinkButton>
                            <asp:LinkButton ID="lnkMonth" runat="server" CommandArgument="month" OnClick="lnkTab_Click" Text="ماهانه" CssClass="btn btn-default"></asp:LinkButton>
                            <asp:LinkButton ID="lnkSeason" runat="server" CommandArgument="season" OnClick="lnkTab_Click" Text="فصلی" CssClass="btn btn-default"></asp:LinkButton>
                            <asp:Button ID="btnBack" runat="server" Text="بازگشت" OnClick="btnBack_Click" CssClass="btn btn-primary" />
                            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger-message" />
                        </div>
                        <!-- Companies Chart -->
                        <div class="row">
                            <div class="col-md-6">
                                <h2 class="center">نمودار تعداد شرکت‌ها</h2>
                                <hr />
                                <asp:Label ID="Lbl_company_total" runat="server" Text=""></asp:Label>
                                /
                                <asp:Label ID="Lbl_company_avg" runat="server" Text=""></asp:Label>
                                /
                                <asp:Label ID="Lbl_company_highlight" runat="server" Text="" ForeColor="Red" CssClass="text-left"></asp:Label>
                                <canvas id="companiesChart" class="full-width"></canvas>
                            </div>

                            <div class="col-md-6">
                                <h2 class="center">نمودار تعداد پیگیری‌ها</h2>
                                <hr />
                                <asp:Label ID="Lbl_followup_total" runat="server" Text=""></asp:Label>
                                /
                                <asp:Label ID="Lbl_followup_avg" runat="server" Text=""></asp:Label>
                                /
                                <asp:Label ID="Lbl_followup_highlight" runat="server" Text="" ForeColor="Green" CssClass="text-left"></asp:Label>
                                <canvas id="followupsChart" class="full-width"></canvas>
                            </div>
                        </div>
                        <!-- Activity List -->
                        <div class="row">
                            <div class="col-md-12">
                                <h2 class="center">لیست فعالیت‌ها</h2>
                                <div class="panel panel-white no-radius">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">فعالیت‌ها</h5>
                                    </div>
                                    <div class="panel-body">
                                        <div class="margin-bottom-20">
                                            <div class="table-responsive">
                                                <asp:ListView ID="lvActivities" runat="server" DataKeyNames="id" OnPagePropertiesChanging="lvActivities_PagePropertiesChanging">
                                                    <EmptyDataTemplate>
                                                        <table runat="server" style="">
                                                            <tr dir="rtl">
                                                                <td dir="rtl">هیچ فعالیتی یافت نشد.</td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <ItemTemplate>
                                                        <tr class="text-center" style="border-style: solid none solid none; border-width: thin; border-color: #FFFFFF; height: 80px">
                                                            <td class="padding-5">
                                                                <div class="CartDescription text-center">
                                                                    <%# Eval("PersianDate") %>
                                                                </div>
                                                            </td>
                                                            <td class="padding-5">
                                                                <div class="CartDescription text-center">
                                                                    <%# Eval("timeopen") %>
                                                                </div>
                                                            </td>
                                                            <td class="padding-5">
                                                                <div class="CartDescription text-center">
                                                                    <%# Eval("timeclose") %>
                                                                </div>
                                                            </td>
                                                            <td class="padding-5">
                                                                <div class="CartDescription text-center">
                                                                    <%# Eval("followup_count") %>
                                                                </div>
                                                            </td>
                                                            <td class="padding-5">
                                                                <div class="CartDescription text-center">
                                                                    <%# Eval("created_companies_count") %>
                                                                </div>
                                                            </td>
                                                            <td class="padding-5">
                                                                <div class="CartDescription text-center">
                                                                    <span class="description-text"><%# GetTruncatedDescription(Eval("descriptionofday")) %></span>
                                                                    <a href="#" class="show-more">نمایش بیشتر</a>
                                                                    <span style="display: none;" class="full-text"><%# Eval("descriptionofday") %></span>
                                                                </div>
                                                            </td>
                                                            <td class="padding-5">
                                                                <asp:HyperLink ID="lnkDetail" runat="server" CssClass="btn btn-sm btn-primary"
                                                                    NavigateUrl='<%# "~/panel/maneger/Detail_Activity_Day.aspx?id_staff=" + Request.QueryString["id_staff"] + "&date_day=" + Server.UrlEncode(Eval("PersianDate").ToString()) %>'
                                                                    Text="جزئیات" />
                                                            </td>
                                                            <td class="padding-5">
                                                                <asp:HyperLink ID="lnkCustomer" runat="server" CssClass="btn btn-sm btn-secondary"
                                                                    NavigateUrl='<%# "~/panel/maneger/customer.aspx?id_staff=" + Request.QueryString["id_staff"] + "&date_day=" + Server.UrlEncode(Eval("PersianDate").ToString()) %>'
                                                                    Text="مشتریان" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <LayoutTemplate>
                                                        <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                                            <tr class="text-center" dir="rtl">
                                                                <td style="width: 7%">تاریخ</td>
                                                                <td style="width: 7%">زمان شروع</td>
                                                                <td style="width: 7%">زمان پایان</td>
                                                                <td style="width: 7%">پیگیری‌ها</td>
                                                                <td style="width: 10%">شرکت‌ها</td>
                                                                <td style="width: 47%">توضیحات</td>
                                                                <td style="width: 7.5%">جزئیات</td>
                                                                <td style="width: 7.5%">مشتریان</td>
                                                            </tr>
                                                            <tr runat="server" id="itemPlaceholder"></tr>
                                                        </table>
                                                        <table>
                                                            <tr runat="server">
                                                                <td runat="server" style="">
                                                                    <asp:DataPager runat="server" ID="DataPager1" PageSize="100" PagedControlID="lvActivities">
                                                                        <Fields>
                                                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" ButtonCssClass="btn btn-o"></asp:NextPreviousPagerField>
                                                                        </Fields>
                                                                    </asp:DataPager>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                </asp:ListView>
                                            </div>
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
   

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/chart.js@4.4.4/dist/chart.umd.min.js"></script>
<script type="text/javascript">
    // --- STEP 1: Data Initialization from C# ---
    // ASP.NET will replace these server-side tags with JavaScript arrays.
    // Make sure your C# code in the Page_Load method correctly fills the ChartX, ChartY, and ChartZ dictionaries.
    var labels = [
            '<%= ChartX.ContainsKey("1") ? ChartX["1"] : null %>', '<%= ChartX.ContainsKey("2") ? ChartX["2"] : null %>',
        '<%= ChartX.ContainsKey("3") ? ChartX["3"] : null %>', '<%= ChartX.ContainsKey("4") ? ChartX["4"] : null %>',
        '<%= ChartX.ContainsKey("5") ? ChartX["5"] : null %>', '<%= ChartX.ContainsKey("6") ? ChartX["6"] : null %>',
        '<%= ChartX.ContainsKey("7") ? ChartX["7"] : null %>', '<%= ChartX.ContainsKey("8") ? ChartX["8"] : null %>',
        '<%= ChartX.ContainsKey("9") ? ChartX["9"] : null %>', '<%= ChartX.ContainsKey("10") ? ChartX["10"] : null %>',
        '<%= ChartX.ContainsKey("11") ? ChartX["11"] : null %>', '<%= ChartX.ContainsKey("12") ? ChartX["12"] : null %>',
        '<%= ChartX.ContainsKey("13") ? ChartX["13"] : null %>', '<%= ChartX.ContainsKey("14") ? ChartX["14"] : null %>',
        '<%= ChartX.ContainsKey("15") ? ChartX["15"] : null %>', '<%= ChartX.ContainsKey("16") ? ChartX["16"] : null %>',
        '<%= ChartX.ContainsKey("17") ? ChartX["17"] : null %>', '<%= ChartX.ContainsKey("18") ? ChartX["18"] : null %>',
        '<%= ChartX.ContainsKey("19") ? ChartX["19"] : null %>', '<%= ChartX.ContainsKey("20") ? ChartX["20"] : null %>',
        '<%= ChartX.ContainsKey("21") ? ChartX["21"] : null %>', '<%= ChartX.ContainsKey("22") ? ChartX["22"] : null %>',
        '<%= ChartX.ContainsKey("23") ? ChartX["23"] : null %>', '<%= ChartX.ContainsKey("24") ? ChartX["24"] : null %>',
        '<%= ChartX.ContainsKey("25") ? ChartX["25"] : null %>', '<%= ChartX.ContainsKey("26") ? ChartX["26"] : null %>',
        '<%= ChartX.ContainsKey("27") ? ChartX["27"] : null %>', '<%= ChartX.ContainsKey("28") ? ChartX["28"] : null %>',
        '<%= ChartX.ContainsKey("29") ? ChartX["29"] : null %>', '<%= ChartX.ContainsKey("30") ? ChartX["30"] : null %>'
    ];
    var companiesData = [
        <%= ChartY.ContainsKey("1") ? ChartY["1"] : "0" %>, <%= ChartY.ContainsKey("2") ? ChartY["2"] : "0" %>,
        <%= ChartY.ContainsKey("3") ? ChartY["3"] : "0" %>, <%= ChartY.ContainsKey("4") ? ChartY["4"] : "0" %>,
        <%= ChartY.ContainsKey("5") ? ChartY["5"] : "0" %>, <%= ChartY.ContainsKey("6") ? ChartY["6"] : "0" %>,
        <%= ChartY.ContainsKey("7") ? ChartY["7"] : "0" %>, <%= ChartY.ContainsKey("8") ? ChartY["8"] : "0" %>,
        <%= ChartY.ContainsKey("9") ? ChartY["9"] : "0" %>, <%= ChartY.ContainsKey("10") ? ChartY["10"] : "0" %>,
        <%= ChartY.ContainsKey("11") ? ChartY["11"] : "0" %>, <%= ChartY.ContainsKey("12") ? ChartY["12"] : "0" %>,
        <%= ChartY.ContainsKey("13") ? ChartY["13"] : "0" %>, <%= ChartY.ContainsKey("14") ? ChartY["14"] : "0" %>,
        <%= ChartY.ContainsKey("15") ? ChartY["15"] : "0" %>, <%= ChartY.ContainsKey("16") ? ChartY["16"] : "0" %>,
        <%= ChartY.ContainsKey("17") ? ChartY["17"] : "0" %>, <%= ChartY.ContainsKey("18") ? ChartY["18"] : "0" %>,
        <%= ChartY.ContainsKey("19") ? ChartY["19"] : "0" %>, <%= ChartY.ContainsKey("20") ? ChartY["20"] : "0" %>,
        <%= ChartY.ContainsKey("21") ? ChartY["21"] : "0" %>, <%= ChartY.ContainsKey("22") ? ChartY["22"] : "0" %>,
        <%= ChartY.ContainsKey("23") ? ChartY["23"] : "0" %>, <%= ChartY.ContainsKey("24") ? ChartY["24"] : "0" %>,
        <%= ChartY.ContainsKey("25") ? ChartY["25"] : "0" %>, <%= ChartY.ContainsKey("26") ? ChartY["26"] : "0" %>,
        <%= ChartY.ContainsKey("27") ? ChartY["27"] : "0" %>, <%= ChartY.ContainsKey("28") ? ChartY["28"] : "0" %>,
        <%= ChartY.ContainsKey("29") ? ChartY["29"] : "0" %>, <%= ChartY.ContainsKey("30") ? ChartY["30"] : "0" %>
    ];
    var followupsData = [
        <%= ChartZ.ContainsKey("1") ? ChartZ["1"] : "0" %>, <%= ChartZ.ContainsKey("2") ? ChartZ["2"] : "0" %>,
        <%= ChartZ.ContainsKey("3") ? ChartZ["3"] : "0" %>, <%= ChartZ.ContainsKey("4") ? ChartZ["4"] : "0" %>,
        <%= ChartZ.ContainsKey("5") ? ChartZ["5"] : "0" %>, <%= ChartZ.ContainsKey("6") ? ChartZ["6"] : "0" %>,
        <%= ChartZ.ContainsKey("7") ? ChartZ["7"] : "0" %>, <%= ChartZ.ContainsKey("8") ? ChartZ["8"] : "0" %>,
        <%= ChartZ.ContainsKey("9") ? ChartZ["9"] : "0" %>, <%= ChartZ.ContainsKey("10") ? ChartZ["10"] : "0" %>,
        <%= ChartZ.ContainsKey("11") ? ChartZ["11"] : "0" %>, <%= ChartZ.ContainsKey("12") ? ChartZ["12"] : "0" %>,
        <%= ChartZ.ContainsKey("13") ? ChartZ["13"] : "0" %>, <%= ChartZ.ContainsKey("14") ? ChartZ["14"] : "0" %>,
        <%= ChartZ.ContainsKey("15") ? ChartZ["15"] : "0" %>, <%= ChartZ.ContainsKey("16") ? ChartZ["16"] : "0" %>,
        <%= ChartZ.ContainsKey("17") ? ChartZ["17"] : "0" %>, <%= ChartZ.ContainsKey("18") ? ChartZ["18"] : "0" %>,
        <%= ChartZ.ContainsKey("19") ? ChartZ["19"] : "0" %>, <%= ChartZ.ContainsKey("20") ? ChartZ["20"] : "0" %>,
        <%= ChartZ.ContainsKey("21") ? ChartZ["21"] : "0" %>, <%= ChartZ.ContainsKey("22") ? ChartZ["22"] : "0" %>,
        <%= ChartZ.ContainsKey("23") ? ChartZ["23"] : "0" %>, <%= ChartZ.ContainsKey("24") ? ChartZ["24"] : "0" %>,
        <%= ChartZ.ContainsKey("25") ? ChartZ["25"] : "0" %>, <%= ChartZ.ContainsKey("26") ? ChartZ["26"] : "0" %>,
        <%= ChartZ.ContainsKey("27") ? ChartZ["27"] : "0" %>, <%= ChartZ.ContainsKey("28") ? ChartZ["28"] : "0" %>,
        <%= ChartZ.ContainsKey("29") ? ChartZ["29"] : "0" %>, <%= ChartZ.ContainsKey("30") ? ChartZ["30"] : "0" %>
    ];

    // --- STEP 2: All DOM-related code is now inside $(document).ready() ---
    $(document).ready(function () {
        
        // --- Chart Drawing Functionality ---
        try {
            // Chart 1: Companies (Bar Chart)
            const companiesCanvas = document.getElementById('companiesChart');
            if (companiesCanvas) {
                const companiesCtx = companiesCanvas.getContext('2d');
                new Chart(companiesCtx, {
                    type: 'bar',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'شرکت‌های ایجادشده',
                            data: companiesData,
                            backgroundColor: 'rgba(75, 192, 192, 0.5)',
                            borderColor: 'rgba(75, 192, 192, 1)',
                            borderWidth: 1
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            legend: { position: 'top' },
                            title: { display: true, text: 'نمودار تعداد شرکت‌ها' }
                        },
                        scales: {
                            y: { beginAtZero: true, title: { display: true, text: 'تعداد' } },
                            x: { title: { display: true, text: 'تاریخ' } }
                        }
                    }
                });
            } else {
                console.error("Canvas element with ID 'companiesChart' not found. Check if the element exists and the ID is correct.");
            }

            // Chart 2: Follow-ups (Line Chart)
            const followupsCanvas = document.getElementById('followupsChart');
            if (followupsCanvas) {
                const followupsCtx = followupsCanvas.getContext('2d');
                new Chart(followupsCtx, {
                    type: 'line',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'تعداد پیگیری‌ها',
                            data: followupsData,
                            backgroundColor: 'rgba(153, 102, 255, 0.4)',
                            borderColor: 'rgba(153, 102, 255, 1)',
                            borderWidth: 2,
                            tension: 0.3,
                            fill: true
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            legend: { position: 'top' },
                            title: { display: true, text: 'نمودار تعداد پیگیری‌ها' }
                        },
                        scales: {
                            y: { beginAtZero: true, title: { display: true, text: 'تعداد' } },
                            x: { title: { display: true, text: 'تاریخ' } }
                        }
                    }
                });
            } else {
                console.error("Canvas element with ID 'followupsChart' not found. Check if the element exists and the ID is correct.");
            }

        } catch (e) {
            console.error('Chart.js Error:', e);
        }
        
        // --- "Show More" Functionality ---
        // This part of your code is correct and does not need changes.
        // Use the correct ClientID for the ListView
        $('#<%= lvActivities.ClientID %>').on('click', '.show-more', function (e) {
            e.preventDefault();
            var $this = $(this);
            var $descriptionSpan = $this.prev('.description-text');
            var $fullText = $this.next('.full-text');
            if (!$descriptionSpan.data('truncated-text')) {
                $descriptionSpan.data('truncated-text', $descriptionSpan.text());
                $descriptionSpan.data('full-text', $fullText.text());
            }
            if ($this.text() === 'نمایش بیشتر') {
                $descriptionSpan.text($descriptionSpan.data('full-text'));
                $this.text('نمایش کمتر');
            } else {
                $descriptionSpan.text($descriptionSpan.data('truncated-text'));
                $this.text('نمایش بیشتر');
            }
        });
    });
</script>


    <%-- 
      <script>
        // داده‌های نمونه شما (یا داده‌هایی که از سمت سرور با C# ارسال می‌کنید)
        // اطمینان حاصل کنید که آرایه‌ها به درستی با داده‌های واقعی پر شده‌اند.
        var labels = ["1404/03/17", "1404/03/18", "1404/03/19", "1404/03/20"]; // مثال با چند لیبل
        var companiesData = [5, 0, 7, 2]; // مثال با داده واقعی
        var followupsData = [10, 8, 0, 12]; // مثال با داده واقعی
        
        //// اگر از کد C# استفاده می‌کنید، باید به این شکل باشد:
        var labels = <%= new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ChartX.Values) %>;
        var companiesData = <%= new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ChartY.Values) %>;
        var followupsData = <%= new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ChartZ.Values) %>;
      
       var labels = [
            '<%= ChartX.ContainsKey("1") ? ChartX["1"] : null %>', '<%= ChartX.ContainsKey("2") ? ChartX["2"] : null %>',
        '<%= ChartX.ContainsKey("3") ? ChartX["3"] : null %>', '<%= ChartX.ContainsKey("4") ? ChartX["4"] : null %>',
        '<%= ChartX.ContainsKey("5") ? ChartX["5"] : null %>', '<%= ChartX.ContainsKey("6") ? ChartX["6"] : null %>',
        '<%= ChartX.ContainsKey("7") ? ChartX["7"] : null %>', '<%= ChartX.ContainsKey("8") ? ChartX["8"] : null %>',
        '<%= ChartX.ContainsKey("9") ? ChartX["9"] : null %>', '<%= ChartX.ContainsKey("10") ? ChartX["10"] : null %>',
        '<%= ChartX.ContainsKey("11") ? ChartX["11"] : null %>', '<%= ChartX.ContainsKey("12") ? ChartX["12"] : null %>',
        '<%= ChartX.ContainsKey("13") ? ChartX["13"] : null %>', '<%= ChartX.ContainsKey("14") ? ChartX["14"] : null %>',
        '<%= ChartX.ContainsKey("15") ? ChartX["15"] : null %>', '<%= ChartX.ContainsKey("16") ? ChartX["16"] : null %>',
        '<%= ChartX.ContainsKey("17") ? ChartX["17"] : null %>', '<%= ChartX.ContainsKey("18") ? ChartX["18"] : null %>',
        '<%= ChartX.ContainsKey("19") ? ChartX["19"] : null %>', '<%= ChartX.ContainsKey("20") ? ChartX["20"] : null %>',
        '<%= ChartX.ContainsKey("21") ? ChartX["21"] : null %>', '<%= ChartX.ContainsKey("22") ? ChartX["22"] : null %>',
        '<%= ChartX.ContainsKey("23") ? ChartX["23"] : null %>', '<%= ChartX.ContainsKey("24") ? ChartX["24"] : null %>',
        '<%= ChartX.ContainsKey("25") ? ChartX["25"] : null %>', '<%= ChartX.ContainsKey("26") ? ChartX["26"] : null %>',
        '<%= ChartX.ContainsKey("27") ? ChartX["27"] : null %>', '<%= ChartX.ContainsKey("28") ? ChartX["28"] : null %>',
        '<%= ChartX.ContainsKey("29") ? ChartX["29"] : null %>', '<%= ChartX.ContainsKey("30") ? ChartX["30"] : null %>'
        ];
        var companiesData = [
            <%= ChartY.ContainsKey("1") ? ChartY["1"] : "0" %>, <%= ChartY.ContainsKey("2") ? ChartY["2"] : "0" %>,
        <%= ChartY.ContainsKey("3") ? ChartY["3"] : "0" %>, <%= ChartY.ContainsKey("4") ? ChartY["4"] : "0" %>,
        <%= ChartY.ContainsKey("5") ? ChartY["5"] : "0" %>, <%= ChartY.ContainsKey("6") ? ChartY["6"] : "0" %>,
        <%= ChartY.ContainsKey("7") ? ChartY["7"] : "0" %>, <%= ChartY.ContainsKey("8") ? ChartY["8"] : "0" %>,
        <%= ChartY.ContainsKey("9") ? ChartY["9"] : "0" %>, <%= ChartY.ContainsKey("10") ? ChartY["10"] : "0" %>,
        <%= ChartY.ContainsKey("11") ? ChartY["11"] : "0" %>, <%= ChartY.ContainsKey("12") ? ChartY["12"] : "0" %>,
        <%= ChartY.ContainsKey("13") ? ChartY["13"] : "0" %>, <%= ChartY.ContainsKey("14") ? ChartY["14"] : "0" %>,
        <%= ChartY.ContainsKey("15") ? ChartY["15"] : "0" %>, <%= ChartY.ContainsKey("16") ? ChartY["16"] : "0" %>,
        <%= ChartY.ContainsKey("17") ? ChartY["17"] : "0" %>, <%= ChartY.ContainsKey("18") ? ChartY["18"] : "0" %>,
        <%= ChartY.ContainsKey("19") ? ChartY["19"] : "0" %>, <%= ChartY.ContainsKey("20") ? ChartY["20"] : "0" %>,
        <%= ChartY.ContainsKey("21") ? ChartY["21"] : "0" %>, <%= ChartY.ContainsKey("22") ? ChartY["22"] : "0" %>,
        <%= ChartY.ContainsKey("23") ? ChartY["23"] : "0" %>, <%= ChartY.ContainsKey("24") ? ChartY["24"] : "0" %>,
        <%= ChartY.ContainsKey("25") ? ChartY["25"] : "0" %>, <%= ChartY.ContainsKey("26") ? ChartY["26"] : "0" %>,
        <%= ChartY.ContainsKey("27") ? ChartY["27"] : "0" %>, <%= ChartY.ContainsKey("28") ? ChartY["28"] : "0" %>,
        <%= ChartY.ContainsKey("29") ? ChartY["29"] : "0" %>, <%= ChartY.ContainsKey("30") ? ChartY["30"] : "0" %>
        ];
        var followupsData = [
            <%= ChartZ.ContainsKey("1") ? ChartZ["1"] : "0" %>, <%= ChartZ.ContainsKey("2") ? ChartZ["2"] : "0" %>,
        <%= ChartZ.ContainsKey("3") ? ChartZ["3"] : "0" %>, <%= ChartZ.ContainsKey("4") ? ChartZ["4"] : "0" %>,
        <%= ChartZ.ContainsKey("5") ? ChartZ["5"] : "0" %>, <%= ChartZ.ContainsKey("6") ? ChartZ["6"] : "0" %>,
        <%= ChartZ.ContainsKey("7") ? ChartZ["7"] : "0" %>, <%= ChartZ.ContainsKey("8") ? ChartZ["8"] : "0" %>,
        <%= ChartZ.ContainsKey("9") ? ChartZ["9"] : "0" %>, <%= ChartZ.ContainsKey("10") ? ChartZ["10"] : "0" %>,
        <%= ChartZ.ContainsKey("11") ? ChartZ["11"] : "0" %>, <%= ChartZ.ContainsKey("12") ? ChartZ["12"] : "0" %>,
        <%= ChartZ.ContainsKey("13") ? ChartZ["13"] : "0" %>, <%= ChartZ.ContainsKey("14") ? ChartZ["14"] : "0" %>,
        <%= ChartZ.ContainsKey("15") ? ChartZ["15"] : "0" %>, <%= ChartZ.ContainsKey("16") ? ChartZ["16"] : "0" %>,
        <%= ChartZ.ContainsKey("17") ? ChartZ["17"] : "0" %>, <%= ChartZ.ContainsKey("18") ? ChartZ["18"] : "0" %>,
        <%= ChartZ.ContainsKey("19") ? ChartZ["19"] : "0" %>, <%= ChartZ.ContainsKey("20") ? ChartZ["20"] : "0" %>,
        <%= ChartZ.ContainsKey("21") ? ChartZ["21"] : "0" %>, <%= ChartZ.ContainsKey("22") ? ChartZ["22"] : "0" %>,
        <%= ChartZ.ContainsKey("23") ? ChartZ["23"] : "0" %>, <%= ChartZ.ContainsKey("24") ? ChartZ["24"] : "0" %>,
        <%= ChartZ.ContainsKey("25") ? ChartZ["25"] : "0" %>, <%= ChartZ.ContainsKey("26") ? ChartZ["26"] : "0" %>,
        <%= ChartZ.ContainsKey("27") ? ChartZ["27"] : "0" %>, <%= ChartZ.ContainsKey("28") ? ChartZ["28"] : "0" %>,
        <%= ChartZ.ContainsKey("29") ? ChartZ["29"] : "0" %>, <%= ChartZ.ContainsKey("30") ? ChartZ["30"] : "0" %>
        ];

        window.onload = function () {
            try {
                // 1. نمودار مربوط به شرکت‌ها
                const companiesCanvas = document.getElementById('companiesChart');
                if (companiesCanvas) {
                    const companiesCtx = companiesCanvas.getContext('2d');
                    new Chart(companiesCtx, {
                        type: 'bar', // نوع نمودار: میله‌ای
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'شرکت‌های ایجادشده',
                                data: companiesData,
                                backgroundColor: 'rgba(75, 192, 192, 0.5)',
                                borderColor: 'rgba(75, 192, 192, 1)',
                                borderWidth: 1
                            }]
                        },
                        options: {
                            responsive: true,
                            plugins: {
                                legend: {
                                    position: 'top',
                                },
                                title: {
                                    display: true,
                                    text: 'نمودار تعداد شرکت‌ها'
                                }
                            },
                            scales: {
                                y: {
                                    beginAtZero: true,
                                    title: {
                                        display: true,
                                        text: 'تعداد'
                                    }
                                },
                                x: {
                                    title: {
                                        display: true,
                                        text: 'تاریخ'
                                    }
                                }
                            }
                        }
                    });
                } else {
                    console.error('Canvas element with ID "companiesChart" not found.');
                }

                // 2. نمودار مربوط به پیگیری‌ها
                const followupsCanvas = document.getElementById('followupsChart');
                if (followupsCanvas) {
                    const followupsCtx = followupsCanvas.getContext('2d');
                    new Chart(followupsCtx, {
                        type: 'line', // نوع نمودار: خطی
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'تعداد پیگیری‌ها',
                                data: followupsData,
                                backgroundColor: 'rgba(153, 102, 255, 0.4)',
                                borderColor: 'rgba(153, 102, 255, 1)',
                                borderWidth: 2,
                                tension: 0.3, // برای منحنی کردن خطوط
                                fill: true
                            }]
                        },
                        options: {
                            responsive: true,
                            plugins: {
                                legend: {
                                    position: 'top',
                                },
                                title: {
                                    display: true,
                                    text: 'نمودار تعداد پیگیری‌ها'
                                }
                            },
                            scales: {
                                y: {
                                    beginAtZero: true,
                                    title: {
                                        display: true,
                                        text: 'تعداد'
                                    }
                                },
                                x: {
                                    title: {
                                        display: true,
                                        text: 'تاریخ'
                                    }
                                }
                            }
                        }
                    });
                } else {
                    console.error('Canvas element with ID "followupsChart" not found.');
                }

            } catch (e) {
                console.error('Chart initialization error:', e);
            }
        };

        // این بخش کد مربوط به نمایش بیشتر/کمتر را بدون تغییر نگه دارید
        $(document).ready(function () {
            $('#<%= lvActivities.ClientID %>').on('click', '.show-more', function (e) {
                e.preventDefault();
                var $this = $(this);
                var $descriptionSpan = $this.prev('.description-text');
                var $fullText = $this.next('.full-text');
                if (!$descriptionSpan.data('truncated-text')) {
                    $descriptionSpan.data('truncated-text', $descriptionSpan.text());
                    $descriptionSpan.data('full-text', $fullText.text());
                }
                if ($this.text() === 'نمایش بیشتر') {
                    $descriptionSpan.text($descriptionSpan.data('full-text'));
                    $this.text('نمایش کمتر');
                } else {
                    $descriptionSpan.text($descriptionSpan.data('truncated-text'));
                    $this.text('نمایش بیشتر');
                }
            });
        });
    </script>--%>

</asp:Content>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tile {
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 15px;
            height: 200px;
            width: 100%;
            background-color: #f9f9f9;
            direction: rtl;
            overflow: hidden;
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

        .chart-container {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            direction: rtl;
        }

        .staff-info {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            direction: rtl;
            display: flex;
            align-items: center;
        }

            .staff-info img {
                width: 50px;
                height: 50px;
                border-radius: 50%;
                margin-left: 10px;
            }

        .nav-tabs li.active a {
            background-color: #007bff;
            color: white;
        }

        .text-danger {
            display: block;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">لیست کارکردهای روزانه</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li><span>کارکردها</span></li>
                    <li class="active"><span>لیست کارکردهای روزانه</span></li>
                </ol>
            </div>
        </div>
    </section>
    <section class="panel panel-white no-radius">
        <div class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
            لیست کارکردهای روزانه
        </div>
        <div class="right panel-white">
            <div class="col-sm-12">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="form-group" style="margin-top: 20px;">
                                <asp:Button ID="btnBack" runat="server" Text="بازگشت به لیست کارمندان" CssClass="btn btn-primary pull-right" OnClick="btnBack_Click" />
                            </div>
                        </div>
                        <div class="staff-info">
                            <asp:Image ID="imgStaff" runat="server" ImageUrl="../../img/default-user.png" AlternateText="تصویر کارمند" />
                            <asp:Label ID="lblStaffName" runat="server" CssClass="text-dark" Style="font-size: large;"></asp:Label>
                        </div>
                        <div class="tabbable no-margin no-padding chart-container panel-white">
                            <ul class="nav nav-tabs" dir="rtl">
                                <li id="myTab7" class='<%= Request.QueryString["type"] == "week" || string.IsNullOrEmpty(Request.QueryString["type"]) ? "active" : "" %>'>
                                    <asp:LinkButton ID="lnkWeekly" runat="server" Text="week" OnClick="lnkTab_Click" CommandArgument="week" CssClass="btn" />
                                </li>

                                <li id="myTab" class='<%= Request.QueryString["type"] == "month" ? "active" : "" %>'>
                                    <asp:LinkButton ID="lnkMonthly" runat="server" Text="month" OnClick="lnkTab_Click" CommandArgument="month" CssClass="btn" />
                                </li>

                                <li id="myTab90" class='<%= Request.QueryString["type"] == "season" ? "active" : "" %>'>
                                    <asp:LinkButton ID="lnkSeasonal" runat="server" Text="فصلی" OnClick="lnkTab_Click" CommandArgument="season" CssClass="btn" />
                                </li>
                            </ul>
                            <div class="tab-pane padding-bottom-5">
                                <div class="panel-body">
                                    <div class="text-center">
                                        <asp:Label ID="lblChartType" runat="server" Style="font-size: large;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="chart-container">
                            <div class="row">
                                <div class="col-md-6">
                                    <h4>نمودار تعداد شرکت‌های ثبت‌شده</h4>
                                    <canvas id="companiesChart"></canvas>
                                </div>
                                <div class="col-md-6">
                                    <h4>نمودار تعداد پیگیری‌ها</h4>
                                    <canvas id="followupsChart"></canvas>
                                </div>
                            </div>
                        </div>
                        <asp:Literal ID="litChartData" runat="server" EnableViewState="false"></asp:Literal>
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                        <asp:ListView ID="lvActivities" runat="server" DataKeyNames="id" OnPagePropertiesChanging="lvActivities_PagePropertiesChanging">
                            <LayoutTemplate>
                                <div class="row">
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </div>
                                <div class="text-center" style="margin-top: 20px;">
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvActivities" PageSize="100">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                                ShowNextPageButton="true" ShowLastPageButton="true" FirstPageText="اولین" PreviousPageText="قبلی"
                                                NextPageText="بعدی" LastPageText="آخرین" ButtonCssClass="btn btn-sm btn-default" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="col-md-3 col-sm-6" style="margin-bottom: 20px;">
                                    <div class="tile">
                                        <div><strong>تاریخ:</strong> <%# Eval("PersianDate") %></div>
                                        <div>
                                            <div><strong>زمان شروع:</strong> <%# Eval("timeopen") %></div>
                                            <div><strong>زمان پایان:</strong> <%# Eval("timeclose") %></div>
                                            <div><strong>پیگیری‌ها:</strong> <%# Eval("followup_count") %></div>
                                            <div><strong>شرکت‌ها:</strong> <%# Eval("created_companies_count") %></div>
                                            <strong>توضیحات:</strong>
                                            <span class="description" data-full-text='<%# Eval("descriptionofday") %>'>
                                                <%# GetTruncatedDescription(Eval("descriptionofday").ToString()) %>
                                            </span>
                                            <%# string.IsNullOrEmpty(Eval("descriptionofday").ToString()) || Eval("descriptionofday").ToString().Length <= 100 ? "" : "<a href='#' class='show-more'>نمایش بیشتر</a>" %>
                                        </div>
                                        <div class="btn-group">
                                            <asp:HyperLink ID="lnkDetail" runat="server" CssClass="btn btn-sm btn-primary"
                                                NavigateUrl='<%# "~/panel/maneger/Detail_Activity_Day.aspx?id_staff=" + Request.QueryString["id_staff"] + "&date_day=" + Server.UrlEncode(Eval("PersianDate").ToString()) %>'
                                                Text="جزئیات فعالیت" />
                                            <asp:HyperLink ID="lnkCustomer" runat="server" CssClass="btn btn-sm btn-secondary"
                                                NavigateUrl='<%# "~/panel/maneger/customer.aspx?id_staff=" + Request.QueryString["id_staff"] + "&date_day=" + Server.UrlEncode(Eval("PersianDate").ToString()) %>'
                                                Text="مشتریان" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div class="text-center" style="padding: 20px;">
                                    هیچ کارکردی یافت نشد.
                                </div>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="vendor/Chart.js/Chart.js"></script>
    <script src="Scripts/Chart.min.js"></script>
    <script src="../../Scripts/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js@4.4.4/dist/chart.umd.min.js"></script>
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

            var chartData = {};
            try {
                chartData = JSON.parse($('#chartData').val() || '{}');
            } catch (e) {
                console.error('Error parsing chartData:', e);
            }
            var dates = chartData.dates || [];
            var companies = chartData.companies || [];
            var followups = chartData.followups || [];

            var validData = [];
            for (var i = 0; i < dates.length; i++) {
                if (dates[i] && companies[i] != null && followups[i] != null) {
                    validData.push({
                        date: dates[i],
                        company: companies[i],
                        followup: followups[i]
                    });
                }
            }

            var companiesCtx = document.getElementById('companiesChart').getContext('2d');
            new Chart(companiesCtx, {
                type: 'bar',
                data: {
                    labels: validData.map(function (item) { return item.date; }),
                    datasets: [{
                        label: 'تعداد شرکت‌ها',
                        data: validData.map(function (item) { return item.company; }),
                        backgroundColor: '#007bff',
                        borderColor: '#0056b3',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: { position: 'top', labels: { font: { size: 12 } } },
                        title: { display: true, text: 'تعداد شرکت‌های ثبت‌شده', font: { size: 16 } },
                        tooltip: { callbacks: { label: function (context) { return context.parsed.y + ' شرکت'; } } }
                    },
                    scales: {
                        x: { title: { display: true, text: 'تاریخ' } },
                        y: { title: { display: true, text: 'تعداد' }, beginAtZero: true }
                    }
                }
            });

            var followupsCtx = document.getElementById('followupsChart').getContext('2d');
            new Chart(followupsCtx, {
                type: 'bar',
                data: {
                    labels: validData.map(function (item) { return item.date; }),
                    datasets: [{
                        label: 'تعداد پیگیری‌ها',
                        data: validData.map(function (item) { return item.followup; }),
                        backgroundColor: '#28a745',
                        borderColor: '#1e7e34',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: { position: 'top', labels: { font: { size: 12 } } },
                        title: { display: true, text: 'تعداد پیگیری‌های روزانه', font: { size: 16 } },
                        tooltip: { callbacks: { label: function (context) { return context.parsed.y + ' پیگیری'; } } }
                    },
                    scales: {
                        x: { title: { display: true, text: 'تاریخ' } },
                        y: { title: { display: true, text: 'تعداد' }, beginAtZero: true }
                    }
                }
            });
        });
    </script>
</asp:Content>--%>

