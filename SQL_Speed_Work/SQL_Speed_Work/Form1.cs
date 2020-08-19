using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//-------------------------
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.Utilities;
using System.Windows.Forms.DataVisualization.Charting.Data;
using System.Windows.Forms.DataVisualization.Charting.Borders3D;
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;
using System.Configuration;
using System.Xml;
using System.IO;
using DataSchema;
using System.Runtime.InteropServices;
using SQL_Speed_Work.Dialogs;
using System.Threading;
using System.Diagnostics;
using Sql_DataSet;
using System.Text.RegularExpressions;

namespace SQL_Speed_Work
{
    public partial class Form1 : Form
    {
        private List<Category> items = new List<Category>();

        #region Variables
            private int countHighlights, HighlightID, TransactionUpdated_WaitCount;
            private int TransactionID = 0, NewTransactionID, ServerID, DatabaseID, BackFromResultAfterSeconds = 3;
            string FileName_DumpValues_Schema, FileName_DumpValues;
            string UseDatabase;
            string connectionString, DefaultDatabase="master";
            Sql sql;
            Sql sql_Temp_Query; 
            Sql sql_Transaction_Tree, sql_DS_Result;
            bool TransactionNew = false, TransactionUpdate = false, NodeClick = false, RunAction = false;
            bool ParamNew = false, paramsNavigate = false, Preview = false, sqlCommand_empty = true;
            DataTable[] chart_DataTable; int chartIndex = -1;
            DataTable dumpValues;
            Sql[] chart_sql;
            private StreamWriter sr;
            private XmlTextWriter xr;
            DataView dv_Session_Values, dv_Transaction_Params, dv_Transaction_Exports, dv_Import_Values;
            DataView dv_Transaction_ColumnWidths, dv_Export_Import;
            int Auto_ReRun_Count = 0, DumpRowIndex = -1, TransactionRowIndex = -1; //Transaction_Text_Pos = 0, 
            string SQL_Project_Path = "", SQL_Project_Path_File = "", AppStartUpDir = "";
            DataSet101 dataSet1 = new DataSet101();
            AppDataSet dataSetApp = new AppDataSet();
            Table_TreeView ttv = new Table_TreeView();
            Util util = new Util();
            bool connected_1, connected_2 = false;
        #endregion

