using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class ViewTranscript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand viewPayments = new SqlCommand("select * From Students_Courses_transcript", conn);
                viewPayments.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = viewPayments.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable table = new DataTable();
                table.Load(reader);
                ResultTable.DataSource = table;
                ResultTable.DataBind();
                conn.Close();
            }

        }
    }
}