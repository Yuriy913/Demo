using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
//using System.Linq;

public partial class TOOLS_Quotes_RatingsWork : System.Web.UI.Page
{
	private string RadioButtonArray;

	#region Constants

	private const string StockIDPrompt = "ID";
	private const string SymbolPrompt = "Symbol";
	private const string PersonIDPrompt = "ID";
	private const string PersonNamePrompt = "Name";

	private static class Actions
	{
		public const int Edit = 0;
		public const int Copy = 1;
		public const int Delete = 2;
	}

	#endregion

	#region Properties

	protected int RatingID
	{
		get
		{
			object oRezult = ViewState["RatingID"];

			return oRezult != null ? Convert.ToInt32(oRezult) : 0;
		}
		set { ViewState.Add("RatingID", value); }
	}

	protected int AnalystAliasID
	{
		get
		{
			object oRezult = ViewState["AnalystAliasID"];

			return oRezult != null ? Convert.ToInt32(oRezult) : 0;
		}
		set { ViewState.Add("AnalystAliasID", value); }
	}

	private int ActionID
	{
		get
		{
			if (rbEdit.Checked)
				return Actions.Edit;
			else if (rbCopy.Checked)
				return Actions.Copy;
			else if (rbDelete.Checked)
				return Actions.Delete;
			else
				throw new Exception("Error get action");
		}
	}

	#endregion

	#region PreInt

	protected void Page_PreInit(Object sender, EventArgs e)
	{
		site_utils PageAttr = new site_utils();
		PageAttr.setPageAttr(this.Page);
	}

	#endregion

	#region Paage Events

	protected void Page_Load(object sender, EventArgs e)
	{
		#region Add Event Handlers

		btnSearch.Click += new EventHandler(btnSearch_Click);
		lbtnAddRating.Click += new EventHandler(lbtnAddRating_Click);
		btnUCancel.Click += new EventHandler(btnUCancel_Click);
		btnUUpdate.Click += new EventHandler(btnUUpdate_Click);

		btnConfirmCancel.Click += new EventHandler(btnConfirmCancel_Click);
		btnConfirmYes.Click += new EventHandler(btnConfirmYes_Click);

		gvRatingsAllColumns.RowCreated += new GridViewRowEventHandler(gvRatingsAllColumns_RowCreated);

		txtUAnalystID.TextChanged += new EventHandler(txtUStockID_TextChanged);
		txtUStockID.TextChanged += new EventHandler(txtUStockID_TextChanged);
		txtUPersonID.TextChanged += new EventHandler(txtUStockID_TextChanged);
		txtUDate.TextChanged += new EventHandler(txtUStockID_TextChanged);
		ddlRating.TextChanged += new EventHandler(txtUStockID_TextChanged);
		ddlUAnalysts.TextChanged += new EventHandler(txtUStockID_TextChanged);

		this.PreRender += new EventHandler(TOOLS_Quotes_RatingsWork_PreRender);

		#endregion

		#region TextBoxes prompts

		RemoveTextBoxPromptText(txtStockID, StockIDPrompt);
		RemoveTextBoxPromptText(txtSymbol, SymbolPrompt);
		RemoveTextBoxPromptText(txtPersonID, PersonIDPrompt);
		RemoveTextBoxPromptText(txtPersonName, PersonNamePrompt);

		#endregion

		RadioButtonArray = string.Empty;
	}

	void TOOLS_Quotes_RatingsWork_PreRender(object sender, EventArgs e)
	{
		AddTextBoxPrompt(txtStockID, StockIDPrompt);
		AddTextBoxPrompt(txtSymbol, SymbolPrompt);
		AddTextBoxPrompt(txtPersonID, PersonIDPrompt);
		AddTextBoxPrompt(txtPersonName, PersonNamePrompt);
	}

	#endregion

	#region Button Handlers

	void btnSearch_Click(object sender, EventArgs e)
	{
		SearchRatings();
	}

	void lbtnAddRating_Click(object sender, EventArgs e)
	{
		//throw new NotImplementedException();
	}

