<%@ Page Title="" Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="CalcReturns.aspx.cs" Inherits="Clients_Alliance_CalcReturns" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="cMain" ContentPlaceHolderID="main" Runat="Server">
<script type="text/jscript" language="javascript">
	function form_validator(theForm) {
		alert("d");
		return (true);
	}
	</script>
	
	<asp:ScriptManager ID="smMain" EnablePartialRendering="true" runat="server"/>
	
	<asp:UpdateProgress ID="uprMain" runat="server">
		<ProgressTemplate>
			<asp:Image ID="iLoading" ImageUrl="~/IMAGES/ajax-loader-middle.gif" runat="server" />
		</ProgressTemplate>
	</asp:UpdateProgress>
	
	<asp:UpdatePanel ID="upMain" runat="server">
		<ContentTemplate>
	
			<asp:UpdatePanel ID="upAlerts" runat="server">
				<ContentTemplate>
					<div style="width:600px;">
						<div class="Label" style="padding-bottom:2px; text-align:left;">
							Alerts for Alliance.
						</div>
						<asp:GridView ID="gvAlerts" PagerSettings-Visible="true" CssClass="GridView"
								Width="600px" HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="false" runat="server">
							<Columns>
								<asp:TemplateField>
									<ItemStyle Width="20px" />
									<ItemTemplate>
										<asp:ImageButton ID="ibtnShowText" ImageUrl="~/IMAGES/options.JPG" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
											ToolTip="Show message text" runat="server" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField>
									<ItemStyle Width="20px" />
									<ItemTemplate>
										<asp:ImageButton ID="ibtnDeleteAlert" ImageUrl="~/IMAGES/delete.gif" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
											OnCommand="ibtnDeleteAlert_Command" ToolTip="Delete message" runat="server" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField ItemStyle-Width="20px" DataField="ID" HeaderText="ID" />
								<asp:BoundField ItemStyle-Width="120px" DataField="DateAdded" HeaderText="Date" />
								<asp:BoundField DataField="Caption" HeaderText="Caption" ItemStyle-HorizontalAlign="Left" />
								<asp:TemplateField>
									<ItemStyle Width="40px" />
									<ItemTemplate>
										<asp:LinkButton ID="btnSendAlert" Text="Send" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
											OnCommand="btnSendAlert_Command" ToolTip="Send message to Alliance" runat="server" />
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
					</div>
					<asp:Panel ID="pInfo" runat="server">
					</asp:Panel>
					<asp:Panel ID="pConfirm" runat="server" Visible="false">
						<div style="left: 207px; width: 400px; position: absolute; top: 207px; height: 100px; background-color: gray;">
							<br />
						</div>
						<div style="left: 200px; width: 400px; position: absolute; top: 200px; height: 100px; border-right: royalblue thin solid; border-top: royalblue thin solid; border-left: royalblue thin solid; border-bottom: royalblue thin solid; background-color: #ffffcc;">
							<div style="padding:5px;">
								<table width="390px">
									<tr class="Label" style="height:50px">
										<td colspan="2"><asp:Label ID="lblPopUpText" runat="server"></asp:Label></td>
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
			</asp:UpdatePanel>
			<br />
			
			<asp:UpdatePanel ID="upCummulativeRetursMatch" runat="server">
				<ContentTemplate>
					<asp:Panel ID="pCummulativeReturns" runat="server">
						<div style="width:800px;">
							<div class="Label" style="padding-bottom:2px; text-align:left;">
								Cummulative returns match.
							</div>
							<asp:GridView ID="gvCummulativeReturns" CssClass="GridView"
									Width="800px" HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="false" runat="server">
								<Columns>
									<asp:BoundField DataField="PersonName" HeaderText="PersonName" />
									<asp:BoundField DataField="PersonID" HeaderText="PersonID" />
									<asp:BoundField DataField="Period" HeaderText="Period" />
									<asp:BoundField DataField="BReturn" HeaderText="B Return" />
									<asp:BoundField DataField="PReturn" HeaderText="P Return" />
									<asp:BoundField DataField="Attribution" HeaderText="Attribution" />
									<asp:TemplateField>
										<ItemTemplate><div><br /></div></ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="BPReturn" HeaderText="B Return" />
									<asp:BoundField DataField="PPReturn" HeaderText="P Return" />
									<asp:BoundField DataField="PAttribution" HeaderText="Attribution" />
									<asp:TemplateField>
										<ItemTemplate><div><br /></div></ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="MaxJump" HeaderText="MaxJump(%)" />
								</Columns>
							</asp:GridView>
						</div>
					</asp:Panel>
					
					<asp:Panel ID="pDailyReturns" Visible="false" runat="server">
						<table>
							<tr>
								<td align="left">
									<asp:LinkButton ID="lbtnBackToStart" Text="Back" CssClass="LinkButton" runat="server"></asp:LinkButton>
									<div class="Label" style="padding-bottom:2px; text-align:left;">
										Analyst daily returns.
									</div>
								</td>
							</tr>
							<tr>
								<td>
									<asp:GridView ID="gvDailyReturns" CssClass="GridView"
											HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="true" runat="server">
									</asp:GridView>
								</td>
							</tr>
						</table>
					</asp:Panel>
					
					<asp:Panel ID="pInfoCummulativeRetursMatch" runat="server">
					</asp:Panel>
				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="gvCummulativeReturns" EventName="RowCommand" />
				</Triggers>
			</asp:UpdatePanel>
		</ContentTemplate>
	</asp:UpdatePanel>
	
	<script language="JavaScript" type="text/javascript">
	<!--
		function ShowWindow(alertID)
		{
			window.open('<%= ResolveUrl("~/Clients/Alliance/PreviewWindow.aspx") %>' + '?ID=' + alertID, '', 'fullscreen=yes, scrollbars=auto');
		}
	//-->
	</script>
</asp:Content>