        #region WinAPI
            public const int WM_CLOSE = 0x0010;
            //---------------------------------

            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("User32.dll")]
            static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lparam);

        #endregion

            public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------
        private void get_servers()
        {
            int itemIndex = 0, PrimaryServerID = 0;
            tSCB_Srv.Items.Clear();

            if (dataSet1.Tables["Servers"].Rows.Count == 0)
            {
                DataRow row = dataSet1.Tables["Servers"].NewRow();
                row["Name"] = "(LOCAL)";
                row["connectionString"] = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=.";
                connectionString = (string)row["connectionString"];
                dataSet1.Tables["Servers"].Rows.Add(row);
            }

            dataGridView1.DataSource = dataSet1.Tables["Servers"];
            //bindingSource_Servers.DataSource = dataSet1.Tables["Servers"];
            //bindingSource_Servers.DataMember = "Servers";
            

            if (dataSet1.Tables["Servers"].Rows.Count > 0)
                foreach (DataRow row in dataSet1.Tables["Servers"].Rows)
                {
                    string itemString = row["ID"].ToString() + "." + row["Name"].ToString();
                    itemIndex = tSCB_Srv.Items.Add(itemString);
                    if ((bool)row["Last"] == true)
                    {
                        tSCB_Srv.SelectedIndex = itemIndex;
                        PrimaryServerID = (int)row["ID"];
                    }
                    //if (row["Primary"] != DBNull.Value)
                    //    if (row["Primary"].ToString() == "1")
                    //    {
                    //        tSCB_Srv.SelectedIndex = itemIndex;
                    //        PrimaryServerID = (int)row["ID"];
                    //    }

                }
            if (dataSet1.Tables["Servers"].Rows.Count == 0)
                tSCB_Srv.SelectedIndex = 0;

            if (tSCB_Srv.Items.Count > 1)
                if (!(tSCB_Srv.SelectedIndex != -1))
                    tSCB_Srv.SelectedIndex = 0;
            if (tSCB_Srv.Items.Count > 1)
                get_databases(PrimaryServerID);
        }
        private void get_databases(int ServerID)
        {
            tSCB_DB.Text="";
            tSCB_DB.Items.Clear();
            DataRow[] dataRows = dataSet1.Tables["Databases"].Select("ServerID="+ServerID.ToString());
            if (dataRows.Length > 0)
                foreach (DataRow row in dataRows)
                {
                    int itemIndex = tSCB_DB.Items.Add(row["ID"].ToString() + "." + (string)row["Name"]);
                    if ((bool)row["Last"] == true)
                    {
                        tSCB_DB.SelectedIndex = itemIndex;
                    }
                }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AppStartUpDir = Application.StartupPath;
            if (File.Exists(AppStartUpDir + "\\AppDataSet.xml"))
                dataSetApp.ReadXml(AppStartUpDir + "\\AppDataSet.xml");
        }
        private void Clear_Work_Area()
        {
            treeView1.Nodes.Clear();
            ttB_Description.Text = "";
            tB_Use_DB.Text = "";
            tB_LinkedServer.Text = "";
            rTB_sqlTransaction.Text = "";
            try{dGV_Transaction_Params.Rows.Clear();}catch{}
            try{dGV_Session_Values.Rows.Clear();}catch{}
            try{dGV_Export_Values.Rows.Clear();}catch{}
            try{dGV_ColumnWidths.Rows.Clear();}catch{}
            try{dGV_Import_Values.Rows.Clear();}catch{}
            dataSet1 = new DataSet101();
            tB_Param_Value.Text = "";
            items.Clear();
            tSCB_Srv.Text = ""; tSCB_Srv.Items.Clear();
            tSCB_DB.Text = ""; tSCB_DB.Items.Clear();
            tSCB_LinkedServers.Text = ""; tSCB_LinkedServers.Items.Clear();
        }
        private void SaveSQLProject()
        {
            if (tSB_TransactionUpdate.Enabled)
                toolStripButton2_Click(null, null);
            SaveDataSet();
        }
        private void SaveDataSet()
        {
            dataSet1.WriteXml(SQL_Project_Path + "DataSet.xml");
        }
        private void OpenSQLProject(string SQLProject_Path)
        {
            NodeClick = true;
            if (SQL_Project_Path != "")
            {
                SaveSQLProject();
                Clear_Work_Area();
            }
            SQL_Project_Path = SQLProject_Path;
            SQL_Project_Path_File = SQL_Project_Path + "DataSet.xml";
            if (File.Exists(SQL_Project_Path_File))
                dataSet1.ReadXml(SQL_Project_Path_File);

            get_servers();
            refreshToolStripMenuItem_Click(null, null); //Show Tree
            Add_Items_To_tSTB("tSTB_URL");

            try
            {
                foreach (DataRow row in dataSet1.Tables["Transactions"].Rows)
                {
                    row["SessionAutoRun"] = 0;
                    row["SessionAutoRun_AfterChangeValue"] = 0;
                }
            }
            catch { }
            NodeClick = false;
        }
        private void openSQLProjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string LastUsed_SQL_Project = "";
            if (dataSetApp.Tables["SQL_Projects"].Rows.Count > 0)
            {
                DataRow[] dataRows = dataSetApp.Tables["SQL_Projects"].Select("LastUsed=True");
                if (dataRows.Length > 0)
                    LastUsed_SQL_Project = (string)dataRows[0]["Path"];
                else
                    LastUsed_SQL_Project = (string)dataSetApp.Tables["SQL_Projects"].Rows[0]["Path"];
                folderBrowserDialog1.SelectedPath = LastUsed_SQL_Project;
            }
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
                if (folderBrowserDialog1.SelectedPath.Length == 4)
                    MessageBox.Show("Should choose not root folder !!!");
                else
                {
                    LastUsed_SQL_Project = folderBrowserDialog1.SelectedPath;

                    OpenSQLProject(LastUsed_SQL_Project + "\\");
                    bool detected = false; int rowIndex;
                    DataRow row_delected = null;
                    foreach (DataRow row in dataSetApp.Tables["SQL_Projects"].Rows)
                    {
                        if ((string)row["Path"] == LastUsed_SQL_Project)
                        {
                            detected = true;
                            row_delected = row;
                        }
                        rowIndex = dataSetApp.Tables["SQL_Projects"].Rows.IndexOf(row);
                        dataSetApp.Tables["SQL_Projects"].Rows[rowIndex].BeginEdit();
                        dataSetApp.Tables["SQL_Projects"].Rows[rowIndex]["LastUsed"] = false;
                        dataSetApp.Tables["SQL_Projects"].Rows[rowIndex].EndEdit();
                    }
                    if (!detected)
                    {
                        DataRow row = dataSetApp.Tables["SQL_Projects"].NewRow();
                        row["Path"] = LastUsed_SQL_Project;
                        row["lastUsed"] = true;
                        dataSetApp.Tables["SQL_Projects"].Rows.Add(row);
                    }
                    else
                    {
                        rowIndex = dataSetApp.Tables["SQL_Projects"].Rows.IndexOf(row_delected);
                        dataSetApp.Tables["SQL_Projects"].Rows[rowIndex].BeginEdit();
                        dataSetApp.Tables["SQL_Projects"].Rows[rowIndex]["LastUsed"] = true;
                        dataSetApp.Tables["SQL_Projects"].Rows[rowIndex].EndEdit();
                    }
                }
        }
        private void Transaction_Actions(int countParams, int IO, int ActionID, int UserID, int TransactionID = 0)
        {
            tSSL_Error.Text = "";
            //sql_Temp_Query.sqlParameters = null;
            int iParam = 0;
            sql_Temp_Query.Parameters = new SqlParameter[countParams];
            sql_Temp_Query.Parameters[iParam++] = new SqlParameter("IO", IO);
            sql_Temp_Query.Parameters[iParam++] = new SqlParameter("ActionID", ActionID);
            sql_Temp_Query.Parameters[iParam++] = new SqlParameter("UserID", UserID);
            if (TransactionID != 0)
                sql_Temp_Query.Parameters[iParam++] = new SqlParameter("TransactionID", TransactionID);

            int[] Execte_Scalar, Execte_NonQuery;
            switch (IO)
            {
                case 2:
                    Execte_Scalar = new int[] { 1 };
                    Execte_NonQuery = new int[] {3,4,5,6,7,9};
                    if (Array.IndexOf(Execte_Scalar, ActionID) != -1)
                        //sql_Temp_Query.sqlCommandExecute_return_Scalar("SupportDB.dbo.sql_speed_work", true);
                        sql_Temp_Query.Execute("SupportDB.dbo.sql_speed_work");
                    else
                        if (Array.IndexOf(Execte_NonQuery, ActionID) != -1)
                        //sql_Temp_Query.sqlCommandExecute_return_NonQuery("SupportDB.dbo.sql_speed_work", true);
                        sql_Temp_Query.Execute("SupportDB.dbo.sql_speed_work");
                    else
                        //sql_Temp_Query.sqlCommandExecute_return_DataSet("SupportDB.dbo.sql_speed_work", true);
                        sql_Temp_Query.Execute("SupportDB.dbo.sql_speed_work");
                    break;
                default:
                    //sql_Temp_Query.sqlCommandExecute_return_DataSet("SupportDB.dbo.sql_speed_work", true);
                    sql_Temp_Query.Execute("SupportDB.dbo.sql_speed_work");
                    break;
            }
            if (!sql_Temp_Query.error)
            {
                if ((IO == 2) && (ActionID == 1))
                    NewTransactionID = (int)sql_Temp_Query.dataSet.Tables[0].Rows[0][0];
            }
            else {tSSL_Error.Text = "Error";}
        }
        private bool Transaction_min_fields(){
            bool result = false;
            if (ttB_Description.Text == "")
                MessageBox.Show("Need: Description");
            else result = true; 
            return result;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.SaveFile(SQL_Project_Path_File, RichTextBoxStreamType.PlainText);
            tSB_TransactionUpdate.Enabled = false;
        }
        private void treenode_update()
        {
            try
            {
                TreeNode node = treeView1.SelectedNode;
                node.Text = ttB_Description.Text;
                Category cat = (Category)node.Tag;
                cat.NodeText = node.Text;
                node.Tag = cat;
            }
            catch { }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void showTransactionID(int NewTransactionID)
        {
            TransactionID = NewTransactionID;
            tSSL_TransactionID.Text = TransactionID.ToString();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void sQLTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //http://www.daniweb.com/software-development/csharp/threads/118395
            treeView1.Nodes.Clear();
            items.Clear();

            dataSet1.Tables["Transactions"].DefaultView.Sort = "ParentID ASC, SortOrder ASC, ID ASC";
            DataView dv = new DataView(dataSet1.Tables["Transactions"]);
            dv.Sort = "ParentID ASC, SortOrder ASC, ID ASC";
            //dv.ApplyDefaultSort = false;
            //dv.Table.DefaultView.Sort = "ParentID ASC, SortOrder ASC, ID ASC";
            //this.dataGrid1.DataSource = dv;
            foreach (DataRow dr in dv.Table.Rows)
            {
                int ID = (int)dr["ID"];
                int ParentID;
                if (dr["ParentID"] == DBNull.Value)
                     ParentID = 0;
                else ParentID = (int)dr["ParentID"];
                string Description = (string)dr["Description"];
                items.Add(new Category(ID, ParentID, Description));
            }
            buildtree();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void buildtree()        
        {            
            treeView1.Nodes.Clear();            // Clear any existing items            
            treeView1.BeginUpdate();            // prevent overhead and flicker            
            LoadBaseNodes();                    // load all the lowest tree nodes            
            treeView1.EndUpdate();              // re-enable the tree            
            treeView1.Refresh();                // refresh the treeview display        
        }
        private void LoadBaseNodes()        
        {            
            int baseParent = 0;                 // Find the lowest root category parent value            
            TreeNode node;            
            foreach (Category cat in items)           
            {                
                if (cat.ParentID < baseParent)                    
                    baseParent = cat.ParentID;            
            }            
            foreach (Category cat in items)     // iterate through the categories            
                {                
                if (cat.ParentID == baseParent) // found a matching root item                
                {                    
                    node = treeView1.Nodes.Add(cat.NodeText); // add it to the tree
                    node.Tag = cat;             // send the category into the tag for future processing              
                    getChildren(node);          // load all the children of this node    
                }            
            }        
        }
        private void getChildren(TreeNode node)        
        {           
            TreeNode Node = null;            
            Category nodeCat = (Category)node.Tag;  // get the category for this node         
            foreach (Category cat in items)         // locate all children of this category      
            {                
                if (cat.ParentID == nodeCat.ID)     // found a child    
                {                    
                    Node = node.Nodes.Add(cat.NodeText);    // add the child  
                    Node.Tag = cat;                         // set its tag to its category  
                    getChildren(Node);                      // find this child's children    
                }            
            }        
        }
        class Category 
        { public int ID; 
            public int ParentID; 
            public string NodeText; 
            public Category(int ID, int ParentID, string NodeText) 
            { this.ID = ID; this.ParentID = ParentID; this.NodeText = NodeText; 
            } 
            public override string ToString() { return this.NodeText; } 
        }
        private void button2_Click_1(object sender)
        {
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            sql_Temp_Query = new Sql(connectionString, true);
            sql_Transaction_Tree = new Sql(connectionString, true);
            //dGV_Import_Values.DataSource = dataSet1.Import_Values.DefaultView;
        }
        private void Add_Items_To_tSTB(string Name){
            switch (Name)
            {
                case "tSTB_URL":
                    foreach(DataRow row in dataSet1.Tables["Browser_URLs"].Rows)
                        tSTB_URL.Items.Add(row["URL"]);
                break;
            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TransactionNew) return;
            if (tSB_TransactionUpdate.Enabled)
                toolStripButton2_Click(null, null);

            NodeClick = true;
            button6.Text = "Value:";
            button6.BackColor = Color.SkyBlue;
            //groupBox13.Enabled = false;
            newToolStripMenuItem.Enabled = true;
            TreeNode node = e.Node;
            Category cat = (Category)node.Tag;
            TransactionID = cat.ID;
            showTransactionID(TransactionID);
            //Transaction_Text_Pos = 0; 
            Pos_X.Text = "0"; Pos_Y.Text = "0";

            DataView dv = new DataView(dataSet1.Tables["Transactions"]);
            dv.Sort = "ID ASC";
            TransactionRowIndex = dv.Find(TransactionID);
            if (TransactionRowIndex == -1)
                MessageBox.Show("Not Found Transaction");
            else
            {
                try
                {
                    SQL_Project_Path_File = SQL_Project_Path + TransactionID.ToString() + ".sql";

                    try
                    {
                        rTB_sqlTransaction.LoadFile(SQL_Project_Path_File);
                    }catch//(Exception ex)
                    {
                            rTB_sqlTransaction.LoadFile(SQL_Project_Path_File, RichTextBoxStreamType.PlainText);
                    }

                    dumpValues = new DataTable();
                    FileName_DumpValues_Schema = SQL_Project_Path + TransactionID.ToString() + "dvs.xml";
                    FileName_DumpValues = SQL_Project_Path + TransactionID.ToString() + "dv.xml";
                    if ((File.Exists(FileName_DumpValues_Schema)) && (File.Exists(FileName_DumpValues)))
                    {
                        dumpValues.ReadXmlSchema(FileName_DumpValues_Schema);
                        dumpValues.ReadXml(FileName_DumpValues);
                    }
                    dGV_Dump_Values.DataSource = dumpValues;

                    DataRow row = dataSet1.Tables["Transactions"].Rows[TransactionRowIndex];

                    ttB_Description.Text = (string)row["Description"];
                    cB_DataSet_Text.Checked = false;

                    //Keep step adding for ZoomFactor
                    rTB_sqlTransaction.ZoomFactor = (float)1;
                    string zoomFactor_str="1.5";
                    if (row["ZoomFactor"] != DBNull.Value)
                        zoomFactor_str = row["ZoomFactor"].ToString();
                    toolStripSplitButton3.Text = zoomFactor_str;
                    rTB_sqlTransaction.ZoomFactor = float.Parse(zoomFactor_str);

                    cB_ChartType.SelectedIndex = 3;
                    if (row["Chart"] == DBNull.Value)
                        cB_Chart.Checked = false;
                    else
                    {
                        cB_Chart.Checked = (bool)row["Chart"];
                        if (cB_Chart.Checked)
                            if (row["ChartType"] != DBNull.Value)
                                cB_ChartType.SelectedIndex = (int)row["ChartType"];
                    }

                    if (row["DelphiChart"] == DBNull.Value)
                    {
                        cB_DelphiChart.Checked = false;
                        cB_DelphiChartType.SelectedIndex = 0;
                    }
                    else
                    {
                        cB_DelphiChart.Checked = (bool)row["DelphiChart"];
                        if (cB_DelphiChart.Checked)
                            if (row["DelphiChartType"] != DBNull.Value)
                                cB_DelphiChartType.SelectedIndex = (int)row["DelphiChartType"];
                    }

                    cB_XML_Column.Checked = (bool)row["XmlColumn"];
                    cB_Tree_Expand.Checked = (bool)row["TreeExpand"];
                    cB_AutoRun.Checked = (bool)row["AutoRun"];
                    cB_Trees.Checked = (bool)row["Trees"];
                    cB_SessionAutoRun.Checked = (bool)row["SessionAutoRun"];
                    cB_SessionAutoRun_AfterChangeValue.Checked = (bool)row["SessionAutoRun_AfterChangeValue"];
                    cB_AutoRun_AfterChangeValue.Checked = (bool)row["AutoRun_AfterChangeValue"];
                    cB_NotSwitch_ToDataSetResult.Checked = (bool)row["NotSwitch_ToDataSetResult"];
                    cB_BackFromResult.Checked = (bool)row["BackFromResult"];

                    tSB_UseLastValues.Checked = (bool)row["UseLastValues"];
                    tSB_UseImportValues.Checked = (bool)row["UseImportValues"];
                    tSB_UseDumpValues.Checked = (bool)row["UseDumpValues"];
                    if ((!tSB_UseDumpValues.Checked) && (!tSB_UseImportValues.Checked) && (!tSB_UseLastValues.Checked))
                        tSB_UseLastValues.Checked = true;

                    cB_Output_Schema.Checked = (bool)row["Output"];

                    if (row["Output_Schema"] != DBNull.Value)
                        tB_Output_Schema.Text = (string)row["Output_Schema"];
                    else
                        tB_Output_Schema.Text = "";

                    cB_Output_ByVertical.Checked = (bool)row["Output_ByVertical"];
                    
                    if (row["DataSetOutNumber"] != DBNull.Value)
                        nUD_DataSetOutNumber.Value = (decimal)row["DataSetOutNumber"];
                    else nUD_DataSetOutNumber.Value = 1;

                    if (row["BackFromResultAfterSeconds"] != DBNull.Value)
                        nUD_BackFromResultAfterSeconds.Value = (int)row["BackFromResultAfterSeconds"];
                    else nUD_BackFromResultAfterSeconds.Value = 3;
                    BackFromResultAfterSeconds = (int)nUD_BackFromResultAfterSeconds.Value;

                    tB_LinkedServer.Text = ""; cB_Use_LinkedServer.Checked = false;
                    if (row["LinkedServer"] != DBNull.Value)
                        tB_LinkedServer.Text = (string)row["LinkedServer"];
                    if (tB_LinkedServer.Text != "") cB_Use_LinkedServer.Checked = true;

                    tB_Use_DB.Text = ""; cB_Use_DB.Checked = false;
                    if (row["UseDatabase"] != DBNull.Value)
                        tB_Use_DB.Text = (string)row["UseDatabase"];
                    if (tB_Use_DB.Text != "") cB_Use_DB.Checked = true;

                    int AfterRunToTransID = (int)row["AfterRunToTransID"];
                    switch (AfterRunToTransID)
                    {
                        case 0:
                            cB_AfterRun.SelectedIndex = 0;
                            break;
                        case -1:
                            cB_AfterRun.SelectedIndex = 1;
                            break;
                        default:
                            cB_AfterRun.SelectedIndex = 2;
                            tB_AfterRunTransID.Text = AfterRunToTransID.ToString();
                            break;
                    }

                    DumpRowIndex = -1;
                    DumpRowIndex = (int)row["DumpRowIndex"];

                    cB_Param_Value.Checked = false;
                    tB_Param_Value.Text = "";
                    tB_Param_Name.Text = "";
                    tB_Param_Import.Text = "";

                    if (tSB_UseLastValues.Checked)
                        tabControl11.SelectedTab = tabPage25;
                    if (tSB_UseImportValues.Checked)
                        tabControl11.SelectedTab = tabPage26;
                    if (tSB_UseDumpValues.Checked)
                    {
                        tabControl11.SelectedTab = tabPage27;
                        if (DumpRowIndex != -1)
                            dGV_Dump_Values.CurrentCell = dGV_Dump_Values.Rows[DumpRowIndex].Cells[0];
                    }

                    //STOP
                    Show_transaction_params(TransactionID);
                    Show_transaction_exports(TransactionID);
                    Show_transaction_ColumnWidhts(TransactionID);
                    Show_transaction_Session_Values(TransactionID);
                    Show_transaction_Import_Values(TransactionID);
                    tB_Param_Value.Items.Clear();
                    Show_transaction_Values(TransactionID);

                    tabControl10.SelectedIndex = 0;
                    tabControl9.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if ((cB_AutoRun.Checked) || (cB_SessionAutoRun.Checked))
                if (!disableAutoRunToolStripMenuItem.Checked)
                    toolStripButton3_Click(null, null);

            NodeClick = false;
            timer_AfterSelect.Enabled = true;
        }


        private void Show_transaction_Values(int TransactionID)
        {
            DataRow[] rows = dataSet1.Tables["Transaction_Values"].Select("TransactionID=" + TransactionID.ToString());
            if (rows.Length > 0)
                foreach (DataRow row in rows)
                    tB_Param_Value.Items.Add(row["Value"].ToString());
        }

        private void set_focus_on_first_param()
        {
            tB_Param_Value.Focus();
            tB_Param_Value.SelectAll();
        }

        private void Show_transaction_Import_Values(int TransactionID)
        {
            dv_Import_Values = new DataView();
            dv_Import_Values = dataSet1.Tables["Import_Values"].DefaultView;
            dv_Import_Values.RowFilter = "TransactionID=" + TransactionID.ToString();
            dGV_Import_Values.DataSource = dv_Import_Values;
        }
        private void Show_transaction_Session_Values(int TransactionID)
        {
            dv_Session_Values = new DataView();
            dv_Session_Values = dataSet1.Tables["Last_Param_Values"].DefaultView;
            dv_Session_Values.RowFilter = "TransactionID=" + TransactionID.ToString();
            dGV_Session_Values.DataSource = dv_Session_Values;
        }

        private void Show_transaction_params(int TransactionID)
        {
            dv_Transaction_Params = new DataView();
            dv_Transaction_Params = dataSet1.Tables["Transaction_Params"].DefaultView;
            dv_Transaction_Params.RowFilter = "TransactionID=" + TransactionID.ToString();
            dv_Transaction_Params.Sort = "SortIndex";
            dGV_Transaction_Params.DataSource = dv_Transaction_Params;
            dGV_Transaction_Params.Columns["TransactionID"].Visible = false;
            if (dGV_Transaction_Params.RowCount > 0)
            {
                tabControl3.SelectedTab = tabPage9;
                dGV_Transaction_Params.ClearSelection();
                dGV_Transaction_Params.Rows[0].Selected = true;
            }
            else
                tabControl3.SelectedTab = tabPage8;
        }
        private void Show_transaction_exports(int TransactionID)
        {
            dv_Transaction_Exports = new DataView();
            dv_Transaction_Exports = dataSet1.Tables["Export_Values"].DefaultView;
            dv_Transaction_Exports.RowFilter = "TransactionID=" + TransactionID.ToString();
            dGV_Export_Values.DataSource = dv_Transaction_Exports;
        }
        private void Show_transaction_ColumnWidhts(int TransactionID)
        {
            dv_Transaction_ColumnWidths = new DataView();
            dv_Transaction_ColumnWidths = dataSet1.Tables["ColumnWidths"].DefaultView;
            dv_Transaction_ColumnWidths.RowFilter = "TransactionID=" + TransactionID.ToString();
            dGV_ColumnWidths.DataSource = dv_Transaction_ColumnWidths;
        }

        private string prepare_sqlCommand(string sqlCommand)
        {
            string result;
            string param_name = "";
            string param_value = "";
            string param_type = "";
            bool param_important = false;
            string param_import = "";
            string param_DumpCol = "";

            int parm_index = -1;
            DataRow[] SessParamValues = dataSet1.Tables["Last_Param_Values"].Select("TransactionID=" + TransactionID.ToString());
            if (dataSet1.Tables["Transaction_Params"].Rows.Count > 0)
            {
                foreach (DataGridViewRow Param_row in dGV_Transaction_Params.Rows)
                {
                    parm_index++;
                    param_name   = Param_row.Cells[1].Value.ToString();
                    param_import = Param_row.Cells[2].Value.ToString();
                    param_type   = Param_row.Cells[3].Value.ToString();
                    if (Param_row.Cells[4].Value != null)
                        param_important = (bool)Param_row.Cells[4].Value;
                    else param_important = false;
                    param_value = Param_row.Cells[5].Value.ToString();

                    if (Param_row.Cells[9].Value != null)
                        param_DumpCol = Param_row.Cells[9].Value.ToString();

                    if (tSB_UseLastValues.Checked)
                    {
                        if (SessParamValues.Length > 0)
                            foreach (DataRow rowSPV in SessParamValues)
                                if (rowSPV[0].ToString() == param_name)
                                    param_value = rowSPV[1].ToString();
                    }

                    if ((tSB_UseImportValues.Checked) && (param_import != ""))
                    {
                        foreach (DataGridViewRow row in dGV_Import_Values.Rows)
                            if ((string)row.Cells["paramName"].Value == param_import)
                                param_value = row.Cells["Value"].Value.ToString();
                    }

                    if ((tSB_UseDumpValues.Checked)&&(param_DumpCol != ""))
                    {
                        DataGridViewRow dgvRow = dGV_Dump_Values.CurrentRow;
                        if (param_DumpCol.IndexOf("col")==-1)
                            param_value = (string)dgvRow.Cells["col"+param_DumpCol].Value;
                        else
                            param_value = (string)dgvRow.Cells[param_DumpCol].Value;
                    }

                    //if ((param_value == "") && (tB_Param_Value.Text != ""))
                    //    param_value = tB_Param_Value.Text.Trim();

                    if ((param_important) && (param_value.Trim() == ""))
                    {
                        rTB_SQL.Text += "----------------------------------------------------\r\n";
                        rTB_SQL.Text += "Need: Important Parameter\r\n";
                        MessageBox.Show("Need: Important Parameter!");
                        sqlCommand = "";
                        break;
                    }

                    if (param_value == "") param_value = "NULL";
                    switch (param_type)
                    {
                        case "1":
                                if ( param_value.IndexOf(',') > 0 )
                                    param_value = param_value.Replace(",", "','");

                                if (param_value != "NULL")
                                    sqlCommand = sqlCommand.Replace("{" + param_name + "}", "'" + param_value + "'");
                                else
                                    sqlCommand = sqlCommand.Replace("{" + param_name + "}", param_value);

                            break;
                        case "2":
                            if (param_value == "True")
                                sqlCommand = sqlCommand.Replace("{" + param_name + "}", "1");
                            else
                                sqlCommand = sqlCommand.Replace("{" + param_name+"}", "0");
                            break;
                        default:
                            sqlCommand = sqlCommand.Replace("{" + param_name + "}", param_value);
                                break;
                    }
                }
            }
            if ((cB_Use_DB.Checked) && (sqlCommand !=""))
                sqlCommand = "USE " + tB_Use_DB.Text + "\r\n" + sqlCommand;

            if ((
                ((Use_LinkedServer.Checked)&&(cB_Use_LinkedServer.Checked))
                ||
                ((cB_Use_LinkedServer.Checked)&&(tB_LinkedServer.Text !=""))
               ) && (sqlCommand !=""))
            {
                sqlCommand = sqlCommand.Replace("'","''");
                sqlCommand = "EXEC ('" + "\r\n" + sqlCommand;
                if (tB_LinkedServer.Text != "")
                    sqlCommand += "\r\n" + "') AT " + tB_LinkedServer.Text;
                else sqlCommand += "\r\n" + "') AT " + LinkedServer_Name.Text;
            }

            if (Preview)
                rTB_SQL_Preview.Text = sqlCommand;
            else
            {
                rTB_SQL.Text += "----------------------------------------------------\r\n";
                rTB_SQL.Text += sqlCommand + "\r\n";
            }
            result = sqlCommand;
            return result;
        }

        private void Transaction_To_Chart()
        {
            string sqlCommand = prepare_sqlCommand(rTB_sqlTransaction.Text);
            if (sqlCommand == "") return;
            if (Preview) return;

            #region Chart c#
            if (cB_Chart.Checked)
            {
                int chartNumber = cB_ChartType.SelectedIndex;
                string chartType = cB_ChartType.Text;
                chartType = chartType.Substring(chartType.IndexOf('.') + 1);

                SeriesChartType ChartType = 0;
                switch (chartType)
                {
                    case "Area": ChartType = SeriesChartType.Area; break;
                    case "Bar": ChartType = SeriesChartType.Bar; break;
                    case "BoxPlot": ChartType = SeriesChartType.BoxPlot; break;
                    case "Bubble": ChartType = SeriesChartType.Bubble; break;
                    case "Candlestick": ChartType = SeriesChartType.Candlestick; break;
                    case "Column": ChartType = SeriesChartType.Column; break;
                    case "Doughnut": ChartType = SeriesChartType.Doughnut; break;
                    case "ErrorBar": ChartType = SeriesChartType.ErrorBar; break;
                    case "FastLine": ChartType = SeriesChartType.FastLine; break;
                    case "FastPoint": ChartType = SeriesChartType.FastPoint; break;
                    case "Funnel": ChartType = SeriesChartType.Funnel; break;
                    case "Kagi": ChartType = SeriesChartType.Kagi; break;
                    case "Line": ChartType = SeriesChartType.Line; break;
                    case "Pie": ChartType = SeriesChartType.Pie; break;
                    case "Point": ChartType = SeriesChartType.Point; break;
                    case "PointAndFigure": ChartType = SeriesChartType.PointAndFigure; break;
                    case "Polar": ChartType = SeriesChartType.Polar; break;
                    case "Pyramid": ChartType = SeriesChartType.Pyramid; break;
                    case "Radar": ChartType = SeriesChartType.Radar; break;
                    case "Range": ChartType = SeriesChartType.Range; break;
                    case "RangeBar": ChartType = SeriesChartType.RangeBar; break;
                    case "RangeColumn": ChartType = SeriesChartType.RangeColumn; break;
                    case "Renko": ChartType = SeriesChartType.Renko; break;
                    case "Spline": ChartType = SeriesChartType.Spline; break;
                    case "SplineArea": ChartType = SeriesChartType.SplineArea; break;
                    case "SplineRange": ChartType = SeriesChartType.SplineRange; break;
                    case "StackedArea": ChartType = SeriesChartType.StackedArea; break;
                    case "StackedArea100": ChartType = SeriesChartType.StackedArea100; break;
                    case "StackedBar": ChartType = SeriesChartType.StackedBar; break;
                    case "StackedBar100": ChartType = SeriesChartType.StackedBar100; break;
                    case "StackedColumn": ChartType = SeriesChartType.StackedColumn; break;
                    case "StackedColumn100": ChartType = SeriesChartType.StackedColumn100; break;
                    case "StepLine": ChartType = SeriesChartType.StepLine; break;
                    case "Stock": ChartType = SeriesChartType.Stock; break;
                    case "ThreeLineBreak": ChartType = SeriesChartType.ThreeLineBreak; break;
                    default:
                        ChartType = SeriesChartType.Point; break;
                }
                //label5.Text = "C# ChartType:" + ((int)ChartType).ToString();
                //if (((int)ChartType) != chartNumber)
                //    label5.BackColor = Color.Fuchsia;

                if (!addToolStripMenuItem4.Checked) clearToolStripMenuItem1_Click(null, null);
                chartIndex++;

                chart_DataTable = new DataTable[chartIndex + 1];
                chart_sql = new Sql[chartIndex + 1];

                chart_sql[chartIndex] = new Sql(connectionString, true);
                try
                {
                    //chart_sql[chartIndex].sqlCommandExecute_return_DataSet(sqlCommand);
                    chart_sql[chartIndex].Execute(sqlCommand);
                }
                catch
                {
                    MessageBox.Show("ERROR of Run");
                    return;
                }
                chart_DataTable[chartIndex] = chart_sql[chartIndex].dataSet.Tables[0];

                chart1.DataSource = chart_DataTable[chartIndex];
                if (chartIndex == 0)
                    chart1.ChartAreas.Add("ChartArea" + chartIndex.ToString());
                chart1.Series.Add("Series" + chartIndex.ToString());
                chart1.Series[chartIndex].ChartType = ChartType; 
                chart1.Series[chartIndex].XValueType = ChartValueType.Date;
                chart1.Series[chartIndex].Points.DataBindXY(chart_DataTable[chartIndex].DefaultView, "X",
                    chart_DataTable[chartIndex].DefaultView, "Y");
                tabControl2.SelectedTab = tP_Charts;
                tabControl6.SelectedTab = tP_Chart_C;
            }
            #endregion
            #region Chart Delphi
            if (cB_DelphiChart.Checked)
            {
                /*
                if (addToolStripMenuItem4.Checked)
                    axDelphi_DBChart1.AddChart = true;
                else
                    axDelphi_DBChart1.AddChart = false;
                axDelphi_DBChart1.connectionString = connectionString;
                axDelphi_DBChart1.sqlCmd = sqlCommand;
                axDelphi_DBChart1.chartType = (sbyte)cB_DelphiChartType.SelectedIndex;
                axDelphi_DBChart1.Chart_Add();
                tabControl2.SelectedTab = tP_Charts;
                tabControl6.SelectedTab = tP_Chart_Delphi;
                */
            }
            #endregion
        }

        private void Transaction_To_DataSet()
        {
            sqlCommand_empty = false;
            string sqlCommand = prepare_sqlCommand(rTB_sqlTransaction.Text);
            if (sqlCommand == "") { sqlCommand_empty = true;  return; }
            if (Preview) return;

            int countRowsShow, countColumnsShow;
            try { countRowsShow = int.Parse(this.Rows_Count.Text); }
            catch { countRowsShow = 3; }
            try { countColumnsShow = int.Parse(toolStripTextBox2.Text); }
            catch { countColumnsShow = 2; }
            sql_DS_Result = new Sql(connectionString);//, true
                                                      //        MessageBox.Show(sqlCommand);
            try
            {
                //sql_DS_Result.sqlCommandExecute_return_DataSet(sqlCommand);
                sql_DS_Result.Execute(sqlCommand);
            }
            catch
            {
                MessageBox.Show("ERROR of Run");
                return;
            }
            int tableIndex, countTables, Rows_Count, countRows, Columns_Count;
            if (!sql_DS_Result.error)
            {
                int DataSetOutNumber=0;
                if (cB_Trees.Checked)
                    tB_Trees.Controls.Clear();
                else
                {
                    DataSetOutNumber = int.Parse(nUD_DataSetOutNumber.Value.ToString());
                    switch (DataSetOutNumber)
                    {
                        case 1: tabPage_DataSet1.Controls.Clear(); break;
                        case 2: tabPage_DataSet2.Controls.Clear(); break;
                        case 3: tabPage_DataSet3.Controls.Clear(); break;
                    }
                    if (cB_DataSet_Text.Checked)
                        rTB_DataSet_Text.Text = "";
                    if (cB_XML_Column.Checked)
                    {
                        rTB_XML_Column.Text = "";
                        rTB_XML_Column_Adjusted.Text = "";
                        rTB_XML_Column.ZoomFactor = (float)1;
                        rTB_XML_Column.ZoomFactor = (float)1.5;
                    }
                }
                countTables = sql_DS_Result.dataSet.Tables.Count;

                if (countTables > 0)
                {
                    tableIndex = 0;
                    TreeView[] treeView = null;
                    DataGridView[] dataGridView = null;
                    Splitter[] spliter = new Splitter[countTables];
                    ToolTip[] toolTip = null;

                    if (cB_Trees.Checked)
                        treeView = new TreeView[countTables];
                    else
                    {
                        dataGridView = new DataGridView[countTables];
                        toolTip = new ToolTip[countTables];
                    }
                    
                    char[] delim = new char[]{','};
                    string[] TableOrientation = null;
                    bool ByVertical = false;
                    if (cB_Output_Schema.Checked)
                        TableOrientation = tB_Output_Schema.Text.Split(delim);

                    foreach (DataTable table in sql_DS_Result.dataSet.Tables)
                    {
                        if (cB_Trees.Checked)
                        {
                            treeView[tableIndex] = new TreeView();
                            treeView[tableIndex].Dock = DockStyle.Left;
                            try{treeView[tableIndex].Width = (int)(tB_Trees.Width / countTables);}catch { }
                            ttv.Load_Table_To_TreeView(table, treeView[tableIndex]);
                            if (cB_Tree_Expand.Checked)
                                treeView[tableIndex].ExpandAll();
                            spliter[tableIndex] = new Splitter();
                            spliter[tableIndex].Dock = DockStyle.Left;
                            spliter[tableIndex].BackColor = Color.SkyBlue;
                        }
                        else
                        {
                            Rows_Count = table.Rows.Count;
                            if (allToolStripMenuItem.Checked)
                                countRowsShow = Rows_Count;
                            Columns_Count = table.Columns.Count;

                            dataGridView[tableIndex] = new DataGridView();
                            dataGridView[tableIndex].DataSource = table;

                            ByVertical = false;
                            if ((cB_Output_Schema.Checked)
                                && (TableOrientation.Length > 0) 
                                && (tableIndex < TableOrientation.Length)
                                )
                            {
                                if (TableOrientation[tableIndex] == "L")
                                    ByVertical = true;
                            }
                            else
                                if (cB_Output_ByVertical.Checked)
                                    ByVertical = true;

                            if (ByVertical)
                            {
                                dataGridView[tableIndex].Width = 40;
                                int multColumn = 100;
                                if (Columns_Count <= countColumnsShow)
                                    dataGridView[tableIndex].Width += Columns_Count * multColumn;
                                else
                                    dataGridView[tableIndex].Width += countColumnsShow * multColumn;
                            }
                            else
                            {
                                dataGridView[tableIndex].Height = 25;
                                int multRow = 22;
                                if (Rows_Count <= countRowsShow)
                                    dataGridView[tableIndex].Height += Rows_Count * multRow;
                                else dataGridView[tableIndex].Height += countRowsShow * multRow;
                                if (Columns_Count > 10)
                                    dataGridView[tableIndex].Height += 15;
                            }

                            if (ByVertical)
                                dataGridView[tableIndex].Dock = DockStyle.Left;
                            else 
                                dataGridView[tableIndex].Dock = DockStyle.Top;
                            spliter[tableIndex] = new Splitter();
                            toolTip[tableIndex] = new ToolTip();
                            toolTip[tableIndex].SetToolTip(spliter[tableIndex], "Rows:" + table.Rows.Count.ToString() + "\r\nColumns:" + table.Columns.Count.ToString());

                            if (ByVertical)
                                spliter[tableIndex].Dock = DockStyle.Left;
                            else spliter[tableIndex].Dock = DockStyle.Top;

                            spliter[tableIndex].BackColor = Color.SkyBlue;

                            if ((cB_ListOfFields.Checked) || (cB_FirstRow_Field_Value.Checked))
                            {
                                if (tableIndex == 0)
                                {
                                    string rowStr = "";
                                    DataRow row = table.Rows[0];
                                    for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                                    {
                                        rowStr += "[" + table.Columns[colIndex].Caption + "]";
                                        if (!cB_ListOfFields.Checked)
                                            rowStr += " = ";

                                        if (!cB_ListOfFields.Checked)
                                        {
                                            Type type = table.Columns[colIndex].DataType;
                                            if (row[colIndex] == DBNull.Value)
                                                rowStr += "NULL";
                                            else
                                                if ((type == typeof(string))
                                                    || (type == typeof(DateTime)))
                                                    rowStr += "'" + row[colIndex].ToString() + "'";
                                                else
                                                    rowStr += row[colIndex].ToString();
                                        }
                                        if ((colIndex + 1) < table.Columns.Count)
                                            rowStr += ", ";
                                        if (!cB_ListOfFields.Checked)
                                            rowStr += "\r\n";
                                    }
                                    rTB_DataSet_Text.Text += rowStr + "\r\n";
                                }
                            }

                            if (cB_DataSet_Text.Checked)
                            {
                                if (tableIndex > 0)
                                {
                                    String str = new String('#', 250);
                                    rTB_DataSet_Text.Text += str + "\r\n";
                                }
                                string rowStr = "";
                                for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                                {
                                    rowStr += "[" + table.Columns[colIndex].Caption + "]";
                                    if (colIndex < table.Columns.Count - 1)
                                        rowStr += "\t";
                                }
                                rTB_DataSet_Text.Text += rowStr + "\r\n";

                                foreach (DataRow row in table.Rows)
                                {
                                    rowStr = "";
                                    for (int colIndex = 0; colIndex < row.ItemArray.Length; colIndex++)
                                    {
                                        rowStr += row.ItemArray[colIndex].ToString();
                                        if (colIndex < row.ItemArray.Length - 1)
                                            rowStr += "\t";
                                    }
                                    rTB_DataSet_Text.Text += rowStr + "\r\n";
                                }
                            }

                            if (cB_XML_Column.Checked)
                            {
                                if (tableIndex == 0)
                                {
                                    foreach (DataRow row in table.Rows)
                                    {
                                        string xmlLine = row[0].ToString();
                                        string xmlOriginal = convert_xmlString_To_xmlText(xmlLine);

                                        if (rTB_XML_Column.Text != "")
                                            rTB_XML_Column.Text += "\r\n--------------------------------------------\r\n";
                                        rTB_XML_Column.Text += xmlOriginal;

                                        xmlOriginal = util.replace_place_to_value(xmlOriginal);
                                        if (rTB_XML_Column_Adjusted.Text != "")
                                            rTB_XML_Column_Adjusted.Text += "\r\n--------------------------------------------\r\n";
                                        rTB_XML_Column_Adjusted.Text += xmlOriginal;
                                        //string XML_FileURI = AppStartUpDir + "\\Adjusted.xml";
                                        //StreamWriter sw = new StreamWriter(XML_FileURI);
                                        //sw.Write(rTB_XML_Column_Adjusted.Text);
                                        //sw.Close();
                                        //XML_webBrowser2.Navigate(XML_FileURI);
                                    }
                                }
                            }
                        }
                        tableIndex++;
                    }

                    for (int j = countTables - 1; j >= 0; j--)
                    {
                        if (cB_Trees.Checked)
                        {
                            tB_Trees.Controls.Add(spliter[j]);
                            tB_Trees.Controls.Add(treeView[j]);
                        }
                        else
                            switch (DataSetOutNumber)
                            {
                                case 1:
                                    tabPage_DataSet1.Controls.Add(spliter[j]);
                                    tabPage_DataSet1.Controls.Add(dataGridView[j]);
                                    break;
                                case 2:
                                    tabPage_DataSet2.Controls.Add(spliter[j]);
                                    tabPage_DataSet2.Controls.Add(dataGridView[j]);
                                    break;
                                case 3:
                                    tabPage_DataSet3.Controls.Add(spliter[j]);
                                    tabPage_DataSet3.Controls.Add(dataGridView[j]);
                                    break;
                            }
                    }

                    if (!cB_NotSwitch_ToDataSetResult.Checked)
                    {
                        if (cB_Trees.Checked)
                            tabControl2.SelectedTab = tB_Trees;
                        else
                        {
                            tabControl2.SelectedTab = tabPage4;
                            switch (DataSetOutNumber)
                            {
                                case 1: tabControl8.SelectedTab = tabPage_DataSet1; break;
                                case 2: tabControl8.SelectedTab = tabPage_DataSet2; break;
                                case 3: tabControl8.SelectedTab = tabPage_DataSet3; break;
                            }
                        }
                    }

                    //check ExportValues
                    if (!cB_Trees.Checked)
                    if (dGV_Export_Values.Rows.Count > 0)
                    {
                        //Зачищать значения только от указанной транзакции, потом сделать
                        //dataSet1.Tables["Import_Values"].Clear();

                        string paramName;
                        int rowIndex; //dataSetIndex, 
                        int fieldIndex; bool detectedImportValues = false;
                        int countFields; bool detectImportParam;
                        string valueOfField; DataRow rowOfField;
                        int ExportValueID, Import_TransactionID;

                        foreach (DataGridViewRow row in dGV_Export_Values.Rows)
                        {
                            detectImportParam = false;
                            ExportValueID = (int)row.Cells["ID"].Value;
                            paramName = (string)row.Cells["paramName"].Value;
                            //dataSetIndex = 1;(int)row["dataSetIndex"];
                            tableIndex = (int)row.Cells["tableIndex"].Value;
                            rowIndex = (int)row.Cells["rowIndex"].Value;
                            fieldIndex = (int)row.Cells["fieldIndex"].Value;

                            if ((countTables > 0) && (countTables > tableIndex))
                            {
                                countRows = sql_DS_Result.dataSet.Tables[tableIndex].Rows.Count;
                                if ((countRows > 0) && (countRows > rowIndex))
                                {
                                    countFields = sql_DS_Result.dataSet.Tables[tableIndex].Columns.Count;
                                    if ((countFields > 0) && (countFields > fieldIndex))
                                    {
                                        rowOfField = sql_DS_Result.dataSet.Tables[tableIndex].Rows[rowIndex];
                                        valueOfField = rowOfField[fieldIndex].ToString();
                                        DataRow[] Export_Import_Rows = dataSet1.Tables["Export_Import"].Select("ExportValueID="+ExportValueID.ToString());
                                        foreach (DataRow Export_Import in Export_Import_Rows)
                                        {
                                            detectImportParam = false;
                                            Import_TransactionID = (int)Export_Import["Import_TransactionID"];
                                            DataRow[] Import_Rows = dataSet1.Tables["Import_Values"].Select("TransactionID="+Import_TransactionID.ToString());
                                            foreach (DataRow importRow in Import_Rows)
                                                if ((importRow["paramName"].ToString()).ToLower() == paramName.ToLower())
                                                {
                                                    importRow["Value"] = valueOfField; detectImportParam = true; break;
                                                }
                                            if (!detectImportParam)
                                                dataSet1.Tables["Import_Values"].Rows.Add(paramName, valueOfField, Import_TransactionID);
                                        }
                                        detectedImportValues = true;
                                    }
                                }
                            }
                        }
                        if (detectedImportValues)
                            dGV_Import_Values.Refresh();
                    }

                    //ColumnWidths
                    if (!cB_Trees.Checked)
                    if (dGV_ColumnWidths.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dGV_ColumnWidths.Rows)
                        {
                            tableIndex = (int)row.Cells["tableIndex"].Value;
                            int colIndex = (int)row.Cells["colIndex"].Value;
                            int colWidth = (int)row.Cells["width"].Value;
                            int mode = (int)row.Cells["mode"].Value;
                            if ((countTables > 0) && (countTables > tableIndex))
                            {
                                int countColumns = sql_DS_Result.dataSet.Tables[tableIndex].Columns.Count;
                                if ((countColumns > 0) && (countColumns > colIndex))
                                    if (mode > -1)
                                        try
                                        {
                                            switch (mode)
                                            {
                                                case 0: dataGridView[tableIndex].Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; break;
                                                case 1: dataGridView[tableIndex].Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; break;
                                                case 2: dataGridView[tableIndex].Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; break;
                                                case 3: dataGridView[tableIndex].Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader; break;
                                                case 4: dataGridView[tableIndex].Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; break;
                                                case 5: dataGridView[tableIndex].Columns[colIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; break;
                                            }
                                        }catch{}
                                    else
                                        dataGridView[tableIndex].Columns[colIndex].Width = colWidth;
                            }
                        }
                    }
                }
                tSL_RunResult.ForeColor = Color.FromArgb(0, 192, 0);
                tSL_RunResult.Text = "DONE";
                countHighlights = 5;
            }
            else
            {
                //MessageBox.Show("HERE");
                tSL_RunResult.ForeColor = Color.Red;
                tSL_RunResult.Text = "ERROR";
                rTB_Errors.Text += "------------------------------------------------\r\n";
                rTB_Errors.Text += sql_DS_Result.errorMessage + "\r\n";
                countHighlights = 50;
            }
            HighlightID = 1;
            timer_Highlight.Enabled = true;
        }

        private string convert_xmlString_To_xmlText(string xmlLine)
        {
            string result = "";
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xmlLine);
            StringWriter writer = new StringWriter();
            xd.Save(writer);
            result = writer.ToString();
            return result;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (tSCB_Srv.Text=="")
            {
                MessageBox.Show("Need setup Server and Database");
                return;
            }
            RunAction = true;
            BackFromResultAfterSeconds = (int)nUD_BackFromResultAfterSeconds.Value;
            if (rTB_sqlTransaction.Text == ""){MessageBox.Show("Empty sqlTransaction"); return;}
            if ((cB_Chart.Checked) || (cB_DelphiChart.Checked))
                Transaction_To_Chart();
            else
            {
                Transaction_To_DataSet();
                if (tSB_UseDumpValues.Checked)
                {
                    try
                    {
                        DumpRowIndex = dGV_Dump_Values.CurrentRow.Index + 1;
                        dGV_Dump_Values.CurrentCell = dGV_Dump_Values.Rows[DumpRowIndex].Cells[0];
                        dataSet1.Tables["Transactions"].Rows[TransactionRowIndex]["DumpRowIndex"] = DumpRowIndex;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                switch (cB_AfterRun.SelectedIndex)
                {
                    case 1:
                        treeView1.SelectedNode = treeView1.SelectedNode.Parent;
                        break;
                    default:
                        break;
                }
            }
        }
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
        }
        private void Transaction_buttons_actions(){
            if (TransactionUpdate)
            {
                tSB_TransactionUpdate.Enabled = true;
                tDB_TransactionUpdateAndRun.Enabled = true;
            }
        }
        //private void Transaction_clear_fields(){
            //ttB_Description.Text = "";
            //rTB_sqlTransaction.Text = "";
        //}
        //private void Transaction_action_cancel()
        //{
            //if (!((NodeClick) || (TransactionUpdate)))
            //    Transaction_clear_fields();
            /*
            tSB_CancelTransaction.Enabled = false;
            tSB_TransactionNew.Enabled = true;
            if (TransactionNew)
            {
                TransactionNew = false;
                //tSB_TransactionAdd.Enabled = false;
                //cB_Child.Enabled = false;
            }
            if (TransactionUpdate)
            {
                TransactionUpdate = false;
                //TransactionUpdate2 = false;
                //TransactionUpdate3 = false;
                tSB_TransactionUpdate.Enabled = false;
                tDB_TransactionUpdateAndRun.Enabled = false;
            }*/
        //}
        private void tB_sqlTransaction_TextChanged(object sender, EventArgs e)
        {
            TransactionUpdate = true;
            Transaction_buttons_actions();
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
            toolStripButton3_Click(sender, e);
        }
        private void tSB_CancelTransaction_Click(object sender, EventArgs e)
        {

        }
        private void showTransactionIDInNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTransactionIDInNodesToolStripMenuItem.Checked = !showTransactionIDInNodesToolStripMenuItem.Checked;
            refreshToolStripMenuItem_Click(null, null);
        }
        private void timer_Highlight_Tick(object sender, EventArgs e)
        {
            timer_Highlight.Enabled = false;
            countHighlights--;
            switch (HighlightID)
            {
                case 1:
                    if (countHighlights == 0)
                    {
                        tSL_RunResult.Text = "WAITING";
                        tSL_RunResult.ForeColor = Color.Black;
                    }
                    break;
            }
            if (countHighlights != 0) 
                timer_Highlight.Enabled = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //toolStripMenuItem3.Checked = !toolStripMenuItem3.Checked;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void upToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            
        }
        private void upToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }
        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            TransactionUpdate = true;
            Transaction_buttons_actions();
        }
        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart1.Annotations.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart_DataTable = null;
            chart_sql = null;
            chartIndex = -1;
        }
        private void reservToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void runToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }
        private void reservToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (tSB_TransactionAdd.Enabled)
            //    toolStripButton1_Click(sender, e);
            if (tSB_TransactionUpdate.Enabled)
                toolStripButton2_Click(sender, e);
        }
        private void saveAndRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tDB_TransactionUpdateAndRun.Enabled)
                toolStripButton4_Click(sender, e);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (NodeClick) return;
            tSB_UseDumpValues.Checked = false;
            if ((!ParamNew) && (!paramsNavigate))
            {
                DataGridViewRow row = dGV_Transaction_Params.CurrentRow;
                if (row == null) return;
                string paramValue = "";
                if (cB_Param_Type.SelectedIndex == 2)
                    paramValue = cB_Param_Value.Checked.ToString();
                else
                    paramValue = tB_Param_Value.Text;
                DataRow[] SessParamValues = dataSet1.Tables["Last_Param_Values"].Select("TransactionID=" + TransactionID.ToString());
                if (SessParamValues.Length >0)
                    foreach (DataRow rowSPV in SessParamValues)
                        if (rowSPV["ParamName"].ToString() == row.Cells[1].Value.ToString())
                            dataSet1.Tables["Last_Param_Values"].Rows.Remove(rowSPV);
                if (paramValue != "")
                {
                    DataRow NewRow = dataSet1.Tables["Last_Param_Values"].NewRow();
                    NewRow["TransactionID"] = TransactionID;
                    NewRow["ParamName"] = row.Cells[1].Value;
                    NewRow["ParamValue"] = paramValue;
                    dataSet1.Tables["Last_Param_Values"].Rows.Add(NewRow);
                }
                if (!paramsNavigate)
                    updToolStripMenuItem.Enabled = true;
                if (cB_AutoRun_AfterChangeValue.Checked)
                    toolStripButton3_Click(null, null);
            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            change_param_status();
        }
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
        }
        private void cB_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("AutoRun", cB_AutoRun.Checked.ToString(), "bool");
        }
        private void cB_Chart_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("Chart", cB_Chart.Checked.ToString(), "bool");
        }
        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (cB_Chart.Checked)
                Update_Param("ChartType", cB_ChartType.SelectedIndex.ToString(), "int");
        }

        //private void Transaction_update_2()
        //{
            //TransactionUpdate = true;
            //TransactionUpdate2 = true;
            //Transaction_buttons_actions();
        //}

        private void Transaction_update_3()
        {
            TransactionUpdate = true;
            //TransactionUpdate3 = true;
            Transaction_buttons_actions();
        }
        private void Transaction_update_4()
        {
            TransactionUpdate = true;
            //TransactionUpdate4 = true;
            Transaction_buttons_actions();
        }
        private void Transaction_update_5()
        {
            TransactionUpdate = true;
            //TransactionUpdate5 = true;
            Transaction_buttons_actions();
        }
        //private void Transaction_update_6()
        //{
            //TransactionUpdate = true;
            //TransactionUpdate6 = true;
            //Transaction_buttons_actions();
        //}
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tB_Param_Name.Text == "")
            {
                MessageBox.Show("Need min 1 params : Name"); return;
            }
            //Transaction_update_2();
            param_add_or_update(true);
            ParamNew = false;
            newToolStripMenuItem.Enabled = true;
            addToolStripMenuItem1.Enabled = false;
            updToolStripMenuItem.Enabled = false;
            tB_Param_Name.ReadOnly = true;
            cB_Param_Type.Enabled = false;
        }
        private void param_add_or_update(bool Add)
        {
            DataRow row = dataSet1.Tables["Transaction_Params"].NewRow();
            if (Add)
            {
                row["TransactionID"] = TransactionID;
                row["paramName"] = tB_Param_Name.Text;
                row["Type"] = cB_Param_Type.SelectedIndex;
                if (cB_Param_Type.SelectedIndex == 2)
                    row["Value"] = cB_Param_Value.Checked.ToString();
                else
                    row["Value"] = tB_Param_Value.Text;
                row["Important"] = true;
                row["Import"] = tB_Param_Import.Text;
                dataSet1.Tables["Transaction_Params"].Rows.Add(row);
            }
            else // Update
            {
                foreach (DataRow row_p in dataSet1.Tables["Transaction_Params"].Rows)
                {
                    if (row_p["paramName"].ToString() == tB_Param_Name.Text)
                    {
                        row_p["Type"] = cB_Param_Type.SelectedIndex;
                        if (cB_Param_Type.SelectedIndex == 2)
                            row_p["Value"] = cB_Param_Value.Checked.ToString();
                        else row_p["Value"] = tB_Param_Value.Text;
                        row_p["Import"] = tB_Param_Import.Text;
                        break;
                    }
                }
            }
            //Add Param To Transaction
            string ParamString = "DECLARE @" + tB_Param_Name.Text+" ";
            string ParamValue = " SET @" + tB_Param_Name.Text + " = {" + tB_Param_Name.Text + "}";
            switch (cB_Param_Type.SelectedIndex)
            {
                case 0: //Number
                    ParamString += "int";
                    break;
                case 1: //String
                    ParamString += "varchar(250)";
                    break;
                case 2: //Boolean
                    ParamString += "bit";
                    break;
            }
            ParamString += ParamValue+"\r\n";
            rTB_sqlTransaction.Text = ParamString + rTB_sqlTransaction.Text;

        }
        private void cB_Param_Type_VisibleChanged(object sender, EventArgs e)
        {
            
        }
        private void checkBox2_CheckedChanged_2(object sender, EventArgs e)
        {
            textBox2_TextChanged(sender, e);
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            /*
            paramsNavigate = true;
            ParamNew = false;
            newToolStripMenuItem.Enabled = true;
            addToolStripMenuItem1.Enabled = false;
            updToolStripMenuItem.Enabled = false;
            int itemIndex=-1;
            ListViewItem item = null;
            if (sender is ListViewItem)
            {
                item = (ListViewItem)sender;
                itemIndex = 0;
            }
            else
                foreach (ListViewItem listItem in listView1.SelectedItems)
                {
                    item = listItem;
                    itemIndex = listItem.Index;
                    break;
                }
            if (itemIndex != -1)
            {
                tB_Param_Name.Text = item.Text;
                cB_Param_Type.SelectedIndex = int.Parse(item.SubItems[1].Text);
                //cB_Param_Static.Checked = bool.Parse(item.SubItems[2].Text);

                if (cB_Param_Type.SelectedIndex == 2)
                {
                    tB_Param_Value.Text = "";
                    if (param_values.Length > 0){
                        if (param_values[itemIndex] != item.SubItems[3].Text)
                            cB_Param_Value.Checked = bool.Parse(param_values[itemIndex]);
                        else cB_Param_Value.Checked = bool.Parse(item.SubItems[3].Text);
                    }
                    else cB_Param_Value.Checked = bool.Parse(item.SubItems[3].Text);
                }
                else
                {
                    cB_Param_Value.Checked = false;
                    if (param_values.Length > 0)
                    {
                        if (param_values[itemIndex] != item.SubItems[3].Text)
                            tB_Param_Value.Text = param_values[itemIndex];
                        else tB_Param_Value.Text = item.SubItems[3].Text;
                    }
                    else tB_Param_Value.Text = item.SubItems[3].Text;
                }
                cB_Param_Important.Checked = bool.Parse(item.SubItems[4].Text);
                tB_Param_Import.Text = item.SubItems[5].Text;
                change_param_status();
            }

            if (item.Checked)
                groupBox13.Enabled = false;
            else
            {
                groupBox13.Enabled = true;
                tB_Param_Value.SelectAll();
                tB_Param_Value.Focus();
            }

            paramsNavigate = false;
            */
        }
        private void change_param_status()
        {
            if (cB_Param_Type.SelectedIndex == 2)
            {
                cB_Param_Value.Enabled = true;
                tB_Param_Value.Enabled = false;
            }
            else
            {
                cB_Param_Value.Checked = false;
                cB_Param_Value.Enabled = false;
                tB_Param_Value.Enabled = true;
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamNew = true;
            //if (!groupBox13.Enabled)                   
            //    groupBox13.Enabled = true;
            tB_Param_Name.Text = "";
            tB_Param_Value.Text = "";
            tB_Param_Import.Text = "";
            cB_Param_Type.SelectedIndex = 0;
            newToolStripMenuItem.Enabled = false;
            addToolStripMenuItem1.Enabled = true;
            updToolStripMenuItem.Enabled = false;
            tB_Param_Name.ReadOnly = false;
            tB_Param_Name.Focus();
            cB_Param_Type.Enabled = true;
            //cB_Param_Important.Checked = true;
            change_param_status();
        }
        private void updToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Transaction_update_2();
            param_add_or_update(false);
            updToolStripMenuItem.Enabled = false;
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            dGV_Transaction_Params.Rows.Remove(dGV_Transaction_Params.CurrentRow);
        }
        private void tB_Param_Value_Click(object sender, EventArgs e)
        {
            
        }
        private void tB_Param_Value_MouseUp(object sender, MouseEventArgs e)
        {
            tB_Param_Value.SelectAll();
        }
        private void tB_Param_Name_MouseUp(object sender, MouseEventArgs e)
        {
            tB_Param_Name.SelectAll();
        }
        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*
            if (e.NewValue.ToString() == "Checked")
                listView1.Items[e.Index].SubItems[2].Text = "True";
            else
                listView1.Items[e.Index].SubItems[2].Text = "False";

            foreach (int itemIndex in listView1.SelectedIndices)
                if (e.Index == itemIndex)
                    if (e.NewValue.ToString() == "Checked")
                        groupBox13.Enabled = false;
                    else
                        groupBox13.Enabled = true;
            */
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            
        }

        private void listView1_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_Validated(object sender, EventArgs e)
        {
            
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void cB_Param_Important_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveParamsAndTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (updToolStripMenuItem.Enabled)
                updToolStripMenuItem_Click(null, null);
            toolStripButton2_Click(null, null);
        }

        private void testDelphiChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sServerID;
            sServerID = tSCB_Srv.Text.Substring(0, tSCB_Srv.Text.IndexOf('.'));
            ServerID = int.Parse(sServerID);

            DataRow[] rows = dataSet1.Tables["Servers"].Select("ID=" + ServerID.ToString());
            if (rows.Length == 1)
            {
                connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=.";
                if (rows[0]["ConnectionString"] == DBNull.Value)
                    rows[0]["ConnectionString"] = connectionString;
                else
                    connectionString = (string)rows[0]["ConnectionString"];

                foreach (DataRow row in dataSet1.Tables["Servers"].Rows)
                    if ((int)row["ID"] == ServerID)
                        row["Last"] = true;
                    else
                        row["Last"] = false;

                sql_Temp_Query = new Sql(connectionString, true);
                get_databases(ServerID);
                get_LinkedServers(ServerID);
            }
        }

        private void get_LinkedServers(int ServerID)
        {
            tSCB_LinkedServers.Text = "";
            tSCB_LinkedServers.Items.Clear();
            DataRow[] dataRows = dataSet1.Tables["LinkedServers"].Select("ServerID=" + ServerID.ToString());
            foreach (DataRow row in dataRows)
                tSCB_LinkedServers.Items.Add(row["Name"].ToString());
        }

        private void checkBox2_CheckedChanged_3(object sender, EventArgs e)
        {
            if (NodeClick) return;

            if (checkBox2.Checked)
            {
                if ((tSCB_Srv.Text == "") || (tSCB_DB.Text == ""))
                {
                    MessageBox.Show("Need right select Server and Database");
                    return;
                }
                if ((tSCB_Srv.Text.IndexOf('.') == -1) ||
                    (tSCB_DB.Text.IndexOf('.') == -1))
                {
                    MessageBox.Show("Need Select Server and Database");
                    return;
                }
                string sServerID;
                string sDatabseID;
                sServerID = tSCB_Srv.Text.Substring(0, tSCB_Srv.Text.IndexOf('.'));
                sDatabseID = tSCB_DB.Text.Substring(0, tSCB_DB.Text.IndexOf('.'));
                ServerID = int.Parse(sServerID);
                DatabaseID = int.Parse(sDatabseID);
                tB_Param_Srv.Text = tSCB_Srv.Text;
                tB_Param_DB.Text = tSCB_DB.Text;
            }
            else
                if ((tB_Param_Srv.Text != "") && (tB_Param_DB.Text != ""))
                {
                    ServerID = 0;
                    DatabaseID = 0;
                }
            if ((tB_Param_Srv.Text != "") && (tB_Param_DB.Text != ""))
                Transaction_update_4();
        }

        private void cB_DelphiChart_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("DelphiChart", cB_DelphiChart.Checked.ToString(), "bool");
        }

        private void cB_Use_DB_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dGV_Transaction_Params_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dGV_Transaction_Params_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dGV_Transaction_Params_Click(object sender, EventArgs e)
        {
        }

        private void dGV_Transaction_Params_EditModeChanged(object sender, EventArgs e)
        {
            
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //string User_ID = "", Password = "";
            //string Initial_Catalog = "";
            //string Provider = "";
            //bool WindowsIntegratedConnectaion = false;
            ServerAdd serverAdd = new ServerAdd();
            serverAdd.ShowDialog();
            string serverName = serverAdd.ServerName;
            string connectionString  = serverAdd.ConnectionString;
            string dataBase = serverAdd.DataBase;
            serverAdd.Close();
            if ((serverName != "") && (connectionString !="") && (dataBase != ""))
            {
                DataRow newRow = dataSet1.Tables["Servers"].NewRow();
                newRow["Name"] = serverName;
                newRow["ConnectionString"] = connectionString;
                newRow["PrimaryDataBase"] = dataBase;
                dataSet1.Tables["Servers"].Rows.Add(newRow);

                DataRow LastRow = (DataRow)dataSet1.Tables["Servers"].Rows[dataSet1.Tables["Servers"].Rows.Count - 1];
                int ServerID = (int)LastRow["ID"];
                    
                // Add DataBase
                newRow = dataSet1.Tables["DataBases"].NewRow();
                newRow["Name"] = dataBase;
                newRow["ServerID"] = ServerID;
                dataSet1.Tables["DataBases"].Rows.Add(newRow);
            }


            //перчитать сервера
            
            //подключиться на колелкцию .config
            //ConnectionStringSettingsCollection csc = ConfigurationManager.ConnectionStrings;
            //string StartApp_AfterUpdates = 
            //csc.Add(settings);
            //ConnectionStringSettings settings = new ConnectionStringSettings(serverName, connectionString);
            //ConfigurationManager.ConnectionStrings.Add(settings);
            //ConfigurationManager.
            //return;

            //System.Configuration.
            /*
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = "(local)"; //IP с портом или без,  или алиас системы
            if (WindowsIntegratedConnectaion)
            {
                //builder["Integrated Security"] = "SSPI";
                //builder["Persist Security Info"] = false;
                builder["Integrated Security"] = true;
            }
            else
            {
                builder["Persist Security Info"] = true;
                builder["Password"] = Password;
                builder["User ID"] = User_ID;
            }
            if (Initial_Catalog !="")
                builder["Initial Catalog"] = Initial_Catalog;
            if (Provider !="")
                builder["Provider"] = Initial_Catalog;
            MessageBox.Show(builder.ConnectionString);
            //*/

            //builder["Initial Catalog"] = "AdventureWorks;NewValue=Bad";
            //Console.WriteLine(builder.ConnectionString);

            //ConfigurationManager.AppSettings.

            //Properties.Settings settings = Properties.Settings.Default;
            //settings["имя строки прописанное в app.config"] = новая строка;
            //settings.Save();

            //MessageBox.Show(toolStripTextBox1.Text);

            /*
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = "prompt";
            ib.FormCaption = "title";
            ib.DefaultValue = "0";
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();*/
            //return s;

            //SimpleDialog sd = new SimpleDialog();
            //sd.ShowDialog();
            //sd.Close();
        }

        private void encryptDecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tB_Param_Import_TextChanged(object sender, EventArgs e)
        {
            textBox2_TextChanged(sender, e);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            tB_Param_Import.Text = tB_Param_Name.Text;
        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            Preview = true;
            toolStripButton3_Click(null, null);
            if (!sqlCommand_empty)
            {
                tabControl2.SelectedTab = tabPage10;
                tabControl5.SelectedTab = tabPage1;
            }
            Preview = false;
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            tB_Param_Import.Text = "";
        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            //rTB_sqlTransaction.Text += "\r\n--\r\n";
            //rTB_sqlTransaction.Text += comboBox2.Text;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
        }

        private void saveTreeToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // method 1 Export use StreamWriter 
            //exportToXml(treeView1, "sql_speed_work_tree_transactions.xml");
            // method 2 Export using XmlTextWriter
            exportToXml2(treeView1, "sql_speed_work_tree_transactions.xml");
        }
        public void exportToXml(TreeView tv, string filename)
        {
            sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sr.WriteLine("<" + treeView1.Nodes[0].Text + ">");
            foreach (TreeNode node in tv.Nodes)
                saveNode(node.Nodes);
            sr.WriteLine("</" + treeView1.Nodes[0].Text + ">");
            sr.Close();
        }

        private void saveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
                if (node.Nodes.Count > 0)
                {
                    sr.WriteLine("<" + node.Text + ">");
                    saveNode(node.Nodes);
                    sr.WriteLine("</" + node.Text + ">");
                }
                else
                    sr.WriteLine(node.Text);
        }

        public void exportToXml2(TreeView tv, string filename)
        {
            xr = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            xr.WriteStartDocument();
            xr.Indentation = 10;
            //xr.Write
            xr.WriteStartElement(treeView1.Nodes[0].Text);
            foreach (TreeNode node in tv.Nodes)
                saveNode2(node.Nodes);
            xr.WriteEndElement();
            xr.Close();
        }

        private void saveNode2(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    xr.WriteStartElement(node.Text);
                    saveNode2(node.Nodes);
                    xr.WriteEndElement();
                }
                else
                    xr.WriteString(node.Text);
            }
        }
        private void populateTreeview()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open XML Document";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.FileName = Application.StartupPath + "\\..\\..\\example.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Just a good practice -- change the cursor to a 
                    //wait cursor while the nodes populate
                    this.Cursor = Cursors.WaitCursor;
                    //First, we'll load the Xml document
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(dlg.FileName);
                    //Now, clear out the treeview, 
                    //and add the first (root) node
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(new
                      TreeNode(xDoc.DocumentElement.Name));
                    TreeNode tNode = new TreeNode();
                    tNode = (TreeNode)treeView1.Nodes[0];
                    //We make a call to addTreeNode, 
                    //where we'll add all of our nodes
                    addTreeNode(xDoc.DocumentElement, tNode);
                    //Expand the treeview to show all nodes
                    treeView1.ExpandAll();
                }
                catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
                {
                    MessageBox.Show(xExc.Message);
                }
                catch (Exception ex) //General exception
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default; //Change the cursor back
                }
            }
        }
        //This function is called recursively until all nodes are loaded
        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.Nodes[x];
                    addTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = xmlNode.OuterXml.Trim();
        }

        private void disableAutoRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disableAutoRunToolStripMenuItem.Checked = !disableAutoRunToolStripMenuItem.Checked;
        }

        private void comboBox1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            if (cB_DelphiChart.Checked)
                Update_Param("DelphiChartType", cB_DelphiChartType.SelectedIndex.ToString(), "int");
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem4.Checked = !addToolStripMenuItem4.Checked;
        }

        private void exportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void delphiClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //dGV_Import_Values.Rows.Remove(dGV_Import_Values.CurrentRow);
        }

        private void ttB_Description_MouseUp(object sender, MouseEventArgs e)
        {
            ttB_Description.SelectAll();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
        }

        private void useLinkServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Use_LinkedServer.Checked = !Use_LinkedServer.Checked;
        }

        private void tB_Param_Srv_TextChanged(object sender, EventArgs e)
        {

        }

        private void cB_NotUse_LinkedServer_CheckedChanged(object sender, EventArgs e)
        {
            //if (NodeClick) return;
            //Update_Param("NotUse_LinkedServer", cB_NotUse_LinkedServer.Checked.ToString(), "bool");
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            
            string URL = tSTB_URL.Text;
            if (URL.IndexOf(']') > 0)
                URL = URL.Substring(URL.IndexOf(']')+1);

            if (URL.IndexOf("{SUBSTITUTION}") > 0)
                URL = URL.Replace("{SUBSTITUTION}", tSTB_Substitution.Text);

            listBox1.Items.Add("======================================================================");

            Process process = new Process();
            process.StartInfo.Arguments = URL;
            switch (toolStripComboBox2.Text)
            {
                case"Internal IE":
                    webBrowser1.Navigate(URL);
                    break;
                case"Chrome":
                    process.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    process.Start();
                    break;
                case"FireFox":
                    process.StartInfo.FileName = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    process.Start();
                    break;
                case "External IE":
                    process.StartInfo.FileName = @"C:\Program Files\Internet Explorer\iexplore.exe";
                    process.Start();
                    break;
            }
        }

        private void tSTB_Substitution_MouseUp(object sender, MouseEventArgs e)
        {
            tSTB_Substitution.SelectAll();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSQLProject();
            dataSetApp.WriteXml(AppStartUpDir + "\\AppDataSet.xml");
        }

        private void cB_UseImportValues_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cB_UseImportValues_Click(object sender, EventArgs e)
        {
            tSB_UseImportValues.Checked = !tSB_UseImportValues.Checked;
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            //tSB_UseLastValues.Checked = !tSB_UseLastValues.Checked;
            //Update_Param("UseLastValues", tSB_UseLastValues.Checked.ToString(), "bool");
        }

        private void Auto_ReRun_Click(object sender, EventArgs e)
        {
            toolStripButton20_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (Auto_ReRun.Checked)
            {
                if (Auto_ReRun_Count == 0)
                {
                    toolStripButton3_Click(sender, e);
                    Auto_ReRun_Count = int.Parse(tSTB_Auto_ReRun_Count.Text);
                }
                Auto_ReRun_Count--;
            }
            if (tSB_TransactionUpdate.Enabled)
            {
                TransactionUpdated_WaitCount++;
                if (TransactionUpdated_WaitCount == 60)
                    toolStripButton2_Click(null, null);
            }

            IntPtr ptr_hWnd;
            ptr_hWnd = FindWindow(null, "Ошибка сценария");
            if (ptr_hWnd != null)
                if (!toolStripButton19.Checked)
                    SendMessage(ptr_hWnd, WM_CLOSE, 0, 0);

            ptr_hWnd = FindWindow(null, "Script Error");
            if (ptr_hWnd != null)
                if (!toolStripButton19.Checked)
                    SendMessage(ptr_hWnd, WM_CLOSE, 0, 0);

            if ((tabControl2.SelectedIndex != 0) && (RunAction))
                if (cB_BackFromResult.Checked)
                {
                    BackFromResultAfterSeconds--;
                    if (BackFromResultAfterSeconds == 0)
                    {
                        tabControl2.SelectedIndex = 0;
                        RunAction = false;
                    }
                }
            timer1.Enabled = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dGV_Session_Values.Rows.Count > 0)
                    dGV_Session_Values.Rows.Remove(dGV_Session_Values.CurrentRow);
            }
            catch { }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }

        private void cB_UseImportValues_Click_1(object sender, EventArgs e)
        {
            //tSB_UseImportValues.Checked = !tSB_UseImportValues.Checked;
            //Update_Param("UseImportValues", tSB_UseImportValues.Checked.ToString(), "bool");
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*/Transactions
            MessageBox.Show("Count:" + dataSet1.Tables["Transactions"].Rows.Count.ToString());
            dataSet1.Tables["Transactions"].Clear();
            MessageBox.Show("Count:" + dataSet1.Tables["Transactions"].Rows.Count.ToString());
            string sqlString = "";
            //sqlString += "SELECT * FROM SupportDB..sql_speed_work_transactions";
sqlString += "SELECT  ";
sqlString += "T.ID,T.Description,ParentID=UT.DumpParentID ,T.AutoRun ,T.Chart ,T.ChartType , ";
sqlString += "T.DelphiChart ,T.DelphiChartType ,UT.ServerID , ";
sqlString += "UT.DatabaseID ,UT.UseDatabase ,UT.NotUse_LinkedServer ,UT.LinkedServer   ";
sqlString += "FROM SupportDB..sql_speed_work_transactions T ";
sqlString += "LEFT JOIN SupportDB..sql_speed_work_user_transactions UT ON UT.TransactionID = T.ID ";

            sql_Temp_Query.sqlCommandExecute_return_DataSet(sqlString);
            if (!sql_Temp_Query.error)
            {
                foreach (DataRow row in sql_Temp_Query.dataSet.Tables[0].Rows)
                {
                    DataRow rowPar = dataSet1.Tables["Transactions"].NewRow();
                    rowPar["ID"]=row["ID"];
                    rowPar["Description"]=row["Description"];
                    rowPar["ParentID"]=row["ParentID"];
                    rowPar["AutoRun"]=row["AutoRun"];
                    rowPar["Chart"]=row["Chart"];
                    rowPar["ChartType"]=row["ChartType"];
                    rowPar["DelphiChart"]=row["DelphiChart"];
                    rowPar["DelphiChartType"]=row["DelphiChartType"];
                    rowPar["ServerID"]=row["ServerID"];
                    rowPar["DatabaseID"]=row["DatabaseID"];
                    rowPar["DatabaseID"]=row["DatabaseID"];
                    rowPar["UseDatabase"]=row["UseDatabase"];
                    rowPar["NotUse_LinkedServer"]=row["NotUse_LinkedServer"];
                    rowPar["LinkedServer"]=row["LinkedServer"];
                    dataSet1.Tables["Transactions"].Rows.Add(rowPar);
                }
                MessageBox.Show("Uploaded:"+dataSet1.Tables["Transactions"].Rows.Count.ToString());
            }//*/

            /*Params
            MessageBox.Show("Count:"+dataSet1.Tables["Transaction_Params"].Rows.Count.ToString());
            dataSet1.Tables["Transaction_Params"].Clear();
            MessageBox.Show("Count:" + dataSet1.Tables["Transaction_Params"].Rows.Count.ToString());

            sql_Temp_Query.sqlCommandExecute_return_DataSet("SELECT * FROM SupportDB..sql_speed_work_transaction_params");
            if (!sql_Temp_Query.error)
            {
                foreach (DataRow row in sql_Temp_Query.dataSet.Tables[0].Rows)
                {
                    DataRow rowPar = dataSet1.Tables["Transaction_Params"].NewRow();
                    rowPar["TransactionID"]=row["TransactionID"];
                    rowPar["paramName"]=row["Name"];
                    rowPar["Type"]=row["Type"];
                    rowPar["Value"]=row["Value"];
                    rowPar["ReadOnly"]=row["ReadOnly"];
                    rowPar["Important"]=row["Important"];
                    rowPar["Import"]=row["Import"];
                    dataSet1.Tables["Transaction_Params"].Rows.Add(rowPar);
                }
                MessageBox.Show("Uploaded");
            }*/

        }

        private void toolStrip4_TextChanged(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            DataRow row = dataSet1.Tables["Browser_URLs"].NewRow();
            row["URL"] = tSTB_URL.Text;
            dataSet1.Tables["Browser_URLs"].Rows.Add(row);
            tSTB_URL.Items.Add(tSTB_URL.Text);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dataSet1.Tables["Browser_URLs"].Rows)
                if (row["URL"].ToString() == tSTB_URL.Text)
                {
                    dataSet1.Tables["Browser_URLs"].Rows.Remove(row);
                    break;
                }
            foreach (string item in tSTB_URL.Items)
                if (item == tSTB_URL.Text)
                {
                    tSTB_URL.Items.Remove(item);
                    break;
                }
        }

        private void tB_Param_DB_TextChanged(object sender, EventArgs e)
        {

        }

        private void tB_Use_DB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tB_LinkedServer_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Update_Param(string pramName, string paramValue, string paramType)
        {
            if (NodeClick) return;
            DataView dv = new DataView(dataSet1.Tables["Transactions"]);
            //dv.RowFilter = "ID=" + TransactionID.ToString();
            dv.Sort = "ID ASC";
            int rowIndex = dv.Find(TransactionID);
            if (rowIndex == -1)
                MessageBox.Show("Not Found Transaction");
            else
            {
                try
                {
                    //string desc = (string)dataSet1.Tables["Transactions"].Rows[rowIndex]["Description"];
                    //Update_Param("Trees", cB_Trees.Checked.ToString(), "bool");
                    //MessageBox.Show(desc);
                    switch (paramType)
                    {
                        case "bool":
                            dataSet1.Tables["Transactions"].Rows[rowIndex][pramName] = bool.Parse(paramValue);
                            break;
                        case "int":
                            dataSet1.Tables["Transactions"].Rows[rowIndex][pramName] = int.Parse(paramValue);
                            break;
                        case "string":
                            dataSet1.Tables["Transactions"].Rows[rowIndex][pramName] = paramValue;
                            break;
                        case "decimal":
                            dataSet1.Tables["Transactions"].Rows[rowIndex][pramName] = decimal.Parse(paramValue);
                            break;
                    }
                    //desc = (string)dataSet1.Tables["Transactions"].Rows[rowIndex]["Description"];
                    //MessageBox.Show(desc);
                }
                catch //(Exception ex)
                {
                }
            }

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedTab.Name)
            {
                case "tabPage3":
                    if (tabControl3.SelectedIndex == 1)
                        set_focus_on_first_param();
                    break;
                case "tabPage2":
                    tSTB_Substitution.SelectAll();
                    tSTB_Substitution.Focus();
                    if (toolStripComboBox2.Text == "")
                        toolStripComboBox2.SelectedIndex = 1;;
                    break;
                case "tabPage11":
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    break;
            }
        }

        private void tB_Use_DB_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void toolStripButton4_Click_2(object sender, EventArgs e)
        {
            //sql_Temp_Query.sqlCommandExecute_return_DataSet("Master.dbo.sp_linkedservers");
            sql_Temp_Query.Execute("Master.dbo.sp_linkedservers");
            if (sql_Temp_Query.error)
                MessageBox.Show(sql_Temp_Query.errorMessage);
            else
            {
                bool LinkedServer_Added = false;
                DataRow[] dataRows = dataSet1.Tables["LinkedServers"].Select("ServerID=" + ServerID.ToString());
                foreach (DataRow row in sql_Temp_Query.dataSet.Tables[0].Rows)
                {
                    bool LinkedServer_Detected = false;
                    foreach (DataRow dataRow in dataRows)
                        if (dataRow["Name"].ToString() == row["SRV_NAME"].ToString())
                        {
                            LinkedServer_Detected = true;
                            break;
                        }
                    if (!LinkedServer_Detected){
                        DataRow newRow = dataSet1.Tables["LinkedServers"].NewRow();
                        newRow["ServerID"]=ServerID;
                        newRow["Name"]=row["SRV_NAME"];
                        dataSet1.Tables["LinkedServers"].Rows.Add(newRow);
                        LinkedServer_Added  =true;
                    }
                }
                if (LinkedServer_Added)
                    get_LinkedServers(ServerID);
            }
        }

        private void cB_Use_LinkedServer_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            listBox2.Items.Add("--------------------------------------------");
            listBox2.Items.Add(e.Description);
            e.Handled = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
            
            tB_NavigateHistory.Text = e.Url.ToString() + "\r\n" + tB_NavigateHistory.Text;
            listBox1.Items.Insert(0, "webBrowser1_DocumentCompleted");
            if (toolStripButton17.Checked)
            {
                listBox1.Items.Insert(0, "AUTO:STOP");
                webBrowser1.Stop();
            }
        }

        private void nUD_DataSet_OutNumber_ValueChanged(object sender, EventArgs e)
        {
            Update_Param("DataSetOutNumber", nUD_DataSetOutNumber.Value.ToString(), "decimal");
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (NodeClick) return;
            cB_Use_DB.Checked = !cB_Use_DB.Checked;
            UseDatabase = "";
            if (cB_Use_DB.Checked)
            {
                if (tSCB_DB.Text == "")
                {
                    MessageBox.Show("Need right select Server and Database");
                    return;
                }
                if (tSCB_DB.Text.IndexOf('.') == -1)
                {
                    MessageBox.Show("Need Select Server and Database");
                    return;
                }
                UseDatabase = tSCB_DB.Text.Substring(tSCB_DB.Text.IndexOf('.') + 1);
            }
            tB_Use_DB.Text = UseDatabase;
            //Transaction_update_5();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            cB_Use_LinkedServer.Checked = !cB_Use_LinkedServer.Checked;
            if (NodeClick) return;
            if (cB_Use_LinkedServer.Checked)
                tB_LinkedServer.Text = tSCB_LinkedServers.Text;
            else tB_LinkedServer.Text = "";
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox5_TextChanged(object sender, EventArgs e)
        {
            Update_Param("LinkedServer", tB_LinkedServer.Text, "string");
            if (tB_LinkedServer.Text == "")
                cB_Use_LinkedServer.Checked = false;
            else
                cB_Use_LinkedServer.Checked = true;
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox4_TextChanged(object sender, EventArgs e)
        {
            Update_Param("UseDatabase", tB_Use_DB.Text, "string");
            if (tB_Use_DB.Text == "")
                cB_Use_DB.Checked=false;
            else
                cB_Use_DB.Checked = true;
        }


        private void rTB_sqlTransaction_TextChanged_1(object sender, EventArgs e)
        {
            if (NodeClick) return;
            TransactionUpdated_WaitCount = 0;
            TransactionUpdate = true;
            Transaction_buttons_actions();
            //rTB_sqlTransaction.ForeColor = Color.White;
            //rTB_sqlTransaction.Refresh();
        }

        private void rTB_sqlTransaction_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 17)
                save_zoomFactor();
        }

        private void save_zoomFactor()
        {
            DataRow[] rows = dataSet1.Tables["Transactions"].Select("ID=" + TransactionID.ToString());
            if (rows.Length == 1)
            {
                DataRow row = rows[0];
                row["ZoomFactor"] = rTB_sqlTransaction.ZoomFactor;
                toolStripSplitButton3.Text = rTB_sqlTransaction.ZoomFactor.ToString();
            }
        }

        private void rTB_sqlTransaction_MouseUp(object sender, MouseEventArgs e)
        {
            //Transaction_Text_Pos = rTB_sqlTransaction.GetCharIndexFromPosition(e.Location);
            //rTB_sqlTransaction.SelectedText.Re
            //Pos_X.Text = e.X.ToString();
            //Pos_Y.Text = e.Y.ToString();
            //e.
        }

        private void dGV_Transaction_Params_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("dGV_Transaction_Params_Click");
            paramsNavigate = true;
            ParamNew = false;
            newToolStripMenuItem.Enabled = true;
            addToolStripMenuItem1.Enabled = false;
            updToolStripMenuItem.Enabled = false;
            //int itemIndex = -1;
            DataGridViewRow row = dGV_Transaction_Params.CurrentRow;

            if (row == null) return;
            //itemIndex = row.Index;

            //if (itemIndex != -1)
            //{
            tB_Param_Name.Text = row.Cells["paramName"].Value.ToString();
            cB_Param_Type.SelectedIndex = int.Parse(row.Cells["Type"].Value.ToString());
            tB_Param_Value.Text = "";
            cB_Param_Value.Checked = false;


            bool sessParamDetected = false;
            DataRow[] SessParamRows = dataSet1.Tables["Last_Param_Values"].Select("TransactionID=" + TransactionID.ToString());
            if (SessParamRows.Length > 0)
            {
                foreach (DataRow sessParamRow in SessParamRows)
                {
                    if (sessParamRow["paramName"].ToString() == row.Cells["paramName"].Value.ToString())
                    {
                        sessParamDetected = true;
                        if (cB_Param_Type.SelectedIndex == 2)
                            cB_Param_Value.Checked = bool.Parse(sessParamRow["paramValue"].ToString());
                        else
                            tB_Param_Value.Text = sessParamRow["paramValue"].ToString();
                    }
                    if (sessParamDetected) break;
                }
            }

            if (!sessParamDetected)
                if (cB_Param_Type.SelectedIndex == 2)
                    cB_Param_Value.Checked = bool.Parse(row.Cells["Value"].Value.ToString());
                else
                    tB_Param_Value.Text = row.Cells["Value"].Value.ToString();

            //cB_Param_Important.Checked = (bool)row.Cells["Important"].Value;
            tB_Param_Import.Text = row.Cells["Import"].Value.ToString();
            change_param_status();
            //}

            //if ((bool)row.Cells[5].Value)
            //    groupBox13.Enabled = false;
            //else
            //{
            //    groupBox13.Enabled = true;
            //    set_focus_on_first_param();
            //}

            set_focus_on_first_param();
            paramsNavigate = false;
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 1)
                set_focus_on_first_param();
        }

        private void tSTB_Substitution_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                toolStripLabel3_Click(null, null);
        }

        private void treeView1_ImeModeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("treeView1_ImeModeChanged");
            if (tabControl3.SelectedIndex == 1)
                set_focus_on_first_param();
        }

        private void ttB_Description_TextChanged_1(object sender, EventArgs e)
        {
            Update_Param("Description", ttB_Description.Text, "string");
            treenode_update();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            //sql_Temp_Query.sqlCommandExecute_return_DataSet("SELECT Name FROM Master..sysdatabases");
            sql_Temp_Query.Execute("SELECT Name FROM Master..sysdatabases");
            if (sql_Temp_Query.error)
                MessageBox.Show(sql_Temp_Query.errorMessage);
            else
            {
                bool Database_Added = false;
                DataRow[] dataRows = dataSet1.Tables["Databases"].Select("ServerID=" + ServerID.ToString());
                foreach (DataRow row in sql_Temp_Query.dataSet.Tables[0].Rows)
                {
                    bool Database_Detected = false;
                    foreach (DataRow dataRow in dataRows)
                        if (dataRow["Name"].ToString() == row["Name"].ToString())
                        {
                            Database_Detected = true;
                            break;
                        }
                    if (!Database_Detected)
                    {
                        DataRow newRow = dataSet1.Tables["Databases"].NewRow();
                        newRow["ServerID"] = ServerID;
                        newRow["Name"] = row["Name"];
                        dataSet1.Tables["Databases"].Rows.Add(newRow);
                        Database_Added = true;
                    }
                }
                if (Database_Added)
                    get_databases(ServerID);
            }
        }

        private void сУчшеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openSQLProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showSQLProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dataSetApp.SQL_Projects.Rows)
            {
                MessageBox.Show((string)row["Path"]);
            }
        }

        private void recentProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearUsedSQLProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQL_Project_Path == "")
                dataSetApp.SQL_Projects.Clear();
            else 
                MessageBox.Show("Use only after start application.");
        }

        private void importFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = SQL_Project_Path;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileNames.Length > 0)
            {
                string FullFilename = openFileDialog1.FileNames[0];
                FileInfo fi = new FileInfo(FullFilename);
                //MessageBox.Show(fi.Name);
                toolStripButton2_Click_1(null, null);
                ttB_Description.Text = fi.Name;
                rTB_sqlTransaction.Lines = File.ReadAllLines(FullFilename);
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            //TreeNode node = treeView1.SelectedNode;
            //treeView1.
            //MessageBox.Show(node.Text);
            //if (node == null)
            //    MessageBox.Show("Node don't  selected");
            //else
            //{
            //    treeView1.SelectedNode = node;
                //MessageBox.Show(
            //}
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void lessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.ZoomFactor = (float)(rTB_sqlTransaction.ZoomFactor * 1.1);
            save_zoomFactor();
        }

        private void zoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.ZoomFactor = (float)(rTB_sqlTransaction.ZoomFactor * 0.9);
            save_zoomFactor();
        }

        private void tSCB_DB_Click(object sender, EventArgs e)
        {

        }

        private void tSCB_DB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string NewDatabase = tSCB_DB.Text.Substring(tSCB_DB.Text.IndexOf('.') + 1);
            connectionString=connectionString.Replace(DefaultDatabase,NewDatabase);
            DefaultDatabase = NewDatabase;

            int indexPoint = tSCB_DB.Text.IndexOf('.');
            string sDatabaseID = tSCB_DB.Text.Substring(0, indexPoint);
            foreach(DataRow row in dataSet1.Tables["Databases"].Rows)
            {
                if (row["ID"].ToString() == sDatabaseID)
                    row["Last"] = true;
                else
                    row["Last"] = false;
            }
        }

        private void cB_AutoRun_AfterChangeValue_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("AutoRun_AfterChangeValue", cB_AutoRun_AfterChangeValue.Checked.ToString(), "bool");
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            dGV_Export_Values.Rows.Remove(dGV_Export_Values.CurrentRow);
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            if ((tB_Export_Param.Text == "") || (tB_Import_TransactionID.Text == ""))
            {
                MessageBox.Show("Need ParamName or Import_TransactionID !!!");
                return;
            }
            bool detectExportParam = false;
            DataRow exportRow = null;
            DataRow[] dataRows = dataSet1.Tables["Export_Values"].Select("TransactionID=" + TransactionID.ToString());
            foreach (DataRow row in dataRows)
                if ((row["paramName"].ToString()).ToLower() == tB_Export_Param.Text.ToLower())
                {
                    exportRow = row; detectExportParam = true; break;
                }
            int ExportValueID;
            if (detectExportParam)
            {
                int rowIndex = dataSet1.Tables["Export_Values"].Rows.IndexOf(exportRow);
                dataSet1.Tables["Export_Values"].Rows[rowIndex].BeginEdit();
                dataSet1.Tables["Export_Values"].Rows[rowIndex]["paramName"] = tB_Export_Param.Text;
                dataSet1.Tables["Export_Values"].Rows[rowIndex]["tableIndex"] = int.Parse(nUD_EV_tI.Text);
                dataSet1.Tables["Export_Values"].Rows[rowIndex]["rowIndex"] = int.Parse(nUD_EV_rI.Text);
                dataSet1.Tables["Export_Values"].Rows[rowIndex]["fieldIndex"] = int.Parse(nUD_EV_cI.Text);
                dataSet1.Tables["Export_Values"].Rows[rowIndex].EndEdit();
                ExportValueID = (int)dataSet1.Tables["Export_Values"].Rows[rowIndex]["ID"];
            }
            else
            {
                DataRow row = dataSet1.Tables["Export_Values"].Rows.Add(tB_Export_Param.Text,
                    int.Parse(nUD_EV_tI.Text),
                    int.Parse(nUD_EV_rI.Text),
                    int.Parse(nUD_EV_cI.Text),
                    TransactionID
                    );
                int indexRow = dataSet1.Tables["Export_Values"].Rows.IndexOf(row);
                ExportValueID = (int)dataSet1.Tables["Export_Values"].Rows[indexRow]["ID"];
            }
            DataRow[] rows = dataSet1.Tables["Export_Import"].Select("ExportValueID=" + ExportValueID.ToString() + " AND Import_TransactionID=" + tB_Import_TransactionID.Text);
            if (rows.Length == 0)
            {
                DataRow newExportImportRow = dataSet1.Tables["Export_Import"].NewRow();
                newExportImportRow["ExportValueID"] = ExportValueID;
                newExportImportRow["Import_TransactionID"] = tB_Import_TransactionID.Text;
                dataSet1.Tables["Export_Import"].Rows.Add(newExportImportRow);
            }
            tB_Export_Param.Text = "";
            nUD_EV_tI.Text = "";
            nUD_EV_rI.Text = "";
            nUD_EV_cI.Text = "";
            tB_Import_TransactionID.Text = "";
            Show_transaction_exports(TransactionID);
        }

        private void dGV_Export_Values_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataRow[] dataRows = dataSet1.Tables["Export_Values"].Select("TransactionID=" + TransactionID.ToString());
            if (dataRows.Length > 0)
                MessageBox.Show("Exists:" + dataRows.Length.ToString());
            else
                MessageBox.Show("Not Exists");
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //foreach(DataGridViewRow row in dGV_Import_Values.SelectedRows)
            //{
            //    dGV_Import_Values.Rows.Remove(row);
            //}
        }

        private void dGV_Transaction_Params_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (int)dGV_Transaction_Params.Rows[e.RowIndex].Cells["ID"].Value;
            bool Value;
            //dataSet1.Tables["Transaction_Params"].Rows[rowIndex].BeginEdit();
            DataRow[] dataRows = dataSet1.Tables["Transaction_Params"].Select("ID=" + ID.ToString());
            if (dataRows.Length > 0)
            {
                int rowIndex = dataSet1.Tables["Transaction_Params"].Rows.IndexOf(dataRows[0]);
                dataSet1.Tables["Transaction_Params"].Rows[rowIndex].BeginEdit();
                switch (dGV_Transaction_Params.Columns[e.ColumnIndex].Name)
                {
                    case "UseImport":
                        Value = !(bool)dataRows[0]["UseImport"];
                        dataSet1.Tables["Transaction_Params"].Rows[rowIndex]["UseImport"] = Value;
                        break;
                    case "Important":
                        Value = !(bool)dataRows[0]["Important"];
                        dataSet1.Tables["Transaction_Params"].Rows[rowIndex]["Important"] = Value;
                        break;
                    case "AutoRun_AfterChange":
                        if (dataRows[0]["AutoRun_AfterChange"] == DBNull.Value) 
                            Value = true;
                        else 
                            Value = !(bool)dataRows[0]["AutoRun_AfterChange"];
                        dataSet1.Tables["Transaction_Params"].Rows[rowIndex]["AutoRun_AfterChange"] = Value;
                        break;
                }
                dataSet1.Tables["Transaction_Params"].Rows[rowIndex].EndEdit();
            }
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            SqlTemplates st = new SqlTemplates();
            st.connectionString = connectionString;
            st.ShowDialog();
            if (st.sqlTemplate != "")
            {
                switch (st.InsertIntoPositionInText)
                {
                    case 0:
                        rTB_sqlTransaction.Text = st.sqlTemplate + "\r\n" + rTB_sqlTransaction.Text;
                        break;
                    case 1:
                        break;
                    case 2:
                        rTB_sqlTransaction.Text += "\r\n" + st.sqlTemplate;
                        break;
                }
                
                //rTB_sqlTransaction.Cursor.
                //rTB_sqlTransaction.Text = rTB_sqlTransaction.Text.Insert(Transaction_Text_Pos, " " + st.sqlTemplate + " ");
                //rTB_sqlTransaction.Text.In
                //rTB_sqlTransaction.SelectionStart = Transaction_Text_Pos;
                //rTB_sqlTransaction.Select(Transaction_Text_Pos, 1);
                //rTB_sqlTransaction.Text = rTB_sqlTransaction.Text.Insert(Transaction_Text_Pos, st.sqlTemplate);
            }
            st.Close();
        }

        private void cB_NotSwitchDataSet_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("NotSwitch_ToDataSetResult", cB_NotSwitch_ToDataSetResult.Checked.ToString(), "bool");
        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {
            TransactionNew = true;
            string ParentDB = tB_Use_DB.Text;
            if (ParentDB == "")
                if (tSCB_DB.Text.IndexOf('.') > 0)
                    ParentDB = tSCB_DB.Text.Substring(tSCB_DB.Text.IndexOf('.') + 1);
            string ParentLS = tB_LinkedServer.Text;

            TreeNode newNode = new TreeNode("-- New Transaction --");
            DataRow newRow = dataSet1.Tables["Transactions"].NewRow();
            newRow["Description"] = newNode.Text;
            newRow["ParentID"] = TransactionID;
            dataSet1.Tables["Transactions"].Rows.Add(newRow);

            int rowIndex = dataSet1.Tables["Transactions"].Rows.Count - 1;
            NewTransactionID = (int)dataSet1.Tables["Transactions"].Rows[rowIndex]["ID"];

            Category cat = new Category(NewTransactionID, TransactionID, newNode.Text);
            newNode.Tag = cat;

            TreeNode parentNode;
            parentNode = treeView1.SelectedNode;

            if (parentNode == null)
                treeView1.Nodes.Add(newNode);
            else
                parentNode.Nodes.Add(newNode);

            treeView1.SelectedNode = newNode;
            showTransactionID(NewTransactionID);

            SQL_Project_Path_File = SQL_Project_Path + NewTransactionID.ToString() + ".sql";
            rTB_sqlTransaction.SaveFile(SQL_Project_Path_File, RichTextBoxStreamType.PlainText);

            rTB_sqlTransaction.Text = "";
            tabControl3.SelectedTab = tabPage8;

            TreeViewEventArgs ea = new TreeViewEventArgs(newNode);
            TransactionNew = false;
            treeView1_AfterSelect(sender, ea);
            ttB_Description.Text = newNode.Text;
            tB_Use_DB.Text = ParentDB;
            tB_LinkedServer.Text = ParentLS;

            //Резервное копирование после добавления новой транзакции
            SaveDataSet();
            ttB_Description.SelectAll();
            ttB_Description.Focus();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            toolStripLabel5.Checked = !toolStripLabel5.Checked;
        }

        private void tSTB_Substitution_TextChanged(object sender, EventArgs e)
        {
            if (toolStripLabel5.Checked)
                toolStripLabel3_Click(sender, e);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DataRow row = dataSet1.Tables["ColumnWidths"].NewRow();
            row["TransactionID"] = TransactionID;
            row["tableIndex"] = nUD_CW_tI.Value;
            row["colIndex"] = nUD_CW_cI.Value;
            if (rB_CW_2.Checked)
                row["mode"] = cB_Column_AutoSizeMode.SelectedIndex;
            else
                row["width"] = nUD_CW_W.Value;
            dataSet1.Tables["ColumnWidths"].Rows.Add(row);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            dGV_ColumnWidths.Rows.Remove(dGV_ColumnWidths.CurrentRow);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if ((e.MaximumProgress > 0) && (e.CurrentProgress <= e.MaximumProgress))
                toolStripProgressBar1.Value = (int)((e.CurrentProgress / e.MaximumProgress)*100);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void rB_CW_2_CheckedChanged(object sender, EventArgs e)
        {
            cB_Column_AutoSizeMode.SelectedIndex = 2;
        }

        private void menuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox3.Text == "") { MessageBox.Show("NEED DB..table"); return; }
            if (textBox1.Text == "") { MessageBox.Show("NEED data dump"); return; }
            string cmdInsert = "INSERT " + toolStripTextBox3.Text+" (";
            string cmdValues = ""; bool dataExists = false;
            int rowNumber = -1, colNumber = -1;
            char[] delim = new char[] {'\t'};
            foreach (string line in textBox1.Lines)
            {
                rowNumber++; colNumber = -1;
                cmdValues = " VALUES(";
                dataExists = false;
                string[] fields = line.Split(delim);
                foreach (string field in fields)
                {
                    colNumber++;
                    if (rowNumber == 0)
                    {
                        if (colNumber > 0) cmdInsert +=", ";
                        cmdInsert += "[" + field + "]";
                    }
                    else
                    {
                        if (colNumber > 0) cmdValues +=", ";
                        cmdValues +="'" + field.Replace("'","''") + "'";
                        if (field !="")
                            dataExists = true;
                    }
                }
                if (rowNumber == 0)
                    cmdInsert += ")";
                else
                {
                    if (dataExists)
                    {
                        cmdValues += ")";
                        string sqlCmd = cmdInsert + " " + cmdValues;
                        //MessageBox.Show(sqlCmd);
                        //sql_Temp_Query.sqlCommandExecute_return_NonQuery(sqlCmd);
                        sql_Temp_Query.Execute(sqlCmd);
                        if (sql_Temp_Query.error)
                        {
                            MessageBox.Show("ERROR OF QUERY:\r\n"+sql_Temp_Query.errorMessage);
                            return;
                        }
                    }
                }
            }
            textBox1.Clear();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            toolStripButton17.Checked = !toolStripButton17.Checked;
        }

        private void exportTreeTransactionsToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            if (folderBrowserDialog2.SelectedPath != "")
            {
                MessageBox.Show(folderBrowserDialog2.SelectedPath);
                try
                {
                    tree_walk(folderBrowserDialog2.SelectedPath, treeView1.Nodes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void tree_walk(string path, TreeNodeCollection nodes)
        {
            foreach(TreeNode node in nodes)
            {
                string text = node.Text;
                text = text.Replace('\\', '_'); text = text.Replace('/', '_'); text = text.Replace(':', '_');
                text = text.Replace('*', '_'); text = text.Replace('?', '_'); text = text.Replace('"', '_');
                text = text.Replace('<', '_'); text = text.Replace('>', '_'); text = text.Replace('|', '_');
                string new_path = path + "\\" + text;
                Directory.CreateDirectory(new_path);
                if (node.Nodes != null)
                    tree_walk(new_path, node.Nodes);
            }
        }

        private void dGV_Export_Values_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Show_transaction_Export_Import(int ExportValueID)
        {
            dv_Export_Import = new DataView();
            dv_Export_Import = dataSet1.Tables["Export_Import"].DefaultView;
            dv_Export_Import.RowFilter = "ExportValueID=" + ExportValueID.ToString();
            dGV_Export_Import.DataSource = dv_Export_Import;
        }

        private void dGV_Export_Values_SelectionChanged(object sender, EventArgs e)
        {
            if (dGV_Export_Values.CurrentRow != null)
            {
                int ExportValueID = (int)dGV_Export_Values.CurrentRow.Cells["ID"].Value;
                Show_transaction_Export_Import(ExportValueID);
            }
            else
                dGV_Export_Import.DataSource = null;
        }

        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(null, null);
        }


        private void cB_SessionAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("SessionAutoRun", cB_SessionAutoRun.Checked.ToString(), "bool");
        }


        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            string firstLine = tB_DumpValues.Lines[0];
            char[] tabDelim;
            switch (toolStripComboBox1.Text.Trim().ToLower())
            {
                case "tab":
                    tabDelim = new char[] { '\t' };
                    break;
                case "space":
                    tabDelim = new char[] { ' ' };
                    break;
                default:
                    tabDelim = new char[] { '\t' };
                    break;
            }

            
            string[] dumpColumns = firstLine.Split(tabDelim);

            dumpValues = new DataTable("Dump_Values");
            int colN = 0;
            foreach (string col in dumpColumns)
            {
                DataColumn column = new DataColumn("col"+(colN++).ToString());
                dumpValues.Columns.Add(column);
            }
            foreach (string line in tB_DumpValues.Lines)
            {
                dumpColumns = line.Split(tabDelim);
                dumpValues.Rows.Add(dumpColumns);
            }

            FileName_DumpValues_Schema = SQL_Project_Path + TransactionID.ToString() + "dvs.xml";
            FileName_DumpValues = SQL_Project_Path + TransactionID.ToString() + "dv.xml";

            dumpValues.WriteXmlSchema(FileName_DumpValues_Schema);
            dumpValues.WriteXml(FileName_DumpValues);

            tB_DumpValues.Text = "";

            dGV_Dump_Values.DataSource = dumpValues;
            tabControl12.SelectedTab = tabPage28;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rB_SessionValues_CheckedChanged(object sender, EventArgs e)
        {
            if (NodeClick) return;
            Update_Param("UseLastValues", tSB_UseLastValues.Checked.ToString(), "bool");
            tabControl11.SelectedTab = tabPage25;
        }

        private void rB_ImportValues_CheckedChanged(object sender, EventArgs e)
        {
            if (NodeClick) return;
            Update_Param("UseImportValues", tSB_UseImportValues.Checked.ToString(), "bool");
            tabControl11.SelectedTab = tabPage26;
        }

        private void rB_DumpValues_CheckedChanged(object sender, EventArgs e)
        {
            if (NodeClick) return;
            Update_Param("UseDumpValues", tSB_UseDumpValues.Checked.ToString(), "bool");
            tabControl11.SelectedTab = tabPage27;
        }

        private void tSTB_Substitution_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            listBox1.Items.Add("webBrowser1_Navigated");
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            listBox1.Items.Add("webBrowser1_Navigating");
        }

        private void moveNode1ToNode2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.Caption = "Move Node To New Parent Node. Enter parent node Number:";
            ib.ShowDialog();
            if (ib.Value != "")
            {
                DataRow[] rows = dataSet1.Tables["Transactions"].Select("ID="+TransactionID.ToString());
                if (rows.Length == 1)
                    rows[0]["ParentID"] = int.Parse(ib.Value);
            }
            ib.Close();
        }

        private void sortOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox_NumericUpDown ib = new InputBox_NumericUpDown();
            ib.Caption = "Enter SortOrder Number:";
            ib.ShowDialog();
            if (ib.Value != -1)
            {
                DataRow[] rows = dataSet1.Tables["Transactions"].Select("ID=" + TransactionID.ToString());
                if (rows.Length == 1)
                    rows[0]["SortOrder"] = ib.Value;
            }
            ib.Close();
        }

        private void updateTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dataSet1.Tables["Transactions"].Rows)
                row["ZoomFactor"] = 1.5;
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            toolStripButton19.Checked = !toolStripButton19.Checked;
        }

        private void cB_DataSet_Text_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cB_FirstRow_Field_Value_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cB_XML_Column_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("XmlColumn", cB_XML_Column.Checked.ToString(), "bool");
        }

        private void cB_Trees_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("Trees", cB_Trees.Checked.ToString(), "bool");
        }

        private void cB_Tree_Expand_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("TreeExpand", cB_Tree_Expand.Checked.ToString(), "bool");
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.ZoomFactor = rTB_sqlTransaction.ZoomFactor + (float)0.1;
            save_zoomFactor();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.ZoomFactor = rTB_sqlTransaction.ZoomFactor - (float)0.1;
            save_zoomFactor();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("SessionAutoRun_AfterChangeValue", cB_SessionAutoRun.Checked.ToString(), "bool");
        }

        private void cB_AutoRun_AfterChangeValue_CheckStateChanged(object sender, EventArgs e)
        {
            if (cB_AutoRun_AfterChangeValue.Checked)
                cB_AutoRun_AfterChangeValue.BackColor = Color.Fuchsia;
            else
                cB_AutoRun_AfterChangeValue.BackColor = SystemColors.Control;
        }

        private void cB_AutoRun_CheckStateChanged(object sender, EventArgs e)
        {
            if (cB_AutoRun.Checked)
                cB_AutoRun.BackColor = Color.Fuchsia;
            else
                cB_AutoRun.BackColor = SystemColors.Control;
        }

        private void cB_SessionAutoRun_CheckStateChanged(object sender, EventArgs e)
        {
            if (cB_SessionAutoRun.Checked)
                cB_SessionAutoRun.BackColor = Color.Fuchsia;
            else
                cB_SessionAutoRun.BackColor = SystemColors.Control;
        }

        private void cB_SessionAutoRun_AfterChangeValue_CheckStateChanged(object sender, EventArgs e)
        {
            if (cB_SessionAutoRun_AfterChangeValue.Checked)
                cB_SessionAutoRun_AfterChangeValue.BackColor = Color.Fuchsia;
            else
                cB_SessionAutoRun_AfterChangeValue.BackColor = SystemColors.Control;
        }

        private void cB_Servers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tB_PartOfTableName_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (tB_Param_Value.Visible)
            {
                tB_Param_Value.SelectAll();
                tB_Param_Value.Focus();
            }
            if (tSTB_Substitution.Visible)
            {
                tSTB_Substitution.SelectAll();
                tSTB_Substitution.Focus();
            }
        }

        private void timer_AfterSelect_Tick(object sender, EventArgs e)
        {
            timer_AfterSelect.Enabled = false;
            if (tB_Param_Value.Visible)
            {
                tB_Param_Value.SelectAll();
                tB_Param_Value.Focus();
            }
        }

        private void cB_BackFromResult_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("BackFromResult", cB_BackFromResult.Checked.ToString(), "bool");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Update_Param("BackFromResultAfterSeconds", nUD_BackFromResultAfterSeconds.Value.ToString(), "int");
            BackFromResultAfterSeconds = (int)nUD_BackFromResultAfterSeconds.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tB_Output_Schema.Text != "")
                tB_Output_Schema.Text += ",";
            tB_Output_Schema.Text += "T";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tB_Output_Schema.Text != "")
                tB_Output_Schema.Text += ",";
            tB_Output_Schema.Text += "L";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tB_Output_Schema.Text = "";
        }

        private void cB_Output_Schema_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("Output", cB_Output_Schema.Checked.ToString(), "bool");
        }

        private void tB_Output_Schema_TextChanged(object sender, EventArgs e)
        {
            Update_Param("Output_Schema", tB_Output_Schema.Text, "string");
        }

        private void cB_Output_ByVertical_CheckedChanged(object sender, EventArgs e)
        {
            Update_Param("Output_ByVertical", cB_Output_ByVertical.Checked.ToString(), "bool");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char[] delim = new char[]{','};
            string[] TableOrientation = tB_Output_Schema.Text.Split(delim);
            MessageBox.Show(TableOrientation.Length.ToString());
            MessageBox.Show(tB_Output_Schema.Text + "\n\r" + TableOrientation.ToString());

        }

        private void tSTB_URL_Click(object sender, EventArgs e)
        {

        }

        private void tSTB_URL_TextChanged(object sender, EventArgs e)
        {
            tSTB_Substitution.SelectAll();
            tSTB_Substitution.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            button9_Click(null, null);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                textBox4.SelectAll();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") && (textBox4.Text == ""))
                return;

            string resultString = "";
            string resultColumn = "";
            char[] delim = null;
            string[] items = null;
            if (radioButton2.Checked) //From Column
            {
                delim = new char[1] { '\n' };
                items = textBox2.Text.Split(delim);
            }
            else //From String
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        delim = new char[1] { ',' };
                        break;
                    case 1:
                        delim = new char[1] { '\t' };
                        break;
                }
                items = textBox4.Text.Split(delim);
            }
            //------------------
            if (items.Length > 0)
            {
                foreach (string item in items)
                    if (item.Trim() != "")
                    {
                        if (resultString != "")
                            switch (comboBox2.SelectedIndex)
                            {
                                case 0: resultString += ",";
                                    break;
                                case 1: resultString += "\t";
                                    break;
                            }
                        resultString += item;
                        if (resultColumn != "") resultColumn += "\r\n";
                        resultColumn += item;
                    }

                resultString = resultString.Replace("\r", "");
                resultString = resultString.Replace("\n", "");
                if (checkBox3.Checked)
                {
                    textBox5.Text = resultString;
                    textBox5.SelectAll();
                    if (checkBox5.Checked)
                        textBox5.Focus();
                }
                if (checkBox4.Checked)
                {
                    textBox3.Text = resultColumn;
                    textBox3.SelectAll();
                    if (checkBox5.Checked)
                        textBox3.Focus();
                }
            }
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.ZoomFactor = rTB_sqlTransaction.ZoomFactor - (float)0.1;
            save_zoomFactor();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            rTB_sqlTransaction.ZoomFactor = rTB_sqlTransaction.ZoomFactor + (float)0.1;
            save_zoomFactor();
        }

        private void aDDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void aDDChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem17_Click_1(sender, e);
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            //Get List Of tables From SQl Connection
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void cB_ListOfFields_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nUD_EV_tI_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tB_Export_Param_TextChanged(object sender, EventArgs e)
        {

        }

        private void nUD_EV_rI_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nUD_EV_cI_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tB_Import_TransactionID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tB_AfterRunTransID_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
                textBox5.Text = "";
            else
                button9_Click(null, null);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked)
                textBox3.Text = "";
            else
                button9_Click(null, null);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button9_Click(null, null);
        }

        private void tabPage12_Enter(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                button9_Click(null, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                button9_Click(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") || (textBox4.Text != ""))
                button9_Click(null, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") || (textBox4.Text != ""))
                button9_Click(null, null);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
                if ((textBox2.Text != "") || (textBox4.Text != ""))
                    button9_Click(null, null);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.SelectAll();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (button6.Text == "Value:")
            {
                button6.Text = "Add:";
                button6.BackColor = Color.Lime;
            }
            else
            {
                button6.Text = "Value:";
                button6.BackColor = Color.SkyBlue;
            }
        }

        private void tB_Param_Value_TextChanged(object sender, EventArgs e)
        {
            //STOP
            textBox2_TextChanged(null, null);
            if (button6.Text == "Add:")
            {
                bool detected = false;
                string Value = tB_Param_Value.Text.Trim();
                foreach (string item in tB_Param_Value.Items)
                    if (item == Value)
                    {
                        detected = true;
                        break;
                    }
                if (!detected)
                {
                    tB_Param_Value.Items.Add(Value);
                    DataRow row = dataSet1.Tables["Transaction_Values"].NewRow();
                    row["TransactionID"] = TransactionID;
                    row["Value"] = Value;
                    dataSet1.Tables["Transaction_Values"].Rows.Add(row);
                }
            }
        }

        private void tB_Param_Value_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tB_Param_Value_MouseUp_1(object sender, MouseEventArgs e)
        {
            tB_Param_Value.SelectAll();
        }

        private void cB_AfterRun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NodeClick) return;
            switch (cB_AfterRun.SelectedIndex)
            {
                case 0:
                    Update_Param("AfterRunToTransID", "0", "int");
                    break;
                case 1:
                    Update_Param("AfterRunToTransID", "-1", "int");
                    break;
                case 2:
                    Update_Param("AfterRunToTransID", tB_AfterRunTransID.ToString(), "int");
                    break;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            Auto_ReRun.Checked = !Auto_ReRun.Checked;
            toolStripButton20.Checked = !toolStripButton20.Checked;
            Auto_ReRun_Count = 0;
            if (toolStripButton20.Checked)
            {
                toolStripLabel9.Text = "RUNNING !!!";
                toolStripLabel9.BackColor = Color.Fuchsia;
            }
            else
            {
                toolStripLabel9.Text = "#";
                toolStripLabel9.BackColor = Color.Silver;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            connect();
            if ((!connected_1)&&(!connected_2))
                timer2.Enabled = true;

        }

        private void connect()
        {
            listBox3.Items.Insert(0, "-----------------------------------------");
            listBox3.Items.Insert(0, "TRYING Connection ...");
            listBox3.Refresh();

            if (!connected_1)
            {
                sql_Temp_Query = new Sql(connectionString, true);

                //sql_Temp_Query.sqlCommandExecute_return_DataSet("SELECT TOP 10 * FROM bot_sources (nolock)");
                sql_Temp_Query.Execute("SELECT TOP 10 * FROM bot_sources (nolock)");
                if (sql_Temp_Query.error)
                {
                    listBox3.Items.Insert(0, "-----------------------------------------");
                    string Item = sql_Temp_Query.errorMessage;
                    listBox3.Items.Insert(0, Item);
                }
                else
                {
                    connected_1 = true;
                    listBox3.Items.Insert(0, "-----------------------------------------");
                    string Item = "CONNETED _ 1 !!!";
                    listBox3.Items.Insert(0, Item);
                    //MessageBox.Show("CONNETED !!!");
                    //-----------------------------------------------------------------
                }
            }


            if (connected_1)
            {
                sql_Transaction_Tree = new Sql(connectionString, true);
                //sql_Transaction_Tree.sqlCommandExecute_return_DataSet("SELECT TOP 10 * FROM bot_sources (nolock)");
                sql_Transaction_Tree.Execute("SELECT TOP 10 * FROM bot_sources (nolock)");
                if (sql_Transaction_Tree.error)
                {
                    listBox3.Items.Insert(0, "-----------------------------------------");
                    string Item = sql_Transaction_Tree.errorMessage;
                    listBox3.Items.Insert(0, Item);
                }
                else
                {
                    connected_2 = true;
                    listBox3.Items.Insert(0, "-----------------------------------------");
                    string Item = "CONNETED _ 2 !!!";
                    listBox3.Items.Insert(0, Item);
                    MessageBox.Show("CONNETED !!!");
                    //-----------------------------------------------------------------
                }
            }
        }

        private void sHOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Servers fs = new Form_Servers();
            fs.ShowDialog();
            fs.Close();
        }
    }

    public class Table_TreeView
    {
        public void Load_Table_To_TreeView(DataTable dt, TreeView _TreeView, TreeNode ParentNode = null, string Field_ID = "ID", string Field_ParentID = "ParentID", string Field_Name = "Name")
        {
            try
            {
                if (_TreeView == null)
                    return;
                if ((_TreeView == null) && (ParentNode == null))
                    return;

                if (Field_ID == null) Field_ID = "ID";
                if (Field_ParentID == null) Field_ParentID = "ParentID";
                if (Field_Name == null) Field_Name = "Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
                return;
            }

            try
            {
                DataRow[] rows = dt.Select(Field_ParentID + "=" + (ParentNode == null ? "0" : ParentNode.Tag.ToString()));
                foreach (DataRow row in rows)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = row[Field_ID].ToString();
                    node.Text = row[Field_Name].ToString();
                    if (ParentNode == null)
                        _TreeView.Nodes.Add(node);
                    else
                        ParentNode.Nodes.Add(node);
                    Load_Table_To_TreeView(dt, _TreeView, node, Field_ID, Field_ParentID, Field_Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

    }

    public class Util
    {
        public string sr_YYYYMMDD = DateTime.Today.ToString("yyyyMMdd"); //{YYYYMMDD}
        public string sr_MMDDYYYY = DateTime.Today.ToString("MMddyyyy"); //{MMDDYYYY}
        public string sr_DDMMYYYY = DateTime.Today.ToString("ddMMyyyy"); //{DDMMYYYY}

        public string sr_YYMMDD = DateTime.Today.ToString("yyMMdd"); //{YYMMDD}
        public string sr_MMDDYY = DateTime.Today.ToString("MMddyy"); //{MMDDYY}
        public string sr_DDMMYY = DateTime.Today.ToString("ddMMyy"); //{DDMMYY}

        public string sr_YYYYMM = DateTime.Today.ToString("yyyyMM"); //{YYYYMM}
        public string sr_YYMM = DateTime.Today.ToString("yyMM");    //{YYMM}

        public string sr_MMdd = DateTime.Today.ToString("MMdd");        //{MM}

        public string sr_MM = DateTime.Today.ToString("MM");        //{MM}
        public string sr_DD = DateTime.Today.ToString("dd");        //{DD}
        public string sr_YYYY = DateTime.Today.ToString("yyyy");    //{YYYY}
        public string sr_YY = DateTime.Today.ToString("yy");        //{YY}

        public string sr_QUOTE = "\"";
        public string sr_AMP = "&";
        public string sr_LESS = "<";
        public string sr_MORE = ">";
        public string sr_APO = "'";

        public Util()
        {
        }

        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public string clear_value(string s)
        {
            string value = s;
            value = value.Replace("&rsquo;", "'");
            value = value.Replace("'", "''");
            value = value.Replace("&amp;", "&");
            MatchCollection mc = Regex.Matches(value, ".*?(?<Clear>[<].*?[>]).*?");
            if (mc.Count > 0)
                foreach (Match mv in mc)
                {
                    string clearSubStr = mv.Groups["Clear"].Value;
                    value = value.Replace(clearSubStr, "");
                }
            return value;
        }

        public string replace_place_to_value(string str)
        {
            str = str.Replace("{QUOTE}", sr_QUOTE);
            str = str.Replace("{AMP}", sr_AMP);
            str = str.Replace("{APO}", sr_APO);
            str = str.Replace("{LESS}", sr_LESS);
            str = str.Replace("{MORE}", sr_MORE);

            str = str.Replace("{Q}", sr_QUOTE);
            str = str.Replace("{A}", sr_AMP);
            str = str.Replace("{P}", sr_APO);
            str = str.Replace("{L}", sr_LESS);
            str = str.Replace("{M}", sr_MORE);

            str = change_date_mask(str);
            return str;
        }

        public string change_date_mask(string str)
        {
            str = str.Replace("{YYYYMMDD}", sr_YYYYMMDD);
            str = str.Replace("{MMDDYYYY}", sr_MMDDYYYY);
            str = str.Replace("{DDMMYYYY}", sr_DDMMYYYY);

            str = str.Replace("{YYMMDD}", sr_YYMMDD);
            str = str.Replace("{MMDDYY}", sr_MMDDYY);
            str = str.Replace("{DDMMYY}", sr_DDMMYY);

            str = str.Replace("{YYYYMM}", sr_YYYYMM);
            str = str.Replace("{YYMM}", sr_YYMM);

            str = str.Replace("{MMDD}", sr_MMdd);

            str = str.Replace("{MM}", sr_MM);
            str = str.Replace("{DD}", sr_DD);
            str = str.Replace("{YYYY}", sr_YYYY);
            str = str.Replace("{YY}", sr_YY);
            return str;
        }

        public string full_time()
        {
            string result = "";
            DateTime time1 = DateTime.Now;
            int Year, Month, Day, Hour, Minute, Second, Millisecond;
            Year = time1.Year; result += Year.ToString(); result += "-";
            Month = time1.Month; if (Month < 10) result += "0"; result += Month.ToString(); result += "-";
            Day = time1.Day; if (Day < 10) result += "0"; result += Day.ToString(); result += " ";
            Hour = time1.Hour; if (Hour < 10) result += "0"; result += Hour.ToString(); result += ":";
            Minute = time1.Minute; if (Minute < 10) result += "0"; result += Minute.ToString(); result += ":";
            Second = time1.Second; if (Second < 10) result += "0"; result += Second.ToString(); result += ":";
            Millisecond = time1.Millisecond;
            if (Millisecond < 10) result += "0";
            if (Millisecond < 100) result += "0";
            result += Millisecond.ToString();
            return result;
        }
    }

}
