<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserRequests.aspx.cs" Inherits="Empty_Project_Template.WebForm2" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <br />
    <br />
    <div class="container" style="height: 100%;">
        <h2 id="requestHistory">Your Request History</h2>
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
                    <th scope="row">CM1900</th>
                    <td>Jane Doe</td>
                    <td>Kristi Morgridge</td>
                    <td>CLA</td>
                    <td>Systems View</td>
                    <td>Complete</td>
                    <td>8/18/19</td>
                    <td class="viewRequest"><a href="CM.aspx"><i class='far fa-eye'></i></a></td>
                </tr>
                <tr>
                    <th scope="row">CM1905</th>
                    <td>Jane Doe</td>
                    <td>Dima Dabbas</td>
                    <td>CLA</td>
                    <td>Work Flow</td>
                    <td>Preprod</td>
                    <td>9/4/19</td>
                    <td class="viewRequest"><a href="CM.aspx"><i class='far fa-eye'></i></a></td>
                </tr>
                <tr>
                    <th scope="row">CM1906</th>
                    <td>Jane Doe</td>
                    <td>Kristi Morgridge</td>
                    <td>CLA</td>
                    <td>Activity Codes</td>
                    <td>Assigned</td>
                    <td>9/22/19</td>
                    <td class="viewRequest"><a href="CM.aspx"><i class='far fa-eye'></i></a></td>
                </tr>
                <tr>
                    <th scope="row">CM1909</th>
                    <td>Jane Doe</td>
                    <td>Dima Dabbas</td>
                    <td>CLA</td>
                    <td>Field</td>
                    <td>Complete</td>
                    <td>9/28/19</td>
                    <td class="viewRequest"><a href="CM.aspx"><i class='far fa-eye'></i></a></td>
                </tr>
                <tr>
                    <th scope="row">CM1913</th>
                    <td>Jane Doe</td>
                    <td>Dima Dabbas</td>
                    <td>CLA</td>
                    <td>Forms</td>
                    <td>Preprod</td>
                    <td>10/24/19</td>
                    <td class="viewRequest"><a href="CM.aspx"><i class='far fa-eye'></i></a></td>
                </tr>
                <tr>
                    <th scope="row">CM1916</th>
                    <td>Jane Doe</td>
                    <td>Kristi Morgridge</td>
                    <td>CLA</td>
                    <td>Entity</td>
                    <td>Not Assigned</td>
                    <td>10/08/19</td>
                    <td class="viewRequest"><a href="CM.aspx"><i class='far fa-eye'></i></a></td>
                </tr>
            </tbody>
        </table>
        <button type="button" class="btn btnDownload">Download All</button>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
