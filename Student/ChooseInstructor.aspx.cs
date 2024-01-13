using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class ChooseInstructor : System.Web.UI.Page
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
                        PopulateSemester();
                        PopulateCourse();
                    }
                    catch
                    {
                        Label label = new Label();
                        label.Text = "Failed to Choose Instructor";
                        label.Font.Size = 16; // Set your desired font size
                        label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                        label.Font.Bold = true; // Make the text bold
                        form1.Controls.Add(label);

                    }

                }
            }
        }
        protected void chooseInstructor(object sender, EventArgs e)
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            Label label = new Label();
            label.Font.Size = 16; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold


                if (DropDownList1.SelectedItem.Text.Equals("Select a Course") || DropDownList2.SelectedItem.Text.Equals("Select an Instructor")
                    || DropDownList3.SelectedItem.Text.Equals("Select a Semester"))
                {
                    label.Text = "Choose values for the Course, Instructor and the Semester!";
                    DropDownList1.SelectedIndex = 0;
                    DropDownList2.SelectedIndex = 0;
                    DropDownList3.SelectedIndex = 0;


                }
                else
                {

                    String courseCode = DropDownList1.SelectedItem.Value;
                    int Cid = Int16.Parse(courseCode);
                    String instructorId = DropDownList2.SelectedItem.Value;
                    int Sid = Int16.Parse(Session["user"].ToString());
                    int Iid = Int16.Parse(instructorId);
                    String semCode = DropDownList3.SelectedItem.Value;

                    try
                    {
                        using (conn)
                        {
                            SqlCommand reg = new SqlCommand("Procedures_Chooseinstructor", conn);
                            reg.CommandType = CommandType.StoredProcedure;
                            reg.Parameters.Add(new SqlParameter("@StudentID", Sid));
                            reg.Parameters.Add(new SqlParameter("@CourseID", Cid));
                            reg.Parameters.Add(new SqlParameter("@instrucorID", Iid));
                            reg.Parameters.Add(new SqlParameter("@current_semester_code", semCode));
                            conn.Open();
                            int affRws = (int)reg.ExecuteNonQuery();
                            conn.Close();

                            if (affRws > 0)
                                label.Text = "Instructor Successfully Chosen";
                            else
                            {
                                label.Text = "Failed to Choose Instructor";
                                DropDownList1.SelectedIndex = 0;
                                DropDownList2.SelectedIndex = 0;
                                DropDownList3.SelectedIndex = 0;

                            }
                        }
                    }
                    catch
                    {
                        label.Text = "Failed to Choose Instructor";
                    }

                }
            
            form1.Controls.Add(label);
        }
        protected void ddlFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("Select an Instructor", "NULL"));
            String courseCode = DropDownList1.SelectedItem.Value;
            int Cid = Int16.Parse(courseCode);
            PopulateInstructor(Cid);

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
                conn.Close();
            }
        }
        private void PopulateInstructor(int course)
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT CONVERT(NVARCHAR(MAX), I.instructor_id)+': ' + I.name AS InstructorCode, I.instructor_id  FROM Instructor I INNER JOIN Instructor_Course IC ON IC.course_id = " + course +" AND I.instructor_id = IC.instructor_id";

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //DropDownList2.Items.Add(new ListItem("Select an Instructor"));

                    // Check if the query returned any rows
                    while (reader.Read())
                    {
                        String s = (reader["InstructorCode"]).ToString();
                        String v = (reader["instructor_id"]).ToString();
                        DropDownList2.Items.Add(new ListItem(s,v));

                    }

                    reader.Close();
                }
                conn.Close();

            }
        }
        private void PopulateSemester()
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT Semester.semester_code FROM Semester";

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DropDownList3.Items.Add(new ListItem("Select a Semester"));

                    // Check if the query returned any rows
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String s = (reader["semester_code"]).ToString();
                            DropDownList3.Items.Add(new ListItem(s));

                        }
                    }

                    reader.Close();
                }
                conn.Close();

            }
        }
    }
}