<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IamA.aspx.cs" Inherits="AdvisingSystem.IamA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Sign In As" style="font-size:20pt; font-family: 'Arial, sans-serif'; font-weight: bold;"></asp:Label>
        </div>
        <p></p>
        <p></p>
        <p></p>
        <p></p>
        <p></p>
        <p></p>
        <div class="button-container">
            <p></p>
            <p></p>
            <p></p>
            <asp:Button ID="Admin" runat="server" Height="35px" Width="200px" Text="Admin" OnClick="AdminP" />
            <asp:Button ID="Advisor" runat="server" Height="35px" Width="200px" Text="Advisor" OnClick="AdvisorP" />
        </div>
        <div>
            <p></p>
            <asp:Button ID="Student" runat="server" Height="35px" Width="200px" Text="Student" OnClick="StudentP" />
        </div>
    </form>
</body>
</html>
