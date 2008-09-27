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

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Currency"] == null) Session["Currency"] = "USD";
        if (Session["Username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
        }
    }

    protected string GetLoan(object data)
    {
        string result = data.ToString();
        if (result.Length == 0) result = "None";
        return result;
    }

    protected string GetDate(object data)
    {
        if (data == DBNull.Value) return "None";
        DateTime date = System.Convert.ToDateTime(data);
        return date.ToString("MM/dd/yyyy");
    }

    protected string Convert(object data)
    {
        if (data == DBNull.Value) return "None";
        return (new CurrencyConverterService.CurrencyConverter()).
            Convert(System.Convert.ToDouble(data), Session["Currency"].ToString());
    }

    protected void lstCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Currency"] = lstCurrency.SelectedValue;
        DataList1.DataBind();
        GridView1.DataBind();
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
