<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.Master" AutoEventWireup="true"
    CodeBehind="FindPwd.aspx.cs" Inherits="BookShop.Web.Member.FindPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#changeCode').click(function () {
                $('#imgCode').attr('src', '/ashx/ValidateCode.ashx?_=' + Math.random());
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: small">
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="22" width="80%">
            <tr>
                <td style="width: 10px">
                    <img height="28" src="../Images/az-tan-top-left-round-corner.gif" width="10" />
                </td>
                <td bgcolor="#DDDDCC">
                    <span class="STYLE1">找回密码</span>
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
                        <table cellpadding="0" cellspacing="0" style="height: 150px;">
                            <tr>
                                <td align="center" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 26px" valign="top" width="24%">
                                    用户名
                                </td>
                                <td align="left" style="height: 26px" valign="top" width="37%">
                                    <input type="text" name="txtName" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="26" valign="top" width="24%">
                                    Email：
                                </td>
                                <td align="left" valign="top" width="37%">
                                    <input type="text" name="txtEmail" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="26" valign="top" width="24%">
                                    验证码：
                                </td>
                                <td align="left" valign="top" width="37%">
                                    <input type="text" name="txtCode" />
                                    <img src="/ashx/ValidateCode.ashx" alt="验证码" id="imgCode" />
                                    <a href="javascript:void(0)" id="changeCode">看不清？</a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <input type="submit" value="提交" /><br />
                                    <br />
                                    <asp:Label ID="txtMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
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
