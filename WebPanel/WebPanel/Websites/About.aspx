<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/FirstMaster.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebPanel.Websites.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>About page</h1>
    <asp:DataGrid ID="gridSQL" runat="server" />
</asp:Content>