	protected void ibtnEditRating_Command(object sender, CommandEventArgs e)
	{
		int ratingID;
		int analystID;

		if (Int32.TryParse(e.CommandArgument.ToString(), out ratingID) && Int32.TryParse(e.CommandName, out analystID))
		{
			RatingID = ratingID;

			DataTable dt = null;

			try
			{
				dt = Data.GetRatings(ratingID.ToString(), analystID.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, false, 10);
			}
			catch (Exception ex)
			{
				Data.ShowError(pInfo, ex);
			}

			if (dt != null && dt.Rows.Count > 0)
			{
				ShowEditRating();

				foreach (GridViewRow row in gvRatings.Rows.Count > 0 ? gvRatings.Rows : gvRatingsAllColumns.Rows)
				{
					if (row.Cells[2].Text.Equals(RatingID.ToString()))
					{
						row.Style.Add("background-color", Data.Constants.Colors.YellowCell);
					}
					else
					{
						row.Style.Remove("background-color");
					}
				}

				/*
				GridViewRow ratingRow =
					(from GridViewRow row in gvRatings.Rows.Count > 0 ? gvRatings.Rows : gvRatingsAllColumns.Rows
					 where row.Cells[2].Text.Equals(RatingID.ToString())
					 select row).SingleOrDefault();

				ratingRow.Style.Add("background-color", Data.Constants.Colors.YellowCell);
				*/

				//Text may be red if window was closed with error
				txtUAnalystID.Style.Remove("color");
				txtUStockID.Style.Remove("color");
				txtUPersonID.Style.Remove("color");
				txtUDate.Style.Remove("color");

				DataRow dr = dt.Rows[0];

				AnalystAliasID = Convert.ToInt32(dr["AnalystAliasID"]);

				txtUAnalystID.Text = dr["AnalystID"].ToString();
				txtUStockID.Text = dr["StockID"].ToString();
				txtUPersonID.Text = dr["PersonID"].ToString();
				txtUDate.Text = dr["Date"].ToString();
				lblUTermID.Text = dr["TermID"].ToString();

				lblUAnalyst.Visible = true;
				ddlUAnalysts.Visible = false;
				lblUAnalyst.Text = Data.GetAnalystNameByAnalystAliasID(Convert.ToInt32(dr["AnalystAliasID"]));
				lblUStock.Text = dr["StockName"].ToString();
				lblUSymbol.Text = dr["Symbol"].ToString();
				lblUPerson.Text = dr["PersonName"].ToString();
				DateTime dtDate = Convert.ToDateTime(txtUDate.Text);
				DateTimeFormatInfo gmn = new DateTimeFormatInfo();
				lblUDate.Text = dtDate.Day.ToString() + " " + gmn.GetMonthName(dtDate.Month) + " " + dtDate.Year.ToString() + " " + dtDate.TimeOfDay.ToString();

				ddlRating.DataSource = Data.GetAnalystTermsByAnalystAliasID(Convert.ToInt32(dr["AnalystAliasID"]));
				ddlRating.DataTextField = "RatingName";
				ddlRating.DataValueField = "TermAliasID";
				ddlRating.DataBind();

				ddlRating.SelectedValue = dr["TermAliasID"].ToString();
			}
			else
			{
				Data.ShowError(pInfo, "Error get rating data");
			}
		}
		else
		{
			Data.ShowError(pInfo, "Error get RatingID and AnalystID");
		}
	}

	void btnUUpdate_Click(object sender, EventArgs e)
	{
		if (RatingID != 0)
		{
			pConfirm.Visible = true;

			tConfirm.Rows[0].Visible = true;
			tConfirm.Rows[1].Visible = true;
			tConfirm.Rows[2].Visible = true;

			if (ActionID == Actions.Delete || ActionID == Actions.Edit)
			{
				//Fil delete row

				DataTable dtOldRating = Data.GetRatings(RatingID.ToString(), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, false, 10);

				if (dtOldRating != null && dtOldRating.Rows.Count > 0)
				{
					DataRow drOldRating = dtOldRating.Rows[0];

					lblConfirmDAnalystID.Text = drOldRating["AnalystID"].ToString();
					lblConfirmDStockID.Text = drOldRating["StockID"].ToString();
					lblConfirmDSymbol.Text = drOldRating["Symbol"].ToString();
					lblConfirmDStockName.Text = drOldRating["StockName"].ToString();
					lblConfirmDDate.Text = drOldRating["Date"].ToString();
					lblConfirmDPersonID.Text = drOldRating["PersonID"].ToString();
					lblConfirmDPerson.Text = drOldRating["PersonName"].ToString();
					lblConfirmDTermID.Text = drOldRating["TermID"].ToString();
					lblConfirmDRating.Text = drOldRating["Rating"].ToString();
					lblConfirmDPrice.Text = drOldRating["Price"].ToString();
				}
			}
			else
			{
				tConfirm.Rows[1].Visible = false;
			}

			if (ActionID != Actions.Delete)
			{
				//Fil insert row
				lblConfirmIAnalystID.Text = txtUAnalystID.Text;
				lblConfirmIStockID.Text = txtUStockID.Text;
				lblConfirmISymbol.Text = lblUSymbol.Text;
				lblConfirmIStockName.Text = lblUStock.Text;
				lblConfirmIDate.Text = txtUDate.Text;
				lblConfirmIPersonID.Text = txtUPersonID.Text;
				lblConfirmIPerson.Text = lblUPerson.Text;
				lblConfirmITermID.Text = lblUTermID.Text;
				lblConfirmIRating.Text = ddlRating.SelectedItem.ToString();
				lblConfirmIPrice.Text = "n/a";
			}
			else
			{
				tConfirm.Rows[2].Visible = false;
			}

			//Match rows
			MatchLabels(lblConfirmDAnalystID, lblConfirmIAnalystID);
			MatchLabels(lblConfirmDStockID, lblConfirmIStockID);
			MatchLabels(lblConfirmDSymbol, lblConfirmISymbol);
			MatchLabels(lblConfirmDStockName, lblConfirmIStockName);
			MatchLabels(lblConfirmDDate, lblConfirmIDate);
			MatchLabels(lblConfirmDPersonID, lblConfirmIPersonID);
			MatchLabels(lblConfirmDPerson, lblConfirmIPerson);
			MatchLabels(lblConfirmDTermID, lblConfirmITermID);
			MatchLabels(lblConfirmDRating, lblConfirmIRating);
			MatchLabels(lblConfirmDPrice, lblConfirmIPrice);

		}
	}

