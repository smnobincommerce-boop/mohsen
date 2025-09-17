<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="chart_view_page.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.chart_view_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="screen">
    <link href="vendor/DataTables/css/DT_bootstrap.css" rel="stylesheet" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle_" id="maintitle" runat="server" dir="rtl">بروزرسانی جداول </h1>
                <span class="maindescription_" id="mainDescription" runat="server" dir="rtl">صفحه مورد نظر را از ساید بار انتخاب نمایید</span>
                 <span class="maindescription_" id="mainurl" runat="server"></span>
            </div>           
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
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="center no-visible" data-appears-class="fadeInUp" data-appears-delay="300">نمودار تعداد کاربر یک ماهه</h2>
                    <hr>
                     <asp:Label ID="Lbl_user30" runat="server" Text=""></asp:Label>/<asp:Label ID="Lbl_user_av" runat="server" Text=""></asp:Label>/<asp:Label ID="lbl_user_all" runat="server" Text="" ForeColor="Red" CssClass="text-left"></asp:Label>
                    <div>
                        <canvas id="myChart" class="full-width"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="center no-visible" data-appears-class="fadeInUp" data-appears-delay="300">نمودار بازدید یک ماهه</h2>
                    <hr>
                    <asp:Label ID="Lbl_view30" runat="server" Text=""></asp:Label>/  <asp:Label ID="Lbl_view_av" runat="server" Text=""></asp:Label>/<asp:Label ID="Lbl_view_all" runat="server" Text="" CssClass="text-left" ForeColor="Lime"></asp:Label>
                    <div>
                        <canvas id="myChart2" class="full-width"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="center no-visible" data-appears-class="fadeInUp" data-appears-delay="300">نمودار تعداد کاربر سه ماهه</h2>
                    <hr>
                     <asp:Label ID="Lbl_user90" runat="server" Text=""></asp:Label>/<asp:Label ID="Lbl_user_av3" runat="server" Text=""></asp:Label>/<asp:Label ID="lbl_user_all90" runat="server" Text="" ForeColor="Red" CssClass="text-left"></asp:Label>
                    <div>
                        <canvas id="myChart90" class="full-width"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="center no-visible" data-appears-class="fadeInUp" data-appears-delay="300">نمودار بازدید سه ماهه</h2>
                    <hr>
                    <asp:Label ID="Lbl_view90" runat="server" Text=""></asp:Label>/<asp:Label ID="Lbl_view_av3" runat="server" Text=""></asp:Label>/<asp:Label ID="Lbl_view_all90" runat="server" Text="" ForeColor="Lime" CssClass="text-left"></asp:Label>
                    <div>
                        <canvas id="myChart290" class="full-width"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script
        src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js">
    </script>
    <script>     
        new Chart("myChart", {
            type: "line",
            data: {
                labels: [' <%= x_1 %> ', ' <%= x_2 %> ', ' <%= x_3 %> ', ' <%= x_4 %> ', ' <%= x_5 %> ', ' <%= x_6 %> ', ' <%= x_7 %> ', ' <%= x_8 %> ', ' <%= x_9 %> ', ' <%= x_10 %> ', ' <%= x_11 %> ', ' <%= x_12 %> ', ' <%= x_13 %> ', ' <%= x_14 %> ', ' <%= x_15 %> ', ' <%= x_16 %> ', ' <%= x_17 %> ', ' <%= x_18 %> ', ' <%= x_19 %> ', ' <%= x_20 %> ', ' <%= x_21 %> ', ' <%= x_22 %> ', ' <%= x_23 %> ', ' <%= x_24 %> ', ' <%= x_25 %> ', ' <%= x_26 %> ', ' <%= x_27 %> ', ' <%= x_28 %> ', ' <%= x_29 %> ', ' <%= x_30 %> '],
                datasets: [{

                    fill: false,

                    backgroundColor: "rgba(255,204,102,1.0)",
                    borderColor: "rgba(44,47,59,1.0)",
                    borderWidth: 3,
                    data: [<%= y_1 %>, <%= y_2 %>, <%= y_3 %>, <%= y_4 %>, <%= y_5 %>, <%= y_6 %>, <%= y_7 %>, <%= y_8 %>, <%= y_9 %>, <%= y_10 %>, <%= y_11 %>, <%= y_12 %>, <%= y_13 %>, <%= y_14 %>, <%= y_15 %>, <%= y_16 %>, <%= y_17 %>, <%= y_18 %>, <%= y_19 %>, <%= y_20 %>, <%= y_21 %>, <%= y_22 %>, <%= y_23 %>, <%= y_24 %>, <%= y_25 %>, <%= y_26 %>, <%= y_27 %>, <%= y_28 %>, <%= y_29 %>, <%= y_30 %>]
                }]

            },
            options: {
                legend: { display: false },
               <%-- scales: {
                    yAxes: [{ ticks: { min: <%= miny %>, max: <%= maxy %> } }],
                }--%>
            }
        });
    </script>
    <script>     
        new Chart("myChart2", {
            type: "line",
            data: {
                labels: [' <%= x_1 %> ', ' <%= x_2 %> ', ' <%= x_3 %> ', ' <%= x_4 %> ', ' <%= x_5 %> ', ' <%= x_6 %> ', ' <%= x_7 %> ', ' <%= x_8 %> ', ' <%= x_9 %> ', ' <%= x_10 %> ', ' <%= x_11 %> ', ' <%= x_12 %> ', ' <%= x_13 %> ', ' <%= x_14 %> ', ' <%= x_15 %> ', ' <%= x_16 %> ', ' <%= x_17 %> ', ' <%= x_18 %> ', ' <%= x_19 %> ', ' <%= x_20 %> ', ' <%= x_21 %> ', ' <%= x_22 %> ', ' <%= x_23 %> ', ' <%= x_24 %> ', ' <%= x_25 %> ', ' <%= x_26 %> ', ' <%= x_27 %> ', ' <%= x_28 %> ', ' <%= x_29 %> ', ' <%= x_30 %> '],
                datasets: [{

                    fill: false,

                    backgroundColor: "rgba(255,204,102,1.0)",
                    borderColor: "rgba(44,47,59,1.0)",
                    borderWidth: 3,
                    data: [<%= z_1 %>, <%= z_2 %>, <%= z_3 %>, <%= z_4 %>, <%= z_5 %>, <%= z_6 %>, <%= z_7 %>, <%= z_8 %>, <%= z_9 %>, <%= z_10 %>, <%= z_11 %>, <%= z_12 %>, <%= z_13 %>, <%= z_14 %>, <%= z_15 %>, <%= z_16 %>, <%= z_17 %>, <%= z_18 %>, <%= z_19 %>, <%= z_20 %>, <%= z_21 %>, <%= z_22 %>, <%= z_23 %>, <%= z_24 %>, <%= z_25 %>, <%= z_26 %>, <%= z_27 %>, <%= z_28 %>, <%= z_29 %>, <%= z_30 %>]
                }]

            },
            options: {
                legend: { display: false },
               <%-- scales: {
                    yAxes: [{ ticks: { min: <%= miny %>, max: <%= maxy %> } }],
                }--%>
            }
        });
    </script>
    <script>     
        new Chart("myChart90", {
            type: "line",
            data: {
                labels: [' <%= x1 %> ', ' <%= x2 %> ', ' <%= x3 %> ', ' <%= x4 %> ', ' <%= x5 %> ', ' <%= x6 %> ', ' <%= x7 %> ', ' <%= x8 %> ', ' <%= x9 %> ', ' <%= x10 %> ', ' <%= x11 %> ', ' <%= x12 %> ', ' <%= x13 %> ', ' <%= x14 %> ', ' <%= x15 %> ', ' <%= x16 %> ', ' <%= x17 %> ', ' <%= x18 %> ', ' <%= x19 %> ', ' <%= x20 %> ', ' <%= x21 %> ', ' <%= x22 %> ', ' <%= x23 %> ', ' <%= x24 %> ', ' <%= x25 %> ', ' <%= x26 %> ', ' <%= x27 %> ', ' <%= x28 %> ', ' <%= x29 %> ', ' <%= x30 %> ', ' <%= x31 %> ', ' <%= x32 %> ', ' <%= x33 %> ', ' <%= x34 %> ', ' <%= x35 %> ', ' <%= x36 %> ', ' <%= x37 %> ', ' <%= x38 %> ', ' <%= x39 %> ', ' <%= x40 %> ', ' <%= x41 %> ', ' <%= x42 %> ', ' <%= x43 %> ', ' <%= x44 %> ', ' <%= x45 %> ', ' <%= x46 %> ', ' <%= x47 %> ', ' <%= x48 %> ', ' <%= x49 %> ', ' <%= x50 %> ', ' <%= x51 %> ', ' <%= x52 %> ', ' <%= x53 %> ', ' <%= x54 %> ', ' <%= x55 %> ', ' <%= x56 %> ', ' <%= x57 %> ', ' <%= x58 %> ', ' <%= x59 %> ', ' <%= x60 %> ', ' <%= x61 %> ', ' <%= x62 %> ', ' <%= x63 %> ', ' <%= x64 %> ', ' <%= x65 %> ', ' <%= x66 %> ', ' <%= x67 %> ', ' <%= x68 %> ', ' <%= x69 %> ', ' <%= x70 %> ', ' <%= x71 %> ', ' <%= x72 %> ', ' <%= x73 %> ', ' <%= x74 %> ', ' <%= x75 %> ', ' <%= x76 %> ', ' <%= x77 %> ', ' <%= x78 %> ', ' <%= x79 %> ', ' <%= x80 %> ', ' <%= x81 %> ', ' <%= x82 %> ', ' <%= x83 %> ', ' <%= x84 %> ', ' <%= x85 %> ', ' <%= x86 %> ', ' <%= x87 %> ', ' <%= x88 %> ', ' <%= x89 %> ', ' <%= x90 %> '],
                datasets: [{
                    fill: false,
                    backgroundColor: "rgba(255,204,102,1.0)",
                    borderColor: "rgba(44,47,59,1.0)",
                    borderWidth: 3,
                    data: [ <%= y1 %> ,  <%= y2 %> ,  <%= y3 %> ,  <%= y4 %> ,  <%= y5 %> ,  <%= y6 %> ,  <%= y7 %> ,  <%= y8 %> ,  <%= y9 %> ,  <%= y10 %> ,  <%= y11 %> ,  <%= y12 %> ,  <%= y13 %> ,  <%= y14 %> ,  <%= y15 %> ,  <%= y16 %> ,  <%= y17 %> ,  <%= y18 %> ,  <%= y19 %> ,  <%= y20 %> ,  <%= y21 %> ,  <%= y22 %> ,  <%= y23 %> ,  <%= y24 %> ,  <%= y25 %> ,  <%= y26 %> ,  <%= y27 %> ,  <%= y28 %> ,  <%= y29 %> ,  <%= y30 %> ,  <%= y31 %> ,  <%= y32 %> ,  <%= y33 %> ,  <%= y34 %> ,  <%= y35 %> ,  <%= y36 %> ,  <%= y37 %> ,  <%= y38 %> ,  <%= y39 %> ,  <%= y40 %> ,  <%= y41 %> ,  <%= y42 %> ,  <%= y43 %> ,  <%= y44 %> ,  <%= y45 %> ,  <%= y46 %> ,  <%= y47 %> ,  <%= y48 %> ,  <%= y49 %> ,  <%= y50 %> ,  <%= y51 %> ,  <%= y52 %> ,  <%= y53 %> ,  <%= y54 %> ,  <%= y55 %> ,  <%= y56 %> ,  <%= y57 %> ,  <%= y58 %> ,  <%= y59 %> ,  <%= y60 %> ,  <%= y61 %> ,  <%= y62 %> ,  <%= y63 %> ,  <%= y64 %> ,  <%= y65 %> ,  <%= y66 %> ,  <%= y67 %> ,  <%= y68 %> ,  <%= y69 %> ,  <%= y70 %> ,  <%= y71 %> ,  <%= y72 %> ,  <%= y73 %> ,  <%= y74 %> ,  <%= y75 %> ,  <%= y76 %> ,  <%= y77 %> ,  <%= y78 %> ,  <%= y79 %> ,  <%= y80 %> ,  <%= y81 %> ,  <%= y82 %> ,  <%= y83 %> ,  <%= y84 %> ,  <%= y85 %> ,  <%= y86 %> ,  <%= y87 %> ,  <%= y88 %> ,  <%= y89 %> ,  <%= y90 %> ]
                }]
            },
            options: {
                legend: { display: false },
               <%-- scales: {
                    yAxes: [{ ticks: { min: <%= miny %>, max: <%= maxy %> } }],
                }--%>
            }
        });
    </script>
     <script>     
         new Chart("myChart290", {
             type: "line",
             data: {
                 labels: [' <%= x1 %> ', ' <%= x2 %> ', ' <%= x3 %> ', ' <%= x4 %> ', ' <%= x5 %> ', ' <%= x6 %> ', ' <%= x7 %> ', ' <%= x8 %> ', ' <%= x9 %> ', ' <%= x10 %> ', ' <%= x11 %> ', ' <%= x12 %> ', ' <%= x13 %> ', ' <%= x14 %> ', ' <%= x15 %> ', ' <%= x16 %> ', ' <%= x17 %> ', ' <%= x18 %> ', ' <%= x19 %> ', ' <%= x20 %> ', ' <%= x21 %> ', ' <%= x22 %> ', ' <%= x23 %> ', ' <%= x24 %> ', ' <%= x25 %> ', ' <%= x26 %> ', ' <%= x27 %> ', ' <%= x28 %> ', ' <%= x29 %> ', ' <%= x30 %> ', ' <%= x31 %> ', ' <%= x32 %> ', ' <%= x33 %> ', ' <%= x34 %> ', ' <%= x35 %> ', ' <%= x36 %> ', ' <%= x37 %> ', ' <%= x38 %> ', ' <%= x39 %> ', ' <%= x40 %> ', ' <%= x41 %> ', ' <%= x42 %> ', ' <%= x43 %> ', ' <%= x44 %> ', ' <%= x45 %> ', ' <%= x46 %> ', ' <%= x47 %> ', ' <%= x48 %> ', ' <%= x49 %> ', ' <%= x50 %> ', ' <%= x51 %> ', ' <%= x52 %> ', ' <%= x53 %> ', ' <%= x54 %> ', ' <%= x55 %> ', ' <%= x56 %> ', ' <%= x57 %> ', ' <%= x58 %> ', ' <%= x59 %> ', ' <%= x60 %> ', ' <%= x61 %> ', ' <%= x62 %> ', ' <%= x63 %> ', ' <%= x64 %> ', ' <%= x65 %> ', ' <%= x66 %> ', ' <%= x67 %> ', ' <%= x68 %> ', ' <%= x69 %> ', ' <%= x70 %> ', ' <%= x71 %> ', ' <%= x72 %> ', ' <%= x73 %> ', ' <%= x74 %> ', ' <%= x75 %> ', ' <%= x76 %> ', ' <%= x77 %> ', ' <%= x78 %> ', ' <%= x79 %> ', ' <%= x80 %> ', ' <%= x81 %> ', ' <%= x82 %> ', ' <%= x83 %> ', ' <%= x84 %> ', ' <%= x85 %> ', ' <%= x86 %> ', ' <%= x87 %> ', ' <%= x88 %> ', ' <%= x89 %> ', ' <%= x90 %> '],
                datasets: [{

                    fill: false,

                    backgroundColor: "rgba(255,204,102,1.0)",
                    borderColor: "rgba(44,47,59,1.0)",
                    borderWidth: 3,
                    data: [ <%= z1 %> ,  <%= z2 %> ,  <%= z3 %> ,  <%= z4 %> ,  <%= z5 %> ,  <%= z6 %> ,  <%= z7 %> ,  <%= z8 %> ,  <%= z9 %> ,  <%= z10 %> ,  <%= z11 %> ,  <%= z12 %> ,  <%= z13 %> ,  <%= z14 %> ,  <%= z15 %> ,  <%= z16 %> ,  <%= z17 %> ,  <%= z18 %> ,  <%= z19 %> ,  <%= z20 %> ,  <%= z21 %> ,  <%= z22 %> ,  <%= z23 %> ,  <%= z24 %> ,  <%= z25 %> ,  <%= z26 %> ,  <%= z27 %> ,  <%= z28 %> ,  <%= z29 %> ,  <%= z30 %> ,  <%= z31 %> ,  <%= z32 %> ,  <%= z33 %> ,  <%= z34 %> ,  <%= z35 %> ,  <%= z36 %> ,  <%= z37 %> ,  <%= z38 %> ,  <%= z39 %> ,  <%= z40 %> ,  <%= z41 %> ,  <%= z42 %> ,  <%= z43 %> ,  <%= z44 %> ,  <%= z45 %> ,  <%= z46 %> ,  <%= z47 %> ,  <%= z48 %> ,  <%= z49 %> ,  <%= z50 %> ,  <%= z51 %> ,  <%= z52 %> ,  <%= z53 %> ,  <%= z54 %> ,  <%= z55 %> ,  <%= z56 %> ,  <%= z57 %> ,  <%= z58 %> ,  <%= z59 %> ,  <%= z60 %> ,  <%= z61 %> ,  <%= z62 %> ,  <%= z63 %> ,  <%= z64 %> ,  <%= z65 %> ,  <%= z66 %> ,  <%= z67 %> ,  <%= z68 %> ,  <%= z69 %> ,  <%= z70 %> ,  <%= z71 %> ,  <%= z72 %> ,  <%= z73 %> ,  <%= z74 %> ,  <%= z75 %> ,  <%= z76 %> ,  <%= z77 %> ,  <%= z78 %> ,  <%= z79 %> ,  <%= z80 %> ,  <%= z81 %> ,  <%= z82 %> ,  <%= z83 %> ,  <%= z84 %> ,  <%= z85 %> ,  <%= z86 %> ,  <%= z87 %> ,  <%= z88 %> ,  <%= z89 %> ,  <%= z90 %> ]
                }]
            },
            options: {
                legend: { display: false },
               <%-- scales: {
                    yAxes: [{ ticks: { min: <%= miny %>, max: <%= maxy %> } }],
                }--%>
            }
        });
    </script>
    <asp:Button ID="Button1" runat="server" Text="بروزرسانی دیتای بازدید" OnClick="Button1_Click" />
     <asp:Button ID="Update_all" runat="server" Text="بروزرسانی دیتای بازدید" OnClick="Update_all_Click"/>
</asp:Content>
