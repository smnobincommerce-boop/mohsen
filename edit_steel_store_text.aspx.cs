using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class edit_steel_store_text : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string path = HttpContext.Current.Request.Url.AbsolutePath;

            //if (path.Contains("/panel/edit_steel_store_text.aspx?T=")  )
            //{

            //if (Session["role"].ToString() == "کارشناس تولید محتوا" || Session["role"].ToString() == "مدیر")
            //{
                if (Request.QueryString["T"] == null)
                {
                    Response.Redirect("~/panel/edit_steel_store_text.aspx?T=0");
                }
                else if (Request.QueryString["T"] == "0")
                {
                    div_choose.Visible = true;
                    //div_edit.Visible = false;
                    //div_grouping.Visible = false;
                    //div_tags.Visible = false;
                }

                
               


        }

       
        
     

       
    }
}