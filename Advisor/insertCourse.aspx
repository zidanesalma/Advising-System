<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertCourse.aspx.cs" Inherits="Advising_System.InsertCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="student_id" placeholder="Enter student id" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:TextBox ID="sem_code" placeholder="Enter semester code" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="course_name" placeholder="Enter course name" Width="355px" Height="40px" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="insert" runat="server" OnClick="insertCourses" Width="155px" Height="35px" Text="Insert course" />
        </p>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
