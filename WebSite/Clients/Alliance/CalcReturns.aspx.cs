using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Data.Linq;
//using System.Linq;
using System.Collections;

public partial class Clients_Alliance_CalcReturns : System.Web.UI.Page
{
	GridViewRow gvrLast;

	#region Constants

	private const string DeleteAlert = "DeleteAlert";
	private const string SendAlert = "SendAlert";

	private const string ShowAlertScript = "ShowWindow({0}); return false;";

	#endregion

	#region PreInt

	protected void Page_PreInit(Object sender, EventArgs e)
	{
		site_utils PageAttr = new site_utils();
		PageAttr.setPageAttr(this.Page);
	}

	#endregion

	#region Page Load

	protected void Page_Load(object sender, EventArgs e)
	{
		gvAlerts.RowDataBound += new GridViewRowEventHandler(gvAlerts_RowDataBound);
		gvCummulativeReturns.RowDataBound += new GridViewRowEventHandler(gvCummulativeReturns_RowDataBound);
		gvDailyReturns.RowDataBound += new GridViewRowEventHandler(gvDailyReturns_RowDataBound);
		btnConfirmYes.Command += new CommandEventHandler(btnConfirmYes_Command);
		btnConfirmCancel.Click += new EventHandler(btnConfirmCancel_Click);
		lbtnBackToStart.Click += new EventHandler(lbtnBackToStart_Click);

		if (!IsPostBack)
		{
			FillAlertsDataView();

			FillCummulativeReturnMatchDataView();
		}
		else
		{
			foreach (GridViewRow gvr in gvAlerts.Rows)
			{
				ImageButton ibtnShowText = gvr.Cells[0].FindControl("ibtnShowText") as ImageButton;

				if (ibtnShowText != null)
				{
					ibtnShowText.Attributes.Add("onclick", String.Format(ShowAlertScript, ibtnShowText.CommandArgument));
				}

				gvr.Attributes.Add("onmouseover", "ColorRow(this)");
				gvr.Attributes.Add("onmouseout", "UnColorRow(this)");
			}

			string eventArg = Request["__EVENTARGUMENT"];
			if (eventArg.IndexOf("Select") > -1)
			{
				int startIndex = eventArg.IndexOf("$") + 1;
				string personPeriod = eventArg.Substring(startIndex, eventArg.Length - startIndex);

				string[] aPersonPeriod = personPeriod.Split('&');

				int personID = 0, periodID = 0;

				int.TryParse(aPersonPeriod[0], out personID);
				int.TryParse(aPersonPeriod[1], out periodID);

				if (personID > 0 && periodID > 0)
				{
					ShowAnalystPerformanceDetails(personID, periodID);
				}
			}
		}
	}

	#endregion

	#region Button Handlers

	protected void ibtnShowText_Command(object sender, CommandEventArgs e)
	{
		int alertID = Convert.ToInt32(e.CommandArgument);

		string messageText = String.Empty;

		try
		{
			messageText = Data.getAllianceAlertText(alertID);
		}
		catch (Exception ex)
		{
			Data.ShowError(pInfo, ex);
		}

		if (!messageText.Equals(String.Empty))
		{
			Response.Write(messageText);//load it to current window
			Response.End();
		}
	}

	protected void ibtnDeleteAlert_Command(object sender, CommandEventArgs e)
	{
		lblPopUpText.Text = "Delete selected item?";

		btnConfirmYes.CommandName = DeleteAlert;
		btnConfirmYes.CommandArgument = e.CommandArgument.ToString();

		pConfirm.Visible = true;
	}

	protected void btnSendAlert_Command(object sender, CommandEventArgs e)
	{
		string addresses = String.Empty;

		try
		{
			addresses = Data.GetEmailAddressesByGroupID(Data.Constants.AllianceGroupID);
		}
		catch (Exception ex)
		{
			Data.ShowError(pInfo, ex);
		}

		lblPopUpText.Text = String.Format("Send alert to {0}?", addresses);

		btnConfirmYes.CommandName = SendAlert;
		btnConfirmYes.CommandArgument = e.CommandArgument.ToString();

		pConfirm.Visible = true;
	}

