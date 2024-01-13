<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertGP.aspx.cs" Inherits="Advising_System.insertGP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="sem_code" placeholder="Enter semester code" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:TextBox ID="sem_credit_hrs" placeholder="Enter semester credit hours" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="exp_grad_sem" placeholder="Enter expected graduation date" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="advisor_id" placeholder="Enter advisor id" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="student_id" placeholder="Enter student id" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="insert" runat="server" OnClick="insertGradPlan" Width="155px" Height="35px" Text="Insert graduation plan" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
