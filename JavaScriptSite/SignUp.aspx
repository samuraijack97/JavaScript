<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="JavaScriptSite.SignUp" %>

<!DOCTYPE>

<html>
<head id="Head1" runat="server">
    <title>Sign Up</title>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $('input[name=email]').blur(function () {
                var re = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!re.test($(this).val())) {
                    alert('not valid email');
                    return;
                }
            });
        });
    </script>
    <style type="text/css">
        #myDiv {
            position: fixed;
            top: 50%;
            left: 50%;
            margin-top: -9em; /*set to a negative number 1/2 of your height*/
            margin-left: -15em; /*set to a negative number 1/2 of your width*/
            border: 1px solid #ccc;
            background-color: #f3f3f3;
        }

        p {
            padding-left: 10px;
            padding-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin: auto;">
            <asp:Literal Text="" runat="server" ID="litMessage" />
        </div>
        <div id="myDiv">

            <p>Email:
                <input type="text" name="email" value="" /></p>
            <p>Password:
                <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" /></p>
            <p>Confirm Password:
                <asp:TextBox runat="server" TextMode="Password" ID="txtConfirmPassword" /></p>
            <p>FirstName:
                <input type="text" name="firstname" value="" /></p>
            <p>LastName:
                <input type="text" name="lastname" value="" /></p>
            <p>
                <asp:Button Text="Sign Up" runat="server" ID="btnSignUp" OnClick="btnSignUp_Click" />
            </p>

        </div>
    </form>
</body>
</html>
