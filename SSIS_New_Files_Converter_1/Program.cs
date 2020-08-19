using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Investars.Bots.Utils.Application;
using System.IO;
using Investars.Bots.Utils.Misc;
using Excel_WorkBook_Export;

namespace SSIS_New_Files_Converter_1
{
    class Program
    {
        static int Main(string[] args)
        {
            //------------------------------------------
            bool Debug =false;
            //------------------------------------------
            App app = new App(args);
            int returnCode = 0;
            string FileID = args[0];

            if (Debug) Console.WriteLine("FileID:" + FileID);

            string SqlCmd = "";
            string TempDir = "";
            Sql sql = new Sql(app.ConnString_SupportDB);
            SqlCmd = "EXEC SupportDB..new_files_CONVERTER @IO = 11, @ConvertTypeID = 1, @FileID = " + FileID;
            sql.Execute(SqlCmd);
            if (sql.error)
            {
                SqlCmd = "EXEC SupportDB..ssis_alert_message @PackageName = 'SSIS_New_Files_Convverter_1.exe', @AlertMessage = 'ERROR of Converting !!! Cant get TempDir.', @FileID=" + FileID;
                returnCode = 1;
            }
            else
            {
                TempDir = sql.dataSet.Tables[0].Rows[0]["TempDir"].ToString();
                TempDir = TempDir + FileID + @"\";

                if (Debug) Console.WriteLine("TempDir:" + TempDir);

                if (!Directory.Exists(TempDir))
                    returnCode = 2;
                else
                {
                    Directory.SetCurrentDirectory(TempDir);

                    if (Debug) Console.WriteLine("Directory.SetCurrentDirectory(TempDir)");

                    string[] files = Directory.GetFiles(TempDir, "*.xlsx");
                    if (files.Length == 0)
                        files = Directory.GetFiles(TempDir, "*.xls");
                    if (files.Length == 1)
                    {
                        if (Debug) Console.WriteLine("Detected file");

                        SqlCmd = "EXEC SupportDB..new_files_CONVERTER @IO = 10, @ConvertTypeID = 1, @FileID = " + FileID;
                        sql.Execute(SqlCmd);
                        if (sql.error)
                        {
                            SqlCmd = "EXEC SupportDB..ssis_alert_message @PackageName = 'SSIS_New_Files_Convverter_1.exe', @AlertMessage = 'ERROR of Converting !!! Cant get ranges, delimiter.', @FileID=" + FileID;
                            returnCode = 4;
                        }
                        else
                        {
                            string ColDelimiter = sql.dataSet.Tables[0].Rows[0]["ColumnDelimiter"].ToString(); //TAB
                            if (ColDelimiter == "TAB") ColDelimiter = "";
                            string Range = sql.dataSet.Tables[0].Rows[0]["CellRange"].ToString(); //A1
                            if (Range == "A1") Range = "";

                            Xlsx_Txt Xlsx_to_Txt = new Xlsx_Txt();
                            if (Debug) Console.WriteLine("try convert");
                            Xlsx_to_Txt.Run(files[0], 1, ColDelimiter, Range, "", true, ".txt");
                            if (Xlsx_to_Txt.error)
                            {
                                SqlCmd = "EXEC SupportDB..ssis_alert_message @PackageName = 'SSIS_New_Files_Convverter_1.exe', @AlertMessage = 'ERROR of Converting !!! May be cant write new file.', @FileID=" + FileID;
                                returnCode = 5;
                            }
                            else
                                SqlCmd = "EXEC SupportDB..new_files_CONVERTER @IO = 9, @FileID = " + FileID;

                        }
                    }
                    else
                        returnCode = 3;
                }
            }
            sql.Execute(SqlCmd);
            if (Debug)
            {
                Console.WriteLine("Press any key ..." + returnCode);
                Console.ReadKey();
            }
            return returnCode;
        }
    }
}
