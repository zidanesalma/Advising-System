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
    public partial class creditHourReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        public static bool ValidateInput(String pattern, string input)
        {
            //String pattern = "^[WS]\\d{2}$";
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
        protected void CreditHours_Request(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string sRequestID = requestID.Text;
            string SemesterCode = semesterCode.Text;


            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            if (!string.IsNullOrWhiteSpace(SemesterCode) && int.TryParse(sRequestID, out int request_ID)
                 && (ValidateInput("^[WS]\\d{2}$", SemesterCode) || ValidateInput("^[S]\\d{2}([R]\\d{1})?$", SemesterCode)))
            {
                try
                {
                    SqlCommand approveRejectCH = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", conn);
                    approveRejectCH.CommandType = CommandType.StoredProcedure;
                    approveRejectCH.Parameters.AddWithValue("@requestID", request_ID);
                    approveRejectCH.Parameters.AddWithValue("@current_sem_code", SemesterCode);

                    conn.Open();
                    int z = approveRejectCH.ExecuteNonQuery();

                    if (z <= 0)
                    {
                        label.Text = "THE REQUEST IS NOT FOUND ";
                    }
                    else
                        label.Text = "YOU HAVE APPROVED/REJECTED ALL CREDIT HOURS REQUESTS";
                    conn.Close();
                }
                catch
                {
                    label.Text = "YOU HAVE NOT APPROVED/REJECTED ALL CREDIT HOURS REQUESTS";

                }
                form1.Controls.Add(label);

            }
            else
            {
                label.Text = "INVALID ENTRIES. TRY AGAIN!";
                form1.Controls.Add(label);

            }
        } 
    }
}