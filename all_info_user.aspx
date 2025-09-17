<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="all_info_user.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.all_info_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="panel_edit_account" class="tab-pane fade in active">
        <div role="form" id="form">
            <fieldset>
                <legend>اطلاعات حساب کاربری
                </legend>
                <div class="container">
                    <h2>مشخصات کاربر</h2>
                    <div class="row">
                        <!-- نام و نام خانوادگی -->
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">نام و نام خانوادگی</label>
                                <div class="input-group">
                                    <input type="text" placeholder="محسن سلیمانی" class="form-control" runat="server" id="lbl_firstname" name="firstname" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_firstname.ClientID %>')">
                                            کپی
               
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">پست الکترونیک</label>
                                <div class="input-group">
                                    <input type="email" placeholder="example@mail.com" class="form-control" runat="server" id="lbl_email" name="email" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_email.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">تلفن</label>
                                <div class="input-group">
                                    <input type="text" placeholder="09123456789" class="form-control" runat="server" id="lbl_phone" name="phone" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_phone.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">آدرس</label>
                                <div class="input-group">
                                    <input type="text" placeholder="تهران، خیابان آزادی" class="form-control" runat="server" id="lbl_address" name="address" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_address.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">کد پستی</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_post_code" name="post_code" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_post_code.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">تحصیلات</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_education" name="education" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_education.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">نقش</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_role" name="role" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_role.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">کد ملی</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_national_code" name="national_code" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_national_code.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">شخصیت</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_personality" name="personality" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_personality.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">کد اقتصادی</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_economic_code" name="economic_code" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_economic_code.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">تلفن ثابت</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_landline" name="landline" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_landline.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">شهر / استان</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_city_province" name="city_province" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_city_province.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">کد پشت کارت ملی</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_national_id_card_back_code" name="national_id_card_back_code" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_national_id_card_back_code.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">تاریخ تولد</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_date_of_birth" name="date_of_birth" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_date_of_birth.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">دارای امضای دیجیتال</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_has_token_sign" name="has_token_sign" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_has_token_sign.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">شماره حساب جاری</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_current_account_number" name="current_account_number" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_current_account_number.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">شماره حساب بانکی</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_bank_account_number" name="bank_account_number" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_bank_account_number.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">شماره شبا</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" runat="server" id="lbl_sheba_number" name="sheba_number" readonly />
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-primary copy-btn" onclick="copyToClipboard('<%= lbl_sheba_number.ClientID %>')">کپی</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    <script>
        // Function to copy text from input field to clipboard
        function copyToClipboard(elementId) {
            var copyText = document.getElementById(elementId);

            copyText.select();
            copyText.setSelectionRange(0, 99999); // For mobile devices

            // Copy the text inside the text field
            document.execCommand("copy");

        }
</script>
</asp:Content>
