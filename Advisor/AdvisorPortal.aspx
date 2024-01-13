<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorPortal.aspx.cs" Inherits="Advising_System.Home_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
            text-align: center;
        }

        Button {
            display: block;
            margin: auto;
            text-align: center;
        }

        #backButton {
            position: fixed;
            bottom: 30px; /* Adjust this value to set the distance from the bottom */
            left: 30px; /* Adjust this value to set the distance from the right */
            background-color: #b3e0ff; /* Example background color */
            color: #000000; /* Example text color */
            padding: 10px; /* Example padding */
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="label" runat="server" Text="Welcome to the University's Advising System" style="font-size:20pt; font-family: 'Arial, sans-serif'; font-weight: bold;"></asp:Label>
            </p>
            <p>
                <asp:Button ID="viewStudents" runat="server" Height="40px" Width="355px" OnClick="advisingStudents" Text="View Advising Students" />
            </p>
            <p>
                <asp:Button ID="insertGP" runat="server" Height="40px" Width="355px"  OnClick="insertGradPlan" Text="Insert GraduationPlan" />
            </p>
            <p>
                <asp:Button ID="insertCourse" runat="server" Height="40px" Width="355px"  OnClick="insertCourses" Text="Insert Courses" />
            </p>
            <p>
                <asp:Button ID="updateDate" runat="server" Height="40px" Width="355px" OnClick="updateGradDate" Text="Update GraduationDate" />
            </p>
            <p>
                <asp:Button ID="deleteCourse" runat="server" Height="40px" Width="355px"  OnClick="deleteCourses" Text="Delete Courses From Grad Plans" />
            </p>
            <p>
                <asp:Button ID="requests" runat="server" Height="40px" Width="355px"  OnClick="View_Requests" Text="View All Requests" />
            </p>
            <p>
                <asp:Button ID="pendingRequests" runat="server" Height="40px" Width="355px"  OnClick="View_pendingRequests" Text="View All Pending Requests" />
            </p>
            <p>
                <asp:Button ID="AssignedStudents" runat="server" Height="40px" Width="355px"  OnClick="View_AssignedStudents" Text="View Assigned Students" />
            </p>
            <p>
                <asp:Button ID="CHRequest" runat="server" Height="40px" Width="355px"  OnClick="CreditHours_Request" Text="Approve/Reject Extra Credit Hours Request" />
            </p>
            <p>
                <asp:Button ID="CourseRequest" runat="server" Height="40px" Width="355px"  OnClick="Course_Request" Text="Approve/Reject Extra Course Request" />
            </p>

        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="advisorLogin.aspx" Style="text-decoration: none;">Back</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
