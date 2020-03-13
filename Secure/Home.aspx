<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ChangeManagementSystem.Secure.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script type="text/javascript" src="../Scripts/bootstrap-toggle.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            var result = AJAX_Demo_Mode("Home.aspx/GetDemoModeStatus");

            if (result.toLowerCase() === 'true') {
                $('#demo_mode').bootstrapToggle('on');
            }
            else if (result.toLowerCase() === 'false') {
                $('#demo_mode').bootstrapToggle('off');
            }
            else {
                alert(result);
            }
        });

        function ShowDictionary() {
            $(document).ready(function () {
                $('#Modal_Dictionary').modal('show');
            });
        }

        function ShowLDAP() {
            $(document).ready(function () {
                $('#Modal_LDAP').modal('show');
            });
        }

        function ShowStudent() {
            $(document).ready(function () {
                $('#Modal_Student').modal('show');
            });
        }

        function ShowAttributes() {
            $(document).ready(function () {
                $('#Modal_Attributes').modal('show');
            });
        }

        $(function () {
            $('#demo_mode').change(function () {
                var toggle = $(this).prop('checked');

                AJAX_Demo_Mode("Home.aspx/SetDemoModeStatus", toggle);
            });
        });


        function AJAX_Demo_Mode(url, param) {

            var input = "";

             if (param === true) {
                 input = "true";
            }
            else if (param === false) {
                 input = "false";
            }

            var json;
            $.ajax({
                type: "POST",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{toggle: "' + input + '"}',
                async: false,
                success: function (response) {
                    json = response.d;
                },
                failure: function (response) {
                    json = response.d;
                },
                error: function (error) {
                    json = error;
                }
            });
            return json;
        }


        //add your JS here
        //add your JS here
        //add your JS here
        //add your JS here
        //add your JS here
    </script>
    <style type="text/css">
        .navbar-brand {
            margin: 10px 0;
        }

        ul > li {
            margin: 10px 0;
            font-weight: bold;
        }

            ul > li > ul > li {
                margin: 0px 0;
                font-weight: 100;
            }

        /*add your CSS here*/
        /*add your CSS here*/
        /*add your CSS here*/
        /*add your CSS here*/
        /*add your CSS here*/
    </style>
    <link href="../Content/demo_mode.css" rel="stylesheet" />
    <link href="../Content/bootstrap-toggle.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
      <div>
          <h1>Hello</h1>
      </div>
    </form>
</body>
</html>
