<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="edit_profile.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="panel_edit_account" class="tab-pane fade in active">
        <div role="form" id="form">
            <fieldset>
                <legend>اطلاعات حساب کاربری
                </legend>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">
                                نام و نام خانوادگی
                            </label>

                            <%--<asp:Textbox CssClass="form-control" runat="server" ID="Textbox1"></asp:Textbox>--%>
                            <input type="text" placeholder="محسن سلیمانی" class="form-control" runat="server" id="lbl_firstname" name="firstname">
                        </div>

                        <div class="form-group">
                            <label class="control-label">
                                ایمیل
                            </label>
                            <input type="email" class="form-control" runat="server" id="lbl_email" name="email">
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                موبایل
                            </label>

                            <asp:TextBox ID="Txt_lbl_phone" CssClass="form-control" runat="server" MaxLength="11" TextMode="Number" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                آدرس
                            </label>
                            <input type="text" class="form-control" runat="server" id="lbl_address" name="address">
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                ویژگی های من / ما &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-characteristics">نمونه</a>
                            </label>
                            <input type="text" class="form-control" runat="server" id="lbl_about_us" name="about_us">
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                تخصص من / ما  &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-cv">نمونه</a>
                            </label>
                            <input type="text" class="form-control" runat="server" id="lbl_cv" name="cv">
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                شرح کامل از رویداد ها و وقایع کاری و شغلی من / ما  &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-description">نمونه</a>
                            </label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" ID="lbl_complete_cv"></asp:TextBox>


                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                مدارک و گواهینامه های من / ما &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-edu">نمونه</a>
                            </label>
                            <asp:Button ID="edu_edit" runat="server" CssClass="btn btn-grey" Text="ویرایش مدارک و گواهینامه ها" OnClick="edu_edit_Click" />
                            <%--<input type="text" placeholder=" مهندسی Nobin " class="form-control" runat="server" id="lbl_education" name="education">--%>
                        </div>

                        <div class="form-group">
                            <label class="control-label">
                                مهارت های من / ما &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-skilis">نمونه</a>
                            </label>

                            <asp:Button ID="skill_edit" runat="server" CssClass="btn btn-grey" Text="ویرایش مهارت ها" OnClick="skill_edit_Click" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                رزومه من / ما &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-cv_job">نمونه</a>
                            </label>

                            <asp:Button ID="job_or_project" CssClass="btn btn-grey" runat="server" Text="ویرایش رزومه" OnClick="job_or_project_Click" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                تجربیات من / ما &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-expriment">نمونه</a>
                            </label>

                            <asp:Button ID="practical" CssClass="btn btn-grey" runat="server" Text="ویرایش تجربیات" OnClick="practical_Click" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                رمز عبور
                            </label>
                            <asp:TextBox ID="lbl_Password" runat="server" CssClass="form-control" controltovalidate="Password" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="lbl_Password" CssClass="btn-block" ErrorMessage="رمز عبور مورد نياز است" ForeColor="Red" ToolTip="رمز عبور مورد نياز است" ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                تایید رمز عبور
                            </label>
                            <asp:TextBox ID="lbl_ConfirmPassword" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="lbl_ConfirmPassword" CssClass="btn-block" ErrorMessage="تکرار رمز عبور مورد نياز است" ForeColor="Red" ToolTip="تکرار رمز عبور مورد نياز است" ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">
                                شخصیت
                            </label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">

                                <asp:ListItem Value="1">حقیقی</asp:ListItem>
                                <asp:ListItem Value="0">حقوقی</asp:ListItem>
                            </asp:RadioButtonList>
                            <%-- <div class="clip-radio radio-primary">
                                                <input type="radio" name="person" runat="server" id="lbl_person">
                                                <label>
                                                    حقوقی
                                                </label>
                                                <input type="radio" name="company" runat="server" id="lbl_company">
                                                <label>
                                                    حقیقی
                                                </label>
                                            </div>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">
                                        کدپستی
                                    </label>
                                    <input class="form-control" placeholder="1445678934" type="number" name="zipcode" runat="server" id="lbl_postcode">
                                </div>
                            </div>
                            <%-- <div class="col-md-8">
                                                <div class="form-group">
                                                    <label class="control-label">
                                                        شهر
                                                    </label>
                                                    <input class="form-control tooltips" placeholder="تهران" type="text" name="city" runat="server" id="lbl_city">
                                                </div>
                                            </div>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">
                                        کدملی/ شناسه ملی
                                    </label>
                                    <input class="form-control" placeholder="1234567890" type="number" name="national_code" runat="server" id="lbl_national_code">
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="control-label">
                                        کد اقتصادی
                                    </label>
                                    <input class="form-control" placeholder="1234567890" type="number" name="economic_code" runat="server" id="lbl_economic_code">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                بارگذاری تصویر
                            </label>
                            <div class="fileinput fileinput-new" data-provides="fileinput">
                                <div class="fileinput-new thumbnail">

                                    <img id="img_edit" runat="server" src="../../img/default-user.png" alt="">
                                </div>
                                <asp:FileUpload ID="File_upload_img1" runat="server"></asp:FileUpload>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="cv" runat="server" Text="مشاهده صفحه شخصی من" CssClass="btn btn-success btn-block" OnClick="cv_Click" />

                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="slider" runat="server" Text="ویرایش اسلایدر" CssClass="btn btn-grey btn-block" OnClick="slider_Click" />
                                &nbsp;<a data-toggle="modal" data-target="#bd-example-modal-slider">نمونه</a>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

            <div class="row">
                <div class="col-md-12">
                    <div>
                        موارد ضروری
                        <hr>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p>
                        By clicking UPDATE, you are agreeing to the Policy and Terms &amp; Conditions.
                    </p>
                </div>
                <div class="col-md-4">
                    <asp:Button CssClass="btn btn-primary btn-block" ID="SAVE_Button" runat="server" Text="ثبت" OnClick="SAVE_Button_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-cv" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه شرح اجمالی از تخصص و تجربه</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/cv.jpg" alt="شرح اجمالی از تخصص و تجربه" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-characteristics" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه ویژگی های من / ما</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/characteristics.png" alt="شرح ویژگی های من / ما" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-description" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه شرح کامل از رویداد ها و وقایع کاری و شغلی</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/description.png" alt="شرح کامل از رویداد ها و وقایع کاری و شغلی" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-skilis" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه مهارت </h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/skilis.png" alt="مهارت ها" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-edu" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه مدارک و گواهینامه ها</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/edu.png" alt="مدارک و گواهینامه ها" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-cv_job" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه رزومه</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/cv_job.png" alt="رزومه" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-expriment" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه تجربیات من</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/expriment.png" alt="تجربیات من" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="bd-example-modal-slider" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <section class="bg-black" dir="ltr">
                    <div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="modal-header">
                            <h2 class="center text-warning">نمونه اسلایدر من</h2>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="">
                                    <img loading="lazy" src="../../img/example/slider.png" alt="اسلایدر من" class="img-responsive" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-grey" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
