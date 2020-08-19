using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
   
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(this.Page);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
               db_utils ndb_utils = new db_utils();
               SqlDataReader suppteam_table;
               suppteam_table = (SqlDataReader)ndb_utils.get_db_Data("EXEC support_team_get_members @UserId = " + Session["UserId"].ToString() + ", @InformationType=1", null, "Reader");
               if (suppteam_table.HasRows)
               {
                   HtmlTable newTable = new HtmlTable();
                   newTable.Attributes.Add("class", "GridView");
                   newTable.CellSpacing = 1;
                   newTable.CellPadding = 3;
                   newTable.Border = 0;
                   int j = 0;
                   while (suppteam_table.Read())
                   {
                       if (j != 0)
                       {
                           HtmlTableRow delRow = new HtmlTableRow();
                           delRow.Attributes.Add("class", "FrameColor");
                           delRow.Cells.Add(new HtmlTableCell());
                           delRow.Cells[0].ColSpan = 3;
                           delRow.Cells[0].Controls.Add(new LiteralControl("&nbsp;"));
                           newTable.Rows.Add(delRow);
                       }
                       j++;
                       for (int i = 0; i < suppteam_table.FieldCount - 1; i++)
                       {

                           HtmlTableRow newRow = new HtmlTableRow();
                           newRow.Attributes.Add("class", "GridView");

                           if (i == 0)
                           {
                               HtmlTableCell newCellImg = new HtmlTableCell();
                               newCellImg.RowSpan = suppteam_table.FieldCount - 1;
                               newCellImg.VAlign = "center";
                               HtmlImage newImg = new HtmlImage();
                               newImg.Src = ResolveUrl(suppteam_table["ImagePath"].ToString().Trim());
                               newImg.Width = 80;
                               newImg.Height = 100;
                               newCellImg.Controls.Add(newImg);
                               newRow.Cells.Add(newCellImg);
                           }

                           HtmlTableCell newCell = new HtmlTableCell();
                           newCell.Attributes.Add("class", "GridViewHead");
                           newCell.Align = "right";
                           newCell.Controls.Add(new LiteralControl(suppteam_table.GetName(i).ToString() + ":"));
                           newRow.Cells.Add(newCell);

                           HtmlTableCell newCellV = new HtmlTableCell();
                           newCellV.Attributes.Add("class", "GridView");
                           newCellV.VAlign = "left";
                           newCellV.Controls.Add(new LiteralControl(suppteam_table[i].ToString()));
                           newRow.Cells.Add(newCellV);
                           newTable.Rows.Add(newRow);
                       }

                   }
                   suppteam_td.Controls.Add(newTable);
               }
    }

    protected void GoButton_Click(object sender, EventArgs e)
    {
        if (messTextBox.Text != "")
        {
            SqlParameter[] paramArray = new SqlParameter[3];
            SqlParameter param0 = new SqlParameter("@UserId", SqlDbType.Int, 4);
            param0.Value = (int)Session["UserId"];
            paramArray[0] = param0;

            SqlParameter param1 = new SqlParameter("@MemberId", SqlDbType.Int, 4);
            param1.Value = Convert.ToInt32(DropDown_send_to.getDropDownValue());
            paramArray[1] = param1;

            SqlParameter param2 = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
            String tmpValue = messTextBox.Text.ToString();

            if (tmpValue.Length > 100)
            {
                tmpValue = tmpValue.Substring(1, 100);
            }
            param2.Value = tmpValue;
            paramArray[2] = param2;

            db_utils ndb_utils = new db_utils();
            ndb_utils.get_db_Data("support_team_send_sms", paramArray, "nonquery");
            messTextBox.Text = "";
            messStatus.InnerText = "The message was sent. Thank you!";
        }
        else 
        {
            messStatus.InnerText = "";
        }

    }
    protected void messTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}
