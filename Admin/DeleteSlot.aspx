<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteSlot.aspx.cs" Inherits="project.DeleteSlot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <p>
        <asp:TextBox ID="semester" placeholder="Enter the Semester Code" Height="40px" Width="355px" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Button1" runat="server" Text="Delete Slots" Height="35px" Width="155px" OnClick="Button1_Click" />
        </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>

    </form>
</body>
</html>
