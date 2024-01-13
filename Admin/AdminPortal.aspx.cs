using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdvisingSystem
{
    public partial class AdminPortal : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null)
                Response.Redirect("AdminLogin.aspx"); 
        }

        protected void GetAdvisors_Click(object sender, EventArgs e)
        {
            SqlCommand getAdvisors = new SqlCommand("Procedures_AdminListAdvisors")
            {
                CommandType = CommandType.StoredProcedure
            };

            Session["tableQuery"] = getAdvisors;
           Response.Redirect("AdminResult.aspx");
        }

        protected void GetStudents_Click(object sender, EventArgs e)
        {
            SqlCommand getStudents = new SqlCommand("AdminListStudentsWithAdvisors")
            {
                CommandType = CommandType.StoredProcedure
            };

            Session["tableQuery"] = getStudents;
            Response.Redirect("AdminResult.aspx");
        }

        protected void GetRequests_Click(object sender, EventArgs e)
        {
            SqlCommand getRequests = new SqlCommand("SELECT * FROM all_Pending_Requests")
            {
                CommandType = CommandType.Text
            };

            Session["tableQuery"] = getRequests;
            Response.Redirect("AdminResult.aspx");
        }

        protected void ViewInstructorCourse_Click(object sender, EventArgs e)
        {
            SqlCommand viewInstructorCourse = new SqlCommand("SELECT * FROM Instructors_AssignedCourses")
            {
                CommandType = CommandType.Text
            };

            Session["tableQuery"] = viewInstructorCourse;
           Response.Redirect("AdminResult.aspx");
        }

        protected void GetCourseSemester_Click(object sender, EventArgs e)
        {
            SqlCommand getCourseSemester = new SqlCommand("SELECT * FROM Semster_offered_Courses")
            {
                CommandType = CommandType.Text
            };

            Session["tableQuery"] = getCourseSemester;
            Response.Redirect("AdminResult.aspx");
        }

        protected void LinkStudentAdvisor_Click(object sender, EventArgs e)
        {
            SqlCommand linkStudentAdvisor = new SqlCommand("Procedures_AdminLinkStudentToAdvisor")
            {
                CommandType = CommandType.StoredProcedure
            };
            linkStudentAdvisor.Parameters.Add("@studentID", SqlDbType.Int);
            linkStudentAdvisor.Parameters.Add("@advisorID", SqlDbType.Int);

            Session["inputs"] = new[] { "Enter student id", "Enter advisor id" };
            Session["action"] = "Link";
            Session["command"] = linkStudentAdvisor;
            Response.Redirect("AdminForm.aspx");
        }

        protected void LinkInstructor_Click(object sender, EventArgs e)
        {
            SqlCommand linkInstructor = new SqlCommand("Procedures_AdminLinkInstructor")
            {
                CommandType = CommandType.StoredProcedure
            };
            linkInstructor.Parameters.Add("@cours_id", SqlDbType.Int);
            linkInstructor.Parameters.Add("@instructor_id", SqlDbType.Int);
            linkInstructor.Parameters.Add("@slot_id", SqlDbType.Int);

            Session["inputs"] = new[] { "Enter course id", "Enter instructor id", "Enter slot id" };
            Session["action"] = "Link";
            Session["command"] = linkInstructor;
            Response.Redirect("AdminForm.aspx");
        }

        protected void LinkStudentCourseInstructor_Click(object sender, EventArgs e)
        {
            SqlCommand linkStudentCourseInstructor = new SqlCommand("Procedures_AdminLinkStudent")
            {
                CommandType = CommandType.StoredProcedure
            };
            linkStudentCourseInstructor.Parameters.Add("@cours_id", SqlDbType.Int);
            linkStudentCourseInstructor.Parameters.Add("@instructor_id", SqlDbType.Int);
            linkStudentCourseInstructor.Parameters.Add("@studentID", SqlDbType.Int);
            linkStudentCourseInstructor.Parameters.Add("@semester_code", SqlDbType.VarChar);

            Session["inputs"] = new[] { "Enter course id", "Enter instructor id", "Enter student id",
                "Enter semester code" };
            Session["action"] = "Link";
            Session["command"] = linkStudentCourseInstructor;
            Response.Redirect("AdminForm.aspx");
        }

        protected void AddSemester_Click(object sender, EventArgs e)
        {
            SqlCommand linkStudentCourseInstructor = new SqlCommand("AdminAddingSemester")
            {
                CommandType = CommandType.StoredProcedure
            };
            linkStudentCourseInstructor.Parameters.Add("@start_date", SqlDbType.Date);
            linkStudentCourseInstructor.Parameters.Add("@end_date", SqlDbType.Date);
            linkStudentCourseInstructor.Parameters.Add("@semester_code", SqlDbType.VarChar);

            Session["inputs"] = new[] { "Enter start date", "Enter end date", "Enter semester code" };
            Session["action"] = "Add";
            Session["command"] = linkStudentCourseInstructor;
           Response.Redirect("AdminForm.aspx");
        }

        protected void AddCourse_Click(object sender, EventArgs e)
        {
            SqlCommand linkStudentCourseInstructor = new SqlCommand("Procedures_AdminAddingCourse")
            {
                CommandType = CommandType.StoredProcedure
            };
            linkStudentCourseInstructor.Parameters.Add("@major", SqlDbType.VarChar);
            linkStudentCourseInstructor.Parameters.Add("@semester", SqlDbType.Int);
            linkStudentCourseInstructor.Parameters.Add("@credit_hours", SqlDbType.Int);
            linkStudentCourseInstructor.Parameters.Add("@name", SqlDbType.VarChar);
            linkStudentCourseInstructor.Parameters.Add("@is_offered", SqlDbType.Bit);

            Session["inputs"] = new[] { "Enter major", "Enter semester", "Enter credit hours", "Enter course name",
                                        "Enter is offered" };
            Session["action"] = "Add";
            Session["command"] = linkStudentCourseInstructor;
            Response.Redirect("AdminForm.aspx");
        }

        protected void DeleteCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteCourse.aspx");
        }

        protected void DeleteSlot_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteSlot.aspx");
        }

        protected void AddMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMakeupExam.aspx");
        }

        protected void payments_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentStudents.aspx");
        }

        protected void IssuesInstallments_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssueInstallments.aspx");
        }

        protected void UpdateStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateStudentStatus.aspx");
        }

        protected void ActiveStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchActiveStudents.aspx");
        }

        protected void ViewGP_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewGPadvisors.aspx");
        }

        protected void ViewTranscript_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTranscript.aspx");
        }

        protected void Offered_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchSemesters.aspx");
        }
    }
}