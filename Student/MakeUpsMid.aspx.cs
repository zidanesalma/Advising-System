using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class MakeUpsMid : System.Web.UI.Page
    {
        String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");

        }

        protected void FirstMakeUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("FirstMakeUp.aspx");

        }
        protected void SecondMakeUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("SecondMakeUp.aspx");

        }

    }
}