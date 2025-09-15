using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025
{
    public partial class careers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MetaDescription = "نیرو های مورد نیاز نوبین و شرایط همکاری با نوبین";
            Page.Title = "نوبین | همکاری با نوبین";
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext Db = new DataClasses1DataContext();
            var user = Db.User_tbls.Where(c => c.Phone == txt_mobile.Text);
            if (user.Count() == 1)
            {
                Db.P_Insert_Message_to_maneger_tbl(user.Single().Name, txt_mobile.Text, null, " متقاضی کار در " + txt_DropDownList1.SelectedValue.ToString(), txt_message.Text, DateTime.Now.ToShortDateString().ToString(), false, null, null, user.Single().id, null);

                var message1 = Db.Message_to_maneger_tbls.Where(c => c.id_user_sender == user.Single().id).OrderByDescending(c => c.id);
                Db.P_Insert_all_message_tbl(null, message1.Take(1).Single().id, null, null, user.Single().id, null, txt_message.Text, DateTime.Now.Date, DateTime.Now.TimeOfDay, null, null, null, true);

            }
            else
            {
                Response.Redirect("register-staff.aspx");
            }
        }
    }
}