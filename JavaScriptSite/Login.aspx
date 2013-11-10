<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JavaScriptSite.Login" %>

<!DOCTYPE>

<html>
<head runat="server">
    <title>Login in to the JavaScript Test taking site</title>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
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
        <div id="myDiv">
            <p>Please enter your username and password to login in.</p>
            <p>UserName: <input type="text" name="userName" value="" /></p>
            <p>Password: <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" /></p>
            <p style="float: right;">
                <asp:Button Text="Login In" runat="server" ID="btnLoginIn" OnClick="btnLoginIn_Click" />
            </p>
        </div>
    </form>
</body>
</html>
