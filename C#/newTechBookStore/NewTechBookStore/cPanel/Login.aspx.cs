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

public partial class cPanel_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        DatabaseService databaseServ = new DatabaseService();
        DataSet dataSet = databaseServ.GetUserDetails(txtUsername.Text, txtPassword.Text);
        DataTable dataTable = dataSet.Tables["Users"];
        if (dataTable.Rows.Count > 0)
        {
            DataRow userData = dataTable.Rows[0];
            int userType = Convert.ToInt32(userData["Type"]);
            if (userType == 0)
            {
                Session["UserID"] = Convert.ToInt32(userData["UserID"]);
                Session["Username"] = userData["Username"];
                Session["Type"] = userType;
                Session["Fullname"] = userData["FirstName"] + " " + userData["LastName"];
                Response.Redirect("Default.aspx");
            }
        }
    }
}
