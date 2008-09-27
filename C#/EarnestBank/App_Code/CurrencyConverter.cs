using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

[WebService(Namespace = "http://earnestbank.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CurrencyConverter : System.Web.Services.WebService
{
    private string currency = "USD";
    private double exchangeRate = 1.00;

    public CurrencyConverter()
    {
    }

    [WebMethod]
    public string Convert(double value, string currency)
    {
        if (this.currency != currency)
        {
            this.currency = currency;
            SqlConnection connection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["OnlineBankSystemConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Currency " +
                "WHERE Code='" + currency + "'", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                exchangeRate = System.Convert.ToDouble(dataReader["ExchangeRate"]);
            }
            dataReader.Close();
            connection.Close();
        }
        value *= exchangeRate;
        return String.Format("{0:0.00}", value) + " " + currency;
    }
}
