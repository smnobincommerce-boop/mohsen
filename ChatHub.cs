using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;


[HubName("chatHub")]
public class ChatHub : Hub
{
    // لیست کاربران آنلاین (بهبود یافته با ConcurrentDictionary برای امنیت)
   
    private static ConcurrentDictionary<string, string> users = new ConcurrentDictionary<string, string>();
    

    // ورود کاربر و ذخیره اتصال
    public void Connect(string username, bool isAdmin)
    {
        try
        {
            string connectionId = Context.ConnectionId;

            if (string.IsNullOrEmpty(connectionId) || string.IsNullOrEmpty(username))
            {
                Clients.Caller.notify("خطا در اتصال به سرور.");
                return;
            }

            users[connectionId] = username;
            Clients.All.updateUserList(users.Values);

            if (isAdmin)
            {
                Clients.Caller.notify("شما به عنوان اپراتور وارد شده‌اید.");
            }
        }
        catch (System.Exception ex)
        {
            Clients.Caller.notify("خطای داخلی سرور: " + ex.Message);
        }
    }

    // ارسال پیام از کاربر به اپراتور
    public void SendMessage(string message)
    {
        try
        {
            string senderId = Context.ConnectionId;
            if (!string.IsNullOrEmpty(senderId) && users.ContainsKey(senderId))
            {
                string username = users[senderId];
                Clients.All.broadcastMessage(username, message);
            }
        }
        catch (System.Exception ex)
        {
            Clients.Caller.notify("خطا در ارسال پیام: " + ex.Message);
        }
    }

    // ارسال پاسخ از اپراتور به کاربر خاص
    public void SendResponse(string connectionId, string response)
    {
        try
        {
            if (!string.IsNullOrEmpty(connectionId) && users.ContainsKey(connectionId))
            {
                Clients.Client(connectionId).receiveResponse("اپراتور", response);
            }
        }
        catch (System.Exception ex)
        {
            Clients.Caller.notify("خطا در ارسال پاسخ: " + ex.Message);
        }
    }

    // مدیریت قطع ارتباط کاربر
    public override Task OnDisconnected(bool stopCalled)
    {
        try
        {
            string connectionId = Context.ConnectionId;

            if (!string.IsNullOrEmpty(connectionId) && users.ContainsKey(connectionId))
            {
                string removedUser;
                users.TryRemove(connectionId, out removedUser);
                Clients.All.updateUserList(users.Values);
            }
        }
        catch (System.Exception ex)
        {
            Clients.Caller.notify("خطا در قطع ارتباط: " + ex.Message);
        }

        return base.OnDisconnected(stopCalled);
    }

    // مدیریت اتصال مجدد کاربر
    public override Task OnReconnected()
    {
        try
        {
            string connectionId = Context.ConnectionId;

            if (!string.IsNullOrEmpty(connectionId) && users.ContainsKey(connectionId))
            {
                Clients.Caller.notify("اتصال مجدد شما برقرار شد.");
            }
        }
        catch (System.Exception ex)
        {
            Clients.Caller.notify("خطا در اتصال مجدد: " + ex.Message);
        }

        return base.OnReconnected();
    }
}
