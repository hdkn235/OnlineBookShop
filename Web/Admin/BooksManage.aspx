<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Manage.Master" AutoEventWireup="true"
    CodeBehind="BooksManage.aspx.cs" Inherits="BookShop.Web.Admin.BooksManage" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('input[type=text]').css('width', '80px');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div style="font-size: small;">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem" DataKeyNames="Id">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PublisherIdLabel" runat="server" Text='<%# Eval("PublisherId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PublishDateLabel" runat="server" Text='<%# Eval("PublishDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ISBNLabel" runat="server" Text='<%# Eval("ISBN") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContentDescriptionLabel" runat="server" Text='<%# Eval("ContentDescription") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #008A8C; color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td >
                        <asp:Label ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PublisherIdTextBox" runat="server" Text='<%# Bind("PublisherId") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="PublishDateTextBox" runat="server" Text='<%# Bind("PublishDate") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="ISBNTextBox" runat="server" Text='<%# Bind("ISBN") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="ContentDescriptionTextBox" runat="server" Text='<%# Bind("ContentDescription") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="CategoryIdTextBox" runat="server" Text='<%# Bind("CategoryId") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse;
                    border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                        <td>
                            未返回数据。
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td class="textSmall">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td class="textSmall">
                        <asp:Label ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="PublisherIdTextBox" runat="server" Text='<%# Bind("PublisherId") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="PublishDateTextBox" runat="server" Text='<%# Bind("PublishDate") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="ISBNTextBox" runat="server" Text='<%# Bind("ISBN") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="ContentDescriptionTextBox" runat="server" Text='<%# Bind("ContentDescription") %>' />
                    </td>
                    <td class="textSmall">
                        <asp:TextBox ID="CategoryIdTextBox" runat="server" Text='<%# Bind("CategoryId") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PublisherIdLabel" runat="server" Text='<%# Eval("PublisherId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PublishDateLabel" runat="server" Text='<%# Eval("PublishDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ISBNLabel" runat="server" Text='<%# Eval("ISBN") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContentDescriptionLabel" runat="server" Text='<%# Eval("ContentDescription") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;
                                border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;
                                font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">
                                    </th>
                                    <th runat="server">
                                        Id
                                    </th>
                                    <th runat="server">
                                        Title
                                    </th>
                                    <th runat="server">
                                        Author
                                    </th>
                                    <th runat="server">
                                        PublisherId
                                    </th>
                                    <th runat="server">
                                        PublishDate
                                    </th>
                                    <th runat="server">
                                        ISBN
                                    </th>
                                    <th runat="server">
                                        UnitPrice
                                    </th>
                                    <th runat="server">
                                        ContentDescription
                                    </th>
                                    <th runat="server">
                                        CategoryId
                                    </th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif;
                            color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                                        ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                                        ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PublisherIdLabel" runat="server" Text='<%# Eval("PublisherId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PublishDateLabel" runat="server" Text='<%# Eval("PublishDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ISBNLabel" runat="server" Text='<%# Eval("ISBN") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContentDescriptionLabel" runat="server" Text='<%# Eval("ContentDescription") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="BookShop.Model.Books"
            DeleteMethod="Delete" InsertMethod="Add" SelectMethod="GetModelList" TypeName="BookShop.BLL.BooksBLL"
            UpdateMethod="Update">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
