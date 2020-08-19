using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Data
/// </summary>
public class Data
{
	public Data(){ }

	#region Alliance

	public static DataTable GetAllianceStocks(int stockID, int securityID, string ticker, string description, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[5];

		paramArray[0] = new SqlParameter("@InvestarsStockID", SqlDbType.Int, 4);
		paramArray[0].Value = stockID;

		paramArray[1] = new SqlParameter("@SecurityID", SqlDbType.Int, 4);
		paramArray[1].Value = securityID;

		paramArray[2] = new SqlParameter("@Ticker", SqlDbType.NVarChar, 10);
		paramArray[2].Value = ticker;

		paramArray[3] = new SqlParameter("@Description", SqlDbType.NVarChar, 250);
		paramArray[3].Value = description;

		paramArray[4] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[4].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_stocks", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetAllianceRatings(int securityID, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@SecurityID", SqlDbType.Int, 4);
		paramArray[0].Value = securityID;

		paramArray[1] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[1].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_ratings", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetAllianceCoverage(int securityID, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@SecurityID", SqlDbType.Int, 4);
		paramArray[0].Value = securityID;

		paramArray[1] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[1].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_coverage", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetAllianceConvictions(int securityID, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@SecurityID", SqlDbType.Int, 4);
		paramArray[0].Value = securityID;

		paramArray[1] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[1].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_convictions", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static int GetStockIDByAllianceSecurityID(int securityID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@SecurityID", SqlDbType.Int, 4);
		paramArray[0].Value = securityID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("acm_get_stockid_by_securityid", paramArray, "scalar");

		return Convert.ToInt32(rez);
	}

	public static DataTable GetAlliancePersonStocks(int personID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@PersonID", SqlDbType.Int, 4);
		paramArray[0].Value = personID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_person_stocks", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetAllianceIndexByPersonID(int personID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@PersonID", SqlDbType.Int, 4);
		paramArray[0].Value = personID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_person_index", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static void UpdateAllianceInvestarsStockID(int securityID, int investarsStockID)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@SecurityID", SqlDbType.Int, 4);
		paramArray[0].Value = securityID;

		paramArray[1] = new SqlParameter("@InvestarsStockID", SqlDbType.Int, 4);
		paramArray[1].Value = investarsStockID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_update_stock_investarsstockid", paramArray, "nonquery") as DataSet;
	}

	public static DataTable GetAllianceAnalystDailyReturns(int personID, int periodID)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@PersonID", SqlDbType.Int, 4);
		paramArray[0].Value = personID;

		paramArray[1] = new SqlParameter("@PeriodID", SqlDbType.Int, 4);
		paramArray[1].Value = periodID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_analyst_daily_returns", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetAllianceAnalystDailyReturns(int personID, int periodID, DateTime DateStart, DateTime DateEnd)
	{
		throw new NotImplementedException();
	}

	public static DataTable GetAllianceAnalystCummulativeReturnsJumps(int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[0].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("acm_get_analyst_cummulative_returns_jumps", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	#region Alerts

	public static DataTable GetAllianceAlerts()
	{
		SqlParameter[] paramArray = new SqlParameter[0];

		db_utils ndb_utils = new db_utils();

		DataSet dsAlerts = ndb_utils.get_db_Data("acm_get_alerts", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsAlerts);
	}

	public static void DeleteAllianceAlert(int alertID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@AlertID", SqlDbType.Int, 4);
		paramArray[0].Value = alertID;

		db_utils ndb_utils = new db_utils();

		ndb_utils.get_db_Data("acm_delete_alert", paramArray, "nonquery");
	}

	public static string getAllianceAlertText(int alertID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@AlertID", SqlDbType.Int, 4);
		paramArray[0].Value = alertID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("acm_get_alert_text", paramArray, "scalar");

		return rez.ToString();
	}

	public static void SendAlertToAlliance(int alertID, string alertEmails)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@AlertID", SqlDbType.Int, 4);
		paramArray[0].Value = alertID;

		paramArray[1] = new SqlParameter("@ToEmails", SqlDbType.VarChar, 1000);
		paramArray[1].Value = alertEmails;

		db_utils ndb_utils = new db_utils();

		ndb_utils.get_db_Data("acm_send_alert_to_alliance_by_alertid", paramArray, "nonquery");
	}

	#endregion

	#endregion

	#region Internal

	private static DataTable GetFirstTable(DataSet ds)
	{
		if (ds != null && ds.Tables.Count > 0)
		{
			return ds.Tables[0];
		}
		else
		{
			return null;
		}
	}

	public static void ShowError(Panel panel, Exception ex)
	{
		Label lblError = new Label();
		lblError.Text = ex.Message;

		panel.Controls.Add(lblError);
	}

	public static void ShowError(Panel panel, string message)
	{
		Label lblError = new Label();
		lblError.Text = message;

		panel.Controls.Add(lblError);
	}

	public static string GetEmailAddressesByGroupID(int groupID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@GroupID", SqlDbType.Int, 4);
		paramArray[0].Value = groupID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("tools_get_emails_by_groupid", paramArray, "scalar");

		return rez != null ? rez.ToString() : String.Empty;
	}

	#endregion

	#region Check Prices

	public static DataTable GetStocksWithBigPriceChange(int userID, int stockID, bool isInstDB, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[4];
		
		paramArray[0] = new SqlParameter("@UserID", SqlDbType.Int, 4);
		paramArray[0].Value = userID;

		paramArray[1] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[1].Value = stockID;

		paramArray[2] = new SqlParameter("@IsInstDB", SqlDbType.Int, 4);
		paramArray[2].Value = isInstDB;

		paramArray[3] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[3].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_stocks_with_big_price_change", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	/// <summary>
	/// Return stock symbols for different sites
	/// </summary>
	/// <param name="stockID">Stock ID from Quotes</param>
	/// <returns></returns>
	public static DataTable GetStockSymbols(int stockID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[0].Value = stockID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_stock_symbols", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetStockInfo(int stockID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[0].Value = stockID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_stock_info", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetStockPrices(int stockID, DateTime dateFrom, DateTime dateTo)
	{
		SqlParameter[] paramArray = new SqlParameter[3];

		paramArray[0] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[0].Value = stockID;

		paramArray[1] = new SqlParameter("@DateFrom", SqlDbType.DateTime, 4);
		paramArray[1].Value = dateFrom;

		paramArray[2] = new SqlParameter("@DateTo", SqlDbType.DateTime, 4);
		paramArray[2].Value = dateTo;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_stock_prices", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static void SetPriceJumpFixed(int erroOpenAtAnalystID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@ErroOpenAtAnalystID", SqlDbType.Int, 4);
		paramArray[0].Value = erroOpenAtAnalystID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_set_price_jump_fixed", paramArray, "DataSet") as DataSet;
	}

	public static void SetPriceJumpNotFixed(int erroOpenAtAnalystID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@ErroOpenAtAnalystID", SqlDbType.Int, 4);
		paramArray[0].Value = erroOpenAtAnalystID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_set_price_jump_remove_fixed", paramArray, "DataSet") as DataSet;
	}

	#endregion

	#region Ratings

	public static DataTable GetInvestarsRatings(int stockID, int analystID, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[3];

		paramArray[0] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[0].Value = stockID;

		paramArray[1] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[1].Value = analystID;

		paramArray[2] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[2].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_ratings", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static DataTable GetRatings(string ratingID, string analystID, string stockID, string symbol,
		string personID, string personName, string termID, string date, bool allColumns, int maxRowCount)
	{
		SqlParameter[] paramArray = new SqlParameter[10];

		paramArray[0] = new SqlParameter("@RatingID", SqlDbType.VarChar, 250);
		paramArray[0].Value = ratingID;

		paramArray[1] = new SqlParameter("@AnalystID", SqlDbType.VarChar, 250);
		paramArray[1].Value = analystID;

		paramArray[2] = new SqlParameter("@StockID", SqlDbType.VarChar, 250);
		paramArray[2].Value = stockID;

		paramArray[3] = new SqlParameter("@Symbol", SqlDbType.VarChar, 250);
		paramArray[3].Value = symbol;

		paramArray[4] = new SqlParameter("@PersonID", SqlDbType.VarChar, 250);
		paramArray[4].Value = personID;

		paramArray[5] = new SqlParameter("@PersonName", SqlDbType.VarChar, 250);
		paramArray[5].Value = personName;

		paramArray[6] = new SqlParameter("@TermID", SqlDbType.VarChar, 250);
		paramArray[6].Value = termID;

		paramArray[7] = new SqlParameter("@Date", SqlDbType.VarChar, 250);
		paramArray[7].Value = date;

		paramArray[8] = new SqlParameter("@AllColumns", SqlDbType.Bit, 1);
		paramArray[8].Value = allColumns;

		paramArray[9] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[9].Value = maxRowCount;

		db_utils ndb_utils = new db_utils();

		DataSet dsRatings = ndb_utils.get_db_Data("tools_get_ratings_by_criteria", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsRatings);
	}

	public static void UpdateRating(int userID, int actionID, int ratingID, int analystID, int analystAliasID, int stockID,
								int personID, string date, int termID, int termAliasID, string comment)
	{
		SqlParameter[] paramArray = new SqlParameter[11];

		paramArray[0] = new SqlParameter("@UserID", SqlDbType.Int, 4);
		paramArray[0].Value = userID;

		paramArray[1] = new SqlParameter("@ActionID", SqlDbType.Int, 4);
		paramArray[1].Value = actionID;

		paramArray[2] = new SqlParameter("@RatingID", SqlDbType.Int, 4);
		paramArray[2].Value = ratingID;

		paramArray[3] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[3].Value = analystID;

		paramArray[4] = new SqlParameter("@AnalystAliasID", SqlDbType.Int, 4);
		paramArray[4].Value = analystAliasID;

		paramArray[5] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[5].Value = stockID;

		paramArray[6] = new SqlParameter("@PersonID", SqlDbType.Int, 4);
		paramArray[6].Value = personID;

		paramArray[7] = new SqlParameter("@Date", SqlDbType.Int, 4);
		paramArray[7].Value = date;

		paramArray[8] = new SqlParameter("@TermID", SqlDbType.Int, 4);
		paramArray[8].Value = termID;

		paramArray[9] = new SqlParameter("@TermAliasID", SqlDbType.Int, 4);
		paramArray[9].Value = termAliasID;

		paramArray[10] = new SqlParameter("@Comment", SqlDbType.Int, 4);
		paramArray[10].Value = comment;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_update_ratig", paramArray, "nonquery") as DataSet;
	}

	#endregion

	#region Analyst Persons

	public static DataTable GetAnalystPersons(int analystID, string personIDs, string moveIDs, string personName, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[5];

		paramArray[0] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[0].Value = analystID;

		paramArray[1] = new SqlParameter("@PersonIDs", SqlDbType.VarChar, 250);
		paramArray[1].Value = personIDs;

		paramArray[2] = new SqlParameter("@MoveIDs", SqlDbType.VarChar, 250);
		paramArray[2].Value = moveIDs;

		paramArray[3] = new SqlParameter("@PersonName", SqlDbType.VarChar, 250);
		paramArray[3].Value = personName;

		paramArray[4] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[4].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_persons", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static string GetPersonNameByID(int personID, int analystID)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@PersonID", SqlDbType.Int, 4);
		paramArray[0].Value = personID;

		paramArray[1] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[1].Value = analystID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("tools_get_person_name_by_id", paramArray, "scalar");

		return rez != null ? rez.ToString() : "n/a";
	}

	#endregion

	#region Stocks

	public static DataTable getStocks(string stockIDs, string instDBStockIDs, string symbol, string name, string exchange, string countryCode, int maxCountRows)
	{
		SqlParameter[] paramArray = new SqlParameter[7];

		paramArray[0] = new SqlParameter("@StockIDs", SqlDbType.VarChar, 250);
		paramArray[0].Value = stockIDs;

		paramArray[1] = new SqlParameter("@InstDBStockIDs", SqlDbType.VarChar, 250);
		paramArray[1].Value = instDBStockIDs;

		paramArray[2] = new SqlParameter("@Symbol", SqlDbType.VarChar, 250);
		paramArray[2].Value = symbol;

		paramArray[3] = new SqlParameter("@Name", SqlDbType.VarChar, 250);
		paramArray[3].Value = name;

		paramArray[4] = new SqlParameter("@Exchange", SqlDbType.VarChar, 250);
		paramArray[4].Value = exchange;

		paramArray[5] = new SqlParameter("@CountryCode", SqlDbType.VarChar, 250);
		paramArray[5].Value = countryCode;

		paramArray[6] = new SqlParameter("@MaxCountRows", SqlDbType.Int, 4);
		paramArray[6].Value = maxCountRows;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("quo_get_stocks", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static string GetStockNameByID(int stockID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@StockID", SqlDbType.Int, 4);
		paramArray[0].Value = stockID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("tools_get_stock_name_by_id", paramArray, "scalar");

		return rez != null ? rez.ToString() : "n/a";
	}

	#endregion

	#region Analysts

	public static DataTable GetAnalystByAnalystID(int analystID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[0].Value = analystID;

		db_utils ndb_utils = new db_utils();

		DataSet dsAnalysts = ndb_utils.get_db_Data("tools_get_analyst_by_analyst_id", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsAnalysts);
	}

	public static string GetAnalystNameByAnalystAliasID(int analystAliasID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@AnalystAliasID", SqlDbType.Int, 4);
		paramArray[0].Value = analystAliasID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("tools_get_analyst_name_by_analyst_alias_id", paramArray, "scalar");

		return rez != null ? rez.ToString() : String.Empty;
	}

	public static DataTable GetAnalystTermsByAnalystAliasID(int analystAliasID)
	{
		SqlParameter[] paramArray = new SqlParameter[1];

		paramArray[0] = new SqlParameter("@AnalystAliasID", SqlDbType.Int, 4);
		paramArray[0].Value = analystAliasID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_analyst_terms_by_analyst_alias_id", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	public static object GetTermIDByTermAliasID(int termAliasID, int analystID)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@TermAliasID", SqlDbType.Int, 4);
		paramArray[0].Value = termAliasID;

		paramArray[1] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[1].Value = analystID;

		db_utils ndb_utils = new db_utils();

		object rez = ndb_utils.get_db_Data("tools_get_term_id_by_term_alias_id", paramArray, "scalar");

		return rez != null && rez != DBNull.Value ? Convert.ToInt32(rez) : 0;
	}

	public static object GetAnalystTermsByAnalystID(int analystID, int ratingID)
	{
		SqlParameter[] paramArray = new SqlParameter[2];

		paramArray[0] = new SqlParameter("@AnalystID", SqlDbType.Int, 4);
		paramArray[0].Value = analystID;

		paramArray[1] = new SqlParameter("@RatingID", SqlDbType.Int, 4);
		paramArray[1].Value = ratingID;

		db_utils ndb_utils = new db_utils();

		DataSet dsStocks = ndb_utils.get_db_Data("tools_get_analyst_terms_by_analyst_id", paramArray, "DataSet") as DataSet;

		return GetFirstTable(dsStocks);
	}

	#endregion

	#region Constants

	public static class Constants
	{
		public const int AllianceGroupID = 119;

		public static class Analysts
		{
			public const int Alliance = 1227;
		}

		public static class Colors
		{
			public const string GreenCell = "#66cc66";
			public const string YellowCell = "#cccc66";
			public const string RedCell = "#cc6666";
		}
	}

	#endregion
}
