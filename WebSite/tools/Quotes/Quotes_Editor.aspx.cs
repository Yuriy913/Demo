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
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    //string strCMD = "";
    //string SUPPORT_SupportDB = WebConfigurationManager.ConnectionStrings["SUPPORT_SupportDB"].ToString();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(this.Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        control_utils tt = new control_utils();
        tt.setMenuStyle(ref Menu1, 1);
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {   int cp=0;
        string p0 = "", v0 = ""; 
        string p1 = "", v1 = ""; 
        string p2 = "", v2 = ""; 
        string p3 = "", v3 = "";
        string p4 = "", v4 = "";

        lMenuPath.Text = e.Item.ValuePath;

        //Stocks
        if (e.Item.ValuePath == "Stocks|Look") {cp +=3; p0 = "@IO"; v0="1"; p1 = "@SubIO"; v1 = "1"; p2 = "@StocksID"; v2 = tbStocksID.Text;}
        if (e.Item.ValuePath == "Stocks|UPDATE|RIC") { cp += 4; p0 = "@IO"; v0 = "1"; p1 = "@SubIO"; v1 = "2"; p2 = "@StocksID"; v2 = tbStocksID.Text; p3 = "@RIC"; v3 = tbFieldContent1.Text; }
        if (e.Item.ValuePath == "Stocks|UPDATE|InstDBStockID"){cp +=4; p0 = "@IO"; v0 = "1";p1 = "@SubIO"; v1 = "4";p2 = "@StocksID"; v2 = tbStocksID.Text;p3 = "@FieldContent1"; v3 = tbFieldContent1.Text;}
        if (e.Item.ValuePath == "Stocks|History|Delete/On 1 Date") { cp += 4; p0 = "@IO"; v0 = "1"; p1 = "@SubIO"; v1 = "3"; p2 = "@StocksID"; v2 = tbStocksID.Text; p3 = "@Date"; v3 = tbFieldContent1.Text; }

        //InstDB
        if (e.Item.ValuePath == "InstDB|Keep Pair Symbol & RIC|Look") {cp +=3; p0 = "@IO"; v0 = "2";p1 = "@SubIO"; v1 = "1";p2 = "@StocksID"; v2 = tbStocksID.Text;}
        if ((e.Item.ValuePath == "InstDB|Keep Pair Symbol & RIC|From Stocks") || (e.Item.ValuePath == "Keep from Stocks")) {cp +=3; p0 = "@IO"; v0 = "2";p1 = "@SubIO"; v1 = "2";p2 = "@StocksID"; v2 = tbStocksID.Text;}
        if (e.Item.ValuePath == "InstDB|Keep Pair Symbol & RIC|Delete") {cp +=3; p0 = "@IO"; v0 = "2";p1 = "@SubIO"; v1 = "4";p2 = "@StocksID"; v2 = tbStocksID.Text;}

        //lCMD.Text = strCMD;
        //if (Made) { SqlDataSource1.SelectCommand = strCMD; }

        if (cp>0)
        {
            SqlParameter[] paramArray = new SqlParameter[cp];
            if (p0 != "") paramArray[0] = new SqlParameter(p0, v0);
            if (p1 != "") paramArray[1] = new SqlParameter(p1, v1);
            if (p2 != "") paramArray[2] = new SqlParameter(p2, v2);
            if (p3 != "") paramArray[3] = new SqlParameter(p3, v3);
            if (p4 != "") paramArray[4] = new SqlParameter(p4, v4);

            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("quotes_editor", paramArray, "DataSet") as DataSet;

            int[] StaticGridViews = new int[3];
            control_utils gu = new control_utils();
            MasterPage MasterPage1 = Page.Master;
            //gu.get_grids(ds, PlaceHolder1, StaticGridViews, MasterPage1);
        }

    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
