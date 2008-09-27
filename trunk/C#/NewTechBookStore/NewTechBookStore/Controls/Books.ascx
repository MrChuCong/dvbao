<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Books.ascx.cs" Inherits="Controls_Books" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td class="page_title">Books</td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="BookID"
            DataSourceID="SqlDataSource1" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="Book ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="BookID" >
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="BookTitle" HeaderText="Title" SortExpression="BookTitle" >
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" >
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" >
                    <ItemStyle Width="50px" />
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
            <PagerStyle BackColor="CadetBlue" ForeColor="Black" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:NewTechBookStoreConnectionString %>"
            DeleteCommand="DELETE FROM [BookDetails] WHERE [BookID] = @original_BookID"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [BookDetails]">
            <DeleteParameters>
                <asp:Parameter Name="original_BookID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:NewTechBookStoreConnectionString %>"
            SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="LightCyan" BorderColor="SteelBlue" ForeColor="Maroon" />
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" Height="50px" AutoGenerateRows="False" DataKeyNames="BookID" DataSourceID="SqlDataSource2"
            BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged">
            <Fields>
                <asp:BoundField DataField="BookID" HeaderText="Book ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="BookID" >                    
                </asp:BoundField>
                <asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" DataValueField="CategoryID"
                            SelectedValue='<%# Bind("CategoryID") %>' Width="160px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" DataValueField="CategoryID"
                            SelectedValue='<%# Bind("CategoryID") %>' Width="160px">
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="85%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Title" SortExpression="BookTitle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BookTitle") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Text="*"
                            ErrorMessage="Book Title cannot be blank"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BookTitle") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Text="*"
                            ErrorMessage="Book Title cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("BookTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author" SortExpression="Author">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Author") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Text="*"
                            ErrorMessage="Author cannot be blank"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Author") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Text="*"
                            ErrorMessage="Author cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Publisher" SortExpression="Publisher">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Publisher") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Text="*"
                            ErrorMessage="Publisher cannot be blank"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Publisher") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Text="*"
                            ErrorMessage="Publisher cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Publisher") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ISBN") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Text="*"
                            ErrorMessage="ISBN cannot be blank"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ISBN") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Text="*"
                            ErrorMessage="ISBN cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Price") %>' Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" Text="*"
                            ErrorMessage="Price cannot be blank"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="TextBox5" Text="*"
                            ErrorMessage="Invalid Price" OnServerValidate="CustomValidator5_ServerValidate"></asp:CustomValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Price") %>' Width="90%"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="TextBox5" Text="*"
                            ErrorMessage="Invalid Price" OnServerValidate="CustomValidator5_ServerValidate"></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" Text="*"
                            ErrorMessage="Price cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" InsertVisible="false">
                    <EditItemTemplate>
                    <asp:Image runat="server" AlternateText="No Image" ImageUrl='<%# this.GetImageUrl(Eval("BookID")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                    <asp:Image runat="server" AlternateText="No Image" ImageUrl='<%# this.GetImageUrl(Eval("BookID")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="90%" Height="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" Text="*"
                            ErrorMessage="Description cannot be blank"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="90%" Height="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" Text="*"
                            ErrorMessage="Description cannot be blank"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
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
            InsertCommand="INSERT INTO [BookDetails] ([CategoryID], [BookTitle], [Author], [Publisher], [ISBN], [Price], [Description]) VALUES (@CategoryID, @BookTitle, @Author, @Publisher, @ISBN, @Price, @Description)"
            OldValuesParameterFormatString="original_{0}"
            SelectCommand="SELECT [BookID], [BookDetails].[CategoryID], [CategoryName], [BookTitle], [Author], [Publisher], [ISBN], [Price], [Description] FROM [BookDetails] JOIN [Categories] ON [BookDetails].[CategoryID] = [Categories].[CategoryID] WHERE ([BookID] = @BookID)"
            UpdateCommand="UPDATE [BookDetails] SET [CategoryID] = @CategoryID, [BookTitle] = @BookTitle, [Author] = @Author, [Publisher] = @Publisher, [ISBN] = @ISBN, [Price] = @Price, [Description] = @Description WHERE [BookID] = @original_BookID">
            <UpdateParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="BookTitle" Type="String" />
                <asp:Parameter Name="Author" Type="String" />
                <asp:Parameter Name="Publisher" Type="String" />
                <asp:Parameter Name="ISBN" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="original_BookID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="BookID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="BookTitle" Type="String" />
                <asp:Parameter Name="Author" Type="String" />
                <asp:Parameter Name="Publisher" Type="String" />
                <asp:Parameter Name="ISBN" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </td>
</tr>
<tr>
    <td style="height:20px"></td>
</tr>
<tr>
    <td>
        <div id="ImageUpload" visible="false" runat="server" style="text-align:center">
        Upload Image:
        &nbsp;&nbsp;
        <asp:FileUpload runat="server" ID="FileUpload1" Width="300px" Height="25px" />
        &nbsp;
        <asp:Button runat="server" ID="Upload1" Text="Upload" Width="80px" Height="25px" OnClick="Upload1_Click" />
        </div>
    </td>
</tr>
</table>