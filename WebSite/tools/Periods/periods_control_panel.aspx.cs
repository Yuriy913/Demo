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

public partial class Tools_Periods_periods_control_panel : System.Web.UI.Page
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

    public void getGrids(bool OneLine)
    {
        if (cp > 0)
        {
            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("periods_control_panel", paramArray, "DataSet") as DataSet;
            //SqlDataSource1. = ds.Tables[0].DefaultView;
            GridView1.DataSource=ds.Tables[0].DefaultView;
            GridView1.DataBind();
            //control_utils gu = new control_utils();
            //MasterPage MasterPage1 = Page.Master; //придержать
            //gu.get_grids(ds, PlaceHolder1, null, Page.Master);
            //gu.get_grids(ds, PlaceHolder1, OneLine);
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteID.Items.Add(new ListItem("0.INVESTARS", "0"));
            SiteID.Items.Add(new ListItem("1.PM", "1"));
            SiteID.Items.Add(new ListItem("2.DIPM,IPM", "2"));
            SiteID.Items.Add(new ListItem("3.FL,DFL", "3"));
            fillAnalysts();
        }
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=12,@PeriodID=" + PeriodID.Text;
        //SqlDataSource1.SelectCommand = sqlStr;
        paramArray[cp++] = new SqlParameter("@IO", "12");
        paramArray[cp++] = new SqlParameter("@PeriodID", PeriodID.Text);
        getGrids(false);

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=5,@PeriodID=" + PeriodID.Text;
        //sqlStr = sqlStr + ",@SiteID=" + SiteID.Text + ",@AnalystID=" + AnalystID.Text;
        //if (UserID.Text != "") { sqlStr = sqlStr + ",@UserID=" + UserID.Text; };
        //SqlDataSource1.SelectCommand = sqlStr;
        paramArray[cp++] = new SqlParameter("@IO", "5");
        paramArray[cp++] = new SqlParameter("@PeriodID", PeriodID.Text);
        paramArray[cp++] = new SqlParameter("@SiteID", SiteID.Text);
        paramArray[cp++] = new SqlParameter("@AnalystID", AnalystID.Text);
        if (UserID.Text != "") { paramArray[cp++] = new SqlParameter("@UserID", UserID.Text); };
        getGrids(false);

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=9,@PeriodID=" + PeriodID.Text;
        //sqlStr = sqlStr + ",@SiteID=" + SiteID.Text + ",@AnalystID=" + AnalystID.Text;
        //if (UserID.Text != "") { sqlStr = sqlStr + ",@UserID=" + UserID.Text; };
        //SqlDataSource1.SelectCommand = sqlStr;
        //Memo1.Text = sqlStr;
        paramArray[cp++] = new SqlParameter("@IO", "9");
        paramArray[cp++] = new SqlParameter("@PeriodID", PeriodID.Text);
        paramArray[cp++] = new SqlParameter("@SiteID", SiteID.Text);
        paramArray[cp++] = new SqlParameter("@AnalystID", AnalystID.Text);
        if (UserID.Text != "") { paramArray[cp++] = new SqlParameter("@UserID", UserID.Text); };
        getGrids(false);

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //string sqlStr = "";
        if (PeriodID.Text == "")
        {
            //sqlStr = "EXEC nipm_edit_periods @ModeIO=7,@PeriodID=NULL";
            paramArray[cp++] = new SqlParameter("@IO", "7");
            paramArray[cp++] = new SqlParameter("@PeriodID",null);
        }
        else
        {
            //sqlStr = "EXEC nipm_edit_periods @ModeIO=6,@PeriodID=" + PeriodID.Text;
            paramArray[cp++] = new SqlParameter("@IO", "6");
            paramArray[cp++] = new SqlParameter("@PeriodID", PeriodID.Text);
        }
        //SqlDataSource1.SelectCommand = sqlStr;
        getGrids(false);

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=10,@PeriodID=" + PeriodID.Text;
        //SqlDataSource1.SelectCommand = sqlStr;
        paramArray[cp++] = new SqlParameter("@IO", "10");
        paramArray[cp++] = new SqlParameter("@PeriodID", PeriodID.Text);
        getGrids(false);
    }
    protected void SiteID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillAnalysts();
    }

    private void fillAnalysts()
    {
        AnalystID.Items.Clear();
        switch (SiteID.SelectedItem.Value)
        {
            case "0":
                {
                    AnalystID.Items.Add(new ListItem("0.All", "0"));
                    AnalystID.Items.Add(new ListItem("744.JPMorgan", "744"));
                    break;
                }
            case "1":
                {
                    AnalystID.Items.Add(new ListItem("0.All", "0"));
                    AnalystID.Items.Add(new ListItem("1.JPMorgan", "1"));
                    AnalystID.Items.Add(new ListItem("2.Alliance Cap.", "2"));
                    AnalystID.Items.Add(new ListItem("42.Alliance Cap.UK", "42"));
                    AnalystID.Items.Add(new ListItem("46.JP Morgan [Bernstain US]", "46"));
                    break;
                }
            case "2":
                {
                    AnalystID.Items.Add(new ListItem("0.All", "0"));
                    AnalystID.Items.Add(new ListItem("20.Alliance EM", "20"));
                    AnalystID.Items.Add(new ListItem("21.Alliance China", "21"));
                    AnalystID.Items.Add(new ListItem("23.Renaissance Cap.", "23"));
                    break;
                }
            case "3":
                {
                    AnalystID.Items.Add(new ListItem("0.All", "0"));
                    AnalystID.Items.Add(new ListItem("21.JPMorgan FL", "21"));
                    break;
                }
        }
    }
    protected void AnalystID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=2,@SiteID=" + SiteID.Text + ",@AnalystID=" + AnalystID.Text;
        paramArray[cp++] = new SqlParameter("@IO", "2");
        paramArray[cp++] = new SqlParameter("@SiteID", SiteID.Text);
        paramArray[cp++] = new SqlParameter("@AnalystID", AnalystID.Text);

        //if (UserID.Text != "") { sqlStr = sqlStr + ",@UserID=" + UserID.Text; }
        if (UserID.Text != "") paramArray[cp++] = new SqlParameter("@UserID", UserID.Text);

        //sqlStr = sqlStr + " ORDER BY "+SORT.Text;
        //SqlDataSource1.SelectCommand = sqlStr;
        //TextBox1.Text = sqlStr;
        getGrids(false);
    }
    protected void SORT_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.SelectCommand = "EXEC nipm_edit_periods @ModeIO=3,@SiteID=" + SiteID.Text + ",@AnalystID=" + AnalystID.Text;
        paramArray[cp++] = new SqlParameter("@IO", "3");
        paramArray[cp++] = new SqlParameter("@SiteID", SiteID.Text);
        paramArray[cp++] = new SqlParameter("@AnalystID", AnalystID.Text);
        getGrids(false);

    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=11,@PeriodID=" + PeriodID.Text + ",@StartDate='" + StartDate.Text + "'";
        //SqlDataSource1.SelectCommand = sqlStr;
        paramArray[cp++] = new SqlParameter("@IO", "11");
        paramArray[cp++] = new SqlParameter("@PeriodID", PeriodID.Text);
        paramArray[cp++] = new SqlParameter("@StartDate", StartDate.Text);
        getGrids(false);

    }
    protected void addPeriod_Click(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=4,@Label='" + Label.Text + "',@StartDate='" + StartDate.Text + "'";
        paramArray[cp++] = new SqlParameter("@IO", "4");
        paramArray[cp++] = new SqlParameter("@Label", Label.Text);
        paramArray[cp++] = new SqlParameter("@StartDate", StartDate.Text);

        //if (EndDate.Text != "") sqlStr = sqlStr + ",@EndDate='" + EndDate.Text + "'";
        if (EndDate.Text != "") paramArray[cp++] = new SqlParameter("@EndDate", EndDate.Text);

        //if (StartMonths.Text != "") { sqlStr = sqlStr + ",@StartMonths=" + StartMonths.Text; }
        if (StartMonths.Text != "") paramArray[cp++] = new SqlParameter("@StartMonths", StartMonths.Text);

        if (cbAutoBind.Checked)
        {
            //sqlStr = sqlStr + ",@AutoBind=1,@SiteID=" + SiteID.Text + ",@AnalystID=" + AnalystID.Text;
            paramArray[cp++] = new SqlParameter("@AutoBind", 1);
            paramArray[cp++] = new SqlParameter("@SiteID", SiteID.Text);
            paramArray[cp++] = new SqlParameter("@AnalystID", AnalystID.Text);            

            //if (UserID.Text != "") { sqlStr = sqlStr + ",@UserID=" + UserID.Text; };
            if (UserID.Text != "") paramArray[cp++] = new SqlParameter("@UserID", UserID.Text);

        }
        //SqlDataSource1.SelectCommand = sqlStr;
        //Memo1.Text = sqlStr;
        getGrids(false);
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        //string sqlStr = "EXEC nipm_edit_periods @ModeIO=8";
        paramArray[cp++] = new SqlParameter("@IO", "8");

        //if (Label.Text != "") { sqlStr = sqlStr + ",@Label='" + Label.Text + "'"; }
        if (Label.Text != "") paramArray[cp++] = new SqlParameter("@Label", Label.Text);

        //if (StartDate.Text != "") { sqlStr = sqlStr + ",@StartDate='" + StartDate.Text + "'"; }
        if (StartDate.Text != "") paramArray[cp++] = new SqlParameter("@StartDate", StartDate.Text);

        //if (EndDate.Text != "") { sqlStr = sqlStr + ",@EndDate='" + EndDate.Text + "'"; }
        if (EndDate.Text != "") paramArray[cp++] = new SqlParameter("@EndDate", EndDate.Text);

        //if (StartMonths.Text != "") { sqlStr = sqlStr + ",@StartMonths='" + StartMonths.Text + "'"; }
        if (StartMonths.Text != "") paramArray[cp++] = new SqlParameter("@StartMonths", StartMonths.Text);
        //SqlDataSource1.SelectCommand = sqlStr;
        getGrids(false);

    }
}
