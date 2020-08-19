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

public partial class Tools_Quotes_Quotes_Dividends_Editor_New : System.Web.UI.Page
{
    public string cmdStr = "";
    SqlParameter[] paramArray = new SqlParameter[100];
    int cp = 0;

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (!
             (
               (Server.MachineName == "YURY") &&
                 (
                   (Page.MasterPageFile == "/SUPPORT/MyPage.master") ||
                   (Page.MasterPageFile == "/investars.support/MyPage.master")
                 )
              )
            )
        {
            site_utils PageAttr = new site_utils();
            PageAttr.setPageAttr(this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void getGrids(bool OneLine)
    {
        if (cp > 0)
        {
            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("InstDB_manual_dividends", paramArray, "DataSet") as DataSet;
            control_utils gu = new control_utils();
            //MasterPage MasterPage1 = Page.Master; //придержать
            //gu.get_grids(ds, PlaceHolder1, null, Page.Master);
            gu.get_grids(ds, PlaceHolder1, OneLine);
        }

    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=13,@StockID=" + tbStockID.Text, NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "13");
        paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
        getGrids(false);
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=14,@StockID=" + tbStockID.Text, NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "14");
        paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
        getGrids(false);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=1,@StockID=" + tbStockID.Text, NIPM_IpmDB_INS, 1, 0);
        paramArray[cp++] = new SqlParameter("@IO", "1");
        paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
        getGrids(true);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void ddl_Update_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlVerifyCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button8_Click(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=4", NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "4");
        getGrids(false);

    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=20", NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "20");
        getGrids(false);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if ((tbNewDividend.Text != "") && (tbStockID.Text != "") && (tbDate.Text != ""))
        {//stop
            //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=6,@StockID=" + tbStockID.Text + ",@Date='" + tbDate.Text + "'
            //,@NewDividend=" + tbNewDividend.Text + ",@DB='Q'", NIPM_IpmDB_INS, 0, -1);
            paramArray[cp++] = new SqlParameter("@IO", "6");
            paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
            paramArray[cp++] = new SqlParameter("@Date", tbDate.Text);
            paramArray[cp++] = new SqlParameter("@NewDividend", tbNewDividend.Text);
            paramArray[cp++] = new SqlParameter("@DB", "Q");
            getGrids(false);
            tbNewDividend.Text = "";
            tbDate.Text = "";
        }

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if ((tbNewDividend.Text != "") && (tbStockID.Text != "") && (tbDate.Text != ""))
        {
            //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=6,@StockID=" + tbStockID.Text + "
            //,@Date='" + tbDate.Text + "',@NewDividend=" + tbNewDividend.Text + ",@DB='I'", NIPM_IpmDB_INS, 0, -1);
            paramArray[cp++] = new SqlParameter("@IO", "6");
            paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
            paramArray[cp++] = new SqlParameter("@Date", tbDate.Text);
            paramArray[cp++] = new SqlParameter("@NewDividend", tbNewDividend.Text);
            paramArray[cp++] = new SqlParameter("@DB", "I");
            getGrids(false);
            tbNewDividend.Text = "";
            tbDate.Text = "";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if ((tbNewDividend.Text != "") && (tbStockID.Text != "") && (tbDate.Text != ""))
        {
            //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=15,@StockID=" + tbStockID.Text + "
            //,@Date='" + tbDate.Text + "',@NewDividend=" + tbNewDividend.Text, NIPM_IpmDB_INS, 0, -1);
            paramArray[cp++] = new SqlParameter("@IO", "15");
            paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
            paramArray[cp++] = new SqlParameter("@Date", tbDate.Text);
            paramArray[cp++] = new SqlParameter("@NewDividend", tbNewDividend.Text);
            getGrids(false);
            tbNewDividend.Text = "";
        }

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
      //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=11,@ID=" + tbID.Text, NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "11");
        paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
        getGrids(false);

    }
    protected void Button10_Click(object sender, EventArgs e)
    {
       // get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=9,@ID=" + tbID.Text, NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "9");
        paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
        getGrids(false);

    }
    protected void Button9_Click(object sender, EventArgs e)
    {
      //  get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=8,@ID=" + tbID.Text, NIPM_IpmDB_INS, 0, -1);
        paramArray[cp++] = new SqlParameter("@IO", "8");
        paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
        getGrids(false);

    }
    protected void ddl_setOper_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddl_setOper.SelectedIndex)
        {
            case 1:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=10,@ID=" + tbID.Text + ",@Oper='I'", NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "10");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@Oper","I");
                    getGrids(false);
                    break;
                }
            case 2:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=10,@ID=" + tbID.Text + ",@Oper='U'", NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "10");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@Oper", "U");
                    getGrids(false);
                    break;
                }
            case 3:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=10,@ID=" + tbID.Text + ",@Oper='D'", NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "10");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@Oper", "D");
                    getGrids(false);
                    break;
                }
            case 4:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=12,@ID=" + tbID.Text + ",@NewDividend=" + tbNewDividend.Text, NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "12");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@NewDividend", tbNewDividend.Text);
                    getGrids(false);
                    break;
                }
            case 5:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=16,@ID=" + tbID.Text + ",@CRC_Factor=" + tbCRC_Factor.Text, NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "16");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@CRC_Factor", tbCRC_Factor.Text);
                    getGrids(false);
                    break;
                }
            case 6:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=18,@StockID=" + tbStockID.Text + ",@Date='" + tbDate.Text + "'", NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "18");
                    paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
                    paramArray[cp++] = new SqlParameter("@Date", tbDate.Text);
                    getGrids(false);
                    break;
                }
            case 7:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=19,@ID=" + tbID.Text + ",@OldDividend=" + tbOldDividend.Text, NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "18");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@OldDividend", tbOldDividend.Text);
                    getGrids(false);
                    break;
                }
            case 8:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=21,@StockID=" + tbStockID.Text, NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "21");
                    paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
                    getGrids(false);
                    break;
                }
            case 9:
                {
                    //get_grids("EXEC IpmDB_INS..nipm_dividends_work @IO=10,@ID=" + tbID.Text + ",@Oper='P'", NIPM_IpmDB_INS, 0, -1);
                    paramArray[cp++] = new SqlParameter("@IO", "10");
                    paramArray[cp++] = new SqlParameter("@ID", tbID.Text);
                    paramArray[cp++] = new SqlParameter("@Oper", "P");
                    getGrids(false);
                    break;
                }
        }
        ddl_setOper.SelectedIndex = 0;
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if ((tbStockID.Text!="") &&(tbDate.Text!=""))
        {
            paramArray[cp++] = new SqlParameter("@IO", "22");
            paramArray[cp++] = new SqlParameter("@StockID", tbStockID.Text);
            paramArray[cp++] = new SqlParameter("@Date", tbDate.Text);
            getGrids(true);
        }
    }
    protected void Button5_Click1(object sender, EventArgs e)
    {
        paramArray[cp++] = new SqlParameter("@IO", "23");
        getGrids(true);
    }
}
