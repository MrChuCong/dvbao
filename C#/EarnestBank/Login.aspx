<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<form id="FORM" runat="server">
    <div style="text-align:center">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" class="page_title">Online Banking Log In</td>
        </tr>
        <tr>
            <td align="left">
                <p style="text-align:justify">Only individuals who have an Earnest Bank account authorised to access bank information should proceed beyond this point.  For the security of customers, any unauthorised attempt to access customer bank information will be subject to illegal action.</p>
                <p style="text-align:justify">Please enter your account details below.</p>
            </td>
        </tr>
        </table>
        <br />
        <span class="information">
        <asp:Label ID="lblInformation" runat="server" Visible="False"></asp:Label></span><br />
        <table border="0" cellpadding="5" cellspacing="5">
        <tr>
            <td align="left" class="field">Username:</td>
            <td align="left">
                <asp:TextBox ID="txtUsername" runat="server" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Password:</td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>        
        <tr>
            <td colspan="2" align="center" style="height: 86px">
                <br />
                <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/images/btnok.gif" OnClick="btnOK_Click" />
            </td>
        </tr>
        </table>
    </div>
</form>
</asp:Content>