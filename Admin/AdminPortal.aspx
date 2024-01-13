<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="AdvisingSystem.AdminPortal" %>

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
            text-align:center;
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
            <asp:Label ID="label1" runat="server" Text="Welcome to Admin Portal" style="font-size:20pt; font-family: 'Arial, sans-serif'; font-weight: bold;"></asp:Label>
            <p></p>
            <p>
                <asp:Button ID="GetAdvisors" runat="server" Text="Get all advisors" Height="40px" Width="355px" OnClick="GetAdvisors_Click" />
            </p>
            <p>
                <asp:Button ID="GetStudents" runat="server" Text="Get all students with their advisors" Height="40px" Width="355px" OnClick="GetStudents_Click" />
            </p>
            <p>
                <asp:Button ID="GetRequests" runat="server" Text="Get all pending requests" Height="40px" Width="355px" OnClick="GetRequests_Click" />
            </p>
            <p>
                <asp:Button ID="AddSemester" runat="server" Text="Add a new semester" Height="40px" Width="355px" OnClick="AddSemester_Click" />
            </p>
            <p>
                <asp:Button ID="AddCourse" runat="server" Text="Add a new course" Height="40px" Width="355px" OnClick="AddCourse_Click" />
            </p>
            <p>
                <asp:Button ID="LinkInstructor" runat="server" Text="Link instructor to course in a slot" Height="40px" Width="355px" OnClick="LinkInstructor_Click" />
            </p>
            <p>
                <asp:Button ID="LinkStudentAdvisor" runat="server" Text="Link student to advisor" Height="40px" Width="355px" OnClick="LinkStudentAdvisor_Click" />
            </p>
            <p>
                <asp:Button ID="LinkStudentCourseInstructor" runat="server" Text="Link student to course with an instructor" Height="40px" Width="355px" OnClick="LinkStudentCourseInstructor_Click" />
            </p>
            <p>
                <asp:Button ID="ViewInstructorCourse" runat="server" Text="View instructors and their courses" Height="40px" Width="355px" OnClick="ViewInstructorCourse_Click" />
            </p>
            <p>
                <asp:Button ID="GetCourseSemester" runat="server" Text="Get all semesters along with their offered courses" Height="40px" Width="355px" OnClick="GetCourseSemester_Click" />
            </p>
             <p>
                <asp:Button ID="DeleteCourse" runat="server" Text="Delete Courses with its slots" Height="40px" Width="355px" OnClick="DeleteCourse_Click" />
            </p>
            <p>
                <asp:Button ID="DeleteSlots" runat="server" Text="Delete Slots of courses not offered in the current semester" Height="40px" Width="355px" OnClick="DeleteSlot_Click" />
            </p>
            <p>
                <asp:Button ID="AddMakeup" runat="server" Text="Add a Makeup exam for a certain course" Height="40px" Width="355px" OnClick="AddMakeup_Click" />
            </p>
            <p>
                <asp:Button ID="payments" runat="server" Text="View payments details with their students" Height="40px" Width="355px" OnClick="payments_Click" />
            </p>
            <p>
                <asp:Button ID="IssuesInstallments" runat="server" Text="Issue installments for a certain payment" Height="40px" Width="355px" OnClick="IssuesInstallments_Click" />
            </p>
            <p>
                <asp:Button ID="UpdateStatus" runat="server" Text="Update a student status" Height="40px" Width="355px" OnClick="UpdateStatus_Click" />
            </p>
            <p>
                <asp:Button ID="ActiveStudents" runat="server" Text="Get all active students" Height="40px" Width="355px" OnClick="ActiveStudents_Click" />
            </p>
            <p>
                <asp:Button ID="ViewGP" runat="server" Text="View graduation plans with their advisors" Height="40px" Width="355px" OnClick="ViewGP_Click" />
            </p>
            <p>
                <asp:Button ID="ViewTranscript" runat="server" Text="View students transcript details" Height="40px" Width="355px" OnClick="ViewTranscript_Click" />
            </p>
            <p>
                <asp:Button ID="semestercourse" runat="server" Text="Get all semesters with their offered courses" Height="40px" Width="355px" OnClick="Offered_Click" />
            </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AdminLogin.aspx" style="text-decoration: none;">Back</asp:HyperLink>

        </div>

    </form>
</body>
</html>
