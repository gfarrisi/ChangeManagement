<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewRequest2.aspx.cs" Inherits="Empty_Project_Template.NewRequest2" %>

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
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Activity Codes</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Business Rules</a>
                        </h5>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Email Templates</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Entity</a>
                        </h5>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Field</a>
                        </h5>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Forms</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">JavaScript on WFE</a>
                        </h5>
                    </div>
                </div>


                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Option Sets</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Relationships</a>
                        </h5>
                    </div>
                </div>


                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Security Roles</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">System Views</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">New User/Modify User</a>
                        </h5>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Web Resources</a>
                        </h5>
                    </div>
                </div>


                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Workflow</a>
                        </h5>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Workflow Schedule</a>
                        </h5>
                    </div>
                </div>




                <div class="col-lg-3 col-md-6 mb-5">
                    <div class="card btn btn-primary cardCM">

                        <h5>
                            <a href="#" style="color: white">Other</a>
                        </h5>
                    </div>
                </div>



            </div>


        </div>
        <!-- /.row -->

    </div>
    <!-- /.container -->

</asp:Content>
