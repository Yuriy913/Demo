<%@ Control Language="C#" AutoEventWireup="true" CodeFile="date.ascx.cs" Inherits="user_controls_date" %>
<asp:Label ID="dateLabel" runat="server" Text="" CssClass="Label"></asp:Label>
<asp:DropDownList ID="Day" runat="server" CssClass="DropDownList"></asp:DropDownList>
<asp:DropDownList ID="Month" runat="server" CssClass="DropDownList" OnSelectedIndexChanged="Month_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<asp:DropDownList ID="Year" runat="server" CssClass="DropDownList" OnSelectedIndexChanged="Year_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>