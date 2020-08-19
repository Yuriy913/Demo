using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public class control_utils
{

    public void setMenuStyle(ref Menu oMenu, int styleType)
    {
        switch (styleType)
        {
            case 1: //Yuri's Type of menu. Please don't change an attributions of this section.
                oMenu.Orientation = Orientation.Horizontal;
                oMenu.BackColor = ColorTranslator.FromHtml("#B5C7DE");
                oMenu.DynamicHorizontalOffset=2;
                oMenu.Font.Name = "Verdana";
                oMenu.Font.Size = new FontUnit(10, UnitType.Pixel);
                oMenu.ForeColor=ColorTranslator.FromHtml("#284E98");
                oMenu.StaticSubMenuIndent = new Unit(10, UnitType.Pixel);
                oMenu.PathSeparator = Convert.ToChar("|");
                oMenu.StaticMenuItemStyle.HorizontalPadding = new Unit(5, UnitType.Pixel);
                oMenu.StaticMenuItemStyle.VerticalPadding = new Unit(2, UnitType.Pixel);
                oMenu.StaticSelectedStyle.Font.Bold = true;
                oMenu.StaticSelectedStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                oMenu.DynamicHoverStyle.BackColor = ColorTranslator.FromHtml("#284E98");
                oMenu.DynamicHoverStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                oMenu.DynamicMenuStyle.BackColor = ColorTranslator.FromHtml("#B5C7DE");
                oMenu.StaticSelectedStyle.BackColor = ColorTranslator.FromHtml("#507CD1");
                oMenu.DynamicSelectedStyle.BackColor = ColorTranslator.FromHtml("#507CD1");
                oMenu.DynamicSelectedStyle.Font.Bold = true;
                oMenu.DynamicSelectedStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                oMenu.DynamicMenuItemStyle.HorizontalPadding = new Unit(5, UnitType.Pixel);
                oMenu.DynamicMenuItemStyle.VerticalPadding = new Unit(2, UnitType.Pixel);
                oMenu.StaticHoverStyle.BackColor = ColorTranslator.FromHtml("#284E98");
                oMenu.StaticHoverStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                return;
            default:
                return;
        }
    }
    public void get_grids(DataSet ds, PlaceHolder ph_out)
    {
        get_grids(ds, ph_out, null, null, false);
    }
    public void get_grids(DataSet ds, PlaceHolder ph_out, bool OneLine)
    {
        get_grids(ds, ph_out, null, null, OneLine);
    }
    public void get_grids(DataSet ds, PlaceHolder ph_out, int[] StaticGridViews)
    {
        get_grids(ds, ph_out, StaticGridViews, null, false);
    }
    public void get_grids(DataSet ds, PlaceHolder ph_out, MasterPage MasterPage1)
    {
        get_grids(ds, ph_out, null, MasterPage1, false);
    }
    public void get_grids(DataSet ds, PlaceHolder ph_out, int[] StaticGridViews, MasterPage MasterPage1, bool OneLine)
    {
        int ds_Tables_Count = ds.Tables.Count;

        GridView[] gv = new GridView[ds_Tables_Count];
        GridView[] gvS = new GridView[ds_Tables_Count];

        for (int i = 0; i < ds_Tables_Count; i++)
        {
            gv[i] = new GridView();
            gv[i].ID = "gr" + i.ToString();
            gv[i].DataSource = ds.Tables[i];
            gv[i].Style.Value = "font-size: 12px;";
            gv[i].DataBind();

            if (StaticGridViews != null)
                if (i < StaticGridViews.Length)
                {
                    if (StaticGridViews[i] == i) { }
                    else { ph_out.Controls.Add(gv[i]); }
                }
                else { ph_out.Controls.Add(gv[i]); }
            else { ph_out.Controls.Add(gv[i]); }

            //if (ph_out!=null)
            //    ph_out.Controls.Add(gv[i]);

            if (MasterPage1!=null)
            {
                ContentPlaceHolder cph = (ContentPlaceHolder)MasterPage1.FindControl("main");
                if (cph == null)
                {
                    cph = (ContentPlaceHolder)MasterPage1.FindControl("ContentPlaceHolder1");
                }
                if (StaticGridViews!=null)
                {
                    int sgv = StaticGridViews.Length;
                    if ((i == 0) && (sgv > i)) if (StaticGridViews[i] == 0) { gvS[i] = (GridView)cph.FindControl("GridView0"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 1) && (sgv > i)) if (StaticGridViews[i] == 1) { gvS[i] = (GridView)cph.FindControl("GridView1"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 2) && (sgv > i)) if (StaticGridViews[i] == 2) { gvS[i] = (GridView)cph.FindControl("GridView2"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 3) && (sgv > i)) if (StaticGridViews[i] == 3) { gvS[i] = (GridView)cph.FindControl("GridView3"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 4) && (sgv > i)) if (StaticGridViews[i] == 4) { gvS[i] = (GridView)cph.FindControl("GridView4"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 5) && (sgv > i)) if (StaticGridViews[i] == 5) { gvS[i] = (GridView)cph.FindControl("GridView5"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 6) && (sgv > i)) if (StaticGridViews[i] == 6) { gvS[i] = (GridView)cph.FindControl("GridView6"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 7) && (sgv > i)) if (StaticGridViews[i] == 7) { gvS[i] = (GridView)cph.FindControl("GridView7"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 8) && (sgv > i)) if (StaticGridViews[i] == 8) { gvS[i] = (GridView)cph.FindControl("GridView8"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                    if ((i == 9) && (sgv > i)) if (StaticGridViews[i] == 9) { gvS[i] = (GridView)cph.FindControl("GridView9"); gvS[i].DataSource = ds.Tables[i]; gvS[i].DataBind(); }
                }
            }
        }
    }
	
}
