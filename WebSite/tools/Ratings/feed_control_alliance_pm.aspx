<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="feed_control_alliance_pm.aspx.cs" Inherits="Tools_Ratings_feed_control_alliance_pm" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" HorizontalAlign="Left" 
        Width="109%" BorderWidth="1px">
        <asp:DropDownList ID="ddl_Look" runat="server" AutoPostBack="True" 
            Height="16px" OnSelectedIndexChanged="ddl_Look_SelectedIndexChanged" 
            Width="156px">
            <asp:ListItem Value="0">-- Choose Look --</asp:ListItem>
            <asp:ListItem Value="1">Look Tables</asp:ListItem>
            <asp:ListItem Value="2">Look History for 3 Days</asp:ListItem>
            <asp:ListItem Value="3">SET StockID</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="SecurityID:"></asp:Label>
        <asp:TextBox ID="tbSecurityID" runat="server" Width="52px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Find:"></asp:Label>
        <asp:CheckBox ID="cbFP" runat="server" Text="%" />
        <asp:TextBox ID="tbFindText" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="by:"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">TIKER</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">NAME</asp:LinkButton><asp:LinkButton 
            ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">StockID</asp:LinkButton>&nbsp;<asp:LinkButton 
            ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">InstDBStockID</asp:LinkButton><asp:LinkButton 
            ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">Analyst</asp:LinkButton>&nbsp;<asp:Button 
            ID="Button1" runat="server" OnClick="Button1_Click" 
            Text="Delete from IpmDB_live:" Width="144px" />
        <asp:Label ID="Label4" runat="server" Text="RatingID:"></asp:Label>
        <asp:TextBox ID="tbRatingID" runat="server" Width="60px"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="CoverageDateStart:"></asp:Label>
        &nbsp;<asp:TextBox ID="tbCoverageDateStart" runat="server" Width="64px"></asp:TextBox><asp:Label 
            ID="Label10" runat="server" Text="CoverageDateEnd:"></asp:Label><asp:TextBox 
            ID="tbCoverageDateEnd" runat="server" Width="65px"></asp:TextBox><asp:Label 
            ID="Label5" runat="server" Text="COVERAGE:"></asp:Label><asp:DropDownList 
            ID="ddl_CoverageFlags" runat="server" AutoPostBack="True" 
            EnableViewState="False" 
            OnSelectedIndexChanged="ddl_CoverageFlags_SelectedIndexChanged">
            <asp:ListItem Value="0">-- Run SET Flag --</asp:ListItem>
            <asp:ListItem Value="1">SET NotUse=&apos;Y&apos;</asp:ListItem>
            <asp:ListItem Value="2">SET NotUse=NULL</asp:ListItem>
            <asp:ListItem Value="3">SET NotDrop=&apos;Y&apos;</asp:ListItem>
            <asp:ListItem Value="4">SET NotDrop=NULL</asp:ListItem>
            <asp:ListItem Value="5">SET NotRating=&apos;Y&apos;</asp:ListItem>
            <asp:ListItem Value="6">SET NotRating=NULL</asp:ListItem>
            <asp:ListItem Value="7">Look Flags</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Text="RATINGS:"></asp:Label>
        <asp:DropDownList ID="ddl_RatingsFlags" runat="server" AutoPostBack="True" 
            EnableViewState="False" 
            OnSelectedIndexChanged="ddl_RatingsFlags_SelectedIndexChanged1">
            <asp:ListItem Value="0">-- Run SET Flag --</asp:ListItem>
            <asp:ListItem Value="1">SET NotUse=&apos;Y&apos;</asp:ListItem>
            <asp:ListItem Value="2">SET NotUse=NULL</asp:ListItem>
            <asp:ListItem Value="3">SET NotDrop=&apos;Y&apos;</asp:ListItem>
            <asp:ListItem Value="4">SET NotDrop=NULL</asp:ListItem>
            <asp:ListItem Value="5">Look Flags</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<br />
        <asp:Button ID="Button2" runat="server" Font-Bold="True" 
            OnClick="Button2_Click" Text="Close and Open Security:" Width="171px" />
        <asp:Label ID="Label7" runat="server" Text="CloseSecurityID:"></asp:Label>
        <asp:TextBox ID="tbCloseSecurityID" runat="server" Width="58px"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="OpenSecurityID:"></asp:Label>
        <asp:TextBox ID="tbOpenSecurityID" runat="server" Width="58px"></asp:TextBox>
        &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">LOOK Duplicates:</asp:LinkButton><asp:Label 
            ID="Label11" runat="server" Text="StockID:"></asp:Label><asp:TextBox 
            ID="tbStockID" runat="server" Width="115px"></asp:TextBox><br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="100%" HorizontalAlign="Left" 
    Width="109%" BorderWidth="1px" BackColor="White">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </asp:Panel>

</asp:Content>

