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

namespace Advising_System
{
    public partial class Requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }

        protected void View_Requests(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";


            string AdvisorID = advisor_id.Text;

            if (int.TryParse(AdvisorID, out int advisorID))
            {
                try
                {
                    SqlCommand viewRequests = new SqlCommand("SELECT * FROM dbo.FN_Advisors_Requests(@advisor_id)", conn);
                    viewRequests.CommandType = System.Data.CommandType.Text;

                    viewRequests.Parameters.AddWithValue("@advisor_id", advisorID);
                    conn.Open();
                    SqlDataReader reader = viewRequests.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        // Create a new HTML row
                        HtmlTableRow row = new HtmlTableRow();

                        // Create cells dynamically based on the data
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            HtmlTableCell cell = new HtmlTableCell();
                            cell.InnerText = reader[i].ToString();
                            row.Cells.Add(cell);
                        }
                        table1.Rows.Add(row);
                    }

                    conn.Close();
                }
                catch
                {
                    label.Text = "Failed to Retrieve Requests";
                }

            }
            else
            {
                label.Text  = "Invalid entries. Try again";

            }
            form1.Controls.Add(label);

        }
    }
}
