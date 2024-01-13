<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCourse.aspx.cs" Inherits="project.DeleteCourse" %>

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
                <asp:TextBox ID="courseID" placeholder="Enter Course ID" runat="server" Height="40px" Width="355px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Height="30px" Width="155px" OnClick="Move" Text="Delete Course"  />
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>

    </form>
</body>
</html>
