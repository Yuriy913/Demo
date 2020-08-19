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

public partial class user_controls_eds_tasks : System.Web.UI.UserControl
{

    public string getSelectedValue() 
    {
        if (ddl_DropDown.SelectedIndex == -1)
        {
            return "-1";
        }
        else 
        {
            return ddl_DropDown.SelectedValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string selValue = "-1";
        db_utils ndb_utils = new db_utils();
        SqlDataReader reader = ndb_utils.get_db_Data("EXEC eds_get_tasks", null, "Reader") as SqlDataReader;

        if (IsPostBack)
        {
            selValue = ddl_DropDown.SelectedValue;
            ddl_DropDown.Items.Clear();
        }

            while (reader.Read())
            {
                ListItem nli = new ListItem(reader["Name"].ToString(), reader["Id"].ToString());
                if (reader["Id"].ToString() == selValue)
                {
                    nli.Selected = true;
                }
                if (reader["UseIt"].ToString() == "N")
                    nli.Attributes.CssStyle.Add("Color", "Silver");
                ddl_DropDown.Items.Add(nli);
            }
            reader.Close();
        }
}
