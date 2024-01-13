using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using Label = System.Web.UI.WebControls.Label;

namespace Advising_System
{
    public partial class deleteCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void deleteCourses(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string StudentID = student.Text;
            string SemesterCode = sem_code.Text;
            string CourseID = course_id.Text;

            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";


            if (string.IsNullOrWhiteSpace(SemesterCode) || !(int.TryParse(StudentID, out int studentID))
                || !int.TryParse(CourseID, out int courseID) || (!ValidateInput("^[WS]\\d{2}$", SemesterCode)
                && !ValidateInput("^[S]\\d{2}([R]\\d{1})?$", SemesterCode)))

                label.Text = "Invalid entries. Try again!";
            else

            {
                try
                {
                    SqlCommand deleteCourse = new SqlCommand("Procedures_AdvisorDeleteFromGP", conn);
                    deleteCourse.CommandType = CommandType.StoredProcedure;

                    deleteCourse.Parameters.AddWithValue("@studentID", studentID);
                    deleteCourse.Parameters.AddWithValue("@sem_code", SemesterCode);
                    deleteCourse.Parameters.AddWithValue("@courseID", courseID);

                    conn.Open();
                    int z = deleteCourse.ExecuteNonQuery();

                    if (z <= 0)
                        label.Text = "YOU HAVE NOT DELETED THE COURSE";
                    else
                        label.Text = "YOU HAVE DELETED THE  COURSE FROM THE GRADUATION PLAN";
                    conn.Close();

                }
                catch
                {
                    label.Text = "YOU HAVE NOT DELETED THE  COURSE. TRY AGAIN";

                }
            }
            form1.Controls.Add(label);
           
                            
        }
        public static bool ValidateInput(String pattern, string input)
        {
            //String pattern = "^[WS]\\d{2}$";
            Regex regex = new Regex(pattern);


            if (regex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}