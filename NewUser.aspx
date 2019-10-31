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
                        <a class="nav-link" href="contact.html">Dashboard</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="AdminTools" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Admin Tools
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                            <a class="dropdown-item" href="full-width.html">View All</a>
                            <a class="dropdown-item" href="sidebar.html">Add New Request Type</a>
                            <a class="dropdown-item" href="faq.html">User Settings</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlo" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dima Dabbas
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">

                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <h1 class="text-center">User Settings</h1>
        <div style="margin: 0 auto; max-width: 300px; padding: 30px;">
        <br />
        <div class="form-group">
            <asp:label id="lbl1" runat="server">Name</asp:label>
            <input class="form-text" id="txtField1" type="text" runat="server" />
            <br />
            <asp:label id="lbl2" runat="server">Email</asp:label>
            <input class="form-text" id="txtField2" type="text" runat="server"/>
            <br />
            <asp:label id="lbl3" runat="server">TUID</asp:label>
            <input class="form-text" id="txtField3" type="text" runat="server"/>
            <br />
            <asp:label id="lbl4" runat="server">College</asp:label>
            <input class="form-text" id="txtField4" type="text" runat="server" />
            
        </div>
        <br />
        <asp:Button CssClass="rounded-pill" Width="90px" BorderStyle="None" ID="btnSubmit" Text="Add User" BackColor="#9D2235" ForeColor="#ffffff" OnClick="btnSubmit_Click" runat="server" />
        
    </div>
    </form>
</asp:Content>
