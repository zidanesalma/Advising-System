using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class AddMakeupExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");
            else
            {
                if (!IsPostBack)
                {
                    Type.Items.Add(new ListItem("Please select the type of the exam"));
                    Type.Items.Add(new ListItem("Normal"));
                    Type.Items.Add(new ListItem("First MakeUp"));
                    Type.Items.Add(new ListItem("Second MakeUp"));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";
            String type = Type.Text;
           
            

            if (string.IsNullOrWhiteSpace(CourseID.Text) || !(int.TryParse(CourseID.Text, out int id))
                || !DateTime.TryParse(Date.Text, out DateTime x) || string.IsNullOrWhiteSpace(Date.Text)
                || Type.SelectedItem.Text.Equals("Please select the type of the exam"))
               
            {
                label.Text = "please try again";
                form1.Controls.Add(label);
            }
            else {
                DateTime date = DateTime.Parse(Date.Text);
                int id1 = Int16.Parse(CourseID.Text);
                SqlCommand AddExam = new SqlCommand("Procedures_AdminAddExam", conn);
                AddExam.CommandType = CommandType.StoredProcedure;
                AddExam.Parameters.Add(new SqlParameter("@Type", type));
                AddExam.Parameters.Add(new SqlParameter("@date", date));
                AddExam.Parameters.Add(new SqlParameter("@courseID", id1));
                conn.Open();
                try
                {
                    AddExam.ExecuteNonQuery();
                    label.Text = "Exam added successfully";
                }
                catch
                {
                    label.Text = "This course id does not exist";
                }
               
                conn.Close();
                form1.Controls.Add(label);
            }
        }

        protected void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = Type.SelectedValue;
        }
    }
}