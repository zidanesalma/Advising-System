using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");

            DataTable table = Session["DataTable"] as DataTable;

            if (table != null)
            {
                // Bind the data to the DataGridView control
                DataGridView1.DataSource = table;
                DataGridView1.DataBind();
            }
        }
    }
}