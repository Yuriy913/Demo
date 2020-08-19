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

public partial class user_controls_show_rows_on_page : System.Web.UI.UserControl
{

    public string getSelectedValue()
    {
        if (ddl_DropDown.SelectedIndex == -1)
        {
            return "20";
        }
        else
        {
            return ddl_DropDown.SelectedValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
