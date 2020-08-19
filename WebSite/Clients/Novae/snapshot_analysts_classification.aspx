<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true"
    CodeFile="snapshot_analysts_classification.aspx.cs" Inherits="snapshot_analysts_classification" %>

<asp:Content ID="main_content" ContentPlaceHolderID="main" runat="Server">
    <asp:ScriptManager runat="server" ID="ajaxSM">
    </asp:ScriptManager>
    <table cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" border="0">
                    <tr>
                        <td>
                            <asp:UpdateProgress ID="ajaxUPr" runat="server" DisplayAfter="100">
                                <ProgressTemplate>
                                    <div class="txtFooter">
                                        Loading...</div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:SqlDataSource ID="mySqlDataSource" runat="server"></asp:SqlDataSource>
                            <asp:Literal ID="ltTodaysListOfAnalysts" runat="server" Text="Today's list of analysts:" />
                            <br />
                            <asp:GridView ID="gvTodaysListOfAnalysts" runat="server" ShowHeaderWhenEmpty="True"
                                ShowHeader="true" CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Show" HeaderText="Show">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Calculate" HeaderText="Calculate">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FidelityIRP" HeaderText="FidelityIRP">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltTodaysClassifications" runat="server" Text="Today's classifications:" />
                            <br />
                            <asp:GridView ID="gvTodaysClassifications" runat="server" ShowHeaderWhenEmpty="True"
                                ShowHeader="true" CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClassificationID" HeaderText="ClassificationID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Classification" HeaderText="Classification">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltNewAnalysts" runat="server" Text="New analysts:" />
                            <br />
                            <asp:GridView ID="gvNewAnalysts" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true"
                                CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Show" HeaderText="Show">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Calculate" HeaderText="Calculate">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FidelityIRP" HeaderText="FidelityIRP">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltRemovedAnalysts" runat="server" Text="Removed analysts:" />
                            <br />
                            <asp:GridView ID="gvRemovedAnalysts" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true"
                                CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Show" HeaderText="Show">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Calculate" HeaderText="Calculate">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FidelityIRP" HeaderText="FidelityIRP">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltAnalystsWithChangedParameters" runat="server" Text="Analysts with changed parameters:" />
                            <br />
                            <asp:Panel ID="pnlLegend" runat="server" Visible="false">
                                <table cellpadding="0" cellspacing="3" border="0" width="10%">
                                    <tr>
                                        <td style="background-color: #F7C1FD; border-style: solid; border-width: thin; text-align: center;">
                                            Changed
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:GridView ID="gvAnalystsWithChangedParameters" runat="server" ShowHeaderWhenEmpty="True"
                                ShowHeader="true" CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false" OnRowDataBound="gvAnalystsWithChangedParameters_RowDataBound">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Show" HeaderText="Show">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Calculate" HeaderText="Calculate">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FidelityIRP" HeaderText="FidelityIRP">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltNewClassifications" runat="server" Text="New classifications:" />
                            <br />
                            <asp:GridView ID="gvNewClassifications" runat="server" ShowHeaderWhenEmpty="True"
                                ShowHeader="true" CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClassificationID" HeaderText="ClassificationID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Classification" HeaderText="Classification">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltRemovedClassifications" runat="server" Text="Removed classifications:" />
                            <br />
                            <asp:GridView ID="gvRemovedClassifications" runat="server" ShowHeaderWhenEmpty="True"
                                ShowHeader="true" CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClassificationID" HeaderText="ClassificationID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Classification" HeaderText="Classification">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
