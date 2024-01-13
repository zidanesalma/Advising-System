using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace AdvisingSystem.Student
{
    public partial class StudentRequest : System.Web.UI.Page
    {
        String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = 1;

            if (!IsPostBack)
            {
                Data.Attributes["placeholder"] = "Enter credit hours";
                RequestTypes.SelectedIndex = 0;
            }
        }

        protected void RequestTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RequestTypes.SelectedIndex == 0)
                Data.Attributes["placeholder"] = "Enter credit hours";
            else
                Data.Attributes["placeholder"] = "Enter course id";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            Label label = new Label();
            label.Font.Size = 16; // Set your desired font size
            label.Font.Name = "Arial, sans-serif"; // Set your desired font family
            label.Font.Bold = true; // Make the text bold


            string procedure;
            if (RequestTypes.SelectedIndex == 0)
                procedure = "Procedures_StudentSendingCHRequest";
            else
                procedure = "Procedures_StudentSendingCourseRequest";

            try
            {
                using (conn)
                {
                    SqlCommand command = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    string[] parameters = RequestTypes.SelectedValue.Split('|');
                    command.Parameters.AddWithValue("@StudentID", Session["user"]);
                    command.Parameters.AddWithValue(parameters[0], Data.Text); // course_id or credit_hours
                    command.Parameters.AddWithValue("@type", parameters[1]);
                    command.Parameters.AddWithValue("@comment", Comment.Text);

                    if (!int.TryParse(Data.Text, out _))
                    {
                        Response.Write("Please enter a valid number for the " + parameters[2]);
                        return;
                    }

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    label.Text = "Request Sent Successfully!";


                }
            }
            catch
            {
                form1.Controls.Clear();
                label.Text = "Failed to Send Request";
            }
            form1.Controls.Add(label);


        }
    }
}