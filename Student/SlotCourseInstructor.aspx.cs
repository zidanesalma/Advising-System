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
    public partial class SlotCourseInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {
                Label label = new Label();
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold

                String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connString);

                if (Session["course"].ToString().Equals("Select a Course") || Session["course"].ToString().Equals("Select an Instructor"))
                {
                    label.Text = "Choose values for the Course and the Semester!";
                    form1.Controls.Add(label);


                }
                else
                {
                    int INcourse_id = Int16.Parse(Session["course"].ToString());
                    int INinstructor_id = Int16.Parse(Session["instructor"].ToString());

                    try
                    {
                        using (conn)
                        {
                            SqlCommand slots = new SqlCommand("SELECT * FROM dbo.FN_StudentViewSlot(@CourseID, @InstructorID)", conn);
                            slots.CommandType = System.Data.CommandType.Text;
                            slots.Parameters.Add(new SqlParameter("@CourseID", INcourse_id));
                            slots.Parameters.Add(new SqlParameter("@InstructorID", INinstructor_id));

                            conn.Open();
                            SqlDataReader reader = slots.ExecuteReader();
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
                            slots.Dispose();
                            conn.Close();
                        }
                    }
                    catch
                    {
                        label.Text = "Failed to Retrieve Slot Info";
                        form1.Controls.Add(label);

                    }
                }


            }
        }
    }
}