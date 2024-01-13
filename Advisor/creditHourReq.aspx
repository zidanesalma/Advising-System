<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creditHourReq.aspx.cs" Inherits="Advising_System.creditHourReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="requestID" placeholder="Enter request id" Width="355px" Height="40px" runat="server"></asp:TextBox>
        <p>
            <asp:TextBox ID="semesterCode" placeholder="Enter semester code" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="approveRejectCH" runat="server" Width="200px" Height="35px" OnClick="CreditHours_Request" Text="Approve/Reject Request" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
