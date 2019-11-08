<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Empty_Project_Template.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">

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
                        <a class="nav-link" href="UserDashboard.aspx">User Dashboard</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link" href="AdminDashboard.aspx">Admin Dashboard</a>
                    </li>
                   
                </ul>
            </div>
        <
    </nav>
<br />
<br />
<br />
<br />
<div class="container" >
    <div class="row">
      <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
        <div class="card card-signin my-5">
          <div class="card-body">          
            <h5 class="card-title text-center">Sign In</h5>
            <form class="form-signin" runat="server">
              <div class="form-label-group">
                    <label for="inputEmail">Email address</label>
                <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus/>
              
              </div>
                <br />
              <div class="form-label-group">
                  <label for="inputPassword">Password</label>
                <input type="password" id="inputPassword" class="form-control" placeholder="Password" required/>
                
              </div>

              <div class="custom-control custom-checkbox mb-3">
                <input type="checkbox" class="custom-control-input" id="customCheck1"/>             
              </div>
                <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-lg btn-secondary btn-block text-uppercase" Text="Sign In"/>
                 <br />
              </form>
          </div>
        </div>
      </div>
    </div>
  </div>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
</asp:Content>
