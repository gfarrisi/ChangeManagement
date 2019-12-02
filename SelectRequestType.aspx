<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SelectRequestType.aspx.cs" Inherits="Empty_Project_Template.NewRequest2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

   

        <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">

            <a class="navbar-brand " href="javascript:history.back()">
                <img src="T.png" alt="" width="40">
            </a>
            <a class="navbar-brand" href="javascript:history.back()">CRM Recruit: Change Management</a>
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
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server" class="body-100">
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">

        <div class="row">
            <div class="row">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>

                        <div class="col-lg-3 col-md-6 mb-5">
                            <div class="card btn-secondary">
                                 <asp:HiddenField runat="server" ID="hfSelectRequestType" Value='<%# DataBinder.Eval(Container.DataItem, "RequestID") %>' />
                                <asp:Button ID="btnRequestType" OnClick="btnRequestType_Click" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' CssClass="btn btn-dark p-5"/>
                            </div>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>


            </div>


        </div>
        <!-- /.row -->

    </div>
    <!-- /.container -->
    </form>
</asp:Content>
