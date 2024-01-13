<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="AdvisingSystem.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div id="div1" runat="server">
            <p>
                <asp:TextBox ID="username" runat="server" Height = "40px" Width = "355px" placeholder= "Write Your ID"></asp:TextBox>
            </p>
            <p>
                <asp:TextBox ID="password" runat="server" Height = "40px" Width = "355px" placeholder= "Write Your Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="log" runat="server" OnClick="login" Text="Log In" Height="35px" Width="155px"></asp:Button>
            </p>
        </div>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Don't Have an Account?"></asp:Label>

            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="StudentRegister.aspx">Register</asp:HyperLink>
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../IamA.aspx" style="font-size:12pt; color: blue; text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
