<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="register_user_for_car.aspx.cs" Inherits="WebApplicationImpora2222025.register_user_for_car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div class="padding-top-40"></div>
        <div class="padding-top-50"></div>
        <div class="login">
            <div class="row">
                <div class="main-login col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                    <div class="box-login ">
                        <fieldset>
                            <div style="font-size: 100%;">

                                <div>
                                    <div class="text-center" style="font-size: large;">&nbsp;&nbsp;فرم ثبت اطلاعات برای سامانه &nbsp;&nbsp;</div>
                                </div>

                                <div class="form-group ">
                                    <asp:Label ID="Label12" runat="server" Text="" ForeColor="Lime" Font-Size="Large" Visible="false"></asp:Label>

                                    <asp:Label ID="Label22" runat="server" Text="" ForeColor="Red" Font-Size="Large" Visible="false"></asp:Label>
                                </div>

                                <div class="form-group ">
                                    <div class="text-right">
                                        <asp:Label ID="UserNameLabel" runat="server">نام <span class="symbol required" dir="rtl"></span></asp:Label>
                                    </div>
                                    <div dir="rtl">
                                        <asp:TextBox ID="Name" runat="server" Font-Names="B Koodak" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="Name" CssClass="btn-block" ErrorMessage="**نام لازم است**" Font-Names="B Koodak" ForeColor="Red" ToolTip="نام  لازم است" ValidationGroup="info"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <asp:Label ID="Label1" runat="server">نام خانوادگی <span class="symbol required" dir="rtl"></span></asp:Label>
                                    </div>
                                    <div dir="rtl">
                                        <asp:TextBox ID="last_name" runat="server" Font-Names="B Koodak" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="last_name" CssClass="btn-block" ErrorMessage="**نام خانوادگی لازم است**" Font-Names="B Koodak" ForeColor="Red" ToolTip="نام خانوادگی  لازم است" ValidationGroup="info"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <asp:Label ID="Label2" runat="server">جنسیت <span class="symbol required" dir="rtl"></span></asp:Label>
                                    </div>
                                    <div dir="rtl">
                                        <asp:DropDownList ID="sex" runat="server" Font-Names="B Koodak" CssClass="form-control">
                                            <asp:ListItem Selected="True"></asp:ListItem>
                                            <asp:ListItem>زن</asp:ListItem>
                                            <asp:ListItem>مرد</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="sex" runat="server" Font-Names="B Koodak" CssClass="form-control"></asp:TextBox>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="sex" CssClass="btn-block" ErrorMessage="**تعیین جنسیت لازم است**" Font-Names="B Koodak" ForeColor="Red" ToolTip="تعیین جنسیت لازم است" ValidationGroup="info"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <asp:Label ID="Label3" runat="server">وضعیت تاهل <span class="symbol required" dir="rtl"></span></asp:Label>
                                    </div>
                                    <div dir="rtl">

                                        <asp:DropDownList ID="marry" runat="server" Font-Names="B Koodak" CssClass="form-control">
                                            <asp:ListItem Selected="True"></asp:ListItem>
                                            <asp:ListItem>مجرد</asp:ListItem>
                                            <asp:ListItem>متاهل</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="sex" runat="server" Font-Names="B Koodak" CssClass="form-control"></asp:TextBox>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="marry" CssClass="btn-block" ErrorMessage="**تعیین وضعیت تاهل لازم است**" Font-Names="B Koodak" ForeColor="Red" ToolTip="تعیین وضعیت تاهل لازم است" ValidationGroup="info"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">کد ملی <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">

                                        <em>(مانند: 0012548754)</em>
                                        <asp:TextBox ID="national_num" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="**شماره ملی را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="national_num" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" ViewStateMode="Inherit" MinimumValue="10" MaximumValue="10" ControlToValidate="national_num"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">شماره شناسنامه <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند: 58754)</em>
                                        <asp:TextBox ID="num_shenasname" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="**شماره شناسنامه را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="num_shenasname" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" ViewStateMode="Inherit" MinimumValue="1" MaximumValue="10" ControlToValidate="num_shenasname" Type="Currency"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">تاريخ تولد  <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="ltr">
                                        <em>(مانند:03/09/1369)</em>
                                        <asp:TextBox ID="date_born" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="**تاريخ  را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="date_born" ValidationGroup="info" ForeColor="Red" ></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" ViewStateMode="Inherit" MinimumValue="10" MaximumValue="10" ControlToValidate="date_born"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">

                                    <div class="text-right">
                                        <label dir="rtl">نام پدر <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">

                                        <em>(مانند: سيد علي)</em>
                                        <asp:TextBox ID="name_father" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="**نام پدر را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="name_father" ValidationGroup="info" ForeColor="Red" ></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator22" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" MaximumValue="50" MinimumValue="3" ControlToValidate="name_father"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">تلفن ثابت <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند:02122074702)</em><br />
                                        <em>در هنگام وارد کردن اعداد دقت نمایید که صفحه کلیدتان روی انگلیسی باشد.</em>
                                        <asp:TextBox ID="phonecompany" runat="server" CssClass="form-control" Columns="2" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="**تلفن ثابت خود را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="phonecompany" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" MinimumValue="8" MaximumValue="8" ControlToValidate="phonecompany" Type="String"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">شماره همراه <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند:09124935658)</em><br />
                                        <em style="color: #FF0000">در هنگام وارد کردن اعداد دقت نمایید که صفحه کلیدتان روی انگلیسی باشد.</em>
                                        <em>شماره موبایل  متعلق به خود شخص باشد</em>
                                        <asp:TextBox ID="mobilemanegment" runat="server" CssClass="form-control" MaxLength="11" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="**شماره همراه خود را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="mobilemanegment" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" ControlToValidate="mobilemanegment" Type="String" MinimumValue="11" MaximumValue="11"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">شخصیت <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند: حقیقی)</em>
                                        <asp:DropDownList ID="personality" runat="server" CssClass="form-control">

                                            <asp:ListItem Selected="True"></asp:ListItem>
                                            <asp:ListItem>حقیقی</asp:ListItem>
                                            <asp:ListItem>حقوقی</asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="**شخصیت کاربری خود را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="personality" ValidationGroup="info" ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </div>


                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">رشته تحصیلی <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند: لیسانس مدیریت)</em>
                                        <asp:TextBox ID="graduate_fild" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="**نام رشته تحصیلی را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="graduate_fild" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" MinimumValue="2" MaximumValue="30" ControlToValidate="statecompany" ValidationGroup="info"></asp:RangeValidator>--%>
                                    </div>


                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">شماره شبا <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>نوع حساب حتما جاری باشد(با دسته چک و بدون دسته چک فرقی ندارد)</em>
                                        <em>(مانند:IR350590032900306177556001)</em>
                                        <asp:TextBox ID="num_sheba" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="**شماره شبا حساب جاری خود را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="num_sheba" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" MinimumValue="2" MaximumValue="30" ControlToValidate="statecompany" ValidationGroup="info"></asp:RangeValidator>--%>
                                    </div>


                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">بانک و شعبه و کد شعبه <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>بانک ملت/شعبه میدان کاج/ کد 12457</em>
                                        <em>با یک جستجوی ساده در اینترنت یا تماس با پشتیبانی بانک خودتان این اطلاعات را بدست بیاورید.</em>
                                        <asp:TextBox ID="bank_detail" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="**بانک و شعبه و کد شعبه را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="bank_detail" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" MinimumValue="2" MaximumValue="30" ControlToValidate="statecompany" ValidationGroup="info"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">کد پستی <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند:1881775158)</em>
                                        <em>(ده رقم باشد)</em>
                                        <asp:TextBox ID="pstsal_code" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="**نام استان را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="pstsal_code" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" MinimumValue="2" MaximumValue="30" ControlToValidate="statecompany" ValidationGroup="info"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">استان و شهر محل سکونت <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>(مانند:استان فارس/شهرآباده)</em>
                                        <asp:TextBox ID="citycompany" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="**نام شهر و استان را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="citycompany" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator9" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" MinimumValue="2" MaximumValue="20" ControlToValidate="citycompany" ValidationGroup="info"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group " dir="rtl">
                                    <div class="text-right">
                                        <label dir="rtl">آدرس محل سکونت <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div>
                                        <em>( مانند:ميدان صنعت خيابان ايران زمين خيابان گلستان شمالي پ 34 طبقه 5 واحد 23 شرقي )</em>
                                        <asp:TextBox ID="addresscompany" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="**آدرس کامل را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="addresscompany" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator7" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" MinimumValue="15" MaximumValue="150" ControlToValidate="addresscompany"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="text-right">
                                        <label dir="rtl">ایمیل <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div dir="rtl">
                                        <em>msoleimani87@gmail.com</em><br />
                                        <em>ایمیلی وارد کنید که قابلیت دسترسی به آن را داشته باشید.</em>
                                        <asp:TextBox ID="Email_txt" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="**ایمیل را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="Email_txt" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator11" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" MinimumValue="10" MaximumValue="50" ValidationGroup="info" ControlToValidate="namecompany"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group " dir="rtl">
                                    <div class="text-right">
                                        <label dir="rtl">کد پشت کارت ملی <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <div>

                                        <em>(کد پشت کارت ملی خود را وارد نمایید.)</em>
                                        <asp:TextBox ID="back_num_national" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="**سابقه کار در شرکت را وارد کنيد**"
                                            Font-Names="B Koodak" Font-Italic="False" ControlToValidate="back_num_national" ValidationGroup="info" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="*به طور صحيح وارد کنيد*" ValidationGroup="info" MinimumValue="15" MaximumValue="150" ControlToValidate="sabeghe_kar"></asp:RangeValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group " dir="rtl">
                                    <div class="text-right">
                                        <label dir="rtl">بارگذاری تصویر کارت ملی <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <em>لطفا خود تصویر را بدون حاشیه اضافی قرار دهید</em>
                                    <em>از قراردادن فایل های با ظرفیت بالا خودداری کنید</em>
                                    <asp:FileUpload ID="fileUpload1" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                                        ErrorMessage="فرمت یا حجم فایل نامعتبر است!"
                                        ClientValidationFunction="validateFile"
                                        OnServerValidate="ValidateFile" ValidationGroup="info" ControlToValidate="fileUpload1" ForeColor="Red">
