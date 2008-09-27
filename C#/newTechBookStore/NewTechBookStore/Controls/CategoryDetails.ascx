<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryDetails.ascx.cs" Inherits="Controls_CategoryDetails" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td class="page_title" style="height: 19px">
        <div id="TitlePanel" runat="server"></div>
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="BookID" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <table border="0" cellpadding="5" cellspacing="5">
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="LinkButton2" runat="server"
                            Text='<%# Eval("BookTitle") %>' ForeColor="Maroon"
                            PostBackUrl='<%# "~/BookDetails.aspx?book_id=" + Eval("BookID") %>' Font-Size="X-Large"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width:260px;vertical-align:top;text-align:center" rowspan="2">
                    <asp:Image ID="BookImage" runat="server" AlternateText="No Image" ImageUrl='<%# this.GetImageUrl(Eval("BookID")) %>' />
                    </td>
                    <td style="width:400px;vertical-align:top">
                    <span class="field">Author:</span>
                    <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>'></asp:Label><br />
                    <span class="field">Publisher:</span>
                    <asp:Label ID="PublisherLabel" runat="server" Text='<%# Eval("Publisher") %>'></asp:Label><br />
                    <span class="field">ISBN:</span>
                    <asp:Label ID="ISBNLabel" runat="server" Text='<%# Eval("ISBN") %>'></asp:Label><br />
                    <span class="field">Price:</span>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# this.ShowPrice(Eval("Price")) %>'></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:bottom">
                        <a href='<%# this.GetViewCartURL() %>'>
                            <div class="viewcart"></div>
                        </a>
                        <br />
                        <a href='<%# this.GetAddToCartURL(Eval("BookTitle"), Eval("Price")) %>'>
                            <div class="addtocart"></div>
                        </a>
                    </td>
                </tr>
                </table>
                <br /><br />
            </ItemTemplate>
        </asp:DataList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewTechBookStoreConnectionString %>"
            SelectCommand="SELECT * FROM [BookDetails] WHERE ([CategoryID] = @CategoryID) ORDER BY [BookID] DESC">
            <SelectParameters>
                <asp:QueryStringParameter Name="CategoryID" QueryStringField="cat_id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td>
</tr>
</table>