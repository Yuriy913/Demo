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

public partial class Clients_Alliance_CheckAlliancePerson : System.Web.UI.Page
{
	#region Page PreInit

	protected void Page_PreInit(Object sender, EventArgs e)
	{
		site_utils PageAttr = new site_utils();
		PageAttr.setPageAttr(this.Page);
	}

	#endregion

	#region Page Load

	protected void Page_Load(object sender, EventArgs e)
	{
		#region Add event handlers

		btnSearch.Click += new EventHandler(btnSearch_Click);

		gvPersons.RowCreated += new GridViewRowEventHandler(gvPersons_RowCreated);

		#endregion
	}

	#endregion

	#region Button Handlers

	void btnSearch_Click(object sender, EventArgs e)
	{
		string personIDs = txtPersonID.Text.Trim();
		string moveIDs = txtAnalystID.Text.Trim();
		string personName = txtName.Text.Trim();

		int maxCountRows = 20; //!!

		FillResults(personIDs, moveIDs, personName, maxCountRows);
	}

	protected void lbtnPerson_Command(object sender, CommandEventArgs e)
	{
		string personIDs = e.CommandArgument.ToString();
		string moveIDs = string.Empty;
		string personName = string.Empty;

		int maxCountRows = 20; //!!

		FillResults(personIDs, moveIDs, personName, maxCountRows);
	}

	#endregion

	void gvPersons_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string show = string.Empty;

			if (((DataRowView)e.Row.DataItem)["Show"] != DBNull.Value)
			{
				show = ((DataRowView)e.Row.DataItem)["Show"].ToString();
			}

			if (show.Equals("n") || show.Equals("N"))
			{
				e.Row.Cells[4].Style.Add("background-color", "#FF9090");
			}
		}
	}

	#region Internal Implementation

	private void FillResults(string personIDs, string moveIDs, string personName, int maxCountRows)
	{

		DataTable dtPersons = null;

		try
		{
			int analystID = Data.Constants.Analysts.Alliance;

			dtPersons = Data.GetAnalystPersons(analystID, personIDs, moveIDs, personName, maxCountRows);
		}
		catch (Exception ex)
		{
			Data.ShowError(pResults, ex);
		}

		gvPersons.DataSource = dtPersons;
		gvPersons.DataBind();

		if (dtPersons != null && dtPersons.Rows.Count == 1)
		{
			int personID = Convert.ToInt32(dtPersons.Rows[0]["ID"]);

			pInfo.Visible = true;

			DataTable dtIndex = null;

			try
			{
				dtIndex = Data.GetAllianceIndexByPersonID(personID);
			}
			catch (Exception ex)
			{
				Data.ShowError(pResults, ex);
			}

			dvIndex.DataSource = dtIndex;
			dvIndex.DataBind();

			#region Get covered stocks

			DataTable dtStocks = null;

			try
			{
				dtStocks = Data.GetAlliancePersonStocks(personID);
			}
			catch (Exception ex)
			{
				Data.ShowError(pResults, ex);
			}

			gvStocks.DataSource = dtStocks;
			gvStocks.DataBind();

			#endregion
		}
		else
		{
			pInfo.Visible = false;
		}
	}

	#endregion
}