</asp:CustomValidator>
                                </div>
                                <div class="form-group " dir="rtl">
                                    <div class="text-right">
                                        <label dir="rtl">بارگذاری تصویر پشت کارت ملی <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <em>لطفا خود تصویر را بدون حاشیه اضافی قرار دهید</em>
                                    <em>از قراردادن فایل های با ظرفیت بالا خودداری کنید</em>
                                    <asp:FileUpload ID="fileUpload2" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator2" runat="server"
                                        ErrorMessage="فرمت یا حجم فایل نامعتبر است!"
                                        ClientValidationFunction="validateFile"
                                        OnServerValidate="ValidateFile" ValidationGroup="info" ControlToValidate="fileUpload2" ForeColor="Red">
</asp:CustomValidator>
                                </div>
                                <div class="form-group " dir="rtl">
                                    <div class="text-right">
                                        <label dir="rtl">بارگذاری تصویر صفحه اول شناسنامه <span class="symbol required" dir="rtl"></span></label>
                                    </div>
                                    <em>لطفا خود تصویر را بدون حاشیه اضافی قرار دهید</em>
                                    <em>از قراردادن فایل های با ظرفیت بالا خودداری کنید</em>
                                    <asp:FileUpload ID="fileUpload3" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator3" runat="server"
                                        ErrorMessage="فرمت یا حجم فایل نامعتبر است!"
                                        ClientValidationFunction="validateFile"
                                        OnServerValidate="ValidateFile" ValidationGroup="info" ControlToValidate="fileUpload3" ForeColor="Red">
