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
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected void btnOK_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.
            ConnectionStrings["OnlineBankSystemConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Customer " +
            "WHERE Username='" + txtUsername.Text + "' " +
            "AND Password='" + txtPassword.Text + "'",
            connection);
        SqlDataReader dataReader = command.ExecuteReader();
        if (dataReader.HasRows)
        {
            dataReader.Read();
            Session["Username"] = dataReader["Username"];
            Session["AccountNumber"] = dataReader["AccountNumber"];
            Session["CustomerName"] = dataReader["CustomerName"];
            dataReader.Close();
            connection.Close();
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblInformation.Visible = true;
            lblInformation.Text = "<br />&nbsp;&nbsp;Wrong Username or Password! Please Try Again!&nbsp;&nbsp;<br /><br />";
            dataReader.Close();
            connection.Close();
        }
    }
}
