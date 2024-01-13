using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Home_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void advisingStudents(object sender, EventArgs e)
        {
            Response.Redirect("advising_students.aspx");

        }
        protected void insertGradPlan(object sender, EventArgs e)
        {
            // Redirect to the Graduation Plan page
            Response.Redirect("insertGP.aspx");
        }
        protected void insertCourses(object sender, EventArgs e)
        {
            Response.Redirect("insertCourse.aspx");
        }
        protected void updateGradDate(object sender, EventArgs e)
        {
            Response.Redirect("updateGP.aspx");
        }
        protected void deleteCourses(object sender, EventArgs e)
        {
            Response.Redirect("deleteCourse.aspx");
        }
        protected void View_AssignedStudents(object sender, EventArgs e)
        {
            // Redirect to the View Assigned Students page
            Response.Redirect("assignedStudents.aspx");
        }
        protected void View_Requests(object sender, EventArgs e)
        {
            // Redirect to the View Assigned Students page
            Response.Redirect("Requests.aspx");
        }
        protected void View_pendingRequests(object sender, EventArgs e)
        {
            // Redirect to the View Assigned Students page
            Response.Redirect("pendingRequests.aspx");
        }
        protected void CreditHours_Request(object sender, EventArgs e)
        {
            // Redirect to the View Assigned Students page
            Response.Redirect("CreditHourReq.aspx");
        }
        protected void Course_Request(object sender, EventArgs e)
        {
            // Redirect to the View Assigned Students page
            Response.Redirect("addCourseReq.aspx");
        }
    }
}