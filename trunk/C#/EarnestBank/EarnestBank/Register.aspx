<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<form id="FORM" runat="server">
    <div style="text-align:center">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" class="page_title">Online Banking Registration</td>
        </tr>
        <tr>
            <td align="left">
                <p style="text-align:justify">If you haven't yet registered for Earnest Bank - it's a very easy process. Register today and find out how easy it is to keep in control of your money.</p>
            </td>
        </tr>
        </table>
        <br />
        <span class="information">
        <asp:Label ID="lblInformation" runat="server" Visible="False"></asp:Label></span><br />
        <table border="0" cellpadding="5" cellspacing="5">
        <tr>
            <td align="left" class="field">Account Number:</td>
            <td align="left">
                <asp:TextBox ID="txtAccountNumber" runat="server" Width="160px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAccountNumber"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Username:</td>
            <td align="left">
                <asp:TextBox ID="txtUsername" runat="server" Width="160px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Password:</td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Confirmed Password:</td>
            <td align="left">
                <asp:TextBox ID="txtConfirmedPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmedPassword" ErrorMessage="* Unmatched Password"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Full Name:</td>
            <td align="left">
                <asp:TextBox ID="txtFullName" runat="server" Width="160px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFullName"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Account Type:</td>
            <td align="left">
                <asp:DropDownList ID="lstAccountType" runat="server" DataSourceID="SqlDataSource"
                    DataTextField="AccountTypeName" DataValueField="AccountTypeID" Width="166px" Height="24px">
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankSystemConnectionString %>"
                    SelectCommand="SELECT [AccountTypeName], [AccountTypeID] FROM [AccountType]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="left" class="field">Address:</td>
            <td align="left">
                <asp:TextBox ID="txtAddress" runat="server" Width="160px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="* Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Email:</td>
            <td align="left">
                <asp:TextBox ID="txtEmail" runat="server" Width="160px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="* Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="left" class="field">Phone:</td>
            <td align="left">
                <asp:TextBox ID="txtPhone" runat="server" Width="160px"></asp:TextBox></td>
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