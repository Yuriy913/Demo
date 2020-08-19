<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Support Center: Log Out</title>
    <link rel="Stylesheet" href="main_style.css" type="text/css"/> 
</head>
<body>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="center" style="width:100%; height:480px;" valign="middle">
            <table border="0" cellpadding="0" cellspacing="0"  style="border-width:1px; border-color:Navy; border-style:solid;">
                <tr style="background-color:#0097FE;">
                    <td align="left" valign="bottom"><img src="~/images/logo_man.jpg" alt="" id="Img1" runat="server" width="108" height="102"/></td>
                    <td align="left">
                          <table border="0" cellpadding="2" cellspacing="0">
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
                           <tr>
                           <td align="center">
                           <form id="frm_logout" runat="server">
                            <div>
                            <table border="0" cellpadding="2" cellspacing="0" class="txtFormWhite">
                            <tr>
                            <td align="center">Thank you for using our<br/>SUPPORT CENTER!</td>
                            </tr>
                            <tr>
                            <td align="center"><asp:LinkButton ID="reLogIn" runat="server" CssClass="txtFormWhite" OnClick="reLogIn_Click"></asp:LinkButton></td>
                            </tr>
                            </table>
                            </div>
                            </form>
                            </td>
                            </tr>
                         </table> 
                      </td>
                </tr>
                <tr>
                   <td align="center" style="background-color:#fffacd" colspan="2">
                   <table border="0" cellpadding="2" cellspacing="0">
                   <tr><td class="txtFooter">&copy; Copyright 2007-<asp:Label ID="cLbl" runat="server"></asp:Label>
                    </td></tr>
                    </table>
                   </td>
                 </tr>
            </table>
        </td>
    </tr>
  </table>
    
    
    
    
</body>
</html>
