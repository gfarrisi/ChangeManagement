<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Empty_Project_Template.NewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <h1 class="text-center">User Settings</h1>
        <div style="margin: 0 auto; max-width: 300px; padding: 30px;">
        <br />
        <div class="form-group">
            <asp:label id="lbl1" runat="server">Name</asp:label>
            <input class="form-text" id="txtField1" type="text" runat="server" />
            <br />
            <asp:label id="lbl2" runat="server">Email</asp:label>
            <input class="form-text" id="txtField2" type="text" runat="server"/>
            <br />
            <asp:label id="lbl3" runat="server">TUID</asp:label>
            <input class="form-text" id="txtField3" type="text" runat="server"/>
            <br />
            <asp:label id="lbl4" runat="server">College</asp:label>
            <input class="form-text" id="txtField4" type="text" runat="server" />
            
        </div>
        <br />
        <asp:Button CssClass="rounded-pill" Width="90px" BorderStyle="None" ID="btnSubmit" Text="Add User" BackColor="#9D2235" ForeColor="#ffffff" OnClick="btnSubmit_Click" runat="server" />
        
    </div>
    </form>
</asp:Content>
