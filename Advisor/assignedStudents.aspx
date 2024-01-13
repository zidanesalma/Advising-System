<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="assignedStudents.aspx.cs" Inherits="project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="advisor" placeholder="Enter advisor id" Width="355px" Height="40px" runat="server"></asp:TextBox>

        </p>
        <p>
            <asp:TextBox ID="major" placeholder="Enter major" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="View_AssignedStudents" Width="155px" Height="35px" Text="View Assigned Students" />
        </p>
        <p>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>  
    </form>
</body>
</html>
