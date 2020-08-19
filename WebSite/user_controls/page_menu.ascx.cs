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
using System.Drawing;

public partial class include_page_menu : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
        {
            DataSet MenuDateSet = (DataSet)Session["MenuDataSet"];
            int userId = (int)Session["UserId"];

            site_utils nsite_utils = new site_utils();
            if (MenuDateSet == null)
            {
                Session["MenuDataSet"] = nsite_utils.getMenuDataSet(userId);
                MenuDateSet = (DataSet)Session["MenuDataSet"];
            }
            nsite_utils.setUserMenu(this.Page, main_top_menu, MenuDateSet, userId);
        }

        if (main_top_menu.Items.Count != 0)
        {
            string mvp = (string)Session["mvp"];

            if (mvp != null)
            {
                if (main_top_menu.FindItem(mvp).Selectable)
                {
                    main_top_menu.FindItem(mvp).Selected = true;
                }
            }
            setSiteMapObject(Page.Master.FindControl("map_panel"), getSiteMapArray());
        }
        else
        {
            Label newLbl = new Label();
            newLbl.ID = "newLbl";
            newLbl.Text = "We are sorry, but no any menu configuration settings for the current user.";
            Page.Master.FindControl("map_panel").Controls.Add(newLbl);
        }
      
    }


    protected void main_top_menu_MenuItemClick(object sender, MenuEventArgs e)
    {
        Session["mvp"] = main_top_menu.SelectedItem.ValuePath.ToString();
        Response.Redirect(main_top_menu.SelectedItem.Value.ToString());
    }


    public String[,] getSiteMapArray()
    {
        site_utils nsite_utils = new site_utils();
        String[,] siteMapArray = new String[nsite_utils.getSiteMapPath(main_top_menu, main_top_menu.SelectedItem).GetUpperBound(0) + 1, 2];
        siteMapArray = nsite_utils.getSiteMapPath(main_top_menu, main_top_menu.SelectedItem);
        return siteMapArray;
    }

    protected void setSiteMapObject(Control setSiteMapTo, String[,] siteMapArray)
    {
        setSiteMapTo.Controls.Clear();
        for (int i = 0; i <= siteMapArray.GetUpperBound(0); i++)
        {
            LinkButton newLB = new LinkButton();
            newLB.ID = "newLB" + i.ToString();
            newLB.Text = siteMapArray[i, 0].ToString();
            newLB.Click += new EventHandler(newLB_Click);
            newLB.CommandName = siteMapArray[i, 1].ToString();
            newLB.CommandArgument = siteMapArray[i, 2].ToString();
            if (!main_top_menu.FindItem(siteMapArray[i, 2].ToString()).Selectable)
            {
                newLB.Enabled = false;
            }
            
            newLB.CssClass = "MapLine";
            setSiteMapTo.Controls.Add(newLB);
            if (siteMapArray.GetUpperBound(0) > 0 && i < siteMapArray.GetUpperBound(0)) 
            {
                Label newLbl = new Label();
                newLbl.ID = "newLbl" + i.ToString();
                newLbl.Text = " : ";
                setSiteMapTo.Controls.Add(newLbl);
            }
        }
    }

    void newLB_Click(object sender, EventArgs e)
    {
        LinkButton lb = new LinkButton();
        lb = (LinkButton)sender;
        Session["mvp"] = lb.CommandArgument.ToString();
        Response.Redirect(lb.CommandName.ToString());
    }






}
