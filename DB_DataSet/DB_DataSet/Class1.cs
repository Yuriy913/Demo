using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DB_DataSet
{
    public class DB
    {
        #region Variables
        public DataSet dataSet;
        public bool error = false;
        public string errorMessage = "";
        private bool KeepConnection;
        private int TypeConnection = 0;

        //TypeConnection = 0
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        public SqlParameter[] sqlParameters;

        //TypeConnection = 1
        //https://www.connectionstrings.com/access/
        //
        private OleDbConnection oleConnection = new OleDbConnection();
        private OleDbCommand oleCommand = new OleDbCommand();
        public OleDbParameter[] oleParameters;
        #endregion

        public DB(string connectionString, int connectionType = 0, bool connectionKeep = false)
        {
            KeepConnection = connectionKeep;
            TypeConnection = connectionType;
            switch (TypeConnection)
            {
                case 0:
                    sqlConnection.ConnectionString = connectionString;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 0;
                    break;
                case 1:
                    oleConnection.ConnectionString = connectionString;
                    oleCommand.Connection = oleConnection;
                    oleCommand.CommandTimeout = 30;
                    break;
            }
        }

        public bool Execute(String CommandString)
        {
            bool result = false;
            switch (TypeConnection)
            {
                case 0:
                    sqlCommand.Parameters.Clear();
                    if (sqlParameters != null)
                        if (sqlParameters.Length > 0)
                            result = sqlCommandExecute(CommandString, sqlParameters);
                        else
                            result = sqlCommandExecute(CommandString, null);
                    else
                        result = sqlCommandExecute(CommandString, null);
                    break;
                case 1:
                    oleCommand.Parameters.Clear();
                    if (oleParameters != null)
                        if (oleParameters.Length > 0)
                            result = oleCommandExecute(CommandString, oleParameters);
                        else
                            result = oleCommandExecute(CommandString, null);
                    else
                        result = oleCommandExecute(CommandString, null);
                    break;
            }
            return result;
        }
        //--------------------------------------

        public bool sqlCommandExecute(String sqlCommandString, SqlParameter[] sqlParameters = null)
        {
            bool result = true;
            sqlCommand.Parameters.Clear();
            if (sqlCommandString.Trim().IndexOf(" ") == -1)
                sqlCommand.CommandType = CommandType.StoredProcedure;
            else
                sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlCommandString;
            if (sqlParameters != null)
            {
                if (sqlCommand.Parameters.Count > 0)
                    sqlCommand.Parameters.Clear();
                foreach (SqlParameter sqlParameter in sqlParameters)
                    if (sqlParameter != null)
                        sqlCommand.Parameters.Add(sqlParameter);
            }

            error = false; errorMessage = "";

            dataSet = new DataSet();
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                    if (!KeepConnection)
                        sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                sqlParameters = null;
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }
            if (sqlConnection.State == ConnectionState.Open)
                if (!KeepConnection)
                    sqlConnection.Close();

            result = !error;
            return result;
        }

        public bool oleCommandExecute(String oleCommandString, OleDbParameter[] oleParameters = null)
        {
            bool result = true;
            oleCommand.Parameters.Clear();
            if (oleCommandString.Trim().IndexOf(" ") == -1)
                oleCommand.CommandType = CommandType.StoredProcedure;
            else
                oleCommand.CommandType = CommandType.Text;
            oleCommand.CommandText = oleCommandString;
            if (oleParameters != null)
            {
                if (oleCommand.Parameters.Count > 0)
                    oleCommand.Parameters.Clear();
                foreach (OleDbParameter oleParameter in oleParameters)
                    if (oleParameter != null)
                        oleCommand.Parameters.Add(oleParameter);
            }

            error = false; errorMessage = "";

            dataSet = new DataSet();
            try
            {
                if (oleConnection.State != ConnectionState.Open)
                    if (!KeepConnection)
                        oleConnection.Open();
                OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter(oleCommand);
                oleDataAdapter.Fill(dataSet);
                oleParameters = null;
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }
            if (oleConnection.State == ConnectionState.Open)
                if (!KeepConnection)
                    oleConnection.Close();

            result = !error;
            return result;
        }
    }

}
