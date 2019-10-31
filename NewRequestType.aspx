<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewRequestType.aspx.cs" Inherits="Empty_Project_Template.NewRequestType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <div style="margin: 0 auto; max-width: 500px; padding: 30px;">
        <h1>New Request Type</h1>
        <br /> 
        <div class="form-row">
            <div class="col-md">
                <asp:Label runat="server"><b>Request Type Name</b></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="ddlControlTypes" runat="server">
                    <asp:ListItem>Short Answer</asp:ListItem>
                    <asp:ListItem>Checklist</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md">
                <p class="form-text" id="txtTypeName"><b>Constraint</b></p>
                <asp:Button CssClass="rounded-pill" Width="140px" BorderStyle="None" ID="btnAddQuestion" Text="Add Question" BackColor="#9D2235" ForeColor="#ffffff" onclick="btnAddQuestion_Click" runat="server" />
                
            </div>
        </div>
        <br />
        <div class="form-group form-row">
            <div class="col-md" >              
                <p runat="server">Questions</p>
                <br />
                <p id="lblQ1" runat="server">Short Answer Question 1</p>
                <br />
                <p id="lblQ2" runat="server">Short Answer Question 2</p>
                <br />
                <p id="lblQ3" runat="server">Checklist Question 1</p>
                
            </div>
            <div class="col-md" >              
                <p class="form-text">Question Name</p>
                <br />
                <input class="form-text" id="txtQ1" type="text" runat="server" />
                <br />
                <input class="form-text" id="txtQ2" type="text" runat="server"/>
                <br />
                <asp:CheckBoxList ID="chkQ3" runat="server">
                    <asp:ListItem>Column Constraint</asp:ListItem>
                    <asp:ListItem>Table Constraint</asp:ListItem>
                </asp:CheckBoxList>
            </div>                                                                
        </div>
        <br />
        <asp:Button BackColor="#9D2235" ForeColor="#ffffff" CssClass="rounded-pill" Width="90px" BorderStyle="None" ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" /> 
    </div>
    </form>
</asp:Content>
