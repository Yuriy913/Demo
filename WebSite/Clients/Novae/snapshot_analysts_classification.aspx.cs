using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class snapshot_analysts_classification : Page
{
    protected string StoredProc = "EXEC Novae_snapshot_analysts_classification_SELECT";
    protected DataSet Ds;

    /// <summary>
    /// Page_PreInit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(Page);
    }

    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        db_utils ndb_utils = new db_utils("altConnectionStringServer142");
        Ds = ndb_utils.get_db_Data(StoredProc, null, "DataSet") as DataSet;
        RefreshGrids();
    }

    /// <summary>
    /// Refresh Grids
    /// </summary>
    protected void RefreshGrids()
    {
        FillGridView(gvTodaysListOfAnalysts, Ds.Tables[0]);
        FillGridView(gvTodaysClassifications, Ds.Tables[1]);
        FillGridView(gvNewAnalysts, Ds.Tables[2]);
        FillGridView(gvRemovedAnalysts, Ds.Tables[3]);
        FillGridView(gvAnalystsWithChangedParameters, Ds.Tables[4]);
        pnlLegend.Visible = Ds.Tables[4].Rows.Count > 0;

        FillGridView(gvNewClassifications, Ds.Tables[5]);
        FillGridView(gvRemovedClassifications, Ds.Tables[6]);
    }

    /// <summary>
    /// Fill GridView
    /// </summary>
    /// <param name="gv"></param>
    /// <param name="dt"></param>
    protected void FillGridView(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    /// <summary>
    /// gvAnalystsWithChangedParameters GridView Row DataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAnalystsWithChangedParameters_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "Show_New").ToString().Trim() != "X")
            {
                e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#F7C1FD");
            }
            if (DataBinder.Eval(e.Row.DataItem, "Calculate_New").ToString().Trim() != "X")
            {
                e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#F7C1FD");
            }
            if (DataBinder.Eval(e.Row.DataItem, "FidelityIRP_New").ToString().Trim() != "X")
            {
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#F7C1FD");
            }
        }
    }
}