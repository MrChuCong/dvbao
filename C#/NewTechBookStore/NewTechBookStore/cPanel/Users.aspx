<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="cPanel_Users" MasterPageFile="~/cPanel/cPanel.master" %>
<%@ Register Src="~/Controls/Users.ascx" TagName="UsersControl" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <uc:UsersControl ID="UsersControl1" runat="server" />
    </td>
</tr>
</table>
</asp:Content>