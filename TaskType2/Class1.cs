using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Investars.Bots.Utils;
using Investars.Bots.Utils.Misc;
using System.Data;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.Net;

namespace TaskType2
{
    public class TaskType
    {
        #region Variables
            public string DLL_Name = "TaskType2", GlobalNodeCode = "0";
            //TaskType_Param ttp;
            TaskType_Param_2 ttp;
            Util util = new Util();
            DataSet DS_Tasks;
            string connStr, sqlCmd;
            object[] COLLECTIONS; int collectionsIndex = -1;
            //int ScheduleID, 
            //int TaskTypeID, 
            int TaskID, ProxyID;//, TaskScheduleID;
            bool PROXY_TaskID_Used = false;
            string Processable_URI = ""; int ForeignID = 0;//, FtpURI = ""
            //string WebPages_Dir = @"d:\FTPRoot\Download\WebPages\";
            Sql sql;
            Web2 web2 = new Web2();
        #endregion

        public void work(object param)
        {
            try
            {
                //ttp = (TaskType_Param)param;
                ttp = (TaskType_Param_2)param;
                //ScheduleID = ttp.ScheduleID;
                //TaskTypeID = ttp.TaskTypeID;
                TaskID = ttp.TaskID;

                connStr = ttp.connectionString;
                //if (ttp.ConsoleDebug)

                //if (ttp.ConsoleDebug)

                sql = new Sql(connStr);

                //----------------------------------
                //sqlCmd = "EXEC MultiTask_FormBot @IO=2, @ActionID=5, @ScheduleID=" + ScheduleID.ToString()
                //    + ", @TaskID = " + TaskID.ToString()
                //    + ", @Debug = " + (ttp.ConsoleDebug ? "1" : "0");

                sqlCmd = "EXEC MultiTask_BotLoader @IO=5, @TaskID = " + TaskID.ToString()
                    + ", @Debug = " + (ttp.ConsoleDebug ? "1" : "0");

                sql.Execute(sqlCmd); DS_Tasks = sql.dataSet;
                if (sql.error)
                {
                    if (ttp.ConsoleDebug)
                    {
                        Console.WriteLine(sql.errorMessage);
                        CHECK_POINT_SendMail(DLL_Name + ":work:DS_Tasks:SqlUtils.SqlErrors:" + sql.errorMessage);
                    }
                    else //CHECK_POINT
                        CHECK_POINT_SendMail(DLL_Name + ":work:DS_Tasks:SqlUtils.SqlErrors:" + sql.errorMessage);
                }
                //----------------------------------
                if (DS_Tasks.Tables.Count == 0)
                    if (ttp.ConsoleDebug)
                        Console.WriteLine("WARNING: DS_Tasks.Tables.Count == 0. Method: work");
                    else //CHECK_POINT
                        CHECK_POINT_SendMail(DLL_Name + ":work:DS_Tasks:Tables.Count == 0");
                //----------------------------------
                if ((!sql.error) && (DS_Tasks.Tables.Count > 0))
                {
                    if (DS_Tasks.Tables.Count > 0)
                        if (DS_Tasks.Tables[0].Rows.Count > 0)
                        {
                            DataRow row_task = DS_Tasks.Tables[0].Rows[0];
                            if (ttp.ConsoleDebug)
                                Console.WriteLine("TaskID = " + TaskID.ToString());

                            work_process(row_task);

                            sql.Execute("EXEC MultiTask_BotLoader @IO=7, @TaskID=" + TaskID.ToString());
                            if (sql.error)
                                CHECK_POINT_SendMail(DLL_Name + ":ERROR: Registry End TaskScheduleID:" + TaskID.ToString());
                        }
                }

                if (PROXY_TaskID_Used)
                {
                    sqlCmd = "EXEC bot_proxy_free @TaskID=" + TaskID.ToString();
                    sql.Execute(sqlCmd);
                }
            }
            catch (Exception ex)
            {
                CHECK_POINT_SendMail("TaskType1:work:" + ex.Message);
                if (ttp.ConsoleDebug)
                    Console.WriteLine(ex.Message);
            }
        }

        private void CHECK_POINT_SendMail(string Text)
        {
            string URL = Processable_URI;
            try
            {
                if (URL.Substring(0, 4).ToLower() == "http")
                    URL = "<a href=\"" + URL + "\" target=\"_blank\" >" + URL + "</a>";
            }
            catch { }
            Text = "ForeignID:[" + ForeignID.ToString() + "], URI:[" + URL + "]:" + Text;
            //util.CHECK_POINT_SendMail_v2(connStr, Text, TaskID.ToString());
            util.CHECK_POINT_SendMail_v2(connStr, Text, "2", "", TaskID.ToString(), GlobalNodeCode);
        }

        private void work_process(DataRow row_task)
        {
            int LocalNodeIndex = 0; string NodeCode = "c0";
            //if (!Directory.Exists(WebPages_Dir))
            //    Directory.CreateDirectory(WebPages_Dir);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml((string)row_task["InstructionXml"]);
            if (ttp.ConsoleDebug) Console.WriteLine("XML Loaded.");
            if (xmlDoc.HasChildNodes)
            {
                XmlNode xmlNode = xmlDoc.FirstChild;
                if (xmlNode.Name == "COLLECTIONS")
                    if (xmlNode.HasChildNodes)
                        foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
                            if (xmlChildNode.Name == "COLLECTION")
                            {
                                NODE_COLLECTION(NodeCode, ++LocalNodeIndex, xmlChildNode);
                                GlobalNodeCode = NodeCode;
                            }
            }
        }

