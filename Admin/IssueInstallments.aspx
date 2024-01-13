<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueInstallments.aspx.cs" Inherits="project.IssueInstallments" %>

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
            <asp:DropDownList ID="paymentid" runat="server" Height="40px" Width="355px" OnSelectedIndexChanged="paymentid_SelectedIndexChanged">
            </asp:DropDownList>
            </p>
            <p>
            <asp:Button ID="Button1" runat="server" Text="Enter" Height="35px" Width="155px" OnClick="Button1_Click" />
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
