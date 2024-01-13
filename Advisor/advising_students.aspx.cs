using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class advising_students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisorID"] == null)
                Response.Redirect("advisorLogin.aspx");
        }
        protected void advisingStudents(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand advising_students = new SqlCommand("Procedures_AdminListStudents", conn);
            advising_students.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = advising_students.ExecuteReader();
                while (reader.Read())
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (reader[i] != null)
                            cell.InnerText = reader[i].ToString();
                        else
                            cell.InnerText = "-";
                        row.Cells.Add(cell);

                    }
                    table1.Rows.Add(row);
                }
                reader.Close();
                
            }
            finally
            {
                conn.Close();
            }
        }
    }
        

    }


