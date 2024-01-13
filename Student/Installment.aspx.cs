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
    public partial class Installment : System.Web.UI.Page
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
                    using (conn)
                    {
                        int sId = Int16.Parse(Session["user"].ToString());
                        SqlCommand courses = new SqlCommand("Select top 1 Installment.* from Installment inner join Payment on Payment.payment_id = Installment.payment_id and Payment.student_id =" + sId+" and Installment.status='notpaid' where Installment.deadline > CURRENT_TIMESTAMP Order by Installment.deadline ASC", conn);

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
                    label.Text = "Failed to Retrieve Installment";
                    label.Font.Size = 16; // Set your desired font size
                    label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                    label.Font.Bold = true; // Make the text bold
                    form1.Controls.Add(label);
                }

            }

        }
    }
}