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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cLbl.Text = DateTime.Today.Year.ToString();

        if (Request.QueryString["goBackTo"] != null)
        {
            goBackTo.Value = Request.QueryString["goBackTo"];
        }

        if (Request.Form.Get("Action") != null) 
        {
            if (Request.Form.Get("Action") == "Login")
            {
                
                string currPage=null;
                if (Request.Form.Get("goBackTo") != null)
                {
                    site_utils su = new site_utils();
                    currPage = su.getSitePage(Request.Form.Get("goBackTo"));
                }
                
                SqlParameter[] paramArray = new SqlParameter[5];

                SqlParameter param1 = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                param1.Value = Request.Form.Get("UserId");
                paramArray[0] = param1;

                SqlParameter param2 = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                param2.Value = Request.Form.Get("Password");;
                paramArray[1] = param2;

                SqlParameter param3 = new SqlParameter("@IP", SqlDbType.NVarChar, 20);
                param3.Value = Request.UserHostAddress.ToString();
                paramArray[2] = param3;

                SqlParameter param4 = new SqlParameter("@Browser", SqlDbType.NVarChar, 100);
                param4.Value = Request.UserAgent.ToString();
                paramArray[3] = param4;

                SqlParameter param5 = new SqlParameter("@Page", SqlDbType.NVarChar, 200);
                param5.Value = currPage;
                paramArray[4] = param5;
                
                db_utils ndb_utils = new db_utils();
                SqlDataReader reader = ndb_utils.get_db_Data("site_get_userid", paramArray, "Reader") as SqlDataReader;
                reader.Read();

                if ((int)reader["UserId"] != -1)
                {
                    Session["UserId"] = reader["UserId"];
                    Session["UserIdOwner"] = reader["IdOwner"];
                    Session["UserEmail"] = reader["Email"];
                    Session["LastVisit"] = reader["LastVisit"];
                    Session["FromIP"] = reader["FromIP"];
                    if (reader["DefRedirectPage"].ToString() == "goBackTo")
                    {

                        Response.Redirect(Request.Form.Get("goBackTo"));
                    }
                    else
                    {
                        Response.Redirect(reader["DefRedirectPage"].ToString());
                    }
                }
                else
                {
                    mesLbl.Text = reader["MessageToUser"].ToString();
                }
            }
        }
    }
}
