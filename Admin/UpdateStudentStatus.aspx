<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudentStatus.aspx.cs" Inherits="project.UpdateStudentStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" type="text/css" href="style.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
            <asp:TextBox ID="studentid" placeholder="Enter the Student ID" Height="40px" Width="355px" runat="server"></asp:TextBox>
            </p>
            <p>
            <asp:Button ID="Button1" runat="server" Height="35px" Width="155px" OnClick="Button1_Click" Text="Update Status" />
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
