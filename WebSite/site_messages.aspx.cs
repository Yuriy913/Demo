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

public partial class site_messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        f_Lbl1.Text = DateTime.Today.Year.ToString();
        if (Request.QueryString["Mess"] != null)
        { 
            if (Request.QueryString["Mess"] == "naftp")
            {
                MesLabel.Text = "You don't have any access for this page.";
            }

            if (Request.QueryString["Mess"] == "npasftu")
            {
                MesLabel.Text = "Current user doesn't have any page access at all.";
            }
            if (Request.QueryString["Mess"] == "err")
            {
                MesLabel.Text = "We are sorry, we are experiencing technical difficulties at this time.";
            }
            
        }
    }
}
