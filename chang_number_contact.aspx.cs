using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class chang_number_contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            if(db.tel_contact_tbls.Where(c => c.active == true).Count()==1)
            {
                var tel_active = db.tel_contact_tbls.Where(c => c.active == true);
                lbl_name_page.InnerHtml = tel_active.Single().tel_contact_co + " فعال می باشد.";
            }
           
            
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var tel = db.tel_contact_tbls.Where(c => c.tel_contact_co.Contains(RadioButtonList1.SelectedValue.ToString()) && c.active == false);
            if (tel.Count() > 0)
            {
                var tel_not_active = db.tel_contact_tbls.Where(c =>  c.active == true);
               
                foreach(var element in tel_not_active)
                {
                    db.P_Update_tel_contact_tbl(element.id, false);
                }
                db.P_Update_tel_contact_tbl(tel.Single().id, true);
                var user = db.User_tbls.Where(c => c.Phone == Session["mobile"].ToString());
                db.P_Insert_activity_tbl(user.Single().id, DateTime.Now.Date, DateTime.Now.TimeOfDay, " تلفن تماس " + RadioButtonList1.SelectedValue + " توسط " + user.Single().Name + " اعمال گردید.");
                success_message.Visible = true;
                warning_message.Visible = false;
                success_Label.Visible = true;
                success_Label.Text = RadioButtonList1.SelectedValue.ToString() + " با موفقیت اعمال شد.";
            }
            else
            {
                warning_message.Visible = true;
                success_message.Visible = false;
                warning_Label.Visible = true;
                warning_Label.Text = "قبلا اعمال شده است.";
            }
        }
    }
}