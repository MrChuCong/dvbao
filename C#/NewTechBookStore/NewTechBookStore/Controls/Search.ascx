<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Controls_Search" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="center" style="vertical-align:middle">
        <asp:TextBox ID="txtKeyword" runat="server" Width="400px" Height="20px"></asp:TextBox>
        <asp:ImageButton runat="server" ImageUrl="~/images/go.gif" />
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
                        <a href="JavaScript: OpenPayPalWindow('https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_cart&business=ntbos_1221864253_biz@gmail.com&display=1')">
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
            SelectCommand="SELECT * FROM [BookDetails] WHERE (([BookTitle] LIKE '%' + @BookTitle + '%') OR ([Description] LIKE '%' + @Description + '%'))">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtKeyword" Name="BookTitle" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtKeyword" Name="Description" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td>
</tr>
</table>