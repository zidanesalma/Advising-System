<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminResult.aspx.cs" Inherits="AdvisingSystem.AdminResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="ResultTable" runat="server"></asp:GridView>
    </form>
    <div id="backButton">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

    </div>

</body>
</html>

