using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AdvisingSystem
{
    public partial class FirstMakeUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {
                
                    try
                    {
                        if (!IsPostBack)
                        {
                            PopulateCourse();
                            PopulateSemester();
                        }
                    }
                    catch
                    {
                        Label label = new Label();
                        label.Text = "Failed to Register for Exam";
                        label.Font.Size = 16; // Set your desired font size
                        label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                        label.Font.Bold = true; // Make the text bold
                        form1.Controls.Add(label);

                    }

                }
            }
    

        protected void Register(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Font.Size = 16; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold


                String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connString);

                if (DropDownList1.SelectedItem.Text.Equals("Select a Course") || DropDownList2.SelectedItem.Text.Equals("Select a Semester"))
                {
                    label.Text = "Choose values for the Course and the Semester!";
                    DropDownList1.SelectedIndex = 0;
                    DropDownList2.SelectedIndex = 0;

                }
                else
                {
                    try {
                        using (conn)
                        {
                            String courseCode = DropDownList1.SelectedItem.Value;
                            int Cid = Int16.Parse(courseCode);
                            int Sid = Int16.Parse(Session["user"].ToString());
                            String semCode = DropDownList2.SelectedItem.Text;
                            SqlCommand reg = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn);
                            reg.CommandType = CommandType.StoredProcedure;
                            reg.Parameters.Add(new SqlParameter("@StudentID", Sid));
                            reg.Parameters.Add(new SqlParameter("@courseID", Cid));
                            reg.Parameters.Add(new SqlParameter("@studentCurr_sem", semCode));

                            conn.Open();
                            int affRws = (int)reg.ExecuteNonQuery();
                            conn.Close();

                            if (affRws > 0)
                                label.Text = "Successfully Registered for the First MakeUp";
                            else
                            {
                                label.Text = "Failed to Register for Exam";
                                DropDownList1.SelectedIndex = 0;
                                DropDownList2.SelectedIndex = 0;
                            }
                            conn.Close();
                        }
                    }
                    catch
                    {
                        label.Text = "Failed to Register for Exam";
                        DropDownList1.SelectedIndex = 0;
                        DropDownList2.SelectedIndex = 0;
                }

                }

            form1.Controls.Add(label);
        }

        private void PopulateCourse()
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT CONVERT(NVARCHAR(MAX), Course.course_id) + ': ' + Course.name AS CourseCode, course_id FROM Course";

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
                    conn.Close();
                }
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
                    DropDownList2.Items.Add(new ListItem("Select a Semester"));

                    // Check if the query returned any rows
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String s = (reader["semester_code"]).ToString();
                            DropDownList2.Items.Add(new ListItem(s));

                        }
                    }
                    reader.Close();
                    conn.Close();
                }
            }
        }
    }
}