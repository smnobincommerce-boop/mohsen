<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-danger { display: block; margin-bottom: 20px; }
        .text-success { display: block; margin-bottom: 20px; color: #28a745; }
    </style>
    <script src="../../Scripts/jquery-3.6.0.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">گفتگو با <asp:Label ID="lblRecipientName" runat="server" /></h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li><span>کارمندان</span></li>
                    <li><span>لیست کارمندان</span></li>
                    <li class="active"><span>گفتگو</span></li>
                </ol>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="blog-posts">
                <div class="row">
                    <div class="col-md-12">
                        <div class="post-media post-comments margin-top-30">
                            <div class="media" dir="rtl">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="upChatMessages" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick" />
                                        <asp:HiddenField ID="hfOldestMessageId" runat="server" Value="0" />
                                        <div id="chatContainer" style="max-height: 400px; overflow-y: auto; margin-bottom: 20px;">
                                            <asp:ListView ID="MessagesListView" runat="server">
                                                <LayoutTemplate>
                                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <div class="media message-item" style='<%# Eval("IsSenderCurrentUser").ToString() == "True" ? "text-align: left;" : "text-align: right;" %>' data-message-id='<%# Eval("Id") %>'>
                                                        <a href="#" class='<%# Eval("IsSenderCurrentUser").ToString() == "True" ? "pull-left" : "pull-right" %>'>
                                                            <img src='<%# string.IsNullOrEmpty(Eval("SenderPic").ToString()) ? "~/images/default-user.png" : Eval("SenderPic") %>' 
                                                                 alt="عکس کاربر" class="media-object img-circle padding-10" style="width: 80px; height: 80px;" />
                                                        </a>
                                                        <div class="media-body" style='<%# Eval("IsSenderCurrentUser").ToString() == "True" ? "background-color: #e3f2fd;" : "background-color: #f5f5f5;" %> padding: 10px; border-radius: 5px; max-width: 70%;'>
                                                            <h5 class="media-heading"><%# Eval("SenderName") %></h5>
                                                            <h5 class="media-heading" style="color: #0000FF"><%# Eval("SenderRole") %></h5>
                                                            <p><%# Eval("MessageText") %></p>
                                                            <asp:HyperLink ID="lnkAttachment" runat="server" 
                                                                           Visible='<%# !string.IsNullOrEmpty(Eval("AttachmentFilePath").ToString()) %>'
                                                                           NavigateUrl='<%# Eval("AttachmentFilePath") %>'
                                                                           Text='<%# "دانلود فایل: " + Eval("AttachmentFileName") %>' />
                                                            <div class="date" style="font-size: small; color: #666;">
                                                                <%# Eval("PersianDate") %> در ساعت <%# Eval("Time") %>
                                                                <%# Eval("IsRead").ToString() == "True" && Eval("IsSenderCurrentUser").ToString() == "True" ? "<span style='color: blue;'>(خوانده شده)</span>" : "" %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    <div class="text-center" style="padding: 20px;">
                                                        هیچ پیامی وجود ندارد.
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:ListView>
                                        </div>
                                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="upSendMessage" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group" style="margin-top: 20px;">
                                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="پیام خود را وارد کنید..." />
                                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" style="margin-top: 10px;" />
                                            <asp:Button ID="btnSend" runat="server" Text="ارسال" CssClass="btn btn-primary" style="margin-top: 10px;" OnClick="btnSend_Click" />
                                            <asp:Button ID="btnBack" runat="server" Text="بازگشت" CssClass="btn btn-default pull-left" style="margin-top: 10px;" OnClick="btnBack_Click" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var chatContainer = $('#chatContainer');
            var isLoading = false;

            chatContainer.scrollTop(chatContainer[0].scrollHeight);

            chatContainer.on('scroll', function () {
                if (chatContainer.scrollTop() <= 50 && !isLoading) {
                    isLoading = true;
                    var oldestMessageId = $('.message-item').first().data('message-id') || parseInt($('#<%= hfOldestMessageId.ClientID %>').val()) || 0;

                    $.ajax({
                        url: 'Chat.aspx/LoadOlderMessages',
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify({ oldestMessageId: oldestMessageId }),
                        success: function (response) {
                            var messages = response.d;
                            if (messages && messages.length > 0) {
                                var currentScrollHeight = chatContainer[0].scrollHeight;
                                var messagesHtml = messages.map(function (msg) {
                                    var alignment = msg.IsSenderCurrentUser ? 'text-align: left;' : 'text-align: right;';
                                    var pullClass = msg.IsSenderCurrentUser ? 'pull-left' : 'pull-right';
                                    var bgColor = msg.IsSenderCurrentUser ? '#e3f2fd' : '#f5f5f5';
                                    var attachmentHtml = msg.AttachmentFilePath ? '<a href="' + msg.AttachmentFilePath + '">دانلود فایل: ' + msg.AttachmentFileName + '</a>' : '';
                                    var readStatus = msg.IsRead && msg.IsSenderCurrentUser ? '<span style="color: blue;">(خوانده شده)</span>' : '';
                                    return [
                                        '<div class="media message-item" style="margin-bottom: 15px; ' + alignment + '" data-message-id="' + msg.Id + '">',
                                        '    <a href="#" class="' + pullClass + '">',
                                        '        <img src="' + (msg.SenderPic || '~/images/default-user.png') + '" alt="عکس کاربر" class="media-object img-circle padding-10" style="width: 80px; height: 80px;" />',
                                        '    </a>',
                                        '    <div class="media-body" style="background-color: ' + bgColor + '; padding: 10px; border-radius: 5px; max-width: 70%;">',
                                        '        <h5 class="media-heading">' + msg.SenderName + '</h5>',
                                        '        <h5 class="media-heading" style="color: #0000FF">' + msg.SenderRole + '</h5>',
                                        '        <p>' + (msg.MessageText || '') + '</p>',
                                        attachmentHtml,
                                        '        <div class="date" style="font-size: small; color: #666;">',
                                        '            ' + msg.PersianDate + ' در ساعت ' + msg.Time + ' ' + readStatus,
                                        '        </div>',
                                        '    </div>',
                                        '</div>'
                                    ].join('');
                                }).join('');

                                chatContainer.prepend(messagesHtml);
                                chatContainer.scrollTop(chatContainer[0].scrollHeight - currentScrollHeight + 50);
                                $('#<%= hfOldestMessageId.ClientID %>').val(messages[messages.length - 1].Id);
                            }
                            isLoading = false;
                        },
                        error: function (xhr) {
                            isLoading = false;
                            $('#<%= lblMessage.ClientID %>').text('خطا در بارگذاری پیام‌های قدیمی‌تر: ' + (xhr.responseJSON ? xhr.responseJSON.Message : 'خطای ناشناخته')).addClass('text-danger');
                            // Trigger UpdatePanel refresh
                            __doPostBack('<%= upChatMessages.ClientID %>', '');
                        }
                    });
                }
            });

            if (Sys && Sys.WebForms) {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                    chatContainer.scrollTop(chatContainer[0].scrollHeight);
                });
            }
        });
    </script>
