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

public partial class AllianceDataFeedAnalysis : System.Web.UI.Page
{
	#region Properties

	private int SecurityID
	{
		get
		{
			object result = ViewState["SecurityID"];

			return result != null ? Convert.ToInt32(result) : 0;
		}

		set {ViewState.Add("SecurityID", value);}
	}

    private int StockID
    {
        get
        {
            object result = ViewState["StockID"];

            return result != null ? Convert.ToInt32(result) : 0;
        }

        set { ViewState.Add("StockID", value); }
    }

	#endregion

	#region Constants

	private const int AllianceID = 1227;

	private const string CSScript = "<script language=\"JavaScript\" type = \"text/javascript\"> <!--{0}//--> </script>";

	private const string CSColorTextBox = @"
	var txtControl = document.getElementById('{0}');
	
	if(txtControl != null)
		ColorUncolorTextBox(txtControl);
";
	#endregion

	#region PreInin

	protected void Page_PreInit(Object sender, EventArgs e)
	{
		site_utils PageAttr = new site_utils();
		PageAttr.setPageAttr(this.Page);
	}

	#endregion

	#region Page Load

	protected void Page_Load(object sender, EventArgs e)
	{
		#region Add Event Handlers

		btnSearch.Click += new EventHandler(btnSearch_Click);
		dgCoverage.ItemDataBound += new DataGridItemEventHandler(dgCoverage_ItemDataBound);
		dgStocks.ItemDataBound += new DataGridItemEventHandler(dgStocks_ItemDataBound);
		dgRatings.ItemDataBound += new DataGridItemEventHandler(dgRatings_ItemDataBound);
		lbtnChangeStockID.Click += new EventHandler(lbtnChangeStockID_Click);
		btnUpdateStockIDCancel.Click += new EventHandler(btnUpdateStockIDCancel_Click);
		btnUpdateStockIDUpdate.Click += new EventHandler(btnUpdateStockIDUpdate_Click);

		#endregion

		//Add java script for color not empty textboxes
		txtStockID.Attributes.Add("onChange", "ColorUncolorTextBox(this);");
		txtSecurityID.Attributes.Add("onChange", "ColorUncolorTextBox(this);");
		txtTicker.Attributes.Add("onChange", "ColorUncolorTextBox(this);");
		txtName.Attributes.Add("onChange", "ColorUncolorTextBox(this);");

		Page.RegisterStartupScript("ColorStockID", String.Format(CSScript, String.Format(CSColorTextBox, txtStockID.ClientID)));
		Page.RegisterStartupScript("ColorSecurityID", String.Format(CSScript, String.Format(CSColorTextBox, txtSecurityID.ClientID)));
		Page.RegisterStartupScript("ColorTicker", String.Format(CSScript, String.Format(CSColorTextBox, txtTicker.ClientID)));
		Page.RegisterStartupScript("ColorName", String.Format(CSScript, String.Format(CSColorTextBox, txtName.ClientID)));
	}

	#endregion

	#region Button handlers

	void btnSearch_Click(object sender, EventArgs e)
	{
		pResults.Visible = false;
		SecurityID = 0;

		int stockID, securityID, rowCount;

		stockID = securityID = -1;
		rowCount = 20;

		string ticker = txtTicker.Text.Trim();
		string description = txtName.Text.Trim();

		try
		{
			if (txtStockID.Text.Trim().Equals(string.Empty))
			{
				stockID = -1;
			}
			else
			{
				stockID = Convert.ToInt32(txtStockID.Text.Trim());
			}

			if (txtSecurityID.Text.Trim().Equals(string.Empty))
			{
				securityID = -1;
			}
			else
			{
				securityID = Convert.ToInt32(txtSecurityID.Text.Trim());
			}

			rowCount = 20; //!!Use TextBox
		}
		catch { }

		DataTable dtStocks = Data.GetAllianceStocks(stockID, securityID, ticker, description, rowCount);

		dgStocks.DataSource = dtStocks;
		dgStocks.DataBind();
		
		if (dtStocks != null && dtStocks.Rows.Count == 1)
		{
			SecurityID = Convert.ToInt32(dtStocks.Rows[0]["ID"]);
			//FillDetails(Convert.ToInt32(dtStocks.Rows[0]["ID"]));

			//pResults.Visible = true;
		}
		else
		{
			//pResults.Visible = false;
		}
	}

	void lbtnChangeStockID_Click(object sender, EventArgs e)
	{
		pUpdateStockID.Visible = true;

        txtUpdateStockID.Text = StockID.ToString();
	}

	void btnUpdateStockIDCancel_Click(object sender, EventArgs e)
	{
		pUpdateStockID.Visible = false;
	}

