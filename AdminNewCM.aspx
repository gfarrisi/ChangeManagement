﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminNewCM.aspx.cs" Inherits="ChangeManagementSystem.NewCM" %>

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
        <div class="pull-right pt-5 pb-1">
            <div class="pl-5 ml-5">
                <div class="row">
                    <div class="col-lg-4 mb-1">
                        <a href="AdminSelectRequestType.aspx" class="btn btn-dark">Back to Request Types</a>
                    </div>

                </div>
            </div>
        </div>
  <div class="row">
            <div class="col-3"></div>
            <div class="col-6 pt-5 pb-5" style="background-color: rgba(0,0,0,.03); box-shadow: 0 0 12px 1.5px #808080;">
                <h1 class="text-center mb-5">CRM Change Management</h1>
                <div style="margin: 0 auto; max-width: 600px;">
                    <div class="row mt-3 mb-3">
                         <div class="col-lg-6">
                             <asp:Label ID="lblCMname" runat="server" Text="CM Name" CssClass="form-text h4 mb-4"></asp:Label>
                             </div>

                        <div class="col-lg-6">
                                <asp:TextBox ID="txtCMname" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>
                    <asp:Panel ID="panelCM" runat="server">
                    </asp:Panel>
                    <asp:Panel ID="panelScreenshots" runat="server">

                        <asp:Label ID="lblHeading" runat="server" Text="Screenshots" CssClass="form-text h4"></asp:Label>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblDesc" runat="server" Text="Detailed description of change" CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtDescResponse" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblUpload" runat="server" Text="Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots." CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:FileUpload ID="fuScreenshots" CssClass="form-control-file" runat="server"></asp:FileUpload>
                            </div>
                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblDesiredDate" runat="server" Text="Desired date of completion" CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                            <asp:TextBox ID="txtDesiredDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblQuesCom" runat="server" Text="Questions/Comments" CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtQuesCom" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-5 ml-5"></div>
            <div class="col-3 pt-5 pr-5">
                <div>
                    <asp:Button CssClass="btn btn-primary btn-lg" BorderStyle="None" ID="btnSubmit" Text="Submit Request" BackColor="#9D2235" ForeColor="#ffffff" runat="server" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>