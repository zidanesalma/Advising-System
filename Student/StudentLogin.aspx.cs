using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace AdvisingSystem
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;

        }
        protected void login(object sender, EventArgs e)
        {

            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            Label label = new Label();
            label.Font.Size = 16; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold

            String strId = username.Text;
            String pass = password.Text;
            if(!string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(strId) 
                && int.TryParse(strId, out int id))
            {
                try
                {
                    SqlCommand Clogin = new SqlCommand("SELECT dbo.FN_StudentLogin(@Student_id, @password)", conn);
                    Clogin.CommandType = System.Data.CommandType.Text;
                    Clogin.Parameters.AddWithValue("@Student_id", id);
                    Clogin.Parameters.AddWithValue("@password", pass);
                    conn.Open();
                    String s = Clogin.ExecuteScalar().ToString();
                    if (s == "True")
                    {
                        Session["user"] = id;
                        Response.Redirect("StudentPortal.aspx");
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