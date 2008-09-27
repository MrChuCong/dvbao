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

public partial class MasterPage : System.Web.UI.MasterPage
{
    public DropDownList CurrencyList
    {
        get
        {
            return lstCurrency;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Currency"] == null) Session["Currency"] = "USD";
        if (lstCurrency.SelectedValue.Length > 0) Session["Currency"] = lstCurrency.SelectedValue;
        if (Session["Username"] != null)
        {
            lblWelcome.Visible = true;
            string welcome = Session["Fullname"] +
                " [ <a href='/NewTechBookStore/Logout.aspx'>Logout</a>";
            if (Convert.ToInt32(Session["Type"]) == 0)
            {
                welcome += " | <a href='/NewTechBookStore/cPanel/Default.aspx'>cPanel</a>";
            }
            welcome += " ]";
            lblWelcome.Text = welcome;
        }
    }

    protected void lstCurrency_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i < lstCurrency.Items.Count; i++)
                if (lstCurrency.Items[i].Value == Session["Currency"].ToString())
                {
                    lstCurrency.SelectedIndex = i;
                    return;
                }
        }
    }
}
