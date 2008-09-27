<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="cPanel_Login" MasterPageFile="~/cPanel/cPanel.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<div style="text-align:center">
<table border="0" cellpadding="5" cellspacing="5">
<tr>
    <td align="left">Username:</td>
    <td align="left"><asp:TextBox ID="txtUsername" runat="server" Width="180px"></asp:TextBox></td>
</tr>
<tr>
    <td align="left">Password:</td>
    <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox></td>
</tr>
<tr>
    <td colspan="2" align="center"><asp:Button ID="btnOK" runat="server" Text="OK" Width="50px" OnClick="btnOK_Click" /></td>
</tr>
</table>
</div>
</asp:Content>