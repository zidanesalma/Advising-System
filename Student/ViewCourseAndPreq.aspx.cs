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
    public partial class ViewCourseAndPreq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (conn)
                {
                    SqlCommand courses = new SqlCommand("SELECT * FROM view_Course_prerequisites", conn);
                    conn.Open();
                    SqlDataReader reader = courses.ExecuteReader();
                    while (reader.Read())
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            HtmlTableCell cell = new HtmlTableCell();
                            String s = reader[i].ToString();
                            if (i == 3)
                                switch (s)
                                {
                                    case "False":
                                        cell.InnerText = "NO"; break;
                                    case "True":
                                        cell.InnerText = "YES"; break;
                                    default:
                                        cell.InnerText = "NULL"; break;
                                }
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
                label.Text = "Failed to Retrieve Slot Info";
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
                form1.Controls.Add(label);

            }

        }
    }
}