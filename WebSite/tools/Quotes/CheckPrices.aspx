<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="CheckPrices.aspx.cs" Inherits="Investars_CheckPrices" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<script id="sTest" runat="server"></script>
	<div style="text-align:left; width:610px">
		<asp:ScriptManager ID="smMain" EnablePartialRendering="true" runat="server">
		</asp:ScriptManager>
		<div>
			<asp:Panel ID="pSearch" runat="server">
				<table width="100%">
					<tr>
						<td style="width:80px">
							<asp:TextBox ID="txtStockID" Width="80px" CssClass="TextBox" runat="server"></asp:TextBox>
						</td>
						<td style="width:80px">
							<asp:Button ID="btnSearch" Text="Search by StockID" CssClass="Button" runat="server" />
						</td>
						<td align="right">
							<asp:UpdatePanel ID="upOptions" runat="server">
								<ContentTemplate>
									<asp:Button ID="btnOptions" Text="Options" CssClass="Button" runat="server" />
									<asp:Panel ID="pOptions" runat="server" Visible="false">
									<div style="left: 307px; width: 430px; position: absolute; top: 157px; height: 150px; background-color: gray;">
										<br />
									</div>
										<div style="left: 300px; width: 430px; position: absolute; top: 150px; height: 150px; border-right: royalblue thin solid; border-top: royalblue thin solid; border-left: royalblue thin solid; border-bottom: royalblue thin solid; background-color: #ffffcc;">
											<div style="padding:5px;">
												<table class="Label">
													<tr valign="top">
														<td rowspan="3" align="left" style="width:120px">
															Analysts:<br />
															<asp:ListBox ID="lbAnalysts" SelectionMode="Multiple" runat="server"></asp:ListBox><br />
															<asp:CheckBox ID="cbAnalystsAll" Text="All Analysts" cssClass="CheckBox" runat="server"></asp:CheckBox>
														</td>
														<td>
															Min price jump
															<asp:TextBox ID="txtDiff" Width="30px" cssClass="TextBox" runat="server"></asp:TextBox> %
														</td>
													</tr>
													<tr valign="top">
														<td>
															Min pair open and close price jump
															<asp:TextBox ID="txtDiffPair" Width="30px" cssClass="TextBox" runat="server"></asp:TextBox> %
														</td>
													</tr>
													<tr valign="top" style="height:70px;">
														<td>
															<asp:CheckBox ID="cbNotShowSmall" cssClass="CheckBox"
																Text="Don't show jumps whith price less then 1" runat="server"></asp:CheckBox>
														</td>
													</tr>
													<tr>
														<td colspan="2" align="center">
															<asp:Button ID="btnCancel" Text="Cancel" CssClass="Button" runat="server" />
															<asp:Button ID="btnSave" Text="Save" CssClass="Button" runat="server" />
														</td>
													</tr>
												</table>
											</div>
										</div>
									</asp:Panel>
								</ContentTemplate>
							</asp:UpdatePanel>
							<asp:UpdateProgress AssociatedUpdatePanelID="upOptions" runat="server">
								<ProgressTemplate>
									<div style="background-color: #fffacd; left: 450px; width: 50px; position: absolute; top: 200px; height: 50px;">
										<asp:Image ID="imgProgress" ImageUrl="~/IMAGES/ajax-loader_big.gif" runat="server" />
									</div>
								</ProgressTemplate>
							</asp:UpdateProgress>
						</td>
					</tr>
				</table>
			</asp:Panel>
			
			<asp:Panel ID="pStocks" runat="Server">
				<div class="Label" style="padding-bottom:2px; cursor: pointer;">
					Top <asp:TextBox ID="txtRows" Text="20" Width="30px" CssClass="TextBox" runat="server"></asp:TextBox> rows.
				</div>
				<asp:DataGrid ID="dgStocks" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="false" runat="Server">
					<Columns>
						<asp:TemplateColumn HeaderText="#">
							<ItemTemplate>
								<asp:Label Text='<%# Container.ItemIndex + 1 %>' runat="server"></asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="StockID">
							<ItemTemplate>
								<asp:HyperLink ID="hlCompanyName" Text='<%# DataBinder.Eval(Container.DataItem, "StockID") %>' 
									NavigateUrl='<%# String.Format("CheckPricesDetails.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "StockID")) %>'
									cssClass="LinkButton" runat="server"></asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Symbol" HeaderText="Symbol"></asp:BoundColumn>
						<asp:BoundColumn DataField="CompanyName" HeaderText="Company"></asp:BoundColumn>
						<asp:BoundColumn DataField="DateFrom" HeaderText="Date From"></asp:BoundColumn>
						<asp:BoundColumn DataField="DateTo" HeaderText="Date To"></asp:BoundColumn>
						<asp:BoundColumn DataField="PriceFrom" HeaderText="Price From"></asp:BoundColumn>
						<asp:BoundColumn DataField="PriceTo" HeaderText="Price To"></asp:BoundColumn>
						<asp:BoundColumn DataField="Diff" HeaderText="Diff"></asp:BoundColumn>
						<asp:BoundColumn DataField="OpenClose" HeaderText="Open/Close"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</asp:Panel>
		</div>
	</div>
</asp:Content>
