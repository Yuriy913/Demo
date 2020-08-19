<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="ftp_uploding_viewer.aspx.cs" Inherits="Tools_Ratings_ftp_uploding_viewer" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel3" runat="server" BorderWidth="1px" HorizontalAlign="Left">
            <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" 
                DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                ForeColor="#990000" OnMenuItemClick="Menu1_MenuItemClick" 
                Orientation="Horizontal" StaticSubMenuIndent="10px">
                <StaticSelectedStyle BackColor="#FFCC66" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicItemTemplate>
                    <%# Eval("Text") %>
                </DynamicItemTemplate>
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <Items>
                    <asp:MenuItem Text="AdminFTP" Value="AdminFTP">
                        <asp:MenuItem Text="By ID" Value="By ID">
                            <asp:MenuItem Text="SET Show" Value="SET Show">
                                <asp:MenuItem Text="Yes" Value="Yes"></asp:MenuItem>
                                <asp:MenuItem Text="No" Value="No"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Brokers" Value="Brokers">
                        <asp:MenuItem Text="By ID" Value="By ID">
                            <asp:MenuItem Text="SET DWS_TypeOfDelay" Value="SET DWS_TypeOfDelay">
                                <asp:MenuItem Text="Work Days" Value="Work Days"></asp:MenuItem>
                                <asp:MenuItem Text="Daily" Value="Daily"></asp:MenuItem>
                                <asp:MenuItem Text="Weekly" Value="Weekly"></asp:MenuItem>
                                <asp:MenuItem Text="Two Weekly" Value="Two Weekly"></asp:MenuItem>
                                <asp:MenuItem Text="Monthly" Value="Monthly"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="SET DWS_AlertToEmails" Value="SET DWS_AlertToEmails">
                            </asp:MenuItem>
                            <asp:MenuItem Text="SET DWS_DisableStatBorderTime" 
                                Value="SET DWS_DisableStatBorderTime">
                                <asp:MenuItem Text="Yes" Value="Yes"></asp:MenuItem>
                                <asp:MenuItem Text="No" Value="No"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="SET DWS_LastAlert" ToolTip="By ID" 
                                Value="SET DWS_LastAlert"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="By AnalystID" Value="By AnalystID"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Analysts" Value="Analysts">
                        <asp:MenuItem Text="by DWS" Value="by DWS"></asp:MenuItem>
                        <asp:MenuItem Enabled="False" Text="by SubString" Value="by SubString">
                        </asp:MenuItem>
                        <asp:MenuItem Enabled="False" Text="Analyst" Value="Analyst">
                            <asp:MenuItem Text="for DWS" Value="for DWS">
                                <asp:MenuItem Text="SET Show=Y" Value="SET Show=Y"></asp:MenuItem>
                                <asp:MenuItem Text="SET Show=N" Value="SET Show=N"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Files" Value="Files">
                        <asp:MenuItem Text="by AnalystID" Value="by AnalystID">
                            <asp:MenuItem Text="All" Value="All"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="File" Value="File">
                            <asp:MenuItem Text="SET UserFlag=Y" Value="SET UserFlag=Y"></asp:MenuItem>
                            <asp:MenuItem Text="SET UserFlag=N" Value="SET UserFlag=N"></asp:MenuItem>
                            <asp:MenuItem Text="SET UserFlag=W" Value="SET UserFlag=W"></asp:MenuItem>
                            <asp:MenuItem Text="SET UserFlag=D" Value="SET UserFlag=D"></asp:MenuItem>
                            <asp:MenuItem Text="SET UserFlag=T" Value="SET UserFlag=T"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Recompare by FileID" Value="Recompare by FileID">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Not Loaded" Value="Not Loaded"></asp:MenuItem>
                        <asp:MenuItem Text="FileDone" Value="FileDone">
                            <asp:MenuItem Text="Look by FileID" Value="Look by FileID"></asp:MenuItem>
                            <asp:MenuItem Text="SET ExecAddRatingsDone=Y by FileID" 
                                Value="SET ExecAddRatingsDone=Y"></asp:MenuItem>
                            <asp:MenuItem Text="SET ExecAddRatingsDone=N by FileID" 
                                Value="SET ExecAddRatingsDone=N"></asp:MenuItem>
                            <asp:MenuItem Text="SET ExecAddRatingsDone=Y by FileID and RuleID" 
                                Value="SET ExecAddRatingsDone=Y by FileID and RuleID"></asp:MenuItem>
                            <asp:MenuItem Text="SET ExecAddRatingsDone=N by FileID and RuleID" 
                                Value="SET ExecAddRatingsDone=N by FileID and RuleID"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Full Reload BY FileID,RuleID" 
                            Value="Full Reload BY FileID,RuleID"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Rules" Value="Rules">
                        <asp:MenuItem Text="by AnalystID" Value="by AnalystID"></asp:MenuItem>
                        <asp:MenuItem Text="Disable" Value="Disable">
                            <asp:MenuItem Text="by ID" Value="by ID"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Enable" Value="Enable">
                            <asp:MenuItem Text="by ID" Value="by ID"></asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Errors" Value="Errors">
                        <asp:MenuItem Text="by FileID" Value="by FileID">
                            <asp:MenuItem Text="with ErrorID" Value="with ErrorID"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Grouped by FileID" Value="Grouped by FileID"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Ratings" Value="Ratings">
                        <asp:MenuItem Text="By FileID" Value="By FileID"></asp:MenuItem>
                        <asp:MenuItem Selectable="False" Text="Statistics" Value="Statistics">
                            <asp:MenuItem Text="for AnalystID by TimeAdded" 
                                Value="for AnalystID by TimeAdded"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="SET StockID by ID" Value="SET StockID by ID"></asp:MenuItem>
                        <asp:MenuItem Text="Moved=I by ID" Value="Moved=I by ID"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Jobs" Value="Job">
                        <asp:MenuItem Text="Last Processed" Value="Last Processed">
                            <asp:MenuItem Text="By CountStarts" Value="By CountStarts"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Statuses" Value="Status"></asp:MenuItem>
                        <asp:MenuItem Text="Server Time" Value="Server Time"></asp:MenuItem>
                        <asp:MenuItem Text="Moved Start" Value="Moved Start"></asp:MenuItem>
                        <asp:MenuItem Text="-----------------" Value="-----------------"></asp:MenuItem>
                        <asp:MenuItem Text="Start" Value="Start"></asp:MenuItem>
                        <asp:MenuItem Text="Stop" Value="Stop"></asp:MenuItem>
                        <asp:MenuItem Text="Disable" Value="Disable"></asp:MenuItem>
                        <asp:MenuItem Text="Enable" Value="Enable"></asp:MenuItem>
                        <asp:MenuItem Enabled="False" Selectable="False" Text="-----------------" 
                            Value="-----------------"></asp:MenuItem>
                        <asp:MenuItem Text="Start (Long Times)" Value="Start (Long Times)">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Stop (Long Times)" Value="Stop (Long Times)"></asp:MenuItem>
                        <asp:MenuItem Text="Disable (Long Times)" Value="Disable (Long Times)">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Enable (Long Times)" Value="Enable (Long Times)">
                        </asp:MenuItem>
                        <asp:MenuItem Enabled="False" Selectable="False" Text="-----------------" 
                            Value="-----------------"></asp:MenuItem>
                        <asp:MenuItem Text="Job Global Temp Tables" Value="Job Global Temp Tables">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Time Alert" Value="Alert">
                        <asp:MenuItem Text="Summary" Value="Summary"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="CLR Testing" Value="CLR Testing">
                        <asp:MenuItem Text="First Table" Value="First Table"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
            </asp:Menu>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Loading(sec):"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Files</asp:LinkButton>
            <br />
            <asp:Label ID="Label2" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="tbID" runat="server" Width="60px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="AnalystID:"></asp:Label>
            <asp:TextBox ID="tbAnalystID" runat="server" Width="30px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="FileID:"></asp:Label>
            <asp:TextBox ID="tbFileID" runat="server" Width="48px"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="StockID:"></asp:Label>
            <asp:TextBox ID="tbStockID" runat="server" Width="41px"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="ErrorID:"></asp:Label>
            <asp:TextBox ID="tbErrorID" runat="server" Width="24px"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="RuleID:"></asp:Label>
            <asp:TextBox ID="tbRuleID" runat="server" Width="33px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="FieldContent1:" ToolTip="Emails,"></asp:Label>
            <asp:TextBox ID="tbString1" runat="server" Width="295px"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="String2:" ToolTip="ContactPersons,"></asp:Label>
            <asp:TextBox ID="tbString2" runat="server" Width="293px"></asp:TextBox>
            <asp:Label ID="lServerTime" runat="server" Text="Server Time:"></asp:Label>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" BackColor="White" HorizontalAlign="Left">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</asp:Content>

