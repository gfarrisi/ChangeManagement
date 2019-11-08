<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Empty_Project_Template.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
     
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

</asp:Content>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">
   
        <br />
        <form runat="server">
    
           <div class="pull-right">
            <div class="btn-group" style="padding-left:5%;">
                <asp:Button ID="btnNewRequest" runat="server" Text="New Request" CssClass="btn btn-dark" OnClick="btnNewRequest_Click" />
                
            </div>
        </div>
             <div class="container" style="height:100%;">
    <div class="container">
       
        <br />

        <div class="row">
            <div class="col-lg-3 mb-5">
                <div style="height: 100%;">
                    <h2 class="card-title" align="center">Not Assigned</h2>

                    <div class="" style="overflow-y:scroll; height:40%; width:100%">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 301<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 302<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 301<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 309<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>

                    </div>
                </div>
            </div>
            


            <!-- /.col-md-4 -->
            <div class="col-lg-3 mb-5">
                <div style="height: 100%;">
                    <h2 class="card-title" align="center">Assigned</h2>
                    <div class=""  style="/*overflow-y:scroll;*/ height:40%; width:100%">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 201<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>

                    </div>
                </div>
            </div>

            <!-- /.col-md-4 -->
           
            <div class="col-lg-3 mb-5">
                <div  style="height: 100%;">
                    <h2 class="card-title" align="center" runat="server">Pre-Production</h2>

                    <div class="" style="/*overflow-y:scroll;*/ height:40%; width:100%">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 207<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 208<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>


                    </div>
                    <br />


                </div>
            </div>
            
            <!-- /.col-md-4 -->

            <!-- /.col-md-4 -->
            <div class="col-lg-3 mb-5" >
                <div style="height: 100%;">
                    <h2 class="card-title" align="center" runat="server">Completed</h2>


                    <div class="" style="overflow-y:scroll; height:40%; width:100%">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 101<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 102<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 103<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 208<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 105<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 208<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 107<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 109<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Completed: 11/5/2019</span> </a>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="viewall">
                        <a href="url" runat="server">View All</a>
                    </div>


                </div>
            </div>
            <!-- /.col-md-4 -->

        </div>
        <!-- /.row -->

        <br />
        <br />
        <br />
        <br />



    </form>

</asp:Content>
