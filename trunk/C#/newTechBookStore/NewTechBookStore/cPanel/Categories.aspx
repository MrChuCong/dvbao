<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="cPanel_Categories" MasterPageFile="~/cPanel/cPanel.master" %>
<%@ Register Src="~/Controls/Categories.ascx" TagName="CategoriesControl" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <uc:CategoriesControl runat="server" />
    </td>
</tr>
</table>
</asp:Content>