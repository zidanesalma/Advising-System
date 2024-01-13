using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reg(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            Label label = new Label();
            label.Font.Size = 16; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold

            String firstn = fname.Text;
            String lastn = lname.Text;
            String spass = pass.Text;
            String sfac = fac.Text;
            String semail = email.Text;
            String smajor = major.Text;
            String ssem = sem.Text;

            if (!string.IsNullOrWhiteSpace(firstn) && !string.IsNullOrWhiteSpace(lastn)
                && !string.IsNullOrWhiteSpace(spass) && !string.IsNullOrWhiteSpace(sfac)
                && !string.IsNullOrWhiteSpace(semail) && !string.IsNullOrWhiteSpace(smajor)
                && !string.IsNullOrWhiteSpace(ssem) && int.TryParse(ssem, out int studentSem))
            {
                try
                {
                    using (conn)
                    {
                        SqlCommand CReg = new SqlCommand("Procedures_StudentRegistration", conn);
                        CReg.CommandType = System.Data.CommandType.StoredProcedure;
                        CReg.Parameters.AddWithValue("@first_name", firstn);
                        CReg.Parameters.AddWithValue("@last_name", lastn);
                        CReg.Parameters.AddWithValue("@password", spass);
                        CReg.Parameters.AddWithValue("@faculty", sfac);
                        CReg.Parameters.AddWithValue("@email", semail);
                        CReg.Parameters.AddWithValue("@major", smajor);
                        CReg.Parameters.AddWithValue("@Semester", ssem);

                        SqlParameter StudentID = new SqlParameter
                        {
                            ParameterName = "@Student_id",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output // Specify that this is an output parameter
                        };;

                        // Add the output parameter to the command
                        CReg.Parameters.Add(StudentID);

                        conn.Open();
                        int affrows = (int)CReg.ExecuteNonQuery();
                        if (affrows > 0)
                        {
                            form1.Controls.Clear();
                            label.Text = "Registered Successfully. Your ID is " + (int)StudentID.Value + ".";
                            Session["user"] = StudentID.Value;
                            HyperLink dynamicHyperLink = new HyperLink();

                            // Set the properties of the HyperLink
                            dynamicHyperLink.ID = "HyperLink1";
                            dynamicHyperLink.Text = "Log In";
                            dynamicHyperLink.NavigateUrl = "StudentLogin.aspx";

                            // Add the HyperLink to a container (assuming you have a Panel with ID="panel1" in your markup)
                            form1.Controls.Add(label);
                            form1.Controls.Add(new LiteralControl("<br/>"));
                            form1.Controls.Add(new LiteralControl("<br/>"));
                            form1.Controls.Add(new LiteralControl("<br/>"));
                            form1.Controls.Add(dynamicHyperLink);


                        }
                        else
                        {
                            label.Text = "You're Already Registered! Your ID is " + (int)StudentID.Value + ".";
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