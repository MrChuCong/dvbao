using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using System.Data.SqlClient;

[assembly: ApplicationName("NTBOS Database DCOM")]
[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(false)]

namespace NTBOSDCOM
{
    public class DBServer : ServicedComponent
    {
        private SqlConnection connection = new SqlConnection(
            "Data Source=(local);Initial Catalog=NewTechBookStore;Integrated Security=True");

        private DataSet GetDataSet(string query, string tableName)
        {
            connection.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            try
            {
                dataAdapter.Fill(dataSet, tableName);
            }
            catch { }
            connection.Close();
            return dataSet;
        }

        public int ExecuteQuery(string query)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public DataSet GetUserDetails(string username, string password)
        {
            return GetDataSet(
                "SELECT * FROM Users " +
                "WHERE Username='" + username + "' " +
                "AND Password='" + password + "'", "Users");
        }

        public DataSet GetCategoriesList()
        {
            return GetDataSet("SELECT * FROM Categories ORDER BY CategoryName ASC", "Categories");
        }

        public DataSet GetCategoryDetails(int categoryID)
        {
            return GetDataSet("SELECT * FROM Categories WHERE CategoryID=" + categoryID, "Categories");
        }

        public DataSet GetBookDetails(int bookID)
        {
            return GetDataSet(
                "SELECT BookID, BookDetails.CategoryID, CategoryName, BookTitle, Author, Publisher, ISBN, Price, Description " +
                "FROM BookDetails JOIN Categories ON BookDetails.CategoryID = Categories.CategoryID " +
                "WHERE BookID=" + bookID, "BookDetails");
        }

        public DataSet GetCurrencyDetails(string currencyCode)
        {
            return GetDataSet(
                "SELECT * FROM Currency " +
                "WHERE Code='" + currencyCode + "'", "Currency");
        }
    }
}
