<%@ Page Title="" Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="DumpLoader.aspx.cs" Inherits="Tools_MultiFunc_Pages_DumpLoader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BorderWidth="1px" Height="100%" 
        HorizontalAlign="Left" Width="100%" BackColor="White">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" 
            BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" 
            Font-Size="0.8em" ForeColor="#990000" onmenuitemclick="Menu1_MenuItemClick" 
            StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem Text="Quotes" Value="Quotes" Selected="True">
                    <asp:MenuItem Text="Prices" Value="Prices"></asp:MenuItem>
                    <asp:MenuItem Text="Dividends" Value="Dividends" Enabled="False"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
        <asp:Label ID="lMenuPath" runat="server" Text="Menu Item Path"> </asp:Label>
        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="1px">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="Load" />
            &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
                Text="Good Reload" />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Item1</asp:ListItem>
                <asp:ListItem>Item2</asp:ListItem>
            </asp:DropDownList>
            <br />
        </asp:Panel>
        <asp:Label ID="lFields" runat="server" Text="Fields Order"></asp:Label>
        <asp:Panel ID="Panel4" runat="server">
            <asp:TextBox ID="TextBox1" runat="server" Height="255px" TextMode="MultiLine" 
                Width="99%" Enabled="False"></asp:TextBox>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

