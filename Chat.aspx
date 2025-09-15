<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebApplicationImpora2222025.Chat" %>


<!DOCTYPE html>
<html lang="fa">
<head runat="server">
    <meta charset="UTF-8">
    <title>چت آنلاین</title>
    <script src="Scripts/jquery-3.7.1.min.js"></script>

    <script src="Scripts/jquery.signalR-2.4.3.min.js"></script>
<script src="/signalr/hubs"></script>
<script src="chat.js"></script>
   
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <input type="text" id="username" placeholder="نام شما" />
            <button type="button" onclick="connect()">ورود</button>
            <br>
            <input type="text" id="message" placeholder="پیام شما" />
            <button type="button" onclick="sendMessage()">ارسال</button>
            <ul id="messages"></ul>
        </div>
    </form>

    <script>
        $(function () {
            var chatHub = $.connection.chatHub;

            if (!chat) {
                console.error("خطا: اتصال به هاب برقرار نشد.");
                return;
            }
            chatHub.client.broadcastMessage = function (user, message) {
                $('#messages').append('<li><strong>' + user + ':</strong> ' + message + '</li>');
            };

            chatHub.client.receiveResponse = function (user, message) {
                $('#messages').append('<li style="color:blue"><strong>' + user + ':</strong> ' + message + '</li>');
            };

            $.connection.hub.start();

            window.connect = function () {
                var username = $('#username').val();
                chatHub.server.connect(username, false);
            };

            window.sendMessage = function () {
                var message = $('#message').val();
                chatHub.server.sendMessage(message);
                $('#message').val('');
            };
        });
    </script>
</body>
</html>
