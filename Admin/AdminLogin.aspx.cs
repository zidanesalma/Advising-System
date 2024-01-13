using System;
using System.Web.UI.WebControls;

namespace AdvisingSystem
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login_Click(object sender, EventArgs e)
        {

            Label label = new Label();
            label.CssClass = "dynamicLabelStyle";
            if (Id.Text != "1" || Password.Text != "1")
            {
                label.Text = "Incorrect ID and/or Password";
                return;
            }
            
            Session["adminId"] = Id.Text;
            Response.Redirect("AdminPortal.aspx");
        }
    }
}