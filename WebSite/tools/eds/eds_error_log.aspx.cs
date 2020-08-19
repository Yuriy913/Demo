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
using System.Data.SqlClient;
using System.IO;

public partial class tools_eds_eds_error_log : System.Web.UI.Page
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(this.Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string errorLogFilePath = "";
        ErrorMessage.Text = "";
        int ShowErrorsNumber = 1;
        db_utils ndb_utils = new db_utils();
        SqlDataReader reader = ndb_utils.get_db_Data("EXEC eds_get_settings", null, "Reader") as SqlDataReader;
        reader.Read();
        ServerName.Text = reader["ServerName"].ToString();
        ErroLogPath.Text = reader["ErrorLogPath"].ToString();
        errorLogFilePath = @reader["ErrorLogPath"].ToString() + "error_log.txt";

        if (ErrorsNumber.Text != "")
        {
            try
            {
                ShowErrorsNumber = Convert.ToInt32(ErrorsNumber.Text);
            }
            catch (Exception exc)
            {
                ErrorMessage.Text = exc.Message.ToString();
                return;
            }

        }

        FileStream fs;
        try
        {
            fs = new FileStream(errorLogFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        catch (Exception exc)
        {
            ErrorMessage.Text = exc.Message.ToString();
            return;
        }

        try
        {
            StreamReader sr = new StreamReader(fs);
            string s;
            int sr_count = 0;
            HtmlTable newTable = new HtmlTable();
            newTable.Attributes.Add("class", "GridView");
            newTable.CellSpacing = 0;
            newTable.CellPadding = 3;
            newTable.Border = 0;
            newTable.Width = "100%";

            while ((s = sr.ReadLine()) != null)
            {
                if (s.Substring(0, 1) == "[")
                {
                    sr_count++;
                }
                
            }

            TotalErrors.Text = sr_count.ToString();
            sr.BaseStream.Position = 0;

            int i = 0, flag=0;
            if (ShowErrorsNumber < sr_count)
            {
                sr_count = sr_count - ShowErrorsNumber;
            }
            else
            {
                sr_count = 0;
            }

            while ((s = sr.ReadLine()) != null)
            {

                if ((i >= sr_count)&&(s.Substring(0, 1) == "[")) {flag = 1;}

                if ((i >= sr_count)&&(flag==1))
                {
                HtmlTableRow newRow = new HtmlTableRow();
                HtmlTableCell newCell = new HtmlTableCell();
                newCell.VAlign = "left";
                if ((s.Length != 0) && (s != null))
                {
                    if ((s.Substring(0, 1) == "[") || (s.Substring(0, 1) == "<") || (s.Substring(0, 1) == "-"))
                    {
                        newCell.Style.Add("font-weight", "bold");
                        newCell.Style.Add("font-size", "11px");
                    }
                }
                newCell.Controls.Add(new LiteralControl(s));
                newRow.Cells.Add(newCell);
                newTable.Rows.Add(newRow);
                }
                if (s.Substring(0, 1) == "[")
                {
                    i++;
                }
            }
            sr.Close();
            ResultText.Controls.Add(newTable);
        }
        catch (Exception exc)
        {
            ErrorMessage.Text = exc.Message.ToString();
            return;
        }
    }
}