        private void NODE_COLLECTION(string NodeCode, int NodeIndex, XmlNode xmlNode, string Html = "", int ForeignID = 0)
        {
            //string NodeCode, int NodeIndex, 
            //-------------------------------------
            NodeCode += ",c" + NodeIndex.ToString();
            int LocalNodeIndex = 0; GlobalNodeCode = NodeCode;
            //-------------------------------------
            if (NodeCode == "c0,c1,a1,c1,a1,c2,a1,c2,a1,c1")
            {
                NodeCode = NodeCode;
            }
            collectionsIndex++;
            string Node_Name = "NODE_COLLECTION";
            DataTable TABLE_COLLECTION = new DataTable();
            DataColumn dataColumn;
            RegexOptions[] regexOptions = null; int regexOptionsIndex = -1;

            int countParams = 0;
            string SqlCmd, RegExp, RegExp1, RegExp2, FileMask, Add_Item_RegExp, Add_Item_RegExp1, Add_Item_RegExp2, Add_Item_RegExp3, Add_Item_RegExp4, FirstPartOfURI;
            SqlCmd = RegExp = RegExp1 = RegExp2 = FileMask = Add_Item_RegExp = Add_Item_RegExp1 = Add_Item_RegExp2 = Add_Item_RegExp3 = Add_Item_RegExp4 = FirstPartOfURI = "";
            bool EmptyRegExp = false, ClearLineEnds = false, BeforeClearLineEnds = false;

            #region Attributes
            if (xmlNode.Attributes.Count > 0)
                foreach (XmlAttribute xmlAttr in xmlNode.Attributes)
                {
                    if (xmlAttr.Name.IndexOf("RegexOptions") == 0)
                    {
                        regexOptionsIndex++;
                        regexOptions = new RegexOptions[regexOptionsIndex + 1];
                    }
                    switch (xmlAttr.Name)
                    {
                        case "SqlCmd": SqlCmd = xmlAttr.Value; break;
                        case "RegExp": RegExp = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "RegExp1": RegExp1 = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "RegExp2": RegExp2 = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "FileMask": FileMask = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "FirstPartOfURI": FirstPartOfURI = util.replace_place_to_value(@xmlAttr.Value); break;

                        case "Not_Obligatory": EmptyRegExp = bool.Parse(@xmlAttr.Value); break;
                        case "EmptyRegExp": EmptyRegExp = bool.Parse(@xmlAttr.Value); break;

                        case "Add_Item_RegExp": Add_Item_RegExp = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "Add_Item_RegExp1": Add_Item_RegExp1 = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "Add_Item_RegExp2": Add_Item_RegExp2 = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "Add_Item_RegExp3": Add_Item_RegExp3 = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "Add_Item_RegExp4": Add_Item_RegExp4 = util.replace_place_to_value(@xmlAttr.Value); break;
                        case "countParams": countParams = int.Parse(xmlAttr.Value); break;
                        case "RegexOptions_Compiled": regexOptions[regexOptionsIndex] = RegexOptions.Compiled; break;
                        case "RegexOptions_CultureInvariant": regexOptions[regexOptionsIndex] = RegexOptions.CultureInvariant; break;
                        case "RegexOptions_ECMAScript": regexOptions[regexOptionsIndex] = RegexOptions.ECMAScript; break;
                        case "RegexOptions_ExplicitCapture": regexOptions[regexOptionsIndex] = RegexOptions.ExplicitCapture; break;
                        case "RegexOptions_IgnoreCase":
                            regexOptions[regexOptionsIndex] = RegexOptions.IgnoreCase; break;
                        case "RegexOptions_IgnorePatternWhitespace": regexOptions[regexOptionsIndex] = RegexOptions.IgnorePatternWhitespace; break;
                        case "RegexOptions_Multiline":
                            regexOptions[regexOptionsIndex] = RegexOptions.Multiline; break;
                        case "RegexOptions_None": regexOptions[regexOptionsIndex] = RegexOptions.None; break;
                        case "RegexOptions_RightToLeft": regexOptions[regexOptionsIndex] = RegexOptions.RightToLeft; break;
                        case "RegexOptions_Singleline": regexOptions[regexOptionsIndex] = RegexOptions.Singleline; break;
                        case "ClearLineEnds": ClearLineEnds = Convert.ToBoolean(xmlAttr.Value); break;
                        case "BeforeClearLineEnds": BeforeClearLineEnds = Convert.ToBoolean(xmlAttr.Value); break;
                        default: break;
                    }
                }
            #endregion
            if (BeforeClearLineEnds)
            {
                Html = Html.Replace("\r\n", "");
                Html = Html.Replace("\n\r", "");
                Html = Html.Replace("\r", "");
                Html = Html.Replace("\n", "");
            }

            dataColumn = TABLE_COLLECTION.Columns.Add("ID", typeof(int));
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;
            TABLE_COLLECTION.Columns.Add("PrimaryID", typeof(int));
            TABLE_COLLECTION.Columns.Add("ITEM", typeof(string));
            TABLE_COLLECTION.Columns.Add("FileName", typeof(string));
            COLLECTIONS = new object[collectionsIndex + 1];
            COLLECTIONS[collectionsIndex] = TABLE_COLLECTION;

            //1). SqlCmd
            #region SqlCmd
            if (SqlCmd != "")
            {
                if (SqlCmd.IndexOf("EXEC") > -1)
                    SqlCmd += ", @Debug = " + (ttp.ConsoleDebug ? "1" : "0");

                sql.Execute(SqlCmd);
                if (sql.error)
                    CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ":" + sql.errorMessage);
                else
                {
                    DataSet ds = sql.dataSet;
                    if (ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count>0)
                            foreach (DataRow row_Uri in ds.Tables[0].Rows)
                            {
                                DataRow row = TABLE_COLLECTION.NewRow();
                                try
                                {
                                    row["ITEM"] = row_Uri["ITEM"];
                                }
                                catch { }
                                try
                                {
                                    row["ITEM"] = row_Uri["URI"];
                                }
                                catch { }
                                foreach (DataColumn column in ds.Tables[0].Columns)
                                    if (column.ColumnName == "PrimaryID")
                                    {
                                        row["PrimaryID"] = row_Uri["PrimaryID"];
                                        //if (AddFileExtension != "")
                                        //    row["FileName"] = row_Uri["PrimaryID"].ToString() + AddFileExtension;
                                    }
                                TABLE_COLLECTION.Rows.Add(row);
                            }
                }
            }
            #endregion

            //2). use Uri From Html By RegExp
            if (NodeCode == "c0,c1,a1,c1,a1,c2")
            {
                NodeCode = NodeCode;
            }
            #region Uri From Html By RegExp
            if ((Html != "") && ((RegExp != "") || (RegExp1 != "") || (RegExp2 != "")))
            {
                MatchCollection matchCollection = null;
                if (regexOptions == null)
                {
                    if (RegExp != "")
                        matchCollection = Regex.Matches(Html, RegExp);
                    if ((RegExp1 != "") && ((matchCollection == null) || (matchCollection.Count == 0)))
                        matchCollection = Regex.Matches(Html, RegExp1);
                    if ((RegExp2 != "") && ((matchCollection == null) || (matchCollection.Count == 0)))
                        matchCollection = Regex.Matches(Html, RegExp2);
                }
                else
                    matchCollection = Regex.Matches(Html, RegExp, getRegexOptions(regexOptions));

                if (matchCollection.Count > 0)
                    foreach (Match matchItem in matchCollection)
                    {
                        Match match = null, match1 = null, match2 = null, match3 = null, match4 = null;
                        if (Add_Item_RegExp != "")
                            match = Regex.Match(Html, Add_Item_RegExp);
                        if (Add_Item_RegExp1 != "")
                            match1 = Regex.Match(Html, Add_Item_RegExp1);
                        if (Add_Item_RegExp2 != "")
                            match2 = Regex.Match(Html, Add_Item_RegExp2);
                        if (Add_Item_RegExp3 != "")
                            match3 = Regex.Match(Html, Add_Item_RegExp3);
                        if (Add_Item_RegExp4 != "")
                            match4 = Regex.Match(Html, Add_Item_RegExp4);

                        DataRow newRow = TABLE_COLLECTION.NewRow();
                        string ITEM = "";
                        if (FirstPartOfURI != "")
                            ITEM = FirstPartOfURI + matchItem.Groups["SecondPartOfURI"].Value;
                        else
                        {
                            if (matchItem.Groups["ITEM"].Success)
                                ITEM = matchItem.Groups["ITEM"].Value;
                            else
                                ITEM = matchItem.Value;

                            if (
                                   (match != null) && (Add_Item_RegExp != "")
                                || (match1 != null) && (Add_Item_RegExp1 != "")
                                || (match2 != null) && (Add_Item_RegExp2 != "")
                                || (match3 != null) && (Add_Item_RegExp3 != "")
                                || (match4 != null) && (Add_Item_RegExp4 != "")
                                )
                            {
                                if ((match != null) && (match.Value != ""))
                                    ITEM += match.Value;
                                if ((match1 != null) && (match1.Value != ""))
                                    ITEM += match1.Value;
                                if ((match2 != null) && (match2.Value != ""))
                                    ITEM += match2.Value;
                                if ((match3 != null) && (match3.Value != ""))
                                    ITEM += match3.Value;
                                if ((match4 != null) && (match4.Value != ""))
                                    ITEM += match4.Value;
                            }
                        }//BREAKPOINT
                        if (ClearLineEnds)
                        {
                            ITEM = ITEM.Replace("\r\n", " ");
                            ITEM = ITEM.Replace("\n\r", " ");
                            ITEM = ITEM.Replace("\r", " ");
                            ITEM = ITEM.Replace("\n", " ");
                        }
                        newRow["ITEM"] = ITEM;
                        if (ForeignID != 0)
                            newRow["PrimaryID"] = ForeignID;
                        TABLE_COLLECTION.Rows.Add(newRow);
                    }
                else
                    if (!EmptyRegExp)
                        CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ":Empty RegExp Result");
            }
            #endregion

