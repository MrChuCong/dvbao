using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using NTBOSDCOM;

[WebService(Namespace = "http://NewTechBookStore.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CurrencyConverter : System.Web.Services.WebService
{
    private DBServer dbServer;
    private string currency = "USD";
    private double exchangeRate = 1.00;

    public CurrencyConverter()
    {
        dbServer = new DBServer();
    }

    [WebMethod]
    public string Convert(double value, string currency)
    {
        if (this.currency != currency)
        {
            this.currency = currency;
            DataSet dataSet = dbServer.GetCurrencyDetails(currency);
            if (dataSet.Tables["Currency"] != null &&
                dataSet.Tables["Currency"].Rows.Count > 0)
            {
                exchangeRate = System.Convert.ToDouble(dataSet.Tables["Currency"].Rows[0]["ExchangeRate"]);
            }
        }
        value *= exchangeRate;
        return String.Format("{0:0.00}", value) + " " + currency;
    }
}

