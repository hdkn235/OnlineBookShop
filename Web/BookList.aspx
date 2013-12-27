<%@ Page Title="" Language="C#" MasterPageFile="~/Master/List.Master" AutoEventWireup="true"
    CodeBehind="BookList.aspx.cs" Inherits="BookShop.Web.BookList" %>

<%@ Register Src="UserControls/UPagedBar.ascx" TagName="UPagedBar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Css/BookList.css" />
    <link href="Css/PagedBar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".paged a").mouseover(function () {
                $(this).css('backgroundColor', '#9CAAC1');
            }).mouseout(function () {
                $(this).css('backgroundColor', '');
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="divOrder">
        <div style="margin: 10px 0px; text-align: left">
            排序方式：
            <input class="orderButton" type="submit" value="<%=obDateBtnValue %>" name="btnDate" />
            |
            <input class="orderButton" type="submit" value="<%=orderbyBtnValue %>" name="btnPrice" />
        </div>
    </div>
    <asp:Repeater ID="BookListRepeater" runat="server" EnableViewState="false">
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
                            name="link_prd_name" >
                            <%#Eval("Title") %></a>(<%#Eval("PublishDate", "{0:yyyy-MM}")%>)
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span style="font-size: 12px; line-height: 20px">
                            <%#Eval("Author") %></span><br />
                        <br />
                        <span style="font-size: 12px; line-height: 20px">
                            <%#BookShop.Web.Common.WebCommon.CutString(Eval("ContentDescription").ToString(),150)%>
                        </span>
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
    <%--    <div class="contentstyle" style="margin: 20px 0px; text-align: center">
        第<%=pageIndex %>页 / 共<%=pageCount %>页
        <input type="submit" name="btnPre" value="上一页" id="btnPre" class="pageButton" />
        <input type="submit" name="btnNext" value="下一页" id="btnNext" class="pageButton" />
        <input type="hidden" name="hiddenPageIndex" value="<%=pageIndex %>" />
    </div>--%>
    <uc1:UPagedBar ID="pageBar" runat="server" />
</asp:Content>
