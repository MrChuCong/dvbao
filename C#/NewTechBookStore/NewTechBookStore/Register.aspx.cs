using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DatabaseServ;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected void btnOK_Click(object sender, ImageClickEventArgs e)
    {
        DatabaseService databaseServ = new DatabaseService();
        databaseServ.RegisterUser(txtUsername.Text, txtPassword.Text,
            txtFirstName.Text, txtLastName.Text,
            txtAddress.Text, txtEmail.Text, txtPhone.Text);
        Response.Redirect("Default.aspx");
    }
}