	void btnConfirmYes_Command(object sender, CommandEventArgs e)
	{
		string commandName = e.CommandName;

		switch (commandName)
		{
			/* Delete alert */
			case DeleteAlert:
				{
					int alertID = Convert.ToInt32(e.CommandArgument);

					try
					{
						Data.DeleteAllianceAlert(alertID);

						FillAlertsDataView();
					}
					catch (Exception ex)
					{
						Data.ShowError(pInfo, ex);
					}

					break;
				}
			case SendAlert:
				{
					int alertID = Convert.ToInt32(e.CommandArgument);

					try
					{
						string addresses = Data.GetEmailAddressesByGroupID(Data.Constants.AllianceGroupID);

						Data.SendAlertToAlliance(alertID, addresses);
					}
					catch (Exception ex)
					{
						Data.ShowError(pInfo, ex);
					}

					break;
				}
			default:
				{
					Data.ShowError(pInfo, "Uncnown CommandName!");

					break;
				}
		}

		pConfirm.Visible = false;
	}

	void btnConfirmCancel_Click(object sender, EventArgs e)
	{
		pConfirm.Visible = false;
	}

	private void ShowAnalystPerformanceDetails(int personID, int periodID)
	{
		pCummulativeReturns.Visible = false;

		DataTable dtDailyReturns = null;

		try
		{
			dtDailyReturns = Data.GetAllianceAnalystDailyReturns(personID, periodID);
		}
		catch (Exception ex)
		{
			Data.ShowError(pInfo, ex);
		}

		if (dtDailyReturns != null && dtDailyReturns.Rows.Count > 0)
		{
			gvDailyReturns.DataSource = dtDailyReturns;
			gvDailyReturns.DataBind();

			pDailyReturns.Visible = true;
		}
	}

	void lbtnBackToStart_Click(object sender, EventArgs e)
	{
		pCummulativeReturns.Visible = true;
		pDailyReturns.Visible = false;
	}

	#endregion

	#region Databound Handlers

	void gvAlerts_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			const int showTestButtonCellIndex = 0;
			const int dateCellIndex = 3;

			e.Row.Attributes.Add("onmouseover", "ColorRow(this)");
			e.Row.Attributes.Add("onmouseout", "UnColorRow(this)");

			//Assign onClick events
			ImageButton ibtnShowText = e.Row.Cells[showTestButtonCellIndex].FindControl("ibtnShowText") as ImageButton;

			if (ibtnShowText != null)
			{
				string alertID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();

				ibtnShowText.Attributes.Add("onClick", String.Format(ShowAlertScript, alertID));
			}

			//Color today's alerts
			string strDate = e.Row.Cells[dateCellIndex].Text;

