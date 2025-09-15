<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplicationImpora2222025.Admin" %>


<!DOCTYPE html>
<html lang="fa">
<head runat="server">
    <meta charset="UTF-8">
    <title>پنل اپراتور</title>
 <script src="Scripts/jquery-3.7.1.min.js"></script>

    <script src="Scripts/jquery.signalR-2.4.3.min.js"></script>
<script src="/signalr/hubs"></script>
<script src="chat.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>پنل اپراتور</h2>
            <ul id="users"></ul>

            <select id="userList"></select>
            <input type="text" id="response" placeholder="پاسخ اپراتور" />
            <button type="button" onclick="sendResponse()">ارسال پاسخ</button>

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

            chatHub.client.updateUserList = function (users) {
                $('#users').empty();
                $('#userList').empty();
                $.each(users, function (index, user) {
                    $('#users').append('<li>' + user + '</li>');
                    $('#userList').append('<option value="' + index + '">' + user + '</option>');
                });
            };

            $.connection.hub.start().done(function () {
                chatHub.server.connect("اپراتور", true);
            });

            window.sendResponse = function () {
                var connectionId = $('#userList').val();
                var response = $('#response').val();
                chatHub.server.sendResponse(connectionId, response);
                $('#response').val('');
            };
        });
    </script>
</body>
</html>
