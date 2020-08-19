using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Tools_Quotes_dump_viewer : System.Web.UI.Page
{
    //string cmdStr = "";
    public int cp = 0;
    public string[] parameters = new string[5];
    public string[] values = new string[5];
    public string ServerID = "";
    public string DatabaseID = "";
    
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
        ServerID = Request.Form.Get("ctl00$main$Servers1$ServerID");
        DatabaseID = Request.Form.Get("ctl00$main$Databases1$DatabaseID");
    }
    public void get_grids_local(PlaceHolder PlaceHolder1) {
        if (cp > 0)
        {
            SqlParameter[] paramArray = new SqlParameter[cp];
            for (int i = 0; i < cp; i++)
            {
                paramArray[i] = new SqlParameter(parameters[i], values[i]);
            }

            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("nipm_dump_viewer", paramArray, "dataset") as DataSet;

            //int[] StaticGridViews = new int[5];
            //StaticGridViews[0] = 0;
            //StaticGridViews[1] = 1;
            //StaticGridViews[2] = 2;
            //StaticGridViews[3] = 3;
            //StaticGridViews[4] = 4;

            control_utils gu = new control_utils();
            MasterPage MasterPage1 = Page.Master;
            gu.get_grids(ds, PlaceHolder1, null, MasterPage1, false);
        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        bool Made = false;
        //cmdStr = "EXEC nipm_dump_viewer @ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID;
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;

        if (e.Item.Text == "Groups(Sectors)") { Made = true; 
            //cmdStr += ",@IO=14";
            parameters[cp] = "@IO"; values[cp++] = "14";
        }
        if (e.Item.Text == "Stock-Index") { Made = true; 
            //cmdStr += ",@IO=17,@horizDump='" + horizDump.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "17";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        }
        if (e.Item.Text == "Sectors-IPM") { Made = true; 
            //cmdStr += ",@IO=18,@Analysts='" + tbAnalysts.Text + "'";
            parameters[cp] = "@IO"; values[cp++] = "18";
            parameters[cp] = "@Analysts"; values[cp++] = tbAnalysts.Text;
        }
        if (e.Item.Text == "New Stock - by CUSIP") { Made = true; 
            //cmdStr += ",@IO=19,@horizDump='" + horizDump.Text + "',@Flags='CUSIP'"; 
            parameters[cp] = "@IO"; values[cp++] = "19";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
            parameters[cp] = "@Flags"; values[cp++] = "CUSIP";
        }
        if (e.Item.Text == "New Stock - by SEDOL") { Made = true; 
            //cmdStr += ",@IO=19,@horizDump='" + horizDump.Text + "',@Flags='SEDOL'"; 
            parameters[cp] = "@IO"; values[cp++] = "19";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
            parameters[cp] = "@Flags"; values[cp++] = "SEDOL";
        }
        if (e.Item.Text == "for InstDB") { Made = true; 
            //cmdStr += ",@IO=19,@horizDump='" + horizDump.Text + "',@Flags='INSTDB'"; 
            parameters[cp] = "@IO"; values[cp++] = "19";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
            parameters[cp] = "@Flags"; values[cp++] = "INSTDB";
        }
        if (e.Item.Text == "UPDATE InstDBStockID") { Made = true; 
            //cmdStr += ",@IO=22,@horizDump='" + horizDump.Text + "',@DopHorDump='" + tbDopHorDump.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "22";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
            parameters[cp] = "@DopHorDump"; values[cp++] = tbDopHorDump.Text;
        }
        if (e.Item.Text == "Queue By StockID") { Made = true; 
            //cmdStr += ",@IO=24,@horizDump='" + horizDump.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "24";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        }

        //tb_strCmd.Text = cmdStr;
        if (Made == true)
            get_grids_local(PlaceHolder1);
        //get_grids(cmdStr, NIPM_IpmDB_INS);

        //Made=true;
        //switch (e.Item.ValuePath) {
        //    case "New Person/for JPMorgan":{cmdStr += ",@IO=21,@Teams='" + tbTeams.Text + "',@horizDump='" + horizDump.Text + "',@DopHorDump='" + tbDopHorDump.Text+ "'";break;}
        //    default: { tb_strCmd.Text = "NOT USED : "+e.Item.ValuePath; Made = false; break;}
        //}
        //if (Made == true) { tb_strCmd.Text = cmdStr; get_grids(cmdStr, NIPM_IpmDB_INS); }
        //tb_strCmd.Text = e.Item.ValuePath;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (sender.Equals(LinkButton1)) {parameters[cp] = "@IO"; values[cp++] = "1";}
        if (sender.Equals(LinkButton2)) {parameters[cp] = "@IO"; values[cp++] = "2";}
        if (sender.Equals(LinkButton4)) {parameters[cp] = "@IO"; values[cp++] = "4";}
        if (sender.Equals(LinkButton5)) {parameters[cp] = "@IO"; values[cp++] = "5";}
        if (sender.Equals(LinkButton15)){parameters[cp] = "@IO"; values[cp++] = "12";}
        if (sender.Equals(LinkButton9)) { parameters[cp] = "@IO"; values[cp++] = "23"; }
        parameters[cp] = "@ServerID";   values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump";  values[cp++] = horizDump.Text;
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        //cmdStr = "EXEC nipm_dump_viewer @IO=6,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
        parameters[cp] = "@IO"; values[cp++] = "6";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        //cmdStr = "EXEC nipm_dump_viewer @IO=7,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
        parameters[cp] = "@IO"; values[cp++] = "7";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        //cmdStr = "EXEC nipm_dump_viewer @IO=8,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
        parameters[cp] = "@IO"; values[cp++] = "8";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //cmdStr = "EXEC nipm_dump_viewer @ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID;
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;

        if (sender.Equals(LinkButton3)) { 
            //cmdStr += ",@IO=9,@horizDump='" + horizDump.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "9";
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        }
        if (sender.Equals(LinkButton11)) { 
            //cmdStr += ",@IO=10,@Persons='" + tbPersons.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "10";
            parameters[cp] = "@Persons"; values[cp++] = tbPersons.Text;
        }
        if (sender.Equals(LinkButton17)) { 
            //cmdStr += ",@IO=20"; 
            parameters[cp] = "@IO"; values[cp++] = "20";
        }

        if (tbAnalysts.Text != "")
        {
            //cmdStr += ",@Analysts='" + tbAnalysts.Text + "'";
            parameters[cp] = "@Analysts"; values[cp++] = tbAnalysts.Text;
        }
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        //cmdStr = "EXEC nipm_dump_viewer @IO=15,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
        parameters[cp] = "@IO"; values[cp++] = "15";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void lbRatings_Click(object sender, EventArgs e)
    {
        if (sender.Equals(lbRatings)) {
            //cmdStr = "EXEC nipm_dump_viewer @IO=3,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@ServerID"; values[cp++] = ServerID;
            parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        }
        if (sender.Equals(LinkButton12)) {
            //cmdStr = "EXEC nipm_dump_viewer @IO=13,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@ServerID"; values[cp++] = ServerID;
            parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
            parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        }
        if (tbAnalysts.Text != "") {
            //cmdStr += ",@Analysts='" + tbAnalysts.Text + "'";
            parameters[cp] = "@Analysts"; values[cp++] = tbAnalysts.Text;
        }
        if (tbPersons.Text != "") { 
            //cmdStr += ",@Persons='" + tbPersons.Text + "'"; 
            parameters[cp] = "@Persons"; values[cp++] = tbPersons.Text;
        }
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        if ((tbAnalysts.Text != "") || (tbPersons.Text != "") || (horizDump.Text != ""))
        {
            //cmdStr = "EXEC nipm_dump_viewer @IO=11,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID;
            parameters[cp] = "@IO"; values[cp++] = "11";
            parameters[cp] = "@ServerID"; values[cp++] = ServerID;
            parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
            if (tbAnalysts.Text != "")
            {
                //cmdStr += ",@Analysts='" + tbAnalysts.Text + "'";
                parameters[cp] = "@Analysts"; values[cp++] = tbAnalysts.Text;
            }
            if (tbPersons.Text != "") {
                //cmdStr += ",@Persons='" + tbPersons.Text + "'";
                parameters[cp] = "@Persons"; values[cp++] = tbPersons.Text;
            }
            if (horizDump.Text != "") { 
                //cmdStr += ",@horizDump='" + horizDump.Text + "'"; 
                parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
            }
            //tb_strCmd.Text = cmdStr;
            //get_grids(cmdStr, NIPM_IpmDB_INS);
            get_grids_local(PlaceHolder1);
        }
    }
    protected void ddl_analysts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        //cmdStr = "EXEC nipm_dump_viewer @IO=16,@ServerID=" + ServerID + ",@DatabaseID=" + DatabaseID + ",@horizDump='" + horizDump.Text + "'";
        parameters[cp] = "@IO"; values[cp++] = "16";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, NIPM_IpmDB_INS);
        get_grids_local(PlaceHolder1);
    }
    protected void DropDownList2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton18_Click(object sender, EventArgs e)
    {
        parameters[cp] = "@IO"; values[cp++] = "25";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@Analysts"; values[cp++] = tbAnalysts.Text;
        get_grids_local(PlaceHolder1);

    }
    protected void LinkButton19_Click(object sender, EventArgs e)
    {
        parameters[cp] = "@IO"; values[cp++] = "26";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton20_Click(object sender, EventArgs e)
    {
        parameters[cp] = "@IO"; values[cp++] = "27";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        get_grids_local(PlaceHolder1);
    }
    protected void LinkButton21_Click(object sender, EventArgs e)
    {
        parameters[cp] = "@IO"; values[cp++] = "28";
        parameters[cp] = "@ServerID"; values[cp++] = ServerID;
        parameters[cp] = "@DatabaseID"; values[cp++] = DatabaseID;
        parameters[cp] = "@horizDump"; values[cp++] = horizDump.Text;
        get_grids_local(PlaceHolder1);
    }
}
