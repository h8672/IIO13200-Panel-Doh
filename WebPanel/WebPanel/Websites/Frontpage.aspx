<%@ Page Language="C#" MasterPageFile="~/Masters/FirstMaster.Master" AutoEventWireup="true" CodeBehind="Frontpage.aspx.cs" Inherits="WebPanel.Websites.Frontpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>Hello<span ID="spanUser" runat="server" />!</h1>
    <p id="infoUserless" runat="server"
        >Welcome anon to MyMySQL Database</p>
    <p>Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum...</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrasidenav" runat="server" />
