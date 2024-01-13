using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AdvisingSystem.Student
{
    public partial class StudentRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");

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
            string procedure;
            if (RequestTypes.SelectedIndex == 0)
                procedure = "Procedures_StudentSendingCHRequest";
            else
                procedure = "Procedures_StudentSendingCourseRequest";

            SqlCommand command = new SqlCommand(procedure)
            {
                CommandType = CommandType.StoredProcedure
            };

            string[] parameters = RequestTypes.SelectedValue.Split('|');
            command.Parameters.AddWithValue("@StudentID", Session["user"]);
            command.Parameters.AddWithValue(parameters[0], Data.Text); // course_id or credit_hours
            command.Parameters.AddWithValue("@type", parameters[1]);
            command.Parameters.AddWithValue("@comment", Comment.Text);
            Label label = new Label();
            if (!int.TryParse(Data.Text, out _))
            {
                label.Text = ("Please enter a valid number for the " + parameters[2]);
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
                form1.Controls.Add(label);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Global.ConnectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                label.Text = ("Request sent successfully.");
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
                form1.Controls.Add(label);

            }
            catch
            {
                label.Text = ("Could not submit request.");
                label.Font.Size = 16; // Set your desired font size
                label.Font.Name = "Arial, sans-serif"; // Set your desired font family
                label.Font.Bold = true; // Make the text bold
                form1.Controls.Add(label);

            }
        }
    }
}