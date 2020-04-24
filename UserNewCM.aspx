<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserNewCM.aspx.cs" Inherits="ChangeManagementSystem.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <a class="navbar-brand " href="UserDashboard.aspx">
            <img src="T.png" alt="" width="40">
        </a>
        <a class="navbar-brand" href="UserDashboard.aspx">CRM Recruit: Change Management</a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link" href="UserDashboard.aspx">Dashboard</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="CM.aspx" id="navbarDropdownBlog" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <asp:Label runat="server" ID="lblUserName" Text="Default"></asp:Label>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                        <a class="dropdown-item" href="Login.aspx">Logout</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptman" runat="server"></asp:ScriptManager>
        <div class="pull-right pt-5 pb-1">
            <div class="pl-5 ml-5">
                <div class="row">
                    <div class="col-lg-4 mb-1">
                        <a href="UserSelectRequestType.aspx" class="btn btn-dark">Back to Request Types</a>
                    </div>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3"></div>
            <div class="col-6 pt-5 pb-5" style="background-color: rgba(0,0,0,.03); box-shadow: 0 0 12px 1.5px #808080;">

                <h1 class="text-center"><span id="spanCM" runat="server"></span></h1>
                   <div style="text-align: center" class="mb-5">
                    <asp:Label ID="Label2" runat="server" Text="All fields required *" CssClass="form-text"></asp:Label>
                </div>
                <div style="text-align: center">
                    <asp:Label runat="server" ID="lblErrorMessage" Visible="false" Text="Please submit a response for all required fields!" Font-Size="Large" ForeColor="Red"></asp:Label>
                </div>
                <div style="margin: 0 auto; max-width: 600px;">
                    <div class="row mt-3 mb-3">
                        <div class="col-lg-6">
                            <asp:Label ID="lblCMname" runat="server" Text="CM Name *" CssClass="form-text h4 mb-4"></asp:Label>
                        </div>

                        <div class="col-lg-6">
                            <asp:TextBox ID="txtCMname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <asp:Panel ID="panelCM" runat="server">
                    </asp:Panel>
                    <asp:Panel ID="panelScreenshots" runat="server">

                        <asp:Label ID="lblHeading" runat="server" Text="Screenshots & Submission" CssClass="form-text h4"></asp:Label>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblDesc" runat="server" Text="Detailed description of change *" CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox TextMode="MultiLine" Rows="4" ID="txtDescResponse" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblUpload" runat="server" Text="Please upload up to 5 applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots. <br>Permitted files: .pdf, .png, .jpg, .xls, .xlsx, .doc, .docx, or .csv *" CssClass="form-text"></asp:Label>
                            </div>

                            <div class="col-lg-6">
                                <asp:FileUpload ID="fuScreenshots" CssClass="form-control-file" runat="server" ClientIDMode="Static" AllowMultiple="true"/>
                                <asp:Label ID="lblScreenshotsError" runat="server" Visible="false" Font-Size="Large" ForeColor="Red">You are only permitted to submit files with a .pdf, .png, .jpg, .xls, .xlsx, .doc, .docx, or .csv file extension!</asp:Label>
                            </div>



                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblDesiredDate" runat="server" Text="Desired date of completion *" CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtDesiredDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-6">
                                <asp:Label ID="lblQuesCom" runat="server" Text="Questions/Comments *" CssClass="form-text"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox TextMode="MultiLine" Rows="4" ID="txtQuesCom *" CssClass="form-control" runat="server"></asp:TextBox>
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
                    <asp:Button CssClass="btn btn-primary btn-lg" BorderStyle="None" ID="btnSubmitUser" Text="Submit Request" BackColor="#9D2235" ForeColor="#ffffff" runat="server" OnClick="btnSubmitUser_Click" />
                </div>
            </div>
        </div>
        <!-- Modal data-toggle="modal" data-target="#warningModal"-->
        <div class="modal fade" id="mdlCMSubmssion" tabindex="-1" role="dialog" aria-labelledby="mdlCMSubmissionLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="mdlCMSubmissionLabel">CM Submssion</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <label id="Label1" style="line-height: 50px;" runat="server">
                                Thank you for submitting your CM!<br />
                                Please check your email or dashboard for updates!</label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnClose" CssClass="btn btn-secondary" BorderStyle="None" OnClick="btnClose_Click" Text="Close" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        $(document).ready(function () {
            $(".dropdown-toggle").dropdown();
        });
    </script>
</asp:Content>
