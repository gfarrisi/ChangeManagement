<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllRequests.aspx.cs" Inherits="Empty_Project_Template.ViewAllRequests" %>

<asp:Content ID="TableContent" ContentPlaceHolderID="CPH1" runat="server">
    <h2 id="requestHistory">Request History</h2>
    <div class="card mb-4 w-50" id="searchBar">
        <div class="input-group">
            <input type="text" class="form-control" placeholder="Search for...">
            <span class="input-group-btn">
                <button class="btn btn-dark" type="button">Search</button>
            </span>
        </div>
    </div>
    <table class="table table-bordered table-hover">
        <thead class="thead">
            <tr>
                <th scope="col">CM ID  <i class="fas fa-sort"></i></th>
                <th scope="col">User  <i class="fas fa-sort"></i></th>
                <th scope="col">Admin  <i class="fas fa-sort"></i></th>
                <th scope="col">College  <i class="fas fa-sort"></i></th>
                <th scope="col">Type  <i class="fas fa-sort"></i></th>
                <th scope="col">Status  <i class="fas fa-sort"></i></th>
                <th scope="col">Last Updated Date  <i class="fa fa-sort"></i></th>
                <th scope="col">View Request</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">CM101</th>
                <td>Sandy James</td>
                <td>Kristi Morgridge</td>
                <td>Boyer</td>
                <td>Entity</td>
                <td>Not Assigned</td>
                <td>10/08/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM102</th>
                <td>Sam Kelly</td>
                <td>Dima Dabbas</td>
                <td>Global</td>
                <td>Forms</td>
                <td>Preprod</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM103</th>
                <td>Lauren O'Neil</td>
                <td>Dima Dabbas</td>
                <td>Tyler</td>
                <td>Field</td>
                <td>Complete</td>
                <td>9/28/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM104</th>
                <td>Jaime Martino</td>
                <td>Kristi Morgridge</td>
                <td>UG</td>
                <td>Activity Codes</td>
                <td>Assigned</td>
                <td>9/22/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM105</th>
                <td>Helene Houser</td>
                <td>Kristi Morgridge</td>
                <td>CRM</td>
                <td>Workflow</td>
                <td>Complete</td>
                <td>8/18/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
            <tr>
                <th scope="row">CM106</th>
                <td>Megan Nyquist</td>
                <td>Dima Dabbas</td>
                <td>CST</td>
                <td>System Views</td>
                <td>Failed</td>
                <td>8/8/19</td>
                <td class="viewRequest"><i class='far fa-eye'></i></td>
            </tr>
        </tbody>
    </table>
    <button type="button" class="btn" id="btnDownload">Download All</button>
</asp:Content>
