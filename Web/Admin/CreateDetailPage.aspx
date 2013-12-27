<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Manage.Master" AutoEventWireup="true" CodeBehind="CreateDetailPage.aspx.cs" Inherits="BookShop.Web.Admin.CreateDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
 <div style="font-size: small">
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="22" width="80%">
            <tr>
                <td style="width: 10px">
                    <img height="28" src="../Images/az-tan-top-left-round-corner.gif" width="10" />
                </td>
                <td bgcolor="#DDDDCC">
                    <span class="STYLE1">生成图书详细页面</span>
                </td>
                <td width="10">
                    <img height="28" src="../Images/az-tan-top-right-round-corner.gif" width="10" />
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="3" width="80%">
            <tr>
                <td bgcolor="#DDDDCC" height="3">
                    <img height="9" src="../Images/touming.gif" width="27" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <input type="submit"  value="生成静态页面" />
        <br />
        <br />
        <asp:Button ID="btnCreateIndex" runat="server" onclick="btnCreateIndex_Click" 
            Text="创建图书索引" />
        <br />
        <br />
        <asp:Button ID="btnAddBook" runat="server" onclick="btnAddBook_Click" 
            Text="添加图书" />
    </div>
</asp:Content>
