<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCourseReq.aspx.cs" Inherits="Advising_System.addCourseReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="requestID" placeholder="Enter request id" runat="server" Width="355px" Height="40px"></asp:TextBox>

        </p>
        <p>
            <asp:TextBox ID="semesterCode" placeholder="Enter semester code" runat="server" Width="355px" Height="40px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="approveRejectCourse" runat="server" OnClick="Course_Request" Width="200px" Height="35px" Text="Approve/Reject Request" />

        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