</asp:CustomValidator>
                                </div>
                                <br />
                                <div>

                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Visible="False" ForeColor="Lime"></asp:Label>
                                    <asp:Button ID="Button1" runat="server" Text="بازگشت" CssClass="col-md-2 btn  btn-info btn-lg btn-block" Font-Names="B Koodak" PostBackUrl="~/index" Visible="False" />
                                    <asp:Button ID="creataccaunt" runat="server" Text="ثبت" CssClass="col-md-2 btn btn-success btn-lg btn-block" Font-Names="B Koodak"   OnClick="creataccaunt_Click" ValidationGroup="info" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hiddenToken" runat="server" />
    </asp:Panel>
  
    <script type="text/javascript">
        function validateFile(source, args) {
            var allowedExtensions = ["jpg", "png" , "jpeg"];
            var maxSize = 2 * 1024 * 1024; // 2MB
            var errorMessage = ""; // پیام خطا برای هر فایل

            // گرفتن فایل آپلود مربوط به این اعتبارسنجی
            var fileInput = document.getElementById(source.controltovalidate);

            if (!fileInput || fileInput.files.length === 0) {
                errorMessage = "لطفاً یک فایل انتخاب کنید.";
            } else {
                var file = fileInput.files[0];
                var fileName = file.name;
                var fileSize = file.size;
                var fileExtension = fileName.split('.').pop().toLowerCase();

                if (!allowedExtensions.includes(fileExtension)) {
                    errorMessage = "فرمت فایل باید jpg یا png باشد.";
                } else if (fileSize > maxSize) {
                    errorMessage = "حجم فایل نباید بیشتر از 2MB باشد.";
                }
            }

            // اگر خطایی وجود داشته باشد، اعتبارسنجی نامعتبر است
            args.IsValid = errorMessage === "";

            // نمایش پیام خطا در همان کنترل
            if (!args.IsValid) {
                source.errormessage = errorMessage;
            }
        }

</script>
</asp:Content>
