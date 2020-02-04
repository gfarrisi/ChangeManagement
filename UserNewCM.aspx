<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserNewCM.aspx.cs" Inherits="ChangeManagementSystem.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <a class="navbar-brand " href="UserDashboard.aspx">
            <img src="T.png" alt="" width="40">
        </a>
        <a class="navbar-brand" href="UserDashboard.aspx">CRM Recruit: Change Management</a>
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
    </nav>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <div class="pull-right pt-5 pb-1">
            <div class="pl-5 ml-5">
                <div class="row">
                    <div class="col-lg-4 mb-1">
                        <a href="UserSelectRequestType.aspx" class="btn btn-dark">Back to Request Types</a>
                    </div>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3"></div>
            <div class="col-6 pt-5 pb-5" style="background-color: rgba(0,0,0,.03); box-shadow: 0 0 12px 1.5px #808080;">
                <h1 class="text-center mb-5">CRM Change Management</h1>
                <div style="margin: 0 auto; max-width: 600px;">
                    <asp:Panel ID="panelCM" runat="server">
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-5 ml-5"></div>
            <div class="col-3 pt-5 pr-5">
                <div>
                    <asp:Button CssClass="btn btn-primary btn-lg" BorderStyle="None" ID="btnSubmitUser" Text="Submit Request" BackColor="#9D2235" ForeColor="#ffffff" runat="server" OnClick="btnSubmitUser_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
