using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class AdvisorRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void advisor_registeration(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Label label = new Label();
            label.Font.Size = 16; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold
 
            string advisorName = advisor_name.Text;
            string Password = pass.Text;
            string advisorEmail = advisor_email.Text;
            string advisorOffice = advisor_office.Text;

            if (!string.IsNullOrWhiteSpace(advisorName) && !string.IsNullOrWhiteSpace(Password)
               && !string.IsNullOrWhiteSpace(advisorEmail) && !string.IsNullOrWhiteSpace(advisorOffice))
            {
                try
                {
                    using (conn)
                    {

                        SqlCommand advisor_registeration = new SqlCommand("Procedures_AdvisorRegistration", conn);
                        advisor_registeration.CommandType = CommandType.StoredProcedure;

                         advisor_registeration.Parameters.AddWithValue("@advisor_name", advisorName);
                         advisor_registeration.Parameters.AddWithValue("@password", Password);
                         advisor_registeration.Parameters.AddWithValue("@email", advisorEmail);
                         advisor_registeration.Parameters.AddWithValue("@office", advisorOffice);

                        SqlParameter output = new SqlParameter
                        {
                            ParameterName = "@Advisor_id",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };;
                        advisor_registeration.Parameters.Add(output); 
           

                        conn.Open();
                        int affrows = (int)advisor_registeration.ExecuteNonQuery();
                        if (affrows > 0)
                        {
                            form1.Controls.Clear();
                            label.Text = "Registered Successfully. Your ID is " + (int)output.Value + ".";
                            Session["advisorID"] = output.Value;
                            HyperLink dynamicHyperLink = new HyperLink();

                            // Set the properties of the HyperLink
                            dynamicHyperLink.ID = "HyperLink1";
                            dynamicHyperLink.Text = "Go To Login Page";
                            dynamicHyperLink.NavigateUrl = "advisorLogin.aspx";

                            // Add the HyperLink to a container (assuming you have a Panel with ID="panel1" in your markup)
                            form1.Controls.Add(label);
                            form1.Controls.Add(new LiteralControl("<br/>"));
                            form1.Controls.Add(new LiteralControl("<br/>"));
                            form1.Controls.Add(new LiteralControl("<br/>"));
                            form1.Controls.Add(dynamicHyperLink);
                        }
                        else
                        {
                            label.Text = "You're Already Registered! Your ID is " + (int)output.Value + ".";
                            form1.Controls.Add(label);
                        }
                        conn.Close();
                    }
                }
                catch
                {
                    label.Text = "Failed to Register";
                    form1.Controls.Add(label);

                }
            }
            else
            {
                label.Text = "Incorrect Info. Try Again.";
                form1.Controls.Add(label);

            }



        }
    }
}
