using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class AdminForm : System.Web.UI.Page
    {
        private List<TextBox> inputs = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null)
                Response.Redirect("AdminLogin.aspx");

            if (Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");

            if (Session["inputs"] != null)
            {
                string[] inputs = (string[])Session["inputs"];
                foreach (string input in inputs)
                {
                    TextBox textBox = new TextBox();
                    textBox.Attributes["placeholder"] = input;
                    textBox.Attributes["style"] = "height: 40px; width: 355px;";
                    this.inputs.Add(textBox);
                    HtmlGenericControl ptextbox = new HtmlGenericControl("p");
                    // Set the inner text of the paragraph
                    ptextbox.Controls.Add(textBox);
                    // Add the new paragraph to the existing content div
                    form1.Controls.Add(ptextbox);
                }
            }

            Button button = new Button
            {
                Text = Session["action"].ToString()
            };
            button.Attributes["style"] = "height: 35px; width: 155px;";
            HtmlGenericControl pbutton = new HtmlGenericControl("p");
            pbutton.Controls.Add(button);
            button.Click += LinkButton_Click;
            form1.Controls.Add(button);
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            string action = Session["action"].ToString();
            Label label =  new Label();
            label.CssClass = "dynamicLabelStyle";
            HtmlGenericControl plabel = new HtmlGenericControl("p");

            SqlCommand command = (SqlCommand)Session["command"];
            for (int i = 0; i < command.Parameters.Count; i++)
            {
                string value = inputs[i].Text;
                if (value.Length == 0)
                {
                    label.Text = "One of the inputs is empty.";
                    plabel.Controls.Add(label);
                    form1.Controls.Add(plabel);
                    return;
                }

                switch (command.Parameters[i].SqlDbType)
                {
                    case System.Data.SqlDbType.Int:
                    case System.Data.SqlDbType.Bit:
                        bool parsed = int.TryParse(value, out int val);
                        if (!parsed)
                        {
                            label.Text = "Please enter valid data.";
                            plabel.Controls.Add(label);
                            form1.Controls.Add(plabel);
                            return;
                        }

                        command.Parameters[i].Value = val;
                        break;
                    default:
                        if (command.Parameters[i].ParameterName == "@semester_code" && !IsValidSemesterCode(value))
                        {
                            label.Text = "Please enter a valid semester code.";
                            plabel.Controls.Add(label);
                            form1.Controls.Add(plabel);
                            return;
                        }

                        command.Parameters[i].Value = value;
                        break;
                }
            }
            int affected = 0;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.ConnectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    affected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {

            }

            if (affected > 0)
            {
                label.Text = action + "ed successfully";
                plabel.Controls.Add(label);
                form1.Controls.Add(plabel);
            }

            else
            {
                label.Text = "Failed to " + action.ToLower();
                plabel.Controls.Add(label);
                form1.Controls.Add(plabel);
            }

            
        }

        private static bool IsValidSemesterCode(string semesterCode)
        {
            if (semesterCode.Length != 3 && semesterCode.Length != 5)
                return false;

            if (semesterCode[0] != 'S' && semesterCode[0] != 'W')
                return false;

            if (semesterCode.Length == 5 && 
               (semesterCode[3] != 'R' || (semesterCode[4] != '0' && semesterCode[4] != '1')))
                return false;

            if (!int.TryParse(semesterCode.Substring(1, 2), out _))
                return false;

            return true;
        }

    }
}