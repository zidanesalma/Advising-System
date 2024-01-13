<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondMakeUp.aspx.cs" Inherits="AdvisingSystem.SecondMakeUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/></head>
<body>
    <form id="form1" runat="server">
            <p>
                <asp:DropDownList ID="DropDownList1" CssClass="searchableSelect" runat="server" placeholder="Choose Course" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:DropDownList ID="DropDownList2" CssClass="searchableSelect" runat="server"  placeholder="Choose Your Semester" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="RegisterSM" runat="server" OnClick="Register" Text="Register For Second MakeUp" Height="35px" Width="220px" />
            </p>
            <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>
            </div>
    </form>
</body>
</html>