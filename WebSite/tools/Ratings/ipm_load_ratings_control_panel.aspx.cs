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

public partial class Tools_Ratings_ipm_load_ratings_control_panel : System.Web.UI.Page
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
        //Ratings
        //cmdStr = e.Item.ValuePath.IndexOf("Ratings/Processed").ToString();
        //cmdStr = e.Item.ValuePath.IndexOf("f").ToString();
        //cmdStr = "EXEC ipm_load_ratings_control_panel";
        //Find
        if (e.Item.ValuePath == "Find/by Symbol") { 
            //made = true; cmdStr += "@IO=1,@SubIO=1,@FieldContent='" + tbFieldContent.Text + "',@SiteID='" + tbSiteID.Text + "',@AnalystID='" + tbAnalystID.Text + "',@TeamID='" + tbTeamID.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "1");
            paramArray[cp++] = new SqlParameter("@SubIO", "1");
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
            paramArray[cp++] = new SqlParameter("@SiteID", tbSiteID.Text);
            paramArray[cp++] = new SqlParameter("@AnalystID", tbAnalystID.Text);
            paramArray[cp++] = new SqlParameter("@TeamID", tbTeamID.Text);

        }

        if (e.Item.ValuePath == "Find/by Sedol") { 
            //made = true; cmdStr += "@IO=1,@SubIO=2,@FieldContent='" + tbFieldContent.Text + "',@SiteID='" + tbSiteID.Text + "',@AnalystID='" + tbAnalystID.Text + "',@TeamID='" + tbTeamID.Text + "'"; 
            paramArray[cp++] = new SqlParameter("@IO", "1");
            paramArray[cp++] = new SqlParameter("@SubIO", "2");
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
            paramArray[cp++] = new SqlParameter("@SiteID", tbSiteID.Text);
            paramArray[cp++] = new SqlParameter("@AnalystID", tbAnalystID.Text);
            paramArray[cp++] = new SqlParameter("@TeamID", tbTeamID.Text);
        }

        if (e.Item.ValuePath == "Find/by Analyst Name") { 
            //made = true; cmdStr += "@IO=1,@SubIO=3,@FieldContent='" + tbFieldContent.Text + "',@SiteID='" + tbSiteID.Text + "',@AnalystID='" + tbAnalystID.Text + "',@TeamID='" + tbTeamID.Text + "'"; 
            paramArray[cp++] = new SqlParameter("@IO", "1");
            paramArray[cp++] = new SqlParameter("@SubIO", "3");
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
            paramArray[cp++] = new SqlParameter("@SiteID", tbSiteID.Text);
            paramArray[cp++] = new SqlParameter("@AnalystID", tbAnalystID.Text);
            paramArray[cp++] = new SqlParameter("@TeamID", tbTeamID.Text);
        }

        //Ratings
        if (e.Item.ValuePath.IndexOf("Ratings/Processed") > -1) { 
            //made = true; cmdStr += "@IO=2,@SubIO=1"; 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "1");

            //if (e.Item.Value == "NULL") cmdStr += ",@Flag=NULL"; 
            if (e.Item.Value == "NULL") paramArray[cp++] = new SqlParameter("@Flag", null);

            //if (e.Item.Value == "No")  cmdStr += ",@Flag='N'"; 
            if (e.Item.Value == "No") paramArray[cp++] = new SqlParameter("@Flag","N");

            //if (e.Item.Value == "Wait") cmdStr += ",@Flag='W'"; 
            if (e.Item.Value == "Wait") paramArray[cp++] = new SqlParameter("@Flag", "W");
            
            //cmdStr += ",@HorizontalDump='" + tbHorizontalDump.Text + "'";
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
        }

        if (e.Item.ValuePath == "Ratings/StockID/Clear") { 
            //made = true; cmdStr += "@IO=2,@SubIO=2"; cmdStr += ",@HorizontalDump='" + tbHorizontalDump.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "2");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
        }

        if (e.Item.ValuePath == "Ratings/StockID/Add")
        { 
            //made = true; cmdStr += "@IO=2,@SubIO=4"; cmdStr += ",@HorizontalDump='" + tbHorizontalDump.Text + "',@FieldContent=" + tbFieldContent.Text; 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "4");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
        }

        if (e.Item.ValuePath == "Ratings/Look")
        { 
            //made = true; cmdStr += "@IO=2,@SubIO=3"; cmdStr += ",@HorizontalDump='" + tbHorizontalDump.Text + "'"; 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "3");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
        }

        if (e.Item.ValuePath == "Ratings/PersonID/Clear")
        { 
            //made = true; cmdStr += "@IO=2,@SubIO=5"; cmdStr += ",@HorizontalDump='" + tbHorizontalDump.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "5");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
        }

        //Ratings

        if (e.Item.ValuePath == "Ratings/UPDATE/Index") { 
            //made = true; cmdStr += "@IO=2,@SubIO=6"; cmdStr += ",@RatingsID='" + tbRatingsID.Text + "',@FieldContent='" + tbFieldContent.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "6");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
        }

        if (e.Item.ValuePath == "Ratings/UPDATE/Sedol") { 
            //made = true; cmdStr += "@IO=2,@SubIO=7"; cmdStr += ",@RatingsID='" + tbRatingsID.Text + "',@FieldContent='" + tbFieldContent.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "7");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
        }

        if (e.Item.ValuePath == "Ratings/UPDATE/CUSIP")
        {
            //made = true; cmdStr += "@IO=2,@SubIO=7"; cmdStr += ",@RatingsID='" + tbRatingsID.Text + "',@FieldContent='" + tbFieldContent.Text + "'";
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "11");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
        }

        if (e.Item.ValuePath == "Ratings/UPDATE/Region") { 
            //made = true; cmdStr += "@IO=2,@SubIO=8"; cmdStr += ",@RatingsID='" + tbRatingsID.Text + "',@FieldContent='" + tbFieldContent.Text + "'"; 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "8");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
        }

        if (e.Item.ValuePath == "Ratings/UPDATE/Without Stock History") { 
            //made = true; cmdStr += "@IO=2,@SubIO=9"; cmdStr += ",@RatingsID='" + tbRatingsID.Text + "'"; 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "9");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
        }
        if (e.Item.ValuePath == "Ratings/UPDATE/NewAnalystName") {
            //made = true; cmdStr += "@IO=2,@SubIO=10"; cmdStr += ",@RatingsID='" + tbRatingsID.Text + "',@FieldContent='" + tbFieldContent.Text + "'"; 
            paramArray[cp++] = new SqlParameter("@IO", "2");
            paramArray[cp++] = new SqlParameter("@SubIO", "10");
            paramArray[cp++] = new SqlParameter("@RatingsID", tbRatingsID.Text);
            paramArray[cp++] = new SqlParameter("@FieldContent", tbFieldContent.Text);
        }


        //if (tbHorizontalDump.Text == "") made = false;
        //execute
        //lCMD.Text = cmdStr;
        //if (made) get_grids(cmdStr, SUPPORT_SupportDB);
        if (cp > 0)
        {
            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("ipm_load_ratings_control_panel", paramArray, "DataSet") as DataSet;
            control_utils gu = new control_utils();
            //MasterPage MasterPage1 = Page.Master; //придержать
            gu.get_grids(ds, PlaceHolder1, null, Page.Master, false);
        }


    }
}
