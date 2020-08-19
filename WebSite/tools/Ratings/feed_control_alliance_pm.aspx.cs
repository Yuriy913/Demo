using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Tools_Ratings_feed_control_alliance_pm : System.Web.UI.Page
{
    //string cmdStr = "";
    public int cp = 0;
    public string[] parameters = new string[5];
    public string[] values = new string[5];

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

    public void get_OldGrids()
    {
        if (cp > 0)
        {
            SqlParameter[] paramArray = new SqlParameter[cp];
            for (int i = 0; i < cp; i++)
            {
                paramArray[i] = new SqlParameter(parameters[i], values[i]);
            }
            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("nipm_load_ratings_ftp_feed_1_2", paramArray, "DataSet") as DataSet;

            //int[] StaticGridViews = new int[5];
            //StaticGridViews[0] = 0;
            //StaticGridViews[1] = 1;
            //StaticGridViews[2] = 2;
            //StaticGridViews[3] = 3;
            //StaticGridViews[4] = 4;

            control_utils gu = new control_utils();
            gu.get_grids(ds, PlaceHolder1, null, Page.Master,false);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if ((tbCloseSecurityID.Text != "") || (tbOpenSecurityID.Text != ""))
        {
            //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=7,@CloseSecurityID='" + tbCloseSecurityID.Text + "',@OpenSecurityID='" + tbOpenSecurityID.Text + "'", NIPM_IpmDB_INS);
            parameters[cp] = "@IO"; values[cp++] = "7";
            parameters[cp] = "@CloseSecurityID"; values[cp++] = tbCloseSecurityID.Text;
            parameters[cp] = "@OpenSecurityID"; values[cp++] = tbOpenSecurityID.Text;
            get_OldGrids();
        }

    }
    protected void ddl_Look_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddl_Look.SelectedIndex)
        {
            case 1: //Look Tables
                {
                    //if (tbSecurityID.Text != "") get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=1,@SecurityID=" + tbSecurityID.Text, NIPM_IpmDB_INS);
                    parameters[cp] = "@IO"; values[cp++] = "1";
                    parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                    get_OldGrids();
                    break;
                }
            case 2: //Look History for 3 Days
                {
                    //if (tbSecurityID.Text != "") get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=20,@SecurityID=" + tbSecurityID.Text, NIPM_IpmDB_INS);
                    parameters[cp] = "@IO"; values[cp++] = "20";
                    parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                    get_OldGrids();
                    break;
                }
            case 3:
                {
                    //if ((tbSecurityID.Text != "") && (tbStockID.Text != ""))
                    //    get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=24,@SecurityID=" + tbSecurityID.Text + ",@StockID=" + tbStockID.Text, NIPM_IpmDB_INS);
                    parameters[cp] = "@IO"; values[cp++] = "24";
                    parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                    parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
                    get_OldGrids();
                    break;
                }
        }
        ddl_Look.SelectedIndex = 0;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //int FP = 0; if (cbFP.Checked) FP = 1;
        //tbCMD.Text = "EXEC nipm_load_ratings_ftp_feed_1_2 
        //@IO=2,
        //@FindText='" + tbFindText.Text + "',
        //@FP=" + FP;

        //parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
        //tbFieldContent1.Text = "";
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=2,@FindText='" + tbFindText.Text + "',@FP=" + FP, NIPM_IpmDB_INS);

        parameters[cp] = "@IO"; values[cp++] = "2";
        parameters[cp] = "@FindText"; values[cp++] = tbFindText.Text;
        parameters[cp] = "@FP"; values[cp++] = "1";
        get_OldGrids();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //int FP = 0; if (cbFP.Checked) FP = 1;
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=3,@FindText='" + tbFindText.Text + "',@FP=" + FP, NIPM_IpmDB_INS);
        parameters[cp] = "@IO"; values[cp++] = "3";
        parameters[cp] = "@FindText"; values[cp++] = tbFindText.Text;
        parameters[cp] = "@FP"; values[cp++] = "1";
        get_OldGrids();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=4,@FindText='" + tbFindText.Text + "'", NIPM_IpmDB_INS);
        parameters[cp] = "@IO"; values[cp++] = "4";
        parameters[cp] = "@FindText"; values[cp++] = tbFindText.Text;
        get_OldGrids();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=5,@FindText='" + tbFindText.Text + "'", NIPM_IpmDB_INS);
        parameters[cp] = "@IO"; values[cp++] = "5";
        parameters[cp] = "@FindText"; values[cp++] = tbFindText.Text;
        get_OldGrids();
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=25,@FindText='" + tbFindText.Text + "'", NIPM_IpmDB_INS);
        parameters[cp] = "@IO"; values[cp++] = "25";
        parameters[cp] = "@FindText"; values[cp++] = tbFindText.Text;
        get_OldGrids();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=6,@RatingID=" + tbRatingID.Text, NIPM_IpmDB_INS);
        parameters[cp] = "@IO"; values[cp++] = "6";
        parameters[cp] = "@RatingID"; values[cp++] = tbRatingID.Text;
        get_OldGrids();
    }
    protected void ddl_CoverageFlags_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddl_CoverageFlags.SelectedIndex)
        {
            case 1: //set NotUse='Y'
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=13,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        //    if (tbCoverageDateEnd.Text != "") { smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; }
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                        parameters[cp] = "@IO"; values[cp++] = "13";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        if (tbCoverageDateEnd.Text != "")
                        {
                            //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'";
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                    }
                    break;
                }
            case 2: //set NotUse=NULL
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=14,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        //    if (tbCoverageDateEnd.Text != "") { smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; }
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                        parameters[cp] = "@IO"; values[cp++] = "14";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        if (tbCoverageDateEnd.Text != "")
                        {
                            //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; 
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                    }
                    break;
                }
            case 3: //set NotDrop='Y'
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != "") && (tbCoverageDateEnd.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=15,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "15";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;

                        if (tbCoverageDateEnd.Text != "") //{ smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; }
                        {
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 4: //set NotDrop=NULL
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != "") && (tbCoverageDateEnd.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=16,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "16";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;

                        if (tbCoverageDateEnd.Text != "") //{ smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; }
                        {
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 5: //set NotRating='Y'
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=17,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "17";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;

                        if (tbCoverageDateEnd.Text != "") //{ smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; }
                        {
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 6: //set NotRating=NULL
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=18,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "18";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        if (tbCoverageDateEnd.Text != "")
                        {
                            //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; 
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 7: //Look Flags coverages
                {
                    if (tbSecurityID.Text != "")
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=22,@SecurityID=" + tbSecurityID.Text;
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                        parameters[cp] = "@IO"; values[cp++] = "22";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        get_OldGrids();
                    }
                    break;
                }
        }
        ddl_CoverageFlags.SelectedIndex = 0;
    }
    protected void  ddl_RatingsFlags_SelectedIndexChanged1(object sender, EventArgs e)
    {
        switch (ddl_RatingsFlags.SelectedIndex)
        {
            case 1: //set NotUse='Y'
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                    //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=9,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "9";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        if (tbCoverageDateEnd.Text != "") { 
                            //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; 
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                    //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 2: //set NotUse=NULL
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=10,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "10";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        if (tbCoverageDateEnd.Text != "") { 
                            //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'"; 
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 3: //set NotDrop='Y'
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=11,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        parameters[cp] = "@IO"; values[cp++] = "11";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        if (tbCoverageDateEnd.Text != "") //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'";
                        {
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                    //    get_grids(smdSQL, NIPM_IpmDB_INS);
                        get_OldGrids();
                    }
                    break;
                }
            case 4: //set NotDrop=NULL
                {
                    if ((tbSecurityID.Text != "") && (tbCoverageDateStart.Text != ""))
                    {
                        parameters[cp] = "@IO"; values[cp++] = "12";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        parameters[cp] = "@CoverageDateStart"; values[cp++] = tbCoverageDateStart.Text;
                        //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=12,@SecurityID=" + tbSecurityID.Text + ",@CoverageDateStart='" + tbCoverageDateStart.Text + "'";
                        if (tbCoverageDateEnd.Text != "") //smdSQL += ",@CoverageDateEnd='" + tbCoverageDateEnd.Text + "'";
                        {
                            parameters[cp] = "@CoverageDateEnd"; values[cp++] = tbCoverageDateEnd.Text;
                        }
                        get_OldGrids();
                        //    get_grids(smdSQL, NIPM_IpmDB_INS);
                    }
                    break;
                }
            case 5: //Look Ratings Flags
                {
                    if (tbSecurityID.Text != "")
                    {
                    //    smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=21,@SecurityID=" + tbSecurityID.Text;
                    //    get_grids(smdSQL, NIPM_IpmDB_INS);
                        parameters[cp] = "@IO"; values[cp++] = "21";
                        parameters[cp] = "@SecurityID"; values[cp++] = tbSecurityID.Text;
                        get_OldGrids();
                    }
                    break;
                }
        }
        //ddl_RatingsFlags.SelectedIndex = 0;
}

    
    protected void Button4_Click1(object sender, EventArgs e)
    {
        //if ((tbPersonID.Text != "") && (tbAnalystCode.Text != ""))
        //    get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=23,@PersonID=" + tbPersonID.Text + ",@FindText='" + tbAnalystCode.Text + "'", NIPM_IpmDB_INS);
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC nipm_load_ratings_ftp_feed_1_2 @IO=8,@FindText='" + tbStockID.Text + "'", NIPM_IpmDB_INS);
        parameters[cp] = "@IO"; values[cp++] = "8";
        parameters[cp] = "@FindText"; values[cp++] = tbStockID.Text;
        get_OldGrids();
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        //smdSQL = "EXEC nipm_load_ratings_ftp_feed_1_2 @IO=19";
        //get_grids(smdSQL, NIPM_IpmDB_INS);

    }
}
