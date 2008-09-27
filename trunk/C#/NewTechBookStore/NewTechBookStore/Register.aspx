<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" MasterPageFile="~/Body.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<div style="text-align:center">
<table border="0" cellpadding="5" cellspacing="5">
<tr>
    <td colspan="2" align="left"><asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="LightCyan" BorderColor="SteelBlue" ForeColor="Maroon"/></td>
</tr>
<tr>
    <td align="left" class="field">Username:</td>
    <td align="left">
        <asp:TextBox ID="txtUsername" runat="server" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
            Text="*" ErrorMessage="Username cannot be blank"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td align="left" class="field">Password:</td>
    <td align="left">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
            Text="*" ErrorMessage="Password cannot be blank"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td align="left" class="field">Confirmed Password:</td>
    <td align="left">
        <asp:TextBox ID="txtConfirmedPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
            ControlToValidate="txtConfirmedPassword" Text="*" ErrorMessage="Unmatched Password"></asp:CompareValidator>
    </td>
</tr>
<tr>
    <td align="left" class="field">First Name:</td>
    <td align="left">
        <asp:TextBox ID="txtFirstName" runat="server" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
            Text="*" ErrorMessage="First Name cannot be blank"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td align="left" class="field">Last Name:</td>
    <td align="left">
        <asp:TextBox ID="txtLastName" runat="server" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLastName"
            Text="*" ErrorMessage="Last Name cannot be blank"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td align="left" class="field">Address:</td>
    <td align="left">
        <asp:TextBox ID="txtAddress" runat="server" Width="160px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td align="left" class="field">Email:</td>
    <td align="left">
        <asp:TextBox ID="txtEmail" runat="server" Width="160px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            Text="*" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
    <td align="left" class="field">Phone:</td>
    <td align="left">
        <asp:TextBox ID="txtPhone" runat="server" Width="160px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td colspan="2" align="center" style="height: 86px">
        <br />
        <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/images/btnok.gif" OnClick="btnOK_Click" />
    </td>
</tr>
</table>
</div>
</asp:Content>