<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="AdvisingSystem.StudentRegister" %>

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
            <asp:Label ID="label" runat="server" Text="Fill Out Your Information" style="font-size:16pt; font-family: 'Arial, sans-serif'; font-weight: bold;"></asp:Label>
            </p>
            <p>
            <asp:TextBox ID="fname" placeholder= "First Name" runat="server" Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>           
            <asp:TextBox ID="lname" placeholder= "Last Name" runat="server"  Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
            <asp:TextBox ID="pass" placeholder= "Password" runat="server" Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
            <asp:TextBox ID="fac" placeholder= "Faculty" runat="server"  Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
            <asp:TextBox ID="email" placeholder= "Email" runat="server" Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
            <asp:TextBox ID="major" placeholder= "Major" runat="server" Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
            <asp:TextBox ID="sem" placeholder= "Semester" runat="server" Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
            <asp:Button ID ="Register" Text="Register" Height="35px" Width="155px" runat="server" OnClick="Reg"></asp:Button>
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="StudentLogin.aspx"  style="font-size:12pt; color: blue; text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>

</body>
</html>
