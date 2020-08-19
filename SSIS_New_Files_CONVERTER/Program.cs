using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Investars.Bots.Utils.Application;
using Investars.Bots.Utils.Misc;
using System.Diagnostics;
using System.Data;
using System.IO;

namespace SSIS_New_Files_CONVERTER
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App(args);
            Sql sql = new Sql(app.ConnString_SupportDB);
            string SqlCmd = "EXEC New_Files_CONVERTER @IO = 6";
            
            //StreamWriter sw = new StreamWriter(@"D:\Temp\CONVERTER.log", true);
            //sw.WriteLine(DateTime.Now.ToString() + "==================================");
            //------------------------------------------------
            bool Debug = false;
            if (Debug)
                SqlCmd += ",@Debug = 1";
            //------------------------------------------------
            sql.Execute(SqlCmd);
            if (!sql.error)
            {
                //sw.WriteLine(DateTime.Now.ToString()+ ": SQL - GOOD");
                foreach (DataRow row in sql.dataSet.Tables[0].Rows)
                {
                    int ConvertTypeID = (int)row["ConvertTypeID"];
                    int FileID = (int)row["FileID"];
                    int TaskID = (int)row["TaskID"];
                    //sw.WriteLine(DateTime.Now.ToString() + ": FileID: " + FileID.ToString());
                    string FileURI = @"D:\SSIS\SSIS_New_Files_Converter_" + ConvertTypeID.ToString() + ".exe";
                    if (File.Exists(FileURI))
                    {
                        //sw.WriteLine(DateTime.Now.ToString() + ": SSIS_New_Files_Converter_: EXISTS: " + ConvertTypeID.ToString());
                        ProcessStartInfo psi = new ProcessStartInfo(FileURI, FileID.ToString());
                        psi.UseShellExecute = true;
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                        Process process = new Process();
                        process.StartInfo = psi;
                        process.Start();
                        //sw.WriteLine(DateTime.Now.ToString() + ": SSIS_New_Files_Converter_: STARTED: " + ConvertTypeID.ToString());
                    }
                }
            }
            //sw.Close();
        }
    }
}
