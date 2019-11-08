<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewCM.aspx.cs" Inherits="Empty_Project_Template.NewCM" %>
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

        <h1 class="text-center">CRM Change Management</h1>
        <div style="margin: 0 auto; max-width: 400px; padding: 30px;">
           
            <br />
            <div align="center">
                  <asp:DropDownList OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged" AutoPostBack="true" BackColor="#9D2235" ForeColor="#ffffff" ID="ddlRequestType" runat="server" CssClass="btn btn-secondary dropdown-toggle">
                <asp:ListItem>Workflow</asp:ListItem>
                <asp:ListItem>Entity</asp:ListItem>
                <asp:ListItem>Business Rules</asp:ListItem>
            </asp:DropDownList>
            </div>
          
          
            <br />
            <div class="form-group">
                <asp:label id="lbl1" runat="server"></asp:label>
                <input class="form-control" id="txtField1" type="text" runat="server" />
                <br />
                <asp:label id="lbl2" runat="server"></asp:label>
                <input class="form-control" id="txtField2" type="text" runat="server"/>
                <br />
                <asp:label id="lbl3" runat="server"></asp:label>
                <input class="form-control" id="txtField3" type="text" runat="server"/>
                <br />
                <div id="rd1" runat="server">
                    <asp:label id="lbl4" runat="server">Is this New or Revised?</asp:label>
                    <br />
                    <span id="rd1opt1" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField1" id="inputrd1opt1" type="radio" value="New"/>
                        <label id="lblrd1opt1" class="form-check-label">New</label>
                    </span>
                    <span id="rd1opt2" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField1" id="inputrd1opt2" type="radio" value="Revised" />
                        <label id="lblrd1opt2" class="form-check-label">Revised</label>
                    </span>
                    <br />
                </div>
                <div id="rd2" runat="server">
                    <asp:label id="lbl5" runat="server">Does this workflow fire an email?</asp:label>
                    <br />
                    <span id="rd2opt1" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField2" id="inputrd2opt1" type="radio" value="YES - Email Template"/>
                        <label id="lblrd2opt1" class="form-check-label">YES - Email Template</label>
                    </span>
                    <span id="rd2opt2" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField2" id="inputrd2opt2" type="radio" value="YES - Email within the workflow" />
                        <label id="lblrd2opt2" class="form-check-label">YES - Email within the workflow</label>
                    </span>
                    <span id="rd2opt3" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField2" id="inputrd2opt3" type="radio" value="NO" />
                        <label id="lblrd2opt3" class="form-check-label">NO</label>
                    </span>
                    <br />
                </div>
                <div id="rd3" runat="server">
                    <asp:label id="lbl6" runat="server">If YES to the previous question, does the email include environment-specific links?</asp:label>
                    <br />
                    <span id="rd3opt1" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField3" id="inputrd3opt1" type="radio" value="YES"/>
                        <label id="lblrd3opt1" class="form-check-label">YES</label>
                    </span>
                    <span id="rd3opt2" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField3" id="inputrd3opt2" type="radio" value="NO" />
                        <label id="lblrd3opt2" class="form-check-label">NO</label>
                    </span>
                    <br />
                </div>
                <div id="rd4" runat="server">
                    <asp:label id="lbl7" runat="server">Is there a corresponding Workflow?</asp:label>
                    <br />
                    <span id="rd4opt1" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField4" id="inputrd4opt1" type="radio" value="YES - NO CHANGES to Workflow Schedule"/>
                        <label id="lblrd4opt1" class="form-check-label">YES - NO CHANGES to Workflow Schedule</label>
                    </span>
                    <span id="rd4opt2" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField4" id="inputrd4opt2" type="radio" value="YES - NEW Workflow Schedule" />
                        <label id="lblrd4opt2" class="form-check-label">YES - NEW Workflow Schedule</label>
                    </span>
                    <span id="rd4opt3" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField4" id="inputrd4opt3" type="radio" value="YES - REVISED Workflow Schedule"/>
                        <label id="lblrd4opt3" class="form-check-label">YES - REVISED Workflow Schedule</label>
                    </span>
                    <span id="rd4opt4" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                        <input style="margin-right: 10px;" class="form-check" name="rdField4" id="inputrd4opt4" type="radio" value="NO - Workflow is triggered" />
                        <label id="lblrd4opt4" class="form-check-label">NO - Workflow is triggered</label>
                    </span>
                </div>
            
            </div>
            <br />
             <div align="center">
                <asp:Button CssClass="btn btn-primary" Width="140px" BorderStyle="None" ID="btnSubmit" Text="Submit Request" BackColor="#9D2235" ForeColor="#ffffff" OnClick="btnSubmit_Click" runat="server" />
            </div>
            <br />
            <br />
            <br />
        </div>
    </form>
    
    
    
</asp:Content>
