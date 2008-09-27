<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoanDetails.aspx.cs" Inherits="LoanDetails" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<form id="FORM" runat="server">
    <div style="text-align:center">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" class="page_title">Loan Details</td>
        </tr>
        <tr>
            <td align="right" class="field">Currency:
                <asp:DropDownList ID="lstCurrency" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Code" DataValueField="Code" OnDataBound="lstCurrency_DataBound" OnSelectedIndexChanged="lstCurrency_SelectedIndexChanged">
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankSystemConnectionString %>"
                    SelectCommand="SELECT [Code] FROM [Currency]"></asp:SqlDataSource>
                <br /><br />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataSourceID="SqlDataSource"
                    ForeColor="#333333">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <ItemTemplate>
                        <span class="products_category">
                        <asp:Label ID="LoanTypeLabel" runat="server" Text='<%# Eval("LoanType") %>'></asp:Label></span><br /><br />
                        <strong><span style="font-size: 13pt">Rates Of Interest</span></strong>:
                        <asp:Label ID="InterestRateLabel" runat="server" Text='<%# Eval("InterestRate") %>'>
                        </asp:Label> %<br />
                        <strong><span style="font-size: 13pt">Minimum Down Payment</span></strong>:
                        <asp:Label ID="MinDownPaymentLabel" runat="server" Text='<%# this.Convert(Eval("MinDownPayment")) %>'>
                        </asp:Label><br />
                        <div style="text-align:justify">
                        <span style="font-size: 13pt"><strong>Description</strong></span>:
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'>
                        </asp:Label></div><br />
                        <br />
                    </ItemTemplate>
                    <AlternatingItemStyle ForeColor="#284775" />
                    <ItemStyle ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                </asp:DataList><asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankSystemConnectionString %>"
                    SelectCommand="SELECT [LoanType], [InterestRate], [MinDownPayment], [Description] FROM [Loan]">
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
    </div>
</form>
</asp:Content>