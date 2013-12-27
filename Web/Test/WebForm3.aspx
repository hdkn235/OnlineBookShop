<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="BookShop.Web.Test.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#dlgLogin').click(function () {
                $("#dlgLogin").show();
                $("#dlgLogin").dialog({
                    resizable: false,
                    height: 140,
                    modal: true,
                    buttons: {
                        "登录": function () {
                            $(this).dialog("close");
                        },
                        "取消": function () {
                            $(this).dialog("close");
                        }
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dlgLogin" >
        用户名：<input type="text" id="txtLoginUserName" /><br />
        密码：<input type="password" id="txtLoginPassword" /><br />
        <div id="divLoginMsg" style="color: Red">
        </div>
    </div>
    </form>
</body>
</html>
