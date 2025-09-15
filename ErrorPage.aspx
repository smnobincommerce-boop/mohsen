<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="WebApplicationImpora2222025.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>صفحه مورد نظر پیدا نشد</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-full-page">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 page-error">
                    <div class="error-number text-azure">
                        ۴۰۴ 😟
                    </div>
                    <div class="error-details col-sm-6 col-sm-offset-3">
                        <h3>اوه نه! این صفحه گم شده 😵</h3>
                        <p>
                            متأسفانه صفحه‌ای که دنبالش بودی پیدا نشد.  
            <br>
                            شاید موقتاً در دسترس نباشه، جابه‌جا شده یا حذف شده باشه.  
            <br>
                            لطفاً آدرس صفحه رو دوباره چک کن و مجدداً امتحان کن.  
            <br>
                            <a href="index" class="btn btn-red btn-return">🏠 برگرد به صفحه اصلی
                            </a>
                            <br>
                            هنوز به نتیجه نرسیدی؟  
            <br>
                            می‌تونی چیزی که دنبالش هستی رو جستجو کنی یا یه چرخی تو سایت بزنی. 🔍  
                        </p>
                        <a class="btn btn-info btn-return" href="result-search.aspx">جستجو در وب سایت نوبین</a>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
