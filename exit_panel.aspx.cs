using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class exit_panel : System.Web.UI.Page
    {
        // Constant for redirect URL
        private const string LoginPageUrl = "~/account/Login.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if Session["mobile"] is null
                if (Session["mobile"] == null)
                {
                    Session.Abandon();
                    Response.Redirect(LoginPageUrl, false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    return;
                }

                try
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        string mobile = Session["mobile"].ToString();
                        var user = db.User_tbls.SingleOrDefault(c => c.Phone == mobile);

                        if (user != null)
                        {
                            // Log logout activity
                            db.P_Insert_activity_tbl(user.id, DateTime.Now.Date, DateTime.Now.TimeOfDay, user.Name + " از سامانه خارج شد.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error (e.g., using a logging framework like Serilog)
                    // For simplicity, redirect to login without throwing
                }

                // Clear session and redirect to login
                Session.Abandon();
                Response.Redirect(LoginPageUrl, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
    }
}