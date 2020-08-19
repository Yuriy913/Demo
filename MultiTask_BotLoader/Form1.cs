using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Investars.Bots.Utils.Misc;
using Investars.Bots.Utils.Application;
using System.Diagnostics;

namespace MultiTask_BotLoader
{
    public partial class Form1 : Form
    {
        #region Variables
            bool Debug;
            Util util = new Util();
            string connStr; //? -двойное использование переменной соединения. нужно ли такое?
            Sql sql;
            string cmdSql;
            int timer1_tick = 0, timer2_tick = 0, timer2_suspendCount = 0;
            public App app;

            string compName = Environment.MachineName;
            Process winProc = Process.GetCurrentProcess();
            string sqlCmd;
            DateTime StartTime = DateTime.Now;

            DataSet1 dataSet1 = new DataSet1();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] cmdLine = Environment.GetCommandLineArgs();
                app = new App(cmdLine);
                if (cmdLine.Length > 1)
                    if (cmdLine[1].ToLower() == "debug") Debug = true;
            }
            catch { }

            //------------------------------------------------------------
            // Start App. Registrate Process.
            //------------------------------------------------------------
            sql = new Sql(app.ConnString_SupportDB);
            //Registrate process
            sqlCmd = "EXEC bot_computer_process @IO=2, @ComputerName='" + compName + "', @ProcessName='" + winProc.ProcessName + "', @ComputerProcessID=" + winProc.Id.ToString() + ", @BotID=1";
            sql.Execute(sqlCmd);
            //------------------------------------------------------------

            if (!Debug)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Visible = false;
            }
            //sql = new Sql(app.ConnString_SupportDB);
            InitializeComponent();
            if (Debug)
                timer1.Interval = 1000; // 1 sec.
            timer1.Enabled = true;
        }

        private bool checkUpdates()
        {
            bool result = false;
            //получение рабочего каталога и каталога обновлений
            string Dir_Current = Application.StartupPath;
            string Dir_Updates = Dir_Current + "\\Updates";
            try
            {
                Directory.CreateDirectory(Dir_Updates);
                // поиск фалой обновлений
                string[] files = Directory.GetFiles(Dir_Updates, "*.exe");
                if (files.Length > 0) result = true;
                if (!result)
                {
                    files = Directory.GetFiles(Dir_Updates, "*.dll");
                    if (files.Length > 0) result = true;
                }
            }
            catch { }
            return result;
        }

        private void CHECK_POINT_SendMail(string Message)
        {
            util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, Message);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer1_tick != timer2_tick)
            {
                timer2_tick = timer1_tick;
                timer2_suspendCount = 0;
            }
            else
                timer2_suspendCount++;
            if (timer2_suspendCount == 3)
            {
                timer2_suspendCount = 0;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1_tick++;
            DateTime StartTime = DateTime.Now;

            if (dataSet1.Tables["CheckWork"].Rows.Count == 0)
            {
                DataRow rowNew = dataSet1.Tables["CheckWork"].NewRow();
                rowNew["LastTime"] = StartTime;
                dataSet1.Tables["CheckWork"].Rows.Add(rowNew);
            }
            else
                dataSet1.Tables["CheckWork"].Rows[0]["LastTime"] = StartTime;
            try
            {
                dataSet1.WriteXmlSchema("MultiTask_BotLoader_Schema.xml");
                dataSet1.WriteXml("MultiTask_BotLoader_Data.xml");
            }
            catch { }

            //-------------------------------
            //util.CHECK_POINT_SendMail(connStr, "MultiTask_BotLoader: CHECK POINT");
            //-------------------------------

            sql.Execute("EXEC MultiTask_BotLoader @IO=1, @StartTime='" + StartTime.ToString() + "'"); //Reg Timer Here
            if (sql.error)
                util.CHECK_POINT_SendMail(connStr, "MultiTask_BotLoader: DS_Tasks: ERROR of QUERY !!!");
            else
            {
                if (sql.dataSet.Tables.Count == 0)
                    util.CHECK_POINT_SendMail(connStr, "EXEC MultiTask_BotLoader: Tasks: Tables.Count == 0 !!!");
                else
                    if (sql.dataSet.Tables[0].Rows.Count == 0)
                    {   //CHECK POINT
                        //util.CHECK_POINT_SendMail(connStr, "MultiTask_BotLoader: Tasks: Tables[0].Rows.Count == 0 !!!");
                    }
                    else
                        foreach (DataRow row_task in sql.dataSet.Tables[0].Rows)
                            if (row_task["TaskID"] != DBNull.Value)
                            {
                                int TaskID = (int)row_task["TaskID"];
                                //--------------------------------------------------
                                // PreLocked
                                //--------------------------------------------------
                                cmdSql = "EXEC MultiTask_BotLoader @IO=2, @TaskID=" + TaskID.ToString();
                                sql.Execute(cmdSql);
                                if (!sql.error)
                                {
                                    Process process = new Process();
                                    process.StartInfo.FileName = "MultiTask_Bot.exe";
                                    process.StartInfo.Arguments = TaskID.ToString();
                                    process.Start();
                                }
                            }
            }

            //DateTime EndTime = DateTime.Now;
            //sql.Execute("MultiTask_BotLoader @IO=0, @BotID=1, @StartTime='" + StartTime.ToString() + "', @EndTime='" + EndTime.ToString() + "'");

            if (timer1_tick == 60)
                timer1_tick = 0;

            if (checkUpdates())
            {
                Process.Start("AppUpdater.exe");
                Close();
            }

            timer1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //------------------------------------------------------------
            // End App. Close Process.
            //------------------------------------------------------------
            DateTime EndTime = DateTime.Now;
            sqlCmd = "EXEC MultiTask_BotLoader @IO=0, @BotID=1, @StartTime='" + StartTime.ToString() + "', @EndTime='" + EndTime.ToString() + "'";
            sql.Execute(sqlCmd);

            sqlCmd = "EXEC bot_computer_process @IO=6, @ComputerName='" + compName + "', @ComputerProcessID=" + winProc.Id.ToString();
            sql.Execute(sqlCmd);
            //------------------------------------------------------------
        }
    }
}
