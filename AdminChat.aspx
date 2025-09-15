<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminChat.aspx.cs" Inherits="WebApplicationImpora2222025.AdminChat" %>


<!DOCTYPE html>
<html>
<head>
    <title>صفحه چت ادمین</title>
    <script src="Scripts/jquery-3.7.1.min.js"></script>
   
    <script src="Scripts/jquery.signalR-2.4.3.min.js"></script>
    <script src="/signalr/hubs"></script>
    <style>
        #chatArea { border: 1px solid #ccc; padding: 10px; height: 300px; overflow-y: scroll; }
        #usersList { width: 200px; float: right; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>صفحه چت ادمین</h2>
        <div id="usersList">
            <h3>کاربران فعال</h3>
            <ul id="activeUsers"></ul>
        </div>
        <div id="chatArea"></div>
        <input type="text" id="message" />
        <button type="button" id="sendButton">ارسال</button>
        <input type="hidden" id="selectedUser" />
    </form>

    <script>
        $(function () {
            var chat = $.connection.chatHub;

            // دریافت پیام از کاربران
            chat.client.receiveMessage = function (userId, message) {
                $('#chatArea').append('<p><strong>' + userId + ':</strong> ' + message + '</p>');
                $('#activeUsers').append('<li data-user="' + userId + '">' + userId + '</li>');
            };

            // انتخاب کاربر برای پاسخ
            $('#activeUsers').on('click', 'li', function () {
                var userId = $(this).data('user');
                $('#selectedUser').val(userId);
                $('#chatArea').append('<p>شما در حال چت با: ' + userId + '</p>');
            });

            // اتصال به هاب
            $.connection.hub.start().done(function () {
                $('#sendButton').click(function () {
                    var userId = $('#selectedUser').val();
                    var message = $('#message').val();
                    if (userId && message) {
                        chat.server.sendMessageToUser(userId, message);
                        $('#chatArea').append('<p><strong>ادمین:</strong> ' + message + '</p>');
                        $('#message').val('');
                    }
                });
            });
        });
    </script>
</body>
</html>