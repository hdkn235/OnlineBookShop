<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookShop.Web.Member.Login" %>
<%@ Register src="/UserControls/ULogin.ascx" tagname="ULogin" tagprefix="uc1" %>
<%@ Register src="../UserControls/ULogin.ascx" tagname="ULogin" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ULogin ID="ULogin1" runat="server" />
</asp:Content>
