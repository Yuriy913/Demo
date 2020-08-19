<%@ Control Language="C#" AutoEventWireup="true" CodeFile="show_rows_on_page.ascx.cs" Inherits="user_controls_show_rows_on_page" %>
<asp:Label ID="lbl_DropDown" runat="server" CssClass="Label">Show rows:</asp:Label>
<asp:DropDownList ID="ddl_DropDown" runat="server" CssClass="DropDownList">
<asp:ListItem Selected="True" Text="20" Value="20"></asp:ListItem> 
<asp:ListItem Text="40" Value="40"></asp:ListItem> 
<asp:ListItem Text="60" Value="60"></asp:ListItem> 
<asp:ListItem Text="80" Value="80"></asp:ListItem> 
<asp:ListItem Text="100" Value="100"></asp:ListItem> 
</asp:DropDownList>
