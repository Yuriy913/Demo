<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="AllianceDataFeedAnalysis.aspx.cs" Inherits="AllianceDataFeedAnalysis" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="error_log" ContentPlaceHolderID="main" Runat="Server">
	<asp:ScriptManager ID="smMain" EnablePartialRendering="true" runat="server" />
	<div style="text-align:left">
		<table>
			<tr class="Label">
				<th>StockID</th><th>SecurityID</th><th>Ticker</th><th>Name</th>
				<td rowspan="2">
					<div style="overflow: hidden; width: 62px; height: 35px; text-align: center;">
						<asp:UpdateProgress ID="upStocksLoad" runat="server">
							<ProgressTemplate>
								<asp:Image ID="iLoading" ImageUrl="~/IMAGES/ajax-loader-middle.gif" runat="server" />
							</ProgressTemplate>
						</asp:UpdateProgress>
						<div style="padding-top:7px;">
							<asp:Button ID="btnSearch" CssClass="Button" Text="Search" runat="server" />
						</div>
					</div>
				</td>
			</tr>
			<tr>
				<td><asp:TextBox ID="txtStockID" CssClass="TextBox" runat="server" ></asp:TextBox></td>
				<td><asp:TextBox ID="txtSecurityID" CssClass="TextBox" runat="Server"></asp:TextBox></td>
				<td><asp:TextBox ID="txtTicker" CssClass="TextBox" runat="server"></asp:TextBox></td>
				<td><asp:TextBox ID="txtName" CssClass="TextBox" runat="server"></asp:TextBox></td>
			</tr>
		</table>
		<asp:UpdatePanel ID="upStocks" runat="server">
			<ContentTemplate>
				<br />
				<asp:DataGrid ID="dgStocks" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" Visible="true" AutoGenerateColumns="False" runat="server">
					<Columns>
						<asp:BoundColumn DataField="ID" HeaderText="ID"></asp:BoundColumn>
						<asp:TemplateColumn>
							<HeaderTemplate>
								Description
							</HeaderTemplate>
							<ItemTemplate>
								<asp:LinkButton ID="lbtnSecurityName" Text='<%# DataBinder.Eval(Container.DataItem, "Description").ToString() %>'
									 OnCommand="lbtnSecurityName_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>' CssClass="LinkButton" runat="server"></asp:LinkButton>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Ticker" HeaderText="Ticker"></asp:BoundColumn>
						<asp:BoundColumn DataField="SEDOL" HeaderText="SEDOL"></asp:BoundColumn>
						<asp:BoundColumn DataField="ISIN" HeaderText="ISIN"></asp:BoundColumn>
						<asp:BoundColumn DataField="Exchange" HeaderText="Exchange"></asp:BoundColumn>
						<asp:BoundColumn DataField="Country" HeaderText="Country"></asp:BoundColumn>
						<asp:BoundColumn DataField="InvestarsStockID" HeaderText="InvestarsStockID"></asp:BoundColumn>
						<asp:BoundColumn DataField="NotUse" HeaderText="NotUse"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
				<asp:Panel ID="pResults" runat="server" Visible="false">
					<asp:Panel ID="pOptions" runat="server">
						<div style="text-align:left; padding-top:4px; padding-bottom:4px;">
							<div style="width:130px; text-align:left; padding:3px; background-color: #B5C7DE;">
								<asp:LinkButton ID="lbtnChangeStockID" Text="Change InvestarsStockID" ToolTip="Change InvestarsStockID" CssClass="LinkButton" runat="server"></asp:LinkButton>
							</div>
						</div>
					</asp:Panel>
					<table>
						<tr><td>
							acm_coverage
							<asp:DataGrid ID="dgCoverage" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server"></asp:DataGrid>
						</td></tr>
						<tr><td>
							acm_ratings
							<asp:DataGrid ID="dgRatings" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server"></asp:DataGrid>
						</td></tr>
						<tr><td>
							acm_convictions
							<asp:DataGrid ID="dgConvictions" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server"></asp:DataGrid>
						</td></tr>
						<tr><td>
							analyst_ratings
							<asp:Panel ID="pAnalystRatings" runat="server">
								<asp:DataGrid ID="dgInvestarsRatings" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server"></asp:DataGrid>
							</asp:Panel>
						</td></tr>
					</table>
				</asp:Panel>
			</ContentTemplate>
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
			</Triggers>
		</asp:UpdatePanel>
	</div>
	<asp:UpdatePanel ID="upUpdateStockID" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pUpdateStockID" runat="server" Visible="false">
				<div style="left: 307px; width: 200px; position: absolute; top: 257px; height: 70px; background-color: gray;">
					<br />
				</div>
					<div style="left: 300px; width: 200px; position: absolute; top: 250px; height: 70px; border-right: royalblue thin solid; border-top: royalblue thin solid; border-left: royalblue thin solid; border-bottom: royalblue thin solid; background-color: #ffffcc;">
						<div style="padding:5px;">
							<table class="Label">
								<tr valign="top" style="height:30px;">
									<td align="left" style="width:60px">
										StockID:
									</td>
									<td>
										<asp:TextBox ID="txtUpdateStockID" Width="60px" cssClass="TextBox" runat="server" />
									</td>
								</tr>
								<tr>
									<td colspan="2">
										<asp:Button ID="btnUpdateStockIDCancel" Text="Cancel" runat="server" />
										<asp:Button ID="btnUpdateStockIDUpdate" Text="Update" runat="server" />
									</td>
								</tr>
							</table>
						</div>
					</div>
				</asp:Panel>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="lbtnChangeStockID" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>

