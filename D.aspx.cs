using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025
{
    public partial class D : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["I"] != null)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var download = db.files_tbls.Where(c => c.id == Convert.ToInt32(Request.QueryString["I"].ToString()));
                if (download.Count() == 1)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string path = HttpContext.Current.Request.Url.AbsolutePath;
                    Response.Redirect("https://nobincommerce.com" + download.Single().Files);
                }
                else
                {
                    Response.Redirect("https://nobincommerce.com/");
                }
            }
            else
            {
                Response.Redirect("https://nobincommerce.com/");
            }
        }
    }
}