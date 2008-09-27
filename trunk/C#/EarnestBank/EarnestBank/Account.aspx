<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" MasterPageFile="MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
<form id="FORM" runat="server">
    <div style="text-align:center">
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" class="page_title">Account Information</td>
        </tr>
        <tr>
            <td align="right" class="field">Currency: 
                <asp:DropDownList ID="lstCurrency" runat="server" DataSourceID="SqlDataSource3" DataTextField="Code" DataValueField="Code" OnDataBound="lstCurrency_DataBound" OnSelectedIndexChanged="lstCurrency_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankSystemConnectionString %>"
                    SelectCommand="SELECT [Code] FROM [Currency]"></asp:SqlDataSource><br /><br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:DataList ID="DataList1" runat="server" DataKeyField="AccountNumber" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <table border="0" cellpadding="5" cellspacing="5">
                        <tr>
                            <td align="left" class="field">Account Number:</td>
                            <td align="left"><asp:Label ID="AccountNumberLabel" runat="server" Text='<%# Eval("AccountNumber") %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Customer Name:</td>
                            <td align="left"><asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Account Type:</td>
                            <td align="left"><asp:Label ID="AccountTypeNameLabel" runat="server" Text='<%# Eval("AccountTypeName") %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Address:</td>
                            <td align="left"><asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Email:</td>
                            <td align="left"><asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Phone:</td>
                            <td align="left"><asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Balance Status:</td>
                            <td align="left"><asp:Label ID="BalanceLabel" runat="server" Text='<%# this.Convert(Eval("Balance")) %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Loan Type:</td>
                            <td align="left"><asp:Label ID="LoanTypeLabel" runat="server" Text='<%# this.GetLoan(Eval("LoanType")) %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Loan Status:</td>
                            <td align="left"><asp:Label ID="LoanStatusLabel" runat="server" Text='<%# this.GetLoan(Eval("LoanStatus")) %>'>
                                </asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="field">Last Transaction Date:</td>
                            <td align="left"><asp:Label ID="TransactionDateLabel" runat="server" Text='<%# this.GetDate(Eval("TransactionDate")) %>'>
                                </asp:Label></td>
                        </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankSystemConnectionString %>"
                    SelectCommand="SELECT TOP 1 Customer.AccountNumber, CustomerName, AccountTypeName, Address, Email, Phone, Balance, LoanType, LoanStatus, TransactionDate FROM Customer JOIN AccountType ON AccountType.AccountTypeID = Customer.AccountTypeID LEFT JOIN Loan ON Loan.LoanID = Customer.LoanID LEFT JOIN TransactionDetails ON TransactionDetails.AccountNumber = Customer.AccountNumber WHERE Customer.AccountNumber = @AccountNumber ORDER BY TransactionDate DESC">
                    <SelectParameters>
                        <asp:SessionParameter Name="AccountNumber" SessionField="AccountNumber" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="height:30px"></td>
        </tr>
        <tr>
            <td align="center" class="page_title">Transactions Record</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10"
                    DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" BorderColor="Black" BorderStyle="Dashed" BorderWidth="2px">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Transaction Date" SortExpression="TransactionDate">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# this.GetDate(Eval("TransactionDate")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# this.Convert(Eval("Amount")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance" SortExpression="Balance">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# this.Convert(Eval("Balance")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankSystemConnectionString %>"
                    SelectCommand="SELECT TransactionDate, Type, Amount, Balance FROM TransactionDetails WHERE AccountNumber = @AccountNumber ORDER BY TransactionDate DESC">
                    <SelectParameters>
                        <asp:SessionParameter Name="AccountNumber" SessionField="AccountNumber" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="height:30px"></td>
        </tr>
        </table> 
    </div>
</form>
</asp:Content>
