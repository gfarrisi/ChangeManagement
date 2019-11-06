<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="Empty_Project_Template.ViewAllUsers" %>
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
    <form runat="server">
    <br />
    <div class="container">
     <h2 id="requestHistory">User Settings</h2>
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
                <th scope="col">User  <i class="fas fa-sort"></i></th>
                <th scope="col">College  <i class="fas fa-sort"></i></th>
                <th scope="col">Created Date  <i class="fa fa-sort"></i></th>
                <th scope="col">Remove User</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">Matthew Schillizzi</th>
                <td>Boyer</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Sandy James</th>
                <td>Boyer</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Trevor Hinkle</th>
                <td>Boyer</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Jemin Patel</th>
                <td>CPH</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Philip Riesch</th>
                <td>CST</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Tristin Carmichael</th>
                <td>CST</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Megan Nyquist</th>
                <td>CST</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Lori Bailey</th>
                <td>EDUC</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Rahel Teklegiorgis</th>
                <td>EDUC</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">ENGR - Colleen Baillie</th>
                <td>CPH</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Liz Windhaus</th>
                <td>ENGR</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Erika Clemons</th>
                <td>Global</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Owen Jones</th>
                <td>Global</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Sam Kelley</th>
                <td>Global</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Michael Toner</th>
                <td>GRAD</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Sabriya McWilliams</th>
                <td>INTL</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Elle Butler</th>
                <td>INTL</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Kaitlin Pierce</th>
                <td>KLEIN</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Stefan Schechs</th>
                <td>LKSOM</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Neal Conley</th>
                <td>NDEG</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Joan Hankins</th>
                <td>PHARM</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Grace Ahn Klensin</th>
                <td>TYL</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Lauren O'Neill</th>
                <td>TYL</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Charles Musgrove</th>
                <td>UG</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Jaime Martino</th>
                <td>UG</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Dima Dabbas</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Ferria Amzovski</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Helene Houser</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Kristi Morgridge</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
        </tbody>
    </table>
    <div class="container">
        <button type="button" class="btn btnDownload">Download All</button>
        
        <asp:Button ID="btnNewUser" runat="server" Text="Add New User" OnClick="btnNewUser_Click" class="btn btnAdd" />
    </div>
        </div>
        </form>
</asp:Content>
