<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="CheckPricesDetails.aspx.cs" Inherits="Investars_CheckPricesDetails" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="am.Charts" Namespace="am.Charts" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
	<asp:ScriptManager ID="smMain" runat="server">
	</asp:ScriptManager>
	<div style="text-align:left;">
		<asp:HyperLink ID="hlBack" Text="Back" NavigateUrl="~/Tools/Quotes/CheckPrices.aspx"
			CssClass="LinkButton" runat="server"></asp:HyperLink>
		<div id="divStockInfo" Style="padding-bottom:5px; padding-top:5px;">
			<div class="Label" style="padding-bottom:5px;">Stock info:</div>
			<asp:DataGrid ID="dgStockInfo" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server">
			</asp:DataGrid>
		</div>
		<asp:Panel ID="pDividents" runat="server" Visible="false">
			<div class="Label" style="padding-bottom:5px;">Dividents:</div>
			<asp:DataGrid ID="dgDividents" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server">
			</asp:DataGrid>
		</asp:Panel>
		<table>
			<tr>
				<td>
					<div style="padding-bottom:5px; padding-top:5px;">
						<div class="Label" style="padding-bottom:5px;">Jumps:</div>
						<asp:UpdatePanel ID="upJumps" runat="server">
							<ContentTemplate>
							</ContentTemplate>
						</asp:UpdatePanel>
								<asp:DataGrid ID="dgStocksForCheck" AutoGenerateColumns="false" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server">
									<Columns>
										<asp:BoundColumn HeaderText="Date From" DataField="DateFrom"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Date To" DataField="DateTo"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Price From" DataField="PriceFrom"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Price To" DataField="PriceTo"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Diff" DataField="Diff"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Open/Close" DataField="OpenClose"></asp:BoundColumn>
										<asp:TemplateColumn>
											<ItemTemplate>
												<table cellpadding="0" cellspacing="0" border="0">
													<tr>
														<td>
															<asp:UpdatePanel ID="upFix" runat="server">
																<ContentTemplate>
																	<asp:LinkButton ID="lbtnFix" Text="Fix" OnCommand="lbtnSetFix_Command"
																		CommandArgument='<%# Eval("ErroOpenAtAnalystID") %>'
																		CssClass="LinkButton" runat="server"></asp:LinkButton>
																</ContentTemplate>
															</asp:UpdatePanel>
														</td>
														<td>
															<asp:UpdateProgress ID="prFix" runat="server">
																<ProgressTemplate>
																	<asp:Image ID="Image1" ImageUrl="~/IMAGES/ajax_loader_small_navy.gif" runat="server" />
																</ProgressTemplate>
															</asp:UpdateProgress>
														</td>
													</tr>
												</table>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:DataGrid>
					</div>
				</td>
				<td>
					<asp:HyperLink ID="hlBigCharts" Target="_blank" CssClass="LinkButton"
						Text='<%# String.Format("BigCharts ({0})", BigChartsSymbol) %>'
						NavigateUrl='<%# String.Format("http://bigcharts.marketwatch.com/interchart/interchart.asp?symb={0}", BigChartsSymbol) %>' runat="server"></asp:HyperLink>
					<br />
					<asp:HyperLink ID="hlBloomberg" Target="_blank" CssClass="LinkButton"
						Text='<%# String.Format("Bloomberg ({0})", BloombergSymbol) %>'
						NavigateUrl='<%# String.Format("http://www.bloomberg.com/apps/cbuilder?ticker1={0}", BloombergSymbol) %>' runat="server"></asp:HyperLink>
					<br />
					<asp:HyperLink ID="hlRreuters" Target="_blank" CssClass="LinkButton"
						Text='<%# String.Format("Reuters ({0})", ReutersSymbol) %>'
						NavigateUrl='<%# String.Format("http://www.reuters.com/finance/stocks/chart?symbol={0}", ReutersSymbol) %>' runat="server"></asp:HyperLink>
					<br />
					<asp:HyperLink ID="HyperLink1" runat="server" CssClass="LinkButton"
						NavigateUrl='<%# String.Format("http://finance.yahoo.com/echarts?s={0}#chart4:symbol={0};range=3m;indicator=split+dividend+volume;charttype=line;crosshair=on;ohlcvalues=0;logscale=on;source=undefined", YahooSymbol) %>'
						Target="_blank" Text='<%# String.Format("Yahoo ({0})", YahooSymbol) %>'></asp:HyperLink>
					<br />
					<asp:HyperLink ID="HyperLink2" runat="server" CssClass="LinkButton"
						NavigateUrl='<%# String.Format("http://investing.businessweek.com/research/stocks/charts/charts.asp?symbol={0}", BusinessWeekSymbol) %>'
						Target="_blank" Text='<%# String.Format("BusinessWeek ({0})", BusinessWeekSymbol) %>'></asp:HyperLink>
					<br />
					<asp:HyperLink ID="HyperLink3" runat="server" CssClass="LinkButton"
						NavigateUrl='<%# String.Format("http://finance.google.com/finance?q={0}", GoogleSymbol) %>'
						Target="_blank" Text='<%# String.Format("Google ({0})", GoogleSymbol) %>'></asp:HyperLink>
					<br />
					<asp:HyperLink ID="hlMsn" runat="server" CssClass="LinkButton"
						NavigateUrl='<%# String.Format("http://moneycentral.msn.com/detail/stock_quote?Symbol={0}", MsnSymbol) %>'
						Target="_blank" Text='<%# String.Format("Msn ({0})", MsnSymbol) %>'></asp:HyperLink>
					<br />
					<asp:HyperLink ID="hlMarketocracy" runat="server" CssClass="LinkButton"
						NavigateUrl='<%# String.Format("http://www.marketocracy.com/cgi-bin/WebObjects/Portfolio.woa/ps/StockGraphPage?symbol={0}", MarketocracySymbol) %>'
						Target="_blank" Text='<%# String.Format("Marketocracy ({0})", MarketocracySymbol) %>'></asp:HyperLink>
					<br />
				</td>
			</tr>
		</table>
		
		<div>
			<cc1:LineChart ID="lcStock" runat="server"/>
		</div>
	</div>
</asp:Content>
