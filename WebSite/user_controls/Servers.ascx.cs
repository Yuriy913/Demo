using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;


public partial class User_Controls_get_servers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {   if (!IsPostBack)
        {
            ds.ConnectionString = WebConfigurationManager.ConnectionStrings["mainConnectionString"].ConnectionString;
            ds.SelectCommand = "SELECT ID,Name FROM dbo.nipm_get_servers(null)";
            //Session["ServerID"] = ServerID.SelectedValue;
        }
    ServerID.ToolTip = "ServerID=" + ServerID.SelectedValue.ToString();
    }
}
