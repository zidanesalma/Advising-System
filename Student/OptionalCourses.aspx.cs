using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace AdvisingSystem
{
    public partial class OptionalCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {
                if (!IsPostBack)
                    try
                    {
                        PopulateSemester();
                    }
                    catch
                    {
                        form1.Controls.Clear();
                        Label label = new Label();
                        label.Text = "Failed to Retrieve Optional Courses";
                        label.Font.Size = 16; // Set your desired font size
                        label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                        label.Font.Bold = true; // Make the text bold
                        form1.Controls.Add(label);

                    }

            }
        }
        protected void ddlFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
                String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connString);
                Label label = new Label();
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
            if (DropDownList1.SelectedItem.Text.Equals("Select a Semester"))
            {
                label.Text = "Choose a Value for the Semester Code!";
                form1.Controls.Add(label);
            }
            else
            {

                String semId = DropDownList1.SelectedValue;
                int sId = Int16.Parse(Session["user"].ToString());
                try
                {
                    using (conn)
                    {
                        SqlCommand vuOP = new SqlCommand("Procedures_ViewOptionalCourse", conn);
                        vuOP.CommandType = System.Data.CommandType.StoredProcedure;
                        vuOP.Parameters.AddWithValue("@StudentID", sId);
                        vuOP.Parameters.AddWithValue("@current_semester_code", semId);
                        conn.Open();
                        SqlDataReader reader = vuOP.ExecuteReader();
                        while (reader.Read())
                        {
                            HtmlTableRow row = new HtmlTableRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                HtmlTableCell cell = new HtmlTableCell();
                                cell.InnerText = reader[i].ToString();
                                row.Cells.Add(cell);

                            }
                            table1.Rows.Add(row);
                        }
                        reader.Close();
                        conn.Close();
                    }
                }
                catch
                {
                    label.Text = "Failed to Retrieve Optional Courses";
                    form1.Controls.Add(label);

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
                    DropDownList1.Items.Add(new ListItem("Select a Semester"));
                    // Check if the query returned any rows
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String s = (reader["semester_code"]).ToString();
                            DropDownList1.Items.Add(new ListItem(s));
                        }
                    }
                    reader.Close();
                    conn.Close();
                    }
                }
            }

       

    }
}