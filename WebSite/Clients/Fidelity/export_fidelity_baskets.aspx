<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true"
    CodeFile="export_fidelity_baskets.aspx.cs" Inherits="export_fidelity_baskets" %>

<asp:Content ID="main_content" ContentPlaceHolderID="main" runat="Server">
    <asp:ScriptManager runat="server" ID="ajaxSM">
    </asp:ScriptManager>
    <table cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" class="GridViewDark" width="100%">
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="3" border="0">
                                            <tr>
                                                <td class="Label">
                                                    Firm:<asp:DropDownList ID="ddFirm" runat="server" />
                                                </td>
                                                <td class="Label">
                                                    Rating:<asp:DropDownList ID="ddRating" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Label">
                                                    Industry:<asp:DropDownList ID="ddIndustry" runat="server" />
                                                </td>
                                                <td class="Label">
                                                    Rebalancing Frequency:<asp:DropDownList ID="ddRebalancingFrequency" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btnGetData" runat="server" Text="Get Data" CssClass="Button" OnClick="btnGetData_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: #FF5353; border-style: solid; border-width: thin; text-align: center;">
                                                    Critical warning
                                                </td>
                                                <td style="background-color: #9999CC; border-style: solid; border-width: thin; text-align: center;">
                                                    Warning
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
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
                            <asp:Literal ID="ltSnapshotUpdates" runat="server" Text="Snapshot Updates:" Visible="false" />
                            <br />
                            <asp:GridView ID="gvSnapshotUpdates" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true" CssClass="GridView"
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="1px" CellPadding="3"
                                CellSpacing="1" GridLines="None" EnableViewState="False" AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="Last_Time" HeaderText="Last Time">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Previous_Time" HeaderText="Previous Time">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="2_Times_Before" HeaderText="2 Times Before">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="3_Times_Before" HeaderText="3 Times Before">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltInsufficientСoverage" Text="Table with changes in flags of insufficient coverage:"
                                runat="server" Visible="false" />
                            <br />
                            <asp:GridView ID="gvInsufficientСoverage" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true"
                                CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="FirmID" HeaderText="FirmID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RatingType" HeaderText="Rating Type">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Industry" HeaderText="Industry">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rebalancing_Frequency" HeaderText="Rebalancing Frequency">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearInsufficientCoverage_PREV" HeaderText="One Year Insufficient Coverage PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearInsufficientCoverage_NEXT" HeaderText="One Year Insufficient Coverage NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_OneYearInsufficientCoverage" HeaderText="Jump One Year Insufficient Coverage"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearInsufficientCoverage_PREV" HeaderText="Two Year Insufficient Coverage PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearInsufficientCoverage_NEXT" HeaderText="Two Year Insufficient Coverage NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_TwoYearInsufficientCoverage" HeaderText="Jump Two Year Insufficient Coverage"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearInsufficientCoverage_PREV" HeaderText="Three Year Insufficient Coverage PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearInsufficientCoverage_NEXT" HeaderText="Three Year Insufficient Coverage NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_ThreeYearInsufficientCoverage" HeaderText="Jump Three Year Insufficient Coverage"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltNumberOfComponents" runat="server" Text="Table with jumps in number of components:"
                                Visible="false" />
                            <br />
                            <asp:GridView ID="gvNumberOfComponents" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true"
                                CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                OnRowDataBound="gvNumberOfComponents_RowDataBound" AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="FirmID" HeaderText="FirmID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RatingType" HeaderText="Rating Type">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Industry" HeaderText="Industry">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rebalancing_Frequency" HeaderText="Rebalancing Frequency">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumberOfComponents_PREV" HeaderText="Number Of Components PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumberOfComponents_NEXT" HeaderText="Number Of Components NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_NumberOfComponents" HeaderText="Jump Number Of Components"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltJumpInReturns" runat="server" Text="Table with jumps in returns:"
                                Visible="false" />
                            <br />
                            <asp:GridView ID="gvJumpInReturns" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true" CssClass="GridView"
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="1px" CellPadding="3"
                                CellSpacing="1" GridLines="None" EnableViewState="False" OnRowDataBound="gvJumpInReturns_RowDataBound"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="FirmID" HeaderText="FirmID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RatingType" HeaderText="Rating Type">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Industry" HeaderText="Industry">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rebalancing_Frequency" HeaderText="Rebalancing Frequency">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearReturn_PREV" HeaderText="One Year Return PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearReturn_NEXT" HeaderText="One Year Return NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_OneYearReturn" HeaderText="Jump One Year Return"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearReturn_PREV" HeaderText="Two Year Return PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearReturn_NEXT" HeaderText="Two Year Return NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_TwoYearReturn" HeaderText="Jump Two Year Return"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearReturn_PREV" HeaderText="Three Year Return PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearReturn_NEXT" HeaderText="Three Year Return NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_ThreeYearReturn" HeaderText="Jump Three Year Return"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltAverageValueOfReturn" runat="server" Text="Table with jumps in industries near average value of return:"
                                Visible="false" />
                            <br />
                            <asp:GridView ID="gvAverageValueOfReturn" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true"
                                CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                OnRowDataBound="gvAverageValueOfReturn_RowDataBound" AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="FirmID" HeaderText="FirmID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RatingType" HeaderText="Rating Type">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Industry" HeaderText="Industry">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rebalancing_Frequency" HeaderText="Rebalancing Frequency">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearReturn" HeaderText="One Year Return" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearReturnIndustryAvg" HeaderText="One Year Return Industry Avg"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_OneYearReturnIndustry" HeaderText="Jump One Year Return Industry"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearReturn" HeaderText="Two Year Return" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearReturnIndustryAvg" HeaderText="Two Year Return Industry Avg"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_TwoYearReturnIndustry" HeaderText="Jump Two Year Return Industry"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearReturn" HeaderText="Three Year Return" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearReturnIndustryAvg" HeaderText="Three Year Return Industry Avg"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_ThreeYearReturnIndustry" HeaderText="Jump Three Year Return Industry"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltJumpsInTurnovers" runat="server" Text="Table with jumps in turnovers:"
                                Visible="false" />
                            <br />
                            <asp:GridView ID="gvJumpsInTurnovers" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true" CssClass="GridView"
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="1px" CellPadding="3"
                                CellSpacing="1" GridLines="None" EnableViewState="False" OnRowDataBound="gvJumpsInTurnovers_RowDataBound"
                                AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="FirmID" HeaderText="FirmID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RatingType" HeaderText="Rating Type">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Industry" HeaderText="Industry">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rebalancing_Frequency" HeaderText="Rebalancing Frequency">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearTurnover_PREV" HeaderText="One Year Turnover PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearTurnover_NEXT" HeaderText="One Year Turnover NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_OneYearTurnover" HeaderText="Jump One Year Turnover"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearTurnover_PREV" HeaderText="Two Year Turnover PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearTurnover_NEXT" HeaderText="Two Year Turnover NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_TwoYearTurnover" HeaderText="Jump Two Year Turnover"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearTurnover_PREV" HeaderText="Three Year Turnover PREV"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearTurnover_NEXT" HeaderText="Three Year Turnover NEXT"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_ThreeYearTurnover" HeaderText="Jump Three Year Turnover"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Literal ID="ltAverageValueOfTurnover" runat="server" Text="Table with jumps in industries near average value of turnover:"
                                Visible="false" />
                            <br />
                            <asp:GridView ID="gvAverageValueOfTurnover" runat="server" ShowHeaderWhenEmpty="True" ShowHeader="true"
                                CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" EnableViewState="False"
                                OnRowDataBound="gvAverageValueOfTurnover_RowDataBound" AutoGenerateColumns="false">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <Columns>
                                    <asp:BoundField DataField="FirmID" HeaderText="FirmID">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firm" HeaderText="Firm">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RatingType" HeaderText="Rating Type">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Industry" HeaderText="Industry">
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rebalancing_Frequency" HeaderText="Rebalancing Frequency">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearTurnover" HeaderText="One Year Turnover" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OneYearTurnoverIndustryAvg" HeaderText="One Year Turnover Industry Avg"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_OneYearTurnoverIndustry" HeaderText="Jump One Year Turnover Industry"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearTurnover" HeaderText="Two Year Turnover" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TwoYearTurnoverIndustryAvg" HeaderText="Two Year Turnover Industry Avg"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_TwoYearTurnoverIndustry" HeaderText="Jump Two Year Turnover Industry"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearTurnover" HeaderText="Three Year Turnover" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ThreeYearTurnoverIndustryAvg" HeaderText="Three Year Turnover Industry Avg"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Jump_ThreeYearTurnoverIndustry" HeaderText="Jump Three Year Turnover Industry"
                                        DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="center" />
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
