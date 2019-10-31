<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllRequests.aspx.cs" Inherits="Empty_Project_Template.ViewAllRequests" %>
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
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <br />
    <br />
      <br />
      <br />
      <br />
    <div class="container">
    <h2 id="requestHistory">Request History</h2>
    <div class="card mb-4 w-50" id="searchBar">
        <div class="input-group">
            <input type="text" class="form-control" placeholder="Search for...">
            <span class="input-group-btn">
                <button class="btn btn-dark" type="button">Search</button>
            </span>
        </div>
    </div>
    <table class="table table-bordered table-striped table-hover">
        <thead class="thead-dark">
            <tr>
                <th scope="col">CM ID  <i class="fas fa-sort"></i></th>
                <th scope="col">User  <i class="fas fa-sort"></i></th>
                <th scope="col">Admin  <i class="fas fa-sort"></i></th>
                <th scope="col">College  <i class="fas fa-sort"></i></th>
                <th scope="col">Type  <i class="fas fa-sort"></i></th>
                <th scope="col">Status  <i class="fas fa-sort"></i></th>
                <th scope="col">Last Updated Date  <i class="fa fa-sort"></i></th>
                <th scope="col">View Request</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">CM101</th>
                <td>Sandy James</td>
                <td>Kristi Morgridge</td>
                <td>Boyer</td>
                <td>Entity</td>
                <td>Not Assigned</td>
                <td>10/08/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM102</th>
                <td>Sam Kelly</td>
                <td>Dima Dabbas</td>
                <td>Global</td>
                <td>Forms</td>
                <td>Preprod</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM103</th>
                <td>Lauren O'Neil</td>
                <td>Dima Dabbas</td>
                <td>Tyler</td>
                <td>Field</td>
                <td>Complete</td>
                <td>9/28/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM104</th>
                <td>Jaime Martino</td>
                <td>Kristi Morgridge</td>
                <td>UG</td>
                <td>Activity Codes</td>
                <td>Assigned</td>
                <td>9/22/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM105</th>
                <td>Helene Houser</td>
                <td>Kristi Morgridge</td>
                <td>CRM</td>
                <td>Workflow</td>
                <td>Complete</td>
                <td>8/18/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM106</th>
                <td>Megan Nyquist</td>
                <td>Dima Dabbas</td>
                <td>CST</td>
                <td>System Views</td>
                <td>Failed</td>
                <td>8/8/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
        </tbody>
    </table>
    <button type="button" class="btn btnDownload">Download All</button>
        </div>
      <br />
      <br />
      <br />  <br />  <br />
</asp:Content>
