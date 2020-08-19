<%@ Page Language="C#" MasterPageFile="~/support_team.master" AutoEventWireup="true" CodeFile="support_team_home.aspx.cs" Inherits="_Default"%>
<%@ Register Src="user_controls/sup_team_members_drop_down.ascx" TagName="DropDown" TagPrefix="uc_member"%>
<asp:Content ID="main_content" ContentPlaceHolderID="main" Runat="Server">
 
 <table width="100%" cellpadding="0" cellspacing="3" border="0">
 <tr>
 <td class="Label" align="left">Support team members:</td>
 </tr>
 <tr>
 <td runat="server" id="suppteam_td" align="left"></td>
 </tr>
 <tr>
 <td class="RedLabel" align="left" id="messStatus" runat="server">&nbsp;</td>
 </tr>
  <tr>
 <td class="Label" align="left">Send a text [sms] message (100 symbols only):</td>
 </tr>
 <tr>
    <td align="left">
        <asp:TextBox ID="messTextBox" runat="server" Columns="48" Rows="3" TextMode="MultiLine" CssClass="TextBox" OnTextChanged="messTextBox_TextChanged"></asp:TextBox></td>
 </tr>
  <tr>
    <td align="left">
        <uc_member:DropDown ID="DropDown_send_to" runat="server" EnableViewState="true" />
        <asp:Button ID="GoButton" runat="server" CssClass="Button" Text="Send" OnClick="GoButton_Click" />
     </td>
 </tr>
   </table>
  </asp:Content>
 
