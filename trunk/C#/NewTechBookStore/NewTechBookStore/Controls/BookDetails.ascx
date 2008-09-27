<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookDetails.ascx.cs" Inherits="Controls_BookDetails" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td><asp:Label ID="TitleLabel" runat="server" Font-Size="X-Large" ForeColor="Maroon"></asp:Label></td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td align="center">
    <asp:Image ID="BookImage" runat="server" AlternateText="No Image" />
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
    <span class="field">Category:</span> <asp:Label ID="CategoryLabel" runat="server"></asp:Label>
    <br />
    <span class="field">Author:</span> <asp:Label ID="AuthorLabel" runat="server"></asp:Label>
    <br />
    <span class="field">Publisher:</span> <asp:Label ID="PublisherLabel" runat="server"></asp:Label>
    <br />
    <span class="field">ISBN:</span> <asp:Label ID="ISBNLabel" runat="server"></asp:Label>
    <br />
    <span class="field">Price:</span> <asp:Label ID="PriceLabel" runat="server"></asp:Label>
    <br />
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td class="field">Description:</td>
</tr>
<tr>
    <td style="height:10px"></td>
</tr>
<tr>
    <td><asp:Label ID="DescriptionLabel" runat="server"></asp:Label></td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
    <div id="LinksPanel" runat="server"></div>
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
</table>