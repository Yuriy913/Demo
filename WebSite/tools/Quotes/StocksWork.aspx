<%@ Page Title="" Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="StocksWork.aspx.cs" Inherits="TOOLS_Quotes_StocksWork" %>
<%@ Register Src="~/user_controls/StockLinks.ascx" TagName="StockLinks" TagPrefix="uc"%>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="cMain" ContentPlaceHolderID="main" Runat="Server">
	<asp:ScriptManager ID="smMain" EnablePartialRendering="true" runat="server" />
	<div style="padding-bottom:6px;">
		<table>
			<tr class="Label">
				<td>
					StockID
				</td>
				<td>
					InstDBStockID
				</td>
				<td>
					Symbol
				</td>
				<td>
					Name
				</td>
				<td>
					Exchange
				</td>
				<td>
					Country Code
				</td>
				<td rowspan="2">
					<div style="overflow: hidden; width: 62px; height: 35px; text-align: center;">
						<asp:UpdateProgress ID="upStocksLoad" runat="server">
							<ProgressTemplate>
								<asp:Image ID="iLoading" ImageUrl="~/IMAGES/ajax-loader-middle.gif" runat="server" />
							</ProgressTemplate>
						</asp:UpdateProgress>
						<div style="padding-top:7px;">
							<asp:Button ID="btnSearch" Text="Search" CssClass="Button" runat="server" />
						</div>
					</div>
				</td>
				<td rowspan="2">
					<asp:CheckBox ID="cbAllColumns" Text="All columns" CssClass="CheckBox" runat="server" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="txtStockID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtInstDBStockID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtSymbol" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtName" Width="170px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtExchange" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtCountryCode" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
			</tr>
		</table>
	</div>
	<asp:UpdatePanel ID="upStocks" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gvStocks" PagerSettings-Visible="true" PageSize="20" AllowPaging="false" CssClass="GridView"
				Width="960px" HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="false" runat="server">
				<Columns>
					<asp:TemplateField HeaderText="StockID">
						<ItemTemplate>
							<asp:LinkButton ID="lbtnStockID" Text='<%# Eval("ID").ToString() %>'
								CommandArgument='<%# Eval("ID").ToString() %>'
								OnCommand="lbtnStockID_Command" CssClass="LinkButton" runat="server"></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="InstDBStockID" HeaderText="InstDB" />
					<asp:BoundField DataField="Name" HeaderText="Name" />
					<asp:BoundField DataField="Symbol" HeaderText="Symbol" />
					<asp:BoundField DataField="RIC" HeaderText="RIC" />
					<asp:BoundField DataField="CUSIP" HeaderText="CUSIP" />
					<asp:BoundField DataField="ISIN" HeaderText="ISIN" />
					<asp:BoundField DataField="SEDOL" HeaderText="SEDOL" />
					<asp:BoundField DataField="DeadFlag" HeaderText="Dead" />
					<asp:BoundField DataField="Exchange" HeaderText="Exchange" />
					<asp:BoundField DataField="LastQuoteDate" HeaderText="LastQuoteDate" />
					<asp:BoundField DataField="Currency" HeaderText="Currency" />
					<asp:BoundField DataField="CountryCode" HeaderText="Country" />
				</Columns>
			</asp:GridView>
			<asp:GridView ID="gvStocksAllColumns" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server">
			</asp:GridView>
			<asp:Panel ID="pInfo" runat="server">
			</asp:Panel>
			<asp:Panel ID="pOptions" runat="server" Visible="false">
				<div style="text-align:left; padding-top:4px; padding-bottom:4px;">
					<div style="width:30px; text-align:left; padding:3px; background-color: #B5C7DE;">
						<asp:LinkButton ID="lbtnLincks" Text="Links" ToolTip="Show lincks for sourse sites" CssClass="LinkButton" runat="server"></asp:LinkButton>
					</div>
				</div>
			</asp:Panel>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="upLincks" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pLincks" Visible="false" runat="server">
				<div style="text-align:left;">
					<uc:StockLinks ID="ucStockLinks" runat="server"></uc:StockLinks>
				</div>
			</asp:Panel>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>

