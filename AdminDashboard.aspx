<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ChangeManagementSystem.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <a class="navbar-brand " href="AdminDashboard.aspx">
            <img src="T.png" alt="" width="40">
        </a>
        <a class="navbar-brand" href="AdminDashboard.aspx">CRM Recruit: Change Management</a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link" href="AdminDashboard.aspx">Dashboard</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="AdminTools" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Admin Tools
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                        <a class="dropdown-item" href="ViewAllRequests.aspx">View All</a>
                        <a class="dropdown-item" href="NewRequestType.aspx">Add New Request Type</a>
                        <a class="dropdown-item" href="ViewAllUsers.aspx">User Settings</a>
                        <a class="dropdown-item" href="EditEmail.aspx">Edit Emails</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlo" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <asp:Label runat="server" ID="lblUserName" Text="Default"></asp:Label>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                        <a class="dropdown-item" href="Login.aspx">Log Out</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="scriptman" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="pull-right pt-5 pb-4" style="background-color: rgba(0,0,0,.03);">
                    <div class="pl-5 ml-5">
                        <div class="row1">
                            <div class="col-lg-.5 mb-1">
                                <a href="ViewAllRequests.aspx" class="btn btn-dark">View All</a>
                            </div>
                            <div class="col-lg-3 mb-1">
                                <a href="AdminSelectRequestType.aspx" class="btn btn-dark">New Request</a>
                            </div>
                            <div class="col-lg-5 mb-1"></div>
                               <h5><span class="label label-default mb-3 rounded" style="color:white; background-color:#A41E35; padding:12px">*Assigned to me</span></h5>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-cm" style="height: 100%;">
                    <div class="row ">
                        <div class="col-lg-3 mb-1">
                            <h3 class="card-title" align="center">Not Assigned</h3>
                        </div>
                        <div class="col-lg-3 mb-1">
                            <h3 class="card-title" align="center">Assigned</h3>
                        </div>
                        <div class="col-lg-3 mb-1">
                            <h3 class="card-title" align="center" runat="server">Pre-Production </h3>
                        </div>
                        <div class="col-lg-3 mb-1">
                            <h3 class="card-title" align="center" runat="server">Completed<span style="font-size: 15px;"> (Last 30 CMs)</span></h3>
                        </div>
                    </div>

                    <%-- not assigned --%>

                    <div class="row  card-footer" style="height: 40rem; overflow-y: scroll;">
                        <div class="col-lg-3 mb-5">
                            <div class="col-lg-12 mb-5">
                                <div>
                                    <div style="height: 40%; width: 100%;">
                                        <asp:Repeater ID="rptNotAssigned" runat="server" OnItemDataBound="rptNotAssigned_ItemDataBound">
                                            <ItemTemplate>
                                                <button runat="server" id="btnCM" type="button" class="btn btn-secondary btn-block btn-lg cm-tiles" onclick="RecordClickedCM(this)">
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# "CM " + DataBinder.Eval(Container.DataItem, "CMID") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "RequestTypeName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Date of Last Update: " + DataBinder.Eval(Container.DataItem, "LastUpdateDate", "{0:MM/dd/yy}")%>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Last Updated By: " + DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                                    <asp:HiddenField ID="hiddenAdminID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AdminID") %>' />
                                                    <asp:HiddenField ID="hiddenCMID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMID") %>' />
                                                </button>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <%-- assigned --%>

                        <!-- /.col-md-4 -->
                        <div class="col-lg-3 mb-5">
                            <div class="col-lg-12 mb-5">
                                <div style="height: 100%;">
                                    <div style="/*overflow-y: scroll; */ height: 40%; width: 100%">
                                        <asp:Repeater ID="rptAssigned" runat="server" OnItemDataBound="rptAssigned_ItemDataBound">
                                            <ItemTemplate>
                                                <button runat="server" id="btnCM" type="button" class="btn btn-secondary btn-block btn-lg cm-tiles" onclick="RecordClickedCM(this)">
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# "CM " + DataBinder.Eval(Container.DataItem, "CMID") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "RequestTypeName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Date of Last Update: " + DataBinder.Eval(Container.DataItem, "LastUpdateDate", "{0:MM/dd/yy}")%>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Last Updated By: " + DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                                    <asp:HiddenField ID="hiddenAdminID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AdminID") %>' />
                                                    <asp:HiddenField ID="hiddenCMID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMID") %>' />
                                                </button>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <%-- pre-production --%>


                        <!-- /.col-md-4 -->
                        <div class="col-lg-3 mb-5">
                            <div class="col-lg-12 mb-5">
                                <div style="height: 100%;">
                                    <div style="/*overflow-y: scroll; */ height: 40%; width: 100%">
                                        <asp:Repeater ID="rptPreProduction" runat="server" OnItemDataBound="rptPreProduction_ItemDataBound">
                                            <ItemTemplate>
                                                <button runat="server" id="btnCM" type="button" class="btn btn-secondary btn-block btn-lg cm-tiles" onclick="RecordClickedCM(this)">
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# "CM " + DataBinder.Eval(Container.DataItem, "CMID") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "RequestTypeName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Date of Last Update: " + DataBinder.Eval(Container.DataItem, "LastUpdateDate", "{0:MM/dd/yy}")%>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Last Updated By: " + DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                                    <asp:HiddenField ID="hiddenAdminID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AdminID") %>' />
                                                    <asp:HiddenField ID="hiddenCMID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMID") %>' />
                                                </button>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>


                        <%-- completed --%>


                        <!-- /.col-md-4 -->
                        <div class="col-lg-3 mb-5">
                            <div class="col-lg-12 mb-5">
                                <div style="height: 100%;">
                                    <div style="height: 40%; width: 100%">
                                        <asp:Repeater ID="rptCompleted" runat="server" OnItemDataBound="rptCompleted_ItemDataBound">
                                            <ItemTemplate>
                                                <button runat="server" id="btnCM" type="button" class="btn btn-secondary btn-block btn-lg cm-tiles" onclick="RecordClickedCM(this)">
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# "CM " + DataBinder.Eval(Container.DataItem, "CMID") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%# DataBinder.Eval(Container.DataItem, "RequestTypeName") %>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Date of Last Update: " + DataBinder.Eval(Container.DataItem, "LastUpdateDate", "{0:MM/dd/yy}")%>'></asp:Label><br />
                                                    <asp:Label runat="server" Style="font-size: 14px;" Text='<%#"Last Updated By: " + DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                                    <asp:HiddenField ID="hiddenAdminID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AdminID") %>' />
                                                    <asp:HiddenField ID="hiddenCMID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMID") %>' />
                                                </button>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- /.col-md-4 -->
                    </div>
                    <!-- /.row -->
                    <br />
                    <br />
                </div>
            </ContentTemplate>
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RefreshTimer" EventName="Tick" />
            </Triggers> 
        </asp:UpdatePanel>
        <asp:Timer ID="RefreshTimer" runat="server" Interval="30000" OnTick="RefreshTimer_Tick"></asp:Timer>

        <!-- Modal -->
        <div class="modal fade bd-example-modal-lg" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header" align="center">
                        <asp:Repeater ID="rptModalHeader" runat="server">
                            <ItemTemplate>
                                <h5 runat="server" class="modal-title" id="exampleModalLongTitle"><%# "CM: " + DataBinder.Eval(Container.DataItem, "CMID") + " - " + DataBinder.Eval(Container.DataItem, "CMProjectName") %></h5>
                                <asp:HiddenField ID="hiddenTitle" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>' />
                            </ItemTemplate>
                        </asp:Repeater>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="closeModal()">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-1 mb-2"></div>
                            <div class="col-lg-10 mb-2 ">
                                <div class=" h-100">
                                    <div class="card-body">
                                        <asp:Repeater ID="rptCMStatus" runat="server" OnItemDataBound="rptCMStatus_ItemDataBound">
                                            <ItemTemplate>
                                                <h4 runat="server"><%# "Status: " + DataBinder.Eval(Container.DataItem, "CMStatus") %></h4>
                                                <asp:HiddenField ID="hiddenCMStatus" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMStatus") %>' />
                                                <asp:HiddenField ID="selectedCMUserID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' />
                                                <div class="progress">
                                                    <div runat="server" id="progressBar" class="progress-bar bg-success" role="progressbar"></div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3 mb-2"></div>
                                            <div class="col-lg-6">
                                                <div class="status-check">
                                                    <div id="status" runat="server">
                                                        <div id="preprodTested" runat="server">
                                                            <asp:Label ID="lblAwaitingAdmin" runat="server" CssClass="font-weight-bold">Awaiting Move to Production</asp:Label>
                                                        </div>
                                                        <div id="preprod" runat="server">
                                                            <asp:Label ID="lblPreProdTesting" runat="server" CssClass="font-weight-bold">User Testing Required in Pre-Prod</asp:Label><br />
                                                            <br />
                                                            <asp:CheckBox class="checkbox" ID="chkPreProd" runat="server"></asp:CheckBox>
                                                            <asp:Label ID="lblTestingConfirmed" runat="server">I have tested and approved pre-prod changes. Move to production</asp:Label><br />
                                                            <br />
                                                            <asp:Button ID="btnSubmitTesting" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmitTesting_Click" />
                                                        </div>
                                                    </div>
                                                    <div id="statusChangeControls" runat="server">
                                                        <asp:Label ID="lblCMStatus" runat="server" CssClass="font-weight-bold">Update Status</asp:Label>
                                                        <asp:DropDownList class="browser-default custom-select" ID="ddlCMStatus" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-12 form-data">
                                <asp:Repeater ID="rptRequestInfo" runat="server">
                                    <ItemTemplate>
                                        <div class="row" runat="server">
                                            <h4 runat="server"><%# "Request Type: " + DataBinder.Eval(Container.DataItem, "RequestTypeName") %></h4>
                                            <br />
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Name:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")  %></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Email address:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "Email")%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>College:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "College")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rptAdminName" runat="server">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Assigned To:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")  %></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Workflow/Process Name:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "CMProjectName")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rptResponse" runat="server">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b><%# DataBinder.Eval(Container.DataItem, "QuestionText")%></b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "QuestionResponse")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <br />
                                <div class="row">
                                    <h4>Screenshots & Submission</h4>
                                    <br />
                                </div>
                                <br />
                                <asp:Repeater ID="rptScreenshots" runat="server" OnItemDataBound="rptScreenshots_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Detailed Description of Change</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "DetailDescription")%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:LinkButton runat="server" ID="btnLink1" OnClientClick="DownloadAttachment()" OnClick="btnLink1_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment1Name") %></asp:LinkButton>  
                                                <br />
                                                <asp:LinkButton runat="server" Visible="false" ID="btnLink2" OnClientClick="DownloadAttachment()" OnClick="btnLink2_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment2Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" Visible="false" ID="btnLink3" OnClientClick="DownloadAttachment()" OnClick="btnLink3_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment3Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" Visible="false" ID="btnLink4" OnClientClick="DownloadAttachment()" OnClick="btnLink4_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment4Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" Visible="false" ID="btnLink5" OnClientClick="DownloadAttachment()" OnClick="btnLink5_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment5Name") %></asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Desired Date for Move</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "DesiredDate")%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Questions/Comments</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "Question/Comments")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="row">
                                    <div class="col-lg-9">
                                    </div>
                                    <div class="col-lg-3">
                                        <br />
                                    </div>
                                </div>
                                <hr />
                            </div>
                        </div>
                        <div class="row mb-7">
                            <div class="col-lg-1 mb-7"></div>
                            <div class="col-lg-11 mb-7" style="height: 50%; padding-left: 0;">
                                <h4 class="mb-3 ml-1 mt-3">Comments</h4>
                                <div class="card ">
                                    <div class="card-body" style="height: 20rem; overflow-y: scroll;">
                                        <asp:Panel ID="pnlNoComments" runat="server">
                                            <p class="pt-3 pb-5">
                                                There are no existing comments
                                            </p>
                                        </asp:Panel>
                                        <%--<asp:Panel ID="pnlComments" runat="server">--%>
                                        <asp:UpdatePanel ID="pnlComments" style="width: 100%" runat="server">
                                            <ContentTemplate>
                                                <%--<asp:Timer ID="tmComments" OnTick="tmComments_Tick" runat="server" Interval="3000" />--%>
                                                <asp:Repeater ID="rptComments" runat="server">
                                                    <ItemTemplate>
                                                        <p class="card-text">
                                                            <asp:Label ID="lbCommentName" CssClass="" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserType") + ": " + DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:Label>
                                                            <br />
                                                            <span class="comment-time">
                                                                <asp:Label ID="lbCommentTime" runat="server" Font-Italic="true" CssClass="" Text='<%# DataBinder.Eval(Container.DataItem, "LastUpdateDate") %>'></asp:Label>
                                                            </span>
                                                            <br />
                                                            <span class="comment-text">
                                                                <asp:Label ID="lbCommentText" runat="server" Font-Italic="true" CssClass="" Text='<%# DataBinder.Eval(Container.DataItem, "CommentText") %>'></asp:Label>
                                                            </span>
                                                        </p>
                                                        <hr />
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rptComments" EventName="ItemDataBound" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <%--</asp:Panel>--%>
                                    </div>
                                    <div class="card-footer">
                                        <div class="control-group form-group">
                                            <div class="controls">
                                                <asp:TextBox ID="txtNewComment" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                <%--<textarea rows="1" cols="100" class="form-control" id="message" data-validation-required-message="Please enter your message" maxlength="99"></textarea>--%>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnNewComment" Text="Comment" runat="server" CssClass="btn btn-secondary" OnClick="btnNewComment_Click" />
                                        <%--<a href="#" class="btn btn-secondary" align="center">Comment</a>--%>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer mt-5">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnClose" onclick="closeModal()">Close</button>
                        <asp:Button runat="server" ID="btnDownloadAsPDF" CssClass="btn btn-secondary" style="background-color:#8C2132" Text="Download As PDF" CausesValidation="false" OnClick="btnDownloadAsPDF_Click" />
                        <asp:Button runat="server" class="btn btn-primary" ID="btnSave" Text="Save changes" OnClientClick="return cmSaved()" OnClick="btnSave_Click"></asp:Button>
                    </div>
                </div>

            </div>
        </div>
        <div class="modal fade" id="mdlSavedChanges" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Changes Saved</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        CM #302 has been marked as failed. User notified.
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div hidden>
            <asp:Button ClientIDMode="Static" ID="btnCMClicked" runat="server" OnClick="btnCMClicked_Click" />
        </div>
        <asp:HiddenField ClientIDMode="Static" ID="hiddenCMClicked" runat="server" />
        <asp:HiddenField ClientIDMode="Static" ID="isModalOpen" runat="server" />
        <asp:HiddenField ClientIDMode="Static" ID="downloadFile" runat="server" />
        <asp:HiddenField ClientIDMode="Static" ID="hiddenCMSaving" runat="server" />
  
        <!-- Modal data-toggle="modal" data-target="#warningModal"-->
        <div class="modal fade"data-toggle="modal" id="mdlCMAttachment" tabindex="-1" role="dialog" aria-labelledby="mdlCMAttachmentLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="mdlCMAttachmentLabel">Attachment Download</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <label id="Label1" style="line-height: 50px;" runat="server">The attachment has been downloaded!</label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button1" CssClass="btn btn-secondary" BorderStyle="None" OnClick="Button1_Click" Text="Close" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">

        function RecordClickedCM(button) {
            var CMID = null;
            if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
                CMID = (button.innerText.split('\r\n', 1)[0]).substring(3);
            }
            else if (navigator.userAgent.indexOf("Chrome") != -1) {
                CMID = (button.innerText.split('\n', 1)[0]).substring(3);             
            }
            else if (navigator.userAgent.indexOf("Safari") != -1) {
                CMID = (button.innerText.split('\n', 1)[0]).substring(3);    
            }
            else if (navigator.userAgent.indexOf("Firefox") != -1) {
                CMID = (button.innerText.split('\n', 1)[0]).substring(3);    
            }
            else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
            {
                CMID = (button.innerText.split('\r\n', 1)[0]).substring(3);             
            }
            else {

            }
            document.getElementById("hiddenCMClicked").value = CMID;
            document.getElementById("isModalOpen").value = "true";
            document.getElementById("btnCMClicked").click();
        }

        function DownloadAttachment() {
            document.getElementById("downloadFile").value = "true";
        }

        $(document).ready(function () {
            $(".dropdown-toggle").dropdown();
        });

        function closeModal() {
            document.getElementById("isModalOpen").value = "false";
        }

        function cmSaved() {
            document.getElementById("hiddenCMSaving").value = "true";
            return true;
        }
        
    </script>
</asp:Content>

