<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="dump_viewer.aspx.cs" Inherits="Tools_Quotes_dump_viewer" Title="Untitled Page" %>

<%@ Register src="../../USER_CONTROLS/Servers.ascx" tagname="Servers" tagprefix="uc1" %>
<%@ Register src="../../USER_CONTROLS/Databases.ascx" tagname="Databases" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left" BackColor="White">
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" 
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#990000" OnMenuItemClick="Menu1_MenuItemClick" 
            Orientation="Horizontal" StaticSubMenuIndent="10px">
            <StaticSelectedStyle BackColor="#FFCC66" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <Items>
                <asp:MenuItem Text="PM" Value="PM">
                    <asp:MenuItem Text="Look Bad Symbol" Value="Look Bad Symbol"></asp:MenuItem>
                    <asp:MenuItem Text="Groups(Sectors)" Value="Groups(Sectors)"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="New Stock" Value="New Stock">
                    <asp:MenuItem Text="for Quotes" Value="for Quotes">
                        <asp:MenuItem Text="New Stock - by CUSIP" Value="New Stock - by CUSIP">
                        </asp:MenuItem>
                        <asp:MenuItem Text="New Stock - by SEDOL" Value="New Stock - by SEDOL">
                        </asp:MenuItem>
                        <asp:MenuItem Text="UPDATE InstDBStockID" Value="UPDATE InstDBStockID">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="for InstDB" Value="for InstDB"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="New Person" Value="New Person">
                    <asp:MenuItem Text="General" Value="General"></asp:MenuItem>
                    <asp:MenuItem Text="for JPMorgan" Value="for JPMorgan"></asp:MenuItem>
                    <asp:MenuItem Text="for Alliance" Value="for Alliance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="FL" Value="FL">
                    <asp:MenuItem Text="Stock-Index" Value="Stock-Index"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Sectors" Value="Sectors">
                    <asp:MenuItem Text="Sectors-IPM" ToolTip="NEED : 1 AnalystID" 
                        Value="Sectors-IPM"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="SunQ" Value="SunQ">
                    <asp:MenuItem Text="Queue By StockID" Value="Queue By StockID"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <div title="Dump Viewer">
            <table border="1" style="height: 148px" width="100%">
                <tr>
                    <td style="width: 71px; height: 202px;" title="Dump Viewer" valign="top">
                        <table id="table1" border="1" cellpadding="0" cellspacing="0" 
                            style="height: 100%" width="100%">
                            <tr>
                                <td valign="top">
                                    <uc1:Servers ID="Servers1" runat="server" />
                                    <uc2:Databases ID="Databases1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 79px" valign="top">
                                    <input id="button1" onclick="return Button1_onclick()" 
                                        type="button" value="=&gt;Horizontal Dump" />
                                    <asp:TextBox ID="tb2" runat="server" Columns="18" 
                                        Rows="35" TextMode="MultiLine" 
                                        ToolTip="Vert.Dump(for preparation)"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="height: 202px" title="Dump Viewer" valign="top">
                        <table id="table_c" border="1" style="height: 148px" width="100%">
                            <tr>
                                <td style="width: 90%; height: 69px" valign="top">
                                    <asp:Label ID="Label2" runat="server" Text="Stock find BY:"></asp:Label>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">StockID/Symbol/RIC</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">InstDBStockID</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton1_Click">SEDOL</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton1_Click">CUSIP/ISIN</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButton1_Click">COMPANY/Issuer</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton1_Click">IssueName</asp:LinkButton>
                                    <br />
                                    <asp:Label ID="Label6" runat="server" Text="Stock Quotes:"></asp:Label>
                                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">Histories</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton7" runat="server" 
                                        OnClick="LinkButton7_Click">Dividends</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">Splits</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton19" runat="server" onclick="LinkButton19_Click">Request4History:</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton20" runat="server" onclick="LinkButton20_Click">Look</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton21" runat="server" onclick="LinkButton21_Click">Stopped</asp:LinkButton>
&nbsp;<asp:Label ID="Label11" runat="server" Text="Renames:"></asp:Label>
                                    <asp:LinkButton ID="LinkButton16" runat="server" Enabled="False" 
                                        OnClick="LinkButton16_Click">StockID/Symbol</asp:LinkButton>
