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
using System.Data.SqlClient;

public partial class tools_ds_ds_check_alert_confirmation : System.Web.UI.Page
{

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(this.Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uid"] != null)
        {

            SqlParameter[] paramArray = new SqlParameter[2];

            SqlParameter param1 = new SqlParameter("@UserID", SqlDbType.Int);
            param1.Value = Session["UserId"];
            paramArray[0] = param1;

            SqlParameter param2 = new SqlParameter("@UID", SqlDbType.Int);
            param2.Value = Request.QueryString["uid"];
            paramArray[1] = param2;

            db_utils ndb_utils = new db_utils();
            String someValue = ndb_utils.get_db_Data("ds_update_check_status", paramArray, "Nonquery").ToString();

            Literal myMessage = new Literal();
            myMessage.Text = "Thank you for the check confirmation!";
            out_panel.Controls.Add(myMessage);
        }
        else
        {
            HtmlImage newImg = new HtmlImage();
            newImg.Src = ResolveUrl("~/images/ds_diagram.jpg");
            out_panel.Controls.Add(newImg);
        }
        
    }
}
