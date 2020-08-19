<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="Quotes_Editor.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<div align="left" style="background-color: white">
    <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Orientation="Horizontal"
        StaticSubMenuIndent="10px" OnMenuItemClick="Menu1_MenuItemClick" BorderWidth="1px">
        <StaticSelectedStyle BackColor="#FFCC66" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BorderWidth="1px" />
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <Items>
                <asp:MenuItem Text="Stocks" Value="Stocks">
                    <asp:MenuItem Text="Look" ToolTip="StocksID" Value="Look" Selected="True">
                        <asp:MenuItem Text="History LAST 20" Value="History LAST 20"></asp:MenuItem>
                        <asp:MenuItem Text="Splits &amp; Dividends" Value="Splits &amp; Dividends"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="UPDATE" Value="UPDATE">
                        <asp:MenuItem Text="Symbol &amp; RIC" Value="Symbol &amp; RIC"></asp:MenuItem>
                        <asp:MenuItem Text="Symbol" Value="Symbol"></asp:MenuItem>
                        <asp:MenuItem Text="RIC" Value="RIC"></asp:MenuItem>
                        <asp:MenuItem Text="InstDBStockID" Value="InstDBStockID"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="History" Value="History">
                        <asp:MenuItem Text="Delete" Value="Delete">
                            <asp:MenuItem Text="On 1 Date" Value="On 1 Date"></asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
            <asp:MenuItem Text="InstDB" Value="InstDB">
                <asp:MenuItem Text="Keep Pair Symbol &amp; RIC" Value="Keep Pair Symbol &amp; RIC">
                    <asp:MenuItem Text="Look" Value="Look"></asp:MenuItem>
                    <asp:MenuItem Text="From Stocks" Value="From Stocks"></asp:MenuItem>
                    <asp:MenuItem Text="Delete" Value="Delete"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Stock History" Value="Stock History">
                    <asp:MenuItem Text="Add First Prices From Archive" ToolTip="StockID,Date (From Begin To Date)"
                        Value="Add First Prices From Archive"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
    <asp:Label ID="lMenuPath" runat="server" BorderWidth="1px"></asp:Label>
    <br />
    <asp:Panel ID="Panel1" runat="server" BorderWidth="1px" Height="47px" Width="100%">
        <asp:Label ID="Label5" runat="server" Text="FieldContent1:" ToolTip="RIC,InstDBStockID,Date"></asp:Label><asp:TextBox ID="tbFieldContent1" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="FieldContent2:" ToolTip="Symbol"></asp:Label><asp:TextBox ID="tbFieldContent2" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="StockIDs:"></asp:Label><asp:TextBox ID="tbStocksID" runat="server" Width="418px"></asp:TextBox></asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="600px" ScrollBars="Both" Width="1200px">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</div>    
</asp:Content>

