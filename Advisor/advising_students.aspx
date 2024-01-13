<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advising_students.aspx.cs" Inherits="Advising_System.advising_students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="noAlign.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id ="table1" runat="server">
                <tr>                    
                    <th>Student ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Password</th>            
                    <th>GPA</th>                    
                    <th>Major</th>
                    <th>Email</th>
                    <th>Faculty</th>
                    <th>Financial Status</th>
                    <th>Semester</th>
                    <th>Acquired Hours</th>
                    <th>Assigned Hours</th>
                    <th>Advisor ID</th>
                </tr>
            </table>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="advisingStudents" Width="200px" Height="35px" Text="View All Advising Students" />
            </p>   
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdvisorPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>