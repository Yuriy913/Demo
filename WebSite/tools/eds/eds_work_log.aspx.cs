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

public partial class tools_eds_work_log : System.Web.UI.Page
{

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(this.Page);
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StartDate.setDate(DateTime.Now.AddDays(-5));
            EndDate.setDate(DateTime.Now);
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        
        StartDate.setName("From: ");
        EndDate.setName(" To: ");

        work_log_grid.PageSize = Convert.ToInt32(show_rows_on_page1.getSelectedValue());
        ErrorMessage.Text = "";


        int findTaskId  = -1 ;
        if (TaskID.Text != "")
        {
            try
            {
                findTaskId = Convert.ToInt32(TaskID.Text);
            }
            catch (Exception exc)
            {
                ErrorMessage.Text = "Wrong TaskID value: " + exc.Message;
            }
        }

        if (eds_tasks1.getSelectedValue() != "-1")
        {
            work_log_grid.Columns[2].Visible = false;
        }
        
        db_utils ds = new db_utils();
        mySqlDataSource.ConnectionString = ds.get_db_ConnectionString();
        mySqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        mySqlDataSource.SelectParameters.Clear();
        mySqlDataSource.SelectParameters.Add("TaskId", findTaskId.ToString());
        mySqlDataSource.SelectParameters.Add("SourceId", eds_tasks1.getSelectedValue());

        string tStartDate, tEndDate;
        if (!IsPostBack)
        {
            tStartDate = DateTime.Now.AddDays(-5).ToString("yyyyMMdd");
            tEndDate = DateTime.Now.ToString("yyyyMMdd");
        }
        else 
        {
            tStartDate = StartDate.getISODate();
            tEndDate = EndDate.getISODate();
        }
        mySqlDataSource.SelectParameters.Add("StartDate", tStartDate);
        mySqlDataSource.SelectParameters.Add("EndDate", tEndDate);

        mySqlDataSource.SelectCommand = "eds_get_work_log";
    }

    protected void work_log_grid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string tmpValue = (string)DataBinder.Eval(e.Row.DataItem, "ExitCode");
            if (tmpValue == "Error") 
            {
                e.Row.BackColor = System.Drawing.Color.Tomato;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
        }
    }


    protected void work_log_grid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (work_log_grid.Rows[e.NewSelectedIndex].RowType == DataControlRowType.DataRow)
        {
            db_utils ndb_utils = new db_utils();
            DataSet ds = ndb_utils.get_db_Data("EXEC eds_get_work_log_details @LogId = " + work_log_grid.Rows[e.NewSelectedIndex].Cells[0].Text, null, "DataSet") as DataSet;

            HtmlTable newTable = new HtmlTable();
            newTable.Attributes.Add("class", "GridViewMini");
            newTable.CellSpacing = 1;
            newTable.CellPadding = 1;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        HtmlTableRow newRow = new HtmlTableRow();
                        HtmlTableCell newCell = new HtmlTableCell();
                        newCell.Attributes.Add("class", "GridViewHeadMini");
                        newCell.Align = "right";
                        newCell.Controls.Add(new LiteralControl(column.ColumnName.ToString().Trim()+":"));
                        newRow.Cells.Add(newCell);
                        HtmlTableCell newCellValue = new HtmlTableCell();
                        newCellValue.Controls.Add(new LiteralControl(row[column].ToString().Trim()));
                        newRow.Cells.Add(newCellValue);
                        newTable.Rows.Add(newRow);
                    }
                }

            }
            ajaxUP.ContentTemplateContainer.Controls.Clear();
            ajaxUP.ContentTemplateContainer.Controls.Add(newTable);
        }
    }


    
}
