<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advisorRegister.aspx.cs" Inherits="Advising_System.AdvisorRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="label" runat="server" Text="Fill Out Your Information" Style="font-size: 20pt; font-family: 'Arial, sans-serif'; font-weight: bold;"></asp:Label>
        </div>
        <p>
            <asp:TextBox ID="advisor_name" placeholder="Enter name" runat="server" Width="355px" Height="40px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="pass" placeholder="Enter password" runat="server" Width="355px" Height="40px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="advisor_email" placeholder="Enter email" runat="server" Width="355px" Height="40px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="advisor_office" placeholder="Enter office" runat="server" Width="355px" Height="40px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="advisorRegisteration" OnClick="advisor_registeration" runat="server" Width="155px" Height="35px" Text="Register" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
