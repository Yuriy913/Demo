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
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    string cmdStr = "";
    string TaskID="", GroupID="", AddressID="";

    int cp = 0;
    string[] parameters = new string[5];
    string[] values = new string[5];

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (!((Server.MachineName=="YURY")&&
              (Page.MasterPageFile=="/SUPPORT/MyPage.master")))
        {
            site_utils PageAttr = new site_utils();
            PageAttr.setPageAttr(this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbDate.Text = DateTime.Today.ToShortDateString();
            //tbTest.Text = Server.MachineName.ToString();
            //tbTest.Text = Request.UserHostName + ":" + Request.UserHostAddress;
            //tbTest.Text = Page.MasterPageFile;
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {   
        if (sender.Equals(LinkButton1))
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            if (TaskID != "")
            { parameters[cp] = "@TaskID"; values[cp++] = TaskID; }
            else
                if (tbTaskID.Text != "")
                { parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text; }
        }
        if (sender.Equals(LinkButton2))
        {   
            parameters[cp] = "@IO"; values[cp++] = "2";
            if (GroupID != "")
                {
                    parameters[cp] = "@GroupID"; values[cp++] = GroupID;
                }                 
            else
                if (tbGroupID.Text != "")
                    {
                        parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
                    }
        }
        if (sender.Equals(LinkButton3))
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            if (AddressID != "")
            { parameters[cp] = "@AddressID"; values[cp++] = AddressID; }
            else
                if (tbAddressID.Text != "")
                { parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text; }
        }

        if (cp > 0)
        {
            SqlParameter[] paramArray = new SqlParameter[cp];
            for (int i = 0; i < cp; i++)
            {
                paramArray[i] = new SqlParameter(parameters[i], values[i]);
            }

            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("admin_emails", paramArray, "DataSet") as DataSet;

            int[] StaticGridViews = new int[5];
            StaticGridViews[0] = 0;
            StaticGridViews[1] = 1;
            StaticGridViews[2] = 2;
            StaticGridViews[3] = 3;
            StaticGridViews[4] = 4;

            control_utils gu = new control_utils();
            MasterPage MasterPage1 = Page.Master;
            gu.get_grids(ds, PlaceHolder1, StaticGridViews, MasterPage1,false);
        }

        TaskID =""; GroupID =""; AddressID ="";
    }
    protected void GridView1_SelectedIndexChanged(object sender,EventArgs e)
    {
       
    }
    protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
    {
        lMenuPath.Text = e.Item.ValuePath;

        //Tasks
        if (e.Item.ValuePath == "Tasks|All") { 
            parameters[cp] = "@IO"; values[cp++] = "1";
        }
        if (e.Item.ValuePath == "Tasks|Find")
        {   
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "0";
            if (tbFieldContent1.Text != "")
            {
                parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
            }
            if (tbFieldContent2.Text != "")
            {
                parameters[cp] = "@FieldContent2"; values[cp++] = tbFieldContent2.Text;
            }
            tbFieldContent1.Text = "";
        }
        if (e.Item.ValuePath == "Tasks|New One") 
        { 
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
            tbFieldContent1.Text = "";
        }
        if (e.Item.ValuePath == "Tasks|Disable")
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "4";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
        }
        if (e.Item.ValuePath == "Tasks|Enable")
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "5";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
        }
        if ((e.Item.ValuePath == "Tasks|Bind With Groups")
            ||
            (e.Item.ValuePath == "Tasks|With Groups|Bind"))
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "8";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
        }

        if (e.Item.ValuePath == "Tasks|With Groups|UnBind ALL")
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "14";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
        }

        if (e.Item.ValuePath == "Tasks|With Addresses|Exclude")
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "12";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Tasks|With Addresses|Include")
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "13";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Tasks|Update|Description")
        {
            parameters[cp] = "@IO"; values[cp++] = "1";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
            parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
        }

        //Groups
        if (e.Item.ValuePath == "Groups|All") { cmdStr += "@IO=2"; }
        if ((e.Item.ValuePath == "Groups|Bind With Tasks")
            ||
            (e.Item.ValuePath == "Groups|With Tasks|Bind"))
        { 
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "8";
            parameters[cp] = "@ListOfTaskID"; values[cp++] = tbTaskID.Text;
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
        }
        if (e.Item.ValuePath == "Groups|Disable")
        {
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "4";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
        }
        if (e.Item.ValuePath == "Groups|Enable")
        {
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "5";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
        }
        if ((e.Item.ValuePath == "Groups|Bind With Addresses")
            ||
            (e.Item.ValuePath == "Groups|With Addresses|Bind"))
        {
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "9";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Groups|With Addresses|Enable")
        {
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "233";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Groups|With Addresses|Disable")
        {
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "234";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }

        if (e.Item.ValuePath == "Groups|Find")
        {   
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "0";
            if (tbFieldContent1.Text != "")
            {
                parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
            }
            if (tbFieldContent2.Text != "")
            {
                parameters[cp] = "@FieldContent2"; values[cp++] = tbFieldContent2.Text;
            }
            tbFieldContent1.Text = "";
        }
        if (e.Item.ValuePath == "Groups|New One")
        { 
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;

            tbFieldContent1.Text = "";
        }
        if (e.Item.ValuePath == "Groups|Update|Description")
        {
            parameters[cp] = "@IO"; values[cp++] = "2";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbTaskID.Text;
            parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
        }

        //Addresses
        if (e.Item.ValuePath == "Addresses|Addresses|All") { cmdStr += "@IO=3"; }
        if (e.Item.ValuePath == "Addresses|Find")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "0";
            if (tbFieldContent1.Text != "")
            {
                parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
            }
            if (tbFieldContent2.Text != "")
            {
                parameters[cp] = "@FieldContent2"; values[cp++] = tbFieldContent2.Text;
            }
            tbFieldContent1.Text = ""; tbFieldContent2.Text = "";
        }
        if (e.Item.ValuePath == "Addresses|New One")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "1";
            parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
            parameters[cp] = "@FieldContent2"; values[cp++] = tbFieldContent2.Text;

            tbFieldContent1.Text = "";
            tbFieldContent2.Text = "";
        }
        if (e.Item.ValuePath == "Addresses|Update|ContactPerson")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
            parameters[cp] = "@FieldContent1"; values[cp++] = tbFieldContent1.Text;
        }
        if (e.Item.ValuePath == "Addresses|Update|Address")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "2";
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
            parameters[cp] = "@FieldContent2"; values[cp++] = tbFieldContent2.Text;
        }

        if (e.Item.ValuePath == "Addresses|Disable")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "4";
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Addresses|Enable")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "5";
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Addresses|InActive From")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "6";
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if (e.Item.ValuePath == "Addresses|InActive To")
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "7";
            parameters[cp] = "@Date"; values[cp++] = tbDate.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }
        if ((e.Item.ValuePath == "Addresses|Bind With Groups")
            ||
            (e.Item.ValuePath == "Addresses|With Groups|Bind"))
        {
            parameters[cp] = "@IO"; values[cp++] = "3";
            parameters[cp] = "@SubIO"; values[cp++] = "8";
            parameters[cp] = "@ListOfGroupID"; values[cp++] = tbGroupID.Text;
            parameters[cp] = "@ListOfAddressID"; values[cp++] = tbAddressID.Text;
        }

        if (cp > 0)
        {
            SqlParameter[] paramArray = new SqlParameter[cp];
            for (int i = 0; i < cp; i++)
            {
                paramArray[i] = new SqlParameter(parameters[i], values[i]);
            }
            db_utils du = new db_utils();
            DataSet ds;
            ds = du.get_db_Data("admin_emails", paramArray, "DataSet") as DataSet;

            int[] StaticGridViews = new int[5];
            StaticGridViews[0] = 0;
            StaticGridViews[1] = 1;
            StaticGridViews[2] = 2;
            StaticGridViews[3] = 3;
            StaticGridViews[4] = 4;

            control_utils gu = new control_utils();
            gu.get_grids(ds, PlaceHolder1, StaticGridViews, Page.Master,false);
        }
    }
    protected void GridView0_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView0_SelectedIndexChanged(object sender, EventArgs e)
    {
        TaskID=GridView1.SelectedDataKey.Values["ID"].ToString();
        LinkButton1_Click(LinkButton1, e);
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GroupID = GridView2.SelectedDataKey.Values["ID"].ToString();
        LinkButton1_Click(LinkButton2, e);
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddressID = GridView4.SelectedDataKey.Values["ID"].ToString();
        LinkButton1_Click(LinkButton3, e);
    }
    protected void tbTaskID_TextChanged(object sender, EventArgs e)
    {

    }
}
