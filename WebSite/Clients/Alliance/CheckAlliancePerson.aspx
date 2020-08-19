<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="CheckAlliancePerson.aspx.cs" Inherits="Clients_Alliance_CheckAlliancePerson" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="cMain" ContentPlaceHolderID="main" Runat="Server">
	<asp:ScriptManager ID="smMain" EnablePartialRendering="true" runat="server">
	</asp:ScriptManager>
	<div style="text-align:left;">
		<table>
			<tr class="Label">
				<td>
					PersonID
				</td>
				<td>
					AnalystID
				</td>
				<td>
					Name
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
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="txtPersonID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtAnalystID" Width="100px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
				<td>
					<asp:TextBox ID="txtName" Width="150px" CssClass="TextBox" runat="server"></asp:TextBox>
				</td>
			</tr>
		</table>
		<asp:Panel ID="pResults" runat="Server">
			<asp:GridView ID="gvPersons" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" AutoGenerateColumns="false" runat="server">
				<Columns>
					<asp:TemplateField HeaderText="PersonID">
						<ItemTemplate>
							<asp:LinkButton OnCommand="lbtnPerson_Command" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>'
								CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>'
								CssClass="LinkButton" runat="server"></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="Name" HeaderText="Name" />
					<asp:BoundField DataField="FirstName" HeaderText="FirstName" />
					<asp:BoundField DataField="LastName" HeaderText="LastName" />
					<asp:BoundField DataField="Show" HeaderText="Show" />
					<asp:BoundField DataField="Region" HeaderText="Region" />
					<asp:BoundField DataField="NumberOfRatings" HeaderText="Ratings" />
					<asp:BoundField DataField="MoveId" HeaderText="MoveId" />
				</Columns>
			</asp:GridView>
			<asp:Panel ID="pInfo" Visible="false" runat="server">
				<div class="Label">Indexes:</div>
				<asp:GridView ID="dvIndex" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="Server">
				</asp:GridView>
				<div class="Label">Covered stocks:</div>
				<asp:GridView ID="gvStocks" CssClass="GridView" HeaderStyle-CssClass="GridViewHead" runat="server">
				</asp:GridView>
			</asp:Panel>
		</asp:Panel>
	</div>
</asp:Content>