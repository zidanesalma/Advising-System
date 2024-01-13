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
    public partial class MissingCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {
                String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connString);
                int sId = Int16.Parse(Session["user"].ToString());
                try
                {
                    // Open a SqlConnection
                    using (conn)
                    {
                        SqlCommand vuMiss = new SqlCommand("Procedures_ViewMS", conn);
                        vuMiss.CommandType = System.Data.CommandType.StoredProcedure;
                        vuMiss.Parameters.AddWithValue("@StudentID", sId);


                        conn.Open();
                        SqlDataReader reader = vuMiss.ExecuteReader();
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
                    label.Text = "Failed to Retrieve Missing Courses";
                    label.Font.Size = 16; // Set your desired font size
                    label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                    label.Font.Bold = true; // Make the text bold
                    form1.Controls.Add(label);
                }


            }




        }
    }
}