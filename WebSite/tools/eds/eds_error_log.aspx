<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="eds_error_log.aspx.cs" Inherits="tools_eds_eds_error_log" Title="Untitled Page" %>
<asp:Content ID="error_log" ContentPlaceHolderID="main" Runat="Server">

<table width="100%" cellpadding="0" cellspacing="5" border="0">
<tr><td align="left">
<table cellpadding="0" cellspacing="3" border="0" width="100%" class="GridViewDark">
 <tr>
 <td colspan="2">
 <table cellpadding="0" cellspacing="3" border="0">
 <tr>
 <td class="txtPagesLabel" align="left"style="white-space: nowrap;">Server Name:</td> 
 <td class="txtPagesResult"><asp:Literal runat="server" ID="ServerName"></asp:Literal></td>
 </tr>
 <tr>
    <td class="txtPagesLabel" align="left">Error Log Path:</td> 
    <td class="txtPagesResult"><asp:Literal runat="server" ID="ErroLogPath"></asp:Literal></td>
 </tr>
  </table>
  </td>
 </tr>
  <tr>
    <td class="txtPagesLabel" align="left" valign="bottom">Show
    <asp:TextBox ID="ErrorsNumber" runat="server" TabIndex="1" CssClass="TextBox" Columns="3" Text="3"></asp:TextBox>
    last error(s) from <asp:Literal runat="server" ID="TotalErrors"></asp:Literal>.
    <asp:Button ID="Go" runat="server" Text="GO!" TabIndex="2" CssClass="Button"/>
    </td>
    <td class="RedLabel" align="left" valign="bottom">
    <asp:Literal runat="server" ID="ErrorMessage"></asp:Literal><br/>
 <asp:RangeValidator ControlToValidate="ErrorsNumber"
    MinimumValue="1" MaximumValue="999" runat="server" 
    ID="ValidatorErrNumber" ErrorMessage="The value should be a number between 1 and 999..."
    Enabled="true" EnableClientScript="true"></asp:RangeValidator>
    <br/><asp:RequiredFieldValidator runat="server" EnableClientScript="true" ControlToValidate="ErrorsNumber"
    Enabled="true" ID="ValidatorEmpty" ErrorMessage="Please set a value as a number between 1 and 999... "></asp:RequiredFieldValidator>
    </td>
 </tr>
 </table>
 </td>
 </tr>
 <tr><td align="left">
 <div id="ResultText" runat="server"></div>
 </td></tr>
 </table>

</asp:Content>

