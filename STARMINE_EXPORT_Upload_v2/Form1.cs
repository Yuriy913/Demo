using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Investars.Bots.Utils.Misc;
using Investars.Bots.Utils.Application;

namespace STARMINE_EXPORT_Upload_v2
{
    public partial class Form1 : Form
    {
        public bool Debug = false;
        //public bool Debug = true;

        #region Variables
            App app;
            Sql sql;
            Util util = new Util();

            const int countFiles = 5, countTryUpload = 50;
            public int fileIndex = 0;
            string[] files = new string[countFiles];

            string day = DateTime.Today.Day.ToString();
            string month = DateTime.Today.Month.ToString();
            string year = DateTime.Today.Year.ToString();

            int hour = DateTime.Now.Hour;
            int intDay = DateTime.Today.Day;
            int intMonth = DateTime.Today.Month;
            int intYear = DateTime.Today.Year;

            public string BatchDate = "{YYYY}-{MM}-{DD}";

            int tryUpload = 0;

        #endregion
        public Form1()
        {
            InitializeComponent();

            //string @PCName = Environment.MachineName;

            try
            {
                string[] cmdLine = Environment.GetCommandLineArgs();
                app = new App(cmdLine);
                if (cmdLine.Length > 1)
                    if (cmdLine[1].ToLower() == "debug") Debug = true;
            }
            catch { }
            sql = new Sql(app.ConnString_SupportDB);

            files[0] = @"D:\FTPRoot\Download\Fidelity\XML\fcom-Security-Full-{YYYY}-{MM}-{DD}.xml.zip";
            files[1] = @"D:\FTPRoot\Download\Fidelity\XML\fcom-Recommendation-Incremental-{YYYY}-{MM}-{DD}.xml.zip";
            files[2] = @"D:\FTPRoot\Download\Fidelity\XML\fcom-Contributor-Full-{YYYY}-{MM}-{DD}.xml.zip";
            files[3] = @"D:\FTPRoot\Download\Fidelity\XML\fcom-Analyst-Full-{YYYY}-{MM}-{DD}.xml.zip";
            files[4] = @"D:\FTPRoot\Download\Fidelity\XML\upload_complete.tag";

            if (Debug)
                intDay = 3; //CLOSE AFTER DEBUG

            if (intDay < 10) 
                day = "0";
            day += intDay.ToString();

            if (intMonth < 10) 
                month = "0";
            month += intMonth.ToString();

            for (int i = 0; i < countFiles; i++)
            {
                files[i] = files[i].Replace("{DD}", day);
                files[i] = files[i].Replace("{MM}", month);
                files[i] = files[i].Replace("{YYYY}", year);
            }
            BatchDate = BatchDate.Replace("{DD}", day);
            BatchDate = BatchDate.Replace("{MM}", month);
            BatchDate = BatchDate.Replace("{YYYY}", year);

            timer1.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CHECK_POINT_SendMail(string Text)
        {
            util.CHECK_POINT_SendMail_v2(app.ConnString_SupportDB, Text, "24");
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            tryUpload++;
            if (try_upload(files[fileIndex]))
            {
                tryUpload = 0;
                fileIndex++;
                if (fileIndex == countFiles)
                    Close();
            }
            else
                CHECK_POINT_SendMail("TRY Upload: " + tryUpload.ToString()+", FOR: " + files[fileIndex]);

            if (Debug)
            {
                fileIndex++;
                tryUpload = 0;
            }
            else
                if (tryUpload == countTryUpload)
                {
                    CHECK_POINT_SendMail("ERROR: BAD Upload Starmine File:" + files[fileIndex]);
                    Close();
                }

            if (fileIndex < countFiles)
                timer1.Enabled = true;
            else
                Close();
        }

        private bool try_upload(string file)
        {
            bool goodResult = false;
            if (File.Exists(file))
            {
                goodResult = true;
                Process newProcess = new Process();
                newProcess.StartInfo.WorkingDirectory = @"D:\FTPRoot\Download\Fidelity\XML\";
                if (Environment.MachineName == "INVESTARSD2950")
                    newProcess.StartInfo.FileName = @"D:\NETSTUFF\CURL\CURL7195\curl.exe";
                else
                    newProcess.StartInfo.FileName = @"D:\NETSTUFF\CURL\CURL7281\curl.exe";

                CHECK_POINT_SendMail("INFO: STARMINE Upload USED : " + newProcess.StartInfo.FileName);

                if (Debug)
                    newProcess.StartInfo.CreateNoWindow = false;
                else
                    newProcess.StartInfo.CreateNoWindow = true;

                newProcess.StartInfo.UseShellExecute = false;
                newProcess.StartInfo.RedirectStandardOutput = true;

                string processArguments = "";
                if (file == @"D:\FTPRoot\Download\Fidelity\XML\upload_complete.tag")
                    processArguments = " --insecure --url https://fcominvest:fcom8439@datafeed.starmine.com --ciphers RC4-MD5 --form supplier=fcom --form date=" + BatchDate + " --form action=upload-complete --form consolidator=1 --form success_recipient=fidelity@investars.com --form error_recipient=fidelity@investars.com --trace-ascii _complete_log.txt --trace-time --retry 4";
                else
                    processArguments = "--insecure --url https://fcominvest:fcom8439@datafeed.starmine.com --ciphers RC4-MD5 --form supplier=fcom --form file_format=xml --form file_packaging=zip --form sec_method=none --form action=upload --form consolidator=1 --form MAX_FILE_SIZE=10000000 --form success_recipient=fidelity@investars.com --form error_recipient=fidelity@investars.com --trace-ascii _recomm_log.txt --trace-time --retry 4 --form userfile=@" + file;

                newProcess.StartInfo.Arguments = " " + processArguments.Trim();
                newProcess.Start();

                newProcess.WaitForExit();
                int exitCode = -1;
                exitCode = newProcess.ExitCode;
                string targerServerAnswer = newProcess.StandardOutput.ReadToEnd();

                CHECK_POINT_SendMail("File : " + files[fileIndex] + ", " + targerServerAnswer);

                newProcess.Close();
                try
                {
                    newProcess.Dispose();
                }
                catch //(Exception ex)
                {
                    //util.CHECK_POINT_SendMail_v2(connStr, "newProcess.Dispose();" + ex.Message, "2", "1", TaskID.ToString());
                }

                string CheckString = "<upload result=\"0\">";

                int checkStringFlag = 0;
                if (CheckString != "NA")
                    checkStringFlag = targerServerAnswer.IndexOf(CheckString);

                if ((exitCode != 0) || (checkStringFlag < 0))
                    goodResult = false;
                else
                    copy_file_to_archive(file);
            }
            return goodResult;
        }

        private void copy_file_to_archive(string file)
        {
            string FileName = file;
            char[] arr = FileName.ToCharArray();
	        Array.Reverse(arr);
            FileName = new string(arr);
            FileName = FileName.Substring(0,FileName.IndexOf("\\"));
            arr = FileName.ToCharArray();
            Array.Reverse(arr);
            FileName = new string(arr);
            string ArchiveFile = @"D:\FTPRoot\Download\Fidelity\XML\Archive\" + FileName;
            try{
                File.Move(file, ArchiveFile);
            }
            catch
            {
            }
        }

    }
}
