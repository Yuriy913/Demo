<%@ Page Title="" Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="RatingsWork.aspx.cs" Inherits="TOOLS_Quotes_RatingsWork" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="cMain" ContentPlaceHolderID="main" Runat="Server">
	<asp:ScriptManager ID="smMain" EnablePartialRendering="true" runat="server" />
	<asp:UpdatePanel ID="upRatings" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pRatings" runat="server">
				<asp:Panel ID="pOptions" runat="server" Visible="true">
					<div style="text-align:left; padding-top:4px; padding-bottom:4px;">
						<div style="width:60px; text-align:left; padding:3px; background-color: #B5C7DE;">
							<asp:LinkButton ID="lbtnAddRating" Text="Add rating" ToolTip="Edit selected rating" CssClass="LinkButton" runat="server"></asp:LinkButton>
						</div>
					</div>
				</asp:Panel>
				<asp:Panel ID="pSearchRatings" runat="server">
					<div style="padding-bottom:6px;">
						<table>
							<tr class="Label" align="center">
								<td>
									RatingID
								</td>
								<td>
									AnalystID
								</td>
								<td>
									Stock
								</td>
								<td>
									Person
								</td>
								<td>
									TermID
								</td>
								<td>
									Date
								</td>
								<td rowspan="2">
									<div style="overflow: hidden; width: 62px; height: 35px; text-align: center;">
										<asp:UpdateProgress ID="upRatingsSearck" runat="server">
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
									<asp:TextBox ID="txtRatingID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
								</td>
								<td>
									<asp:TextBox ID="txtAnalystID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
								</td>
								<td>
									<asp:TextBox ID="txtStockID" Width="50px" CssClass="TextBox" runat="server"></asp:TextBox>
									<asp:TextBox ID="txtSymbol" Width="60px" CssClass="TextBox" runat="server"></asp:TextBox>
								</td>
								<td>
									<asp:TextBox ID="txtPersonID" Width="50px" CssClass="TextBox" runat="server"></asp:TextBox>
									<asp:TextBox ID="txtPersonName" Width="130px" CssClass="TextBox" runat="server"></asp:TextBox>
								</td>
								<td>
									<asp:TextBox ID="txtTermID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
								</td>
								<td>
									<asp:TextBox ID="txtDate" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
								</td>
							</tr>
						</table>
					</div>
				</asp:Panel>
				
				<asp:UpdatePanel ID="upEditRating" runat="server">
					<ContentTemplate>
						<asp:Panel ID="pEditRating" Visible="false" runat="server">
							<div class="Label" style="padding-bottom:10px;">
								<table width="400px">
									<tr>
										<td align="left" style="width:100px;">
											<asp:RadioButton ID="rbEdit" Text="Edit" GroupName="action" onclick="ChangeTitle('Edit');" runat="server" /><br />
											<asp:RadioButton ID="rbCopy" Text="Copy" GroupName="action" onclick="ChangeTitle('Copy');" runat="server" /><br />
											<asp:RadioButton ID="rbDelete" Text="Delete" GroupName="action" onclick="ChangeTitle('Delete');" runat="server" />
										</td>
										<td align="left">
											<H1><asp:Label ID="lblAction" Text="Edit" runat="server"></asp:Label> Rating</H1>
										</td>
									</tr>
								</table>
							</div>
							<table style="text-align:left;" class="Label">
								<tr>
									<td rowspan="6" valign="top" style="width:35px;">
										<asp:UpdateProgress ID="uprEditRating" AssociatedUpdatePanelID="upEditRating" runat="server">
											<ProgressTemplate>
												<asp:Image ID="iLoading" ImageUrl="~/IMAGES/ajax-loader-middle.gif" runat="server" />
											</ProgressTemplate>
										</asp:UpdateProgress>
									</td>
									<td>AnalystID:</td>
									<td><asp:TextBox ID="txtUAnalystID" AutoPostBack="true" CssClass="TextBox" runat="server"></asp:TextBox></td>
									<td style="width:300px;">
										<asp:Label ID="lblUAnalyst" class="Label" runat="server"></asp:Label>
										<asp:DropDownList ID="ddlUAnalysts" Visible="false" AutoPostBack="true" runat="server"></asp:DropDownList>
									</td>
								</tr>
								<tr>
									<td>StockID:</td>
									<td><asp:TextBox ID="txtUStockID" AutoPostBack="true" CssClass="TextBox" runat="server"></asp:TextBox></td>
									<td>
										<asp:Label ID="lblUSymbol" CssClass="Label" runat="server"></asp:Label> - 
										<asp:Label ID="lblUStock" class="Label" runat="server"></asp:Label>
									</td>
								</tr>
								<tr>
									<td>PersonID:</td>
									<td><asp:TextBox ID="txtUPersonID" AutoPostBack="true" CssClass="TextBox" runat="server"></asp:TextBox></td>
									<td><asp:Label ID="lblUPerson" class="Label" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Date:</td>
									<td><asp:TextBox ID="txtUDate" AutoPostBack="true" CssClass="TextBox" runat="server"></asp:TextBox></td>
									<td align="left"><asp:Label ID="lblUDate" class="Label" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>TermID:</td>
									<td colspan="2">
										<asp:Label ID="lblUTermID" class="Label" runat="server"></asp:Label>
										<asp:DropDownList ID="ddlRating" AutoPostBack="true" CssClass="DropDownList" runat="server"></asp:DropDownList>
									</td>
								</tr>
								<tr>
									<td>Comment:</td>
									<td colspan="2">
										<asp:TextBox ID="txtComment" CssClass="TextBox" runat="server"></asp:TextBox>
									</td>
								</tr>
							</table>
							<table width="400px">
								<tr>
									<td><asp:Button ID="btnUCancel" Text="Cancel" CssClass="Button" runat="server" /></td>
									<td><asp:Button ID="btnUUpdate" Text="Update" CssClass="Button" runat="server" /></td>
								</tr>
							</table>
							<br />
						</asp:Panel>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="gvRatingsAllColumns" EventName="RowCommand" />
						<asp:AsyncPostBackTrigger ControlID="btnUCancel" EventName="Click" />
						<asp:AsyncPostBackTrigger ControlID="btnUUpdate" EventName="Click" />
					</Triggers>
				</asp:UpdatePanel>
				<!-- end Edit Rating-->
				
				<asp:UpdatePanel ID="upRatingsList" runat="server">
					<ContentTemplate>
						<asp:GridView ID="gvRatings" PagerSettings-Visible="true" PageSize="20" AllowPaging="false" CssClass="GridView"
							Width="960px" HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="false" runat="server">
							<Columns>
								<asp:BoundField DataField="ID" HeaderText="ID" />
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
						<asp:GridView ID="gvRatingsAllColumns" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server">
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<asp:ImageButton ID="ibtnEditRating" ImageUrl="~/IMAGES/options.JPG" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
											CommandName='<%# DataBinder.Eval(Container.DataItem, "AnalystID") %>'
											OnCommand="ibtnEditRating_Command" runat="server" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="#">
									<ItemTemplate>
										<asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
						<asp:Panel ID="pInfo" runat="server">
						</asp:Panel>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
					</Triggers>
				</asp:UpdatePanel>
			</asp:Panel>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="gvRatingsAllColumns" EventName="RowCommand" />
			<asp:AsyncPostBackTrigger ControlID="btnUCancel" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="btnUUpdate" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
	
	<asp:UpdatePanel ID="upConfirm" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pConfirm" runat="server" Visible="false">
				<div style="left: 107px; width: 830px; position: absolute; top: 207px; height: 140px; background-color: gray;">
					<br />
				</div>
				<div style="left: 100px; width: 830px; position: absolute; top: 200px; height: 140px; border-right: royalblue thin solid; border-top: royalblue thin solid; border-left: royalblue thin solid; border-bottom: royalblue thin solid; background-color: #ffffcc;">
					<div style="padding:5px;">
						<table>
							<tr class="Label">
								<td colspan="2">Are you sure want to do next actions:</td>
							</tr>
							<tr>
								<td colspan="2">
									<table id="tConfirm" class="GridView" runat="server">
										<tr class="GridViewHead">
											<td></td>
											<td>AnalystID</td>
											<td>StockID</td>
											<td>Symbol</td>
											<td>Stock Name</td>
											<td>Date</td>
											<td>PersonID</td>
											<td>Person Name</td>
											<td>TermID</td>
											<td>Rating</td>
											<td>Price</td>
										</tr>
										<tr>
											<td style="color:Red;">
												Delete rating:
											</td>
											<td>
												<asp:Label ID="lblConfirmDAnalystID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDStockID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDSymbol" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDStockName" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDDate" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDPersonID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDPerson" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDTermID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDRating" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmDPrice" runat="server"></asp:Label>
											</td>
										</tr>
										<tr style="font-weight:bold;">
											<td style="color:Green;">
												Add rating:
											</td>
											<td>
												<asp:Label ID="lblConfirmIAnalystID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIStockID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmISymbol" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIStockName" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIDate" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIPersonID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIPerson" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmITermID" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIRating" runat="server"></asp:Label>
											</td>
											<td>
												<asp:Label ID="lblConfirmIPrice" runat="server"></asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Button ID="btnConfirmCancel" Text="Cancel" CssClass="Button" runat="server" />
								</td>
								<td>
									<asp:Button ID="btnConfirmYes" Text="Yes" CssClass="Button" runat="server" />
								</td>
							</tr>
						</table>
					</div>
				</div>
			</asp:Panel>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="btnUUpdate" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="btnConfirmCancel" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="btnConfirmYes" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
	
		
	<script language="JavaScript" type="text/javascript">
	<!--
		function ChangeTitle(newTitle)
		{
			var lblAction = document.getElementById('<%= lblAction.ClientID %>');

			lblAction.innerHTML = newTitle;
		}
	//-->
	</script>
</asp:Content>

