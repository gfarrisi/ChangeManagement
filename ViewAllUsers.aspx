<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="ChangeManagementSystem.ViewAllUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <a class="navbar-brand " href="AdminDashboard.aspx">
            <img src="T.png" alt="" width="40">
        </a>
        <a class="navbar-brand" href="AdminDashboard.aspx">CRM Recruit: Change Management</a>
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
                        <a class="dropdown-item" href="EditEmail.aspx">Edit Emails</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlo" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <asp:Label runat="server" ID="lblUserName" Text="Default"></asp:Label>
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
                    <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" placeholder="Search for..."></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button CssClass="btn btn-dark" BorderStyle="None" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                    </span>
                </div>
            </div>
            <div style="overflow-y: scroll; height: 500px;">
                <div class="gv">
                    <asp:HiddenField runat="server" ID="hf" ClientIDMode="Static" />
                    <asp:GridView ID="gvAllUsers" runat="server" CellPadding="3" CssClass="table" ForeColor="Black" AutoGenerateColumns="False" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" GridLines="Vertical" OnSorting="OnSorting">
                        <HeaderStyle BackColor="#333333" ForeColor="White" />

                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="TU ID" ReadOnly="true" SortExpression="UserID" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="true" SortExpression="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="true" SortExpression="LastName" />
                            <asp:BoundField DataField="College" HeaderText="College" ReadOnly="true" SortExpression="College" />
                            <asp:BoundField DataField="UserType" HeaderText="User Type" ReadOnly="true" SortExpression="UserType" />
                            <asp:TemplateField HeaderText="Deactivate User" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnfldVariable" Value='<%# Eval("UserID") %>' runat="server" />
                                    <a class="viewRequest" onclick="getData(this)" data-toggle="modal" data-target="#warningModal" style="cursor: pointer"><i class='fas fa-user-slash'></i></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
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

        <!-- Modal data-toggle="modal" data-target="#warningModal"-->
        <div class="modal fade" id="warningModal" tabindex="-1" role="dialog" aria-labelledby="warningModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="warningModalLabel">WARNING</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <label id="Label1" style="line-height: 50px;" runat="server">Are you sure you want to deactivate this user?</label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeactivate" CssClass="btn btn-danger" BorderStyle="None" Text="Deactivate User" runat="server" OnClick="btnDeactivate_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        function getData(t) {
            var row = t.parentElement.parentElement.rowIndex;
            var userID = document.getElementById('CPH1_gvAllUsers_hdnfldVariable_' + (row - 1)).value;
            $("#hf").val(String(userID))
        }

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
