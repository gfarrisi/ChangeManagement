<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Empty_Project_Template.NewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <div class="container">
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
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <h1 class="text-center">New User</h1>
        <div style="margin: 0 auto; max-width: 300px; padding: 30px;">
        <br />
        <div class="form-group form-row">
            <div class="col-lg-3">
                <label id="lblName" style="line-height: 50px;" runat="server">Name</label>
                <br />
                <label id="lblEmail" style="line-height: 50px;" runat="server">Email</label>
                <br />
                <label id="lblTUID" style="line-height: 50px;" runat="server">TUID</label>
                <br />
                <label id="lblCollege" style="line-height: 50px;" runat="server">College</label>
            </div>
            <div class="col-lg-9">
                <input class="form-control" id="txtName" type="text" runat="server" />
                <br />
            
                <input class="form-control" id="txtEmail" type="text" runat="server"/>
                <br />
            
                <input class="form-control" id="txtTUID" type="text" runat="server"/>
                <br />
            
                <input class="form-control" id="txtCollege" type="text" runat="server" />
            </div>
            
            
            
        </div>
        <br />
            <div align="center">
        <asp:Button CssClass="btn btn-primary" Width="90px" BorderStyle="None" ID="btnSubmit" Text="Add User" BackColor="#9D2235" ForeColor="#ffffff" OnClick="btnSubmit_Click" runat="server" />

            </div>
         <br />
        <br />
        <br />
        <br />
        <br />
             <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</asp:Content>
