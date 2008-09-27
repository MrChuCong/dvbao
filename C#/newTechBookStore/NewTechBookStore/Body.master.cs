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
using DatabaseServ;

public partial class Body : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseService databaseServ = new DatabaseService();
        DataSet dataSet = databaseServ.GetCategoriesList();
        DataTable dataTable = dataSet.Tables["Categories"];
        string html = "<table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            DataRow category = dataTable.Rows[i];
            html += "<tr><td>";
            html += "<a href=\"CategoryDetails.aspx?cat_id=" + category["CategoryID"] + "\">" +
                category["CategoryName"] + "</a>";
            html += "</td></tr>";
        }
        html += "</table>";
        CategoriesPanel.InnerHtml = html;
    }
}
