<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" MasterPageFile="~/Body.master" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="SearchControl" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <uc:SearchControl ID="SearchControl1" runat="server" />
    </td>
</tr>
</table>
</asp:Content>