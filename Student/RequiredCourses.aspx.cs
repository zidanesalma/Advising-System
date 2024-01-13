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
    public partial class RequiredCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    label.Text = "Failed to Retrieve Required Courses";
                    label.Font.Size = 16; // Set your desired font size
                    label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                    label.Font.Bold = true; // Make the text bold
                    form1.Controls.Add(label);

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

                int sId = Int16.Parse(Session["user"].ToString());
                String semCode = DropDownList1.SelectedValue;

                try
                {
                    using (conn)
                    {
                        SqlCommand vuReq = new SqlCommand("Procedures_ViewRequiredCourses", conn);
                        vuReq.CommandType = System.Data.CommandType.StoredProcedure;
                        vuReq.Parameters.AddWithValue("@StudentID", sId);
                        vuReq.Parameters.AddWithValue("@current_semester_code", semCode);
                        conn.Open();
                        SqlDataReader reader = vuReq.ExecuteReader();
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
                    label.Text = "Failed to Retrieve Required Courses";
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