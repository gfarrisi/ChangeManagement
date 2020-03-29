<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllRequests.aspx.cs" Inherits="ChangeManagementSystem.ViewAllRequests" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">

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
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="scriptman" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="container mt-5" style="height: 100%;">
            <h2 id="requestHistory">Request History</h2>
            <div class="card mb-4 w-50" id="searchBar">
                <div class="input-group">
                    <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" placeholder="Search for..."></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button CssClass="btn btn-dark" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                    </span>
                </div>
            </div>
            <div style="overflow-y: scroll; height: 500px;">
                <div class="gv">
                    <asp:HiddenField runat="server" ID="hf" ClientIDMode="Static" />
                    <asp:GridView ID="gvAllRequests" runat="server" CssClass="table" OnRowDataBound="gvAllRequests_RowDataBound" AutoGenerateColumns="False" AllowSorting="True" BorderColor="#CCCCCC" OnSorting="OnSorting" PageSize="10" AllowPaging="True" OnPageIndexChanging="gvAllRequests_PageIndexChanging">
                        <HeaderStyle BackColor="#333333" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CMID" ItemStyle-CssClass="thead-dark" HeaderText="CMID" SortExpression="CMID">
                                <ItemStyle CssClass="font-weight-bold" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CMProjectName" ItemStyle-CssClass="thead-dark" HeaderText="CM Project Name" SortExpression="CMProjectName" />
                            <asp:TemplateField ItemStyle-CssClass="thead-dark" SortExpression="LastName" HeaderText="User">
                                <ItemTemplate>
                                    <%# Eval("FirstName") + " " + Eval("LastName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                            <asp:BoundField DataField="College" HeaderText="College" SortExpression="College" />
                            <asp:BoundField DataField="RequestTypeName" HeaderText="Type" SortExpression="RequestTypeName" />
                            <asp:BoundField DataField="CMStatus" HeaderText="Status" SortExpression="CMStatus" />
                            <asp:BoundField DataField="LastUpdateDate" HeaderText="Last Updated Date" DataFormatString="{0:MM/dd/yyyy}" SortExpression="LastUpdateDate" />
                            <asp:TemplateField HeaderText="View Request" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="btn" BorderStyle="None" ID="btnCheck" runat="server" OnClick="btnCheck_Click"><i class='far fa-eye'></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" />
                    </asp:GridView>
                </div>
            </div>
            <button onclick="exportTableToCSV('Requests.csv')" class="btn btnDownload mt-1">Export Table to .CSV File</button>
        </div>

        <br />
        <br />
        <br />

        <!-- Modal -->
        <div class="modal fade bd-example-modal-lg" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header" align="center">
                        <asp:Repeater ID="rptModalHeader" runat="server">
                            <ItemTemplate>
                                <h5 runat="server" class="modal-title" id="exampleModalLongTitle"><%# "CM: " + DataBinder.Eval(Container.DataItem, "CMID") + " - " + DataBinder.Eval(Container.DataItem, "CMProjectName") %></h5>
                                <asp:HiddenField ID="hiddenTitle" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMProjectName") %>' />
                            </ItemTemplate>
                        </asp:Repeater>
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
                                        <asp:Repeater ID="rptCMStatus" runat="server" OnItemDataBound="rptCMStatus_ItemDataBound">
                                            <ItemTemplate>
                                                <h4 runat="server"><%# "Status: " + DataBinder.Eval(Container.DataItem, "CMStatus") %></h4>
                                                <asp:HiddenField ID="hiddenCMStatus" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CMStatus") %>' />
                                                <div class="progress">
                                                    <div runat="server" id="progressBar" class="progress-bar bg-success" role="progressbar"></div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3 mb-2"></div>
                                            <div class="col-lg-6">
                                                <div class="status-check">
                                                    <asp:Label ID="lblCMStatus" runat="server">Update Status</asp:Label>
                                                    <asp:DropDownList class="browser-default custom-select" ID="ddlCMStatus" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-12 form-data">
                                <asp:Repeater ID="rptRequestInfo" runat="server">
                                    <ItemTemplate>
                                        <div class="row" runat="server">
                                            <h4 runat="server"><%# "Request Type: " + DataBinder.Eval(Container.DataItem, "RequestTypeID") %></h4>
                                            <br />
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Name:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")  %></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Email address:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "Email")%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>College:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "College")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rptAdminName" runat="server">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Assigned To:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")  %></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Workflow/Process Name:</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p runat="server"><%# DataBinder.Eval(Container.DataItem, "CMProjectName")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rptResponse" runat="server">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b><%# DataBinder.Eval(Container.DataItem, "QuestionText")%></b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "QuestionResponse")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <br />
                                <div class="row">
                                    <h4>Screenshots & Submission</h4>
                                    <br />
                                </div>
                                <br />
                                <asp:Repeater ID="rptScreenshots" runat="server" OnItemDataBound="rptScreenshots_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Detailed Description of Change</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "DetailDescription")%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:LinkButton runat="server" ID="btnLink1" OnClick="btnLink1_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment1Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink2" OnClick="btnLink2_Click" Visible="false"><%# DataBinder.Eval(Container.DataItem, "Attachment2Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink3" OnClick="btnLink3_Click" Visible="false"><%# DataBinder.Eval(Container.DataItem, "Attachment3Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink4" OnClick="btnLink4_Click" Visible="false"><%# DataBinder.Eval(Container.DataItem, "Attachment4Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink5" OnClick="btnLink5_Click" Visible="false"><%# DataBinder.Eval(Container.DataItem, "Attachment5Name") %></asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Desired Date for Move</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "DesiredDate")%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <p><b>Questions/Comments</b></p>
                                            </div>
                                            <div class="col-lg-6">
                                                <p><%# DataBinder.Eval(Container.DataItem, "Question/Comments")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                            <div class="col-lg-11 mb-7" style="height: 50%; padding-left: 0;">
                                <h4 class="mb-3 ml-1 mt-3">Comments</h4>
                                <div class="card ">
                                    <div class="card-body" style="height: 20rem; overflow-y: scroll;">
                                        <asp:Panel ID="pnlNoComments" runat="server">
                                            <p class="pt-3 pb-5">
                                                There are no existing comments
                                            </p>
                                        </asp:Panel>
                                        <%--<asp:Panel ID="pnlComments" runat="server">--%>
                                        <asp:UpdatePanel ID="pnlComments" style="width: 100%" runat="server">
                                            <ContentTemplate>
                                                <%--<asp:Timer ID="tmComments" OnTick="tmComments_Tick" runat="server" Interval="3000" />--%>
                                                <asp:Repeater ID="rptComments" runat="server">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="Label6" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Info"></asp:Label>--%>
                                                        <%--<asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />--%>
                                                        <p class="card-text">
                                                            <asp:Label ID="lbCommentName" CssClass="" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserType") + ": " + DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:Label>
                                                            <br />
                                                            <span class="comment-time">
                                                                <asp:Label ID="lbCommentTime" runat="server" Font-Italic="true" CssClass="" Text='<%# DataBinder.Eval(Container.DataItem, "LastUpdateDate") %>'></asp:Label>
                                                            </span>
                                                            <br />
                                                            <span class="comment-text">
                                                                <asp:Label ID="lbCommentText" runat="server" Font-Italic="true" CssClass="" Text='<%# DataBinder.Eval(Container.DataItem, "CommentText") %>'></asp:Label>
                                                            </span>
                                                        </p>
                                                        <hr />
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rptComments" EventName="ItemDataBound" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <%--</asp:Panel>--%>
                                    </div>
                                    <div class="card-footer">
                                        <div class="control-group form-group">
                                            <div class="controls">
                                                <asp:TextBox ID="txtNewComment" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                <%--<textarea rows="1" cols="100" class="form-control" id="message" data-validation-required-message="Please enter your message" maxlength="99"></textarea>--%>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnNewComment" Text="Comment" runat="server" CssClass="btn btn-secondary" OnClick="btnNewComment_Click" />
                                        <%--<a href="#" class="btn btn-secondary" align="center">Comment</a>--%>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer mt-5">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnClose">Close</button>
                        <asp:Button runat="server" ID="btnDownloadAsPDF" CssClass="btn btn-secondary" style="background-color:#8C2132" Text="Download As PDF" CausesValidation="false" OnClick="btnDownloadAsPDF_Click" />
                        <asp:Button runat="server" class="btn btn-primary" ID="btnSave" Text="Save changes" OnClick="btnSave_Click"></asp:Button>
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

          <!-- Modal data-toggle="modal" data-target="#warningModal"-->
        <div class="modal fade" id="mdlCMAttachment" tabindex="-1" role="dialog" aria-labelledby="mdlCMAttachment" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="mdlCMAttachmentLabel">Attachment Download</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <label id="Label1" style="line-height: 50px;" runat="server">The attachment has been downloaded!</label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAttachment" CssClass="btn btn-secondary" BorderStyle="None" OnClick="btnAttachment_Click" Text="Close" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.1/js/jquery.tablesorter.min.js" integrity="sha256-uC1JMW5e1U5D28+mXFxzTz4SSMCywqhxQIodqLECnfU=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".dropdown-toggle").dropdown();
        });

        function RecordClickedCM(t) {
            var row = t.parentElement.parentElement.rowIndex;
            var userID = document.getElementById('CPH1_gvAllUsers_hdnfldVariable_' + (row - 1)).value;
            alert(userID);
            $("#hf").val(String(userID))
        }

        $("body").on("click", "#btnExport", function () {
            html2canvas($('[id*=gvAllRequests]')[0], {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("Table.pdf");
                }
            });
        });

        function exportTableToCSV(filename) {
            var csv = [];
            var rows = document.querySelectorAll("table tr");

            for (var i = 0; i < rows.length; i++) {
                var row = [], cols = rows[i].querySelectorAll("td, th");

                for (var j = 0; j < cols.length; j++)
                    row.push(cols[j].innerText);

                csv.push(row.join(","));
            }

            // Download CSV file
            downloadCSV(csv.join("\n"), filename);
        }
        function downloadCSV(csv, filename) {
            var csvFile;
            var downloadLink;

            // CSV file
            csvFile = new Blob([csv], { type: "text/csv" });

            // Download link
            downloadLink = document.createElement("a");

            // File name
            downloadLink.download = filename;

            // Create a link to the file
            downloadLink.href = window.URL.createObjectURL(csvFile);

            // Hide download link
            downloadLink.style.display = "none";

            // Add the link to DOM
            document.body.appendChild(downloadLink);

            // Click download link
            downloadLink.click();
        }

        $(document).ready(function () {
            $("#gvAllRequests").tablesorter();
        });
    </script>
</asp:Content>