	void btnUCancel_Click(object sender, EventArgs e)
	{
		HideEditRating();

		SearchRatings();
	}

	void btnConfirmYes_Click(object sender, EventArgs e)
	{
		//pConfirm.Visible = false;
	}

	void btnConfirmCancel_Click(object sender, EventArgs e)
	{
		pConfirm.Visible = false;
	}

	#endregion

	#region TextBoxes Handlers

	void txtUStockID_TextChanged(object sender, EventArgs e)
	{
		Control txtData = sender as Control;

		if (txtData != null)
		{
			int analystID = 0;
			Int32.TryParse(txtUAnalystID.Text, out analystID);

			if (txtData.ID == "txtUAnalystID")
			{
				if (analystID != 0)
				{
					DataTable dtAnalysts = Data.GetAnalystByAnalystID(analystID);

					if (dtAnalysts != null && dtAnalysts.Rows.Count > 0)
					{
						if (dtAnalysts.Rows.Count > 1)
						{//Show drop down
							lblUAnalyst.Visible = false;
							ddlUAnalysts.Visible = true;

							ddlUAnalysts.DataSource = dtAnalysts;
							ddlUAnalysts.DataValueField = "AnalystAliasID";
							ddlUAnalysts.DataTextField = "AnalystName";

							ddlUAnalysts.DataBind();

							AnalystAliasID = Convert.ToInt32(ddlUAnalysts.SelectedValue);
						}
						else
						{//Show label
							lblUAnalyst.Visible = true;
							ddlUAnalysts.Visible = false;

							DataRow drAnalysts = dtAnalysts.Rows[0];

							AnalystAliasID = Convert.ToInt32(drAnalysts["AnalystAliasID"]);
							lblUAnalyst.Text = drAnalysts["AnalystName"].ToString();
						}

						ddlRating.DataSource = Data.GetAnalystTermsByAnalystAliasID(AnalystAliasID);
						ddlRating.DataBind();

						txtUAnalystID.Style.Remove("color");
					}
					else
					{
						txtUAnalystID.Style.Add("color", "red");

						lblUAnalyst.Visible = true;
						ddlUAnalysts.Visible = false;

						AnalystAliasID = 0;
						lblUAnalyst.Text = "n/a";
					}
				}
				else
				{
					txtUAnalystID.Style.Add("color", "red");
				}
			}

			if (txtData.ID == "txtUStockID")
			{
				int stockID = 0;

				if (Int32.TryParse(txtUStockID.Text, out stockID))
				{
					DataTable dtStock = Data.getStocks(stockID.ToString(), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, 10);

					if (dtStock != null && dtStock.Rows.Count > 0)
					{
						lblUSymbol.Text = dtStock.Rows[0]["Symbol"].ToString();
						lblUStock.Text = dtStock.Rows[0]["Name"].ToString();

						txtUStockID.Style.Remove("color");
					}
					else
					{
						lblUSymbol.Text = "n/a" + " - ";
						lblUStock.Text = "n/a";

						txtUStockID.Style.Add("color", "red");
					}
				}
				else
				{
					txtUStockID.Style.Add("color", "red");
				}
			}

			if (txtData.ID == "ddlUAnalysts")
			{
				AnalystAliasID = Convert.ToInt32(ddlUAnalysts.SelectedValue);

				ddlRating.DataSource = Data.GetAnalystTermsByAnalystAliasID(AnalystAliasID);
				ddlRating.DataBind();
			}

			if (txtData.ID == "txtUPersonID" || txtData.ID == "txtUAnalystID")
			{
				int personID = 0;

				if (Int32.TryParse(txtUPersonID.Text, out personID))
				{
					string personName = Data.GetPersonNameByID(personID, analystID);

					lblUPerson.Text = personName;

					txtUPersonID.Style.Remove("color");
				}
				else
				{
					txtUPersonID.Style.Add("color", "red");
				}
			}

			if (txtData.ID == "txtUDate")
			{
				DateTime date = DateTime.MinValue;

				if (DateTime.TryParse(txtUDate.Text, out date))
				{
					DateTimeFormatInfo gmn = new DateTimeFormatInfo();
					string dateString = date.Day.ToString() + " " + gmn.GetMonthName(date.Month) + " " + date.Year.ToString() + " " + date.TimeOfDay.ToString();

					lblUDate.Text = dateString;

					txtUDate.Style.Remove("color");
				}
				else
				{
					txtUDate.Style.Add("color", "red");
				}
			}

			if (txtData.ID == "ddlRating" || txtData.ID == "txtUAnalystID" || txtData.ID == "ddlUAnalysts")
			{
				int termAliasID = 0;

				if (Int32.TryParse(ddlRating.SelectedValue, out termAliasID))
				{
					string termID = Data.GetTermIDByTermAliasID(termAliasID, analystID).ToString();

					lblUTermID.Text = termID == "0" ? "n/a" : termID;
				}
				else
				{
					lblUTermID.Text = "n/a";
				}
			}
		}
	}

