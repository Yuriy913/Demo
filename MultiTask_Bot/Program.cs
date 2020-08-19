using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Investars.Bots.Utils;
using Investars.Bots.Utils.Misc;
using Investars.Bots.Utils.Application;
using System.Diagnostics;
using System.Threading;

namespace MultiTask_Bot
{
    class Program
    {
        #region Variables
            static App app;
            static Sql sql;
            static Util util = new Util();
            static string sqlCmd;
            static string compName = Environment.MachineName;
            static Process winProc = Process.GetCurrentProcess();
            static int TaskID;
        #endregion

        static void Main(string[] args)
        {
            app = new App(args);
            sql = new Sql(app.ConnString_SupportDB);
            Console.WriteLine("ConnStr : " + app.ConnString_SupportDB);
            if (args.Length == 1)
            {
                TaskID = int.Parse(args[0]);
                Console.WriteLine("TaskID : " + TaskID.ToString());
                sqlCmd = "MultiTask_BotLoader @IO = 6, @TaskID = " + TaskID.ToString(); //GET TaskTypeID
                sql.Execute(sqlCmd);
                if (!sql.error)
                {
                    int TaskTypeID = (int)sql.dataSet.Tables[0].Rows[0][0];
                    Console.WriteLine("TaskTypeID : " + TaskTypeID.ToString());
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Parent Thread:BEGIN");
                    //---------------------------------------
                    TaskType_Param_2 ttp = new TaskType_Param_2(TaskTypeID, TaskID, app.ConnString_SupportDB);
                    Thread th = new Thread(new ParameterizedThreadStart(thread_do));
                    th.Start((object)ttp);
                    //---------------------------------------
                    Console.WriteLine("Parent Thread:END");
                    Console.WriteLine("-----------------------------------");
                }
                else
                {
                    Console.WriteLine("ERROR : GET TaskTypeID is WRONG");
                }
            }
            else
            {
                Console.WriteLine("PARAMS WRONG : args.Length != 1");
            }
        }
        private static void thread_do(object p)
        {
            DateTime StartTime = DateTime.Now;
            Console.WriteLine("===================================");
            Console.WriteLine("Child Thread: BEGIN");
            //---------------------------------------
            string sqlCmd = "EXEC bot_computer_process @IO=2, @ComputerName='" + compName + "', @ProcessName='" + winProc.ProcessName + "', @ComputerProcessID=" + winProc.Id.ToString() + ", @TaskID=" + TaskID.ToString()+", @BotID=2";

            //---------------------------
            //util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, sqlCmd);
            //---------------------------

            sql.Execute(sqlCmd);
            if (sql.error)
                util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, ":ERROR:" + sql.errorMessage);
            else
            {
                sqlCmd = "EXEC MultiTask_BotLoader @IO=3, @TaskID=" + TaskID.ToString() + ", @ComputerProcessID=" + winProc.Id.ToString(); //SET LOCKED
                sql.Execute(sqlCmd);
                if (sql.error)
                    util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, "ERROR: Not Locked TaskID = " + TaskID.ToString() + ", " + sql.errorMessage);
                else
                {
                    //util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, "CHECK: Start TaskID = " + TaskID.ToString());

                    TaskTypeID_Execute ttd;
                    ttd = new TaskTypeID_Execute(p);
                    //---------------------------------------
                    sqlCmd = "EXEC bot_computer_process @IO=6, @ComputerName='" + compName + "', @ComputerProcessID=" + winProc.Id.ToString();
                    sql.Execute(sqlCmd);
                    if (sql.error)
                        util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, ":ERROR:" + sql.errorMessage);
                    //---------------------------------------
                    Console.WriteLine("Child Thread: DONE");
                    Console.WriteLine("===================================");
                    DateTime EndTime = DateTime.Now;
                    sql.Execute("EXEC MultiTask_BotLoader @IO=0, @BotID=2, @TaskID=" + TaskID.ToString() + ", @StartTime='" + StartTime.ToString() + "', @EndTime='" + EndTime.ToString() + "'");
                }
            }
        }
    }
}
