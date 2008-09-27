using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DatabaseServ;
using CurrencyServ;

public partial class Controls_Search : System.Web.UI.UserControl
{
    private DatabaseService databaseServ = new DatabaseService();
    private CurrencyConverter currencyServ = new CurrencyConverter();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtKeyword.Focus();
        if (IsPostBack)
        {
            DataList1.DataBind();
        }
    }

    protected string GetImageUrl(object id)
    {
        string filename = Server.MapPath("cPanel\\upload_dir") + "\\" + id + ".jpg";
        if (File.Exists(filename))
        {
            return "~/cPanel/upload_dir/" + id + ".jpg";
        }
        else
        {
            return "~/images/noimage.gif";
        }
    }

    protected string GetAddToCartURL(object title, object price)
    {
        string url = "https://www.sandbox.paypal.com/cgi-bin/webscr" +
            "?cmd=_cart" +
            "&business=ntbos_1221864253_biz@gmail.com" +
            "&item_name=" + title +
            "&amount=" + price +
            "&no_shipping=0" +
            "&no_note=1" +
            "&currency_code=USD" +
            "&add=1";
        return "JavaScript: OpenPayPalWindow(\"" + url + "\")";
    }

    protected String ShowPrice(object price)
    {
        return currencyServ.Convert(System.Convert.ToDouble(price), Session["Currency"].ToString());
    }
}
