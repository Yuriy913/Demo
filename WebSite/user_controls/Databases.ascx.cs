using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Configuration;

public partial class USER_CONTROLS_Databases : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string NewServerID = "";
        if (!IsPostBack) ServerID.Text = "";
        if (Request.Form.Get("ctl00$main$Servers1$ServerID") == null)
        {
            NewServerID = "0";
        }
        else
        {
            NewServerID = Request.Form.Get("ctl00$main$Servers1$ServerID");
        }

        //Security length
        if (NewServerID.Length > 3) NewServerID = NewServerID.Substring(1, 3);

        if (ServerID.Text != NewServerID)
        {
            ServerID.Text = NewServerID;
            ds.ConnectionString = WebConfigurationManager.ConnectionStrings["mainConnectionString"].ConnectionString;
            ds.SelectCommand = "SELECT ID,Name FROM dbo.nipm_get_databases(" + ServerID.Text + ",null)";
            DatabaseID.DataBind();
            DatabaseID.ToolTip = "ServerID=" + ServerID.Text + ",DatabaseID=" + DatabaseID.SelectedValue.ToString();

            //Request.Form.Set("ctl00$main$Databases$DatabaseID", DatabaseID.SelectedValue);
            //Request.Form.S

            //DatabaseID.ID.ToString()-НЕ ПОЙДЕТ
            //DatabaseID.NamingContainer.ToString() -?
            //DatabaseID.Page.ToString()
            //DatabaseID.UniqueID.ToString()-полезняха
            //DatabaseID.ClientID.ToString()-полезняха 

        }

    }
}
