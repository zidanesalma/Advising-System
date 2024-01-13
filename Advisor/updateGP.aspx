<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateGP.aspx.cs" Inherits="Advising_System.updateGP" %>

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
            <asp:TextBox ID="expected_grad_date" placeholder="Expected Graduation Date" runat="server" Width="355px" Height="40px" ></asp:TextBox>
           </p>
           <p>
            <asp:TextBox ID="student_id" placeholder="Student ID" runat="server" Width="355px" Height="40px"></asp:TextBox>
           </p>
           <p>
           <asp:Button ID="insert" runat="server" Width="200px" Height="35px" OnClick="updateGradDate" Text="Update graduation plan" />
           </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
