<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Grid.ascx.cs" Inherits="User_Controls_Grid" %>

<asp:GridView ID="gv_GridView" runat="server" Font-Names="Verdana" Font-Overline="False" Font-Size="7pt" Font-Strikeout="False" Font-Italic="False" BackColor="White" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None">
              <PagerStyle BorderColor="White" BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
          </asp:GridView>
