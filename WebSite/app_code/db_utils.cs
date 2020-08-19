using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Data.SqlClient;

/// -----------------------------------
/// Please contact if any questions to:
/// Vitaly Kuleshov 
/// e-mail: vkuleshov@biz.by 
/// phone : +375296430929 
/// Belarus, Mogilev
/// Start Date: 15-Nov-2007
/// ----------------------------------
/// This class works with your site's database.
/// You can get any information about your database's connection, 
/// also you can get the data from your database in the different ways.
/// You can use the CommandType "Text" or "StoredProcedure" 
/// and get the data via "DataReader" or "DataSet".
/// Also you can change the type of the return way of the returned data 
/// to ExecuteNonQuery, ExecuteScalar, EcecuteReader and so on.
/// The class designer can be used as:
/// 1. db_utils someName = new db_utils(); in this case you will work with the default connection "mainConnectionString" from the web.config file;
/// 2. db_utils someName = new db_utils(aliasconnectionString); you will work with any connection string aliases from the web.config file.

/// <summary>
/// db_utils() - creates an db_utils object with default site's connection ("mainConnectionString" [web.config file])  
/// db_utils(aliasConnectionString) - creates an db_utils object with the (string aliasConnectionString [from the file web.config]) 
/// </summary>
public class db_utils
{
    private string db_ConnectionString;
    private SqlConnection db_SqlConnection = new SqlConnection();
    private SqlCommand db_SqlCommand = new SqlCommand();
       
    public db_utils()
	{
        db_ConnectionString = WebConfigurationManager.ConnectionStrings["mainConnectionString"].ToString();
        do_db_SqlCommand();
	}

    // aliasConnectionString = alias connection string from file web.config
	public db_utils(string aliasConnectionString)
	{
        db_ConnectionString = WebConfigurationManager.ConnectionStrings[aliasConnectionString].ToString();
        do_db_SqlCommand();
	}
    
    public void do_db_SqlCommand()
    {
        db_SqlCommand.Connection = this.get_db_SqlConnection();
        db_SqlCommand.CommandTimeout = 300;
    }

    // The method returns a database's connection string 
    public string get_db_ConnectionString()
    {
        return db_ConnectionString;
    }

    // The method returns an SqlConnection object
    public SqlConnection get_db_SqlConnection()
    {
        db_SqlConnection.ConnectionString = this.get_db_ConnectionString().ToString();
        return db_SqlConnection;
    }

    // The method returns an data object from the connected database
    /*
     returnType:
     -----------
     NonQuery  - returns only the numbers of the changed rows (insert, update, delete)
     Example: 
     db_utils ndb_utils = new db_utils(); 
     String someValue = ndb_utils.get_db_Data("DELETE someTable WHERE ID = 114", null, "Nonquery").ToString();
     Scalar    - returns the first column value of the first row (count(), sum())
     Example: 
     db_utils ndb_utils = new db_utils(); 
     String someValue = ndb_utils.get_db_Data("SELECT COUNT(*) FROM someTable", null, "Nonquery").ToString(); 
     Reader    - returns a DataReader object
     Example:
     SomeGridView.DataSource = ndb_utils.get_db_Data("SELECT TOP 10 * FROM someTable", null, "Reader");
     DataSet   - returns a DataSet object
     Example:
     SomeGridView.DataSource = ndb_utils.get_db_Data("SELECT TOP 10 * FROM someTable", null, "DataSet");
     Please use a "null" value for the "paramArray" argument 
     if you want to execute a direct select command without any parameters in other case use an object "paramArray".
     Example:
     SqlParameter[] paramArray = new SqlParameter[2];
      
     You can use short format:
     paramArray[0] = new SqlParameter("@SomeParam1", Param1Value);
     or full format:
     SqlParameter SomeParam1 = new SqlParameter("@SomeParam1", SqlDbType.NVarChar, 100);   
     SomeParam1.Value = "Param1Value"; 
     paramArray[0] = SomeParam1; 
      
     paramArray[1] = new SqlParameter("@SomeParam2", Param2Value);
      
     db_utils ndb_utils = new db_utils();
     SqlDataReader reader = ndb_utils.get_db_Data("SomeStoredProcedureName or any SQL command with parameters (i.e. SELECT * FROM table WHERE Id=@ParamId)", paramArray, "Reader") as SqlDataReader;
      
     */
    public Object get_db_Data(String queryString, SqlParameter[] paramArray, String returnType)
    {

        if (queryString.Trim().IndexOf(" ") == -1)
        {
            db_SqlCommand.CommandType = CommandType.StoredProcedure;
        }
        else 
        {
            db_SqlCommand.CommandType = CommandType.Text;
        }

        db_SqlCommand.CommandText = queryString;

        if (paramArray != null) 
        {
            foreach (SqlParameter param in paramArray)
            {
                if (param!=null)
                    db_SqlCommand.Parameters.Add(param);         
            }
        }

        if ((returnType.ToLower().Trim() != "dataset") && (db_SqlConnection.State != ConnectionState.Open))
        {
            db_SqlConnection.Open();
        }

        switch (returnType.ToLower().Trim())
        {
            case "nonquery":
                int cmdNonQueryResult;
                cmdNonQueryResult = db_SqlCommand.ExecuteNonQuery();
                db_SqlConnection.Close();
                return cmdNonQueryResult;
            case "scalar":
                Object cmdScalarResult;
                cmdScalarResult = db_SqlCommand.ExecuteScalar();
                db_SqlConnection.Close();
                return cmdScalarResult;
            case "reader":
                SqlDataReader db_reader = db_SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return db_reader;
            case "dataset":
                SqlDataAdapter db_SqlDataAdapter = new SqlDataAdapter();
                DataSet db_DataSet = new DataSet();
                db_SqlDataAdapter.SelectCommand = db_SqlCommand;
                db_SqlDataAdapter.Fill(db_DataSet);          
                return db_DataSet;
            default:
                return "no any data objects, please check your parameters..." as Object;
         }
      
    }


}
