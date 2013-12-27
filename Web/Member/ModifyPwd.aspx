<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.Master" AutoEventWireup="true"
    CodeBehind="ModifyPwd.aspx.cs" Inherits="BookShop.Web.Member.ModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: small">
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="22" width="80%">
            <tr>
                <td style="width: 10px">
                    <img height="28" src="../Images/az-tan-top-left-round-corner.gif" width="10" />
                </td>
                <td bgcolor="#DDDDCC">
                    <span class="STYLE1">修改密码</span>
                </td>
                <td width="10">
                    <img height="28" src="../Images/az-tan-top-right-round-corner.gif" width="10" />
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="80%">
            <tr>
                <td bgcolor="#DDDDCC" width="2">
                    &nbsp;
                </td>
                <td>
                    <div align="center">
                        <table cellpadding="0" cellspacing="0" style="height: 150px">
                            <tr>
                                <td align="center" colspan="2">
                                    <input type="hidden" name="hdUid" id="hdUid" value="" runat="server" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 26px" valign="top" width="24%">
                                    用户名
                                </td>
                                <td align="left" style="height: 26px" valign="top" width="37%">
                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="26" valign="top" width="24%">
                                    新密码：
                                </td>
                                <td align="left" valign="top" width="37%">
                                    <input type="password" name="txtPass" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="26" valign="top" width="24%">
                                    确认新密码：
                                </td>
                                <td align="left" valign="top" width="37%">
                                    <input type="password" name="txtTwoPass" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <input type="submit" value="修改" /><br />
                                    <br />
                                    <asp:Label ID="txtMsg" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div class="STYLE5">
                            ---------------------------------------------------------</div>
                    </div>
                </td>
                <td bgcolor="#DDDDCC" width="2">
                    &nbsp;
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
</asp:Content>
