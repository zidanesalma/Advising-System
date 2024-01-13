using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace AdvisingSystem.Student
{
    public partial class Phone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("StudentLogin.aspx");
        }
        public bool IsCorrectPhoneFormat(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
                return Regex.IsMatch(phone, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")
                       || Regex.IsMatch(phone, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$")
                       || Regex.IsMatch(phone, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{6})$");
            return false;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("Procedures_StudentaddMobile")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            string[] p = phones.Text.Split(',').Distinct().ToArray();

            foreach (string phone in p)
            {
                if (!IsCorrectPhoneFormat(phone))
                {
                    label.Text = "Please enter valid phone number(s)";
                    form1.Controls.Add(label);

                    return;
                }

                add.Parameters.Clear();
                add.Parameters.AddWithValue("@StudentID", Session["user"]);
                add.Parameters.AddWithValue("@mobile_number", phone.Replace(" ", ""));
                int affected = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(Global.ConnectionString))
                    {
                        add.Connection = connection;

                        connection.Open();
                        affected = add.ExecuteNonQuery();
                        label.Text = phone + " added successfully.";
                        form1.Controls.Add(label);

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("The duplicate key value"))
                        label.Text = phone + " has already been added.";
                    else if (affected == 0)
                    {
                        label.Text = "Failed to add the number " + phone;
                        form1.Controls.Add(label);

                    }

                }
            }
        }
    } 
}