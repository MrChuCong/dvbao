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
using System.IO;
using DatabaseServ;
using CurrencyServ;

public partial class Controls_BookDetails : System.Web.UI.UserControl
{
    private DatabaseService databaseServ = new DatabaseService();
    private int bookID;

    protected void Page_Load(object sender, EventArgs e)
    {
        bookID = Convert.ToInt32(Request.QueryString["book_id"]);
        DataSet dataSet = databaseServ.GetBookDetails(bookID);
        if (dataSet.Tables["BookDetails"].Rows.Count > 0)
        {
            string filename = Server.MapPath("cPanel\\upload_dir") + "\\" + bookID + ".jpg";
            if (File.Exists(filename))
            {
                BookImage.ImageUrl = "~/cPanel/upload_dir/" + bookID + ".jpg";
            }
            else
            {
                BookImage.ImageUrl = "~/images/noimage.gif";
            }
            DataRow bookDetails = dataSet.Tables["BookDetails"].Rows[0];
            TitleLabel.Text = bookDetails["BookTitle"].ToString();
            CategoryLabel.Text = "<a href=\"CategoryDetails.aspx?cat_id=" + bookDetails["CategoryID"].ToString() + "\">" + bookDetails["CategoryName"].ToString() + "</a>";
            AuthorLabel.Text = bookDetails["Author"].ToString();
            PublisherLabel.Text = bookDetails["Publisher"].ToString();
            ISBNLabel.Text = bookDetails["ISBN"].ToString();
            PriceLabel.Text = (new CurrencyConverter()).Convert(System.Convert.ToDouble(bookDetails["Price"]),
                Session["Currency"].ToString());
            DescriptionLabel.Text = bookDetails["Description"].ToString();
            string url = "https://www.sandbox.paypal.com/cgi-bin/webscr" +
                "?cmd=_cart" +
                "&business=ntbos_1221864253_biz@gmail.com" +
                "&item_name=" + bookDetails["BookTitle"].ToString() +
                "&amount=" + bookDetails["Price"].ToString() +
                "&no_shipping=0" +
                "&no_note=1" +
                "&currency_code=USD" +
                "&add=1";
            if (Session["Username"] != null)
            {
                LinksPanel.InnerHtml = "<a href=\"JavaScript: OpenPayPalWindow('https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_cart&business=ntbos_1221864253_biz@gmail.com&display=1')\">" +
                    "<div class=\"viewcart\"></div></a><br />" +
                    "<a href='JavaScript: OpenPayPalWindow(\"" + url + "\")'>" +
                    "<div class=\"addtocart\"></div></a>";
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
