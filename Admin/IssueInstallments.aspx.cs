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
    public partial class IssueInstallments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null || Request.UrlReferrer == null)
                Response.Redirect("AdminPortal.aspx");


            else
            {
                if (!IsPostBack)
                {
                    paymentid.Items.Add(new ListItem("Please select the payment id"));
                   populatePayment();
                   // paymentid.Items.Add(new ListItem("1"));
                    //paymentid.Items.Add(new ListItem("2"));
                   // paymentid.Items.Add(new ListItem("3"));
                   // paymentid.Items.Add(new ListItem("4"));
                   // paymentid.Items.Add(new ListItem("5"));
                   // paymentid.Items.Add(new ListItem("6"));
                   // paymentid.Items.Add(new ListItem("7"));
                   // paymentid.Items.Add(new ListItem("8"));
                    //paymentid.Items.Add(new ListItem("9"));
                    //paymentid.Items.Add(new ListItem("10"));
                }
            }
        }

        private void populatePayment()
        {
            String connString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT payment_id FROM   Payment";

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                   

                    // Check if the query returned any rows
                    while (reader.Read())
                    {
                        String s = (reader["payment_id"]).ToString();
                        String v = (reader["payment_id"]).ToString();
                        paymentid.Items.Add(new ListItem(s, v));

                    }
                    reader.Close();
                }
                conn.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
           
            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";
            SqlCommand issuesinstallment = new SqlCommand("Procedures_AdminIssueInstallment", conn);
            issuesinstallment.CommandType = CommandType.StoredProcedure;
            
            conn.Open();
            //int z=issuesinstallment.ExecuteNonQuery();
            try
            {
                if (paymentid.SelectedItem.Text.Equals("Please select the payment id"))
                {
                    label.Text = "Please select a payment id";
                }
                else {
                    int id = Int16.Parse(paymentid.Text);
                    issuesinstallment.Parameters.Add(new SqlParameter("@payment_id", id));
                    issuesinstallment.ExecuteNonQuery();
                    label.Text = "The installments for this payment are issued successfully"; }
            }
            catch
            {
                label.Text=" The installments for this payment are already issued";
            }
            form1.Controls.Add(label);
            conn.Close();
           
        }

        protected void paymentid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = paymentid.SelectedValue;
        }
    }
}