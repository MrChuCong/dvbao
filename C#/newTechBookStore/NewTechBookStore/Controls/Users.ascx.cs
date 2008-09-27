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

public partial class Controls_Users : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (DataControlFieldCell dataControlFieldCell in e.Row.Cells)
            {
                foreach (Control control in dataControlFieldCell.Controls)
                {
                    LinkButton button = control as LinkButton;
                    if (button != null && button.CommandName == "Delete")
                    {
                        button.Attributes.Add("onClick",
                            "return confirm(\"Do you want to delete this record?\")");
                    }
                }
            }
        }
    }
}
