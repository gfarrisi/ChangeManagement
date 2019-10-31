<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewCM.aspx.cs" Inherits="Empty_Project_Template.NewCM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <h1 class="text-center">CRM Change Management</h1>
        <div style="margin: 0 auto; max-width: 300px; padding: 30px;">
        
        <br />
        <asp:DropDownList OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged" AutoPostBack="true" BackColor="#9D2235" ForeColor="#ffffff" ID="ddlRequestType" runat="server">
            <asp:ListItem>Workflow</asp:ListItem>
            <asp:ListItem>Entity</asp:ListItem>
            <asp:ListItem>Business Rules</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <div class="form-group">
            <asp:label id="lbl1" runat="server"></asp:label>
            <input class="form-text" id="txtField1" type="text" runat="server" />
            <br />
            <asp:label id="lbl2" runat="server"></asp:label>
            <input class="form-text" id="txtField2" type="text" runat="server"/>
            <br />
            <asp:label id="lbl3" runat="server"></asp:label>
            <input class="form-text" id="txtField3" type="text" runat="server"/>
            <br />
            <asp:label id="lbl4" runat="server"></asp:label>
            <br />
            <span id="rd1" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                <input style="margin-right: 10px;" class="form-check" name="rdField1" id="rdNew" type="radio" value="New"/>
                <label id="lblNew" class="form-check-label">New</label>
            </span>
            <span id="rd2" style= "display: flex; flex-flow: row wrap; align-items: center;" runat="server">
                <input style="margin-right: 10px;" class="form-check" name="rdField1" id="rdRevised" type="radio" value="Revised" />
                <label id="lblRevised" class="form-check-label">Revised</label>
            </span>
        </div>
        <br />
        <asp:Button CssClass="rounded-pill" Width="120px" BorderStyle="None" ID="btnSubmit" Text="New Request" BackColor="#9D2235" ForeColor="#ffffff" OnClick="btnSubmit_Click" runat="server" />
        
    </div>
    </form>
    
    
    
</asp:Content>
