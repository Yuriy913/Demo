using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Investars.Bots.Utils.Misc;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SQL_Alerts_SubSystem
{
    public partial class Form1 : Form
    {
        #region Variables
            Sql sql = new Sql("user id=botclient;password=tatamas4k;data source=SQL_DATA_SUPPORT;persist security info=True;initial catalog=SupportDB");
            string sqlCmd;
            string Dir_Updates, Dir_App;
            string FtpFilesInfo_Xml;
            //DataSet2 dataSet_FtpFilesInfo = new DataSet2();
            //DataSet_FtpFilesInfo dataSet_FtpFilesInfo = new DataSet_FtpFilesInfo();
            Ftp ftp;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string Person = toolStripComboBox1.Text;
            sqlCmd = "alert_messages_APP @IO = 0, @Person = '" + Person + "'";
            sql.Execute(sqlCmd);
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
            {
                dataGridView1.DataSource = sql.dataSet.Tables[0];
                if (dataGridView1.Rows.Count > 0)
                {
                    toolStripButton3.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton13.Enabled = true;
                    toolStripButton14.Enabled = true;
                }
            }
            toolStripLabel4.Checked = true;
            toolStripLabel6.Checked = true;
            toolStripButton8.Checked = true;
            groupBox1.Text = "COUNT:" + dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                richTextBox_SQL.Text = "";
                richTextBox_SQL.BackColor = Color.White;
                toolStripTextBox3.Text = "";
                toolStripTextBox3.Text = "";
                toolStripTextBox4.Text = "";
                toolStripButton10.Enabled = false;
                //toolStripButton9.Enabled = false;
                toolStripButton12.Enabled = false;
                int MessageID = (int)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value;
                toolStripTextBox2.Text = MessageID.ToString();
                
                int UnitID = (int)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value;
                toolStripLabel5.Text = UnitID.ToString();

                int TaskID = (int)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value;
                toolStripLabel7.Text = TaskID.ToString();

                toolStripTextBox1.Text = "";
                if (dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["TaskName"].Value != DBNull.Value)
                    toolStripTextBox1.Text = (string)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["TaskName"].Value;

                sqlCmd = "alert_messages_APP @IO = 1, @MessageID=" + MessageID.ToString();
                sql.Execute(sqlCmd);
                if (sql.error)
                    MessageBox.Show(sql.errorMessage);
                else
                {
                    string FullMessage = sql.dataSet.Tables[0].Rows[0]["FullMessage"].ToString();
                    string FileURI = Application.StartupPath+"\\Last_FullMessage.html";
                    StreamWriter sw = new StreamWriter(FileURI);
                    sw.WriteLine("<HTML><BODY>");
                    sw.WriteLine(FullMessage);
                    sw.WriteLine("</BODY></HTML>");
                    sw.Close();
                    webBrowser1.Navigate(FileURI);

                    Match match = Regex.Match(FullMessage,@"ForeignID:\[(?<ForeignID>.*?)\]"); 
                    if (match.Success)
                    {
                        toolStripTextBox3.Text = match.Groups["ForeignID"].Value;
                        //toolStripButton9.Enabled = true;
                    }

                    match = Regex.Match(FullMessage, "SQL:(?<sqlEXEC>.*)");
                    if (match.Success)
                    {
                        richTextBox_SQL.BackColor = Color.Yellow;
                        richTextBox_SQL.Text = match.Groups["sqlEXEC"].Value;
                        toolStripButton10.Enabled = true;
                    }

                    match = Regex.Match(FullMessage,"URI:\\[<a href=\"(?<URI>.*?)\""); 
                    if (match.Success)
                    {
                        toolStripTextBox4.Text = match.Groups["URI"].Value;
                        toolStripButton12.Enabled = true;
                        if (toolStripButton11.Checked)
                            if (!toolStripButton10.Enabled)
                                toolStripButton12_Click(null, null);
                    }

                    sqlCmd = "alert_messages_APP @IO = 4, @MessageID=" + MessageID.ToString();
                    sql.Execute(sqlCmd);
                    if (sql.error)
                        MessageBox.Show(sql.errorMessage);
                    else
                        dataGridView2.DataSource = sql.dataSet.Tables[0];
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string File1 = Dir_App + "\\SQL_Alerts_SubSystem.exe";
            FileInfo fi = new FileInfo(File1);
            toolStripStatusLabel2.Text = fi.LastWriteTime.ToString();
        }

        private void fill_persons()
        {
            sql.Execute("alert_messages_APP @IO = 2");
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
            {
                foreach (DataRow row in sql.dataSet.Tables[0].Rows)
                {
                    toolStripComboBox1.Items.Add(row["Name"].ToString());
                }
                toolStripComboBox1.SelectedIndex = 0;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int MessageID = (int)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value;
                sqlCmd = "alert_messages_APP @IO = 3, @MessageID=" + MessageID.ToString();
                sql.Execute(sqlCmd);
                if (sql.error)
                    MessageBox.Show(sql.errorMessage);
                else
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
            if (dataGridView1.Rows.Count == 0)
            {
                toolStripButton3.Enabled = false;
                toolStripButton7.Enabled = false;
                toolStripButton13.Enabled = false;
                toolStripButton14.Enabled = false;
            }
            groupBox1.Text = "COUNT:" + dataGridView1.Rows.Count.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dir_App = Application.StartupPath;
            Dir_Updates = Dir_App + "\\Updates";
            FtpFilesInfo_Xml = Dir_App + "\\FtpFilesInfo.xml";
            if (!Directory.Exists(Dir_Updates))
                Directory.CreateDirectory(Dir_Updates);
            //if (File.Exists(FtpFilesInfo_Xml))
            //    dataSet_FtpFilesInfo.ReadXml(FtpFilesInfo_Xml);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dataSet_FtpFilesInfo.WriteXml(FtpFilesInfo_Xml);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Check_And_Download_New_File(string FileName, string ToDir)
        {
            /*
            DateTime FileTime = DateTime.Parse("1900-01-01 01:01");
            DataRow rowDetected = null;
            foreach (DataRow row in dataSet_FtpFilesInfo.Tables["FtpFilesInfo"].Rows)
                if ((string)row["FileName"] == FileName)
                {
                    rowDetected = row;
                    FileTime = (DateTime)row["FileTime"];
                    break;
                }
            ftp.Check_And_Download_New_File(FileName, FileTime, ToDir);
            if (ftp.last_check_file_code == 4)
            {
                if (rowDetected != null)
                    rowDetected["FileTime"] = ftp.last_check_file_time;
                else
                {
                    DataRow row = dataSet_FtpFilesInfo.Tables["FtpFilesInfo"].NewRow();
                    row["FileName"] = FileName;
                    row["FileTime"] = ftp.last_check_file_time;
                    dataSet_FtpFilesInfo.Tables["FtpFilesInfo"].Rows.Add(row);
                }
            }//*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add("-------------------------------------------------");
            //------------------------------------
            string File1 = Dir_App + "\\SQL_Alerts_SubSystem.exe";
            FileInfo fi = new FileInfo(File1);
            listBox1.Items.Add(File1);
            listBox1.Items.Add("CreationTime : " + fi.CreationTime.ToString());
            listBox1.Items.Add("LastWriteTime : " + fi.LastWriteTime.ToString());
            //------------------------------------
            string File2 = Dir_App + "\\Investars.Bots.Utils.dll";
            fi = new FileInfo(File2);
            listBox1.Items.Add(File2);
            listBox1.Items.Add("CreationTime : " + fi.CreationTime.ToString());
            listBox1.Items.Add("LastWriteTime : " + fi.LastWriteTime.ToString());
            //------------------------------------
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            /*
            string strYear = DateTime.Today.Year.ToString();
            DateTime StartYearDate = DateTime.Parse(strYear + "-01-01 01:01");

            DataRow[] rows = dataSet_FtpFilesInfo.Tables["FtpFilesInfo"].Select("FileTime < '" + StartYearDate + "'");
            if (rows.Length > 0)
                foreach (DataRow row in rows)
                    dataSet_FtpFilesInfo.Tables["FtpFilesInfo"].Rows.Remove(row);

            try
            {
                string PopMessage = "Detected New Downloaded Files !!!\r\nSwitch to tabPage 'Updates' and click button [Update Applications And Libraries].";
                ftp = new Ftp("ftp.investars.com", "AppUpdates", "");
                if (!ftp.Exists_Downloaded_New_Files(Dir_Updates))
                {
                    listBox1.Items.Add("Check and Download : AppUpdater.exe");
                    Check_And_Download_New_File("AppUpdater.exe", Dir_App);

                    listBox1.Items.Add("Check and Download : Investars.Bots.Utils.dll");
                    Check_And_Download_New_File("Investars.Bots.Utils.dll", Dir_Updates);

                    listBox1.Items.Add("Check and Download : SQL_Alerts_SubSystem.exe");
                    Check_And_Download_New_File("SQL_Alerts_SubSystem.exe", Dir_Updates);
                    if (ftp.Exists_Downloaded_New_Files(Dir_Updates))
                    {
                        MessageBox.Show(PopMessage);
                        listBox1.Items.Add("Detected New Files");
                        toolStripButton5.Enabled = true;
                    }
                    else
                        listBox1.Items.Add("No New Files");
                }
                else
                {
                    MessageBox.Show(PopMessage);
                    listBox1.Items.Add("Detected New Files");
                    toolStripButton5.Enabled = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("TRY AGAIN !!! ERROR: " + ex.Message);
            }//*/
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = Dir_App + "\\AppUpdater.exe";
            process.Start();
            Close();
        }

        private void timer_updates_Tick(object sender, EventArgs e)
        {
            timer_updates.Enabled = false;
            //toolStripButton4_Click(null, null);
        }

        private void toolStripComboBox1_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBox1.Items.Count == 0)
                    fill_persons();

                if (toolStripComboBox1.Items.Count > 0)
                    toolStripButton1.Enabled = true;
            }
            catch { }
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //dataGridView3.DataSource = dataSet_FtpFilesInfo.Tables["FtpFilesInfo"];
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            toolStripLabel6.Checked = !toolStripLabel6.Checked;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                sqlCmd = "alert_messages_APP @IO = 5";
                if (toolStripButton8.Checked)
                    sqlCmd += ", @Sended=1";
                else
                    sqlCmd += ", @Sended=0";
                if (toolStripLabel4.Checked)
                    sqlCmd += ",@UnitID=" + toolStripLabel5.Text;
                if (toolStripLabel6.Checked)
                    sqlCmd += ",@TaskID=" + toolStripLabel7.Text;

                sql.Execute(sqlCmd);
                if (sql.error)
                    MessageBox.Show(sql.errorMessage);
            }
            toolStripButton1_Click(null, null);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            toolStripButton8.Checked = !toolStripButton8.Checked;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            sqlCmd = richTextBox_SQL.Text;
            sql.Execute(sqlCmd);
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
            {
                richTextBox_SQL.Text = "";
                toolStripButton10.Enabled = false;
                toolStripButton3_Click(null, null);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            /*
            sqlCmd = "EXEC bot_stocks_EDITOR @IO = 6, @SourceStockID = " + toolStripTextBox3.Text;
            sql.Execute(sqlCmd);
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
            {
                toolStripTextBox3.Text = "NOT USED";
                toolStripButton9.Enabled = false;
            }*/
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            toolStripButton11.Checked = !toolStripButton11.Checked;
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            toolStripTextBox4.SelectAll();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

            Process process = new Process();
            switch (toolStripComboBox2.SelectedIndex)
            {
                case 0:
                    process.StartInfo.FileName = "iexplore.exe";
                    break;
                case 1:
                    process.StartInfo.FileName = "chrome.exe";
                    break;
            }
            process.StartInfo.Arguments = toolStripTextBox4.Text.Trim();
            process.Start();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            string Person = toolStripComboBox1.Text;
            if (dataGridView1.Rows.Count > 0)
            {
                sqlCmd = "alert_messages_APP @IO = 6";
                if (toolStripLabel4.Checked)
                    sqlCmd += ",@UnitID=" + toolStripLabel5.Text;
                if (toolStripLabel6.Checked)
                    sqlCmd += ",@TaskID=" + toolStripLabel7.Text;
                sqlCmd += ",@Person='" + Person + "'";
                sql.Execute(sqlCmd);
                if (sql.error)
                    MessageBox.Show(sql.errorMessage);
            }
        }

        private void richTextBox_SQL_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox_SQL.Text !="")
                richTextBox_SQL.BackColor = Color.Yellow;
            else
                richTextBox_SQL.BackColor = Color.White;
        }

        private void toolStripButton9_ButtonClick(object sender, EventArgs e)
        {
        }

        private void nOTGetPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            string Person = toolStripComboBox1.Text;
            if (dataGridView1.Rows.Count > 0)
            {
                sqlCmd = "alert_messages_APP @IO = 8";
                if (toolStripLabel4.Checked)
                    sqlCmd += ",@UnitID=" + toolStripLabel5.Text;
                if (toolStripLabel6.Checked)
                    sqlCmd += ",@TaskID=" + toolStripLabel7.Text;
                sqlCmd += ",@Person='" + Person + "'";
                sql.Execute(sqlCmd);
                if (sql.error)
                    MessageBox.Show(sql.errorMessage);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Person = toolStripComboBox1.Text;

        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            sqlCmd = "EXEC alert_messages_APP @IO = 7, @int1 = " + toolStripTextBox3.Text;
            sql.Execute(sqlCmd);
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
            {
                toolStripTextBox3.Text = "NOT GP=0";
                //toolStripButton9.Enabled = false;
                toolStripButton3_Click(null, null);
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            sqlCmd = "EXEC bot_stocks_EDITOR @IO = 6, @SourceStockID = " + toolStripTextBox3.Text;
            sql.Execute(sqlCmd);
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
            {
                toolStripTextBox3.Text = "NOT USED";
                //toolStripButton9.Enabled = false;
                toolStripButton3_Click(null, null);
            }
        }
    }
}
