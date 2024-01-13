using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace project
{
    public partial class DeleteCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"]==null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");

        }
        protected void Move(object sender, EventArgs e)
        { 

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            if (string.IsNullOrWhiteSpace(courseID.Text) ||! int.TryParse(courseID.Text, out int id))
            {
                label.Text = "please try again";
                form1.Controls.Add(label);
            }
            else
            {
               
                int id1 = Int16.Parse(courseID.Text);
                SqlCommand deletproc = new SqlCommand("Procedures_AdminDeleteCourse", conn);
                deletproc.CommandType = CommandType.StoredProcedure;
                deletproc.Parameters.Add(new SqlParameter("@courseID", id1));
                conn.Open();
               int z= deletproc.ExecuteNonQuery();
                if (z <= 0)
                {
                    label.Text = "This Course does not exist";
                }
                else
                {
                    label.Text = "Course deleted successfully";
                }
               
                form1.Controls.Add(label);
                conn.Close();
            }
           
            
        }
    }
}