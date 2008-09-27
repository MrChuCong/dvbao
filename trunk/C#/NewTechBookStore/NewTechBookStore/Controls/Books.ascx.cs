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
using System.Drawing;

public partial class Controls_Books : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageUpload.Visible = DetailsView1.CurrentMode == DetailsViewMode.Edit;
    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        GridView1.DataBind();
    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        ImageUpload.Visible = false;
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

    protected void DetailsView1_ModeChanged(object sender, EventArgs e)
    {
        ImageUpload.Visible = DetailsView1.CurrentMode == DetailsViewMode.Edit;
    }

    protected void Upload1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (extension == ".jpg")
            {
                try
                {
                    string id = DetailsView1.DataKey.Value.ToString();
                    FileUpload1.PostedFile.SaveAs(
                        Server.MapPath("upload_dir") + "\\" + id + ".jpg");
                }
                catch { }
            }
        }
    }

    protected string GetImageUrl(object id)
    {
        string filename = Server.MapPath("upload_dir") + "\\" + id + ".jpg";
        if (File.Exists(filename))
        {
            return "~/cPanel/upload_dir/" + id + ".jpg";
        }
        else
        {
            return "~/images/noimage.gif";
        }
    }

    protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
    {
        double price = -1;
        try
        {
            price = Convert.ToDouble(args.Value);
        }
        catch { }
        args.IsValid = price > 0;
    }
}
