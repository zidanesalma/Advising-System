using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace Advising_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["advisorID"] = null;
        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Label label = new Label();
            label.Font.Size = 13; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold

            String strId = username.Text;
            String pass = password.Text;
            if (!string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(strId)
                && int.TryParse(strId, out int id))
            {
                try
                {
                    SqlCommand login = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@advisor_Id,@password)", conn);
                    login.CommandType = System.Data.CommandType.Text;
                    login.Parameters.AddWithValue("@advisor_Id", id);
                    login.Parameters.AddWithValue("@password", pass);
                    conn.Open();
                    String s = login.ExecuteScalar().ToString();
                    if (s == "True")
                    {
                        Session["advisorID"] = id;
                        Response.Redirect("AdvisorPortal.aspx");
                    }
                    else
                        label.Text = "Failed to Log In. Try Again.";
                    conn.Close();
                }
                catch
                {
                    label.Text = "Failed to Register for Exam";
                    label.Font.Size = 16; // Set your desired font size
                    label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                    label.Font.Bold = true; // Make the text bold
                    form1.Controls.Add(label);
                }
            }
            else
            {
                label.Text = "Failed to Log In. Try Again.";
            }
            div1.Controls.Add(label);

        }


    }
}