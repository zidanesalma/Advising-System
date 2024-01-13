<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeUpsMid.aspx.cs" Inherits="AdvisingSystem.MakeUpsMid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>        
</head>

<body>
    <form id="form1" runat="server">
        <div class="button-container">
            <asp:Button ID="FirstMakeUp" runat="server" Height="35" Width="200" Text="First MakeUp" OnClick="FirstMakeUp_Click" />
            <asp:Button ID="SecondMakeUp" runat="server" Height="35" Width="200" Text="Second MakeUp" OnClick="SecondMakeUp_Click" />
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" >Back</asp:HyperLink>
        </div>
    </form>
</body>
</html>
