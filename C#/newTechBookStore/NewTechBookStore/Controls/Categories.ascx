<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Categories.ascx.cs" Inherits="Controls_Categories" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td colspan="2" class="page_title">Categories</td>
</tr>
<tr>
    <td colspan="2" style="height:20px"></td>
</tr>
<tr>
    <td colspan="2">
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="CategoryID" DataSourceID="SqlDataSource1"
            BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="CategoryID" HeaderText="Category ID" InsertVisible="False"
                    ReadOnly="True" SortExpression="CategoryID">
                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" >
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
            DeleteCommand="DELETE FROM [Categories] WHERE [CategoryID] = @original_CategoryID"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Categories]">
            <DeleteParameters>
                <asp:Parameter Name="original_CategoryID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </td>
</tr>
<tr>
    <td colspan="2" style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="CategoryID"
            DataSourceID="SqlDataSource2" Height="50px" Width="400px"
            BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated">
            <Fields>
                <asp:TemplateField HeaderText="Category ID" InsertVisible="False" SortExpression="CategoryID">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name" SortExpression="CategoryName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1" Text="*"
                            ErrorMessage="Category Name cannot be blank"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Text="*"
                            ErrorMessage="Category Name cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemStyle Width="200px" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" ForeColor="Black"></asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" ForeColor="Black"></asp:LinkButton>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" ForeColor="Black"></asp:LinkButton>
                        &nbsp;                            
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" ForeColor="Black"></asp:LinkButton>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" ForeColor="Black"></asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" ForeColor="Black"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:NewTechBookStoreConnectionString %>"            
            InsertCommand="INSERT INTO [Categories] ([CategoryName]) VALUES (@CategoryName)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Categories] WHERE ([CategoryID] = @CategoryID)"
            UpdateCommand="UPDATE [Categories] SET [CategoryName] = @CategoryName WHERE [CategoryID] = @original_CategoryID">            
            <UpdateParameters>
                <asp:Parameter Name="CategoryName" Type="String" />
                <asp:Parameter Name="original_CategoryID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="CategoryID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="CategoryName" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </td>    
    <td style="width:100%; padding-left:5px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="LightCyan" BorderColor="SteelBlue" ForeColor="Maroon" />
    </td>
</tr>
</table>