&nbsp;
                                    <br />
                                    <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton3_Click">Persons:</asp:LinkButton>
                                    <asp:TextBox ID="tbPersons" runat="server" Width="95px"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server" Text="BY:"></asp:Label>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">PartOfName</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:Label ID="Label9" runat="server" Text="Users BY:"></asp:Label>
                                    <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButton13_Click">PartOfName</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton14" runat="server" Enabled="False">ID</asp:LinkButton>
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:Label ID="Label7" runat="server" Text="sqlCmd:"></asp:Label>
                                    <asp:TextBox ID="tb_strCmd" runat="server" EnableViewState="False" 
                                        ReadOnly="True" Width="45%"></asp:TextBox>
                                    <br />
                                    <asp:LinkButton ID="lbRatings" runat="server" OnClick="lbRatings_Click">Ratings:</asp:LinkButton>
                                    <asp:Label ID="Label15" runat="server" Text="BY:"></asp:Label>
                                    <asp:LinkButton ID="LinkButton12" runat="server" OnClick="lbRatings_Click">ID</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton10" runat="server" 
                                        OnClick="LinkButton10_Click">Last</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="LinkButton18" runat="server" onclick="LinkButton18_Click">Analysts:</asp:LinkButton>
                                    <asp:TextBox ID="tbAnalysts" runat="server" Width="96px"></asp:TextBox>
                                    &nbsp; &nbsp;&nbsp;
                                    <select ID="ddl_analysts" name="ddl_analysts" 
                                        onchange="ddl_analysts_onchange()">
                                        <option selected="selected" value="0">-- Choose Analyst --</option>
                                        <option value="1819">1819.JPMorgan</option>
                                        <option value="1227">1227.Alliance Cap</option>
                                        <option value="1">1. JPMorgan</option>
                                        <option value="2">2.Alliance Cap</option>
                                    </select>&nbsp;&nbsp;<asp:LinkButton ID="LinkButton17" runat="server" 
                                        OnClick="LinkButton3_Click">Teams:</asp:LinkButton><asp:TextBox 
                                        ID="tbTeams" runat="server" Width="49px"></asp:TextBox><asp:Label 
                                        ID="Label8" runat="server" Text="Dates:"></asp:Label><asp:TextBox 
                                        ID="TextBox1" runat="server" Enabled="False" Width="62px">1900-01-01</asp:TextBox><asp:DropDownList 
                                        ID="DropDownList1" runat="server" Enabled="False" Width="32px">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Horizontal Dump:" 
                                        ToolTip="Lists of : Symol,RIC,StockID,IssueName... OR single part of name"></asp:Label>
                                    <asp:TextBox ID="horizDump" runat="server" Width="56%"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" Text="DopHorDump:" 
                                        ToolTip="ExtraName for 1.JPMorgan"></asp:Label>
                                    <asp:TextBox ID="tbDopHorDump" runat="server" ToolTip="FOR : InstDBStockID"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="Label12" runat="server" Text="Single IDs:"></asp:Label>
                                    <asp:Label ID="Label13" runat="server" Text="StockID:"></asp:Label>
                                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Width="66px"></asp:TextBox>
                                    <asp:Label ID="Label14" runat="server" Text="InstDBStockID:"></asp:Label>
                                    <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Width="57px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel2" runat="server" Height="620px" ScrollBars="Both" 
                            Width="1050px">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    

    <script language="javascript" type="text/javascript">
// <!CDATA[
        var theForm = document.forms['aspnetForm'];
        if (!theForm) {
            theForm = document.aspnetForm;
        }

        function ddl_analysts_onchange() {
            if (document.aspnetForm.ddl_analysts.value != 0) {
                document.aspnetForm.ctl00_main_tbAnalysts.value = document.aspnetForm.ddl_analysts.value;
            }
            else {
                alert('document.aspnetForm.ddl_analysts.value = 0');
                document.aspnetForm.ctl00_main_tbAnalysts.value = '';
            }
        }

        function Button1_onclick() {
            //var str = '';
            //alert(form1.tb2.value);
            
            //str=form1.tb2.value.replace('\r\n',',');
            //str='kdsjhfksd\r\nsfdfsfd\r\ngfdgdfg'
            //alert(str);
            //str=str.replace('\(rn)',',');
            //alert(str);
        }
// ]]>
    </script>
</asp:Content>

