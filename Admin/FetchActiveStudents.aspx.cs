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
    public partial class FetchActiveStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");

            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand viewPayments = new SqlCommand("select student_id,f_name," +
                    "l_name, password,gpa,faculty,email,major, financial_status," +
                    "semester,acquired_hours,assigned_hours,advisor_id From view_Students ", conn);
                viewPayments.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = viewPayments.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable table = new DataTable();
                table.Load(reader);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i][8] = table.Rows[i][8].ToString();
                }

                ResultTable.DataSource = table;
                ResultTable.DataBind();
                conn.Close();
            }
        }
    }
}