using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MultiTask_BotLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            bool processDetected = false;
            int countProcesses = 0;
            Process[] Processes = Process.GetProcesses();
            foreach (Process process in Processes)
                if ((process.ProcessName == "MultiTask_BotLoader") || (process.ProcessName == "MultiTask_BotLoader.exe"))
                    countProcesses++;
            if (countProcesses > 1)
                processDetected = true;

            if (!processDetected)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
