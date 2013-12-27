<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BookShop.Web.Test.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请输入搜索内容:<input type="text" name="txtContent" />
        <input type="submit" value="搜索" name="btnSearch" />
        <input type="submit" value="创建索引" name="btnCreate" />
        <br />
        <ul>
            <asp:Repeater ID="SearchRepeater" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <li><a href='<%#Eval("Url") %>'>
                        <%#Eval("Title")%></a></li>
                    <li>
                        <%#Eval("Msg")%></li>
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
            </asp:Repeater>
        </ul>
    </div>
    </form>
</body>
</html>
