<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewRequestType.aspx.cs" Inherits="Empty_Project_Template.NewRequestType" %>
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
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
       
        <div style="height:100%;">
        <div style="margin: 0 auto; max-width: 500px; padding: 30px;">
        <h1>New Request Type</h1>
        <br /> 
        <div class="form-row" >
            <div class="col-md">
                <asp:Label runat="server"><b>Request Type Name</b></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="ddlControlTypes" runat="server"  CssClass="dropdown-toggle">
                    <asp:ListItem>Short Answer</asp:ListItem>
                    <asp:ListItem>Multiple Choice</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md">
                <p class="form-text" id="txtTypeName"><b>Constraint</b></p>
                <asp:Button CssClass="btn btn-secondary" Width="140px" BorderStyle="None" ID="btnAddQuestion" Text="Add Question" BackColor="#9D2235" ForeColor="#ffffff" onclick="btnAddQuestion_Click" runat="server" />
                
            </div>
        </div>
        <br />
        <div class="form-group form-row">
            <div class="col-md" >              
                <p class="form-text" runat="server">Questions</p>
                <br />
                <p id="lblQ1" runat="server">Short Answer Question 1</p>
                <br />
                <p id="lblQ2" runat="server">Short Answer Question 2</p>
                <br />
                <p id="lblQ3" runat="server">Multiple Choice Question 1</p>
                
            </div>
            <div class="col-md" >              
                <p class="form-text">Question Name</p>
                <br />
                <input class="form-text" id="txtQ1" type="text" runat="server" />
                <br />
                <input class="form-text" id="txtQ2" type="text" runat="server"/>
                <br />
                <input class="form-text" id="txtQ3" type="text" runat="server"/>
            </div>    
            <div class="col-md">
                <p class="form-text">Response Options</p>
                <br />
                <input class="form-text" id="opt1Q3" type="text" runat="server" />
                <br />
                <input class="form-text" id="opt2Q3" type="text" runat="server" />
            </div>
        </div>
        <br />
        <asp:Button BackColor="#9D2235" ForeColor="#ffffff" CssClass="btn btn-secondary" Width="90px" BorderStyle="None" ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" /> 
      <br />
        <br />
        <br />
              <br />
        <br />
        <br />
              <br />
        <br />
        <br />
        </div>
          
         
    </form>
</asp:Content>