			if (strDate != String.Empty)
			{
				DateTime date = Convert.ToDateTime(strDate);

				if (date.Date == DateTime.Now.Date)
				{
					e.Row.Cells[dateCellIndex].Style.Add("background-color", Data.Constants.Colors.GreenCell);
				}
			}
		}
	}

	void gvCummulativeReturns_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			SortedList formatCells = new SortedList();

			//"id", "name,colspan,rowspan"
			formatCells.Add("1", ",3,1");
			formatCells.Add("2", "Last,3,1");
			formatCells.Add("3", ",1,1");
			formatCells.Add("4", "Previous,3,1");
			formatCells.Add("5", ",2,1");

			GetMultiRowHeader(e, formatCells);
		}

		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			const int bReturnIndex = 3;
			const int pReturnIndex = 4;
			const int attributionIndex = 5;
			const int bpReturnIndex = 7;
			const int ppReturnIndex = 8;
			const int pAttributionIndex = 9;
			const int jumpIndex = 11;

			//Color row on mouseover
			e.Row.Attributes.Add("onmouseover", "ColorRow(this)");
			e.Row.Attributes.Add("onmouseout", "UnColorRow(this)");

			//Add onClick event to row
			string personID = DataBinder.Eval(e.Row.DataItem, "PersonID").ToString();
			string periodID = DataBinder.Eval(e.Row.DataItem, "PeriodID").ToString();
			string eventArg = String.Format("Select${0}&{1}", personID, periodID);

			e.Row.Style.Add("cursor", "pointer");
			//e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(sender as GridView, eventArg));
			e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(upCummulativeRetursMatch, eventArg));

			smMain.RegisterAsyncPostBackControl(gvCummulativeReturns);

			//Color cells with big jumps
			ColorCellsIfBigJump(e.Row.Cells[bReturnIndex], e.Row.Cells[bpReturnIndex]);
			ColorCellsIfBigJump(e.Row.Cells[pReturnIndex], e.Row.Cells[ppReturnIndex]);
			ColorCellsIfBigJump(e.Row.Cells[attributionIndex], e.Row.Cells[pAttributionIndex]);
			ColorCellsIfBigJump(e.Row.Cells[attributionIndex], e.Row.Cells[pAttributionIndex]);
			ColorCellsIfBigJump(e.Row.Cells[jumpIndex]);
		}
	}

	void gvDailyReturns_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			if (DataBinder.Eval(e.Row.DataItem, "Prev").Equals(1) && gvrLast != null)
			{
				for (int index = 3; index < e.Row.Cells.Count; index++)
				{
					if (!gvrLast.Cells[index].Text.Equals(e.Row.Cells[index].Text))
					{
						gvrLast.Cells[index].Style.Add("background-color", Data.Constants.Colors.YellowCell);
						e.Row.Cells[index].Style.Add("background-color", Data.Constants.Colors.YellowCell);
					}
				}
			}
			else
			{
				gvrLast = e.Row;
			}
		}
	}

	#endregion

	#region Internal Implementation

	private void FillAlertsDataView()
	{
		DataTable dt = null;

		try
		{
			dt = Data.GetAllianceAlerts();
		}
		catch (Exception ex)
		{
			Data.ShowError(pInfo, ex);
		}

		gvAlerts.DataSource = dt;
		gvAlerts.DataBind();

		if (dt.Rows.Count == 0)
		{
			Data.ShowError(pInfo, "No data");
		}
	}

	private void FillCummulativeReturnMatchDataView()
	{
		/*
		db_utils ndb_utils = new db_utils();

		SupportDBDataContext db = new SupportDBDataContext(ndb_utils.get_db_ConnectionString());

		var cummulativeReturns =
			from cr in db.acm_get_analyst_cummulative_returns_jumps(20)
			select cr;
		*/
		DataTable dtCummulativeReturn = null;

		try
		{
			dtCummulativeReturn = Data.GetAllianceAnalystCummulativeReturnsJumps(20);
		}
		catch (Exception ex)
		{
			Data.ShowError(pInfo, ex);
		}

		if (dtCummulativeReturn != null && dtCummulativeReturn.Rows.Count > 0)
		{
			gvCummulativeReturns.DataSource = dtCummulativeReturn;
			gvCummulativeReturns.DataBind();
		}

	}

	public void GetMultiRowHeader(GridViewRowEventArgs e, SortedList GetCels)
	{

		if (e.Row.RowType == DataControlRowType.Header)
		{
			GridViewRow row;
			IDictionaryEnumerator enumCels = GetCels.GetEnumerator();

			row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
			
			while (enumCels.MoveNext())
			{

				string[] count = enumCels.Value.ToString().Split(Convert.ToChar(","));
				TableCell Cell;
				Cell = new TableCell();
				Cell.RowSpan = Convert.ToInt16(count [2].ToString());
				Cell.ColumnSpan = Convert.ToInt16(count [1].ToString());
				Cell.Controls.Add(new LiteralControl(count [0].ToString()));
				Cell.HorizontalAlign = HorizontalAlign.Center;
				Cell.ForeColor = System.Drawing.Color.White;
				row.Cells.Add(Cell);
			}

			e.Row.Parent.Controls.AddAt(0, row);
		}
	}

	private void ColorCellsIfBigJump(TableCell cFrom, TableCell cTo)
	{
		float valueFrom, valueTo = 0;
		bool isParsed;

		isParsed = float.TryParse(cFrom.Text, out valueFrom) &&
					float.TryParse(cTo.Text, out valueTo);

		if (isParsed)
		{
			float jump = Math.Abs(valueTo - valueFrom);

			if (jump > 10)
			{
				cFrom.Style.Add("background-color", Data.Constants.Colors.RedCell);
				cTo.Style.Add("background-color", Data.Constants.Colors.RedCell);
			}
			else if (jump > 5)
			{
				cFrom.Style.Add("background-color", Data.Constants.Colors.YellowCell);
				cTo.Style.Add("background-color", Data.Constants.Colors.YellowCell);
			}
		}
	}

	private void ColorCellsIfBigJump(TableCell cTo)
	{
		TableCell tcEmpty = new TableCell();
		tcEmpty.Text = "0.0";

		ColorCellsIfBigJump(tcEmpty, cTo);
		//ColorCellsIfBigJump(new TableCell { Text = "0.0" }, cTo);
	}

	#endregion
}
