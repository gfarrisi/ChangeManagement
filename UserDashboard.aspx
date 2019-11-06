<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="Empty_Project_Template.UserDashboard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
    
        <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <div class="container">
            <a class="navbar-brand" href="index.html">CRM Recruit: Change Management</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">

                    <li class="nav-item">
                        <a class="nav-link" href="UserDashboard.aspx">Dashboard</a>
                    </li>

                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="CM.aspx" id="navbarDropdownBlog" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Jane Doe
            </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                            <a class="dropdown-item" href="Login.aspx">Logout</a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
     <form runat="server">
    <br />
            <div class="pull-right">
            <div class="btn-group" style="padding-left:5%;">
                <asp:Button ID="btnNewRequest" runat="server" Text="New Request" CssClass="btn btn-dark" OnClick="btnNewRequest_Click" />
                
            </div>
        </div>
    <div class="container">
       
        <br />

        <div class="row">
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center">Not Assigned</h2>

                    <div class="card-footer" style="overflow-y:scroll;">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 301<br /><span style="font-size: 14px;">Workflow for CLA</span><br /><span style="font-size: 14px;">Submitted: 11/5/2019</span> </a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 302</a>
                    </div>
                </div>
            </div>
            


            <!-- /.col-md-4 -->
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center">Assigned</h2>
                    <div class="card-footer" style="overflow-y:scroll;">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 201</a>
                    </div>
                </div>
            </div>

            <!-- /.col-md-4 -->
           
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center" runat="server">Pre-Production</h2>

                    <div class="card-footer" style="overflow-y:scroll;">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 207</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 208</a>

                    </div>
                    <br />


                </div>
            </div>
            
            <!-- /.col-md-4 -->

            <!-- /.col-md-4 -->
            <div class="col-lg-3 mb-5">
                <div>
                    <h2 class="card-title" align="center" runat="server">Completed</h2>


                    <div class="card-footer" style="overflow-y:scroll;">
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 101</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 102</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 103</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 104</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 105</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 106</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 107</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 108</a>
                        <a href="CM.aspx" class="btn btn-secondary btn-block btn-lg">CM 109</a>

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
