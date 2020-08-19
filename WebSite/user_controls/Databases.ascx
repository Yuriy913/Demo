<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Databases.ascx.cs" Inherits="USER_CONTROLS_Databases" %>
<asp:DropDownList ID="DatabaseID" runat="server" DataSourceID="ds" 
    DataTextField="Name" DataValueField="ID">
</asp:DropDownList>
<asp:TextBox ID="ServerID" runat="server" Visible="False" Width="16px"></asp:TextBox>
<asp:SqlDataSource ID="ds" runat="server"></asp:SqlDataSource>
