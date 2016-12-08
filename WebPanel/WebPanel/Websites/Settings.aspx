<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/FirstMaster.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="WebPanel.Websites.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <table>
        <tr>
            <th colspan="3" style="border-bottom: solid 1px">
                MySQL database
            </th>
        </tr><tr>
            <td colspan="2"><asp:TextBox ID="tbServerUrl" TextMode="SingleLine" runat="server" /></td>
            <td><asp:Button Text="Save" ID="btnSaveServer" runat="server" /></td>
        </tr><tr>
            <td colspan="2"><asp:GridView ID="gvData" runat="server" /></td>
            <td>
                <asp:Button Text="Edit" ID="btnEditServer" runat="server" /><br />
                <asp:Button Text="Delete" ID="btnDeleteServer" runat="server" />
            </td>
        </tr><tr>
            <th colspan="3" style="border-bottom: solid 1px">User</th>
        </tr><tr>
            <td>Old Password</td>
            <td colspan="2"><asp:TextBox ID="tbOldPassword" TextMode="Password" runat="server" /></td>
        </tr><tr>
            <td>Retype</td>
            <td colspan="2"><asp:TextBox ID="tbReOldPassword" TextMode="Password" runat="server" /></td>
        </tr><tr>
            <td colspan="3"><asp:Button Text="Change password" ID="btnChangePassword" runat="server" /></td>
        </tr><tr>
            <td>Email</td>
            <td colspan="2"><asp:TextBox ID="tbEmailChange" TextMode="Email" runat="server" /></td>
        </tr><tr>
            <td colspan="3"><asp:Button Text="Ask for change" ID="btnEmailChange" runat="server" /></td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrasidenav" runat="server">
</asp:Content>
