<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGPadvisors.aspx.cs" Inherits="project.ViewGPadvisors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="ResultTable" runat="server">
            </asp:GridView>
        </div>

        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
