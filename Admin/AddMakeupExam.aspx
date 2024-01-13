<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMakeupExam.aspx.cs" Inherits="project.AddMakeupExam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
        <asp:DropDownList ID="Type" runat="server" Height="40px" Width="355px" OnSelectedIndexChanged="Type_SelectedIndexChanged">
        </asp:DropDownList>
        </p>
        <p>
        <asp:TextBox ID="Date" placeholder="Enter the Date YYYY/MM/DD" runat="server" Height="40px" Width="355px"></asp:TextBox>
        </p>
        <p>
        <asp:TextBox ID="CourseID" runat="server" Height="40px" Width="355px" placeholder="Enter Course ID" ></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Button1" runat="server" Height="35px" Width="155px" Text="Create" OnClick="Button1_Click" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>

    </form>
</body>
</html>
