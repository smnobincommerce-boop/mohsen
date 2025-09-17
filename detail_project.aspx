<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="detail_project.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.detail_project" %>

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
            directionality: 'rtl', // تنظیم راست‌به‌چپ
            toolbar: 'ltr rtl', // دکمه‌های تغییر جهت در تولبار
            plugins: 'advlist autolink link image lists charmap print preview',
            paste_auto_cleanup_on_paste: true,
            paste_postprocess: function (pl, o) {
                o.node.innerHTML = o.node.innerHTML.replace(/&nbsp;/ig, " ");
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="alert alert-success text-center" dir="rtl" id="contactSuccess2" runat="server" style="display: none">
        <input id="Label12" runat="server" type="text" style="color: #33CC33; font-size: large" />
       
    </div>
    <div class="alert alert-warning text-center" dir="rtl" id="contactError2" runat="server" style="display: none">
         <input id="Label22" runat="server" type="text" style="color: #CC0000; font-size: large" />
       

    </div>
    <section class="container-fluid container-fullw bg-white">

        <div class="panel-success padding-20">
            <div class="">
                <div>

                    <div class="inline-block">
                        <i class="fa fa-newspaper-o"></i><span id="txt_subject_" runat="server" class="block week-day text-extra-large">Wensdey</span><br />

                        <i class="fa fa-calendar"></i><span id="txt_date_want_contact" runat="server" class="block week-day text-extra-large">Wensdey</span><br />

                         <i class="fa  fa-phone"></i><span id="txt_phone_want_contact" runat="server" class="block week-day text-extra-large">Wensdey</span><br />

                        

                         <i class="fa fa-user"></i><span id="txt_name_engineer" runat="server" class="block week-day text-extra-large">Wensdey</span><br />
                    </div>
                </div>
            </div>
            <div class="timeline_content" id="txt_description" runat="server" visible="false">
            </div>
            <div class="readmore">
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <a href="#new_ticket" class="btn btn-dark-yellow">پاسخ<i class="fa fa-pencil"></i>
                        </a>
                    </div>
                    <div class="col-md-6">
                        <br />
                        <span id="txt_date_" runat="server" class="block month text-large text-light">november 2014</span>

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

                                <asp:ListView ID="ListView_message_project" runat="server">

                                    <EmptyDataTemplate>
                                        <td dir="rtl">هیچ اطلاعاتی وجود ندارد.
                                        </td>
                                    </EmptyDataTemplate>

                                    <ItemSeparatorTemplate>
                                        <br />
                                    </ItemSeparatorTemplate>
                                    <ItemTemplate>

                                        <a href="#" class="pull-right">

                                            <img id="img_user_project" runat="server" src='<%# Eval("Pic") %>' alt="" class="media-object img-circle padding-15 " style="width: 80px; height: 100%">
                                        </a>
                                        <div class="media-body">
                                            <h5 class="media-heading" id="name_user_project" runat="server"><%# Eval("Name") %> </h5>
                                            <h5 class="media-heading" visible='<%# Eval("Role_visible") %>' id="role_user_project" runat="server" style="color: #0000FF"><%# Eval("Role") %> </h5>

                                            <p id="txt_message_" runat="server">
                                                <%# Eval("message") %>
                                            </p>
                                            <span class="reply"><span><a target="_blank" visible='<%# Eval("address_file_visible") %>' id="txt_file_address" runat="server" href='<%# Eval("address_file") %>'><i class="fa fa-download"></i>دانلود فایل</a></span> </span>
                                            <span id="txt_date_and_time" runat="server" class="date" style="font-size: small"><%# Eval("date_create") %> در ساعت <%# Eval("time_create") %></span>
                                            <hr>
                                        </div>

                                        <%--
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Name" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Pic" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Role" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "Role_visible" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "des_service" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "subject" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "datechoosecontact" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "message" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "time_create" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "date_create" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "address_file" });
            MyDataTable.Columns.Add(new DataColumn() { DataType = System.Type.GetType("System.String"), ColumnName = "address_file_visible" });
                                        --%>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <div runat="server" id="itemPlaceholderContainer" style="">
                                            <div runat="server" id="itemPlaceholder" />
                                        </div>
                                        <div style="">
                                        </div>
                                    </LayoutTemplate>
                                    <SelectedItemTemplate>

                                        <li style="">
                                            <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /><br />

                                            <asp:Label Text='<%# Eval("Pic") %>' runat="server" ID="PicLabel" /><br />

                                            <asp:Label Text='<%# Eval("Role") %>' runat="server" ID="RoleLabel" /><br />

                                            <asp:Label Text='<%# Eval("Role_visible") %>' runat="server" ID="Role_visibleLabel" /><br />

                                            <asp:Label Text='<%# Eval("des_service") %>' runat="server" ID="des_serviceLabel" /><br />

                                            <asp:Label Text='<%# Eval("subject") %>' runat="server" ID="subjectLabel" /><br />

                                            <asp:Label Text='<%# Eval("datechoosecontact") %>' runat="server" ID="datechoosecontactLabel" /><br />

                                            <asp:Label Text='<%# Eval("message") %>' runat="server" ID="messageLabel" /><br />

                                            <asp:Label Text='<%# Eval("time_create") %>' runat="server" ID="time_createLabel" /><br />

                                            <asp:Label Text='<%# Eval("date_create") %>' runat="server" ID="date_createLabel" /><br />

                                            <asp:Label Text='<%# Eval("address_file_visible") %>' runat="server" ID="address_file_visibleLabel" /><br />

                                            <asp:Label Text='<%# Eval("address_file") %>' runat="server" ID="address_fileLabel" /><br />

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
        <div id="new_ticket">
            <div role="form">
                <fieldset>
                    <legend>ارسال پیام 
                    </legend>
                    <div class="row">
                        <div class="col-md-12">

                            <div class="form-group">
                                <label class="control-label">
                                    پاسخ
                                </label>
                                <textarea id="txt_message_ticket" runat="server" class="form-control" cols="20" rows="5" style="width: 100%; height: 200px;" maxlength="1000"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_message_ticket" CssClass="btn-block" ErrorMessage="متن مورد نياز است" ForeColor="Red" ToolTip="متن مورد نياز است" ValidationGroup="ticket"></asp:RequiredFieldValidator>
                            </div>




                            <div class="form-group">
                                <label>
                                    بارگذاری فایل
                                </label>
                                <div class="fileinput fileinput-new" data-provides="fileinput">
                                    <div class="fileinput-new thumbnail">

                                        <asp:FileUpload CssClass=" width-200" ID="file_upload_project" runat="server" />
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-12">

                            <asp:Button CssClass="btn btn-primary pull-right" ID="Button_send" runat="server" Text="ارسال" OnClick="Button_send_Click"></asp:Button>

                        </div>
                    </div>
                </fieldset>


            </div>
        </div>

    </section>

</asp:Content>
