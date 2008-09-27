<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/Body.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<div style="text-align:center">
<table border="0" cellpadding="5" cellspacing="5">
<tr>
    <td align="left" class="field">Username:</td>
    <td align="left"><asp:TextBox ID="txtUsername" runat="server" Width="180px"></asp:TextBox></td>
</tr>
<tr>
    <td align="left" class="field">Password:</td>
    <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox></td>
</tr>
<tr>
    <td colspan="2" align="center"><br /><asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/images/btnok.gif" OnClick="btnOK_Click" /></td>
</tr>
</table>
</div>
</asp:Content>