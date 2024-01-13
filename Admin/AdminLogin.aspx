<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="AdvisingSystem.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>

</head>
<body>
    <form id="adminLoginForm" runat="server">
        <div>
        <p>
            <asp:Label ID="label1" runat="server" Text="Welcome to Admin Portal" style="font-size:20pt; font-family: 'Arial, sans-serif'; font-weight: bold;"></asp:Label>
        </p>
        <p></p>
        <p>
            <asp:TextBox ID="Id" placeholder="Admin ID" runat="server" Width="355" Height="40"></asp:TextBox>
        </p>
        <asp:TextBox ID="Password" placeholder="Password" type="password" Width="355" Height="40" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Login" runat="server" Text="Login" Width="155" Height="35" OnClick="Login_Click" />
        </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../IamA.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
