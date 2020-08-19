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
using System.Text;

public partial class Investars_CheckPrices : System.Web.UI.Page
{
	protected void Page_PreInit(Object sender, EventArgs e)
	{
		site_utils PageAttr = new site_utils();
		PageAttr.setPageAttr(this.Page);
	}

	#region Page Load

	protected void Page_Load(object sender, EventArgs e)
	{
		#region Add event handlers

		btnSearch.Click += new EventHandler(btnSearch_Click);
		btnOptions.Click += new EventHandler(btnOptions_Click);
		btnCancel.Click += new EventHandler(btnCancel_Click);
		btnSave.Click += new EventHandler(btnSave_Click);

		dgStocks.ItemDataBound += new DataGridItemEventHandler(dgStocks_ItemDataBound);

		#endregion

		if (!smMain.IsInAsyncPostBack)
		{
			if (!IsPostBack)
			{
				txtDiff.Text = "50";

				DataTable dtAnalysts = new DataTable();
				DataColumn cAnalystID = new DataColumn("AnalystID", System.Type.GetType("System.Int32"));
				DataColumn cAnalystName = new DataColumn("AnalystName", System.Type.GetType("System.String"));

				dtAnalysts.Columns.Add(cAnalystID);
				dtAnalysts.Columns.Add(cAnalystName);

				dtAnalysts.Rows.Add(744, "744 JPMorgan");
				dtAnalysts.Rows.Add(1227, "1227 Alliance");
				dtAnalysts.Rows.Add(646, "646 S&P");
				dtAnalysts.Rows.Add(1819, "1819 DWS");

				lbAnalysts.DataSource = dtAnalysts;
				lbAnalysts.DataValueField = "AnalystID";
				lbAnalysts.DataTextField = "AnalystName";
				lbAnalysts.DataBind();
			}

			FillTable();
		}
	}

	void btnTest_Click(object sender, EventArgs e)
	{
		//int i = 0;
	}

	#endregion

	#region Data Boud Handlers

	void dgStocks_ItemDataBound(object sender, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			e.Item.Attributes.Add("onmouseover", "ColorRow(this)");
			e.Item.Attributes.Add("onmouseout", "UnColorRow(this)");
		}
	}

	#endregion

	#region Button Handlers

	void btnOptions_Click(object sender, EventArgs e)
	{
		pOptions.Visible = true;
	}

	void btnCancel_Click(object sender, EventArgs e)
	{
		//Do javascript
		pOptions.Visible = false;
	}

	void btnSave_Click(object sender, EventArgs e)
	{
		//Save options and refresh table
		pOptions.Visible = false;
	}

	void btnSearch_Click(object sender, EventArgs e)
	{
		FillTable();
	}

	#endregion

	#region Internal Implementation

	private void FillTable()
	{
		bool instDB = false;
		int maxCountRows = 20;
		int stockID = 0;
		int userID = 0; //!!

		if (txtRows.Text.Trim() != String.Empty)
		{
			try
			{
				maxCountRows = Convert.ToInt32(txtRows.Text.Trim());
				stockID = Convert.ToInt32(txtStockID.Text.Trim());
			}
			catch { }
		}

		DataTable dtStocks = null;

		try
		{
			dtStocks = Data.GetStocksWithBigPriceChange(userID, stockID, instDB, maxCountRows);
		}
		catch (Exception ex)
		{
			Label lblError = new Label();
			lblError.Text = ex.Message;

			pStocks.Controls.Add(lblError);
		}

		dgStocks.DataSource = dtStocks;
		dgStocks.DataBind();
	}

	#endregion
}
