using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TOOLS_Quotes_StocksWork : System.Web.UI.Page
{
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
		#region Add Evant Handlers

		btnSearch.Click += new EventHandler(btnSearch_Click);
		lbtnLincks.Command += new CommandEventHandler(lbtnLincks_Command);

		#endregion
	}

	#endregion

	#region Button Handlers

	void btnSearch_Click(object sender, EventArgs e)
	{
		string stockIDs = txtStockID.Text.Trim();
		string instDBStockIDs = txtInstDBStockID.Text.Trim();
		string symbol = txtSymbol.Text.Trim();
		string name = txtName.Text;
		string exchange = txtExchange.Text.Trim();
		string countryCode = txtCountryCode.Text.Trim();

		int maxCountRows = 100;

		SearchStock(stockIDs, instDBStockIDs, symbol, name, exchange, countryCode, maxCountRows);
	}

	private void lbtnLincks_Command(object sender, CommandEventArgs e)
	{
		pLincks.Visible = true;

		int stockID = Convert.ToInt32(e.CommandArgument);

		ucStockLinks.FillLinks(stockID);
	}

	protected void lbtnStockID_Command(object sender, CommandEventArgs e)
	{
		string stockIDs = e.CommandArgument.ToString();
		string instDBStockIDs = String.Empty;
		string symbol = String.Empty;
		string name = String.Empty;
		string exchange = String.Empty;
		string countryCode = String.Empty;

		int maxCountRows = 100;

		SearchStock(stockIDs, instDBStockIDs, symbol, name, exchange, countryCode, maxCountRows);
	}

	#endregion

	#region Internal Implementation

	private void SearchStock(string stockIDs, string instDBStockIDs, string symbol, string name, string exchange, string countryCode, int maxCountRows)
	{
		DataTable dtStocks = null;

		try
		{
			dtStocks = Data.getStocks(stockIDs, instDBStockIDs, symbol, name, exchange, countryCode, maxCountRows);
		}
		catch (Exception ex)
		{
			Label lblError = new Label();
			lblError.Text = ex.Message;

			pInfo.Controls.Add(lblError);
		}

		if (dtStocks != null && dtStocks.Rows.Count == 1)
		{
			pOptions.Visible = true;

			lbtnLincks.CommandArgument = dtStocks.Rows[0]["ID"].ToString();
		}
		else
		{
			pOptions.Visible = false;
		}

		if (!cbAllColumns.Checked)
		{
			gvStocks.Visible = true;
			gvStocksAllColumns.Visible = false;
			gvStocks.DataSource = dtStocks;
			gvStocks.DataBind();
		}
		else
		{
			gvStocks.Visible = false;
			gvStocksAllColumns.Visible = true;
			gvStocksAllColumns.DataSource = dtStocks;
			gvStocksAllColumns.DataBind();
		}

		//Hide info panels
		pLincks.Visible = false;
	}

	#endregion
}
