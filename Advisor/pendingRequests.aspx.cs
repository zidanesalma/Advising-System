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
    public partial class pendingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void View_pendingRequests(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand pendingRequests = new SqlCommand("SELECT * FROM all_Pending_Requests", conn);
            pendingRequests.CommandType = CommandType.Text;
            conn.Open();

            SqlDataReader reader = pendingRequests.ExecuteReader(CommandBehavior.CloseConnection);

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

                table2.Rows.Add(row);
            }

            conn.Close();
        }

        
    }
}