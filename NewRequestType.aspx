<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewRequestType.aspx.cs" Inherits="ChangeManagementSystem.NewRequestType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <a class="navbar-brand " href="AdminDashboard.aspx">
            <img src="T.png" alt="" width="40">
        </a>
        <a class="navbar-brand" href="AdminDashboard.aspx">CRM Recruit: Change Management</a>
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
                        <a class="dropdown-item" href="EditEmail.aspx">Edit Emails</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownBlo" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <asp:Label runat="server" ID="lblUserName" Text="Default"></asp:Label>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <br />

        <div class="mt-5">
            <div class="row mt-5">
                <div class="col-3"></div>

                <div class="col-6 p-5" style="background-color: rgba(0,0,0,.03); box-shadow: 0 0 12px 1.5px #808080;">
                    <h2 id="requestHistory" class="mb-5 ">New Request Type</h2>
                    <div style="margin: 0 auto; max-width: 600px;">
                        <div class="row mt-3 mb-3">
                            <div class="col-lg-5 ml-3">
                                <asp:Label runat="server" CssClass="form-text font-weight-bold">Request Type Name</asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtRequestName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="margin: 0 auto; max-width: 600px;">
                        <asp:Panel ID="pnlNewRequestType" runat="server">
                        </asp:Panel>
                        <div id="newRequestType_container" runat="server"></div>
                    </div>
                    <div class="form-row mt-5">
                        <div class="col-lg-5"></div>
                        <div class="col-lg-4">
                            <button type="button" class="btn btn-secondary mt-5" data-toggle="modal" data-target="#mdlAddQuestion" id="btnAddQuestion" onclick="clearModal()" data-whatever="@fat">Add Question</button>
                        </div>
                    </div>
                    <div style="margin: 0 auto; max-width: 600px;">
                        <asp:Panel ID="panelScreenshots" CssClass="mt-5" runat="server">

                            <asp:Label ID="lblHeading" runat="server" Text="Screenshots & Submission" CssClass="form-text h4"></asp:Label>
                            <div class="row mt-3 mb-3">
                                <div class="col-lg-5 ml-3">
                                    <asp:Label ID="lblDesc" runat="server" Text="Detailed description of change" CssClass="form-text"></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtDescResponse" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 mb-3">
                                <div class="col-lg-5 ml-3">
                                    <asp:Label ID="lblUpload" runat="server" Text="Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots. (Maximum of 5)" CssClass="form-text"></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <asp:FileUpload ID="fuScreenshots" CssClass="form-control-file" runat="server" ClientIDMode="Static" Enabled="false"></asp:FileUpload>
                                </div>
                            </div>
                            <div class="row mt-3 mb-3">
                                <div class="col-lg-5 ml-3">
                                    <asp:Label ID="lblDesiredDate" runat="server" Text="Desired date of completion" CssClass="form-text"></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtDesiredDate" CssClass="form-control" runat="server" TextMode="Date" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 mb-3">
                                <div class="col-lg-5 ml-3">
                                    <asp:Label ID="lblQuesCom" runat="server" Text="Questions/Comments" CssClass="form-text"></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtQuesCom" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-lg-4"></div>
                <div class="col-lg-8">
                    <%--<asp:RequiredFieldValidator runat="server" Font-Size="Large" ID="reqRequestName" CssClass="ml-5" ControlToValidate="txtRequestName" ForeColor="DarkRed" ErrorMessage="*Please enter the requests type name." />--%>
                </div>
            </div>
            <div class="row">
                 <div class="col-lg-12" style="text-align: center;">
                     <asp:Label ID="Label2" runat="server" Text="* WARNING: Request types cannot be deleted once added to the CRM system. Please review your new request type carefully to ensure correct data entry." Visible="true" ForeColor="DarkOrange" CssClass="col-form-label"></asp:Label>
                     <br />
                     <br />
                     <asp:Label ID="lblRequestTypeNameError" runat="server" Text="* Please enter a request type name before submitting" Visible="false" ForeColor="DarkRed" CssClass="col-form-label"></asp:Label>
                </div>

            </div>
            <div class="row">
                <div class="col-lg-5"></div>
                <div class="col-lg-7">
                    <asp:Button BackColor="#9D2235" ForeColor="#ffffff" CssClass="btn btn-secondary mt-5 ml-3" BorderStyle="None" ID="btnSubmit" runat="server" Text="Create new request type" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
          <asp:HiddenField ClientIDMode="Static" ID="hfClearModal" Value="true" runat="server" />
        <!-- Modal -->
        <div class="modal fade" id="mdlAddQuestion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">New Question</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label">Control Type:</label>
                                                  
                             <%--<asp:Label ID="lblControlTypeError" runat="server" Text="* Please select a control type" Visible="false" ForeColor="DarkRed" CssClass="col-form-label"></asp:Label>--%>
                        <%--    <label class="col-form-label hide" >* Please select a control type</label>--%>
                            <br />
                            <select id="control-type" class="form-control" name="control-type" onchange="chgControlType()">
                                <option value="--">--</option>
                                <option value="Dropdown">Dropdown</option>
                                <option value="RadioButton">Radio Button</option>
                                <option value="TextBox">TextBox</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="col-form-label">Control Text/Question:</label><br />
                             <%--<asp:Label ID="lblControlTextError" runat="server" Text="* Please enter a control text/question" Visible="false" ForeColor="DarkRed" CssClass="col-form-label"></asp:Label>--%>
                            <%--<label class="hide">* Please enter a control name</label>--%>
                           <%--  <asp:TextBox ID="txtControl" runat="server" Text="" CssClass="form-control"></asp:TextBox>--%>
                            <input type="text" class="form-control" id="control-text" name="control-text">
                        </div>
                        <div id="option-container" class="d-none form-group">
                            <label for="message-text" class="col-form-label">Options:</label>
                            <div id="options">
                                <div id="Option 1">
                                    <input type="text" class="form-control mb-2" style="width: 95%; display: inline;" id="control-option" onchange="addOptionsToSession()" placeholder="Option 1">
                                    <i id="1"></i>
                                </div>
                            </div>
                            <div class="form-group" id="addOption">
                                <button type="button" class="form-control" style="text-align: left; width: 95%;" id="btnAddOption" onclick="addOption()">Add Option</button>
                            </div>
                            <%--<button type="button" class="btn btn-secondary float-right">Confirm Options</button>--%>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="closeModal()">Close</button>
                        <button type="submit" class="btn btn-primary" id="btnAdd" runat="server" onserverclick="btnAdd_ServerClick">Add</button>
                    </div>
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
                                Your new request type has been created.<br />
                                The new request will now be accessible for both users and admins through the dashboard.</label>
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

        function edit(renderedID) {
            //alert("clicked");
            console.log(renderedID)
            var id = renderedID.split("__")
            var questionID = id[1];
            // console.log(questionID)

            console.log("outside loop", questionID)
            // Get saved data from sessionStorage
            var requestSessionValue = '<%=Session["request"]%>'
            const requestObj = JSON.parse(requestSessionValue);
            let newRequestObj = requestObj.filter(item => (item.Question_ID !== parseInt(questionID, 10)))
            console.log("new request obj", newRequestObj)
            // all custom jQuery will go here
            if ($.cookie('token') == null) {
                var json = JSON.stringify(newRequestObj);
                console.log(json);
                $.cookie('newRequestObj', json);
            } else {
                var json = JSON.stringify(newRequestObj);
                console.log(json);
                $.cookie('newRequestObj', json);
            }
            $.cookie('EditedItem', true);
            requestObj.forEach(function (obj) {

                if (obj.Question_ID == questionID) {

                    $("#control-text").val(obj.Question_Text);
                    console.log("in loop id", obj.Question_ID)
                    console.log(obj.Question_Control)
                    console.log(obj.Question_Text)
                    $("#control-type").val(obj.Question_Control);

                    var optionContainer = document.getElementById("option-container");
                    var controlType = document.getElementById("control-type").value;
                    if (controlType == "Dropdown" || controlType == "RadioButton") {
                        optionContainer.classList.add("d-block");
                        optionContainer.classList.remove("d-none");
                    }
                    else {
                        optionContainer.classList.remove("d-block");
                        optionContainer.classList.add("d-none");
                    }
                    $('#mdlAddQuestion').modal('show')
                      //document.getElementById("isModalOpen").value = "true";
                }
                else {
                    console.log("not correct id ", obj.Question_ID)
                }
            });

        }

        function deleteQuestion(renderedID) {
            //alert("clicked");
            console.log(renderedID)
            let id = renderedID.split("__")
            let questionID = id[1];
            // console.log(questionid)

            console.log("outside loop", questionID)
            // get saved data from sessionstorage
            let requestSessionValue = '<%=Session["request"]%>'

            const requestObj = JSON.parse(requestSessionValue);

            let newRequestObj = requestObj.filter(item => (item.Question_ID !== parseInt(questionID, 10)))
            console.log("new request obj", newRequestObj)
            // all custom jQuery will go here
            if ($.cookie('token') == null) {
                var json = JSON.stringify(newRequestObj);
                console.log(json);
                $.cookie('newRequestObj', json);
            } else {
                var json = JSON.stringify(newRequestObj);
                console.log(json);
                $.cookie('newRequestObj', json);
            }

            // $.cookie('newRequestObj', JSON.stringify(newRequestObj));

            var requestCookie = JSON.parse($.cookie("newRequestObj"));
            console.log(requestCookie);



            $.cookie('DeletedItem', true);

            var cookie = $.cookie("DeletedItem");
            console.log(cookie);

            location.reload();

        }
        
        function closeModal() {
            document.getElementById("hfClearModal").value = "true";
        }


    </script>


</asp:Content>
