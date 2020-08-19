<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="periods_control_panel.aspx.cs" Inherits="Tools_Periods_periods_control_panel" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="99%" HorizontalAlign="Left" Width="99%" BackColor="White">
        <table border="1" style="width: 100%">
            <tr>
                <td style="width: 19%; height: 38px">
                    <asp:Label ID="Label8" runat="server" Text="PeriodID:"></asp:Label><asp:TextBox ID="PeriodID"
                        runat="server" Width="52px"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">DaysOff</asp:LinkButton><br />
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Bind</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">UnBind</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Look</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Delete</asp:LinkButton></td>
                <td style="width: 799px; height: 38px">
                    <asp:Label ID="Label4" runat="server" Text="Site:"></asp:Label><asp:DropDownList
                        ID="SiteID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SiteID_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="Label5" runat="server" Text="Analyst:"></asp:Label><asp:DropDownList
                        ID="AnalystID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AnalystID_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="Label6" runat="server" Text="User:"></asp:Label><asp:TextBox ID="UserID"
                        runat="server" Width="42px"></asp:TextBox>
                    <asp:Button ID="Periods" runat="server" OnClick="Button1_Click" Text="Periods" />&nbsp;
                    <asp:DropDownList ID="SORT" runat="server" Enabled="False" OnSelectedIndexChanged="SORT_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="Label">SORT:Label</asp:ListItem>
                        <asp:ListItem Value="PeriodID">SORT:PeriodID</asp:ListItem>
                        <asp:ListItem Value="SortOrderOnIPM">SORT:SortOrderOnIPM</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Users" runat="server" OnClick="Button2_Click" Text="Users" /></td>
            </tr>
            <tr>
                <td style="width: 19%; height: 398px" valign="top">
                    <asp:Label ID="Label7" runat="server" Text="Label:"></asp:Label><br />
                    <asp:TextBox ID="Label" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label1" runat="server" Text="StartDate"></asp:Label>
                    <br />
                    <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">New</asp:LinkButton><br />
                    <asp:Label ID="Label2" runat="server" Text="StartMonths"></asp:Label><br />
                    <asp:TextBox ID="StartMonths" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label3" runat="server" Text="EndDate"></asp:Label><br />
                    <asp:TextBox ID="EndDate" runat="server"></asp:TextBox><br />
                    <asp:Button ID="addPeriod" runat="server" OnClick="addPeriod_Click" Text="Add Period"
                        Width="81px" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Find" />
                    <asp:CheckBox ID="cbAutoBind" runat="server" Text="AutoBind" TextAlign="Left" Width="80px" /><br />
                    <hr />
                    <br />
                    <br />
                    <br />
                    &nbsp;<asp:TextBox ID="Memo1" runat="server"></asp:TextBox></td>
                <td style="width: 799px; height: 398px" valign="top">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="0" EnableViewState="False"
                        Font-Size="Smaller">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <EmptyDataRowStyle Height="20px" VerticalAlign="Top" Wrap="False" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" Font-Size="Smaller" ForeColor="#000066"
                            Height="5px" HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                        <EditRowStyle Height="20px" VerticalAlign="Top" Wrap="False" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

