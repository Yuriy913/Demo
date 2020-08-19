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

public partial class User_Controls_sup_team_members_drop_down : System.Web.UI.UserControl
{
    public void setDropDownAttr(Object clientDataSource, String dataTextField, String dataValueFiels, String lblName) 
    {
        if (lblName != null) 
        {
            lbl_DropDown.Text = lblName.ToString();
        }
        ddl_DropDown.DataTextField = dataTextField.ToString();
        ddl_DropDown.DataValueField = dataValueFiels.ToString();
        ddl_DropDown.DataSource = clientDataSource;
        ddl_DropDown.DataBind();
    }


    public string getDropDownValue() 
    {
        return this.ddl_DropDown.SelectedItem.Value;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            db_utils ndb_utils = new db_utils();
            setDropDownAttr(ndb_utils.get_db_Data("EXEC support_team_get_members @UserId = " + Session["UserId"].ToString() + ", @InformationType=2", null, "Reader"), "Name", "Id", "to support team member:");
        }
    }
}
