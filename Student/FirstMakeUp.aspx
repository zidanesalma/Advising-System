<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstMakeUp.aspx.cs" Inherits="AdvisingSystem.FirstMakeUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
            <p>
                <asp:DropDownList ID="DropDownList1"  runat="server" placeholder="Choose Course" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:DropDownList ID="DropDownList2"  runat="server"  placeholder="Choose Your Semester" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="RegisterFM" runat="server" OnClick="Register" Text="Register For First MakeUp" Height="35px" Width="200px" />
            </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
