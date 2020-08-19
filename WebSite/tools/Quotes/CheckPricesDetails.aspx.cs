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
using System.Globalization;
using am.Charts;

public partial class Investars_CheckPricesDetails : System.Web.UI.Page
{
	#region PreInit

	protected void Page_PreInit(Object sender, EventArgs e)
	{
		site_utils PageAttr = new site_utils();
		PageAttr.setPageAttr(this.Page);
	}

	#endregion

	#region Constants

	#endregion

	#region Properties

	private int UserID
	{
		get
		{
			if (Page.Session["UserId"] != null)
			{
				int userID = Convert.ToInt32(Page.Session["UserId"]);

				if (userID != -1)
					return userID;
			}

			return 0;
		}
	}

	protected int StockID
	{
		get
		{
			object oRezult = ViewState["StockID"];

			return oRezult != null ? Convert.ToInt32(oRezult) : 0;
		}
		set { ViewState.Add("StockID", value); }
	}

	#region Form content

	protected string BigChartsSymbol
	{
		get
		{
			object oRezult = ViewState["BigChartsSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("BigChartsSymbol", value); }
	}

	protected string BloombergSymbol
	{
		get
		{
			object oRezult = ViewState["BloombergSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("BloombergSymbol", value); }
	}

	protected string ReutersSymbol
	{
		get
		{
			object oRezult = ViewState["ReutersSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("ReutersSymbol", value); }
	}

	protected string YahooSymbol
	{
		get
		{
			object oRezult = ViewState["YahooSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("YahooSymbol", value); }
	}

	protected string BusinessWeekSymbol
	{
		get
		{
			object oRezult = ViewState["BusinessWeekSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("BusinessWeekSymbol", value); }
	}

	protected string GoogleSymbol
	{
		get
		{
			object oRezult = ViewState["GoogleSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("GoogleSymbol", value); }
	}

	protected string MsnSymbol
	{
		get
		{
			object oRezult = ViewState["MsnSymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("MsnSymbol", value); }
	}

	protected string MarketocracySymbol
	{
		get
		{
			object oRezult = ViewState["MarketocracySymbol"];

			return oRezult != null ? oRezult.ToString() : String.Empty;
		}
		set { ViewState.Add("MarketocracySymbol", value); }
	}

	#endregion

	#endregion

	#region Page Load

	protected void Page_Load(object sender, EventArgs e)
	{
		#region Add event handlers

		//btnSetFix.Click += new EventHandler(btnSetFix_Click);
		dgStocksForCheck.ItemDataBound += new DataGridItemEventHandler(dgStocksForCheck_ItemDataBound);

		#endregion

		if (!smMain.IsInAsyncPostBack)
		{
			if (Request.QueryString.HasKeys() && Request.QueryString["ID"] != null)
			{
				int stockID;

				if (int.TryParse(Request.QueryString["ID"], out stockID))
				{
					StockID = stockID;

					bool isInstDB = false;
					int maxRowCount = 100;

					DataTable dtInfo = Data.GetStocksWithBigPriceChange(UserID, StockID, isInstDB, maxRowCount);

					dgStocksForCheck.DataSource = dtInfo;

					DataTable dtStockInfo = Data.GetStockInfo(StockID);

					dgStockInfo.DataSource = dtStockInfo;

					if (dtInfo != null && dtInfo.Rows.Count > 0)
					{
						DataRow drInfo = dtInfo.Rows[0];

						DataTable dtSymbols = Data.GetStockSymbols(StockID);

						if (dtSymbols != null && dtSymbols.Rows.Count > 0)
						{
							DataRow drSymbols = dtSymbols.Rows[0];

							BigChartsSymbol = drSymbols["BigChartsSymbol"].ToString();
							BloombergSymbol = drSymbols["BloombergSymbol"].ToString();
							ReutersSymbol = drSymbols["ReutersSymbol"].ToString();
							YahooSymbol = drSymbols["YahooSymbol"].ToString();
							BusinessWeekSymbol = drSymbols["BusinessWeekSymbol"].ToString();
							GoogleSymbol = drSymbols["GoogleSymbol"].ToString();
							MsnSymbol = drSymbols["MsnSymbol"].ToString();
							MarketocracySymbol = drSymbols["MarketocracySymbol"].ToString();
						}

						CultureInfo culture = new CultureInfo("ru-RU");
						DateTime dateFrom = Convert.ToDateTime(drInfo["DateFrom"], culture);
						DateTime dateTo = Convert.ToDateTime(drInfo["DateTo"], culture);
						/*
						DataTable dtDividents = Data.GetStockDividents(StockID, dateFrom);

						if (dtDividents != null && dtDividents.Rows.Count > 0)
						{
							pDividents.Visible = true;
							dgDividents.DataSource = dtDividents;
						}
						else
						{
							pDividents.Visible = false;
						}
						*/
						DataTable dtPrices = Data.GetStockPrices(StockID, dateFrom.AddDays(-20), dateTo.AddDays(20));
						
						if (dtPrices != null && dtPrices.Rows.Count > 0)// && lcStock.Graphs.Count == 0)
						{
							if (lcStock.Graphs.Count > 0)
							{
								lcStock.Graphs.RemoveAt(1);
								lcStock.Graphs.RemoveAt(0);
							}

							lcStock.DataSource = dtPrices.DefaultView;

							lcStock.DataSeriesIDField = "DateTxt";
							//lcStock.DataSeriesValueField = "CloseAt";

							//CloseAt prices
							LineChartGraph gCloseAt = new LineChartGraph();

							gCloseAt.DataSource = dtPrices.DefaultView;
							gCloseAt.DataSeriesItemIDField = "DateTxt";
							gCloseAt.DataValueField = "CloseAt";
							gCloseAt.DataDescriptionField = "Dividend";
							gCloseAt.DataBulletSizeField = "DividendBulletSize";
							//gCloseAt.DataBulletColorField = "BulletColor";
							//gCloseAt.DataBulletUrlField = "BulletUrl";
							gCloseAt.Title = "CloseAt";

							gCloseAt.Bullet = LineChartBulletTypes.Round;
							gCloseAt.BulletSize = 0;
							gCloseAt.BulletColor = System.Drawing.Color.Green;

							//OpenAt prices
							LineChartGraph gOpenAt = new LineChartGraph();

							gOpenAt.DataSource = dtPrices.DefaultView;
							gOpenAt.DataSeriesItemIDField = "DateTxt";
							gOpenAt.DataValueField = "OpenAt";
							gOpenAt.Title = "OpenAt";

							lcStock.Graphs.Add(gCloseAt);
							lcStock.Graphs.Add(gOpenAt);

							lcStock.DataBind();
						}
					}
				}
			}
			DataBind();
		}
	}

	#endregion

	#region Button Handlers

	protected void lbtnSetFix_Command(object sender, CommandEventArgs e)
	{
		int erroOpenAtAnalystID = 0;

		Int32.TryParse(e.CommandArgument.ToString(), out erroOpenAtAnalystID);
		LinkButton lbFix = sender as LinkButton;

		if (erroOpenAtAnalystID > 0 && lbFix != null)
		{
			if (lbFix.Text != "Rem fix")
			{
				Data.SetPriceJumpFixed(erroOpenAtAnalystID);

				lbFix.Text = "Rem fix";
			}
			else
			{
				Data.SetPriceJumpNotFixed(erroOpenAtAnalystID);

				lbFix.Text = "Fix";
			}
			/*
			//Fill DataGrid
			int maxCountRows = 10;
			DataTable dtInfo = Data.GetStocksWithBigPriceChange(UserID, StockID, false, maxCountRows);

			dgStocksForCheck.DataSource = dtInfo;
			dgStocksForCheck.DataBind();*/
		}
		else
		{
			//Error
		}
	}

	#endregion

	void dgStocksForCheck_ItemDataBound(object sender, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			UpdatePanel upFix = e.Item.FindControl("upFix") as UpdatePanel;
			UpdateProgress prFix = e.Item.FindControl("prFix") as UpdateProgress;

			if (upFix != null && prFix != null)
			{
				prFix.AssociatedUpdatePanelID = upFix.ID;
			}
		}
	}
}
