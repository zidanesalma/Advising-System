﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPaymentStudents.aspx.cs" Inherits="project.ViewPaymentStudents" %>

<p>
    <br />
</p>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView ID="ResultTable" runat="server"></asp:GridView>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>

