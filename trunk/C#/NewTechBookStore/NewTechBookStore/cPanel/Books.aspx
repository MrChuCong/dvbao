<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="cPanel_Books" MasterPageFile="~/cPanel/cPanel.master" %>
<%@ Register Src="~/Controls/Books.ascx" TagName="BooksControl" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <uc:BooksControl ID="BooksControl1" runat="server" />
    </td>
</tr>
</table>
</asp:Content>