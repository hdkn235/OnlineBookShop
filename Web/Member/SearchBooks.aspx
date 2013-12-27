<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBooks.aspx.cs" Inherits="BookShop.Web.Member.SearchBooks"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>北京市新华书店王府井书店 - 网上书店80折起，购书满99元免运费！</title>
    <meta content="北京市新华书店王府井书店，致力于提供专业化购书服务.网上购书选择新华书店王府井书店(网上书店),购书放心有保障.王府井书店电话:010-65132842.010-65252592"
        name="description" />
    <meta content="王府井书店 新华书店 网上书店 网上购书 北京图书大厦" name="keywords" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="/Css/index.css" rel="stylesheet" type="text/css" />
    <link href="../Css/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#w").autocomplete({
                source: "/ashx/AutoComplete.ashx?_=" + Math.random()
            });
            $("#w").focus(function () {

                if ($(this).val() == "请输入搜索内容") {

                    $(this).css("color", "black").val("");
                }
            }).blur(function () {
                //光标离开
                if ($(this).val() == "") {
                    $(this).css("color", "Gray").val("请输入搜索内容");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" method="get" action="SearchBooks.aspx">
    <center>
        <div class="top">
            <div class="m_c" style="width: 750px; height: 27px;">
                <span class="l"><a href="javascript:void(0)" onclick="window.external.addFavorite('http://localhost:12358/BookList.aspx','网上图书商城')">
                    收藏本站</a></span> <span class="r">您好！欢迎来到网上图书商城！&nbsp; <a href="/Member/login.aspx">[登录]</a>&nbsp;
                        <a href="/Member/register.aspx">[免费注册]</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="/OrderInfo.aspx">我的订单</a>
                    </span>
            </div>
        </div>
        <div style="width: 750px;">
            <img src="/images/集团网站1.jpg" width="750px" height="93" /></div>
        <div id="tabsI" style="width: 750px; height: 32px">
            <ul>
                <!-- CSS Tabs -->
                <li><a href="/booklist.aspx"><span>首页</span></a></li>
                <li><a href="/booklist.aspx"><span>推荐图书</span></a></li>
                <li><a href="/booklist.aspx"><span>最新图书</span></a></li>
                <li><a href="/booklist.aspx"><span>热门图书</span></a></li>
                <li><a href="/booklist.aspx"><span>我的购物车</span></a></li>
                <li><a href="/booklist.aspx"><span>购书流程</span></a></li>
                <li><a href="/booklist.aspx"><span>网站留言</span></a></li>
                <li><a href="/booklist.aspx"><span>我的留言</span></a></li>
            </ul>
        </div>
        <div id="search" style="width: 750px; height: 55px">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="text-align: left">
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td bgcolor="#51A8FF">
                                    <table width="94%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100" height="34">
                                            </td>
                                            <td height="34" class="ui-widget" style="text-align: left;">
                                                <input type="text" name="w" style="color: gray; width: 400px" value="<%= txt %>"
                                                    id="w" />
                                            </td>
                                            <td width="10" height="34">
                                            </td>
                                            <td width="100" height="34" style="text-align: left;">
                                                <input type="submit" id="btnSearch" value="" style="background: url('/images/default_r7_c9.gif') left top no-repeat;
                                                    width: 79px; height: 27px; cursor: pointer; border: none;" />
                                            </td>
                                            <td width="100" height="34">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="main_box" style="position: relative; margin-left: auto; margin-right: auto;">
            <div style="text-align: left;">
                <asp:Repeater ID="BookListRepeater" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td rowspan="2">
                                    <a href='<%#BookShop.Web.Common.WebCommon.GetPath( Eval("PublishDate"),Eval("Id")) %>'>
                                        <img alt='<%#Eval("Title") %>' height="121" hspace="4" src='<%#Eval("ISBN","/Images/BookCovers/{0}.jpg") %>'
                                            style="cursor: hand" width="95" /></a>
                                </td>
                                <td style="font-size: small;" width="650">
                                    <a id="link_prd_name" class="booktitle" href='<%#BookShop.Web.Common.WebCommon.GetPath( Eval("PublishDate"),Eval("Id")) %>'
                                        name="link_prd_name">
                                        <%#Eval("Title") %></a>(<%#Eval("PublishDate", "{0:yyyy-MM}")%>)
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <p>
                                        <span style="font-size: 12px; line-height: 20px">
                                            <%#Eval("Author") %></span>
                                    </p>
                                    <p>
                                        <span style="font-size: 12px; line-height: 20px">
                                            <%#Eval("ContentDescription")%>
                                        </span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <span style="font-weight: bold; font-size: 13px; line-height: 20px">&yen;
                                        <%#Eval("UnitPrice","{0:0.00}")%></span>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="footer" style="clear: both; position: relative; bottom: 0px">
            <table border="0" width="100%" class="categories1">
                <tr>
                    <td align="center">
                        <ul>
                            <li><a href='#'>关于我们王府井书店><a href='#'>关于我们王府井书店</li>
                            <li><a href="#">书店营业时间：9：30-21：00 </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/images/logo123x40.jpg" width="123" height="40" border="0">
                            </a><a href="#" target="_blank">
                                <img border="0" src="/images/kaixin.jpg">
                            </a></li>
                            <li>&nbsp;<span lang="zh-cn"><a title="京ICP备08001692号" href="http://www.miibeian.gov.cn">京ICP备08987373号</a></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <!--end foot div -->
    </center>
    </form>
</body>
</html>
