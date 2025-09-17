<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Create_Reminder.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Create_Reminder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">ایجاد یادآوری</h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li>
                        <span>شرکت‌ها</span>
                    </li>
                    <li class="active">
                        <span>ایجاد یادآوری</span>
                    </li>
                </ol>
            </div>
        </div>
    </section>
    <section class="panel panel-white no-radius">
        <div id="main_title" runat="server" class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
        </div>

        <div class="right">
            <div class="col-sm-12">
                <div class="panel-heading border-dark" dir="rtl" style="font-size: x-large">
                    ایجاد یادآوری
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>شرکت:</label>
                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" ReadOnly="true" ValidationGroup="create" />
                                    <asp:HiddenField ID="hfCompanyId" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>عنوان یادآوری:</label>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" MaxLength="200" ValidationGroup="create" />
                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                        ErrorMessage="عنوان یادآوری الزامی است." CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>تاریخ یادآوری (شمسی):</label>
                                    <asp:TextBox ID="txtDateRemind" runat="server" CssClass="form-control" placeholder="مثال: 1404/03/08" ValidationGroup="create" />
                                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDateRemind"
                                        ErrorMessage="تاریخ یادآوری الزامی است." CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hfGregorianDate" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>زمان یادآوری:</label>
                                    <asp:TextBox ID="txtTimeRemind" runat="server" CssClass="form-control" Type="time" ValidationGroup="create" />
                                    <asp:RequiredFieldValidator ID="rfvTime" runat="server" ControlToValidate="txtTimeRemind"
                                        ErrorMessage="زمان یادآوری الزامی است." CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button ID="btnCreate" runat="server" Text="ایجاد یادآوری" CssClass="btn btn-primary" OnClick="btnCreate_Click" ValidationGroup="create" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <a href="List-Reminder" class="btn btn-primary">لیست یادآوری‌ها</a>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <a href="my_customer" class="btn btn-primary pull-right">بازگشت به لیست شرکت های من</a>
                                </div>
                            </div>

                            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- jQuery and Persian Datepicker -->

    <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    <%--   <script src="../../Scripts/persian-date.min.js"></script>
        <script src="../../Scripts/persian-datepicker.min.js"></script>
        <link href="../../Scripts/persian-datepicker.min.css" rel="stylesheet" />--%>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/persian-date@1.1.0/dist/js/persian-date.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/persian-datepicker@1.2.0/dist/js/persian-datepicker.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/persian-datepicker@1.2.0/dist/css/persian-datepicker.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            console.log("Textbox found: " + $("#<%= txtDateRemind.ClientID %>").length);
        if ($("#<%= txtDateRemind.ClientID %>").length > 0) {
            $("#<%= txtDateRemind.ClientID %>").persianDatepicker({
                format: 'YYYY/MM/DD',
                autoClose: true,
                persianNumbers: true,
                theme: 'default',
                toolbox: {
                    calendarSwitch: {
                        enabled: false
                    }
                },
                onSelect: function (unix) {
                    var persianDate = new persianDate(unix);
                    var gregorianDate = persianDate.toCalendar('gregorian').format('YYYY-MM-DD');
                    $("#<%= hfGregorianDate.ClientID %>").val(gregorianDate);
                }
            });
        } else {
            console.error("Textbox with ID <%= txtDateRemind.ClientID %> not found.");
        }
    });
    </script>
</asp:Content>

