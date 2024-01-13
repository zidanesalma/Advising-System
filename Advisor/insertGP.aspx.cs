using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using Label = System.Web.UI.WebControls.Label;
using System.Text.RegularExpressions;


namespace Advising_System
{
    public partial class insertGP : System.Web.UI.Page
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
        protected void insertGradPlan(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string SemesterCode = sem_code.Text;
            string SemCreditHours = sem_credit_hrs.Text;
            string ExpectedGradDate = exp_grad_sem.Text;
            string StudentID = student_id.Text;
            string AdvisorID = advisor_id.Text;

            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            if (!string.IsNullOrWhiteSpace(SemesterCode) && !string.IsNullOrWhiteSpace(ExpectedGradDate)
               && int.TryParse(SemCreditHours, out int creditHours)&& int.TryParse(StudentID, out int studentID)
               && int.TryParse(AdvisorID, out int advisorID) && DateTime.TryParse(ExpectedGradDate, out DateTime x)
              &&  (ValidateInput("^[WS]\\d{2}$", SemesterCode) || ValidateInput("^[S]\\d{2}([R]\\d{1})?$", SemesterCode)))
            {
                try
                {
                    SqlCommand insertGradPlan = new SqlCommand("Procedures_AdvisorCreateGP", conn);
                    insertGradPlan.CommandType = CommandType.StoredProcedure;
                    DateTime date = DateTime.Parse(ExpectedGradDate);
                    String p = date.ToString("yyyy-MM-dd");
                    
                    insertGradPlan.Parameters.AddWithValue("@semester_code", SemesterCode);
                    insertGradPlan.Parameters.AddWithValue("@sem_credit_hours", creditHours);
                    insertGradPlan.Parameters.AddWithValue("@expected_graduation_date", p);
                    insertGradPlan.Parameters.AddWithValue("@advisor_id", advisorID);
                    insertGradPlan.Parameters.AddWithValue("@student_id", studentID);

                 //   conn.Open();
                    conn.Open();
                    int z = insertGradPlan.ExecuteNonQuery();
                    conn.Close();
                    if (z <= 0)
                    {
                        label.Text = "THE GRADUATION PLAN IS NOT ADDED";
                    }
                    else
                        label.Text = "YOU HAVE ADDED THE GRADUATION PLAN";

                   
                }
                catch
                {
                    label.Text = "YOU HAVE NOT ADDED THE GRADUATION PLAN, TRY AGAIN";

                }
            }
            else
            {
                label.Text = "INVALID ENTRIES. TRY AGAIN";

            }
            form1.Controls.Add(label);

        }
    }
}