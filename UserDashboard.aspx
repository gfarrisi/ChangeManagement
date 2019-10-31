<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="Empty_Project_Template.UserDashboard" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">

        <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <div class="container">
            <a class="navbar-brand" href="index.html">CRM Recruit: Change Management</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">

                    <li class="nav-item">
                        <a class="nav-link" href="contact.html">Dashboard</a>
                    </li>

                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlog" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">User One
            </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                            <a class="dropdown-item" href="full-width.html">View All</a>
                            <a class="dropdown-item" href="sidebar.html">Add New Request Type</a>
                            <a class="dropdown-item" href="faq.html">User Settings</a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
     <br />
            <div class="pull-right">
            <div class="btn-group">
                <button class="btn btn-dark" onclick="btnNewRequest_click">
                    New Request 
                </button>
            </div>
        </div>
    <div class="container">
       
       <form id="form1" runat="server">


        <br />

        <div class="row">
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center">Not Assigned</h2>

                    <div class="card-footer">
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 301</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 302</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 303</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 304</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 305</a>
                    </div>
                </div>
            </div>
            


            <!-- /.col-md-4 -->
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center">Assigned</h2>
                    <div class="card-footer">
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 201</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 202</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 203</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 204</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 205</a>
                    </div>
                </div>
            </div>

            <!-- /.col-md-4 -->
           
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center" runat="server">Pre-Production</h2>

                    <div class="card-footer">
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 207</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 208</a>

                    </div>
                    <br />


                </div>
            </div>
            
            <!-- /.col-md-4 -->

            <!-- /.col-md-4 -->
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center" runat="server">Completed</h2>


                    <div class="card-footer">
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 101</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 102</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 103</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 104</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 105</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 106</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 107</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 108</a>
                        <a href="#" class="btn btn-secondary btn-block btn-lg">CM 109</a>

                    </div>
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
        </div>

</asp:Content>
