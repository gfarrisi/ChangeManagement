<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CM.aspx.cs" Inherits="ChangeManagementSystem.CM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <div class="container">
            <a class="navbar-brand" href="index.html">CRM Recruit: Change Management</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">

                    <li class="nav-item">
                        <a class="nav-link" href="AdminDashboard.aspx">Admin Dashboard</a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link" href="UserDashboard.aspx">Dashboard</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlog" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Jane Doe
            </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                            <a class="dropdown-item" href="Login.aspx">Log Out</a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container-cm">
     <!-- Intro Content -->
    <br />
    <div class="row">
    </div>
         <div class="row">
      <div class="col-lg-2 mb-4" style="height: 250px;">
          <br />
          <br />
        <div class="card h-100">
            <h4 class="card-header" align="center">Status</h4>
            <div class="card-body">
                <p class="card-text" align="center">Admin making changes in develop</p>
                <%--<div class="status-check"> 
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Check me out</label>
                </div>--%>

                <div class="status-check">
                    <select  name="avatar" class="browser-default custom-select">
                        <option value="avatars">Actions</option>
                        <option value="avatars/avatar-4.jpg">Assign to me</option>
						<option value="avatars/avatar-1.jpg">CM Failed</option>
						<option value="avatars/avatar-2.jpg">Change implented in preprod</option>
						<option value="avatars/avatar-3.jpg">Change implemented in prod</option>
						
					</select>
                </div>
                <div align="center">
                    <br />
                   <a href="#" class="btn btn-secondary" align="center">Submit</a>
                </div>
                 
            </div>
            
        </div> 
      </div>
            <%-- <div class="col-lg-1 mb-4">
                 </div>--%>
      <div class="col-lg-7 form-data">
        <h2 align="center">CM #1905 - Update Create Person Workflows for UG Transfer</h2>
          <br />
          
        <div class="row">
            <h4>Request Type: Workflow</h4><br />
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
                <p><b>Admin Name:</b></p>
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
                <p> All 4 Create Person WFs for UG Transfer</p>
            </div>
         </div>
        <div class="row">
            <div class="col-lg-6">
                <p><b>Entity:</b></p>
            </div>
            <div class="col-lg-6">
                <p> UG Transfer Staging</p>
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
            <h4>Screenshots & Submission</h4><br />
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
                <p><a href="">File 1https://drive.google.com/open?id=1gomIbt8yJA2pn0xY06-
                    PxS5AZFHYmP2k
                    File 2https://drive.google.com/open?id=1hV2JPhOHB47aEy7clxsPuWOiDbad0Ze
                    File 3https://drive.google.com/open?id=1L--
                    Dnd6dLVQGhCP3hbkZ5Rs-z0iwJUwm
                    File 4https://drive.google.com/open?
                    id=16nZJaBWjqmG5642crodKkUYnHYhfJE2U
                    </a></p>
            </div>
        </div>
          <div class="row">
            <div class="col-lg-6">
                <p><b>Desired Date for Move</b></p>
            </div>
            <div class="col-lg-6">
                <p>December 10, 2019</p>
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
                <a href="#" class="btn btn-secondary" align="center">Download</a>
            </div>
        </div>
          <br />
          <br />
      </div>
         <div class="col-lg-3"  style="height: 400px; padding-left:0;">
            <h4 align="center">Comments</h4>
              <div class="card h-100">
           
            <div class="card-body overflow-auto" >
                <p class="card-text">Admin   <br />
                    <span class="comment-time">[10/17/2019 4:42 PM]</span>  <br />
                <span class="comment-text">Was this the first submission of this form? It looks like we may have completed this two weeks ago.</span>
                </p>
                <hr>
                 <p class="card-text">Jane Doe  <br />
                    <span class="comment-time">[10/19/2019 6:42 PM]</span>  <br />
                <span class="comment-text">The form submitted two weeks ago was similar, but we actually need a few things added so this is a new submission request.</span>
                 </p>
                <hr> 
                <p class="card-text">Admin   <br />
                    <span class="comment-time">[10/20/2019 11:40 AM]</span>  <br />
                <span class="comment-text">Can you provide the CM# for that request?</span></p>

                 <hr>
                 <p class="card-text">Jane Doe  <br />
                    <span class="comment-time">[10/20/2019 1:12 PM]</span>  <br />
                <span class="comment-text">Sure, it was #9127</span>
                 </p>
            </div>
            <div class="card-footer">
                 <div class="control-group form-group">
                <div class="controls">
                  <textarea rows="1" cols="100" class="form-control" id="message" required data-validation-required-message="Please enter your message" maxlength="99" style="resize:"></textarea>
                </div>
              </div>
                <a href="#" class="btn btn-secondary" align="center">Comment</a>
            </div>
        </div> 
      </div>
    </div>
    <!-- /.row -->

    </div>

    <script>
        $(document).ready(function () {
            $(".dropdown-toggle").dropdown();
        });
    </script>
</asp:Content>
