using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class USER_CONTROLS_StockLinks : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public void FillLinks(int stockID)
	{
		DataTable dtSymbols = null;

		try
		{
			dtSymbols = Data.GetStockSymbols(stockID);
		}
		catch (Exception ex)
		{
			Data.ShowError(pLinks, ex);
		}

		if (dtSymbols != null && dtSymbols.Rows.Count > 0)
		{
			DataRow drSymbols = dtSymbols.Rows[0];

			string bigChartsSymbol = drSymbols["BigChartsSymbol"].ToString();
			string bloombergSymbol = drSymbols["BloombergSymbol"].ToString();
			string reutersSymbol = drSymbols["ReutersSymbol"].ToString();
			string yahooSymbol = drSymbols["YahooSymbol"].ToString();
			string businessWeekSymbol = drSymbols["BusinessWeekSymbol"].ToString();
			string googleSymbol = drSymbols["GoogleSymbol"].ToString();
			string msnSymbol = drSymbols["MsnSymbol"].ToString();
			string marketocracySymbol = drSymbols["MarketocracySymbol"].ToString();

			hlBigCharts.Text = String.Format("BigCharts ({0})", bigChartsSymbol);
			hlBigCharts.NavigateUrl = String.Format("http://bigcharts.marketwatch.com/interchart/interchart.asp?symb={0}", bigChartsSymbol);

			hlBloomberg.Text = String.Format("Bloomberg ({0})", bloombergSymbol);
			hlBloomberg.NavigateUrl = String.Format("http://www.bloomberg.com/apps/cbuilder?ticker1={0}", bloombergSymbol);

			hlRreuters.Text = String.Format("Reuters ({0})", reutersSymbol);
			hlRreuters.NavigateUrl = String.Format("http://www.reuters.com/finance/stocks/chart?symbol={0}", reutersSymbol);

			hlYahoo.Text = String.Format("Yahoo ({0})", yahooSymbol);
			hlYahoo.NavigateUrl = String.Format("http://finance.yahoo.com/echarts?s={0}#chart4:symbol={0};range=3m;indicator=split+dividend+volume;charttype=line;crosshair=on;ohlcvalues=0;logscale=on;source=undefined", yahooSymbol);

			hlBusinessWeek.Text = String.Format("BusinessWeek ({0})", businessWeekSymbol);
			hlBusinessWeek.NavigateUrl = String.Format("http://investing.businessweek.com/research/stocks/charts/charts.asp?symbol={0}", businessWeekSymbol);

			hlGoogle.Text = String.Format("Google ({0})", googleSymbol);
			hlGoogle.NavigateUrl = String.Format("http://finance.google.com/finance?q={0}", googleSymbol);

			hlMsn.Text = String.Format("Msn ({0})", msnSymbol);
			hlMsn.NavigateUrl = String.Format("http://moneycentral.msn.com/detail/stock_quote?Symbol={0}", msnSymbol);

			hlMarketocracy.Text = String.Format("Marketocracy ({0})", marketocracySymbol);
			hlMarketocracy.NavigateUrl = String.Format("http://www.marketocracy.com/cgi-bin/WebObjects/Portfolio.woa/ps/StockGraphPage?symbol={0}", marketocracySymbol);
		}
	}
}