	void btnUpdateStockIDUpdate_Click(object sender, EventArgs e)
	{
		int investarsStockID;

		if (SecurityID != 0 && Int32.TryParse(txtUpdateStockID.Text.Trim(), out investarsStockID))
		{
			//Update
			Data.UpdateAllianceInvestarsStockID(SecurityID, investarsStockID);

			txtSecurityID.Text = SecurityID.ToString();

			btnSearch_Click(btnSearch, new EventArgs());
		}

		pUpdateStockID.Visible = false;
	}

	protected void lbtnSecurityName_Command(object sender, CommandEventArgs e)
	{
		SecurityID = Convert.ToInt32(e.CommandArgument);

		FillDetails(SecurityID);

		pResults.Visible = true;
	}

	#endregion

	#region DataBound handlers

	void dgStocks_ItemDataBound(object sender, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			//Color/uncolor row by mouse move
			e.Item.Attributes.Add("onmouseover", "ColorRow(this)");
			e.Item.Attributes.Add("onmouseout", "UnColorRow(this)");

            int stockID = 0;

            if (((DataRowView)e.Item.DataItem)["InvestarsStockID"] != DBNull.Value)
            {
                stockID = Convert.ToInt32(((DataRowView)e.Item.DataItem)["InvestarsStockID"]);
            }

            if (stockID == 0)
            {
                e.Item.Cells[7].Style.Add("background-color", "#FF9090");
            }
		}
	}

	void dgCoverage_ItemDataBound(object sender, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			DateTime dateStart, dateEnd;
			dateStart = dateEnd = DateTime.Now;

			if (((DataRowView)e.Item.DataItem)["CoverageDateStart"] != DBNull.Value)
			{
				dateStart = Convert.ToDateTime(((DataRowView)e.Item.DataItem)["CoverageDateStart"]);
			}

			if (((DataRowView)e.Item.DataItem)["CoverageDateEnd"] != DBNull.Value)
			{
				dateEnd = Convert.ToDateTime(((DataRowView)e.Item.DataItem)["CoverageDateEnd"]);
			}

			if (dateStart > dateEnd)
			{
				e.Item.Cells[4].Style.Add("background-color", "#FF9090");
				e.Item.Cells[4].Style.Add("color", "black");
				e.Item.Cells[5].Style.Add("background-color", "#FF9090");
				e.Item.Cells[5].Style.Add("color", "black");
			}

			//e.Item.Style.Add("background-color", "green");
		}
	}

	void dgRatings_ItemDataBound(object sender, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			DateTime dateStart, dateEnd;
			dateStart = dateEnd = DateTime.Now;

			if (((DataRowView)e.Item.DataItem)["CoverageDateStart"] != DBNull.Value)
			{
				dateStart = Convert.ToDateTime(((DataRowView)e.Item.DataItem)["CoverageDateStart"]);
			}

			if (((DataRowView)e.Item.DataItem)["CoverageDateEnd"] != DBNull.Value)
			{
				dateEnd = Convert.ToDateTime(((DataRowView)e.Item.DataItem)["CoverageDateEnd"]);
			}

			if (dateStart > dateEnd)
			{
				e.Item.Cells[7].Style.Add("background-color", "#FF9090");
				e.Item.Cells[7].Style.Add("color", "black");
				e.Item.Cells[8].Style.Add("background-color", "#FF9090");
				e.Item.Cells[8].Style.Add("color", "black");
			}

			//e.Item.Style.Add("background-color", "green");
		}
	}

	#endregion

	#region Internal implementation

	private void FillDetails(int securityID)
	{
		if (!securityID.Equals(String.Empty))
		{
			pResults.Visible = true;

			int maxCountRows = 40; //!!Implement TextBox

			DataTable dtRatings = Data.GetAllianceRatings(securityID, maxCountRows);
			DataTable dtCoverage = Data.GetAllianceCoverage(securityID, maxCountRows);
			DataTable dtConvictions = Data.GetAllianceConvictions(securityID, maxCountRows);

			try
			{
				int stockID = Data.GetStockIDByAllianceSecurityID(securityID);

                StockID = stockID;

				DataTable dtInvestarsRatings = Data.GetInvestarsRatings(stockID, AllianceID, maxCountRows);

				dgInvestarsRatings.DataSource = dtInvestarsRatings;

				DataTable dtStocks = Data.GetAllianceStocks(stockID, securityID, String.Empty, String.Empty, maxCountRows);

				dgStocks.DataSource = dtStocks;
				dgStocks.DataBind();
			}
            catch //(Exception ex)
			{
				Label lError = new Label();
				lError.Text = "Error load analyst_ratings!";
				lError.Style.Add("color", "red");

				pAnalystRatings.Controls.Add(lError);
			}

			dgRatings.DataSource = dtRatings;
			dgCoverage.DataSource = dtCoverage;
			dgConvictions.DataSource = dtConvictions;

			dgRatings.DataBind();
			dgCoverage.DataBind();
			dgConvictions.DataBind();
			dgInvestarsRatings.DataBind();
		}
	}

	#endregion
}
