<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" ViewStateEncryptionMode="Always" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Support Center: Log In</title>
    <link rel="Stylesheet" href="main_style.css" type="text/css"/> 
</head>
<body>
<script type="text/jscript" language="javascript">
 function form_validator(theForm) {
  if (theForm.UserID.value == "")  {
		alert("Please enter a value for the \"User Name\" field.");
		theForm.UserID.focus();
		return (false);
	} 
  if (theForm.Password.value == "")  {
   alert("Please enter a value for the \"Password\" field.");
   theForm.Password.focus();
   return (false);
  }
  return (true);
 }
</script>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="center" style="width:100%; height:480px;" valign="middle">
            <table border="0" cellpadding="0" cellspacing="0"  style="border-width:1px; border-color:Navy; border-style:solid;">
                <tr style="background-color:#0097FE;">
                    <td align="left" valign="bottom"><img src="~/images/logo_man.jpg" alt="" id="Img1" runat="server" width="108" height="102" /></td>
                    <td align="left">
                          <table border="0" cellpadding="0" cellspacing="0">
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
                           <td align="left">
                           <form id="sec_form" runat="server" method="post" action="login.aspx" onsubmit="return form_validator(this);" enableviewstate="false">
                            <div>
                            <table border="0" cellpadding="2" cellspacing="0" class="txtFormWhite">
                            <tr>
                            <td align="left">User Name:</td><td><asp:TextBox ID="UserID" runat="server" EnableViewState="False" TabIndex="1" CssClass="TextBox"></asp:TextBox></td>
                            <td rowspan="2" valign="bottom"><asp:Button ID="GoButton" runat="server" Text="GO!" EnableViewState="False" TabIndex="3" CssClass="Button"/></td>
                            </tr>
                            <tr>
                            <td align="left">Password:</td><td><asp:TextBox ID="Password" runat="server" TextMode="Password" EnableViewState="False" TabIndex="2" CssClass="TextBox"></asp:TextBox></td>
                            </tr>
                            </table>
                        	<input type="hidden" name="Action" value="Login" />
		                    <input type="hidden" name="goBackTo" id="goBackTo" runat="server" /> 
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
                   <tr><td class="txtWarning" align="center"><asp:Label ID="mesLbl" runat="server"></asp:Label>
                    </td></tr>
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
