<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="eds_work_log.aspx.cs" Inherits="tools_eds_work_log"%>
<%@ Register Src="~/user_controls/date.ascx" TagName="date" TagPrefix="myuc2" %>
<%@ Register Src="~/user_controls/eds_tasks.ascx" TagName="eds_tasks" TagPrefix="myuc1" %>
<%@ Register Src="~/user_controls/show_rows_on_page.ascx" TagName="show_rows_on_page" TagPrefix="myuc" %>

            <asp:Content ID="main_content" ContentPlaceHolderID="main" Runat="Server">
                <asp:ScriptManager runat="server" ID="ajaxSM">
                </asp:ScriptManager>
            <table cellpadding="0" cellspacing="5" border="0">
                <tr>
                    <td align="center">
                    <table cellpadding="0" cellspacing="3" border="0">
                    <tr>
                    <td>
                    <table cellpadding="0" cellspacing="0" border="0" class="GridViewDark" width="100%">
                    <tr><td align="left">
                    <table cellpadding="0" cellspacing="3" border="0">
                    <tr>
                    <td>
                        <myuc1:eds_tasks ID="eds_tasks1" runat="server"/>
                    </td>
                    <td class="Label">Find TaskID: <asp:TextBox ID="TaskID" runat="server" CssClass="TextBox" Columns="5"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td colspan="2"><myuc2:date ID="StartDate" runat="server" /><myuc2:date ID="EndDate" runat="server" />
                    </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                        <myuc:show_rows_on_page id="show_rows_on_page1" runat="server"/>
                        <asp:Button ID="Go" runat="server" Text="GO!" CssClass="Button"/>
                        
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2" align="center" class="RedLabel"><asp:RangeValidator MinimumValue="1" MaximumValue="999999999999" CssClass="RedLabel" ControlToValidate="TaskId" ID="TaskIDValidator" runat="server" ErrorMessage="The value should be a number more than zero..."></asp:RangeValidator><asp:Literal runat="server" ID="ErrorMessage"></asp:Literal></td>
                    </tr>
                    
                    </table>
                    </td></tr></table>
                    </td><td>
                        &nbsp;</td>
                    </tr>
                    <tr><td><asp:UpdateProgress id="ajaxUPr" runat="server" DisplayAfter="100"><progresstemplate><div class="txtFooter">Loading...</div></progresstemplate></asp:UpdateProgress></td></tr>
                        <tr>
                             <td valign="top">
                                 <asp:SqlDataSource ID="mySqlDataSource" runat="server">
                                 </asp:SqlDataSource>
                <asp:UpdatePanel runat="server" ID="ajaxUPG">
                <contenttemplate>
                <asp:GridView ID="work_log_grid" runat="server" CssClass="GridView" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" AllowPaging="True" AllowSorting="True" PageSize="20" AutoGenerateColumns="False" DataSourceID="mySqlDataSource" OnRowCreated="work_log_grid_RowCreated" EnableViewState="False" OnSelectedIndexChanging="work_log_grid_SelectedIndexChanging">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <Columns>
                        <asp:BoundField DataField="UID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                            SortExpression="UID" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" DataFormatString="{0:yyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TaskName" HeaderText="Task Name" SortExpression="TaskName" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SourceFileName" HeaderText="File" SortExpression="SourceFileName" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ExitCode" HeaderText="Result" ReadOnly="True" SortExpression="ExitCode" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" SelectText="Details" ShowCancelButton="False" />
                    </Columns>
                </asp:GridView>
                </contenttemplate>
                                     </asp:UpdatePanel>
                            </td>
                            <td valign="top" align="left">
                                <asp:UpdatePanel runat="server" ID="ajaxUP">
                                <Triggers>
<asp:AsyncPostBackTrigger ControlID="work_log_grid" EventName="SelectedIndexChanging"></asp:AsyncPostBackTrigger>
</Triggers>
                                </asp:UpdatePanel>&nbsp;
                                </td>
                        </tr>
                    </table>
                </td>
                </tr>
            </table>
            
           </asp:Content>
 
         
 
  