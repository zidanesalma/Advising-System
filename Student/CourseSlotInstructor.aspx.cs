using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class CourseSlotInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {
                String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    using (conn) { 
                        SqlCommand courses = new SqlCommand("SELECT * FROM Courses_Slots_Instructor", conn);
                        conn.Open();
                        SqlDataReader reader = courses.ExecuteReader();
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
                    form1.Controls.Clear();
                    Label label = new Label();
                    label.Text = "Failed to Retrieve Courses and Exam Details";
                    label.Font.Size = 16; // Set your desired font size
                    label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                    label.Font.Bold = true; // Make the text bold
                    form1.Controls.Add(label);
                }

            }

        }
    }
}