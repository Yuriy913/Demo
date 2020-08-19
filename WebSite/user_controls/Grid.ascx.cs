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

public partial class User_Controls_Grid : System.Web.UI.UserControl
{

    public void setGridAttr(Object clientDataSource)
    {
        gv_GridView.DataSource = clientDataSource;
        gv_GridView.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
