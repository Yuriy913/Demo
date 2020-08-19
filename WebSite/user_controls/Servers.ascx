<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Servers.ascx.cs" Inherits="User_Controls_get_servers" %>
<asp:DropDownList ID="ServerID" runat="server" DataSourceID="ds"
    DataTextField="Name" DataValueField="ID" AutoPostBack="True">
</asp:DropDownList><asp:SqlDataSource ID="ds" runat="server" DataSourceMode="DataReader"></asp:SqlDataSource>
