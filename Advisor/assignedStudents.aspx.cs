using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }

        protected void View_AssignedStudents(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String strId = advisor.Text;
                String m = major.Text;

                Label label = new Label();
                label.CssClass = "dynamicLabelStyle";

                if (!string.IsNullOrWhiteSpace(m) && !string.IsNullOrWhiteSpace(strId)
                && int.TryParse(strId, out int id))
                {
                    SqlCommand command = new SqlCommand("Procedures_AdvisorViewAssignedStudents", connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@AdvisorID", id);
                    command.Parameters.AddWithValue("@major", m);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        Session["DataTable"] = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            label.Text = "There are no students with this advisor in this major";
                        }
                        else
                        {
                            Response.Redirect("Display.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        label.Text = "There are no students with this advisor in this major";
                    }
                    finally
                    {
                        form1.Controls.Add(label);
                        connection.Close();
                    }
                }
                else
                {
                    label.Text = "Invalid Entries. Try Again";
                    form1.Controls.Add(label);


                }

            }
        }
    }
}