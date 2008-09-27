<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Users.ascx.cs" Inherits="Controls_Users" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td class="page_title">Users</td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1"
            BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="UserID" >
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" >
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" >
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" >
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" >
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Commands" ShowHeader="False">
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                            Text="Select" ForeColor="Black"></asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                            CommandName="Delete" Text="Delete" ForeColor="Black"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <SelectedRowStyle BackColor="Bisque" />
            <HeaderStyle BackColor="Black" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DDDDDD" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:NewTechBookStoreConnectionString %>"
            DeleteCommand="DELETE FROM [Users] WHERE [UserID] = @original_UserID AND [Type] = 1"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Users]">
            <DeleteParameters>
                <asp:Parameter Name="original_UserID" Type="Int32" />
            </DeleteParameters>            
        </asp:SqlDataSource>
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID"
            DataSourceID="SqlDataSource2" Height="50px" Width="320px"
            BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <Fields>
                <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="UserID" >
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            </Fields>
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NewTechBookStoreConnectionString %>"
            SelectCommand="SELECT * FROM [Users] WHERE ([UserID] = @UserID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="UserID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td>
</tr>
</table>