using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class StudentPortal : System.Web.UI.Page
    {
        String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addPhone(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("Phone.aspx");
        }
        protected void viewOptionalC(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("OptionalCourses.aspx");
        }
        protected void viewAvailableC(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("AvailableCourses.aspx");
        }
        protected void viewReqC(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("RequiredCourses.aspx");
        }
        protected void viewMissingC(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("MissingCourses.aspx");
        }
        protected void Req(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("StudentRequest.aspx");
        }
        protected void viewGradPlan(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("GraduationPlan.aspx");
        }
        protected void viewInstallment(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("Installment.aspx");
        }
        protected void viewCourseDetails(object sender, EventArgs e)
        {
            //
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("CourseDetails.aspx");
        }
        protected void MakeUpReg(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("MakeUpsMid.aspx");
        }
        protected void courseSlotInstructor(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("CourseSlotInstructor.aspx");
        }
        protected void slotCourseInstructor(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("SlotCourseInstructorMid.aspx");
        }
        protected void chooseInstructor(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("ChooseInstructor.aspx");
        }
        protected void viewCourseAndPreReq(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("ViewCourseAndPreq.aspx");
        }
    }
}