<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SelectRequestType.aspx.cs" Inherits="Empty_Project_Template.NewRequest2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <form id="form1" runat="server">

        <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">

            <a class="navbar-brand " href="#Home">
                <img src="T.png" alt="" width="40">
            </a>
            <a class="navbar-brand" href="index.html">CRM Recruit: Change Management</a>
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
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlo" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dima Dabbas
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                            <a class="dropdown-item" href="Login.aspx">Log Out</a>
                        </div>
                    </li>
                </ul>
            </div>

        </nav>

    </form>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server" class="body-100">
    <br />
    <br />
    <br />
    <div class="container">

        <div class="row">
            <div class="row">

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">
                        <button id="btnActivityCodes" class="btn btn-dark p-4">Activity Codes</button>
                    </div>

                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnBusinessRules" class="btn btn-dark p-4">Business Rules</button>

                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnEmailTemplates" class="btn btn-dark p-4">Email Templates</button>


                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnEntity" class="btn btn-dark p-4">Entity</button>


                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">
                        <button id="btnField" class="btn btn-dark p-4">Field</button>

                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">


                        <button id="btnForms" class="btn btn-dark p-4">Forms</button>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">
                        <button id="btnJavaScript" class="btn btn-dark p-4">JavaScript on WFE</button>

                    </div>
                </div>


                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnOptionSets" class="btn btn-dark p-4">Option Sets</button>


                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">


                        <button id="btnRelationships" class="btn btn-dark p-4">Relationships</button>

                    </div>
                </div>


                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnSecurityRoles" class="btn btn-dark p-4">Security Roles</button>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnSystemViews" class="btn btn-dark p-4">System Views</button>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnNewUser" class="btn btn-dark p-4">New User/Modify User</button>

                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnWebResources" class="btn btn-dark p-4">Web Resources</button>

                    </div>
                </div>


                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnWorkflow" class="btn btn-dark p-4">Workflow</button>

                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                        <button id="btnWorkflowSchedule" class="btn btn-dark p-4">Workflow Schedule</button>

                    </div>
                </div>




                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn-primary">

                      <button id="btnOther" class="btn btn-dark p-4">Other</button>

                    </div>
                </div>



            </div>


        </div>
        <!-- /.row -->

    </div>
    <!-- /.container -->

</asp:Content>