            //3). use FileMask. Example: D:\Path\*.htm
            #region FileMask
            if (FileMask != "")
            {
                string path = get_path_mask(FileMask);
                if (path != "")
                {
                    string searchPattern = path.Substring(path.IndexOf('|') + 1);
                    path = path.Substring(0, path.IndexOf('|') - 1);
                    string[] files = null;
                    try
                    {
                        files = Directory.GetFiles(path, searchPattern);
                    }
                    catch { }
                    if (files.Length > 0)
                        foreach (string file in files)
                        {
                            DataRow row = TABLE_COLLECTION.NewRow();
                            row["ITEM"] = file;
                            TABLE_COLLECTION.Rows.Add(row);
                        }
                }
            }
            #endregion

            //4). без параметров сбор коллеции из пунктов
            #region Direct URI
            foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
                if (xmlChildNode.Name == "URI")
                {
                    DataRow row = TABLE_COLLECTION.NewRow();
                    foreach (XmlAttribute xmlAttr in xmlChildNode.Attributes)
                        switch (xmlAttr.Name)
                        {
                            case "Uri": row["ITEM"] = util.replace_place_to_value(xmlChildNode.Attributes[0].Value); break;
                            case "FileName_AfterLastRightSlesh":
                                string FileName = row["ITEM"].ToString();
                                FileName = util.ReverseString(FileName);
                                FileName = FileName.Substring(0, FileName.IndexOf('/'));
                                FileName = util.ReverseString(FileName);
                                row["FileName"] = FileName;
                                break;
                            case "FileName":
                                row["FileName"] = util.replace_place_to_value(xmlAttr.Value);
                                break;
                            default: break;
                        }
                    TABLE_COLLECTION.Rows.Add(row);
                    int ID = TABLE_COLLECTION.Rows[TABLE_COLLECTION.Rows.IndexOf(row)].Field<int>("ID");
                    if (xmlChildNode.HasChildNodes)
                        foreach (XmlNode node in xmlChildNode.ChildNodes)
                            if (node.Name == "ACTION")
                                NODE_ACTION(NodeCode, ++LocalNodeIndex, node, ID);
                }
            #endregion

            //4). Отработка общих действий над коллекцией URI
            if (TABLE_COLLECTION.Rows.Count > 0)
                foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
                    if (xmlChildNode.Name.ToUpper() == "ACTION")
                        NODE_ACTION(NodeCode, ++LocalNodeIndex, xmlChildNode);

