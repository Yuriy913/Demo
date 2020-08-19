<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="exports_control_panel.aspx.cs" Inherits="Tools_Exports_exports_control_panel" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" BorderWidth="1px" Height="99%" HorizontalAlign="Left"
        Width="99%" BackColor="White">

    <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" BorderWidth="1px" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" OnMenuItemClick="Menu1_MenuItemClick"
        Orientation="Horizontal" StaticSubMenuIndent="10px">
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuStyle BackColor="#FFFBD6" BorderWidth="1px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <Items>
            <asp:MenuItem Text="Ratings" Value="Ratings">
                <asp:MenuItem Text="Look" Value="Look"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="DWS" Value="DWS">
                <asp:MenuItem Text="Scores &amp; Signals" Value="Scores &amp; Signals">
                    <asp:MenuItem Enabled="False" Text="Brokers" Value="Brokers"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="Sources" Value="Sources"></asp:MenuItem>
                    <asp:MenuItem Text="Securities" Value="Securities"></asp:MenuItem>
                    <asp:MenuItem Text="Signals" Value="Signals"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="Benchmarks" Value="Benchmarks"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="Scores" Value="Scores"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="Checks Signals" Value="Checks Signals"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Ratings" Value="Ratings">
                    <asp:MenuItem Text="Look Exported" Value="Look Exported"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Selectable="False" Text="-----------------" Value="-----------------">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Add as Excluded" Value="Add as Excluded"></asp:MenuItem>
                    <asp:MenuItem Text="-----------------" Value="-----------------" Enabled="False" Selectable="False"></asp:MenuItem>
                    <asp:MenuItem Text="Registaration Delete" Value="Registaration Delete"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuStyle BorderWidth="1px" />
    </asp:Menu>
    <asp:Label ID="lMenuPath" runat="server" BorderWidth="1px" EnableViewState="False"></asp:Label><asp:Label
        ID="lCMD" runat="server" BorderWidth="1px" EnableViewState="False" Font-Strikeout="False"></asp:Label><br />
    <asp:Panel ID="Panel1" runat="server" BorderWidth="1px" Height="50px" Width="99%">
    <asp:Label ID="lFiendContent" runat="server" Font-Bold="True" Text="FiendContent:"></asp:Label><asp:TextBox
        ID="tbFieldContent" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label1" runat="server"
            Font-Bold="True" Text="RatingsID:"></asp:Label><asp:TextBox ID="tbListOfRatings"
                runat="server" Width="645px"></asp:TextBox></asp:Panel>
        <asp:Panel ID="Panel3" runat="server" BorderWidth="1px" Height="99%" ScrollBars="Auto"
            Width="99%">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

