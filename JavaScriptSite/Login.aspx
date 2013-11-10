<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JavaScriptSite.Login" %>

<!DOCTYPE>

<html>
<head runat="server">
    <title>Login in to the JavaScript Test taking site</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin: auto;">
            <p>User Name: <input type="text" name="userName" value="" /></p>
            <p>Password: <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" /></p>
        </div>
    </form>
</body>
</html>
