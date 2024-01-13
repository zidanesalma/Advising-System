using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

namespace AdvisingSystem
{
    public partial class SlotCourseInstructorMid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {

                if (!IsPostBack)
                {
                    DropDownList2.Items.Add(new ListItem("Select an Instructor", "NULL"));

                    try
                    {
                        PopulateCourse();
                    }
                    catch
                    {
                        form1.Controls.Clear();
                        Label label = new Label();
                        label.Text = "Failed to Retrieve Slot Info";
                        label.Font.Size = 16; // Set your desired font size
                        label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                        label.Font.Bold = true; // Make the text bold
                        form1.Controls.Add(label);

                    }

                }
            }

        }
        protected void ok(object sender, EventArgs e) 
        {

            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            Label label = new Label();

            if (DropDownList1.SelectedItem.Text.Equals("Select a Course") || DropDownList2.SelectedItem.Text.Equals("Select an Instructor"))
            {
                label.Text = "Choose values for the Course and the Instructor!";
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
                DropDownList1.SelectedIndex = 0;
                DropDownList2.SelectedIndex = 0;
                form1.Controls.Add(label);

            }
            else
            {
                Session["course"] = DropDownList1.SelectedItem.Value;
                Session["instructor"] = DropDownList1.SelectedItem.Value;
                Response.Redirect("SlotCourseInstructor.aspx");
            }

        }
        protected void ddlFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("Select an Instructor", "NULL"));
            String courseCode = DropDownList1.SelectedItem.Value;
            int Cid = Int16.Parse(courseCode);
            try
            {
                PopulateInstructor(Cid);
            }
            catch
            {
                Label label = new Label();
                label.Text = "Failed to Retrieve Slot Info";
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
                form1.Controls.Add(label);

            }

        }
        private void PopulateCourse()
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT CONVERT(NVARCHAR(MAX), Course.course_id) + ': ' + Course.name AS CourseCode, course_id  FROM Course";

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DropDownList1.Items.Add(new ListItem("Select a Course", "NULL"));

                    // Check if the query returned any rows
                    while (reader.Read())
                    {
                        String s = (reader["CourseCode"]).ToString();
                        String v = (reader["course_id"]).ToString();
                        DropDownList1.Items.Add(new ListItem(s, v));

                    }

                    reader.Close();
                }
            }
        }
        private void PopulateInstructor(int course)
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT CONVERT(NVARCHAR(MAX), I.instructor_id)+': ' + I.name AS InstructorCode, I.instructor_id  FROM Instructor I INNER JOIN Instructor_Course IC ON IC.course_id = " + course + " AND I.instructor_id = IC.instructor_id";

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // Check if the query returned any rows
                    while (reader.Read())
                    {
                        String s = (reader["InstructorCode"]).ToString();
                        String v = (reader["instructor_id"]).ToString();
                        DropDownList2.Items.Add(new ListItem(s, v));

                    }

                    reader.Close();
                }
            }
        }
    }
}
