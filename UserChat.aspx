<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChat.aspx.cs" Inherits="WebApplicationImpora2222025.UserChat" %>

<!DOCTYPE html>
<html>
<head>
    <title>صفحه چت کاربر</title>
   
    <script src="Scripts/jquery-3.7.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.3.min.js"></script>
    <script src="/signalr/hubs"></script>
    <style>
        #chatArea { border: 1px solid #ccc; padding: 10px; height: 300px; overflow-y: scroll; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>صفحه چت کاربر</h2>
        <div id="chatArea"></div>
        <input type="text" id="message" />
        <button type="button" id="sendButton">ارسال</button>
    </form>

    <script>
        $(function () {
            var chat = $.connection.chatHub;
            var userId = '<%= Session["UserId"] ?? "User_" + Guid.NewGuid().ToString() %>';

            // دریافت پیام از ادمین
            chat.client.receiveMessage = function (message) {
                $('#chatArea').append('<p><strong>ادمین:</strong> ' + message + '</p>');
            };

            // اتصال به هاب
            $.connection.hub.start().done(function () {
                $('#sendButton').click(function () {
                    var message = $('#message').val();
                    chat.server.sendMessageToAdmin(userId, message);
                    $('#chatArea').append('<p><strong>' + userId + ':</strong> ' + message + '</p>');
                    $('#message').val('');
                });
            });
        });
    </script>
</body>
</html>