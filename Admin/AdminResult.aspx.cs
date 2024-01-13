using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class AdminResult : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";

            if (Session["adminId"] == null)
                Response.Redirect("AdminLogin.aspx");

            if (Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");

            try
            {
                DataTable table = new DataTable();

                using (SqlConnection connection = new SqlConnection(Global.ConnectionString))
                {
                    SqlCommand command = (SqlCommand)Session["tableQuery"];
                    command.Connection = connection;

                    connection.Open();
                    table.Load(command.ExecuteReader());
                    connection.Close();
                }

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string name = table.Columns[i].ColumnName;
                    if (name.Contains("_"))
                        name = name.Split('_')[0] + " " + name.Split('_')[1];

                    table.Columns[i].ColumnName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
                }

                ResultTable.DataSource = table;
                ResultTable.DataBind();
                if (ResultTable.Rows.Count == 0)
                {
                    label.Text = "No records found.";
                    form1.Controls.Add(label);
                }
            }
            catch
            {
                label.Text = "Could not get the table.";
                form1.Controls.Add(label);

            }
        }
    }
}