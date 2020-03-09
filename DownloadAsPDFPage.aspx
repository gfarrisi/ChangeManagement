﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DownloadAsPDFPage.aspx.cs" Inherits="ChangeManagementSystem.DownloadAsPDFPage" %>
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
        <div id="exampleModalLong" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header" align="center">
                        <asp:Repeater ID="rptModalHeader" runat="server">
                            <ItemTemplate>
                                <h5 runat="server" class="modal-title" id="exampleModalLongTitle"><%# "CM: " + DataBinder.Eval(Container.DataItem, "CMID") + " - " + DataBinder.Eval(Container.DataItem, "CMProjectName") %></h5>
                                <asp:HiddenField ID="hiddenTitle" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>'/>
                            </ItemTemplate>
                        </asp:Repeater>
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
                                                    <asp:Label ID="lblCMStatus" runat="server" CssClass="font-weight-bold">Update Status</asp:Label>
                                                    <asp:DropDownList class="browser-default custom-select" ID="ddlCMStatus" runat="server"></asp:DropDownList>
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
                                            <h4 runat="server"><%# "Request Type: " + DataBinder.Eval(Container.DataItem, "RequestTypeID") %></h4>
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
                                <asp:Repeater ID="rptScreenshots" runat="server">
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
                                                <p>
                                                    <a href="">File 1https://drive.google.com/open?id=1gomIbt8yJA2pn0xY06-
                                                    PxS5AZFHYmP2k
                                                    File 2https://drive.google.com/open?id=1hV2JPhOHB47aEy7clxsPuWOiDbad0Ze
                                                    File 3https://drive.google.com/open?id=1L--
                                                    Dnd6dLVQGhCP3hbkZ5Rs-z0iwJUwm
                                                    File 4https://drive.google.com/open?
                                                    id=16nZJaBWjqmG5642crodKkUYnHYhfJE2U
                                                    </a>
                                                </p>
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
                                                        <%--<asp:Label ID="Label6" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Info"></asp:Label>--%>
                                                        <%--<asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />--%>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>