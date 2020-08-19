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

public partial class Clients_DWS_rdsftp_file_alerts : System.Web.UI.Page
{
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
        control_utils tt = new control_utils();
        tt.setMenuStyle(ref Menu1, 1);
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {   int cp = 0;
        string p0 = "", v0 = "";
        string p1 = "", v1 = "";
        string p2 = "", v2 = "";
        string p3 = "", v3 = "";
        string p4 = "", v4 = "";

        lMenuPath.Text = e.Item.ValuePath;

        //Find By
        if (e.Item.ValuePath == "Find By|Emails") 
        {   cp += 3; 
            p0 = "@IO"; v0 = "1"; 
            p1 = "@SubIO"; v1 = "1"; 
            p2 = "@FieldContent1"; v2 = tbFieldContent1.Text; 
        }
        if (e.Item.ValuePath == "Find By|Contact Person")
        {
            cp += 3;
            p0 = "@IO"; v0 = "1";
            p1 = "@SubIO"; v1 = "2";
            p2 = "@FieldContent1"; v2 = tbFieldContent1.Text;
        }
        if (e.Item.ValuePath == "Find By|By AnalystID")
        {
            cp += 3;
            p0 = "@IO"; v0 = "2";
            p1 = "@SubIO"; v1 = "1";
            p2 = "@FieldContent1"; v2 = tbFieldContent1.Text;
        }

        //Broker
        if (e.Item.ValuePath == "Broker|Update|ExchangeISOID")
        {
            cp += 4;
            p0 = "@IO";             v0 = "3";
            p1 = "@SubIO";          v1 = "1";
            p2 = "@ID";             v2 = tbID.Text;
            p3 = "@ExchangeISOID";  v3 = tbExchangeISOID.Text;
        }

        if (e.Item.ValuePath == "Broker|Update|LastAlert Date")
        {
            cp += 4;
            p0 = "@IO";             v0 = "3";
            p1 = "@SubIO";          v1 = "2";
            p2 = "@ID";             v2 = tbID.Text;
            p3 = "@Date";  v3 = tbDate.Text;
        }
        if (e.Item.ValuePath == "Broker|Update|emailGroupID")
        {
            cp += 4;
            p0 = "@IO";            v0 = "3";
            p1 = "@SubIO";         v1 = "3";
            p2 = "@ID";            v2 = tbID.Text;
            p3 = "@FieldContent1"; v3 = tbFieldContent1.Text;
        }
        if ((e.Item.ValuePath == "Broker|Update|TypeOfDelay|Daily")||
            (e.Item.ValuePath == "Broker|Update|TypeOfDelay|Weekly")||
            (e.Item.ValuePath == "Broker|Update|TypeOfDelay|Monthly"))
        {
            cp += 4;
            p0 = "@IO"; v0 = "3";
            p1 = "@SubIO"; v1 = "4";
            p2 = "@ID"; v2 = tbID.Text;
            if (e.Item.ValuePath == "Broker|Update|TypeOfDelay|Daily") { p3 = "@FieldContent1"; v3 = "Daily"; }
            if (e.Item.ValuePath == "Broker|Update|TypeOfDelay|Weekly") {p3 = "@FieldContent1"; v3 = "Weekly"; }
            if (e.Item.ValuePath == "Broker|Update|TypeOfDelay|Monthly") {p3 = "@FieldContent1"; v3 = "Monthly";  }
        }



        if (cp > 0)
        {
            SqlParameter[] paramArray = new SqlParameter[cp];
            if (p0 != "") paramArray[0] = new SqlParameter(p0, v0);
            if (p1 != "") paramArray[1] = new SqlParameter(p1, v1);
            if (p2 != "") paramArray[2] = new SqlParameter(p2, v2);
            if (p3 != "") paramArray[3] = new SqlParameter(p3, v3);
            if (p4 != "") paramArray[4] = new SqlParameter(p4, v4);

            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("rdsftp_file_alerts", paramArray, "DataSet") as DataSet;

            int[] StaticGridViews = new int[0];
            control_utils gu = new control_utils();
            MasterPage MasterPage1 = Page.Master;
            gu.get_grids(ds, PlaceHolder1, StaticGridViews, MasterPage1,false); 
        }
    }
}
