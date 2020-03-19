<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditEmail.aspx.cs" Inherits="ChangeManagementSystem.WebForm3" %>

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
                        <asp:Label ID="lblUserName" runat="server" Text="Default"></asp:Label>
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
   
    <div class="container mt-5" style="height: 100%;">
        <h2 id="automateEmails">Automated Emails</h2>
        <div>
            <form id="form1" runat="server">
               
                <div class="gvE">
                     <asp:HiddenField runat="server" ID="hf" ClientIDMode="Static" />
                    <asp:GridView ID="gvEmails" runat="server" CssClass="table" AutoGenerateColumns="False" Width="1000px" BorderColor="#CCCCCC">
                        <Columns>
                            <asp:BoundField DataField="Type" HeaderText="Email" ReadOnly="true">
                                <ItemStyle CssClass="font-weight-bold" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sent" HeaderText="Sent To" ReadOnly="true" />
                            <asp:BoundField DataField="Subject" HeaderText="Subject" ReadOnly="true" />
                            <asp:BoundField DataField="Body" HeaderText="Body" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Edit Message" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <a class="viewRequest" onclick="getData(this)" data-toggle="modal" data-target="#exampleModal" style="cursor: pointer"><i class='far fa-edit'></i></a>
                                </ItemTemplate>
                            </asp:TemplateField>


<%--                            <asp:HiddenField runat="server" ID="SendA" Value=""></asp:HiddenField>
                            <script type="text/javascript">
                                document.getElementById("<%=SendA.Email%>").value="1";
                            </script>--%>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    
                </div>

                <!-- Modal -->
                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Edit Message</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Subject:</label><br />
                                        <label for="recipient-name" class="col-form-label">Subject can not be edited</label>
                                        <asp:TextBox ID="txtSubject" class="form-control" disabled="disabled" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="message-text" class="col-form-label">Body:</label>
                                        <asp:TextBox ID="txtBody" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnEdit" class="btn btn-primary" runat="server" Text="Edit Email" OnClick="btnEdit_Click" OnClientClick="abc()" />
          
                                
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.1/js/jquery.tablesorter.min.js" integrity="sha256-uC1JMW5e1U5D28+mXFxzTz4SSMCywqhxQIodqLECnfU=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        function getData(t) {
            
            var row = t.parentElement.parentElement.rowIndex;
            
            var subject = document.querySelectorAll('tr')[row].cells[2].innerHTML;
            var body = document.querySelectorAll('tr')[row].cells[3].innerHTML;
            document.querySelectorAll('input[name="ctl00$CPH1$txtSubject"]')[0].value = subject;
            document.querySelectorAll('input[name="ctl00$CPH1$txtBody"]')[0].value = body;
            //alert(String(row));
            //document.getElementById("labelRow").innerHTML = '' + String(row);
            $("#hf").val(String(row))
          
       
        }

        $(document).ready(function () {
            $(".dropdown-toggle").dropdown();
        });
    </script>
</asp:Content>
