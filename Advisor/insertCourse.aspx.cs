using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Label = System.Web.UI.WebControls.Label;

namespace Advising_System
{
    public partial class InsertCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void insertCourses(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string StudentID = student_id.Text;
            string CourseName = course_name.Text;
            string SemesterCode = sem_code.Text;


            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            if (!string.IsNullOrWhiteSpace(CourseName) && !string.IsNullOrWhiteSpace(SemesterCode)
               && int.TryParse(StudentID, out int id) 
               && (ValidateInput("^[WS]\\d{2}$", SemesterCode) || ValidateInput("^[S]\\d{2}([R]\\d{1})?$", SemesterCode)))
            {
                try
                {
                    SqlCommand insertCourse = new SqlCommand("Procedures_AdvisorAddCourseGP", conn);
                    insertCourse.CommandType = CommandType.StoredProcedure;

                    insertCourse.Parameters.AddWithValue("@Semester_code", SemesterCode);
                    insertCourse.Parameters.AddWithValue("@student_id", id);
                    insertCourse.Parameters.AddWithValue("@course_name", CourseName);

                    conn.Open();
                    int z = insertCourse.ExecuteNonQuery();

                    if (z <= 0)
                    {
                        label.Text = "YOU HAVE NOT ADDED THE COURSE IN THE GRAD PLAN ";
                    }
                    else
                        label.Text = "YOU HAVE ADDED THE COURSE THE GRADUATION PLAN";
                    conn.Close();
                }
                catch
                {
                    label.Text = "Failed to Insert the Course";
                }
            }
            else
            {
                label.Text = "Invalid Entries. Try Again.";
            }
            form1.Controls.Add(label);
        }
        public static bool ValidateInput(String pattern, string input)
        {
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