<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllRequests.aspx.cs" Inherits="Empty_Project_Template.ViewAllRequests" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">

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
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <br />
    <br />
    <br />
    <div class="container" style="height: 100%;">
        <h2 id="requestHistory">Request History</h2>
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
                    <th scope="row">CM1900</th>
                    <td>Jane Doe</td>
                    <td>Kristi Morgridge</td>
                    <td>CLA</td>
                    <td>Systems View</td>
                    <td>Complete</td>
                    <td>8/18/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>
                </tr>
                <tr>
                    <th scope="row">CM1901</th>
                    <td>Sandy James</td>
                    <td>Kristi Morgridge</td>
                    <td>Boyer</td>
                    <td>Entity</td>
                    <td>Not Assigned</td>
                    <td>10/08/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1902</th>
                    <td>Sam Kelly</td>
                    <td>Dima Dabbas</td>
                    <td>Global</td>
                    <td>Forms</td>
                    <td>Preprod</td>
                    <td>10/24/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1903</th>
                    <td>Lauren O'Neil</td>
                    <td>Dima Dabbas</td>
                    <td>Tyler</td>
                    <td>Field</td>
                    <td>Complete</td>
                    <td>9/28/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1904</th>
                    <td>Jaime Martino</td>
                    <td>Kristi Morgridge</td>
                    <td>UG</td>
                    <td>Activity Codes</td>
                    <td>Assigned</td>
                    <td>9/22/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1905</th>
                    <td>Jane Doe</td>
                    <td>Dima Dabbas</td>
                    <td>CLA</td>
                    <td>Work Flow</td>
                    <td>Preprod</td>
                    <td>9/4/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1906</th>
                    <td>Jane Doe</td>
                    <td>Kristi Morgridge</td>
                    <td>CLA</td>
                    <td>Activity Codes</td>
                    <td>Assigned</td>
                    <td>9/22/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1907</th>
                    <td>Helene Houser</td>
                    <td>Kristi Morgridge</td>
                    <td>CRM</td>
                    <td>Workflow</td>
                    <td>Complete</td>
                    <td>8/18/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>

                <tr>
                    <th scope="row">CM1908</th>
                    <td>Megan Nyquist</td>
                    <td>Dima Dabbas</td>
                    <td>CST</td>
                    <td>System Views</td>
                    <td>Failed</td>
                    <td>8/8/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1909</th>
                    <td>Jane Doe</td>
                    <td>Dima Dabbas</td>
                    <td>CLA</td>
                    <td>Field</td>
                    <td>Complete</td>
                    <td>9/28/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1910</th>
                    <td>Sam Kelly</td>
                    <td>Dima Dabbas</td>
                    <td>Global</td>
                    <td>Forms</td>
                    <td>Preprod</td>
                    <td>10/24/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1911</th>
                    <td>Megan Nyquist</td>
                    <td>Dima Dabbas</td>
                    <td>CST</td>
                    <td>System Views</td>
                    <td>Failed</td>
                    <td>8/8/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1912</th>
                    <td>Sam Kelly</td>
                    <td>Dima Dabbas</td>
                    <td>Global</td>
                    <td>Forms</td>
                    <td>Preprod</td>
                    <td>10/24/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1913</th>
                    <td>Jane Doe</td>
                    <td>Dima Dabbas</td>
                    <td>CLA</td>
                    <td>Forms</td>
                    <td>Preprod</td>
                    <td>10/24/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1914</th>
                    <td>Sandy James</td>
                    <td>Kristi Morgridge</td>
                    <td>Boyer</td>
                    <td>Entity</td>
                    <td>Not Assigned</td>
                    <td>10/08/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1915</th>
                    <td>Lauren O'Neil</td>
                    <td>Dima Dabbas</td>
                    <td>Tyler</td>
                    <td>Field</td>
                    <td>Complete</td>
                    <td>9/28/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1916</th>
                    <td>Jane Doe</td>
                    <td>Kristi Morgridge</td>
                    <td>CLA</td>
                    <td>Entity</td>
                    <td>Not Assigned</td>
                    <td>10/08/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
                <tr>
                    <th scope="row">CM1917</th>
                    <td>Sam Kelly</td>
                    <td>Dima Dabbas</td>
                    <td>Global</td>
                    <td>Forms</td>
                    <td>Preprod</td>
                    <td>10/24/19</td>
                    <td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>

                </tr>
            </tbody>
        </table>
        <button type="button" class="btn btnDownload">Download All</button>
    </div>
    <br />
    <br />
    <br />

    <!-- Modal -->
    <div class="modal fade bd-example-modal-lg" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header" align="center">
                    <h5 class="modal-title" id="exampleModalLongTitle">CM #1905 - Update Create Person Workflows for UG Transfer</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-1 mb-2"></div>
                        <div class="col-lg-10 mb-2 ">
                            <div class=" h-100">

                                <div class="card-body">
                                    <h4 class="" align="center">Status: Assigned</h4>
                                    <div class="progress">
                                        <div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <br />
                                    <%--<div class="status-check"> 
                                        <input type="checkbox" class="form-check-input" id="exampleCheck1">
                                        <label class="form-check-label" for="exampleCheck1">Check me out</label>
                                    </div>--%>
                                    <div class="row">
                                        <div class="col-lg-3 mb-2"></div>
                                        <div class="col-lg-6">
                                            <div class="status-check">
                                                <select name="avatar" class="browser-default custom-select">
                                                    <option value="avatars">- Update Status -</option>
                                                    <%--<option value="avatars/avatar-4.jpg">Assign to me</option>--%>
                                                    <option value="avatars/avatar-1.jpg">CM Failed</option>
                                                    <option value="avatars/avatar-2.jpg">Change implented in preprod</option>
                                                    <option value="avatars/avatar-3.jpg">Change implemented in prod</option>

                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="center">

                                        <%--   <a href="#" class="btn btn-secondary" align="center">Submit</a>--%>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 form-data">

                            <br />

                            <div class="row">
                                <h4>Request Type: Workflow</h4>
                                <br />
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Name:</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>Jane Doe</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Email address: </b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>tuf13663@temple.edu</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>College:</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>College of Liberal Arts</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Assigned To:</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>Dima Dabbas</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Workflow/Process Name:</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>All 4 Create Person WFs for UG Transfer</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Entity:</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>UG Transfer Staging</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Description:</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>All 4 Create Person WFs for UG Transfer</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Is this a New or Revised workflow?</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>REVISED</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Does this workflow fire an email? </b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>NO</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Is there a corresponding Workflow Schedule?</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>NO - Workflow is triggered</p>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <h4>Screenshots & Submission</h4>
                                <br />
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Detailed Description of Change</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>Update all 4 Create Person WFs for UG Transfer in PREPROD</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>
                                        <a href="">File 1https://drive.google.com/open?id=1gomIbt8yJA2pn0xY06-
                                            PxS5AZFHYmP2k
                                            File 2https://drive.google.com/open?id=1hV2JPhOHB47aEy7clxsPuWOiDbad0Ze
                                            File 3https://drive.google.com/open?id=1L--
                                            Dnd6dLVQGhCP3hbkZ5Rs-z0iwJUwm
                                            File 4https://drive.google.com/open?
                                            id=16nZJaBWjqmG5642crodKkUYnHYhfJE2U
                                        </a>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Desired Date for Move</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>Sep 04, 2019</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p><b>Questions/Comments</b></p>
                                </div>
                                <div class="col-lg-6">
                                    <p>Please update workflows in PREPROD and PROD.</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-9">
                                </div>
                                <div class="col-lg-3">
                                    <br />

                                </div>
                            </div>
                            <hr />
                        </div>


                    </div>

                    <div class="row mb-7">

                        <div class="col-lg-1 mb-7"></div>
                        <div class="col-lg-11 mb-7" style="height: 400px; padding-left: 0;">

                            <h4 class="mb-3 ml-1 mt-3">Comments</h4>
                            <div class="card h-100">

                                <div class="card-body overflow-auto">
                                    <p class="card-text">
                                        Admin  
                                            <br />
                                        <span class="comment-time">[10/17/2019 4:42 PM]</span>
                                        <br />
                                        <span class="comment-text">Was this the first submission of this form? It looks like we may have completed this two weeks ago.</span>
                                    </p>
                                    <hr>
                                    <p class="card-text">
                                        Jane Doe 
                                            <br />
                                        <span class="comment-time">[10/19/2019 6:42 PM]</span>
                                        <br />
                                        <span class="comment-text">The form submitted two weeks ago was similar, but we actually need a few things added so this is a new submission request.</span>
                                    </p>
                                    <hr>
                                    <p class="card-text">
                                        Admin  
                                            <br />
                                        <span class="comment-time">[10/20/2019 11:40 AM]</span>
                                        <br />
                                        <span class="comment-text">Can you provide the CM# for that request?</span>
                                    </p>

                                    <hr>
                                    <p class="card-text">
                                        Jane Doe 
                                            <br />
                                        <span class="comment-time">[10/20/2019 1:12 PM]</span>
                                        <br />
                                        <span class="comment-text">Sure, it was #9127</span>
                                    </p>
                                </div>
                                <div class="card-footer">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <textarea rows="1" cols="100" class="form-control" id="message" required data-validation-required-message="Please enter your message" maxlength="99"></textarea>
                                        </div>
                                    </div>
                                    <a href="#" class="btn btn-secondary" align="center">Comment</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer mt-5">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnClose">Close</button>
                    <button type="button" class="btn btn-secondary" id="btnDownload">Download</button>
                    <button type="button" class="btn btn-primary" id="btnSave" data-dismiss="modal" data-toggle="modal" data-target="#mdlSavedChanges">Save changes</button>
                </div>
            </div>

        </div>
    </div>
    <div class="modal fade" id="mdlSavedChanges" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Changes Saved</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    CM #302 has been marked as failed. User notified.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
