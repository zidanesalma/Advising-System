<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPortal.aspx.cs" Inherits="AdvisingSystem.StudentPortal" %>

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
            <asp:Button ID="phone" runat="server" Height="40px" OnClick="addPhone" Text="Add Phone Number" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewOpCourses" runat="server" Height="40px" OnClick="viewOptionalC" Text="Optional Courses" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewAvCourses" runat="server" Height="40px" OnClick="viewAvailableC" Text="Available Courses" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewReqCourses" runat="server" Height="40px" OnClick="viewReqC" Text="Required Courses" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewMissCourses" runat="server" Height="40px" OnClick="viewMissingC" Text="Missing Courses" Width="355px" />
        </p>   
        <p>
            <asp:Button ID="SendReq" runat="server" Height="40px" OnClick="Req" Text="Send Requests" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewGradPlan" runat="server" Height="40px" OnClick="viewGradPlan" Text="View Graduation Plan" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewUpcominInstallment" runat="server" Height="40px" OnClick="viewInstallment" Text="Upcoming Installment" Width="354px" />
        </p>
        <p>
            <asp:Button ID="ViewCourseDetails" runat="server" OnClick="viewCourseDetails" Text="View Courses and Exam Details" Width="355px" Height="40px" />
        </p>
        <p>
            <asp:Button ID="RegisterForMakeUp" runat="server" OnClick="MakeUpReg" Text="Register for MakeUps" Height="40px" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewCSI" runat="server" OnClick="courseSlotInstructor" Text="View Courses with their Slots and Instructors" Height="40px" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ViewSCI" runat="server" OnClick="slotCourseInstructor" Text="View Slots of Course and Instructors" Height="40px" Width="355px" />
        </p>
        <p>
            <asp:Button ID="ChooseInstructor" runat="server" OnClick="chooseInstructor" Text="Choose Instructor" Height="40px" Width="355px" />
        </p>
        <p>
            <asp:Button ID="CourseAndPreReq" runat="server" OnClick="viewCourseAndPreReq" Text="View All Courses and Pre-requisite Details" Height="40px" Width="355px" />
        </p>
        </div>
        <div id="backButton">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StudentLogin.aspx"  style="font-size:12pt; color: blue; text-decoration: none;">Back</asp:HyperLink>

        </div>


    </form>
</body>
</html>
