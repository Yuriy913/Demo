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

public partial class Tools_Exports_exports_control_panel : System.Web.UI.Page
{
    public string cmdStr = "";
    SqlParameter[] paramArray = new SqlParameter[100];
    int cp = 0;

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (!((Server.MachineName == "YURY") &&
              (Page.MasterPageFile == "/SUPPORT/MyPage.master")))
        {
            site_utils PageAttr = new site_utils();
            PageAttr.setPageAttr(this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        lMenuPath.Text = e.Item.ValuePath;
        //cmdStr = "empty";
        bool made = false;  
        //cmdStr = "EXEC exports_control_panel ";

        //Ratings
        if (e.Item.ValuePath == "Ratings/Look") { made = true; //cmdStr += "@IO=1,@SubIO=1,@ServerID=" + Session["ServerID"] + ",@DatabaseID=" + Session["DatabaseID"] + ",@ListOfRatings='" + tbListOfRatings.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "1");
            paramArray[cp++] = new SqlParameter("@SubIO", "1");
            //paramArray[cp++] = new SqlParameter("@ServerID",Session["ServerID"]);
            //paramArray[cp++] = new SqlParameter("@ServerID",Session["DatabaseID"]);
            paramArray[cp++] = new SqlParameter("@ListOfRatings", tbListOfRatings.Text);
        }

        //Servers.ServerID.Text

        //DWS
        if (e.Item.ValuePath == "DWS/Ratings/Look Exported") 
        {   
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "1");
            paramArray[cp++] = new SqlParameter("@ListOfRatings", tbListOfRatings.Text);
        }
        if (e.Item.ValuePath == "DWS/Ratings/Add as Excluded") 
        { 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "2");
            paramArray[cp++] = new SqlParameter("@ListOfRatings", tbListOfRatings.Text);
        }
        if (e.Item.ValuePath == "DWS/Ratings/Registaration Delete") 
        { 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "3");
            paramArray[cp++] = new SqlParameter("@ListOfRatings", tbListOfRatings.Text);
        }

        //if (cp>0) get_grids(cmdStr, SUPPORT_SupportDB);
        if (cp > 0)
        {
            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("exports_control_panel", paramArray, "DataSet") as DataSet;
            control_utils gu = new control_utils();
            //MasterPage MasterPage1 = Page.Master; //придержать
            gu.get_grids(ds, PlaceHolder1, null, Page.Master,false);
        }

    }
}
