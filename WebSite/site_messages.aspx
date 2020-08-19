<%@ Page Language="C#" AutoEventWireup="true" CodeFile="site_messages.aspx.cs" Inherits="site_messages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="messHead" runat="server">
<link rel="Stylesheet" href="main_style.css" type="text/css"/>  
<title>Warning!!!</title>
</head>
<body>
    <form id="war_form" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
        <!-- Top -->
        
  <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color:#0097FE;">
    <tr>
        <td align="left" style="width:100%;">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left"><img src="~/images/logo_man.jpg" alt="" id="Img1" runat="server"/></td>
                    <td align="left" valign="top" style="width:100%;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                           <tr>
                                <td align="left" style="font-size:25px; font-family: Courier New; color:#26B9FE; font-weight:bold; text-decoration: underline;">
                                    NETOLOGIC INC.
                                </td>
                                <td rowspan="2" align="right" style="font-size:10px; font-family: Verdana; color:#284E98; font-weight:bold;">
                                </td>
                           </tr>
                           <tr>
                                <td align="left" valign="top" style="font-size:18px; font-family: Courier New; color:#26B9FE; font-weight:bold;">
                                    SUPPORT CENTER
                                </td>
                           </tr>
                         </table> </td>
                </tr>
            </table>
        </td>
    </tr>
  </table>
       
        <!-- End Top -->
        </td>
    </tr>
    <tr>
      <td align="center">
      <table width="97%" cellpadding="15" cellspacing="0" border="0">
      <tr><td style="height:14px"></td></tr>
        <tr>
            <td  class="FrameColor" align="center">
            <asp:Label ID="MesLabel" runat="server" CssClass="txtWarning"></asp:Label>
            </td>
        </tr>
        <tr><td style="height:10px"></td></tr>
       </table>
      </td>
    </tr>
    <tr>
        <td>
        <!-- Footer -->
        <table width="100%" border="0" cellspacing="5" cellpadding="0">
           <tr>
            <td align="center"><img alt="" src="~/images/footer.gif" id="FootImage" runat="server" /></td>
           </tr>
           <tr>
              <td align="center" class="txtFooter">&copy; Copyright 2007-<asp:Label ID="f_Lbl1" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td align="center" class="txtFooter">[Support Center]</td>
            </tr>
        </table>
        <!-- End Footer -->
        </td>
    </tr>
    </table>
</form>
</body>
</html>





