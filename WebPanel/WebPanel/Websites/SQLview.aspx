<%@ Page Language="C#" MasterPageFile="~/Masters/FirstMaster.Master" AutoEventWireup="true" CodeBehind="SQLview.aspx.cs" Inherits="WebPanel.Websites.SQLview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!--Need tab menu for page-->
    <table>
        <tr>
            <td>
                <asp:Menu CssClass="w3-container"
                    ID="tabMenu" runat="server"
                    Orientation="Horizontal"
                    StaticEnableDefaultPopOutImage="false"
                    OnMenuItemClick="tabMenu_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="List items" Value="0" />
                        <asp:MenuItem Text="Attributes" Value="1" />
                        <asp:MenuItem Text="Log" Value="2" />
                    </Items>
                </asp:Menu>
            </td>
            <td>
                <!--Dropdownlist for databases-->
                <asp:DropDownList ID="ddlDatabases" runat="server" />
            </td>
            <td>
                <!--Dropdownlist for tables-->
                <asp:DropDownList ID="ddlTables" runat="server" />
            </td>
        </tr>
    </table>
    <asp:TextBox Text="test!" runat="server"></asp:TextBox>
    <!--Need tab view for page-->
    <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
        <asp:View ID="Tab1" runat="server">
            <!--TODO fetch items from selected database from selected table-->
            <asp:Button Text="TestTab1" runat="server" />
        </asp:View>
        <asp:View ID="Tab2" runat="server">
            <!--TODO fetch attributes from selected database from selected table-->
            <asp:Button Text="TestTab2" runat="server" />
        </asp:View>
        <asp:View ID="Tab3" runat="server">
            <!--TODO fetch log from selected database-->
            <asp:Button Text="TestTab3" runat="server" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrasidenav" runat="server">
    <table>
        <tr>
            <th>Database</th>
        </tr><tr>
            <td><asp:DropDownList ID="ddlDatabase" runat="server" /></td>
        </tr><tr>
            <th>Table</th>
        </tr><tr>
            <td><asp:DropDownList ID="ddlTable" runat="server" /></td>
        </tr>
    </table><br />
    <asp:Button ID="btnAdd" Text="Add item" CssClass="w3-btn-block w3-dark-grey" runat="server" OnClick="btnAdd_Click" /><br />
    <asp:Button ID="btnEdit" Text="Edit item" CssClass="w3-btn-block w3-dark-grey" runat="server" OnClick="btnEdit_Click" /><br />
    <asp:Button ID="btnRemove" Text="Remove item" CssClass="w3-btn-block w3-dark-grey" runat="server" OnClick="btnRemove_Click" /><br />
</asp:Content>
