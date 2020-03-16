<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewRequestType.aspx.cs" Inherits="ChangeManagementSystem.NewRequestType" %>

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
    <form id="form1" runat="server">
        <br />

        <div class="mt-5">
            <div class="row mt-5">
                <div class="col-3"></div>

                <div class="col-6 p-5" style="background-color: rgba(0,0,0,.03); box-shadow: 0 0 12px 1.5px #808080;">
                    <h2 id="requestHistory" class="mb-5 ">New Request Type</h2>
                    <div style="margin: 0 auto; max-width: 600px;">
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label runat="server" CssClass="form-text font-weight-bold">Request Type Name</asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtRequestName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="margin: 0 auto; max-width: 600px;">
                        <asp:Panel ID="pnlNewRequestType" runat="server">
                        </asp:Panel>
                    </div>
                    <div class="form-row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-8">
                            <button type="button" class="btn btn-secondary mt-5 ml-5" data-toggle="modal" data-target="#mdlAddQuestion" data-whatever="@fat">Add Question</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-3"></div>
                <asp:Button BackColor="#9D2235" ForeColor="#ffffff" CssClass="btn btn-secondary mt-5 ml-3" BorderStyle="None" ID="btnSubmit" runat="server" Text="Create new request type" OnClick="btnSubmit_Click" />
            </div>

        </div>
        <!-- Modal -->
        <div class="modal fade" id="mdlAddQuestion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">New message</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label">Control Type:</label><br />
                            <select id="control-type" class="form-control" name="control-type" onchange="chgControlType()">
                                <option value="N/A">- Select control type -</option>
                                <option value="Dropdown">Dropdown</option>
                                <option value="RadioButton">Radio Button</option>
                                <option value="TextBox">TextBox</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="col-form-label">Control Text/Question:</label>
                            <input type="text" class="form-control" id="control-text" name="control-text" required>
                        </div>
                        <div id="option-container" class="d-none form-group">
                            <label for="message-text" class="col-form-label">Options:</label>
                            <div id="options">
                                <div id="Option 1">
                                    <input type="text" class="form-control mb-2" style="width: 95%; display: inline;" id="control-option" onchange="addOptionsToSession()" placeholder="Option 1" required>
                                    <i id="1"></i>
                                </div>
                            </div>
                            <div class="form-group" id="addOption">
                                <button type="button" class="form-control" style="text-align: left; width: 95%;" id="btnAddOption" onclick="addOption()">Add Option</button>
                            </div>
                            <%--<button type="button" class="btn btn-secondary float-right">Confirm Options</button>--%>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="submit" class="btn btn-primary" id="btnAdd" runat="server" onserverclick="btnAdd_ServerClick">Add</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <%--<script>
        function myFunction() {
           alert("clicked!")
        }
    </script>--%>

    <script>
        $(document).ready(function () {
            $(".dropdown-toggle").dropdown();
        });
    </script>
</asp:Content>
