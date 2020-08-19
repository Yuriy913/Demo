<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="oper_file_uploader.aspx.cs" Inherits="tools_operators_oper_file_uploader" Title="Untitled Page" %>
<asp:Content ID="file_uploader" ContentPlaceHolderID="main" Runat="Server">

<table cellpadding="0" cellspacing="5" border="0" width="100%">
                <tr>
                    <td align="left">
                    <table cellpadding="0" cellspacing="3" border="0">
                    <tr><td class="LinkButton">Please upload the firm's file and in some minutes you will get an e-email from<br/>address [automatedcommunications@investars.com] with prepared ratings attached.</td></tr>
                    <tr>
                    <td><asp:FileUpload ID="mainFileUpload" runat="server" Font-Size="14px" Font-Names="Verdana"/>
                    <asp:Button ID="Upload" runat="server" Text="GO!" Font-Size="12px" Font-Names="Verdana" OnClick="Upload_Click"/></td>
                    </tr>
                    <tr><td ><asp:Label ID="lblStatus" runat="server" Text="Label" CssClass="RedLabel"></asp:Label></td></tr>
                    <tr>
                    <td class="Label">
                    Supported Firms:<br/>
                    <div class="txtFooter">
                    [211] BMO Capital Markets<br/>
                    </div>
                    </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    </table>
</asp:Content>

