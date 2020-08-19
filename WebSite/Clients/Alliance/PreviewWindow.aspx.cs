using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clients_Alliance_PreviewWindow : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		int alertID = 0;

		if (Request.QueryString["ID"] != null)
		{
			Int32.TryParse(Request.QueryString["ID"], out alertID);
		}

		string messageText = String.Empty;

		if (alertID != 0)
		{
			try
			{
				messageText = Data.getAllianceAlertText(alertID);
			}
			catch //(Exception ex)
			{
				//Data.ShowError(pInfo, ex);
			}
		}

		if (!messageText.Equals(String.Empty))
		{
			Response.Write(messageText);//load it to current window
			Response.End();
		}
	}
}
