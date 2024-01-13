using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Advising_System
{
    public partial class addCourseReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void Course_Request(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string SemesterCode = semesterCode.Text;
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";
             

            if (string.IsNullOrWhiteSpace(requestID.Text) || string.IsNullOrWhiteSpace(SemesterCode) 
                || !(int.TryParse(requestID.Text, out int RequestID) )|| !((ValidateInput("^[WS]\\d{2}$", SemesterCode) 
                || ValidateInput("^[S]\\d{2}([R]\\d{1})?$", SemesterCode))))
                label.Text = "Enter Valid Data!";
            else
            {

                SqlCommand approveRejectCourse = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn);
                approveRejectCourse.CommandType = CommandType.StoredProcedure;

                approveRejectCourse.Parameters.AddWithValue("@requestID", RequestID);
                approveRejectCourse.Parameters.AddWithValue("@current_semester_code", SemesterCode);

                conn.Open();
                int z = approveRejectCourse.ExecuteNonQuery();

                if (z <= 0)
                    label.Text = "THE REQUEST IS NOT FOUND ";
                else
                    label.Text = "YOU HAVE APPROVED/REJECTED ALL COURSE REQUESTS";

                conn.Close();
            }
            form1.Controls.Add(label);

        }
        public static bool ValidateInput(String pattern, string input)
        {
            Regex regex = new Regex(pattern);


            if (regex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}