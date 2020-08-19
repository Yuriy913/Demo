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

public partial class support_team : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        site_utils nsite_utils = new site_utils();
        nsite_utils.RegisterClientId(this.Page, clockexam_bel);
        nsite_utils.RegisterClientId(this.Page, clockexam_usa);

        f_Lbl1.Text = DateTime.Today.Year.ToString();
        UserName.Text = "Account owner: " + (string)Session["UserIdOwner"];
        LastVisit.Text = "Last visit: " + (string)Session["LastVisit"];
        FromIP.Text = "From IP: " + (string)Session["FromIP"];
        LogOut.Text = "LogOut";
    }

    protected void CalendarTop_SelectionChanged(object sender, EventArgs e)
    {

    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/logout.aspx");
    }
}
