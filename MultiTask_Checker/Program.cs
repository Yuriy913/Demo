using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Threading;

namespace MultiTask_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();
            if (File.Exists("MultiTask_BotLoader_Schema.xml"))
            {
                Thread.Sleep(10000);
                try
                {
                    dataSet.ReadXmlSchema("MultiTask_BotLoader_Schema.xml");
                    dataSet.ReadXml("MultiTask_BotLoader_Data.xml");
                    try
                    {
                        File.Delete("MultiTask_BotLoader_Schema.xml");
                        File.Delete("MultiTask_BotLoader_Data.xml");
                    }
                    catch { }
                    DateTime LastTime = (DateTime)dataSet.Tables["CheckWork"].Rows[0]["LastTime"];
                    DateTime CurrentTime = DateTime.Now;
                    int Minutes = ((TimeSpan)(CurrentTime - LastTime)).Minutes;
                    if (Minutes >= 10)
                    {
                        Process[] Processes = Process.GetProcesses();
                        foreach (Process process in Processes)
                            if (process.ProcessName == "MultiTask_BotLoader.exe")
                            {
                                process.Kill();
                                Process newProcess = new Process();
                                newProcess.StartInfo.FileName = @"d:\NETSTUFF\Bots\MultiTask_Bot\MultiTask_BotLoader.exe";
                                newProcess.Start();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
