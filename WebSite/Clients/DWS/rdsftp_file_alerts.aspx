<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="rdsftp_file_alerts.aspx.cs" Inherits="Clients_DWS_rdsftp_file_alerts" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <div style="width: 99%; height: 100%; text-align: left; background-color: white;">
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
            <Items>
                <asp:MenuItem Text="Find By" Value="Find By">
                    <asp:MenuItem Text="By AnalystID" Value="By AnalystID"></asp:MenuItem>
                    <asp:MenuItem Text="Emails" Value="Emails"></asp:MenuItem>
                    <asp:MenuItem Text="Contact Person" Value="Contact Person"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Broker" Value="Broker">
                    <asp:MenuItem Text="Update" Value="Update">
                        <asp:MenuItem Text="ExchangeISOID" ToolTip="Need: ID,ExchangeISOID" Value="ExchangeISOID">
                        </asp:MenuItem>
                        <asp:MenuItem Text="LastAlert Date" Value="LastAlert Date"></asp:MenuItem>
                        <asp:MenuItem Text="emailGroupID" Value="emailGroupID"></asp:MenuItem>
                        <asp:MenuItem Text="TypeOfDelay" Value="TypeOfDelay">
                            <asp:MenuItem Text="Daily" ToolTip="Need:ID" Value="Daily"></asp:MenuItem>
                            <asp:MenuItem Text="Weekly" ToolTip="Need:ID" Value="Weekly"></asp:MenuItem>
                            <asp:MenuItem Text="Monthly" ToolTip="Need:ID" Value="Monthly"></asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:Label ID="lMenuPath" runat="server" BorderWidth="1px"></asp:Label><br />
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%" BorderWidth="1px">
            <asp:Label ID="label1" runat="server" Text="FieldContent1:"></asp:Label><asp:TextBox
                ID="tbFieldContent1" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="ID:"></asp:Label><asp:TextBox ID="tbID"
                runat="server" Width="47px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="ExchangeISOID:"></asp:Label><asp:TextBox ID="tbExchangeISOID" runat="server" Width="56px"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Date:"></asp:Label><asp:TextBox ID="tbDate"
                runat="server" Width="64px">12/31/1990</asp:TextBox></asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="500px" ScrollBars="Both" Width="100%" BorderWidth="1px">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </asp:Panel>
    </div>

</asp:Content>