</asp:Content>

<%--<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-danger { display: block; margin-bottom: 20px; }
        .text-success { display: block; margin-bottom: 20px; color: #28a745; }
    </style>
    <script src="../../Scripts/jquery-3.6.0.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-title">
        <div class="row">
            <div class="col-sm-8">
                <h1 class="mainTitle">گفتگو با <asp:Label ID="lblRecipientName" runat="server" /></h1>
            </div>
            <div class="pull-right">
                <ol class="breadcrumb" dir="rtl">
                    <li><span>کارمندان</span></li>
                    <li><span>لیست کارمندان</span></li>
                    <li class="active"><span>گفتگو</span></li>
                </ol>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="blog-posts">
                <div class="row">
                    <div class="col-md-12">
                        <div class="post-media post-comments margin-top-30">
                            <div class="media" dir="rtl">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="upChatMessages" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick" />
                                        <asp:HiddenField ID="hfOldestMessageId" runat="server" Value="0" />
                                        <div id="chatContainer" style="max-height: 400px; overflow-y: auto; margin-bottom: 20px;">
                                            <asp:ListView ID="MessagesListView" runat="server">
                                                <LayoutTemplate>
                                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <div class="div class="media message-item" style="margin-bottom: 15px; <%# Eval("IsSenderCurrentUser").ToString() == "True" ? "text-align: left;" : "text-align:right;" %>
                                                        data-message-id='<%# Eval("Id") %>'>
                                                        <a href="#" class="<%# Eval("IsSenderCurrentUser").ToString() == "True" ? "pull-left" : "pull-right" %>">
                                                            <img src="'<%# string.IsNullOrEmpty(Eval("SenderPic").ToString()) ? "~/images/default-user.png" : Eval("SenderPic") %>' 
                                                                 alt="عکس کاربر" class="media-object img-circle padding-10" style="width: 80px; height: 80px;" />
                                                        </a>
                                                        <div class="media-body" style="background-color: <%# Eval("IsSenderCurrentUser").ToString() == "True" ? "#e3f2fd" : "#f5f5f5" %>; padding: 10px; border-radius: 5px; max-width: 70%;">
                                                            <h5 class="media-heading"><% h5 Eval("SenderName") %></h5>
                                                            <h5 class="media-heading" style="color: #0000FF"><% h5 Eval("SenderRole") %></h5>
                                                            <p p p p p p p p p p <% % Eval("MessageText") %></p>
                                                            <asp:HyperLink ID="lnkAttachment" runat="server" 
                                                                           Visible='<%# !string.IsNullOrEmpty(Eval("AttachmentFilePath").ToString()) %>'
                                                                           NavigateUrl='<%# Eval("AttachmentFilePath") %>'
                                                                           Text='<%# "دانلود فایل: " + Eval("AttachmentFileName") %>' />
                                                            <div class="date" style="font-size: small; color: #666;">
                                                                <%# Eval("PersianDate") %> در ساعت <%# Eval("Time") %>
                                                                <%# Eval("IsRead").ToString() == "True" && Eval("IsSenderCurrentUser").ToString() == "True" ? "<span style='color: blue;'>(خوانده شده)</span>" : "" %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    <div class="text-center" style="padding: 20px;">
                                                        هیچ پیامی وجود ندارد.
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:ListView>
                                        </div>
                                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="upSendMessage" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group" style="margin-top: 20px;">
                                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="پیام خود را وارد کنید..." />
                                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" style="margin-top: 10px;" />
                                            <asp:Button ID="btnSend" runat="server" Text="ارسال" CssClass="btn btn-primary" style="margin-top: 10px;" OnClick="btnSend_Click" />
                                            <asp:Button ID="btnBack" runat="server" Text="بازگشت" CssClass="btn btn-default pull-left" style="margin-top: 10px;" OnClick="btnBack_Click" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var chatContainer = $('#chatContainer');
            var isLoading = false;

            chatContainer.scrollTop(chatContainer[0].scrollHeight);

            chatContainer.on('scroll', function () {
                if (chatContainer.scrollTop() <= 50 && !isLoading) {
                    isLoading = true;
                    var oldestMessageId = $('.message-item').first().data('message-id') || parseInt($('#<%= hfOldestMessageId.ClientID %>').val()) || 0;

                    $.ajax({
                        url: 'Chat.aspx/LoadOlderMessages',
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify({ oldestMessageId: oldestMessageId }),
                        success: function (response) {
                            var messages = response.d;
                            if (messages && messages.length > 0) {
                                var currentScrollHeight = chatContainer[0].scrollHeight;
                                var messagesHtml = messages.map(function (msg) {
                                    var alignment = msg.IsSenderCurrentUser ? 'text-align: left;' : 'text-align: right;';
                                    var pullClass = msg.IsSenderCurrentUser ? 'pull-left' : 'pull-right';
                                    var bgColor = msg.IsSenderCurrentUser ? '#e3f2fd' : '#f5f5f5';
                                    var attachmentHtml = msg.AttachmentFilePath ? '<a href="' + msg.AttachmentFilePath + '">دانلود فایل: ' + msg.AttachmentFileName + '</a>' : '';
                                    var readStatus = msg.IsRead && msg.IsSenderCurrentUser ? '<span style="color: blue;">(خوانده شده)</span>' : '';
                                    return [
                                        '<div class="media message-item" style="margin-bottom: 15px; ' + alignment + '" data-message-id="' + msg.Id + '">',
                                        '    <a href="#" class="' + pullClass + '">',
                                        '        <img src="' + (msg.SenderPic || '~/images/default-user.png') + '" alt="عکس کاربر" class="media-object img-circle padding-10" style="width: 80px; height: 80px;" />',
                                        '    </a>',
                                        '    <div class="media-body" style="background-color: ' + bgColor + '; padding: 10px; border-radius: 5px; max-width: 70%;">',
                                        '        <h5 class="media-heading">' + msg.SenderName + '</h5>',
                                        '        <h5 class="media-heading" style="color: #0000FF">' + msg.SenderRole + '</h5>',
                                        '        <p>' + (msg.MessageText || '') + '</p>',
                                        attachmentHtml,
                                        '        <div class="date" style="font-size: small; color: #666;">',
                                        '            ' + msg.PersianDate + ' در ساعت ' + msg.Time + ' ' + readStatus,
                                        '        </div>',
                                        '    </div>',
                                        '</div>'
                                    ].join('');
                                }).join('');

                                chatContainer.prepend(messagesHtml);
                                chatContainer.scrollTop(chatContainer[0].scrollHeight - currentScrollHeight + 50);
                                $('#<%= hfOldestMessageId.ClientID %>').val(messages[messages.length - 1].Id);
                            }
                            isLoading = false;
                        },
                        error: function (xhr) {
                            isLoading = false;
                            $('#<%= lblMessage.ClientID %>').text('خطا در بارگذاری پیام‌های قدیمی‌تر: ' + (xhr.responseJSON ? xhr.responseJSON.Message : 'خطای ناشناخته')).addClass('text-danger');
                            // Trigger UpdatePanel refresh
                            __doPostBack('<%= upChatMessages.ClientID %>', '');
                        }
                    });
                }
            });

            if (Sys && Sys.WebForms) {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                    chatContainer.scrollTop(chatContainer[0].scrollHeight);
                });
            }
        });
    </script>
</asp:Content>--%>