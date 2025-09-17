using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class all_info_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           DataClasses1DataContext Db = new DataClasses1DataContext();
            if(Request.QueryString["id_user"]!= null)
            {
                var user = Db.User_tbls.Where(c => c.id == Convert.ToInt32(Request.QueryString["id_user"]));
                var user2 = Db.User_complete_info_tbls.Where(c => c.id_user == Convert.ToInt32(Request.QueryString["id_user"]));

                if (user.Count() == 1 )
                {
                    var user_sing = user.Single();
                    var user_sing2 = user2.Single();
                    lbl_firstname.Value =  user_sing.Name;
                    lbl_email.Value =  user_sing.Email;
                    lbl_phone.Value =  user_sing.Phone;
                    lbl_address.Value =  user_sing.Address;
                    lbl_post_code.Value =  user_sing.Post_code;
                    lbl_education.Value =  user_sing.Education;
                    lbl_role.Value =  user_sing.Role;
                    lbl_national_code.Value =  user_sing.national_code;
                    if ( user_sing.personality == true)
                    {
                        lbl_personality.Value = "حقیقی";
                    }
                    else if ( user_sing.personality == false)
                    {
                        lbl_personality.Value = "حقوقی";
                    }
                    else
                    {
                        lbl_personality.Value = "نامشخص";
                    }

                    lbl_economic_code.Value = user_sing.economic_code;
                    if (user.Count() == 1)
                    {
                        lbl_landline.Value = user_sing2.Landline;
                        lbl_city_province.Value = user_sing2.City_Province;
                        lbl_national_id_card_back_code.Value = user_sing2.National_ID_Card_Back_Code;
                        lbl_date_of_birth.Value = user_sing2.Date_of_Birth;
                        if (user_sing2.Has_token_sign == true)
                        {
                            lbl_has_token_sign.Value = "توکن امضای الکتونیک دارد";
                        }
                        else
                        {
                            lbl_has_token_sign.Value = "توکن امضای الکترونیک ندارد";
                        }
                        lbl_current_account_number.Value = user_sing2.Current_Account_Number;
                        lbl_bank_account_number.Value = user_sing2.Bank_Account_Number;
                        lbl_sheba_number.Value = user_sing2.Sheba_Number;
                    }
                    else
                    {
                        lbl_landline.Value = "";
                        lbl_city_province.Value = "";
                        lbl_national_id_card_back_code.Value = "";
                        lbl_date_of_birth.Value = "";                       
                            lbl_has_token_sign.Value = "توکن امضای الکترونیک ندارد";                       
                        lbl_current_account_number.Value = "";
                        lbl_bank_account_number.Value = "";
                        lbl_sheba_number.Value = "";
                    }


                }
                else
                {

                    lbl_firstname.Value = "";
                    lbl_email.Value = "";
                    lbl_phone.Value = "";
                    lbl_address.Value = "";
                    lbl_post_code.Value = "";
                    lbl_education.Value = "";
                    lbl_role.Value = "";
                    lbl_national_code.Value = "";
                    lbl_personality.Value = "نامشخص";
                    lbl_economic_code.Value = "";
                }
            }
            else
            {
                Response.Redirect("user");
            }
        }
    }
}