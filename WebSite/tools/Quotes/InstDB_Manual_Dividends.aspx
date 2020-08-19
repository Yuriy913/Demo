<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="InstDB_Manual_Dividends.aspx.cs" Inherits="Tools_Quotes_Quotes_Dividends_Editor_New" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="99%" Width="99%" HorizontalAlign="Left">
        <asp:Menu ID="Menu1" runat="server" BorderWidth="1px" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick">
        </asp:Menu>
        <asp:Label ID="Label1" runat="server" BorderWidth="1px"></asp:Label><asp:Label ID="Label2" runat="server" BorderWidth="1px"></asp:Label><br />
        <asp:Panel ID="Panel2" runat="server" BorderWidth="1px" Height="120px" 
            Width="99%">
            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Stock" Width="44px" /><asp:Button
                ID="Button13" runat="server" OnClick="Button13_Click" Text="History" Width="46px" /><asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="Look" /><asp:Label ID="Label3"
                        runat="server" Text="StockID:"></asp:Label><asp:TextBox ID="tbStockID" runat="server"
                            Width="59px"></asp:TextBox><asp:Label ID="Label4" runat="server" Text="Date:"></asp:Label><asp:TextBox
                                ID="tbDate" runat="server" Width="79px"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Upload From Splited"
                ToolTip="StockID,Date" Width="129px" />&nbsp;<asp:Button ID="Button5" runat="server"
                    OnClick="Button5_Click1" Text="Look Upload Queue " /><br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Generate Alert" /><asp:Button
                ID="Button14" runat="server" OnClick="Button14_Click" Text="Dividend Types" /><br />
            <asp:Label ID="Label5" runat="server" Text="OldDividend:" ToolTip="OldDividend/OriginalDividend"></asp:Label><asp:TextBox
                    ID="tbOldDividend" runat="server" Width="54px"></asp:TextBox><asp:Label ID="Label6"
                        runat="server" Text="NewDividend:" ToolTip="QuotesDividend/NewDividend/Dividend"></asp:Label><asp:TextBox
                            ID="tbNewDividend" runat="server" Width="55px"></asp:TextBox><asp:Button ID="Button6"
                                runat="server" OnClick="Button6_Click" Text="Add: Quotes Dividend more than price"
                                Width="227px" /><asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Add: InstDB Dividend more than price"
                                    Width="221px" /><br />
            <asp:Label ID="Label7" runat="server" Text="Manual dividends:"></asp:Label><asp:Button
                ID="Button3" runat="server" OnClick="Button3_Click" Text="Add" /><asp:Button ID="Button11"
                    runat="server" OnClick="Button11_Click" Text="Delete" /><asp:Button ID="Button10"
                        runat="server" OnClick="Button10_Click" Text="Look:" /><asp:Label ID="Label8" runat="server"
                            Text="ID:"></asp:Label><asp:TextBox ID="tbID" runat="server" 
                Width="35px" Height="22px"></asp:TextBox><asp:Button
                                ID="Button9" runat="server" OnClick="Button9_Click" Text="UnDetected" Width="77px" /><asp:DropDownList
                                    ID="ddl_setOper" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_setOper_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">-- Choose Oper --</asp:ListItem>
                                    <asp:ListItem Value="1">SET OPER=INSERT</asp:ListItem>
                                    <asp:ListItem Value="2">SET OPER=UPDATE</asp:ListItem>
                                    <asp:ListItem Value="3">SET OPER=DELETE</asp:ListItem>
                                    <asp:ListItem Value="4">SET QuotesDividend</asp:ListItem>
                                    <asp:ListItem Value="5">SET CRC_Factor</asp:ListItem>
                                    <asp:ListItem Value="6">LOOK &amp; SUM CRC_Factor</asp:ListItem>
                                    <asp:ListItem Value="7">SET OriginalDividend</asp:ListItem>
                                    <asp:ListItem Value="8">LOOK by StockID</asp:ListItem>
                                    <asp:ListItem Value="9">SET OPER=PASS</asp:ListItem>
                                </asp:DropDownList><asp:Label ID="Label9" runat="server" Text="CRC_Factor:"></asp:Label><asp:TextBox
                                    ID="tbCRC_Factor" runat="server" Width="65px"></asp:TextBox>
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="99%" Width="99%" BorderWidth="1px" ScrollBars="Auto">
            <asp:Panel ID="Panel4" runat="server">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

