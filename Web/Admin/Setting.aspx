<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Manage.Master" AutoEventWireup="true"
    CodeBehind="Setting.aspx.cs" Inherits="BookShop.Web.Admin.Setting" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <style type="text/css">
        #tb td
        {
           vertical-align:middle;
           text-align:left;
        }
        .style1
        {
            height: 26px;
            width: 18%;
        }
        .style2
        {
            width: 18%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div style="font-size: small">
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="22" width="80%">
            <tr>
                <td style="width: 10px">
                    <img height="28" src="../Images/az-tan-top-left-round-corner.gif" width="10" />
                </td>
                <td bgcolor="#DDDDCC">
                    <span class="STYLE1">修改系统配置</span>
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
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="80%">
        <tr>
            <td bgcolor="#DDDDCC" width="2">
                &nbsp;
            </td>
            <td>
                <div align="center">
                    <table cellpadding="0" cellspacing="10" style="height: 150px;width:80%;" id="tb">
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" class="style1">
                                系统邮件地址：
                            </td>
                            <td align="left" style="height: 26px" valign="top" width="37%">
                                <asp:TextBox ID="txtSenderEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="26" valign="top" class="style2">
                                系统邮件用户名：
                            </td>
                            <td align="left" valign="top" width="37%">
                                <asp:TextBox ID="txtSenderUserName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="26" valign="top" class="style2">
                                系统邮件密码：
                            </td>
                            <td align="left" valign="top" width="37%">
                                <asp:TextBox ID="txtSenderPwd" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="26" valign="top" class="style2">
                                系统邮件SMTP：
                            </td>
                            <td align="left" valign="top" width="37%">
                                <asp:TextBox ID="txtSenderSmtp" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="26" valign="top" class="style2">
                                激活邮件内容：
                            </td>
                            <td align="left" valign="top" width="37%">
                                <asp:TextBox ID="txtActiveContent" runat="server" Rows="8" TextMode="MultiLine" 
                                    Width="305px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="26" valign="top" class="style2">
                                找回密码邮件内容：
                            </td>
                            <td align="left" valign="top" width="37%">
                                <asp:TextBox ID="txtFindPwdContent" runat="server" Rows="8" TextMode="MultiLine"
                                    Width="305px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  colspan="2" style="text-align:center;">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="height: 21px"
                                    Text="保存" /><br />
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
</asp:Content>
