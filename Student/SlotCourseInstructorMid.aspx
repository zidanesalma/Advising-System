<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlotCourseInstructorMid.aspx.cs" Inherits="AdvisingSystem.SlotCourseInstructorMid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:DropDownList ID="DropDownList1"  placeholder="Choose a Course" AutoPostBack="True" OnSelectedIndexChanged="ddlFirst_SelectedIndexChanged" runat="server"  Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:DropDownList ID="DropDownList2"  runat="server" placeholder="Choose an Instructor" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                &nbsp;
            </p>
            <asp:Button ID="View" runat="server" OnClick="ok" Text="View" Height="35px" Width="155px" />
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
