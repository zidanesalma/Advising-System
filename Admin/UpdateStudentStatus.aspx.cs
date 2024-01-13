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
    public partial class UpdateStudentStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";
            if (string.IsNullOrWhiteSpace(studentid.Text) || ! int.TryParse(studentid.Text, out int id))
            {
                label.Text = "Please try again";
                form1.Controls.Add(label);
            }
            else
            {
                int id1 = Int16.Parse(studentid.Text);
                SqlCommand updateStatus = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn);
                updateStatus.CommandType = CommandType.StoredProcedure;
                updateStatus.Parameters.Add(new SqlParameter("@student_id", id1));
                conn.Open();
                int x = updateStatus.ExecuteNonQuery();
                if (x == 0)
                {
                    label.Text = "The student doesnt exist";
                }
                else
                {
                    label.Text = "The students's status is updated successfully";


                }
                conn.Close();
                form1.Controls.Add(label);

            }
        }
    }
}