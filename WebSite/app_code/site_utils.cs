using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// -----------------------------------
/// Please contact if any questions to:
/// Vitaly Kuleshov 
/// e-mail: vkuleshov@biz.by 
/// phone : +375296430929 
/// Belarus, Mogilev
/// Start Date: 15-Nov-2007
/// ----------------------------------
/// <summary>
/// This class sets pages attributes and so on...
/// </summary>
public class site_utils
{
    public string getSitePage(string currPage)
    {
        // getting the only page name
        currPage = currPage.Substring(currPage.LastIndexOf("/") + 1);
        if (currPage.LastIndexOf("?") != -1)
        {
            currPage = currPage.Remove(currPage.LastIndexOf("?"));
        }
        return currPage.ToLower().Trim();
    }

    protected void fillProfilePagesArray(Page cPage) 
    {
        if (cPage.Session["profilePages"] == null)
        {
            db_utils ndb_utils = new db_utils();
            int tmpCount = (int)ndb_utils.get_db_Data("EXEC site_set_page_attributes @UserId = " + cPage.Session["UserId"].ToString(), null, "Scalar");
            if (tmpCount == 0) { return; }
            string[,] profilePages = new string[tmpCount, 4];
            SqlDataReader reader = ndb_utils.get_db_Data("EXEC site_set_page_attributes @UserId = " + cPage.Session["UserId"].ToString(), null, "Reader") as SqlDataReader;
            int i = 0;
            while (reader.Read())
            {
                profilePages[i, 0] = reader["PageName"].ToString();
                profilePages[i, 1] = reader["PageTitle"].ToString();
                profilePages[i, 2] = reader["MasterPage"].ToString();
                profilePages[i, 3] = reader["CSSPage"].ToString();
                i++;
            }
            cPage.Session["profilePages"] = profilePages;
        }
    }

    public void setPageAttr(Page mPage)
    {
        if ((int)mPage.Session["UserId"] == -1)
        {
            mPage.Response.Redirect("~/login.aspx?goBackTo=" + mPage.Server.UrlEncode(mPage.Request.RawUrl));
            return;
        }

        if (mPage.Session["profilePages"] == null) 
        {
            fillProfilePagesArray(mPage);
        }

        string currPage = this.getSitePage(mPage.Request.RawUrl);
        string[,] tmpArray = (string[,])mPage.Session["profilePages"];
        int accessFlag = 0;
        if (tmpArray == null)
        {
            mPage.Response.Redirect("~/site_messages.aspx?mess=npasftu");
        }
        else
        {
            for(int i = 0; i <= tmpArray.GetUpperBound(0); i++)
            {
                if (tmpArray[i, 0].ToString() == currPage) 
                {
                    accessFlag = 1;
                    // set title of the current page
                    mPage.Title = tmpArray[i, 1].ToString();
                    // set master page for the current page
                    mPage.MasterPageFile = tmpArray[i, 2].ToString();
                    // set css file for the current page
                    
                    HtmlLink myCSSLink = new HtmlLink();
                    myCSSLink.Href = tmpArray[i, 3].ToString();
                    myCSSLink.Attributes.Add("rel", "stylesheet");
                    myCSSLink.Attributes.Add("type", "text/css");
                    mPage.Master.FindControl("mpheader").Controls.Add(myCSSLink);
                    LiteralControl scryptLiteral = new LiteralControl("<script language=\"javascript\" type=\"text/javascript\" src=\"" + mPage.ResolveUrl("~/js_sources/main.js") + "\"></script>");
                    mPage.Master.FindControl("mpheader").Controls.Add(scryptLiteral);
                }
            }
            if (accessFlag == 0)
            {
                mPage.Response.Redirect("~/site_messages.aspx?mess=naftp");
            }
        }
    }

    public DataSet getMenuDataSet(int userId)
    {
        SqlParameter[] paramArray = new SqlParameter[1];
        SqlParameter param1 = new SqlParameter("@UserId", SqlDbType.Int, 4);
        param1.Value = userId;
        paramArray[0] = param1;

        db_utils ndb_utils = new db_utils();   
        return ndb_utils.get_db_Data("site_get_menu_pages", paramArray, "DataSet") as DataSet;
    }

    public void setUserMenu(Page mPage, Menu myMenu, DataSet MenuDataSet, int userId) 
    {
        if (MenuDataSet == null)
        {
            MenuDataSet = getMenuDataSet(userId);
        }
        if ((int)MenuDataSet.Tables[0].Rows.Count == 0)
        {
            return;
        }

        myMenu.Items.Clear();
        int totalItems = (int)MenuDataSet.Tables[0].Rows.Count;
        Object[,] parentArray = new Object[totalItems, 2];
        int j = 0;
        for (int i = 1; i <= (int) MenuDataSet.Tables[0].Rows[0]["LevelCount"]; i++)
        {
            DataRow[] arrayRows = MenuDataSet.Tables[0].Select("MenuLevelId = " + i.ToString());
            foreach (DataRow row in arrayRows) 
                {
                    MenuItem newItem = new MenuItem();
                    newItem.Text = row["Title"].ToString();
                    newItem.Value = row["Url"].ToString();
                
                    if (row["ShowUrl"].ToString() == "N")
                    {
                        newItem.Selectable = false;
                    }

                    if ((row["LastItem"].ToString() == "Y") && (row["PageName"].ToString() == this.getSitePage(mPage.Request.RawUrl)))
                    {
                        newItem.Selected = true;
                    }

                    if ((row["LastItem"].ToString() == "Y") && (row["PageEnabled"].ToString() != "Y"))
                    {
                        newItem.Enabled = false;
                    }

                    MenuItem parentItem = null;
                    for (int m = 0; m <= totalItems-1; m++)
                    {
                        if ((String) parentArray[m, 0] == (row["ParentMenuLevelId"].ToString() + "|" + row["ParentPageId"].ToString()))
                        {
                            parentItem = (MenuItem) parentArray[m, 1];
                        }
                    }

                    if (parentItem != null)
                    {
                        parentItem.ChildItems.Add(newItem);
                    }
                    else
                    {
                        myMenu.Items.Add(newItem);
                    }
                    parentArray[j, 0] = row["MenuLevelId"].ToString() + "|" + row["PageId"].ToString();
                    parentArray[j, 1] = newItem;

                    j++;
                }
        }
    }


    public String[,] getSiteMapPath(Menu myMenu, MenuItem selectedItem)
    {
        if (selectedItem == null)
        {
            selectedItem = myMenu.Items[0];
        }

        int selectedLevel = selectedItem.Depth +1;
        
        String[,] pathArray = new String[selectedLevel, 3];
        
        int i = 1;
        do
            {
                pathArray[selectedLevel-i, 0] = selectedItem.Text.ToString();
                pathArray[selectedLevel-i, 1] = selectedItem.Value.ToString();
                pathArray[selectedLevel-i, 2] = selectedItem.ValuePath.ToString();
                i++;
                selectedItem = selectedItem.Parent;
            }
        while (selectedItem != null);
        return pathArray;
    }


    // Adding real controls name into DOM of the page
    public void RegisterClientId(Page p, Control c)
    {
        if (c.ID != null && c.ID.Length > 0)
        {
            p.ClientScript.RegisterStartupScript(this.GetType(), "_clientIdsInit", "var _clientIds = new Array();", true);
            string clientID = string.Format("\t_clientIds['{0}'] = '{1}';\n", c.ID, c.ClientID);
            p.ClientScript.RegisterStartupScript(this.GetType(), c.ClientID, clientID, true);
        }
    } 


}
