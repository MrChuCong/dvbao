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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAccountNumber.Focus();
    }

    protected void btnOK_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.
            ConnectionStrings["OnlineBankSystemConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Customer " +
            "WHERE AccountNumber='" + txtAccountNumber.Text + "' " +
            "OR Username='" + txtUsername.Text + "'",
            connection);
        SqlDataReader dataReader = command.ExecuteReader();
        if (dataReader.HasRows)
        {
            lblInformation.Visible = true;
            lblInformation.Text = "<br />&nbsp;&nbsp;The Account Number or Username exists!&nbsp;&nbsp;<br /><br />";
            dataReader.Close();
            connection.Close();
        }
        else
        {
            dataReader.Close();
            command = new SqlCommand("INSERT INTO Customer VALUES (" +
                "'" + txtAccountNumber.Text + "', '" + txtUsername.Text + "', " +
                "'" + txtPassword.Text + "', '" + txtFullName.Text + "', " +
                "'" + lstAccountType.SelectedValue + "', '', " +
                "'', '" + txtAddress.Text + "', " +
                "'" + txtEmail.Text + "', '" + txtPhone.Text + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            Session["Username"] = txtUsername.Text;
            Session["AccountNumber"] = txtAccountNumber.Text;
            Session["CustomerName"] = txtFullName.Text;
            Response.Redirect("Default.aspx");
        }
    }
}
