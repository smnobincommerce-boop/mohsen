<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="D.aspx.cs" Inherits="WebApplicationImpora2222025.D" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ImportXpress.ir | Download</title>
    <!-- start: META -->
    <!--[if IE]><meta http-equiv='X-UA-Compatible' content="IE=edge,IE=9,IE=8,chrome=1" /><![endif]-->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- end: META -->
    <!-- start: GOOGLE FONTS -->
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,400italic,600,700|Raleway:300,400,500,600,700|Crete+Round:400italic" rel="stylesheet" type="text/css" />
    <!-- end: GOOGLE FONTS -->
    <!-- start: MAIN CSS -->
    <link rel="stylesheet" href="panel/maneger/vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="panel/maneger/vendor/fontawesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="panel/maneger/vendor/themify-icons/themify-icons.min.css" />
    <link href="panel/maneger/vendor/animate.css/animate.min.css" rel="stylesheet" media="screen" />
    <link href="panel/maneger/vendor/perfect-scrollbar/perfect-scrollbar.min.css" rel="stylesheet" media="screen" />
    <link href="panel/maneger/vendor/switchery/switchery.min.css" rel="stylesheet" media="screen" />
    <!-- end: MAIN CSS -->
    <!-- start: CLIP-TWO CSS -->
    <link rel="stylesheet" href="assets/css/styles1.css" />
    <link rel="stylesheet" href="panel/maneger/assets/css/plugins.css" />
    <link rel="stylesheet" href="panel/maneger/assets/css/themes/theme-1.css" id="skin_color" />
    <!-- end:  CSS -->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="success_message" runat="server" role="alert" class="alert alert-success padding-40" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                <strong>موفق!</strong>
                <asp:Label ID="success_Label" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div id="warning_message" runat="server" class="alert alert-warning padding-40" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                <strong>توجه!</strong>
                <asp:Label ID="warning_Label" runat="server" Text=""></asp:Label>
            </div>
            <div class="login" id="register_panel" runat="server">
                <div class="row">
                    <div class="main-login col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                        <div class="box-login ">
                            <fieldset>
                                <div style="font-size: 100%;" dir="rtl">
                                    <div class="padding-15">
                                        <div class="text-center" style="font-size: large">لینک دانلود </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button ID="Button2" runat="server" Text="دانلود" CssClass="col-md-2 btn btn-success btn-lg btn-block" OnClick="Button2_Click"  />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- end: LOGIN -->
    <!-- start: MAIN JAVASCRIPTS -->
    <script src="panel/maneger/vendor/jquery/jquery.min.js"></script>
    <script src="panel/maneger/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="panel/maneger/vendor/modernizr/modernizr.js"></script>
    <script src="panel/maneger/vendor/jquery-cookie/jquery.cookie.js"></script>
    <script src="panel/maneger/vendor/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <script src="panel/maneger/vendor/switchery/switchery.min.js"></script>
    <!-- end: MAIN JAVASCRIPTS -->
    <!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="panel/maneger/vendor/jquery-validation/jquery.validate.min.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <!-- start: CLIP-TWO JAVASCRIPTS -->
    <script src="panel/maneger/assets/js/main.js"></script>
    <!-- start: JavaScript Event Handlers for this page -->
    <script src="panel/maneger/assets/js/login.js"></script>
    <script>
        jQuery(document).ready(function () {
            Main.init();
            Login.init();
        });
    </script>
    <!-- end: JavaScript Event Handlers for this page -->
    <!-- end: CLIP-TWO JAVASCRIPTS -->
</body>
</html>
