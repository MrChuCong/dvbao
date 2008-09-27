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

public partial class cPanel_cPanel : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.RawUrl == "/NewTechBookStore/cPanel/Login.aspx") return;
        bool isAdminUser =
            Session["Username"] != null && Convert.ToInt32(Session["Type"]) == 0;
        if (!isAdminUser)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
