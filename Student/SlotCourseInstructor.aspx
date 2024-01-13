<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlotCourseInstructor.aspx.cs" Inherits="AdvisingSystem.SlotCourseInstructor" %>

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
                    <th>Course ID</th>
                    <th>Course Name</th>            
                    <th>Slot ID</th>
                    <th>Slot Day</th>                    
                    <th>Slot Time</th>
                    <th>Slot Location</th>
                    <th>Insrtuctor ID </th>
                    <th>Instructor Name</th>
                </tr>
            </table>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentPortal.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>
    </form>
</body>
</html>
