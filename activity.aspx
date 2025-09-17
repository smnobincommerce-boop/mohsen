<%@ Page Title="" Language="C#" MasterPageFile="~/panel/maneger/master_users.Master" AutoEventWireup="true" CodeBehind="activity.aspx.cs" Inherits="WebApplicationImpora2222025.panel.maneger.activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="panel_overview" class="tab-pane fade in active">
        <div role="form">
            <fieldset>
                <legend>آخرین فعالیت های در سامانه 
                </legend>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-white" id="activities" runat="server">
                            <div class="panel-heading border-light">
                                <h4 class="panel-title text-primary">آخرین فعالیت ها</h4>
                                <paneltool class="panel-tools" tool-collapse="tool-collapse" tool-refresh="load1" tool-dismiss="tool-dismiss"></paneltool>
                            </div>
                            <div collapse="activities" ng-init="activities=false" class="panel-wrapper">
                                <div class="panel-body">
                                    <ul class="timeline-xs margin-top-15 margin-bottom-15">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <li class="timeline-item success">
                                                    <div class="margin-right-15">

                                                        <div class="text-muted text-small">

                                                            <asp:Label ID="dateLabel" runat="server" Text='<%# Dateshamsi(Convert.ToDateTime(Eval("date").ToString())) %>'></asp:Label>, &nbsp;<asp:Label ID="timeLabel" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                                                            <%--2 minutes ago--%>
                                                        </div>
                                                        <p>
                                                            <%--<a class="text-info" href>Steven
                                                            </a>
                                                            has completed his account.--%>
                                                            <%# Eval("des_activity") %>
                                                        </p>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--  <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ImporaConnectionString %>' SelectCommand="SELECT * FROM [activity_tbl] WHERE ([id_user] = @id_user) ORDER BY [date] DESC, [time] DESC">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="id_user_panel" PropertyName="Text" Name="id_user" Type="Int32"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:Label ID="id_user_panel" runat="server" Text="" Visible="false"></asp:Label>--%>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>



</asp:Content>
