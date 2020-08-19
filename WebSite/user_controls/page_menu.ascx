<%@ Control Language="C#" AutoEventWireup="true" CodeFile="page_menu.ascx.cs" Inherits="include_page_menu" %>
<table cellspacing="1" width="100%"><tr><td>
<table style="border-style: solid; border-width:1px;border-color:#26B9FE;width:100%; background-image:url(<%= ResolveUrl("~/images/logo_man_bg.jpg") %>)">
<tr><td><asp:Menu ID="main_top_menu" runat="server" Orientation="Horizontal" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="10px" ForeColor="#284E98" StaticSubMenuIndent="10px" OnMenuItemClick="main_top_menu_MenuItemClick" PathSeparator="|">
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle Font-Bold="true" ForeColor="white" />
    <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
    <DynamicMenuStyle BackColor="#B5C7DE" />
    <StaticSelectedStyle BackColor="#507CD1" />
    <DynamicSelectedStyle BackColor="#507CD1" Font-Bold="true" ForeColor="white" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
</asp:Menu>
</td></tr>
</table>
</td></tr></table>
