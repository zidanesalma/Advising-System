<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseInstructor.aspx.cs" Inherits="AdvisingSystem.ChooseInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/></head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:DropDownList ID="DropDownList1" placeholder="Choose a Course" AutoPostBack="True" OnSelectedIndexChanged="ddlFirst_SelectedIndexChanged" runat="server"  Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:DropDownList ID="DropDownList2" runat="server" placeholder="Choose Instructor" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:DropDownList ID="DropDownList3"  runat="server" placeholder="Choose Semester" Height="40px" Width="355px">
                </asp:DropDownList>
            </p>

            <p>
                <asp:Button ID="Choose" runat="server" OnClick="chooseInstructor" Height="35px" Width="155px" Text="Choose" />
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