	#endregion

	#region Data Bound Handlers

	void gvRatingsAllColumns_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "ColorRow(this)");
			e.Row.Attributes.Add("onmouseout", "UnColorRow(this)");

			/*
			ImageButton ibtnEditRating = e.Row.Cells[0].FindControl("ibtnEditRating") as ImageButton;

			if (ibtnEditRating != null)
			{
				string id = ibtnEditRating.UniqueID;

				AsyncPostBackTrigger tr = new AsyncPostBackTrigger();
				tr.ControlID = id;
				tr.EventName = "command";

				upRatings.Triggers.Add(tr);
				upEditRating.Triggers.Add(tr);
			}*/
		}
	}

	#endregion

	#region Internal Implementation

	private void SearchRatings()
	{
		string ratingID = txtRatingID.Text.Trim();
		string analystID = txtAnalystID.Text.Trim();
		string stockID = txtStockID.Text.Trim();
		string symbol = txtSymbol.Text;
		string personID = txtPersonID.Text.Trim();
		string personName = txtPersonName.Text;
		string termID = txtTermID.Text.Trim();
		string date = txtDate.Text.Trim();

		int maxRowCount = 40;

		bool allColumns = cbAllColumns.Checked;

		DataTable dtRatings = null;

		try
		{
			dtRatings = Data.GetRatings(ratingID, analystID, stockID, symbol, personID, personName, termID, date, allColumns, maxRowCount);
		}
		catch (Exception ex)
		{
			Data.ShowError(pInfo, ex);
		}

		gvRatingsAllColumns.DataSource = dtRatings;
		gvRatingsAllColumns.DataBind();
	}

	private void MatchLabels(Label FirstLabel, Label SecondLabel)
	{
		if (tConfirm.Rows[1].Visible && tConfirm.Rows[2].Visible
			&& !FirstLabel.Text.Equals(SecondLabel.Text))
		{
			(FirstLabel.Parent as System.Web.UI.HtmlControls.HtmlTableCell).Style.Add("background", "yellow");
			(SecondLabel.Parent as System.Web.UI.HtmlControls.HtmlTableCell).Style.Add("background", "yellow");
		}
		else
		{
			(FirstLabel.Parent as System.Web.UI.HtmlControls.HtmlTableCell).Style.Remove("background");
			(SecondLabel.Parent as System.Web.UI.HtmlControls.HtmlTableCell).Style.Remove("background");
		}
	}

	private void AddTextBoxPrompt(TextBox txtConrol, string prompt)
	{
		txtConrol.Attributes.Add("onFocus", String.Format("TextBoxOnFocusPrompt(this, '{0}')", prompt));
		txtConrol.Attributes.Add("onBlur", String.Format("TextBoxOnBlurPrompt(this, '{0}')", prompt));

		if (txtConrol.Text == String.Empty)
		{
			txtConrol.Text = prompt;
			txtConrol.Style.Add("color", "gray");
		}
		else
		{
			txtConrol.Style.Remove("color");
		}
	}

	private void RemoveTextBoxPromptText(TextBox txtConrol, string prompt)
	{
		if (txtConrol.Text == prompt)
		{
			txtConrol.Text = String.Empty;
		}
	}

	private void ShowEditRating()
	{
		pOptions.Visible = false;
		pSearchRatings.Visible = false;

		pEditRating.Visible = true;

		rbEdit.Checked = true;
		rbCopy.Checked = false;
		rbDelete.Checked = false;

	}

	private void HideEditRating()
	{
		pOptions.Visible = true;
		pSearchRatings.Visible = true;

		pEditRating.Visible = false;
	}

	#endregion
}
