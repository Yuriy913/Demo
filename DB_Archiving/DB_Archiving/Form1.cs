using DB_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Archiving
{
    public partial class Form1 : Form
    {
        #region Variables
            DB db_A, db_A_2;
            DB dbMSSQL;
            string connectionString_db_A;
            string connectionString_MSSQL;
            bool Opening_table = false;
            string AppDataFolder = "", DataDir="";
            DataTable table = new DataTable("Files");
            DataTable drives = new DataTable("Drives");
            DataView DV;
            string DB_Control = "";
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        public void Read_App_Config()
        {
            AppDataFolder = ConfigurationSettings.AppSettings["AppDataFolder"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read_App_Config();
            DataDir = AppDataFolder;
            DB_Control = DataDir + "DB_Archiving.mdb";
            connectionString_db_A = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ DataDir + "DB_Archiving.mdb;Persist Security Info=False";
            db_A = new DB(connectionString_db_A, 1);
            db_A_2 = new DB(connectionString_db_A, 1);

            table.Columns.Add("Size");
            //table.Columns.Add("CreationTime");
            //table.Columns.Add("ModifiedTime");
            table.Columns.Add("LastTime");
            table.Columns.Add("FileName");

            DV = new DataView(table);
            DV.Sort = "LastTime DESC";
            dataGridView1.DataSource = DV;

            SHOW_Paths();

            drives.Columns.Add("Letter");
            drives.Columns.Add("Percent");
            drives.Columns.Add("Free_Size");
            dataGridView2.DataSource = drives;

            Disks_Info();
        }

        private void SHOW_Paths()
        {
            db_A.Execute("SELECT * FROM Backup_Folders");
            if (db_A.error)
                MessageBox.Show(db_A.errorMessage);
            else
            {
                Opening_table = true;
                comboBox1.DataSource = db_A.dataSet.Tables[0];
                comboBox1.DisplayMember = "Path";
                comboBox1.ValueMember = "ID";
                Opening_table = false;
                SHOW_Files();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Opening_table) return;
            SHOW_Files();
        }

        private void SHOW_Files()
        {
            table.Rows.Clear();
            string Path = comboBox1.Text.Trim();
            if (!Directory.Exists(Path))
                MessageBox.Show("Directory not exists !!!");
            else
            {
                string[] files = Directory.GetFiles(Path, "*.*");
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        DataRow New_Row = table.NewRow();
                        New_Row["Size"]= Delimited_String_Value(fi.Length.ToString());
                        if (fi.CreationTime > fi.LastWriteTime)
                            New_Row["LastTime"] = Get_DateTime_As_YYYY_MM_DD_HH_MM(fi.CreationTime);
                        else
                            New_Row["LastTime"] = Get_DateTime_As_YYYY_MM_DD_HH_MM(fi.LastWriteTime);
                        New_Row["FileName"] = fi.ToString();
                        table.Rows.Add(New_Row);
                    }
                }
            }
        }

        private string Delimited_String_Value(string Int_Value)
        {
            string result = "";
            if (Int_Value.Length < 4)
                result = result;
            else
            {
                Int_Value = new String(Int_Value.Reverse().ToArray());
                while (Int_Value.Length > 3)
                {
                    result += Int_Value.Substring(0, 3) + ",";
                    Int_Value = Int_Value.Substring(3);
                    if (Int_Value.Length < 4)
                        result += Int_Value;
                }
                result = new string(result.Reverse().ToArray());
            }
            return result;
        }

        private string Get_DateTime_As_YYYY_MM_DD_HH_MM(DateTime dt)
        {
            string Year = dt.Year.ToString();

            string Month="";
            if (dt.Month < 10) Month = "0";
            Month += dt.Month.ToString();

            string Day = "";
            if (dt.Day < 10) Day = "0";
            Day += dt.Day.ToString();

            string Hour = "";
            if (dt.Hour < 10) Hour = "0";
            Hour += dt.Hour.ToString();

            string Minute = "";
            if (dt.Minute < 10) Minute = "0";
            Minute += dt.Minute.ToString();

            string result= Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute;
            return result;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool error = false;
            db_A.Execute("SELECT Files.FileSpec, Backup_Folders.Path FROM Backup_Folders INNER JOIN Files ON Backup_Folders.ID = Files.BackupFolderID WHERE Files.NotUse=0");
            if (db_A.error)
                MessageBox.Show(db_A.errorMessage);
            else
            {
                foreach (DataRow row in db_A.dataSet.Tables[0].Rows)
                {
                    string FileSpec = row["FileSpec"].ToString();
                    FileInfo fi = new FileInfo(FileSpec);
                    string Path = row["Path"].ToString();
                    string DayOfWeek = DateTime.Now.DayOfWeek.ToString();
                    string FileName = fi.Name.Replace(".", "_"+ Get_Number_Day_Of_Week()+".");
                    //string Destination_FileSpec = Path + DayOfWeek+"_"+fi.Name;
                    string Destination_FileSpec = Path + FileName;
                    try
                    {
                        File.Copy(FileSpec, Destination_FileSpec,true);
                    }
                    catch 
                    { 

                    }
                }
            }
            SHOW_Files();
        }

        private string Get_Number_Day_Of_Week()
        {
            string result = "0";
            string DayOfWeek = DateTime.Now.DayOfWeek.ToString();
            switch(DayOfWeek)
            {
                case "Monday":
                    result = "2";
                    break;
                case "Tuesday":
                    result = "3";
                    break;
                case "Wednesday":
                    result = "4";
                    break;
                case "Thursday":
                    result = "5";
                    break;
                case "Friday":
                    result = "6";
                    break;
                case "Saturday":
                    result = "7";
                    break;
                case "Sunday":
                    result = "1";
                    break;
            }
            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
            button2_Click_1(sender, e);
        }

        private void dELETEFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FileName = dataGridView1.SelectedRows[0].Cells["FileName"].Value.ToString();
            if (File.Exists(FileName))
                try
                {
                    File.Delete(FileName);
                    MessageBox.Show("File deleted : " + FileName);
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
                catch 
                {
                    MessageBox.Show("CAN'T delete file : " + FileName);
                }
        }

        private void Disks_Info()
        {
            drives.Rows.Clear();
            string[] _drives = Directory.GetLogicalDrives();
            foreach (string drive in _drives)
            {
                DriveInfo di = new DriveInfo(drive);
                if (di.DriveType == DriveType.Fixed)
                {
                    DataRow New_Row = drives.NewRow();
                    New_Row["Letter"] = di.Name;

                    long FreeSpace = di.TotalFreeSpace;
                    long TotalSize = di.TotalSize;

                    double d_FreeSpace = (double)FreeSpace;
                    double d_TotalSize = (double)TotalSize;

                    double part = Math.Round((d_FreeSpace / d_TotalSize), 2) * 100;

                    New_Row["Percent"] = part.ToString();
                    New_Row["Free_Size"] = Delimited_String_Value(di.TotalFreeSpace.ToString());
                    drives.Rows.Add(New_Row);
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = DB_Control;
            process.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = @"c:\";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr.ToString() == "OK")
            {
                if (!db_A.Execute("INSERT INTO Files (FileSpec,BackupFolderID) VALUES('" + openFileDialog1.FileName + "',1)"))
                    MessageBox.Show(db_A.errorMessage);
                else
                    MessageBox.Show("File Added !");
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!db_A.Execute("SELECT * FROM Files ORDER BY ID"))
                MessageBox.Show(db_A.errorMessage);
            else
                dataGridView3.DataSource = db_A.dataSet.Tables[0].DefaultView;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string ID = dataGridView3.SelectedRows[0].Cells["ID"].Value.ToString();
            if (!db_A.Execute("DELETE FROM Files WHERE ID="+ID))
                MessageBox.Show(db_A.errorMessage);
            else
                dataGridView3.Rows.Remove(dataGridView3.SelectedRows[0]);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!db_A.Execute("SELECT * FROM SQL_Backups ORDER BY ID"))
                MessageBox.Show(db_A.errorMessage);
            else
                dataGridView4.DataSource = db_A.dataSet.Tables[0].DefaultView;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string ID = dataGridView3.SelectedRows[0].Cells["ID"].Value.ToString();
            if (!db_A.Execute("UPDATE Files SET NotUSe=1 WHERE ID=" + ID))
                MessageBox.Show(db_A.errorMessage);
            else
                dataGridView3.SelectedRows[0].Cells["NotUSe"].Value = 1;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string ID = dataGridView3.SelectedRows[0].Cells["ID"].Value.ToString();
            if (!db_A.Execute("UPDATE Files SET NotUSe=0 WHERE ID=" + ID))
                MessageBox.Show(db_A.errorMessage);
            else
                dataGridView3.SelectedRows[0].Cells["NotUSe"].Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connectionString_MSSQL = "Data Source = localhost; Initial Catalog = Master; Integrated Security = True";
            dbMSSQL = new DB(connectionString_MSSQL);
            dbMSSQL.error = false;

            bool error = false;

            if (!db_A.Execute("SELECT ID,BackupFolderID FROM SQL_Backups WHERE NotUse=0 ORDER BY ID"))
                MessageBox.Show(db_A.errorMessage);
            else
            {
                foreach (DataRow row in db_A.dataSet.Tables[0].Rows)
                {
                    string ID             = row["ID"].ToString();
                    string BackupFolderID = row["BackupFolderID"].ToString();
                    string SQL = "SELECT Command FROM SQL_Backup_Commands WHERE SqlBackupID=" + ID + " AND NotUse=0 ORDER BY ID";

                    if (!db_A_2.Execute(SQL))
                        MessageBox.Show(db_A.errorMessage);
                    else
                    {
                        foreach (DataRow row_2 in db_A_2.dataSet.Tables[0].Rows)
                        {
                            string Command = row_2["Command"].ToString();
                            dbMSSQL.Execute(Command);
                            error = dbMSSQL.error;
                            if (error)
                                break;
                        }
                    }
                    if (error)
                        break;
                }
            }

            if (dbMSSQL.error)
                MessageBox.Show(dbMSSQL.errorMessage);
            else
                SHOW_Files();
        }
    }
}
