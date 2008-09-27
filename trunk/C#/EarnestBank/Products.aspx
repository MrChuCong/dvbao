<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<form id="FORM" runat="server">
    <div style="text-align:center">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" align="center" class="page_title">Our Products</td>
        </tr>
        <tr>
            <td colspan="2">
                <p style="text-align:justify; padding-bottom:40px">Earnest Bank offers a variety of products and services to meet every need and help you achieve your financial goals. And you can apply right online - with many of our checking and credit cards offering instant approval.</p>
            </td>
        </tr>
        <tr>
            <td class="products_category">Bank Accounts</td>
            <td class="products_category">Loan Details</td>
        </tr>
        <tr>
            <td class="products_overview">Basic bank accounts, current accounts and longer-term savings accounts - how they work, who can open one and tips on how to choose.</td>
            <td class="products_overview">Since no two customers are alike, we continually strive to provide customers with loan options that meet their specific needs.</td>
        </tr>
        <tr>
            <td>
                <a href="BankAccounts.aspx"><img src="images/btnmore.gif" alt="" style="border:0px" /></a>
            </td>
            <td>
                <a href="LoanDetails.aspx"><img src="images/btnmore.gif" alt="" style="border:0px" /></a>
            </td>
        </tr>
        </table>
    </div>
</form>
</asp:Content>