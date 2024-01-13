using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class GraduationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
            else
            {
                String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connString);
                int id = Int16.Parse(Session["user"].ToString());
                try
                {
                    using (conn)
                    {
                        SqlCommand gradPlan = new SqlCommand("SELECT * FROM dbo.FN_StudentViewGP(@student_ID)", conn);
                        gradPlan.Parameters.AddWithValue("@student_ID", id);
                        gradPlan.CommandType = System.Data.CommandType.Text;
                        conn.Open();
                        SqlDataReader reader = gradPlan.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            // Create a new HTML row
                            HtmlTableRow row = new HtmlTableRow();

                            // Create cells dynamically based on the data
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                HtmlTableCell cell = new HtmlTableCell();

                                if (i == 4)
                                    cell.InnerText = ((DateTime)reader[i]).ToString("yyyy-MM-dd");
                                else
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
                    label.Text = "Failed to Retrieve Graduarion Plan";
                    label.Font.Size = 16; // Set your desired font size
                    label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                    label.Font.Bold = true; // Make the text bold
                    form1.Controls.Add(label);
                }

            }
        }
    }
}