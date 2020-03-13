<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChangeManagementSystem.Secure.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center><h2>These buttons are for development & demo purposes only!</h2></center>
        <div class="row" style="margin-top: 100px">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div runat="server" id="divError" class="alert alert-danger" role="alert" visible="false">
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <asp:Button runat="server" ID="btnShibb" Text="Shibboleth" CssClass="btn btn-lg btn-primary" Width="100%" OnClick="btnShibb_Click" />
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin-top: 50px">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <asp:Button runat="server" ID="btnEmployee" Text="Employee Account" CssClass="btn btn-lg btn-primary" Width="100%" OnClick="btnEmployeeTestAcct_Click" />
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin-top: 50px">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <asp:Button runat="server" ID="btnStudent" Text="Student Account" CssClass="btn btn-lg btn-primary" Width="100%" OnClick="btnStudentTestAcct_Click" />
            </div>
            <div class="col-md-4"></div>
        </div>
    </form>

</body>
</html>
