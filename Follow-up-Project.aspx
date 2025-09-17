<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="Follow-up-Project.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.Follow_up_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/sweetalert/sweet-alert.css" rel="stylesheet" media="screen">
    <link href="vendor/sweetalert/ie9.css" rel="stylesheet" media="screen">
    <link href="vendor/toastr/toastr.min.css" rel="stylesheet" media="screen">
    <script type="text/javascript" src="../../Scripts/tinymce/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            selector: "textarea",
            language: 'fa',
            plugins: 'link',
            menubar: true,
            statusbar: true,
            directionality: 'rtl',
            toolbar: 'ltr rtl',
            plugins: 'advlist autolink link image lists charmap print preview',
            paste_auto_cleanup_on_paste: true,
            paste_postprocess: function (pl, o) {
                o.node.innerHTML = o.node.innerHTML.replace(/ /ig, " ");
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container-fluid container-fullw bg-white">
        <div class="panel-dark padding-20">
            <div>
                <div class="inline-block">
                    <i class="fa fa-briefcase"></i>
                    <span id="txt_project_name" runat="server" class="block week-day text-extra-large"></span>
                    <br />
                    <i class="fa fa-building"></i>
                    <span id="txt_company_name" runat="server" class="block week-day text-extra-large"></span>
                    <br />
                    <i class="fa fa-calendar"></i>
                    <span id="txt_date_create" runat="server" class="block week-day text-extra-large"></span>
                    <br />
                    <i class="fa fa-edit"></i>
                    <span id="txt_date_last_edit" runat="server" class="block week-day text-extra-large"></span>
                    <br />
                </div>
            </div>
            <div class="timeline_content" id="txt_project_description" runat="server" visible="false">
            </div>
            <div class="readmore">
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <a href="#new_log" class="btn btn-dark-yellow">ثبت پیگیری<i class="fa fa-pencil"></i></a>
                    </div>
                    <div class="col-md-6">
                        <br />
                        <span id="txt_log_count" runat="server" class="block month text-large text-light"></span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="container-fluid container-fullw bg-white">
        <div class="container">
            <div class="blog-posts">
                <div class="row">
                    <div class="col-md-12">
                        <div class="post-media post-comments margin-top-30">
                            <div class="media">
                                <asp:ListView ID="ListView_project_logs" runat="server">
                                    <EmptyDataTemplate>
                                        <td dir="rtl">هیچ پیگیری برای این پروژه وجود ندارد.</td>
                                    </EmptyDataTemplate>
                                    <ItemSeparatorTemplate>
                                        <br />
                                    </ItemSeparatorTemplate>
                                    <ItemTemplate>
                                        <a href="#" class="pull-right">
                                            <img id="img_user_log" runat="server" src='<%# Eval("Pic") %>' alt="" class="media-object img-circle padding-15" style="width: 80px; height: 100%" />
                                        </a>
                                        <div class="media-body">
                                            <h5 class="media-heading" id="name_user_log" runat="server"><%# Eval("Name") %></h5>
                                            <h5 class="media-heading" visible='<%# Eval("Role_visible") %>' id="role_user_log" runat="server" style="color: #0000FF"><%# Eval("Role") %></h5>
                                            <p id="txt_log_description" runat="server"><%# Eval("lastdescription") %></p>
                                            <span id="txt_date_create_log" runat="server" class="date" style="font-size: small"><%# Eval("datecreate") %></span>
                                            <hr />
                                        </div>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <div runat="server" id="itemPlaceholderContainer" style="">
                                            <div runat="server" id="itemPlaceholder" />
                                        </div>
                                        <div style=""></div>
                                    </LayoutTemplate>
                                    <SelectedItemTemplate>
                                        <li style="">
                                            <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /><br />
                                            <asp:Label Text='<%# Eval("Pic") %>' runat="server" ID="PicLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role") %>' runat="server" ID="RoleLabel" /><br />
                                            <asp:Label Text='<%# Eval("Role_visible") %>' runat="server" ID="Role_visibleLabel" /><br />
                                            <asp:Label Text='<%# Eval("lastdescription") %>' runat="server" ID="lastdescriptionLabel" /><br />
                                            <asp:Label Text='<%# Eval("datecreate") %>' runat="server" ID="datecreateLabel" /><br />
                                        </li>
                                    </SelectedItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div id="new_log">
            <div role="form">
                <fieldset>
                    <legend>ثبت پیگیری جدید</legend>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">توضیحات پیگیری</label>
                                <textarea id="txt_log_description" runat="server" class="form-control" cols="20" rows="5" style="width: 100%; height: 200px;" maxlength="1000" validationgroup="log"></textarea>
                                <%--<asp:RequiredFieldValidator ID="rfvLogDescription" runat="server" ControlToValidate="txt_log_description" 
                                    CssClass="btn-block" ErrorMessage="توضیحات پیگیری الزامی است" ForeColor="Red" ValidationGroup="log" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Button CssClass="btn btn-primary pull-right" ID="btnSubmitLog" runat="server" Text="ثبت" OnClick="btnSubmitLog_Click" ValidationGroup="log" />
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary pull-right" ID="Button1" runat="server" Text="بازگشت به لیست شرکت های من" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </section>
</asp:Content>
