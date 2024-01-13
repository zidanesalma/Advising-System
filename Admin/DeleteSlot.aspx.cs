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

namespace project
{
    public partial class DeleteSlot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");

        }
        public static bool ValidateInput( String pattern, string input)
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String sem = semester.Text;
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";
            if (string.IsNullOrWhiteSpace(sem) || int.TryParse(sem , out int id))
            {
               
                label.Text = "Please try again";
                form1.Controls.Add(label);
             

            }
            else
            {
                if (ValidateInput("^[WS]\\d{2}$",sem) || ValidateInput("^[S]\\d{2}([R]\\d{1})?$",sem))
                {
                    SqlCommand deletslot = new SqlCommand("Procedures_AdminDeleteSlots", conn);
                    deletslot.CommandType = CommandType.StoredProcedure;
                    deletslot.Parameters.Add(new SqlParameter("@current_semester", sem));
                    conn.Open();
                    int z = deletslot.ExecuteNonQuery();

                    if (z <= 0)
                    {
                        label.Text = "There is no slots to delete";
                    }
                    else
                    {
                        label.Text = "Slot is deleted successfully";
                    }

                     

                }
                else
                {
                    label.Text = "invalid semester code";
                }

            }
            form1.Controls.Add(label);
            conn.Close();
 
        }
    }
}