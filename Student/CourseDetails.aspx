<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="AdvisingSystem.CourseDetails" %>

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
                    <th>Exam ID</th>
                    <th>Date</th>            
                    <th>Type</th>
                    <th>Course ID</th>                    
                    <th>Course Name</th>
                    <th>Course Semester</th>
                </tr>
            </table>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
