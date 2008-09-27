<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryDetails.aspx.cs" Inherits="CategoryDetails" MasterPageFile="~/Body.master" %>
<%@ Register Src="~/Controls/CategoryDetails.ascx" TagName="CategoryDetailsControl" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <uc:CategoryDetailsControl ID="CategoryDetailsControl1" runat="server" />
    </td>
</tr>
</table>
</asp:Content>