            // Clear Last Collection
            collectionsIndex--;
            COLLECTIONS = new object[collectionsIndex + 1];
            GlobalNodeCode = NodeCode;
        }

        private void NODE_ACTION(string NodeCode, int NodeIndex, XmlNode xmlNode, int collectionItemIndex = -1)
        {
            //string NodeCode, int NodeIndex, 
            //-------------------------------------
            NodeCode += ",a" + NodeIndex.ToString();
            int LocalNodeIndex = 0; GlobalNodeCode = NodeCode;
            //-------------------------------------
            if (NodeCode == "c0,c1,a1,c1,a1,c1,a1")
            {
                NodeCode = NodeCode; //CHECK_POINT
            }

            string Node_Name = "NODE_ACTION";
            string Action = "", GetPageBy = "", Download_For = "", PostParams = "", FileName = "";
            string Params = "", Param = "";
            string Item_File_For = "";
            string Item_String_For = "";
            string Item_Url_For = "", Download_Dir = "";
            string UseProxy = "";
            string MultiLine = "";
            bool existsUri = false;
            bool isDelay = false;
            int Delay = 0; // delay secs
            //string WebPage_LocalFile = "";
            Random timeDelay = new Random();

            #region ACTION_Attributes
            foreach (XmlAttribute xmlAttr in xmlNode.Attributes)
            {
                switch (xmlAttr.Name)
                {
                    case "Action":          Action = xmlAttr.Value; break;                              //Parse_Url
//Parse_File,Parse_Text,Parse_Url,Execute_Application,Checking_Files_For_Exists,Checking_Files_Size_More,Checking_Files_For_Count,Checking_Files_For_Empty_Dir,
//Clear_Dir,Download_Page_For_Parse,Delete_Files,Flat_Import_File_Add,Parse_special_URL
                    case "Params":          Params = util.replace_place_to_value(xmlAttr.Value); break; //
                    case "Param":           Param = util.replace_place_to_value(xmlAttr.Value); break;  //
                    case "Item_File_For":   Item_File_For = xmlAttr.Value.ToUpper(); break;             //PARSE
                    case "Item_String_For": Item_String_For = xmlAttr.Value.ToUpper(); break;           //PARSE
                    case "Item_Url_For":    Item_Url_For = xmlAttr.Value.ToUpper(); break;              //PARSE,PARSEPAGEBYPOSTREQUEST
                    case "MultiLine":       MultiLine = xmlAttr.Value; break;                           //use,true
                    case "isDelay":         isDelay = Convert.ToBoolean(xmlAttr.Value); break;          //true
                    case "Delay":           Delay = int.Parse(xmlAttr.Value); break;                    //NN seconds
                    case "Download_For":    Download_For = xmlAttr.Value; break;                        //Save,SaveAndParse,Parse
                    case "Download_Dir":    Download_Dir = util.replace_place_to_value(xmlAttr.Value); break; //
                    case "GetPageBy":       GetPageBy = xmlAttr.Value; break;                                 //PostMethod,PostMethodWithoutCookies,Url,GET2
                    case "PostParams":      PostParams = util.replace_place_to_value(xmlAttr.Value); break;   //
                    case "UseProxy":        UseProxy = xmlAttr.Value; break;                                  //New(Next Free),One(One Free),Pin(Pinned For TaskID)
                }
            }
            #endregion
            
            bool FullFileRead = false;
            if ((MultiLine == "use") || (MultiLine == "true"))
                FullFileRead = true;

            DataTable COLLECTION_TABLE = (COLLECTIONS[collectionsIndex] as DataTable);
            DataRow[] dataRows = null;
            if (collectionItemIndex != -1)
                dataRows = COLLECTION_TABLE.Select("ID=" + collectionItemIndex.ToString());
            else
                dataRows = COLLECTION_TABLE.Select();

            //int collItemIndex = -1;
            //int countCollItems = -1; countCollItems = dataRows.Length;

            int itemIndex = 0;
            ProxyID = 0;
            if ((UseProxy == "One") || (UseProxy == "New"))
                Console.WriteLine("PROXY : " + UseProxy);

            //if (ttp.ConsoleDebug)
            Console.WriteLine("COUNT ITEMS:" + dataRows.Length.ToString());
            foreach (DataRow row_ITEM in dataRows)
            {
                try
                {
                    string ITEM = util.replace_place_to_value((string)row_ITEM["ITEM"]);
                    if (
                            (ITEM.IndexOf("://") == 4) ||
                            (ITEM.IndexOf("://") == 5) ||
                            (ITEM.IndexOf(":\\") == 1)
                        )
                    {
                        Processable_URI = ITEM;
                        // Internet - URL 
                        // тут определяется используемый Proxy
                        if (((UseProxy == "One") && (ProxyID == 0))
                        || (UseProxy == "New"))
                        {
                            //Console.WriteLine("PROXY : " + UseProxy);
                            //идем в базу за идентификатором Proxy там же выжидаем в цикле после PreLock и возвращаю ID
                            sqlCmd = "EXEC bot_proxy_lock @TaskID=" + TaskID.ToString();
                            if (UseProxy == "New") sqlCmd += ",@New=1";
                            sql.Execute(sqlCmd);
                            if (sql.error)
                            {
                                sql.Execute(sqlCmd);
                                if (sql.error)
                                {
                                    sql.Execute(sqlCmd);
                                    if (sql.error)
                                    {
                                        Console.WriteLine("ERROR : PROXY is not get from DB !!!");
                                        continue;
                                    }
                                    else
                                        ProxyID = (int)sql.dataSet.Tables[0].Rows[0]["ProxyID"];
                                }
                                else
                                    ProxyID = (int)sql.dataSet.Tables[0].Rows[0]["ProxyID"];
                            }
                            else
                                ProxyID = (int)sql.dataSet.Tables[0].Rows[0]["ProxyID"];
                        }
                        if (ProxyID > 0)
                            PROXY_TaskID_Used = true;
                    }
                    /*---------- KEEP THIS CHECK POINT ----------
                    if (ITEM == "https://www.marketwatch.com/investing/index/gspf?countrycode=xx")
                        ITEM = ITEM;
                    else
                        continue;
                    //---------- CHECK POINT ----------*/
                    string FileSise = "";
                    if (ttp.ConsoleDebug)
                    {
                        if (ITEM.IndexOf(':') == 1)
                            try
                            {
                                if (File.Exists(ITEM))
                                {
                                    FileInfo fi = new FileInfo(ITEM);
                                    FileSise = ":FileSize=" + fi.Length.ToString();
                                    if (fi.Length == 0)
                                        CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ": FileSise = 0 For:" + Processable_URI);
                                }
                            }
                            catch (Exception ex)
                            {
                                CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ":FileSise Is Not Detected For:" + Processable_URI + ":" + ex.Message);
                            }
                    }
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("#" + (++itemIndex).ToString() + ": " + DateTime.Now.ToLongTimeString() + ": " + ITEM + FileSise);

                    string Text = "";
                    string FullFileURI = "";

                    if (row_ITEM["PrimaryID"] != DBNull.Value)
                        ForeignID = (int)row_ITEM["PrimaryID"];

                    //if (ForeignID != 2761) --FOR DEBUG ONLY 1 Source-Stocks
                    //    continue;

                    if (isDelay)
                        System.Threading.Thread.Sleep((timeDelay.Next(3) + 2) * 1000 * 6);
                    if (Delay > 0)
                        System.Threading.Thread.Sleep(Delay * 1000);

                    if (Item_Url_For == "PARSE")
                        Action = "Parse_Url";

                    switch (Action)
                    {
                        case "Parse_File":
                            FullFileURI = ITEM;
                            existsUri = (File.Exists(FullFileURI) ? true : false);
                            if (!existsUri)
                                CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ":File Not Exists:" + Processable_URI);
                            break;
                        case "Parse_Text":
                            existsUri = true;
                            Text = ITEM;
                            break;
                        case "Parse_Url":

                            //FileName = TaskID.ToString() + "_" + util.full_time() + ".html";
                            //FileName = FileName.Replace("-", "");
                            //FileName = FileName.Replace(":", "");
                            //FileName = FileName.Replace(" ", "_");
                            //WebPage_LocalFile = WebPages_Dir + FileName;
                            //FtpURI = "ftp://WebPages@ftp.investars.com/" + FileName;

//STOP
                            Text = "";
                            if (ProxyID > 0)
                            {
                                Text = web2.Proxy_GetPageByUrl(ProxyID, ITEM);
                                if ((GetPageBy == "GET2") && (Text == ""))
                                    Text = web2.Proxy_GetPageByUrl(ProxyID, ITEM);
                            }
                            else
                            {
                               Text = WebUtils.GetPageByUrl(ITEM);
                                if (((GetPageBy == "GET2") && (Text == ""))
                                   ||(GetPageBy == "GET3")
                                )
                                    Text = WebUtils.GetPageByUrl(ITEM);
                             /*  if (Text == "")
                                { Text = WebUtils.getPageByURIUsedProxy(ITEM); }*/
                            }

                            existsUri = (Text != "" ? true : false);
                            //try { StreamWriter sw = new StreamWriter(WebPage_LocalFile); sw.Write(Text); sw.Close(); }
                            //catch { }

                            //Text = WebUtils.GetPageByUrl(ITEM);
                            //existsUri = (Text != "" ? true : false);
                            break;
                        case "Execute_Application":
                            //if (ttp.ConsoleDebug)
                            //    Params = "20131202";
                            Action_Execute_Application(ITEM, Params);
                            break;

                        case "Checking_Files_For_Exists":
                            Action_Work_With_Files(ITEM, Action);
                            break;

                        case "Checking_Files_Size_More":
                            Action_Work_With_Files(ITEM, Action, Param);
                            break;

                        case "Checking_Files_For_Count":
                            Action_Work_With_Files(ITEM, Action, Param);
                            break;
                        case "Checking_Files_For_Empty_Dir":
                            if (Param != "")
                                Action_Work_With_Files(ITEM, Action, Param);
                            else
                                Action_Work_With_Files(ITEM, Action);
                            break;
                        case "Clear_Dir":
                            Action_Work_With_Files(ITEM, Action);
                            break;
                        case "Delete_Files":
                            Action_Work_With_Files(ITEM, Action);
                            break;
                        case "Download_Page_For_Parse":
                            //Console.WriteLine("GET PAGE STR:"+util.full_time());
                            //2 places and before
                            //FileName = TaskID.ToString() + "_" + util.full_time() + ".html";
                            //FileName = FileName.Replace("-", "");
                            //FileName = FileName.Replace(":", "");
                            //FileName = FileName.Replace(" ", "_");
                            //WebPage_LocalFile = WebPages_Dir + FileName;
                            //FtpURI = "ftp://WebPages@ftp.investars.com/" + FileName;

                            Text = WebUtils.GetPageByUrl(ITEM);
                            existsUri = (Text != "" ? true : false);

                            //try { StreamWriter sw = new StreamWriter(WebPage_LocalFile); sw.Write(Text); sw.Close(); }
                            //catch { }

                            //Console.WriteLine("GET PAGE END:" + util.full_time());
                            break;
                        case "Flat_Import_File_Add":
                            Action_Work_With_Files(ITEM, Action, ForeignID.ToString());
                            break;
                        case "Parse_special_URL":
                            WebClient web = new WebClient();
                            Text = "";
                            Text = web.DownloadString(ITEM);
                            existsUri = (Text != "" ? true : false);
                            break;
                        default: //Use in near time
                            string[] fileActions = 
                            { "Checking_Files_For_Exists", 
                                "Checking_Files_For_Empty_Dir", 
                                  "Clear_Dir"};
                            if (Array.IndexOf(fileActions, Action) > -1)
                                Action_Work_With_Files(ITEM, Action);

                            break;
                    }

                    if (Download_For != "")
                    {
                        FileName = (string)row_ITEM["FileName"];
                        switch (GetPageBy)
                        {
                            case "PostMethod":
                                if ((Download_For == "Save") || (Download_For == "SaveAndParse"))
                                    WebUtils.GetPageByPostMethod(ITEM, PostParams, Download_Dir + FileName);
                                if ((Download_For == "Parse") || (Download_For == "SaveAndParse"))
                                    Text = WebUtils.GetPageByPostMethod(ITEM, PostParams);
                                break;
                            case "PostMethodWithoutCookies":
                                if ((Download_For == "Save") || (Download_For == "SaveAndParse"))
                                    WebUtils.GetPageByPostMethodWithoutCookies(ITEM, PostParams, Download_Dir + FileName);
                                if ((Download_For == "Parse") || (Download_For == "SaveAndParse"))
                                    Text = WebUtils.GetPageByPostMethodWithoutCookies(ITEM, PostParams);
                                break;
                            case "Url":
                                if ((Download_For == "Save") || (Download_For == "SaveAndParse"))
                                    WebUtils.GetPageByUrl(ITEM, Download_Dir + FileName);
                                if ((Download_For == "Parse") || (Download_For == "SaveAndParse"))
                                    Text = WebUtils.GetPageByUrl(ITEM);
                                break;
                        }
                    }

                    if (Item_File_For == "PARSE")
                    {
                        FullFileURI = ITEM;
                        existsUri = (File.Exists(FullFileURI) ? true : false);
                        if (!existsUri)
                            CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ":File Not Exists:" + Processable_URI);
                    }

                    if (Item_String_For == "PARSE")
                    {
                        existsUri = true;
                        Text = row_ITEM.Field<string>("ITEM");
                    }
              /*     if (Item_Url_For == "PARSE_POST_SPESIAL")
                   {
                     
                      Text = WebUtilsSpesial.GetPageByUrl(ITEM);
                        existsUri = (Text != "" ? true : false);
                    }*/

                    if (Item_Url_For == "PARSEPAGEBYPOSTREQUEST")
                    {
                        if (ITEM.IndexOf("?") != -1)
                        {
                            if (ttp.ConsoleDebug) Console.WriteLine("WebUtils.GetPageByPostMethod(" + ITEM.Remove(ITEM.IndexOf("?")) + ", " + ITEM.Substring(ITEM.IndexOf("?") + 1) + ")");
                            Text = WebUtils.GetPageByPostMethod(ITEM.Remove(ITEM.IndexOf("?")), ITEM.Substring(ITEM.IndexOf("?") + 1));
                            existsUri = (Text != "" ? true : false);
                        }
                        else { CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ": Check html url for post request :" + ITEM); }
                    }
                    if (existsUri)
                        foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
                            switch (xmlChildNode.Name)
                            {
                                case "COLLECTION":
                                    if ((FullFileRead) && (FullFileURI != ""))
                                        using (StreamReader sr = new StreamReader(FullFileURI))
                                            Text = sr.ReadToEnd();
                                    if (NodeCode == "c0,c1,a1,c1,a1,c2,a1")
                                    {
                                        NodeCode = NodeCode; //CHECK_POINT
                                    }
                                    if (Text != "")
                                        if (ForeignID == 0)
                                            NODE_COLLECTION(NodeCode, ++LocalNodeIndex, xmlChildNode, Text);
                                        else
                                            NODE_COLLECTION(NodeCode, ++LocalNodeIndex, xmlChildNode, Text, ForeignID);
                                    else
                                        CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ": Html Of file is empty :" + Processable_URI);
                                    break;
                                case "TRANSACTION":
                                    //Console.WriteLine("TRANSACTION START:"+util.full_time());
                                    NODE_TRANSACTION(NodeCode, ++LocalNodeIndex, xmlChildNode, ref Text, ref ITEM, ForeignID, FullFileURI, FullFileRead);
                                    //Console.WriteLine("TRANSACTION FINISH:"+util.full_time());
                                    break;
                                case "#comment":
                                    if (ttp.ConsoleDebug)
                                        Console.WriteLine("CHECK POINT");
                                    break;
                            }
                }
                catch (Exception ex)
                {
                    if (ttp.ConsoleDebug) Console.WriteLine("ERROR:" + ex.Message);
                    else CHECK_POINT_SendMail(DLL_Name + ":" + Node_Name + ":" + ex.Message + ". ITEM:" + Processable_URI);
                }
            }
            GlobalNodeCode = NodeCode;
        }/*END NODE_ACTION*/

        private void NODE_TRANSACTION(string NodeCode, int NodeIndex, XmlNode xmlNode, ref string Html, ref string ITEM, int ForeignID = 0, string FullFileURI = "", bool FullFileRead = false)
        {
            //string NodeCode, int NodeIndex, 
            NodeCode += ",t" + NodeIndex.ToString();
            GlobalNodeCode = NodeCode;
            if (NodeCode == "c0,c1,a1,c1,a1,c1,a1,t4")
            {
                NodeCode = NodeCode;
            }

            string Method_Name = "NODE_TRANSACTION";

            if ((FullFileURI != "") && (FullFileRead))
            {
                StreamReader sr = new StreamReader(FullFileURI);
                Html = sr.ReadToEnd();
                sr.Close();
            }

            //ArrayList Transaction_RegExp_Array = new ArrayList();
            int countRegExp = 20;
            string[,] Transaction_RegExp_Array2 = new string[countRegExp, 2];

            Hashtable Exclude_Key_Values = new Hashtable();
            string str_Exclude_Key_Values = "";
            bool BeforeClearLineEnds = false;

            #region TRANSACTION_Attributes
            string Load_To_SqlTable = "";//, Transaction_RegExp = "", Transaction_RegExp2 = "";

            string[,] RegExpArr = new string[countRegExp, 2];// { "RegExp", "RegExp1", "RegExp2", "RegExp3" };
            for (int i = 0; i < countRegExp; i++)
            {
                RegExpArr[i, 0] = "RegExp" + (i == 0 ? "" : i.ToString());
                RegExpArr[i, 1] = "EmptyRegExp" + (i == 0 ? "" : i.ToString());
                Transaction_RegExp_Array2[i, 0] = "";
                Transaction_RegExp_Array2[i, 1] = "";
            }
            foreach (XmlAttribute xmlAttr in xmlNode.Attributes) //Attributes
            {
                int indexRegExpItem = -1, indexRegExp = -1, indexEmptyRegExp = -1;
                //int indexRegExpItem = Array.IndexOf(RegExpArr, xmlAttr.Name);
                //for (int i = 0; i < countRegExp; i++)
                //    if (RegExpArr[i, 0] == xmlAttr.Name)
                //        indexRegExpItem = i;
                //if (indexRegExpItem > -1)
                for (int i = 0; i < countRegExp; i++)
                {
                    if (RegExpArr[i, 0] == xmlAttr.Name)
                        indexRegExp = i;
                    if (RegExpArr[i, 1] == xmlAttr.Name)
                        indexEmptyRegExp = i;
                    if (indexRegExp != -1 || indexEmptyRegExp != -1)
                    {
                        indexRegExpItem = i;
                        break;
                    }
                }

                if (indexRegExpItem > -1)
                {
                    //Transaction_RegExp_Array.Add(util.replace_place_to_value(@xmlAttr.Value));
                    if (indexRegExp != -1)
                        Transaction_RegExp_Array2[indexRegExp, 0] = util.replace_place_to_value(@xmlAttr.Value);
                    if (indexEmptyRegExp != -1)
                        Transaction_RegExp_Array2[indexEmptyRegExp, 1] = "empty";
                }
                else
                    switch (xmlAttr.Name)
                    {
                        case "Load_To_Procedure": Load_To_SqlTable = xmlAttr.Value; break;
                        case "Exclude_Key_Values": str_Exclude_Key_Values = xmlAttr.Value; break;
                        case "BeforeClearLineEnds": BeforeClearLineEnds = Convert.ToBoolean(xmlAttr.Value); break;
                    }
            }
            #endregion

            if (BeforeClearLineEnds)
            {
                Html = Html.Replace("\r\n", "");
                Html = Html.Replace("\n\r", "");
                Html = Html.Replace("\r", "");
                Html = Html.Replace("\n", "");
            }

            if (str_Exclude_Key_Values != "")
            {
                char[] sep1 = new char[1] { ';' };
                char[] sep2 = new char[1] { '=' };
                string[] key_values = str_Exclude_Key_Values.Split(sep1);
                foreach (string key_value in key_values)
                {
                    string[] key_val = key_value.Split(sep2);
                    Exclude_Key_Values.Add(key_val[0], key_val[1]);
                }
            }

            //if (FullFileURI.IndexOf("1000.htm") > -1) //CHECK POINT
            //{
            //    FullFileURI = FullFileURI;
            //}

            string field_Name, field_Value, field_ForeignID, field_TaskID, field_Value_By_RegExp,
                field_Not_Obligatory, field_Value_From_URI_By_RegExp;
            bool field_Value_EmptyRegExp = false;
            Hashtable field_value = new Hashtable();
            if (xmlNode.ChildNodes.Count > 0)
                foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
                    if ((xmlChildNode.Name == "PARAM") || (xmlChildNode.Name == "FIELD") || (xmlChildNode.Name == "PARAMETER"))
                    {
                        field_Name = field_Value = field_ForeignID = field_TaskID = field_Value_By_RegExp
                            = field_Not_Obligatory = field_Value_From_URI_By_RegExp = "";

                        field_Value_EmptyRegExp = false;
                        foreach (XmlAttribute xmlAttr in xmlChildNode.Attributes)
                            switch (xmlAttr.Name)
                            {
                                case "Name": field_Name = xmlAttr.Value; break;
                                case "Value": field_Value = util.replace_place_to_value(xmlAttr.Value); break;
                                case "Value_By_RegExp": field_Value_By_RegExp = util.replace_place_to_value(@xmlAttr.Value); break;
                                case "Value_From_URI_By_RegExp": field_Value_From_URI_By_RegExp = util.replace_place_to_value(@xmlAttr.Value); break;
                                case "EmptyRegExp": field_Value_EmptyRegExp = bool.Parse(xmlAttr.Value.ToUpper()); break;
                                case "ForeignID": field_ForeignID = xmlAttr.Value; break;
                                case "Not_Obligatory": field_Not_Obligatory = xmlAttr.Value; break;
                            }

                        if ((field_Value_By_RegExp != "") && (Html != "") ||
                            (field_Value_From_URI_By_RegExp != "") && (FullFileURI != "") ||
                            (field_Value_From_URI_By_RegExp != "") && (ITEM != "")
                            )
                        {
                            Match match = null;
                            try
                            {
                                if (field_Value_By_RegExp != "")
                                    match = Regex.Match(Html, field_Value_By_RegExp);

                                if (field_Value_From_URI_By_RegExp != "")
                                {
                                    if (ITEM != "")
                                        match = Regex.Match(ITEM, field_Value_From_URI_By_RegExp);
                                    else
                                        match = Regex.Match(FullFileURI, field_Value_From_URI_By_RegExp);
                                }

                                if (match.Success)
                                    field_Value = match.Groups[field_Name].Value;
                                else
                                    if (!((field_Not_Obligatory == "use") || (field_Not_Obligatory == "yes") || (field_Value_EmptyRegExp)))
                                    {
                                        if (field_Value_By_RegExp != "")
                                            CHECK_POINT_SendMail(DLL_Name + ":" + Method_Name + ": Empty Result Value_By_RegExp. ITEM:" + Processable_URI);
                                        if (field_Value_From_URI_By_RegExp != "")
                                            CHECK_POINT_SendMail(DLL_Name + ":" + Method_Name + ": Empty Result field_Value_From_URI_By_RegExp. ITEM:" + Processable_URI);
                                    }
                            }
                            catch (Exception ex)
                            {
                                if (ttp.ConsoleDebug)
                                    Console.WriteLine("ERROR:" + ex.Message);
                                else
                                    CHECK_POINT_SendMail(DLL_Name + ":" + Method_Name + ":" + ex.Message + ". ITEM:" + Processable_URI);
                            }
                        }
                        if ((field_Name == "TaskID") && (field_Value == "use"))
                            field_value.Add(field_Name, TaskID.ToString());
                        else
                            if ((field_Name == "Uri") && (field_Value == "use"))
                            {
                                field_value.Add(field_Name, Processable_URI);
                                //field_value.Add("FtpUri", FtpURI);
                            }
                            else
                                if (field_ForeignID == "use")
                                    field_value.Add(field_Name, ForeignID.ToString());
                                else
                                {
                                    field_Value = util.clear_value(field_Value);
                                    field_value.Add(field_Name, field_Value);
                                }
                    }

            MatchCollection fieldsOfRegExp = null;
            //foreach (string Transaction_RegExp in Transaction_RegExp_Array)
            for (int i = 0; i < countRegExp; i++)
            {
                string Transaction_RegExp = Transaction_RegExp_Array2[i, 0];
                if (Transaction_RegExp != "")
                {
                    string Transaction_RegExp_CLEARED = Transaction_RegExp;

                    MatchCollection GroupsForDel = Regex.Matches(Transaction_RegExp_CLEARED, @"\(\?<=.*?\)");
                    if (GroupsForDel.Count > 0)
                        foreach (Match groupForDel in GroupsForDel)
                            Transaction_RegExp_CLEARED = Transaction_RegExp_CLEARED.Replace(groupForDel.Groups[0].Value, "");

                    GroupsForDel = Regex.Matches(Transaction_RegExp_CLEARED, @"\(\?<!.*?\)");
                    if (GroupsForDel.Count > 0)
                        foreach (Match groupForDel in GroupsForDel)
                            Transaction_RegExp_CLEARED = Transaction_RegExp_CLEARED.Replace(groupForDel.Groups[0].Value, "");

                    fieldsOfRegExp = Regex.Matches(Transaction_RegExp_CLEARED, @"\(\?<(?<field_Name>.*?)\>");
                    foreach (Match matchFields in fieldsOfRegExp)
                    {
                        if (!field_value.ContainsKey(matchFields.Groups["field_Name"].Value))
                            field_value.Add((matchFields.Groups["field_Name"].Value), "");
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            if ((FullFileURI != "") && (!FullFileRead)) //Read By Line
            {
                StreamReader sr = new StreamReader(FullFileURI);
                string line = sr.ReadLine();
                while (line != null)
                {
                    sql_add(ref Html, ref Transaction_RegExp_Array2, ref fieldsOfRegExp, ref field_value, Load_To_SqlTable, ref sb, ref Exclude_Key_Values, ref ITEM);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            else //Read In Whole File
                sql_add(ref Html, ref Transaction_RegExp_Array2, ref fieldsOfRegExp, ref field_value, Load_To_SqlTable, ref sb, ref Exclude_Key_Values, ref ITEM);

            #region Exec Transaction
            string sqlTransaction = "";
            if (sb.Length > 0)
            {
                if (ProxyID > 0)
                    sqlTransaction = "INSERT bot_proxy_task_statistics (ProxyID,TaskID,GoodResp) VALUES(" + ProxyID.ToString() + "," + TaskID.ToString() + ",1); ";
                sqlTransaction += sb.ToString();
                sql.sqlCommandExecute(sqlTransaction);
                if (sql.error)
                    if (ttp.ConsoleDebug)
                        Console.WriteLine("ERROR:" + sql.errorMessage);
                    else
                        CHECK_POINT_SendMail(DLL_Name + ":" + Method_Name + ":" + sql.errorMessage + ". ITEM:" + Processable_URI + "SQL:" + sqlTransaction);
            }
            else
            {
                if (ProxyID > 0)
                {
                    sqlTransaction = "INSERT bot_proxy_task_statistics (ProxyID,TaskID,GoodResp) VALUES(" + ProxyID.ToString() + "," + TaskID.ToString() + ",0)";
                    sql.sqlCommandExecute(sqlTransaction);
                    if (sql.error)
                        if (ttp.ConsoleDebug)
                            Console.WriteLine("ERROR:" + sql.errorMessage);
                        else
                            CHECK_POINT_SendMail(DLL_Name + ":" + Method_Name + ":" + sql.errorMessage + ". ITEM:" + Processable_URI + "SQL:" + sqlTransaction);
                }
            }
            #endregion
            GlobalNodeCode = NodeCode;
        }

        private void sql_add(ref string Html, ref string[,] Transaction_RegExp_Array, ref MatchCollection fieldsOfRegExp, ref Hashtable field_value, string Load_To_SqlTable, ref StringBuilder sb, ref Hashtable Exclude_Key_Values, ref string ITEM)
        {
                string Method_Name = "sql_add"; int countRegExp = 0;
                for (int i = 0; i < 20; i++)
                    if (Transaction_RegExp_Array[i, 0] != "")
                        countRegExp++;

                if (countRegExp > 0)
                {
                    bool detectedValues = false, EmptyRegExp = false;
                    MatchCollection matchCollection = null;
                    for (int i = 0; i < 20; i++)
                    {
                        string Transaction_RegExp = Transaction_RegExp_Array[i, 0];
                        if (Transaction_RegExp_Array[i, 1] == "empty")
                            EmptyRegExp = true;
                        if (Transaction_RegExp != "")
                        {
                            matchCollection = Regex.Matches(Html, Transaction_RegExp, RegexOptions.None);
                          
                            if (matchCollection.Count > 0)
                            {
                                Console.WriteLine("matchCollection.Count == 1");
                                detectedValues = true;
                                foreach (Match matchValues in matchCollection)
                                {
                                    fieldsOfRegExp = Regex.Matches(Transaction_RegExp, @"\(\?<(?<field_Name>.*?)\>");
                                    foreach (Match matchFields in fieldsOfRegExp)
                                    {
                                        string field_Name = matchFields.Groups["field_Name"].Value;
                                        string value = matchValues.Groups[field_Name].Value.Trim();
                                        field_value[field_Name] = util.clear_value(value);
                                    }
                                    sql_add_2(Load_To_SqlTable, ref field_value, ref sb);
                                }
                            }
                            else
                            {
                                if (ttp.ConsoleDebug)
                                    Console.WriteLine("matchCollection.Count == 0");
                            }
                        }
                    }

                    if ((!detectedValues) && (!EmptyRegExp))
                    {
                        bool excludeDetected = false;
                        foreach (DictionaryEntry key_value in Exclude_Key_Values)
                            foreach (DictionaryEntry field_val in field_value)
                                if ((field_val.Key.ToString().Trim() == key_value.Key.ToString().Trim())
                                    && (field_val.Value.ToString().Trim() == key_value.Value.ToString().Trim()))
                                    excludeDetected = true;
                        if (!excludeDetected)
                            CHECK_POINT_SendMail(DLL_Name + ":" + Method_Name + ": Empty Result RegExp. ITEM:" + Processable_URI);
                    }
                }
                else
                    sql_add_2(Load_To_SqlTable, ref field_value, ref sb);
         
        }

        private void sql_add_2(string Load_To_SqlTable, ref Hashtable field_value, ref StringBuilder sb)
        {
            sqlCmd = "EXEC " + Load_To_SqlTable + " "; bool firstKey = true;
            foreach (DictionaryEntry key_value in field_value)
            {
                if (!firstKey)
                    sqlCmd += ", ";
                else
                    firstKey = false;
                sqlCmd += "@" + key_value.Key.ToString() + "='" + key_value.Value.ToString().Trim() + "'";
            }
            sb.AppendLine(sqlCmd);
        }

        private string get_path_mask(string path_with_fileMask)
        {
            string result = "";

            string DirFile = util.ReverseString(path_with_fileMask);
            string FileMask = "";
            if (DirFile.IndexOf("\\") > 0)
            {
                FileMask = DirFile.Substring(0, DirFile.IndexOf("\\"));
                FileMask = util.ReverseString(FileMask);
                DirFile = DirFile.Substring(DirFile.IndexOf("\\"));
            }
            DirFile = util.ReverseString(DirFile);
            if (Directory.Exists(DirFile))
            {
                string[] files = Directory.GetFiles(DirFile, FileMask);
                if (files.Length > 0)
                    result = DirFile + "|" + FileMask;
            }

            return result;
        }

        private void Action_Execute_Application(string FullFileURI, string Params = "")
        {
            if (File.Exists(FullFileURI))
            {
                ProcessStartInfo psi;
                if (Params != "")
                    psi = new ProcessStartInfo(FullFileURI, Params);
                else
                    psi = new ProcessStartInfo(FullFileURI);
                Process process = new Process();
                process.StartInfo = psi;
                if (ttp.ConsoleDebug)
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                else
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = true;
                if (!process.Start())
                    CHECK_POINT_SendMail("NOT STARTED Process:" + FullFileURI);
            }
            else
                CHECK_POINT_SendMail("NOT EXISTS Application:" + FullFileURI);
        }

        private void Action_Work_With_Files(string FullFileURI, string Action = "", string Param = "")
        {
            //CHECK_POINT_SendMail("Check_For == Exists");
            FileInfo fi;
            string DirFile = util.ReverseString(FullFileURI);
            string FileMask = "*.*";
            if (DirFile.IndexOf("\\") > 0)
            {
                FileMask = DirFile.Substring(0, DirFile.IndexOf("\\"));
                FileMask = util.ReverseString(FileMask);
                DirFile = DirFile.Substring(DirFile.IndexOf("\\"));
            }
            DirFile = util.ReverseString(DirFile);
            if (Directory.Exists(DirFile))
            {
                string[] files = Directory.GetFiles(DirFile, FileMask);
                string[] directories = Directory.GetDirectories(DirFile);
                switch (Action)
                {
                    case "Checking_Files_For_Exists":
                        if (files.Length == 0)
                            CHECK_POINT_SendMail("NOT EXISTS : " + FullFileURI);
                        break;

                    case "Checking_Files_Size_More":
                        if (files.Length == 0)
                            CHECK_POINT_SendMail("NOT EXISTS : " + FullFileURI);
                        else
                        {
                            foreach (string file in files)
                            {
                                try
                                {
                                    fi = new FileInfo(file);
                                    if (fi.Length <= int.Parse(Param))
                                        CHECK_POINT_SendMail("FILE ERROR: File Size wrong : " + FullFileURI);
                                }
                                catch (Exception ex)
                                {
                                    CHECK_POINT_SendMail("FILE ERROR: Not Checked File Info With Size: " + FullFileURI + " ; " + ex.Message);
                                }
                            }
                        }
                        break;

                    case "Checking_Files_For_Count":
                        int Param_Count = int.Parse(Param);
                        if (files.Length != Param_Count)
                            CHECK_POINT_SendMail("COUNT IS NOT VALID : " + FullFileURI);
                        break;
                    case "Checking_Files_For_Empty_Dir":
                        bool Param_WithDir = true;
                        if (Param != "")
                            Param_WithDir = false;
                        if ((files.Length > 0) || ((directories.Length > 0) && (Param_WithDir)))
                        {
                            string example = "";
                            if (files.Length > 0)
                                example = files[0].ToString();
                            else
                                example = directories[0].ToString();
                            if (Param == "8")
                                util.CHECK_POINT_SendMail_v2(connStr, "DETECTED NEW FILE : " + example, "20", "8");
                            else
                                CHECK_POINT_SendMail("DIR IS NOT EMPTY : " + FullFileURI + ", EXAMPLE:" + example);
                        }
                        break;
                    case "Clear_Dir":
                        Clear_FileURI(FullFileURI);
                        break;
                    case "Delete_File":
                        Clear_FileURI(FullFileURI);
                        break;
                    case "Flat_Import_File_Add":
                        if (ttp.ConsoleDebug)
                            Console.WriteLine("DETECTED COUNT Files : " + files.Length.ToString());
                        Flat_Import_File_Add(ref files, Param);
                        break;
                    case "Move_File_To_Archive":
                        Move_File_To_Archive(ref FullFileURI, ref DirFile, ref FileMask);
                        break;
                }
            }
            else //CHECK
                CHECK_POINT_SendMail("NOT EXISTS DIRECTORY : " + DirFile);
        }

        private void Move_File_To_Archive(ref string FullFileURI, ref string DirFile, ref string FileMask)
        {
            string sourceFileName = FullFileURI;
            string ArchiveDir = DirFile + @"Archive\";
            string destFileName = ArchiveDir + "{YYYYMMDD_HHMM}_" + FileMask;
            destFileName = util.change_date_mask(destFileName);
            if (!Directory.Exists(ArchiveDir))
            {
                try
                {
                    Directory.CreateDirectory(ArchiveDir);
                }
                catch (Exception ex)
                {
                    CHECK_POINT_SendMail("Can't create dir : " + ArchiveDir + " : " + ex.Message);
                }
                if (Directory.Exists(ArchiveDir))
                {
                    try
                    {
                        File.Move(sourceFileName, destFileName);
                    }
                    catch (Exception ex)
                    {
                        CHECK_POINT_SendMail("Can't move file to archive : " + sourceFileName + " to " + destFileName + " : " + ex.Message);
                    }
                }
            }
        }

        private void Flat_Import_File_Add(ref string[] files, string TaskID)
        {
            string[] FlatExtensions = { ".txt", ".csv", "." };

            foreach (string file in files)
            {
                string Ext = "";
                Ext = util.ReverseString(file);
                Ext = Ext.Substring(0, Ext.IndexOf("\\"));
                Ext = Ext.Substring(0, Ext.IndexOf(".") + 1);
                Ext = util.ReverseString(Ext).ToLower();
                if (Array.IndexOf(FlatExtensions, Ext) > -1)
                {
                    string FileURI = file;
                    FileInfo fi = new FileInfo(FileURI);
                    long FileSize = fi.Length;
                    DateTime FileTime = fi.CreationTime;

                    string ArchiveDirectory = fi.DirectoryName + @"\Archive\";
                    if (!Directory.Exists(ArchiveDirectory)) Directory.CreateDirectory(ArchiveDirectory);
                    string ArchiveFileName = "{YYYYMMDD_HHMMSS}_" + fi.Name;
                    ArchiveFileName = util.replace_place_to_value(ArchiveFileName);
                    string FileDestination = ArchiveDirectory + ArchiveFileName;

                    sql.Parameters = new SqlParameter[7];
                    sql.Parameters[0] = new SqlParameter("TaskID", TaskID);
                    sql.Parameters[1] = new SqlParameter("FileURI", FileURI);
                    sql.Parameters[2] = new SqlParameter("FileSize", FileSize);
                    sql.Parameters[3] = new SqlParameter("FileTime", FileTime);
                    sql.Parameters[4] = new SqlParameter("FileCreationTime", fi.CreationTime);
                    sql.Parameters[5] = new SqlParameter("FileLastWriteTime", fi.LastWriteTime);
                    sql.Parameters[6] = new SqlParameter("ArchiveFileName", ArchiveFileName);

                    sql.Execute("flat_import_file_add", true);
                    if (sql.error)
                        util.CHECK_POINT_SendMail_v2(connStr, "ERROR: " + DLL_Name + ": Insert file To Flat Import SubSystem: " + sql.errorMessage, "10", "", TaskID);

                    string returned_ArchiveFileName = sql.dataSet.Tables[0].Rows[0][0].ToString();
                    if (returned_ArchiveFileName == ArchiveFileName)
                        try
                        {
                            File.Copy(FileURI, FileDestination);
                        }
                        catch
                        {//(Exception ex)
                            util.CHECK_POINT_SendMail_v2(connStr, "ERROR: " + DLL_Name + ": Flat Import SubSystem: Cant copy file to Archive : " + FileDestination, "10", "", TaskID);
                        }
                }
                else
                {
                    util.CHECK_POINT_SendMail_v2(connStr, "ERROR: " + DLL_Name + ": Flat Import SubSystem: Wrong Extension:" + Ext + ", For:" + file, "10", "", TaskID);
                }
            }
        }

        private void Clear_FileURI(string uri, bool delRoot = false)
        {
            if (File.Exists(uri))
            {
                try
                {
                    File.SetAttributes(uri, FileAttributes.Archive);
                    File.Delete(uri);
                }
                catch //(Exception ex) 
                { }

            }
            else //check dir
                if (Directory.Exists(uri))
                {
                    //Directories
                    DirectoryInfo directoryInfo = new DirectoryInfo(uri);
                    try
                    {
                        directoryInfo.Attributes = FileAttributes.Archive;
                    }
                    catch //(Exception ex) 
                    { }

                    DirectoryInfo[] dirsInfo = directoryInfo.GetDirectories();
                    if (dirsInfo.Length > 0)
                        foreach (DirectoryInfo dirInfo in dirsInfo)
                            Clear_FileURI(dirInfo.FullName, true);

                    //Files
                    FileInfo[] files = directoryInfo.GetFiles();
                    if (files.Length > 0)
                        foreach (FileInfo file in files)
                        {
                            try
                            {
                                File.SetAttributes(file.FullName, FileAttributes.Archive);
                                file.Delete();
                            }
                            catch { }
                        }

                    // Delete Empty dir
                    if (delRoot)
                        try
                        {
                            Directory.Delete(uri);
                        }
                        catch //(Exception ex) 
                        { }

                }
        }

        private RegexOptions getRegexOptions(RegexOptions[] regexOptions)
        {
            RegexOptions options = new RegexOptions();
            foreach (RegexOptions option in regexOptions)
                options |= option;
            return options;
        }
    }
}
