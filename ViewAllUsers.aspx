<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="Empty_Project_Template.ViewAllUsers" %>

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
            <div style="overflow-y: scroll; height: 500px; ">
                <table class="table table-bordered table-striped table-hover" >
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">User  <i class="fas fa-sort"></i></th>
                            <th scope="col">College  <i class="fas fa-sort"></i></th>
                            <th scope="col">Created Date  <i class="fa fa-sort"></i></th>
                            <th scope="col">Deactivate User</th>
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
            </div>
            <div class="container mt-4">
                <button type="button" onclick="exportTableToCSV('Users.csv')" class="btn btnDownload">Download All Users as CSV</button>
                <button type="button" class="btn btnAdd" data-toggle="modal" data-target="#exampleModal">
                    Add New User
                </button>
                <%--<asp:Button ID="btnNewUser" runat="server" Text="Add New User" OnClick="btnNewUser_Click" class="btn btnAdd" />--%>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">New User Information</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group form-row">
                            <div class="col-lg-3">

                                <label id="lblAccessNet" style="line-height: 50px;" runat="server">AccessNet ID</label>
                                <br />
                                <label id="lblAccountType" style="line-height: 50px;" runat="server">Account Type</label>
                            </div>
                            <div class="col-lg-9">
                                <input class="form-control" id="txtTUID" type="text" runat="server" />
                                <br />
                                <select class="form-control" runat="server">
                                    <option>- Choose Type -</option>
                                    <option value="admin">Admin</option>
                                    <option value="user">User</option>
                                </select>
                            </div>



                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Add</button>
                    </div>
                </div>
            </div>
        </div>


    </form>

    <script>
        function exportTableToCSV(filename) {
            var csv = [];
            var rows = document.querySelectorAll("table tr");

            for (var i = 0; i < rows.length; i++) {
                var row = [], cols = rows[i].querySelectorAll("td, th");

                for (var j = 0; j < cols.length; j++)
                    row.push(cols[j].innerText);

                csv.push(row.join(","));
            }

            // Download CSV file
            downloadCSV(csv.join("\n"), filename);
        }
        function downloadCSV(csv, filename) {
            var csvFile;
            var downloadLink;

            // CSV file
            csvFile = new Blob([csv], { type: "text/csv" });

            // Download link
            downloadLink = document.createElement("a");

            // File name
            downloadLink.download = filename;

            // Create a link to the file
            downloadLink.href = window.URL.createObjectURL(csvFile);

            // Hide download link
            downloadLink.style.display = "none";

            // Add the link to DOM
            document.body.appendChild(downloadLink);

            // Click download link
            downloadLink.click();
        }
    </script>

</asp:Content>
