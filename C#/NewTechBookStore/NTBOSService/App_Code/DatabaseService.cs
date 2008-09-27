using System;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.Services;
using System.Web.Services.Protocols;
using NTBOSDCOM;

[WebService(Namespace = "http://NewTechBookStore.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class DatabaseService : System.Web.Services.WebService
{
    private DBServer dbServer;

    public DatabaseService()
    {
        dbServer = new DBServer();
    }

    [WebMethod]
    public DataSet GetUserDetails(string username, string password)
    {
        return dbServer.GetUserDetails(username, password);
    }

    [WebMethod]
    public DataSet GetCategoriesList()
    {
        return dbServer.GetCategoriesList();
    }

    [WebMethod]
    public DataSet GetCategoryDetails(int categoryID)
    {
        return dbServer.GetCategoryDetails(categoryID);
    }

    [WebMethod]
    public DataSet GetBookDetails(int bookID)
    {
        return dbServer.GetBookDetails(bookID);
    }

    [WebMethod]
    public int RegisterUser(string Username, string Password,
        string FirstName, string LastName, string Address, string Email, string Phone)
    {
        return dbServer.ExecuteQuery(
            "INSERT INTO Users (Username, Password, Type, FirstName, LastName, Address, Email, Phone)" +
            "VALUES ('" + Username + "', '" + Password + "', " + 1 + ", '" + FirstName + "', " +
            "'" + LastName + "', '" + Address + "', '" + Email + "', '" + Phone + "')");
    }
}
