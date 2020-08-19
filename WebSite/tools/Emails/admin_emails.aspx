<%@ Page Language="C#" MasterPageFile="~/SUPPORT_TEAM.master" AutoEventWireup="true" CodeFile="admin_emails.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <asp:Panel ID="Panel3" runat="server" BorderWidth="1px" Height="700px"
        Width="99%" HorizontalAlign="Left" BackColor="White">
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Orientation="Horizontal"
            StaticSubMenuIndent="10px" BorderWidth="1px" OnMenuItemClick="Menu1_MenuItemClick1" PathSeparator="|">
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <StaticSelectedStyle BackColor="#FFCC66" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <Items>
                <asp:MenuItem Text="Tasks" Value="Tasks" Selectable="False">
                    <asp:MenuItem Text="Find" Value="Find"></asp:MenuItem>
                    <asp:MenuItem Text="All" Value="All"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="New One" Value="New One" ToolTip="Need: FieldContent1-Task Description"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="Bind With Groups" Value="Bind With Groups"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="UnBind With Groups" Value="UnBind With Groups"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="Disable With Groups" Value="Disable With Groups">
                    </asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="Disable" Value="Disable"></asp:MenuItem>
                    <asp:MenuItem Text="Enable" Value="Enable"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="With Groups" Value="With Groups">
                        <asp:MenuItem Text="Bind" Value="Bind"></asp:MenuItem>
                        <asp:MenuItem Text="UnBind" Value="UnBind" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Enable" Value="Enable" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Disable" Value="Disable" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="UnBind ALL" Value="UnBind ALL"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="With Addresses" Value="With Addresses">
                        <asp:MenuItem Text="Exclude" Value="Exclude"></asp:MenuItem>
                        <asp:MenuItem Text="Include" Value="Include"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Update" Value="Update">
                        <asp:MenuItem Text="Description" Value="Description"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Groups" Value="Groups" Selectable="False">
                    <asp:MenuItem Text="Find" Value="Find"></asp:MenuItem>
                    <asp:MenuItem Text="All" Value="All"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="New One" Value="New One" ToolTip="Need: FieldContent1-Task Description"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="Bind With Addresses" ToolTip="NEED: ListOfGroups, ListOfAddresses"
                        Value="Bind With Addresses"></asp:MenuItem>
                    <asp:MenuItem Text="Bind With Tasks" ToolTip="NEED: ListOfTasks,ListOfGroups" Value="Bind With Tasks">
                    </asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="Disable" Value="Disable"></asp:MenuItem>
                    <asp:MenuItem Text="Enable" Value="Enable"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="With Tasks" Value="With Tasks">
                        <asp:MenuItem Text="Bind" Value="Bind"></asp:MenuItem>
                        <asp:MenuItem Text="UnBind" Value="UnBind" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Enable" Value="Enable" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Disable" Value="Disable" Enabled="False"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="With Addresses" Value="With Addresses">
                        <asp:MenuItem Text="Bind" Value="Bind"></asp:MenuItem>
                        <asp:MenuItem Text="UnBind" Value="UnBind" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Enable" Value="Enable"></asp:MenuItem>
                        <asp:MenuItem Text="Disable" Value="Disable"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Update" Value="Update">
                        <asp:MenuItem Text="Description" Value="Description"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Addresses" Value="Addresses" Selectable="False">
                    <asp:MenuItem Text="Find" Value="Find"></asp:MenuItem>
                    <asp:MenuItem Text="All" Value="All"></asp:MenuItem>
                    <asp:MenuItem Enabled="False" Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="New One" Value="New One" ToolTip="Need: FieldContent1-ContactPerson,FieldContent2-Address"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="InActive From" Value="InActive From" ToolTip="Need:Addresses,Date"></asp:MenuItem>
                    <asp:MenuItem Text="InActive To" Value="InActive To" ToolTip="Need:Addresses,Date"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="Bind With Groups" ToolTip="NEED: ListOfGroups, ListOfAddresses"
                        Value="Bind With Groups"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="Disable" Value="Disable"></asp:MenuItem>
                    <asp:MenuItem Text="Enable" Value="Enable"></asp:MenuItem>
                    <asp:MenuItem Text="----------" Value="----------"></asp:MenuItem>
                    <asp:MenuItem Text="With Groups" Value="With Groups">
                        <asp:MenuItem Text="Bind" Value="Bind"></asp:MenuItem>
                        <asp:MenuItem Text="UnBind" Value="UnBind" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Enable" Value="Enable" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Disable" Value="Disable" Enabled="False"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="With Tasks" Value="With Tasks">
                        <asp:MenuItem Text="Exclude" Value="Exclude" Enabled="False"></asp:MenuItem>
                        <asp:MenuItem Text="Include" Value="Include" Enabled="False"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Update" Value="Update">
                        <asp:MenuItem Text="ContactPerson" ToolTip="NEED: FieldContent1" Value="ContactPerson">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Address" ToolTip="NEED: FieldContent2" Value="Address"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        </asp:Menu>
        <asp:Label ID="lMenuPath" runat="server" BorderWidth="1px"></asp:Label><br />

    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%" BorderWidth="1px">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Tasks:</asp:LinkButton><asp:TextBox
            ID="tbTaskID" runat="server" Width="145px" 
            ontextchanged="tbTaskID_TextChanged"></asp:TextBox>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">Groups:</asp:LinkButton><asp:TextBox
            ID="tbGroupID" runat="server" Width="146px"></asp:TextBox>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click">Addresses:</asp:LinkButton>
        <asp:TextBox ID="tbAddressID" runat="server" Width="188px"></asp:TextBox>&nbsp;<br />
        <asp:Label ID="Label1" runat="server" Text="FieldContent1:"></asp:Label><asp:TextBox
            ID="tbFieldContent1" runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server"
                Text="FieldContent2:"></asp:Label><asp:TextBox ID="tbFieldContent2" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label><asp:TextBox ID="tbDate" runat="server" Width="63px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="600px" ScrollBars="Both" 
            Width="100%" style="text-decoration: underline">
    <table style="width: 0%">
            <tr>
                <td style="width: 0px; height: 0px" valign="top">
                    <asp:GridView ID="GridView0" runat="server" AutoGenerateColumns="False" Font-Size="Small" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <Columns>
                            <asp:BoundField DataField="TaskID" HeaderText="T" />
                            <asp:BoundField DataField="AddressID" HeaderText="A" />
                        </Columns>
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
                <td style="width: 0px; height: 0px;" valign="top">
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView0_SelectedIndexChanged" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" DataKeyNames="ID,Description">
                        <Columns>
                            <asp:ButtonField CommandName="Select" DataTextField="ID" Text="Button" HeaderText="ID" />
                            <asp:ButtonField CommandName="Select" DataTextField="Description" HeaderText="Task Description"
                                Text="Button" >
                                <ItemStyle Wrap="False" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="Disabled" HeaderText="Dis" />
                            <asp:BoundField DataField="CountGroups" HeaderText="Gc" />
                            <asp:BoundField DataField="CountAddresses" HeaderText="Ac" />
                        </Columns>
                        <RowStyle Font-Size="Smaller" />
                        <HeaderStyle Font-Size="Smaller" Wrap="False" />
                        <AlternatingRowStyle Wrap="False" />
                    </asp:GridView>
                </td>
                <td style="height: 0px; width: 0px;" valign="top">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" DataKeyNames="ID,Description">
                        <Columns>
                            <asp:ButtonField CommandName="Select" DataTextField="ID" HeaderText="ID" Text="Button" />
                            <asp:ButtonField CommandName="Select" DataTextField="Description" HeaderText="Group Description"
                                Text="Button" >
                                <ItemStyle Wrap="False" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="Disabled" HeaderText="Dis" />
                            <asp:BoundField DataField="CountTasks" HeaderText="Tc" />
                            <asp:BoundField DataField="CountAddresses" HeaderText="Ac" />
                        </Columns>
                        <RowStyle Font-Size="Smaller" />
                        <HeaderStyle Font-Size="Smaller" Wrap="False" />
                        <AlternatingRowStyle Wrap="False" />
                    </asp:GridView>
                </td>
                <td style="width: 0px; height: 0px" valign="top">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="GroupID" HeaderText="G" />
                            <asp:BoundField DataField="AddressID" HeaderText="A" />
                            <asp:BoundField DataField="Disabled" HeaderText="D" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 0px; height: 0px;" valign="top">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="ID,ContactPerson,Address" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField CommandName="Select" DataTextField="ID" HeaderText="ID" Text="Button" />
                            <asp:ButtonField CommandName="Select" DataTextField="ContactPerson" HeaderText="ContactPerson"
                                Text="Button" >
                                <ItemStyle Wrap="False" />
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="Select" DataTextField="Address" HeaderText="Address"
                                Text="Button" />
                            <asp:BoundField DataField="Disabled" HeaderText="Dis" />
                            <asp:BoundField DataField="CountTasks" HeaderText="Tc" />
                            <asp:BoundField DataField="CountGroups" HeaderText="Gc" />
                            <asp:BoundField DataField="InActiveFrom" HeaderText="Fm" />
                            <asp:BoundField DataField="InActiveTo" HeaderText="To" />
                        </Columns>
                        <RowStyle Font-Size="Smaller" />
                        <HeaderStyle Font-Size="Smaller" Wrap="False" />
                        <AlternatingRowStyle Wrap="False" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </asp:Panel>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    &nbsp;<br />
</asp:Content>

