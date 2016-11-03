<%@ Page Language="C#" MasterPageFile="~/Masters/FirstMaster.Master" AutoEventWireup="true" CodeBehind="Frontpage.aspx.cs" Inherits="WebPanel.Websites.Frontpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <h1>Hello!</h1>
    <asp:Label Text="text" runat="server" ID="lblUser" />
    <p>Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum...</p>
</asp:Content>
