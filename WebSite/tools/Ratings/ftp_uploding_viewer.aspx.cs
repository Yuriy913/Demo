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


public partial class Tools_Ratings_ftp_uploding_viewer : System.Web.UI.Page
{
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
    public void get_Grids()
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
            ds = du.get_db_Data("ipm_rdsftp_uploading_viewer", paramArray, "DataSet") as DataSet;

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
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        //*
        //bool Made = false;
        //tbTest.Text = e.Item.ValuePath;
        //AdminFTP
        if (e.Item.ValuePath == "AdminFTP/By ID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=4,@ID=" + tbID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "4";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
        }
        if (e.Item.ValuePath == "AdminFTP/By ID/SET Show/Yes") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=4,@SubIO=2,@ID=" + tbID.Text + ",@Flag='Y'"; 
            parameters[cp] = "@IO"; values[cp++] = "4";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "Y";
        }
        if (e.Item.ValuePath == "AdminFTP/By ID/SET Show/No") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=4,@SubIO=2,@ID=" + tbID.Text + ",@Flag='N'"; 
            parameters[cp] = "@IO"; values[cp++] = "4";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "N";
        }

        //Brokers
        if (e.Item.ValuePath == "Brokers/By AnalystID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=1,@AnalystID=" + tbAnalystID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@AnalystID"; values[cp++] = tbAnalystID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Brokers/By ID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=2,@ID=" + tbID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_TypeOfDelay/Work Days") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=3,@ID=" + tbID.Text + ",@Flag='wd'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "wd";
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_TypeOfDelay/Daily") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=3,@ID=" + tbID.Text + ",@Flag='d'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "d";
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_TypeOfDelay/Weekly") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=3,@ID=" + tbID.Text + ",@Flag='w'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "w";
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_TypeOfDelay/Two Weekly") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=3,@ID=" + tbID.Text + ",@Flag='2w'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "2w";
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_TypeOfDelay/Monthly") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=3,@ID=" + tbID.Text + ",@Flag='m'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "m";
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_AlertToEmails") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=4,@ID=" + tbID.Text + ",@String1='" + tbString1.Text + "',@String2='" + tbString2.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "4";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@String1"; values[cp++] = tbString1.Text;
            parameters[cp] = "@String2"; values[cp++] = tbString2.Text;
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_DisableStatBorderTime/Yes") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=5,@ID=" + tbID.Text + ",@Flag='Y'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "5";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "Y";
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_DisableStatBorderTime/No") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=5,@ID=" + tbID.Text + ",@Flag='N'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "5";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "N";
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;        
        }
        if (e.Item.ValuePath == "Brokers/By ID/SET DWS_LastAlert") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=15,@SubIO=6,@ID=" + tbID.Text + ",@FieldContent_1='" + tbString1.Text + "'"; 
            parameters[cp] = "@IO"; values[cp++] = "15";
            parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@FieldContent_1"; values[cp++] = tbString1.Text;
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;       
        }

        //Analysts
        if (e.Item.ValuePath == "Analysts/by DWS") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=8"; 
            parameters[cp] = "@IO"; values[cp++] = "8";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            //parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@FieldContent_1"; values[cp++] = tbString1.Text;
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;       
        }

        //Files
        if (e.Item.ValuePath == "Files/File/SET UserFlag=Y") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=9,@FileID=" + tbFileID.Text + ",@Flag='Y'"; 
            parameters[cp] = "@IO"; values[cp++] = "9";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "Y";
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;       
        }
        if (e.Item.ValuePath == "Files/File/SET UserFlag=N") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=9,@FileID=" + tbFileID.Text + ",@Flag='N'"; 
            parameters[cp] = "@IO"; values[cp++] = "9";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "N";
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;       
        }
        if (e.Item.ValuePath == "Files/File/SET UserFlag=W") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=9,@FileID=" + tbFileID.Text + ",@Flag='W'"; 
            parameters[cp] = "@IO"; values[cp++] = "9";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "W";
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;               
        }
        if (e.Item.ValuePath == "Files/File/SET UserFlag=D") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=9,@FileID=" + tbFileID.Text + ",@Flag='D'"; 
            parameters[cp] = "@IO"; values[cp++] = "9";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "D";
            //parameters[cp] = "@String2"; values[cp++] = tbString2.Text;               
        }
        if (e.Item.ValuePath == "Files/File/SET UserFlag=T") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=9,@FileID=" + tbFileID.Text + ",@Flag='T'"; 
            parameters[cp] = "@IO"; values[cp++] = "9";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "T";
        }
        if (e.Item.ValuePath == "Files/Not Loaded") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=2"; 
            parameters[cp] = "@IO"; values[cp++] = "2";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            //parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "T";
        }
        if (e.Item.ValuePath == "Files/Recompare by FileID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=12,@FileID=" + tbFileID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "12";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "T";
        }
        if (e.Item.ValuePath == "Files/FileDone/Look by FileID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=14,@FileID=" + tbFileID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "14";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "T";
        }
        if (e.Item.ValuePath == "Files/FileDone/SET ExecAddRatingsDone=Y") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=14,@FileID=" + tbFileID.Text + ",@Flag='Y'"; 
            parameters[cp] = "@IO"; values[cp++] = "14";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "Y";
        }
        if (e.Item.ValuePath == "Files/FileDone/SET ExecAddRatingsDone=N") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=14,@FileID=" + tbFileID.Text + ",@Flag='N'"; 
            parameters[cp] = "@IO"; values[cp++] = "14";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Files/FileDone/SET ExecAddRatingsDone=Y by FileID and RuleID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=14,@FileID=" + tbFileID.Text + ",@RuleID=" + tbRuleID.Text + ",@Flag='Y'"; 
            parameters[cp] = "@IO"; values[cp++] = "14";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@RuleID"; values[cp++] = tbRuleID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "Y";
        }
        if (e.Item.ValuePath == "Files/FileDone/SET ExecAddRatingsDone=N by FileID and RuleID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=14,@FileID=" + tbFileID.Text + ",@RuleID=" + tbRuleID.Text + ",@Flag='N'";
            parameters[cp] = "@IO"; values[cp++] = "14";
            //parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@RuleID"; values[cp++] = tbRuleID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Files/Full Reload BY FileID,RuleID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=18,@SubIO=1,@FileID=" + tbFileID.Text + ",@RuleID=" + tbRuleID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "18";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@RuleID"; values[cp++] = tbRuleID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Files/by AnalystID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=18,@SubIO=2,@AnalystID=" + tbAnalystID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "18";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@AnalystID"; values[cp++] = tbAnalystID.Text;
            //parameters[cp] = "@RuleID"; values[cp++] = tbRuleID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Files/by AnalystID/All") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=18,@SubIO=3,@AnalystID=" + tbAnalystID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "18";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@AnalystID"; values[cp++] = tbAnalystID.Text;
            //parameters[cp] = "@RuleID"; values[cp++] = tbRuleID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }


        //Errors
        if (e.Item.ValuePath == "Errors/by FileID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=5,@SubIO=1,@FileID=" + tbFileID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "5";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            //parameters[cp] = "@RuleID"; values[cp++] = tbRuleID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Errors/by FileID/with ErrorID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=5,@SubIO=1,@FileID=" + tbFileID.Text + ",@ErrorID=" + tbErrorID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "5";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Errors/Grouped by FileID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=5,@SubIO=2,@FileID=" + tbFileID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "5";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            //parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }

        //Rules
        if (e.Item.ValuePath == "Rules/by AnalystID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=3,@AnalystID=" + tbAnalystID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "3";
            //parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@AnalystID"; values[cp++] = tbAnalystID.Text;
            //parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Rules/Enable/by ID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=10,@ID=" + tbID.Text + ",@Flag='N'"; 
            parameters[cp] = "@IO"; values[cp++] = "10";
            //parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "N";
        }
        if (e.Item.ValuePath == "Rules/Disable/by ID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=10,@ID=" + tbID.Text + ",@Flag='Y'"; 
            parameters[cp] = "@IO"; values[cp++] = "10";
            //parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "Y";
        }

        //Ratings
        if (e.Item.ValuePath == "Ratings/Statistics/for AnalystID by TimeAdded") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=6,@AnalystID=" + tbAnalystID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "6";
            //parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@AnalystID"; values[cp++] = tbAnalystID.Text;
            //parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "Y";
        }
        if (e.Item.ValuePath == "Ratings/By FileID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=17,@SubIO=1,@FileID=" + tbFileID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "6";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FileID"; values[cp++] = tbFileID.Text;
            //parameters[cp] = "@ErrorID"; values[cp++] = tbErrorID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "Y";
        }
        if (e.Item.ValuePath == "Ratings/SET StockID by ID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=17,@SubIO=2,@ID=" + tbID.Text + ",@StockID=" + tbStockID.Text; 
            parameters[cp] = "@IO"; values[cp++] = "17";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "Y";
        }
        if (e.Item.ValuePath == "Ratings/Moved=I by ID") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=17,@SubIO=3,@ID=" + tbID.Text + ",@Flag='I'"; 
            parameters[cp] = "@IO"; values[cp++] = "17";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
            parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
            parameters[cp] = "@Flag"; values[cp++] = "I";
        }


        //Job
        if (e.Item.ValuePath == "Job/Last Processed") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=4"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "4";
            //parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "I";
        }
        if (e.Item.ValuePath == "Job/Last Processed/By CountStarts") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=9"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "9";
            //parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "I";
        }
        if (e.Item.ValuePath == "Job/Status") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=1";
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            //parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "I";
        }
        if (e.Item.ValuePath == "Job/Server Time") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=8"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "8";
            //parameters[cp] = "@ID"; values[cp++] = tbID.Text;
            //parameters[cp] = "@StockID"; values[cp++] = tbStockID.Text;
            //parameters[cp] = "@Flag"; values[cp++] = "I";
        }
        if (e.Item.ValuePath == "Job/Moved Start") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=5"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "5";
        }
        if (e.Item.ValuePath == "Job/Start") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=2"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
        }
        if (e.Item.ValuePath == "Job/Stop") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=3"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "3";
        }
        if (e.Item.ValuePath == "Job/Disable") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=6"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "6";
        }
        if (e.Item.ValuePath == "Job/Enable") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=7"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "7";
        }
        if (e.Item.ValuePath == "Job/Start (Long Times)") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=10"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "10";
        }
        if (e.Item.ValuePath == "Job/Stop (Long Times)") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=11"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "11";
        }
        if (e.Item.ValuePath == "Job/Disable (Long Times)") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=12"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "12";
        }
        if (e.Item.ValuePath == "Job/Enable (Long Times)") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=13"; 
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "13";
        }
        if (e.Item.ValuePath == "Job/Job Global Temp Tables") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=13,@ID=14";
            parameters[cp] = "@IO"; values[cp++] = "13";
            parameters[cp] = "@SubIO"; values[cp++] = "14";
        }

        //Alert
        if (e.Item.ValuePath == "Alert/Summary") { 
            //Made = true; cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=16,@SubIO=1"; 
            parameters[cp] = "@IO"; values[cp++] = "16";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
        }

        //tb_strCmd.Text = cmdStr;
        //if (Made == true) get_grids(cmdStr, srv141_InvestarsDB);
        //*/
        if (cp > 0) get_Grids();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (sender.Equals(LinkButton1)) 
        {
            //cmdStr = "EXEC ipm_rdsftp_uploading_viewer @IO=1";
            parameters[cp] = "@IO"; values[cp++] = "1";
            //parameters[cp] = "@SubIO"; values[cp++] = "1";
        }

        //tb_strCmd.Text = cmdStr;
        //if (Made == true) get_grids(cmdStr, srv141_InvestarsDB);
        //*/
        if (cp > 0) get_Grids();

        //tb_strCmd.Text = cmdStr;
        //get_grids(cmdStr, srv141_InvestarsDB);
    }
}
