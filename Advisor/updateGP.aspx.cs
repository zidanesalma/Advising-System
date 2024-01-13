using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Advising_System
{
    public partial class updateGP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void updateGradDate(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string StudentID = student_id.Text;
            string ExpectedGradDate = expected_grad_date.Text;
              


            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            if (!string.IsNullOrWhiteSpace(ExpectedGradDate)&& int.TryParse(StudentID, out int id)
                && DateTime.TryParse(ExpectedGradDate, out DateTime x))
            {
                try
                {

                    SqlCommand updateGP = new SqlCommand("Procedures_AdvisorUpdateGP", conn);
                    updateGP.CommandType = CommandType.StoredProcedure;
                    DateTime date = DateTime.Parse(ExpectedGradDate);
                   String p= date.ToString("yyyy-MM-dd");
                    updateGP.Parameters.AddWithValue("@expected_grad_date", p);
                    updateGP.Parameters.AddWithValue("@studentID", id);

                    conn.Open();
                    int z = updateGP.ExecuteNonQuery();

                    if (z <= 0)
                    {
                        label.Text = "YOU HAVE NOT UPDATED THE GRADUATION DATA SUUCESSFULY";
                    }
                    else
                        label.Text = "YOU HAVE UPDATED THE GRADUATION DATE";
                    conn.Close();
                }
                catch
                {
                    label.Text = "YOU HAVE NOT UPDATED THE GRADUATION DATE, TRY AGAIN!";

                }

            }
            else
            {
                label.Text = "INVALID ENTRIES, TRY AGAIN!";

            }
            form1.Controls.Add(label);
        }
    }
}