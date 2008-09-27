using System;
using System.Collections.Generic;
using System.Text;
using NTBOSDCOM;
using System.Data;

namespace TestDCOM
{
    class Program
    {
        static void Main(string[] args)
        {
            DBServer dbServer = new DBServer();
            try
            {
                DataSet ds = dbServer.GetCurrencyDetails("AUD");
                Console.WriteLine(ds.Tables["Currency"].Rows[0]["ExchangeRate"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            Console.ReadLine();
        }
    }
}
