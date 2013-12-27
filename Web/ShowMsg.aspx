<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMsg.aspx.cs" Inherits="BookShop.Web.ShowMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var sid = setInterval(function () {
                var tObj = document.getElementById('time');
                var t = parseInt(tObj.innerHTML);
                t--;
                if (t > 0) {
                    tObj.innerHTML = t;
                }
                else {
                    clearInterval(sid);
                    location.href = document.getElementById('url').href;
                }
            }, 1000);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="490" height="325" border="0" align="center" cellpadding="0" cellspacing="0"
            background="Images/showinfo.png">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="50">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="40">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="50">
                                &nbsp;
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="#CC0000" Width="98%"></asp:Label>
                            </td>
                            <td width="40">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="50">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="40">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="50" class="style1">
                                &nbsp;
                            </td>
                            <td style="text-align: center">
                                <span id="time" style="font-size: 19px; color: Red;">5</span>秒钟后自动跳转到<a id="url" href="<%= url %>"><%= txt %></a>
                            </td>
                            <td width="40">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
