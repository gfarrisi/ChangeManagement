<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserRequests.aspx.cs" Inherits="ChangeManagementSystem.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <nav class="navbar fixed-top navbar-expand-lg navbar-dark navbar-custom fixed-top navbar-custom">
        <a class="navbar-brand " href="UserDashboard.aspx">
            <img src="T.png" alt="" width="40">
        </a>
        <a class="navbar-brand" href="UserDashboard.aspx">CRM Recruit: Change Management</a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
            <ul class="navbar-nav ml-auto">

                <li class="nav-item">
                    <a class="nav-link" href="UserDashboard.aspx">Dashboard</a>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="CM.aspx" id="navbarDropdownBlog" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <asp:Label runat="server" ID="lblUserName" Text="Default"></asp:Label>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownBlog">
                        <a class="dropdown-item" href="Login.aspx">Logout</a>
                    </div>
                </li>
            </ul>
        </div>

    </nav>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="scriptman" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="container mt-5" style="height: 100%;">
            <h2 id="requestHistory">Your Request History</h2>
           
                <div class="gv">
                    <asp:HiddenField runat="server" ID="hf" ClientIDMode="Static" />
                    <asp:GridView ID="gvUserRequests" runat="server" CssClass="datatable" AutoGenerateColumns="False" BorderColor="#CCCCCC" AllowPaging="false" OnRowDataBound="gvUserRequests_RowDataBound">
                        <HeaderStyle BackColor="#333333" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CMID" ItemStyle-CssClass="thead-dark" HeaderText="CM ID" ReadOnly="true" SortExpression="CMID">
                                <ItemStyle CssClass="font-weight-bold" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CMProjectName" ItemStyle-CssClass="thead-dark" HeaderText="CM Project Name" ReadOnly="true" SortExpression="CMProjectName" />
                            <asp:TemplateField ItemStyle-CssClass="thead-dark" HeaderText="Assigned Admin" SortExpression="AdminLastName">
                                <ItemTemplate>
                                    <%# Eval("AdminFirstName") + " " + Eval("AdminLastName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="thead-dark" HeaderText="Submitted By:" SortExpression="LastName">
                                <ItemTemplate>
                                    <%# Eval("FirstName") + " " + Eval("LastName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="RequestTypeName" HeaderText="Type" ReadOnly="true" SortExpression="RequestTypeName" />
                            <asp:BoundField DataField="CMStatus" HeaderText="Status" ReadOnly="true" SortExpression="CMStatus" />
                            <asp:BoundField DataField="LastUpdateDate" HeaderText="Last Updated Date" ReadOnly="true" DataFormatString="{0:MM/dd/yyyy}" SortExpression="LastUpdateDate" />
                            <asp:TemplateField HeaderText="View Request" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="btn" BorderStyle="None" ID="btnCheck" runat="server" OnClick="btnCheck_Click"><i class='far fa-eye'></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
            </div>

            <button onclick="exportTableToCSV('Requests.csv')" class="btn btnDownload mt-4">Export Table to CSV File</button>

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
                                                <asp:LinkButton runat="server" ID="btnLink2" Visible="false" OnClick="btnLink2_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment2Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink3" Visible="false" OnClick="btnLink3_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment3Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink4" Visible="false" OnClick="btnLink4_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment4Name") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnLink5" Visible="false" OnClick="btnLink5_Click"><%# DataBinder.Eval(Container.DataItem, "Attachment5Name") %></asp:LinkButton>
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
    </form>
    <script>
        function RecordClickedCM(t) {
            var row = t.parentElement.parentElement.rowIndex;
            var userID = document.getElementById('CPH1_gvAllUsers_hdnfldVariable_' + (row - 1)).value;
            $("#hf").val(String(userID))
        }

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
            $('.datatable').DataTable({
                "scrollY": "800px",
                "scrollCollapse": true
            });
        });
    </script>

</asp:Content>
