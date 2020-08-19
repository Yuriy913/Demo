using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//------------------------------
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;


public partial class Tools_MultiFunc_Pages_DumpLoader : System.Web.UI.Page
{
    #region MasterPages
        private string pathToMasterPage1 = "~/support_team.master";
        private string pathToMasterPage2 = "~/MyPage.master";
    #endregion 

    #region Variables
        static string Menu_Item_ValuePath = "";
        db_utils du = new db_utils("mainConnectionString");
        char[] rowDelim = { '\r' };
        string[] Rows;
        char[] colDelim = { '\t' };
        string[] Columns;
        string[,] pv; //можно пользовать что нить типа HashTable
        string[] Fields;
        int countInserted = 0, rowIndex = -1, colCount = -1;
        SqlParameter[] paramArray = null; 
    #endregion


    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Server.MachineName == "YURY")
            Page.MasterPageFile = pathToMasterPage2;
        else
            Page.MasterPageFile = pathToMasterPage1;

        if (!(
              (Server.MachineName == "YURY") &&
                  ((Page.MasterPageFile == "/SUPPORT/MyPage.master") ||
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
        //TextBox2.Text = dbu1.get_db_ConnectionString();
        //dbu1 = new db_utils(mainConnectionString);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {   
        Menu_Item_ValuePath = e.Item.ValuePath;
        lMenuPath.Text = Menu_Item_ValuePath;
        e.Item.Selected = true;
        switch (Menu_Item_ValuePath)
        {
            case "Quotes/Prices":
                //Literal1.Text = "StockID  Date  CloseAt [ OpenAt [ Volume [ MarketCap]]]";
                lFields.Text = "StockID  Date  CloseAt [ OpenAt [ Volume [ MarketCap]]]";
                break;
            case "Quotes/Dividends":
                //Literal1.Text = "StockID  Date  Dividend";
                lFields.Text = "StockID  Date  Dividend";
                break;
        }
        TextBox1.Enabled = true;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Rows = (TextBox1.Text.Trim()).Split(rowDelim);
        foreach (string row in Rows)
        {   
            rowIndex++; 
            Columns = (row.Trim()).Split(colDelim);
            if (Columns.Length > 0)
            {
                if (rowIndex == 0)
                {
                    pv = new string[Columns.Length+1, 2];
                    switch (Menu_Item_ValuePath)
                    {   
                        case "Quotes/Prices":
                            Fields = new string[] { "IO", "StockID", "Date", "CloseAt", "OpenAt", "Volume", "MarketCap" };
                            pv[0, 1] = "1"; break;
                        case "Quotes/Dividends":
                            Fields = new string[] { "IO", "StockID", "Date", "Dividend"};
                            pv[0, 1] = "2"; break; // ??? 
                    }
                    for (int i = 0; i <= Columns.Length; i++)
                        pv[i, 0] = Fields[i]; 
                }
                for (int i = 1; i <= Columns.Length; i++)
                    pv[i, 1] = Columns[i-1];
                if (rowIndex == 0)
                    paramArray = new SqlParameter[Columns.Length+1];
                for (int i = 0; i <= Columns.Length; i++)
                    if (rowIndex == 0)
                        paramArray[i] = new SqlParameter(pv[i, 0], pv[i, 1]);
                    else 
                        if (i > 0)
                            paramArray[i].Value = pv[i, 1];
                if (rowIndex == 0)
                    countInserted += (int)du.get_db_Data("DumpLoader", paramArray, "nonquery");
                else 
                    countInserted += (int)du.get_db_Data("DumpLoader", null, "nonquery");
            }
        }
        if (countInserted > 0) TextBox1.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

    }
}