﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="Empty_Project_Template.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <h2 id="requestHistory">User Settings</h2>
    <div class="card mb-4 w-50" id="searchBar">
        <div class="input-group">
            <input type="text" class="form-control" placeholder="Search for...">
            <span class="input-group-btn">
                <button class="btn btn-dark" type="button">Search</button>
            </span>
        </div>
    </div>
    <table class="table table-bordered table-striped table-hover">
        <thead class="thead-dark">
            <tr>
                <th scope="col">User  <i class="fas fa-sort"></i></th>
                <th scope="col">College  <i class="fas fa-sort"></i></th>
                <th scope="col">Created Date  <i class="fa fa-sort"></i></th>
                <th scope="col">Remove User</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">Matthew Schillizzi</th>
                <td>Boyer</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Sandy James</th>
                <td>Boyer</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Trevor Hinkle</th>
                <td>Boyer</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Jemin Patel</th>
                <td>CPH</td>
                <td>10/28/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Philip Riesch</th>
                <td>CST</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Tristin Carmichael</th>
                <td>CST</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Megan Nyquist</th>
                <td>CST</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Lori Bailey</th>
                <td>EDUC</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Rahel Teklegiorgis</th>
                <td>EDUC</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">ENGR - Colleen Baillie</th>
                <td>CPH</td>
                <td>10/24/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Liz Windhaus</th>
                <td>ENGR</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Erika Clemons</th>
                <td>Global</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Owen Jones</th>
                <td>Global</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Sam Kelley</th>
                <td>Global</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Michael Toner</th>
                <td>GRAD</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Sabriya McWilliams</th>
                <td>INTL</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Elle Butler</th>
                <td>INTL</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Kaitlin Pierce</th>
                <td>KLEIN</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Stefan Schechs</th>
                <td>LKSOM</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Neal Conley</th>
                <td>NDEG</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Joan Hankins</th>
                <td>PHARM</td>
                <td>10/21/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Grace Ahn Klensin</th>
                <td>TYL</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Lauren O'Neill</th>
                <td>TYL</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Charles Musgrove</th>
                <td>UG</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Jaime Martino</th>
                <td>UG</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Dima Dabbas</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Ferria Amzovski</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Helene Houser</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
            <tr>
                <th scope="row">Kristi Morgridge</th>
                <td>CRM</td>
                <td>10/18/19</td>
                <td class="viewRequest"><i class="fas fa-trash-alt"></i></td>
            </tr>
        </tbody>
    </table>
    <div class="container">
        <button type="button" class="btn btnDownload">Download All</button>
        <button type="button" class="btn btnAdd">Add New User</button>
    </div>

</asp:Content>