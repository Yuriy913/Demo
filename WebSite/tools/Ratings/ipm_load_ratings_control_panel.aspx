<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="ipm_load_ratings_control_panel.aspx.cs" Inherits="Tools_Ratings_ipm_load_ratings_control_panel" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="99%" HorizontalAlign="Left"
        Width="99%">
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" BorderWidth="1px" DynamicHorizontalOffset="2"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" OnMenuItemClick="Menu1_MenuItemClick"
            Orientation="Horizontal" StaticSubMenuIndent="10px">
            <StaticSelectedStyle BackColor="#FFCC66" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#990000" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px"
                ForeColor="White" />
            <DynamicMenuStyle BackColor="#FFFBD6" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1px" />
            <DynamicSelectedStyle BackColor="#FFCC66" BorderColor="#C000C0" BorderStyle="Solid"
                BorderWidth="1px" />
            <DynamicMenuItemStyle BorderColor="#00C000" BorderStyle="Solid" BorderWidth="1px"
                HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <Items>
                <asp:MenuItem Text="Find" Value="Find">
                    <asp:MenuItem Text="by Symbol" ToolTip="RatingID[,...], FieldContent" Value="by Symbol">
                    </asp:MenuItem>
                    <asp:MenuItem Text="by Sedol" Value="by Sedol"></asp:MenuItem>
                    <asp:MenuItem Text="by Analyst Name" Value="by Analyst Name"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Ratings" Value="Ratings">
                    <asp:MenuItem Text="Look" ToolTip="RatingID[,...]" Value="Look"></asp:MenuItem>
                    <asp:MenuItem Text="Processed" Value="Processed">
                        <asp:MenuItem Text="NULL" ToolTip="RatingID[,...]" Value="NULL"></asp:MenuItem>
                        <asp:MenuItem Text="No" ToolTip="RatingID[,...]" Value="No"></asp:MenuItem>
                        <asp:MenuItem Text="Wait" ToolTip="RatingID[,...]" Value="Wait"></asp:MenuItem>
                        <asp:MenuItem Enabled="False" Selectable="False" Text="----------" Value="----------">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Yes" Value="Yes"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="StockID" Value="StockID">
                        <asp:MenuItem Text="Clear" ToolTip="RatingID[,...]" Value="Clear"></asp:MenuItem>
                        <asp:MenuItem Text="Add" ToolTip="RatingID[,...]" Value="Add"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="PersonID" Value="PersonID">
                        <asp:MenuItem Text="Clear" Value="Clear"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Enabled="False" Selectable="False" Text="-----------" Value="-----------">
                    </asp:MenuItem>
                    <asp:MenuItem Text="UPDATE" Value="UPDATE">
                        <asp:MenuItem Text="Index" Value="Index"></asp:MenuItem>
                        <asp:MenuItem Text="Sedol" Value="Sedol"></asp:MenuItem>
                        <asp:MenuItem Text="Region" Value="Region"></asp:MenuItem>
                        <asp:MenuItem Text="Without Stock History" Value="Without Stock History"></asp:MenuItem>
                        <asp:MenuItem Text="NewAnalystName" Value="NewAnalystName"></asp:MenuItem>
                        <asp:MenuItem Text="CUSIP" Value="CUSIP"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:Label ID="lMenuPath" runat="server" BorderWidth="1px" EnableViewState="False"></asp:Label>
        &nbsp;
        &nbsp; &nbsp;<br />
        <asp:Panel ID="Panel2" runat="server" BorderWidth="1px" Height="53px" Width="99%">
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="FieldContent:" ToolTip="StockID"></asp:Label><asp:TextBox
                ID="tbFieldContent" runat="server"></asp:TextBox>&nbsp;
            <asp:Label ID="Label1" runat="server" Text="SiteID:"></asp:Label><asp:TextBox ID="tbSiteID"
                runat="server" Width="45px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="AnalystID:"></asp:Label><asp:TextBox
                ID="tbAnalystID" runat="server" Width="65px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="TeamID:"></asp:Label><asp:TextBox ID="tbTeamID"
                runat="server" Width="75px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp;<asp:Label ID="tbDateStart" runat="server" Text="DateStart:"></asp:Label><asp:TextBox
                ID="TextBox1" runat="server" Width="65px"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="DateEnd:"></asp:Label>
            <asp:TextBox ID="tbDateEnd" runat="server" Width="67px"></asp:TextBox><br />
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="RatingsID:"
                ToolTip="RatingID[,...], Substring, ListOfMeans"></asp:Label>
            <asp:TextBox ID="tbRatingsID" runat="server" Width="829px"></asp:TextBox>&nbsp;
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="99%" Width="99%" BorderWidth="1px" ScrollBars="Auto">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

