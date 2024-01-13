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
    public partial class IamA : System.Web.UI.Page
    {
        String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AdminP(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("Admin/AdminLogin.aspx");

        }
        protected void AdvisorP(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("Advisor/AdvisorLogin.aspx");

        }
        protected void StudentP(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Response.Redirect("Student/StudentLogin.aspx");

        }
    }
}