<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buy.Master" AutoEventWireup="true"
    EnableViewState="false" CodeBehind="Cart.aspx.cs" Inherits="BookShop.Web.Member.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            getTotalMoney();
        });

        //更新商品数量
        function changeBar(oper, id) {
            var $txtCount = $('#txtCount' + id);
            var count = parseInt($txtCount.val());
            if (oper == '+') {
                count++;
            }
            else if (oper == '-') {
                count--;
            }
            if (count == 0) {
                del(id);
                return false;
            }
            $.post("/ashx/CartOperation.ashx", { oper: 'change', id: id, count: count }, function (res) {
                if (res == 'yes') {
                    $txtCount.val(count);
                    getTotalMoney();
                }
            });
        }

        //删除商品
        function del(id, isBack, control) {
            $("#delMsg").text(" 确定删除该商品吗？");
            $("#dvDelMsg").dialog({
                resizable: false,
                height: 140,
                modal: true,
                show: {
                    effect: "blind",
                    duration: 500
                },
                hide: {
                    effect: "explode",
                    duration: 500
                },
                buttons: {
                    "确定": function () {
                        $.post("/ashx/CartOperation.ashx", { oper: 'del', id: id }, function (res) {
                            if (res == 'yes') {
                                $('#tr' + id).remove();
                                getTotalMoney();
                            }
                        });
                        $(this).dialog("close");
                    },
                    "取消": function () {
                        if (isBack) {
                            $(control).val(oldCount);
                        }
                        $(this).dialog("close");
                    }
                }
            });

        }

        function ShowMsg(msg) {
            $("#msg").text(msg);
            $("#dvMsg").dialog({
                modal: true,
                show: {
                    effect: "blind",
                    duration: 500
                },
                hide: {
                    effect: "explode",
                    duration: 500
                },
                buttons: {
                    "确定": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }

        var oldCount;
        function changeTxtOnFocus(control) {
            oldCount = $(control).val();
        }

        function changeTextOnBlur(id, control) {
            var count = $(control).val();
            if (count == 0) {
                del(id, true, control);
                return false;
            }
            var reg = /^\d{1,3}$/;
            if (reg.test(count)) {
                $.post("/ashx/CartOperation.ashx", { oper: 'change', id: id, count: count }, function (res) {
                    if (res == 'yes') {
                        getTotalMoney();
                    }
                });
            }
            else {
                ShowMsg("商品数量只能是数字！");
                $(control).val(oldCount);
            }

        }

        function getTotalMoney() {
            var totalMoney = 0;
            $(".align_Center:gt(0)").each(function () {
                var p = $(this).find('.price').text();
                var c = $(this).find('input').val();
                totalMoney += parseFloat(p) * parseInt(c);
            });
            $('#totleMoney').text(totalMoney);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="98%">
            <tr>
                <td colspan="2">
                    <img height="27" src="/images/shop-cart-header-blue.gif" width="206" alt="" /><img
                        alt="" src="/Images/png-0170.png" /><asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl="/Member/">我的订单</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" width="98%">
                    <table cellpadding='0' cellspacing='0' width='100%'>
                        <tr class='align_Center Thead'>
                            <td width='7%' style='height: 30px'>
                                图片
                            </td>
                            <td>
                                图书名称
                            </td>
                            <td width='14%'>
                                单价
                            </td>
                            <td width='11%'>
                                购买数量
                            </td>
                            <td width='7%'>
                                删除图书
                            </td>
                        </tr>
                        <asp:Repeater ID="rptCartList" runat="server">
                            <ItemTemplate>
                                <tr class='align_Center' id="tr<%#Eval("Id")%>">
                                    <td style='padding: 5px 0 5px 0;'>
                                        <a href='<%#BookShop.Web.Common.WebCommon.GetPath( Eval("Book.PublishDate"),Eval("Book.Id")) %>'>
                                            <img src='<%#Eval("Book.ISBN","/Images/BookCovers/{0}.jpg") %>' width="40" height="50"
                                                border="0" alt="" /></a>
                                    </td>
                                    <td class='align_Left'>
                                        <a href='<%#BookShop.Web.Common.WebCommon.GetPath( Eval("Book.PublishDate"),Eval("Book.Id")) %>'>
                                            <%#Eval("Book.Title") %></a>
                                    </td>
                                    <td>
                                        <span class='price'>
                                            <%#Eval("Book.UnitPrice","{0:0.00}")%></span>
                                    </td>
                                    <td>
                                        <a href='javascript:void(0)' title='减一' onclick="changeBar('-',<%#Eval("Id")%>)"
                                            style='margin-right: 2px;'>
                                            <img src="/Images/bag_close.gif" width="9" height="9" border='none' style='display: inline'
                                                alt="" /></a>
                                        <input type='text' id='txtCount<%#Eval("Id") %>' name='txtCount<%#Eval("Id") %>'
                                            maxlength='3' style='width: 30px' onkeydown='if(event.keyCode == 13) event.returnValue = false'
                                            value='<%#Eval("Count") %>' onfocus='changeTxtOnFocus(this);' onblur="changeTextOnBlur(<%#Eval("Id")%>,this);" />
                                        <a href='javascript:void(0)' title='加一' onclick="changeBar('+',<%#Eval("Id")%>)"
                                            style='margin-left: 2px;'>
                                            <img src='/images/bag_open.gif' width="9" height="9" border='none' style='display: inline'
                                                alt="" /></a>
                                    </td>
                                    <td>
                                        <a href='javascript:void(0)' id='btnDel<%#Eval("Id") %>' onclick="del(<%#Eval("Id") %>)">
                                            删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td class='align_Right Tfoot' colspan='5' style='height: 30px'>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;&nbsp;&nbsp; 商品金额总计：<span id="totleMoney" style="font-size: large; color: Red;">0</span>元
                </td>
                <td>
                    &nbsp; <a href="/booklist.aspx">
                        <img alt="" src="/Images/gobuy.jpg" width="103" height="36" border="0" />
                    </a><a href="/Member/OrderConfirm.aspx">
                        <img src="/images/balance.gif" border="0" /></a>
                </td>
            </tr>
        </table>
    </div>
    <div id="dvMsg" title="提示">
        <p id="msg">
        </p>
    </div>
    <div id="dvDelMsg" title="提示">
        <p id="delMsg">
        </p>
    </div>
</asp:Content>
