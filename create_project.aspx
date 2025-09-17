<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="create_project.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.create_project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="new_projects" class="tab-pane fade in active">
        <div role="form">
            <fieldset>
                <legend>ایجاد قرارداد 
                </legend>
                <div class="row" id="panel1" runat="server">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">
                                موضوع قرارداد
                            </label>
                            <input type="text" placeholder="موضوع" class="form-control" runat="server" id="txt_project_subject" name="firstname" maxlength="50">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_project_subject" CssClass="btn-block" ErrorMessage="موضوع پروژه مورد نياز است" ForeColor="Red" ToolTip="موضوع پروژه مورد نياز است" ValidationGroup="project_valid"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                شرح قرارداد
                            </label>
                            <textarea id="txt_project_message" runat="server" class="form-control" cols="20" rows="5" style="width: 100%; height: 200px;" maxlength="1000"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_project_message" CssClass="btn-block" ErrorMessage=" شرح پروژه مورد نياز است" ForeColor="Red" ToolTip=" شرح پروژه مورد نياز است" ValidationGroup="project_valid"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">
                                گروه مرتبط با پروژه
                            </label>
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server">


                                <asp:ListItem Value="0">بازرگانی خارجی</asp:ListItem>
                                <asp:ListItem Value="1">تجارت خارجی</asp:ListItem>
                                
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadioButtonList2" CssClass="btn-block" ErrorMessage=" گروه پروژه مورد نياز است" ForeColor="Red" ToolTip=" گروه پروژه مورد نياز است" ValidationGroup="project_valid2"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label>
                                انتخاب کاربر/ مشتری
                            </label>
                            <div>

                                <asp:Button ID="choose_engineer" runat="server" Text="انتخاب مهندسین" OnClick="choose_engineer_Click" ValidationGroup="project_valid2" />
                            </div>

                        </div>
                        <div class="form-group">
                            <label>
                                بارگذاری فایل
                            </label>
                            <div class="fileinput fileinput-new" data-provides="fileinput">
                                <div class="fileinput-new thumbnail">

                                    <asp:FileUpload CssClass=" width-200" ID="File_project" runat="server" />
                                </div>


                            </div>
                        </div>

                    </div>
                </div>
                <div class="row" id="panel2" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label padding-15">
                                مشتریان مورد نظر خود را انتخاب نمایید
                            </label>
                            <br />

                            <div class="col-md-3" id="div1" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong1" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-3" id="div2" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong2" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div3" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong3" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div4" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong4" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox4" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div5" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong5" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox5" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div6" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong6" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox6" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div7" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong7" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label7" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox7" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div8" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong8" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label8" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox8" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div9" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong9" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label9" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox9" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div10" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong10" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label10" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox10" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div11" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong11" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label11" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox11" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div12" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong12" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label12" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox12" runat="server" />
                                </div>
                            </div>
                            
                             <div class="col-md-3" id="div13" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong13" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label13" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox13" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div14" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong14" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label14" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox14" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div15" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong15" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label15" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox15" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div16" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong16" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label16" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox16" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div17" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong17" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label17" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox17" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div18" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong18" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label18" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox18" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div19" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong19" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label19" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox19" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div20" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong20" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label20" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox20" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div21" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong21" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label21" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox21" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div22" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong22" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label22" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox22" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div23" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong23" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label23" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox23" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div24" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong24" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label24" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox24" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div25" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong25" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label25" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox25" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div26" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong26" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label26" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox26" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div27" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong27" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label27" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox27" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div28" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong28" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label28" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox28" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div29" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong29" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label29" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox29" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div30" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong30" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label30" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox30" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div31" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong31" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label31" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox31" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div32" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong32" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label32" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox32" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div33" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong33" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label33" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox33" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div34" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong34" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label34" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox34" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div35" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong35" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label35" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox35" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div36" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong36" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label36" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox36" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div37" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong37" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label37" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox37" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div38" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong38" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label38" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox38" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div39" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong39" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label39" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox39" runat="server" />
                                </div>
                            </div>
                             <div class="col-md-3" id="div40" runat="server" visible="false">
                                <div role="alert" class="alert alert-success">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <strong id="Strong40" runat="server">محمد احمدی</strong>&nbsp;&nbsp;
                                <asp:Label ID="Label40" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:CheckBox ID="CheckBox40" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 padding-15">

                        <asp:Button CssClass="btn btn-primary pull-left" ID="save_engineer" runat="server" Text="ثبت مهندسین" OnClick="save_engineer_Click"></asp:Button>

                    </div>

                </div>
                <div class="row" id="panel3" runat="server">
                    <div class="col-md-8">
                        <p>
                            پروژه های های شما ارسالی در اسرع وقت توسط کارشناسان نوبین بررسی و پاسخ داده خواهند شد.
                        </p>
                    </div>
                    <div class="col-md-4">

                        <asp:Button CssClass="btn btn-primary pull-right" ID="Button_project" runat="server" Text="ثبت پروژه" OnClick="Button_project_Click" ValidationGroup="project_valid"></asp:Button>

                    </div>
                </div>
            </fieldset>


        </div>
    </div>


</asp:Content>
