<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="BookDetails" MasterPageFile="~/Body.master" %>
<%@ Register Src="~/Controls/BookDetails.ascx" TagName="BookDetailsControl" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <uc:BookDetailsControl ID="BookDetailsControl1" runat="server" />
    </td>
</tr>
</table>
</asp:Content>