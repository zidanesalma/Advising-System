<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Phone.aspx.cs" Inherits="AdvisingSystem.Student.Phone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add phone number(s)
        </div>
        <p>
            <asp:TextBox ID="phones" placeholder="Enter phone numbers (separated with commas)" width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="add" runat="server" Text="Add" OnClick="Add_Click" Height="35px" Width="155px" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>
        </div>
    </form>
</body>
</html>
