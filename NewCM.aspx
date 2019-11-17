<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewCM.aspx.cs" Inherits="Empty_Project_Template.NewCM" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">  
         <br />
         <br />
        <h1 class="text-center">CRM Change Management</h1>
        <div style="margin: 0 auto; max-width: 400px; padding: 30px;">                                                
            <asp:Panel ID="panelCM" runat="server">
            </asp:Panel>
            <br />
            <asp:Button  CssClass="btn btn-primary" Width="140px" BorderStyle="None" ID="btnSubmit" Text="Submit Request" BackColor="#9D2235" ForeColor="#ffffff" OnClick="btnSubmit_Click" runat="server" />      
        
        </div>
        
        <br />
        <br />
        <br />
    </form>
    
    
    
</asp:Content>
