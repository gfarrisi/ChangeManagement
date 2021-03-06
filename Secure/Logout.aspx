<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="ChangeManagementSystem.Secure.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <!--Supporting 1:1 ratio for smaller screens (mobile support)-->
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--Referencing Bootstrap JS/CSS CDNs with integrety and security-->
    <link id="Link1" runat="server" rel="shortcut icon" href="Resources/favicon.ico" type="image/x-icon" />
    <link id="Link2" runat="server" rel="icon" href="Resources/favicon.ico" type="image/ico" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" integrity="sha384-3ceskX3iaEnIogmQchP8opvBy3Mi7Ce34nWjpBIwVTHfGYWQS9jwHDVRnpKKHJg7" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <style type="text/css">
        body {
            padding-top: 5rem;
        }

        .starter-template {
            padding: 3rem 1.5rem;
        }

        p, ul {
            font-size: 15pt;
        }
    </style>

</head>
<body>
    <div id="navBar">
        <nav class="navbar-temple navbar-fixed-top">
            <div class="navbar-header">
                <a id="logoLink" runat="server" class="navbar-brand" href="default.aspx">Cancel Logout</a>
            </div>
        </nav>
    </div>
    <form runat="server">
    <div class="container" runat="server">
        <div id="content" class="starter-template">
            <div class="col-md-2 col-lg-2"></div>
            <div class="col-sm-12 col-md-8 col-lg-8">
                <h1>Local Logout</h1>
                <hr />
                <p>Status of Local Logout: Logout completed successfully.</p>
                <ul>
                    <li>You <b>MUST</b> close your browser to complete the local logout process.</li>
                    <br />
                    <br />
                    <b>OR:</b>
                    <br />
                    <br />
                
                </ul>
            </div>
            <div class="col-md-2 col-lg-2"></div>
        </div>
    </div>
        </form>
</body>

</html>
