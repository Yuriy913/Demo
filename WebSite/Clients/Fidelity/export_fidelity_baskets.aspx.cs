using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class export_fidelity_baskets : Page
{
    protected string StoredProc = "EXEC export_fdl_baskets_select @FirmID={0}, @RatingID={1}, @IndustryID={2}, @RebalancingFrequencyID={3}";
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
    /// Page_Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RefreshDropdowns();
        }
        else
        {
            ltAverageValueOfReturn.Visible = true;
            ltAverageValueOfTurnover.Visible = true;
            ltInsufficientСoverage.Visible = true;
            ltJumpInReturns.Visible = true;
            ltJumpsInTurnovers.Visible = true;
            ltNumberOfComponents.Visible = true;
            ltSnapshotUpdates.Visible = true;

            RefreshStoredProc();
            db_utils ndb_utils = new db_utils("altConnectionStringServer142");
            Ds = ndb_utils.get_db_Data(StoredProc, null, "DataSet") as DataSet;
        }
    }

    /// <summary>
    /// Button Get Data onclick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        RefreshStoredProc();
        RefreshGrids();
    }

    /// <summary>
    /// Refresh Dropdowns
    /// </summary>
    protected void RefreshDropdowns()
    {
        RefreshStoredProc();
        db_utils ndb_utils = new db_utils("altConnectionStringServer142");
        Ds = ndb_utils.get_db_Data(StoredProc, null, "DataSet") as DataSet;

        if (Ds != null && Ds.Tables.Count > 0)
        {
            FillDropDown(ddFirm, Ds.Tables[0], "FirmID", "FirmName", "Selected");
            FillDropDown(ddRating, Ds.Tables[1], "RatingID", "RatingType", "Selected");
            FillDropDown(ddIndustry, Ds.Tables[2], "IndustryID", "IndustryName", "Selected");
            FillDropDown(ddRebalancingFrequency, Ds.Tables[3], "RebalancingFrequencyID", "RebalancingFrequency", "Selected");
        }
    }

    /// <summary>
    /// Refresh Grids
    /// </summary>
    protected void RefreshGrids()
    {
        ltInsufficientСoverage.Text = Ds.Tables[5].Rows.Count > 0 ? "<font color='red'><b>Table with changes in flags of insufficient coverage:</b></font>" : "Table with changes in flags of insufficient coverage:";

        FillGridView(gvSnapshotUpdates, Ds.Tables[4]);
        FillGridView(gvInsufficientСoverage, Ds.Tables[5]);
        FillGridView(gvNumberOfComponents, Ds.Tables[6]);
        FillGridView(gvJumpInReturns, Ds.Tables[7]);
        FillGridView(gvAverageValueOfReturn, Ds.Tables[8]);
        FillGridView(gvJumpsInTurnovers, Ds.Tables[9]);
        FillGridView(gvAverageValueOfTurnover, Ds.Tables[10]);
    }

    protected void FillGridView(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void RefreshStoredProc()
    {
        StoredProc = string.Format(StoredProc, ddFirm.SelectedValue == "" ? "0" : ddFirm.SelectedValue, ddRating.SelectedValue == "" ? "0" : ddRating.SelectedValue, ddIndustry.SelectedValue == "" ? "0" : ddIndustry.SelectedValue, ddRebalancingFrequency.SelectedValue == "" ? "0" : ddRebalancingFrequency.SelectedValue);
    }

    /// <summary>
    /// Fill DropDown
    /// </summary>
    /// <param name="DropDown"></param>
    /// <param name="dt"></param>
    /// <param name="DataValueField"></param>
    /// <param name="DataTextField"></param>
    /// <param name="SelectedField"></param>
    protected void FillDropDown(DropDownList DropDown, DataTable dt, string DataValueField, string DataTextField, string SelectedField)
    {
        DropDown.DataSource = dt;
        DropDown.DataValueField = DataValueField;
        DropDown.DataTextField = DataTextField;
        DropDown.DataBind();

        foreach (DataRow row in dt.Rows)
        {
            bool selected = row["Selected"].ToString() == "Y";
            if (selected)
            {
                DropDown.SelectedValue = row[DataValueField].ToString();
            }
        }
    }

    /// <summary>
    /// gvNumberOfComponents GridView Row DataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNumberOfComponents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NumberOfComponents_PREV"))) > 5 && Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NumberOfComponents_NEXT")) == 0)
            {
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5353");
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5353"); 
            }
        }
    }

    /// <summary>
    /// gvJumpInReturns GridView Row DataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvJumpInReturns_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_OneYearReturn"))) > 10)
            {
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_TwoYearReturn"))) > 10)
            {
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_ThreeYearReturn"))) > 10)
            {
                e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }
        }
    }

    /// <summary>
    /// gvAverageValueOfReturn GridView Row DataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAverageValueOfReturn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_OneYearReturnIndustry"))) > 20)
            {
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_TwoYearReturnIndustry"))) > 20)
            {
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_ThreeYearReturnIndustry"))) > 20)
            {
                e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }
        }
    }

    /// <summary>
    /// gvJumpsInTurnovers GridView Row DataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvJumpsInTurnovers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_OneYearTurnover"))) > 10)
            {
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_TwoYearTurnover"))) > 10)
            {
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_ThreeYearTurnover"))) > 10)
            {
                e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }
        }
    }

    /// <summary>
    /// gvAverageValueOfTurnover GridView Row DataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAverageValueOfTurnover_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_OneYearTurnoverIndustry"))) > 20)
            {
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_TwoYearTurnoverIndustry"))) > 20)
            {
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }

            if (Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jump_ThreeYearTurnoverIndustry"))) > 20)
            {
                e.Row.Cells[11].BackColor =  System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
                e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#9999CC");
            }
        }
    }

   
}