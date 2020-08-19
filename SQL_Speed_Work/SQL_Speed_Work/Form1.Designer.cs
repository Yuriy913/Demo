using System;
using System.Windows;
using System.Windows.Forms;

namespace SQL_Speed_Work
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_TransactionID = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_Error = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pos_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pos_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSQLProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showSQLProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.сУчшеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Auto_ReRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tSTB_Auto_ReRun_Count = new System.Windows.Forms.ToolStripTextBox();
            this.saveAndRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveParamsAndTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTreeToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.disableAutoRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showTransactionIDInNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countColumnsInGridsForDataSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.clearUsedSQLProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.exportTreeTransactionsToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sHOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Use_LinkedServer = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkedServer_Name = new System.Windows.Forms.ToolStripTextBox();
            this.dataSetViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.Rows_Count = new System.Windows.Forms.ToolStripTextBox();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tSCB_Srv = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripButton();
            this.tSCB_DB = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tSCB_LinkedServers = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.rTB_sqlTransaction = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripButton();
            this.ttB_Description = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.cB_Use_DB = new System.Windows.Forms.ToolStripButton();
            this.tB_Use_DB = new System.Windows.Forms.ToolStripTextBox();
            this.cB_Use_LinkedServer = new System.Windows.Forms.ToolStripButton();
            this.tB_LinkedServer = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton21 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton22 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.tabControl11 = new System.Windows.Forms.TabControl();
            this.tabPage25 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dGV_Session_Values = new System.Windows.Forms.DataGridView();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.tabPage26 = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.dGV_Import_Values = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.tabPage27 = new System.Windows.Forms.TabPage();
            this.tabControl12 = new System.Windows.Forms.TabControl();
            this.tabPage28 = new System.Windows.Forms.TabPage();
            this.dGV_Dump_Values = new System.Windows.Forms.DataGridView();
            this.tabPage29 = new System.Windows.Forms.TabPage();
            this.tB_DumpValues = new System.Windows.Forms.TextBox();
            this.toolStrip10 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tSB_UseDumpValues = new System.Windows.Forms.RadioButton();
            this.tSB_UseImportValues = new System.Windows.Forms.RadioButton();
            this.tSB_UseLastValues = new System.Windows.Forms.RadioButton();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.dGV_Transaction_Params = new System.Windows.Forms.DataGridView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cB_DelphiChartType = new System.Windows.Forms.ComboBox();
            this.cB_DelphiChart = new System.Windows.Forms.CheckBox();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.cB_ChartType = new System.Windows.Forms.ComboBox();
            this.cB_Chart = new System.Windows.Forms.CheckBox();
            this.tabPage32 = new System.Windows.Forms.TabPage();
            this.cB_Tree_Expand = new System.Windows.Forms.CheckBox();
            this.cB_Trees = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tB_Param_Value = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tB_Param_Import = new System.Windows.Forms.TextBox();
            this.cB_Param_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cB_Param_Value = new System.Windows.Forms.CheckBox();
            this.tB_Param_Name = new System.Windows.Forms.TextBox();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl10 = new System.Windows.Forms.TabControl();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.tB_Param_DB = new System.Windows.Forms.TextBox();
            this.tB_Param_Srv = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabControl9 = new System.Windows.Forms.TabControl();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.cB_SessionAutoRun_AfterChangeValue = new System.Windows.Forms.CheckBox();
            this.cB_SessionAutoRun = new System.Windows.Forms.CheckBox();
            this.cB_AutoRun_AfterChangeValue = new System.Windows.Forms.CheckBox();
            this.cB_AutoRun = new System.Windows.Forms.CheckBox();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.nUD_BackFromResultAfterSeconds = new System.Windows.Forms.NumericUpDown();
            this.cB_BackFromResult = new System.Windows.Forms.CheckBox();
            this.cB_NotSwitch_ToDataSetResult = new System.Windows.Forms.CheckBox();
            this.nUD_DataSetOutNumber = new System.Windows.Forms.NumericUpDown();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.cB_XML_Column = new System.Windows.Forms.CheckBox();
            this.cB_ListOfFields = new System.Windows.Forms.CheckBox();
            this.cB_FirstRow_Field_Value = new System.Windows.Forms.CheckBox();
            this.cB_DataSet_Text = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.cB_Output_ByVertical = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tB_Output_Schema = new System.Windows.Forms.TextBox();
            this.cB_Output_Schema = new System.Windows.Forms.CheckBox();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.dGV_Export_Values = new System.Windows.Forms.DataGridView();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.dGV_Export_Import = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tB_Import_TransactionID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nUD_EV_cI = new System.Windows.Forms.NumericUpDown();
            this.nUD_EV_rI = new System.Windows.Forms.NumericUpDown();
            this.nUD_EV_tI = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tB_Export_Param = new System.Windows.Forms.TextBox();
            this.tabPage23 = new System.Windows.Forms.TabPage();
            this.dGV_ColumnWidths = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cB_Column_AutoSizeMode = new System.Windows.Forms.ComboBox();
            this.rB_CW_2 = new System.Windows.Forms.RadioButton();
            this.rB_CW_1 = new System.Windows.Forms.RadioButton();
            this.nUD_CW_W = new System.Windows.Forms.NumericUpDown();
            this.nUD_CW_cI = new System.Windows.Forms.NumericUpDown();
            this.nUD_CW_tI = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.tabPage34 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cB_AfterRun = new System.Windows.Forms.ComboBox();
            this.tB_AfterRunTransID = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tDB_TransactionUpdateAndRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_TransactionUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tSL_RunResult = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
            this.aDDChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.moveNode1ToNode2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.sortOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl8 = new System.Windows.Forms.TabControl();
            this.tabPage_DataSet1 = new System.Windows.Forms.TabPage();
            this.tabPage_DataSet2 = new System.Windows.Forms.TabPage();
            this.tabPage_DataSet3 = new System.Windows.Forms.TabPage();
            this.tabPage_Table0_TabedText = new System.Windows.Forms.TabPage();
            this.rTB_DataSet_Text = new System.Windows.Forms.RichTextBox();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.rTB_XML_Column = new System.Windows.Forms.RichTextBox();
            this.tabPage33 = new System.Windows.Forms.TabPage();
            this.rTB_XML_Column_Adjusted = new System.Windows.Forms.RichTextBox();
            this.tP_Charts = new System.Windows.Forms.TabPage();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tP_Chart_C = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tB_Trees = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip9 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.rTB_Errors = new System.Windows.Forms.RichTextBox();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.rTB_SQL = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rTB_SQL_Preview = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl7 = new System.Windows.Forms.TabControl();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.tB_NavigateHistory = new System.Windows.Forms.TextBox();
            this.tabPage24 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage30 = new System.Windows.Forms.TabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSTB_URL = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripButton();
            this.tSTB_Substitution = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage35 = new System.Windows.Forms.TabPage();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.tabControl13 = new System.Windows.Forms.TabControl();
            this.tabPage36 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage37 = new System.Windows.Forms.TabPage();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button37 = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.bindingSource_Servers = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet101 = new DataSchema.DataSet101();
            this.timer_Highlight = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer_AfterSelect = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabControl11.SuspendLayout();
            this.tabPage25.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Session_Values)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.tabPage26.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Import_Values)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabPage27.SuspendLayout();
            this.tabControl12.SuspendLayout();
            this.tabPage28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Dump_Values)).BeginInit();
            this.tabPage29.SuspendLayout();
            this.toolStrip10.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Transaction_Params)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.tabPage32.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.tabControl10.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.tabControl9.SuspendLayout();
            this.tabPage20.SuspendLayout();
            this.tabPage18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_BackFromResultAfterSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_DataSetOutNumber)).BeginInit();
            this.tabPage19.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Export_Values)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Export_Import)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_EV_cI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_EV_rI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_EV_tI)).BeginInit();
            this.toolStrip7.SuspendLayout();
            this.tabPage23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_ColumnWidths)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CW_W)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CW_cI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CW_tI)).BeginInit();
            this.toolStrip8.SuspendLayout();
            this.tabPage34.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl8.SuspendLayout();
            this.tabPage_Table0_TabedText.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabPage33.SuspendLayout();
            this.tP_Charts.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tP_Chart_C.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.toolStrip9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl7.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.tabPage24.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage35.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.tabControl13.SuspendLayout();
            this.tabPage36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage37.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Servers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet101)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tSSL_TransactionID,
            this.tSSL_Error,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.Pos_X,
            this.toolStripStatusLabel6,
            this.Pos_Y,
            this.toolStripStatusLabel8});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1323, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel1.Text = "Transaction:Actions";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel2.Text = "TransactionID:";
            // 
            // tSSL_TransactionID
            // 
            this.tSSL_TransactionID.ForeColor = System.Drawing.Color.White;
            this.tSSL_TransactionID.Name = "tSSL_TransactionID";
            this.tSSL_TransactionID.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSL_Error
            // 
            this.tSSL_Error.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSL_Error.ForeColor = System.Drawing.Color.Red;
            this.tSSL_Error.Name = "tSSL_Error";
            this.tSSL_Error.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel3.Text = "Pos:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel4.Text = "X:";
            // 
            // Pos_X
            // 
            this.Pos_X.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Pos_X.Name = "Pos_X";
            this.Pos_X.Size = new System.Drawing.Size(13, 17);
            this.Pos_X.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel6.Text = "Y:";
            // 
            // Pos_Y
            // 
            this.Pos_Y.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Pos_Y.Name = "Pos_Y";
            this.Pos_Y.Size = new System.Drawing.Size(13, 17);
            this.Pos_Y.Text = "0";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(4, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sQLTreeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.chartToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.dataSetViewToolStripMenuItem,
            this.toolStripMenuItem14});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1323, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSQLProjectToolStripMenuItem1,
            this.showSQLProjectsToolStripMenuItem,
            this.recentProjectsToolStripMenuItem,
            this.toolStripSeparator6,
            this.сУчшеToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSQLProjectToolStripMenuItem1
            // 
            this.openSQLProjectToolStripMenuItem1.Name = "openSQLProjectToolStripMenuItem1";
            this.openSQLProjectToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.openSQLProjectToolStripMenuItem1.Text = "Open SQL Project";
            this.openSQLProjectToolStripMenuItem1.Click += new System.EventHandler(this.openSQLProjectToolStripMenuItem1_Click);
            // 
            // showSQLProjectsToolStripMenuItem
            // 
            this.showSQLProjectsToolStripMenuItem.Name = "showSQLProjectsToolStripMenuItem";
            this.showSQLProjectsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.showSQLProjectsToolStripMenuItem.Text = "Show SQL Projects";
            this.showSQLProjectsToolStripMenuItem.Click += new System.EventHandler(this.showSQLProjectsToolStripMenuItem_Click);
            // 
            // recentProjectsToolStripMenuItem
            // 
            this.recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
            this.recentProjectsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.recentProjectsToolStripMenuItem.Text = "Recent Projects";
            this.recentProjectsToolStripMenuItem.Click += new System.EventHandler(this.recentProjectsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(169, 6);
            // 
            // сУчшеToolStripMenuItem
            // 
            this.сУчшеToolStripMenuItem.Name = "сУчшеToolStripMenuItem";
            this.сУчшеToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.сУчшеToolStripMenuItem.Text = "Exit";
            this.сУчшеToolStripMenuItem.Click += new System.EventHandler(this.сУчшеToolStripMenuItem_Click);
            // 
            // sQLTreeToolStripMenuItem
            // 
            this.sQLTreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17,
            this.toolStripSeparator18,
            this.runToolStripMenuItem,
            this.Auto_ReRun,
            this.saveAndRunToolStripMenuItem,
            this.previewToolStripMenuItem,
            this.toolStripSeparator10,
            this.saveToolStripMenuItem,
            this.saveParamsAndTransactionToolStripMenuItem,
            this.toolStripSeparator8,
            this.saveTreeToXmlToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator7,
            this.disableAutoRunToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.sQLTreeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.sQLTreeToolStripMenuItem.Name = "sQLTreeToolStripMenuItem";
            this.sQLTreeToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.sQLTreeToolStripMenuItem.Text = "SQL Transaction";
            this.sQLTreeToolStripMenuItem.Click += new System.EventHandler(this.sQLTreeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem17.Size = new System.Drawing.Size(298, 22);
            this.toolStripMenuItem17.Text = "New";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click_1);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(295, 6);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click_1);
            // 
            // Auto_ReRun
            // 
            this.Auto_ReRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSTB_Auto_ReRun_Count});
            this.Auto_ReRun.Name = "Auto_ReRun";
            this.Auto_ReRun.Size = new System.Drawing.Size(298, 22);
            this.Auto_ReRun.Text = "Auto ReRun";
            this.Auto_ReRun.Click += new System.EventHandler(this.Auto_ReRun_Click);
            // 
            // tSTB_Auto_ReRun_Count
            // 
            this.tSTB_Auto_ReRun_Count.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tSTB_Auto_ReRun_Count.Name = "tSTB_Auto_ReRun_Count";
            this.tSTB_Auto_ReRun_Count.Size = new System.Drawing.Size(100, 23);
            this.tSTB_Auto_ReRun_Count.Text = "5";
            // 
            // saveAndRunToolStripMenuItem
            // 
            this.saveAndRunToolStripMenuItem.Name = "saveAndRunToolStripMenuItem";
            this.saveAndRunToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.saveAndRunToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.saveAndRunToolStripMenuItem.Text = "Save and Run";
            this.saveAndRunToolStripMenuItem.Click += new System.EventHandler(this.saveAndRunToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F5)));
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(295, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveParamsAndTransactionToolStripMenuItem
            // 
            this.saveParamsAndTransactionToolStripMenuItem.Name = "saveParamsAndTransactionToolStripMenuItem";
            this.saveParamsAndTransactionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveParamsAndTransactionToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.saveParamsAndTransactionToolStripMenuItem.Text = "Save Params and Transaction";
            this.saveParamsAndTransactionToolStripMenuItem.Click += new System.EventHandler(this.saveParamsAndTransactionToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(295, 6);
            // 
            // saveTreeToXmlToolStripMenuItem
            // 
            this.saveTreeToXmlToolStripMenuItem.Name = "saveTreeToXmlToolStripMenuItem";
            this.saveTreeToXmlToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.saveTreeToXmlToolStripMenuItem.Text = "Save Tree To Xml";
            this.saveTreeToXmlToolStripMenuItem.Click += new System.EventHandler(this.saveTreeToXmlToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.refreshToolStripMenuItem.Text = "Refresh Tree";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(295, 6);
            // 
            // disableAutoRunToolStripMenuItem
            // 
            this.disableAutoRunToolStripMenuItem.Name = "disableAutoRunToolStripMenuItem";
            this.disableAutoRunToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.disableAutoRunToolStripMenuItem.Text = "Disable AutoRun";
            this.disableAutoRunToolStripMenuItem.Click += new System.EventHandler(this.disableAutoRunToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(295, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTransactionIDInNodesToolStripMenuItem,
            this.countColumnsInGridsForDataSetToolStripMenuItem,
            this.clearUsedSQLProjectsToolStripMenuItem,
            this.toolStripSeparator23,
            this.exportTreeTransactionsToFolderToolStripMenuItem,
            this.toolStripSeparator24});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem1.Text = "Tools";
            // 
            // showTransactionIDInNodesToolStripMenuItem
            // 
            this.showTransactionIDInNodesToolStripMenuItem.Name = "showTransactionIDInNodesToolStripMenuItem";
            this.showTransactionIDInNodesToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.showTransactionIDInNodesToolStripMenuItem.Text = "Show TransactionID in nodes";
            this.showTransactionIDInNodesToolStripMenuItem.Click += new System.EventHandler(this.showTransactionIDInNodesToolStripMenuItem_Click);
            // 
            // countColumnsInGridsForDataSetToolStripMenuItem
            // 
            this.countColumnsInGridsForDataSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.countColumnsInGridsForDataSetToolStripMenuItem.Name = "countColumnsInGridsForDataSetToolStripMenuItem";
            this.countColumnsInGridsForDataSetToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.countColumnsInGridsForDataSetToolStripMenuItem.Text = "Count Columns in Grids For DataSet";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Text = "2";
            // 
            // clearUsedSQLProjectsToolStripMenuItem
            // 
            this.clearUsedSQLProjectsToolStripMenuItem.Name = "clearUsedSQLProjectsToolStripMenuItem";
            this.clearUsedSQLProjectsToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.clearUsedSQLProjectsToolStripMenuItem.Text = "Clear Used SQL Projects ";
            this.clearUsedSQLProjectsToolStripMenuItem.Click += new System.EventHandler(this.clearUsedSQLProjectsToolStripMenuItem_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(261, 6);
            // 
            // exportTreeTransactionsToFolderToolStripMenuItem
            // 
            this.exportTreeTransactionsToFolderToolStripMenuItem.Name = "exportTreeTransactionsToFolderToolStripMenuItem";
            this.exportTreeTransactionsToFolderToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.exportTreeTransactionsToFolderToolStripMenuItem.Text = "Export Tree Transactions To Folder";
            this.exportTreeTransactionsToFolderToolStripMenuItem.Click += new System.EventHandler(this.exportTreeTransactionsToFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(261, 6);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem4,
            this.toolStripSeparator12,
            this.clearToolStripMenuItem1,
            this.toolStripSeparator11,
            this.exportToFileToolStripMenuItem});
            this.chartToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // addToolStripMenuItem4
            // 
            this.addToolStripMenuItem4.Name = "addToolStripMenuItem4";
            this.addToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem4.Text = "Add";
            this.addToolStripMenuItem4.Click += new System.EventHandler(this.addToolStripMenuItem4_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(177, 6);
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem1.Text = "C Clear";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(177, 6);
            // 
            // exportToFileToolStripMenuItem
            // 
            this.exportToFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11});
            this.exportToFileToolStripMenuItem.Enabled = false;
            this.exportToFileToolStripMenuItem.Name = "exportToFileToolStripMenuItem";
            this.exportToFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToFileToolStripMenuItem.Text = "Export To File";
            this.exportToFileToolStripMenuItem.Click += new System.EventHandler(this.exportToFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem11.Text = "*.BMP";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sHOWToolStripMenuItem,
            this.addToolStripMenuItem3,
            this.deleteToolStripMenuItem,
            this.Use_LinkedServer});
            this.serverToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // sHOWToolStripMenuItem
            // 
            this.sHOWToolStripMenuItem.Name = "sHOWToolStripMenuItem";
            this.sHOWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sHOWToolStripMenuItem.Text = "SHOW";
            this.sHOWToolStripMenuItem.Click += new System.EventHandler(this.sHOWToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem3
            // 
            this.addToolStripMenuItem3.Name = "addToolStripMenuItem3";
            this.addToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem3.Text = "Add";
            this.addToolStripMenuItem3.Click += new System.EventHandler(this.addToolStripMenuItem3_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // Use_LinkedServer
            // 
            this.Use_LinkedServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LinkedServer_Name});
            this.Use_LinkedServer.Name = "Use_LinkedServer";
            this.Use_LinkedServer.Size = new System.Drawing.Size(180, 22);
            this.Use_LinkedServer.Text = "Use Linked Server";
            this.Use_LinkedServer.Click += new System.EventHandler(this.useLinkServerToolStripMenuItem_Click);
            // 
            // LinkedServer_Name
            // 
            this.LinkedServer_Name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkedServer_Name.Name = "LinkedServer_Name";
            this.LinkedServer_Name.Size = new System.Drawing.Size(100, 23);
            this.LinkedServer_Name.Text = "GOOD";
            // 
            // dataSetViewToolStripMenuItem
            // 
            this.dataSetViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem13});
            this.dataSetViewToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dataSetViewToolStripMenuItem.Name = "dataSetViewToolStripMenuItem";
            this.dataSetViewToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.dataSetViewToolStripMenuItem.Text = "DataSet View";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Rows_Count,
            this.allToolStripMenuItem});
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem12.Text = "Rows";
            // 
            // Rows_Count
            // 
            this.Rows_Count.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Rows_Count.Name = "Rows_Count";
            this.Rows_Count.Size = new System.Drawing.Size(100, 23);
            this.Rows_Count.Text = "10";
            this.Rows_Count.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allToolStripMenuItem.Text = "All";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widthToolStripMenuItem});
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem13.Text = "Columns";
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byDataToolStripMenuItem});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // byDataToolStripMenuItem
            // 
            this.byDataToolStripMenuItem.Enabled = false;
            this.byDataToolStripMenuItem.Name = "byDataToolStripMenuItem";
            this.byDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.byDataToolStripMenuItem.Text = "By Data";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.updateTransactionsToolStripMenuItem});
            this.toolStripMenuItem14.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem14.Text = "Debug";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.debugToolStripMenuItem.Text = "Load Params From SQL";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // updateTransactionsToolStripMenuItem
            // 
            this.updateTransactionsToolStripMenuItem.Name = "updateTransactionsToolStripMenuItem";
            this.updateTransactionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.updateTransactionsToolStripMenuItem.Text = "Update Transactions";
            this.updateTransactionsToolStripMenuItem.Click += new System.EventHandler(this.updateTransactionsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tSCB_Srv,
            this.toolStripLabel2,
            this.tSCB_DB,
            this.toolStripButton4,
            this.tSCB_LinkedServers,
            this.toolStripSeparator17,
            this.toolStripButton20,
            this.toolStripSeparator30,
            this.toolStripLabel9,
            this.toolStripSeparator31});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1323, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel1.Text = "Servers:";
            // 
            // tSCB_Srv
            // 
            this.tSCB_Srv.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tSCB_Srv.MaxDropDownItems = 20;
            this.tSCB_Srv.Name = "tSCB_Srv";
            this.tSCB_Srv.Size = new System.Drawing.Size(250, 25);
            this.tSCB_Srv.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.tSCB_Srv.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel2.Text = "Databases:";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // tSCB_DB
            // 
            this.tSCB_DB.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tSCB_DB.MaxDropDownItems = 20;
            this.tSCB_DB.Name = "tSCB_DB";
            this.tSCB_DB.Size = new System.Drawing.Size(121, 25);
            this.tSCB_DB.SelectedIndexChanged += new System.EventHandler(this.tSCB_DB_SelectedIndexChanged);
            this.tSCB_DB.Click += new System.EventHandler(this.tSCB_DB_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(89, 22);
            this.toolStripButton4.Text = "Linked Servers:";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click_2);
            // 
            // tSCB_LinkedServers
            // 
            this.tSCB_LinkedServers.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tSCB_LinkedServers.MaxDropDownItems = 20;
            this.tSCB_LinkedServers.Name = "tSCB_LinkedServers";
            this.tSCB_LinkedServers.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton20
            // 
            this.toolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton20.ForeColor = System.Drawing.Color.White;
            this.toolStripButton20.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton20.Image")));
            this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton20.Name = "toolStripButton20";
            this.toolStripButton20.Size = new System.Drawing.Size(74, 22);
            this.toolStripButton20.Text = "Auto ReRun";
            this.toolStripButton20.Click += new System.EventHandler(this.toolStripButton20_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel9.Image")));
            this.toolStripLabel9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(23, 22);
            this.toolStripLabel9.Text = "#";
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(6, 25);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tP_Charts);
            this.tabControl2.Controls.Add(this.tB_Trees);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Controls.Add(this.tabPage35);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 49);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1323, 533);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.splitter1);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1315, 507);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Query Tree and Transaction Scripts";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl3);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(313, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 501);
            this.panel1.TabIndex = 2;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 25);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(999, 476);
            this.tabControl3.TabIndex = 1;
            this.tabControl3.SelectedIndexChanged += new System.EventHandler(this.tabControl3_SelectedIndexChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.rTB_sqlTransaction);
            this.tabPage8.Controls.Add(this.toolStrip6);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(991, 450);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "sqlTransaction and Description";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // rTB_sqlTransaction
            // 
            this.rTB_sqlTransaction.AutoWordSelection = true;
            this.rTB_sqlTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_sqlTransaction.ContextMenuStrip = this.contextMenuStrip3;
            this.rTB_sqlTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_sqlTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rTB_sqlTransaction.ForeColor = System.Drawing.Color.White;
            this.rTB_sqlTransaction.HideSelection = false;
            this.rTB_sqlTransaction.Location = new System.Drawing.Point(3, 35);
            this.rTB_sqlTransaction.Name = "rTB_sqlTransaction";
            this.rTB_sqlTransaction.Size = new System.Drawing.Size(985, 412);
            this.rTB_sqlTransaction.TabIndex = 11;
            this.rTB_sqlTransaction.Text = "";
            this.rTB_sqlTransaction.WordWrap = false;
            this.rTB_sqlTransaction.ZoomFactor = 1.5F;
            this.rTB_sqlTransaction.TextChanged += new System.EventHandler(this.rTB_sqlTransaction_TextChanged_1);
            this.rTB_sqlTransaction.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rTB_sqlTransaction_KeyUp);
            this.rTB_sqlTransaction.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rTB_sqlTransaction_MouseUp);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.zoomToolStripMenuItem1});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(118, 48);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zoomToolStripMenuItem.Text = "Zoom +";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem1
            // 
            this.zoomToolStripMenuItem1.Name = "zoomToolStripMenuItem1";
            this.zoomToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.zoomToolStripMenuItem1.Text = "Zoom -";
            this.zoomToolStripMenuItem1.Click += new System.EventHandler(this.zoomToolStripMenuItem1_Click);
            // 
            // toolStrip6
            // 
            this.toolStrip6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.ttB_Description,
            this.toolStripSeparator16,
            this.cB_Use_DB,
            this.tB_Use_DB,
            this.cB_Use_LinkedServer,
            this.tB_LinkedServer,
            this.toolStripSeparator28,
            this.toolStripLabel10,
            this.toolStripSplitButton3,
            this.toolStripSeparator29,
            this.toolStripButton21,
            this.toolStripSeparator32,
            this.toolStripButton22,
            this.toolStripSeparator33});
            this.toolStrip6.Location = new System.Drawing.Point(3, 3);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(985, 32);
            this.toolStrip6.TabIndex = 10;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(23, 29);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.Click += new System.EventHandler(this.toolStripSplitButton1_Click);
            // 
            // ttB_Description
            // 
            this.ttB_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ttB_Description.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ttB_Description.Name = "ttB_Description";
            this.ttB_Description.Size = new System.Drawing.Size(400, 32);
            this.ttB_Description.TextChanged += new System.EventHandler(this.ttB_Description_TextChanged_1);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 32);
            // 
            // cB_Use_DB
            // 
            this.cB_Use_DB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cB_Use_DB.ForeColor = System.Drawing.Color.White;
            this.cB_Use_DB.Image = ((System.Drawing.Image)(resources.GetObject("cB_Use_DB.Image")));
            this.cB_Use_DB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cB_Use_DB.Name = "cB_Use_DB";
            this.cB_Use_DB.Size = new System.Drawing.Size(48, 29);
            this.cB_Use_DB.Text = "UseDB:";
            this.cB_Use_DB.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // tB_Use_DB
            // 
            this.tB_Use_DB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Use_DB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tB_Use_DB.Name = "tB_Use_DB";
            this.tB_Use_DB.Size = new System.Drawing.Size(100, 32);
            this.tB_Use_DB.Click += new System.EventHandler(this.toolStripTextBox4_Click);
            this.tB_Use_DB.TextChanged += new System.EventHandler(this.toolStripTextBox4_TextChanged);
            // 
            // cB_Use_LinkedServer
            // 
            this.cB_Use_LinkedServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cB_Use_LinkedServer.ForeColor = System.Drawing.Color.White;
            this.cB_Use_LinkedServer.Image = ((System.Drawing.Image)(resources.GetObject("cB_Use_LinkedServer.Image")));
            this.cB_Use_LinkedServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cB_Use_LinkedServer.Name = "cB_Use_LinkedServer";
            this.cB_Use_LinkedServer.Size = new System.Drawing.Size(45, 29);
            this.cB_Use_LinkedServer.Text = "UseLS:";
            this.cB_Use_LinkedServer.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // tB_LinkedServer
            // 
            this.tB_LinkedServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_LinkedServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tB_LinkedServer.Name = "tB_LinkedServer";
            this.tB_LinkedServer.Size = new System.Drawing.Size(100, 32);
            this.tB_LinkedServer.Click += new System.EventHandler(this.toolStripTextBox5_Click);
            this.tB_LinkedServer.TextChanged += new System.EventHandler(this.toolStripTextBox5_TextChanged);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(42, 29);
            this.toolStripLabel10.Text = "Zoom:";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem19,
            this.toolStripMenuItem20});
            this.toolStripSplitButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripSplitButton3.Text = "0";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem19.Text = "+0.1";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.toolStripMenuItem19_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem20.Text = "-0.1";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.toolStripMenuItem20_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton21
            // 
            this.toolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton21.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStripButton21.ForeColor = System.Drawing.Color.White;
            this.toolStripButton21.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton21.Image")));
            this.toolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton21.Name = "toolStripButton21";
            this.toolStripButton21.Size = new System.Drawing.Size(24, 29);
            this.toolStripButton21.Text = "-";
            this.toolStripButton21.Click += new System.EventHandler(this.toolStripButton21_Click);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton22
            // 
            this.toolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton22.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStripButton22.ForeColor = System.Drawing.Color.White;
            this.toolStripButton22.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton22.Image")));
            this.toolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton22.Name = "toolStripButton22";
            this.toolStripButton22.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton22.Text = "+";
            this.toolStripButton22.Click += new System.EventHandler(this.toolStripButton22_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 32);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel8);
            this.tabPage9.Controls.Add(this.splitter2);
            this.tabPage9.Controls.Add(this.splitter3);
            this.tabPage9.Controls.Add(this.groupBox12);
            this.tabPage9.Controls.Add(this.tabControl10);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(991, 450);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Parameters";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.splitter4);
            this.panel8.Controls.Add(this.groupBox19);
            this.panel8.Controls.Add(this.groupBox17);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(213, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(775, 335);
            this.panel8.TabIndex = 56;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(0, 160);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(775, 3);
            this.splitter4.TabIndex = 53;
            this.splitter4.TabStop = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.tabControl11);
            this.groupBox19.Controls.Add(this.panel7);
            this.groupBox19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox19.Location = new System.Drawing.Point(0, 160);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(775, 175);
            this.groupBox19.TabIndex = 52;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Session and Import Values";
            // 
            // tabControl11
            // 
            this.tabControl11.Controls.Add(this.tabPage25);
            this.tabControl11.Controls.Add(this.tabPage26);
            this.tabControl11.Controls.Add(this.tabPage27);
            this.tabControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl11.Location = new System.Drawing.Point(107, 16);
            this.tabControl11.Name = "tabControl11";
            this.tabControl11.SelectedIndex = 0;
            this.tabControl11.Size = new System.Drawing.Size(665, 156);
            this.tabControl11.TabIndex = 13;
            // 
            // tabPage25
            // 
            this.tabPage25.Controls.Add(this.groupBox10);
            this.tabPage25.Location = new System.Drawing.Point(4, 22);
            this.tabPage25.Name = "tabPage25";
            this.tabPage25.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage25.Size = new System.Drawing.Size(657, 130);
            this.tabPage25.TabIndex = 0;
            this.tabPage25.Text = "Session Values";
            this.tabPage25.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dGV_Session_Values);
            this.groupBox10.Controls.Add(this.toolStrip5);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(651, 124);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Session Values";
            // 
            // dGV_Session_Values
            // 
            this.dGV_Session_Values.AllowUserToAddRows = false;
            this.dGV_Session_Values.AllowUserToResizeRows = false;
            this.dGV_Session_Values.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dGV_Session_Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Session_Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Session_Values.Location = new System.Drawing.Point(3, 41);
            this.dGV_Session_Values.Name = "dGV_Session_Values";
            this.dGV_Session_Values.RowTemplate.Height = 24;
            this.dGV_Session_Values.Size = new System.Drawing.Size(645, 80);
            this.dGV_Session_Values.TabIndex = 6;
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripSeparator14,
            this.toolStripButton6});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(645, 25);
            this.toolStrip5.TabIndex = 0;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton5.Text = "Clear";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(28, 22);
            this.toolStripButton6.Text = "Del";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // tabPage26
            // 
            this.tabPage26.Controls.Add(this.groupBox21);
            this.tabPage26.Location = new System.Drawing.Point(4, 22);
            this.tabPage26.Name = "tabPage26";
            this.tabPage26.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage26.Size = new System.Drawing.Size(657, 130);
            this.tabPage26.TabIndex = 1;
            this.tabPage26.Text = "Import Values";
            this.tabPage26.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.dGV_Import_Values);
            this.groupBox21.Controls.Add(this.toolStrip3);
            this.groupBox21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox21.Location = new System.Drawing.Point(3, 3);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(651, 124);
            this.groupBox21.TabIndex = 11;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Import Values";
            // 
            // dGV_Import_Values
            // 
            this.dGV_Import_Values.AllowUserToAddRows = false;
            this.dGV_Import_Values.AllowUserToDeleteRows = false;
            this.dGV_Import_Values.AllowUserToResizeRows = false;
            this.dGV_Import_Values.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_Import_Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Import_Values.ContextMenuStrip = this.contextMenuStrip1;
            this.dGV_Import_Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Import_Values.Location = new System.Drawing.Point(3, 41);
            this.dGV_Import_Values.Name = "dGV_Import_Values";
            this.dGV_Import_Values.ReadOnly = true;
            this.dGV_Import_Values.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dGV_Import_Values.RowTemplate.Height = 24;
            this.dGV_Import_Values.Size = new System.Drawing.Size(645, 80);
            this.dGV_Import_Values.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton9});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(645, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Enabled = false;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(28, 22);
            this.toolStripButton9.Text = "Del";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // tabPage27
            // 
            this.tabPage27.Controls.Add(this.tabControl12);
            this.tabPage27.Location = new System.Drawing.Point(4, 22);
            this.tabPage27.Name = "tabPage27";
            this.tabPage27.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage27.Size = new System.Drawing.Size(657, 130);
            this.tabPage27.TabIndex = 2;
            this.tabPage27.Text = "Dump Values";
            this.tabPage27.UseVisualStyleBackColor = true;
            // 
            // tabControl12
            // 
            this.tabControl12.Controls.Add(this.tabPage28);
            this.tabControl12.Controls.Add(this.tabPage29);
            this.tabControl12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl12.Location = new System.Drawing.Point(3, 3);
            this.tabControl12.Name = "tabControl12";
            this.tabControl12.SelectedIndex = 0;
            this.tabControl12.Size = new System.Drawing.Size(651, 124);
            this.tabControl12.TabIndex = 0;
            // 
            // tabPage28
            // 
            this.tabPage28.Controls.Add(this.dGV_Dump_Values);
            this.tabPage28.Location = new System.Drawing.Point(4, 22);
            this.tabPage28.Name = "tabPage28";
            this.tabPage28.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage28.Size = new System.Drawing.Size(643, 98);
            this.tabPage28.TabIndex = 0;
            this.tabPage28.Text = "Dump Values";
            this.tabPage28.UseVisualStyleBackColor = true;
            // 
            // dGV_Dump_Values
            // 
            this.dGV_Dump_Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Dump_Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Dump_Values.Location = new System.Drawing.Point(3, 3);
            this.dGV_Dump_Values.Name = "dGV_Dump_Values";
            this.dGV_Dump_Values.RowTemplate.Height = 24;
            this.dGV_Dump_Values.Size = new System.Drawing.Size(637, 92);
            this.dGV_Dump_Values.TabIndex = 0;
            // 
            // tabPage29
            // 
            this.tabPage29.Controls.Add(this.tB_DumpValues);
            this.tabPage29.Controls.Add(this.toolStrip10);
            this.tabPage29.Location = new System.Drawing.Point(4, 22);
            this.tabPage29.Name = "tabPage29";
            this.tabPage29.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage29.Size = new System.Drawing.Size(643, 98);
            this.tabPage29.TabIndex = 1;
            this.tabPage29.Text = "Load Tabbed Text Dump";
            this.tabPage29.UseVisualStyleBackColor = true;
            // 
            // tB_DumpValues
            // 
            this.tB_DumpValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tB_DumpValues.Location = new System.Drawing.Point(3, 28);
            this.tB_DumpValues.Multiline = true;
            this.tB_DumpValues.Name = "tB_DumpValues";
            this.tB_DumpValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tB_DumpValues.Size = new System.Drawing.Size(637, 67);
            this.tB_DumpValues.TabIndex = 1;
            this.tB_DumpValues.WordWrap = false;
            // 
            // toolStrip10
            // 
            this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel8,
            this.toolStripComboBox1,
            this.toolStripSeparator13,
            this.toolStripButton18,
            this.toolStripSeparator15});
            this.toolStrip10.Location = new System.Drawing.Point(3, 3);
            this.toolStrip10.Name = "toolStrip10";
            this.toolStrip10.Size = new System.Drawing.Size(637, 25);
            this.toolStrip10.TabIndex = 0;
            this.toolStrip10.Text = "toolStrip10";
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel8.Text = "Col Delim:";
            this.toolStripLabel8.Click += new System.EventHandler(this.toolStripLabel8_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "TAB",
            "SPACE"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox1.Text = "TAB";
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click_1);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton18.Text = "Load";
            this.toolStripButton18.Click += new System.EventHandler(this.toolStripButton18_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.tSB_UseDumpValues);
            this.panel7.Controls.Add(this.tSB_UseImportValues);
            this.panel7.Controls.Add(this.tSB_UseLastValues);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(3, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(104, 156);
            this.panel7.TabIndex = 12;
            // 
            // tSB_UseDumpValues
            // 
            this.tSB_UseDumpValues.AutoSize = true;
            this.tSB_UseDumpValues.Location = new System.Drawing.Point(5, 50);
            this.tSB_UseDumpValues.Name = "tSB_UseDumpValues";
            this.tSB_UseDumpValues.Size = new System.Drawing.Size(88, 17);
            this.tSB_UseDumpValues.TabIndex = 5;
            this.tSB_UseDumpValues.Text = "Dump Values";
            this.tSB_UseDumpValues.UseVisualStyleBackColor = true;
            this.tSB_UseDumpValues.CheckedChanged += new System.EventHandler(this.rB_DumpValues_CheckedChanged);
            // 
            // tSB_UseImportValues
            // 
            this.tSB_UseImportValues.AutoSize = true;
            this.tSB_UseImportValues.Location = new System.Drawing.Point(4, 27);
            this.tSB_UseImportValues.Name = "tSB_UseImportValues";
            this.tSB_UseImportValues.Size = new System.Drawing.Size(89, 17);
            this.tSB_UseImportValues.TabIndex = 4;
            this.tSB_UseImportValues.Text = "Import Values";
            this.tSB_UseImportValues.UseVisualStyleBackColor = true;
            this.tSB_UseImportValues.CheckedChanged += new System.EventHandler(this.rB_ImportValues_CheckedChanged);
            // 
            // tSB_UseLastValues
            // 
            this.tSB_UseLastValues.AutoSize = true;
            this.tSB_UseLastValues.Checked = true;
            this.tSB_UseLastValues.Location = new System.Drawing.Point(3, 3);
            this.tSB_UseLastValues.Name = "tSB_UseLastValues";
            this.tSB_UseLastValues.Size = new System.Drawing.Size(97, 17);
            this.tSB_UseLastValues.TabIndex = 3;
            this.tSB_UseLastValues.TabStop = true;
            this.tSB_UseLastValues.Text = "Session Values";
            this.tSB_UseLastValues.UseVisualStyleBackColor = true;
            this.tSB_UseLastValues.CheckedChanged += new System.EventHandler(this.rB_SessionValues_CheckedChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.dGV_Transaction_Params);
            this.groupBox17.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox17.Location = new System.Drawing.Point(0, 0);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(775, 160);
            this.groupBox17.TabIndex = 44;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Parameters";
            // 
            // dGV_Transaction_Params
            // 
            this.dGV_Transaction_Params.AllowUserToAddRows = false;
            this.dGV_Transaction_Params.AllowUserToDeleteRows = false;
            this.dGV_Transaction_Params.AllowUserToResizeRows = false;
            this.dGV_Transaction_Params.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dGV_Transaction_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Transaction_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Transaction_Params.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dGV_Transaction_Params.Location = new System.Drawing.Point(3, 16);
            this.dGV_Transaction_Params.MultiSelect = false;
            this.dGV_Transaction_Params.Name = "dGV_Transaction_Params";
            this.dGV_Transaction_Params.RowTemplate.Height = 24;
            this.dGV_Transaction_Params.Size = new System.Drawing.Size(769, 141);
            this.dGV_Transaction_Params.TabIndex = 0;
            this.dGV_Transaction_Params.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Transaction_Params_CellContentClick);
            this.dGV_Transaction_Params.SelectionChanged += new System.EventHandler(this.dGV_Transaction_Params_SelectionChanged);
            this.dGV_Transaction_Params.Click += new System.EventHandler(this.dGV_Transaction_Params_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(210, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 335);
            this.splitter2.TabIndex = 55;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(210, 338);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(778, 3);
            this.splitter3.TabIndex = 54;
            this.splitter3.TabStop = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.groupBox14);
            this.groupBox12.Controls.Add(this.groupBox11);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox12.Location = new System.Drawing.Point(3, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox12.Size = new System.Drawing.Size(207, 338);
            this.groupBox12.TabIndex = 42;
            this.groupBox12.TabStop = false;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.tabControl1);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox14.Location = new System.Drawing.Point(3, 160);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(201, 98);
            this.groupBox14.TabIndex = 43;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Charts/Trees";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage15);
            this.tabControl1.Controls.Add(this.tabPage32);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(195, 79);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cB_DelphiChartType);
            this.tabPage5.Controls.Add(this.cB_DelphiChart);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(187, 53);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Delphi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cB_DelphiChartType
            // 
            this.cB_DelphiChartType.FormattingEnabled = true;
            this.cB_DelphiChartType.Items.AddRange(new object[] {
            "0.Line",
            "1.Point",
            "2.Gantt",
            "3.Bar",
            "4.Pie",
            "5.Arrow",
            "6.Horiz.Bar",
            "7.Fast Line",
            "8.Bubble",
            "9.Area",
            "10.Shape"});
            this.cB_DelphiChartType.Location = new System.Drawing.Point(57, 4);
            this.cB_DelphiChartType.Name = "cB_DelphiChartType";
            this.cB_DelphiChartType.Size = new System.Drawing.Size(87, 21);
            this.cB_DelphiChartType.TabIndex = 1;
            this.cB_DelphiChartType.Text = "0.Line";
            this.cB_DelphiChartType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_3);
            // 
            // cB_DelphiChart
            // 
            this.cB_DelphiChart.AutoSize = true;
            this.cB_DelphiChart.Location = new System.Drawing.Point(6, 6);
            this.cB_DelphiChart.Name = "cB_DelphiChart";
            this.cB_DelphiChart.Size = new System.Drawing.Size(45, 17);
            this.cB_DelphiChart.TabIndex = 0;
            this.cB_DelphiChart.Text = "Use";
            this.cB_DelphiChart.UseVisualStyleBackColor = true;
            this.cB_DelphiChart.CheckedChanged += new System.EventHandler(this.cB_DelphiChart_CheckedChanged);
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.cB_ChartType);
            this.tabPage15.Controls.Add(this.cB_Chart);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(187, 53);
            this.tabPage15.TabIndex = 1;
            this.tabPage15.Text = "C#";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // cB_ChartType
            // 
            this.cB_ChartType.FormattingEnabled = true;
            this.cB_ChartType.Items.AddRange(new object[] {
            "0.Point",
            "1.FastPoint",
            "2.Bubble",
            "3.Line",
            "4.Spline",
            "5.StepLine",
            "6.FastLine",
            "7.Bar",
            "8.StackedBar",
            "9.StackedBar100",
            "10.Column",
            "11.StackedColumn",
            "12.StackedColumn100",
            "13.Area",
            "14.SplineArea",
            "15.StackedArea",
            "16.StackedArea100",
            "17.Pie",
            "18.Doughnut",
            "19.Stock",
            "20.Candlestick",
            "21.Range",
            "22.SplineRange",
            "23.RangeBar",
            "24.RangeColumn",
            "25.Radar",
            "26.Polar",
            "27.ErrorBar",
            "28.BoxPlot",
            "29.Renko",
            "30.ThreeLineBreak",
            "31.Kagi",
            "32.PointAndFigure",
            "33.Funnel",
            "34.Pyramid",
            "35.ThreeLineBreak"});
            this.cB_ChartType.Location = new System.Drawing.Point(57, 4);
            this.cB_ChartType.Name = "cB_ChartType";
            this.cB_ChartType.Size = new System.Drawing.Size(90, 21);
            this.cB_ChartType.TabIndex = 23;
            this.cB_ChartType.Text = "3.Line";
            this.cB_ChartType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_2);
            // 
            // cB_Chart
            // 
            this.cB_Chart.AutoSize = true;
            this.cB_Chart.Location = new System.Drawing.Point(6, 6);
            this.cB_Chart.Name = "cB_Chart";
            this.cB_Chart.Size = new System.Drawing.Size(45, 17);
            this.cB_Chart.TabIndex = 22;
            this.cB_Chart.Text = "Use";
            this.cB_Chart.UseVisualStyleBackColor = true;
            this.cB_Chart.CheckedChanged += new System.EventHandler(this.cB_Chart_CheckedChanged);
            // 
            // tabPage32
            // 
            this.tabPage32.Controls.Add(this.cB_Tree_Expand);
            this.tabPage32.Controls.Add(this.cB_Trees);
            this.tabPage32.Location = new System.Drawing.Point(4, 22);
            this.tabPage32.Name = "tabPage32";
            this.tabPage32.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage32.Size = new System.Drawing.Size(187, 53);
            this.tabPage32.TabIndex = 2;
            this.tabPage32.Text = "Trees";
            this.tabPage32.UseVisualStyleBackColor = true;
            // 
            // cB_Tree_Expand
            // 
            this.cB_Tree_Expand.AutoSize = true;
            this.cB_Tree_Expand.Checked = true;
            this.cB_Tree_Expand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_Tree_Expand.Location = new System.Drawing.Point(6, 28);
            this.cB_Tree_Expand.Name = "cB_Tree_Expand";
            this.cB_Tree_Expand.Size = new System.Drawing.Size(62, 17);
            this.cB_Tree_Expand.TabIndex = 2;
            this.cB_Tree_Expand.Text = "Expand";
            this.cB_Tree_Expand.UseVisualStyleBackColor = true;
            this.cB_Tree_Expand.CheckedChanged += new System.EventHandler(this.cB_Tree_Expand_CheckedChanged);
            // 
            // cB_Trees
            // 
            this.cB_Trees.AutoSize = true;
            this.cB_Trees.Location = new System.Drawing.Point(6, 6);
            this.cB_Trees.Name = "cB_Trees";
            this.cB_Trees.Size = new System.Drawing.Size(45, 17);
            this.cB_Trees.TabIndex = 0;
            this.cB_Trees.Text = "Use";
            this.cB_Trees.UseVisualStyleBackColor = true;
            this.cB_Trees.CheckedChanged += new System.EventHandler(this.cB_Trees_CheckedChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.groupBox13);
            this.groupBox11.Controls.Add(this.menuStrip4);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox11.Location = new System.Drawing.Point(3, 13);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox11.Size = new System.Drawing.Size(201, 147);
            this.groupBox11.TabIndex = 41;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Param Attributes";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.checkBox1);
            this.groupBox13.Controls.Add(this.button6);
            this.groupBox13.Controls.Add(this.tB_Param_Value);
            this.groupBox13.Controls.Add(this.button7);
            this.groupBox13.Controls.Add(this.button1);
            this.groupBox13.Controls.Add(this.tB_Param_Import);
            this.groupBox13.Controls.Add(this.cB_Param_Type);
            this.groupBox13.Controls.Add(this.label3);
            this.groupBox13.Controls.Add(this.cB_Param_Value);
            this.groupBox13.Controls.Add(this.tB_Param_Name);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.Location = new System.Drawing.Point(3, 13);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(195, 107);
            this.groupBox13.TabIndex = 46;
            this.groupBox13.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(5, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 17);
            this.checkBox1.TabIndex = 53;
            this.checkBox1.Text = "comma";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.SkyBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(2, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 23);
            this.button6.TabIndex = 52;
            this.button6.Text = "Value:";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // tB_Param_Value
            // 
            this.tB_Param_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Param_Value.FormattingEnabled = true;
            this.tB_Param_Value.Location = new System.Drawing.Point(72, 11);
            this.tB_Param_Value.Name = "tB_Param_Value";
            this.tB_Param_Value.Size = new System.Drawing.Size(119, 21);
            this.tB_Param_Value.TabIndex = 51;
            this.tB_Param_Value.SelectedIndexChanged += new System.EventHandler(this.tB_Param_Value_SelectedIndexChanged);
            this.tB_Param_Value.TextChanged += new System.EventHandler(this.tB_Param_Value_TextChanged);
            this.tB_Param_Value.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tB_Param_Value_MouseUp_1);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(3, 80);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 22);
            this.button7.TabIndex = 50;
            this.button7.Text = "Import:";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_2);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(2, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Name:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // tB_Param_Import
            // 
            this.tB_Param_Import.Location = new System.Drawing.Point(52, 81);
            this.tB_Param_Import.Name = "tB_Param_Import";
            this.tB_Param_Import.Size = new System.Drawing.Size(139, 20);
            this.tB_Param_Import.TabIndex = 48;
            this.tB_Param_Import.TextChanged += new System.EventHandler(this.tB_Param_Import_TextChanged);
            // 
            // cB_Param_Type
            // 
            this.cB_Param_Type.FormattingEnabled = true;
            this.cB_Param_Type.Items.AddRange(new object[] {
            "0.As Number",
            "1.As String",
            "2.As Bit"});
            this.cB_Param_Type.Location = new System.Drawing.Point(103, 35);
            this.cB_Param_Type.Name = "cB_Param_Type";
            this.cB_Param_Type.Size = new System.Drawing.Size(88, 21);
            this.cB_Param_Type.TabIndex = 33;
            this.cB_Param_Type.Text = "0.As Number";
            this.cB_Param_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            this.cB_Param_Type.VisibleChanged += new System.EventHandler(this.cB_Param_Type_VisibleChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Type:";
            // 
            // cB_Param_Value
            // 
            this.cB_Param_Value.AutoSize = true;
            this.cB_Param_Value.Enabled = false;
            this.cB_Param_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cB_Param_Value.Location = new System.Drawing.Point(54, 14);
            this.cB_Param_Value.Name = "cB_Param_Value";
            this.cB_Param_Value.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cB_Param_Value.Size = new System.Drawing.Size(15, 14);
            this.cB_Param_Value.TabIndex = 44;
            this.cB_Param_Value.UseVisualStyleBackColor = true;
            this.cB_Param_Value.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_2);
            // 
            // tB_Param_Name
            // 
            this.tB_Param_Name.Location = new System.Drawing.Point(53, 57);
            this.tB_Param_Name.Name = "tB_Param_Name";
            this.tB_Param_Name.ReadOnly = true;
            this.tB_Param_Name.Size = new System.Drawing.Size(138, 20);
            this.tB_Param_Name.TabIndex = 36;
            this.tB_Param_Name.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.tB_Param_Name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tB_Param_Name_MouseUp);
            // 
            // menuStrip4
            // 
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.addToolStripMenuItem1,
            this.updToolStripMenuItem,
            this.toolStripMenuItem10});
            this.menuStrip4.Location = new System.Drawing.Point(3, 120);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(195, 24);
            this.menuStrip4.TabIndex = 43;
            this.menuStrip4.Text = "menuStrip4";
            this.menuStrip4.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip4_ItemClicked);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Enabled = false;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Enabled = false;
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // updToolStripMenuItem
            // 
            this.updToolStripMenuItem.Enabled = false;
            this.updToolStripMenuItem.Name = "updToolStripMenuItem";
            this.updToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.updToolStripMenuItem.Text = "Upd";
            this.updToolStripMenuItem.Click += new System.EventHandler(this.updToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem10.Text = "Del>";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // tabControl10
            // 
            this.tabControl10.Controls.Add(this.tabPage21);
            this.tabControl10.Controls.Add(this.tabPage22);
            this.tabControl10.Controls.Add(this.tabPage23);
            this.tabControl10.Controls.Add(this.tabPage34);
            this.tabControl10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl10.Location = new System.Drawing.Point(3, 341);
            this.tabControl10.Name = "tabControl10";
            this.tabControl10.SelectedIndex = 0;
            this.tabControl10.Size = new System.Drawing.Size(985, 106);
            this.tabControl10.TabIndex = 53;
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.groupBox16);
            this.tabPage21.Controls.Add(this.tabControl9);
            this.tabPage21.Location = new System.Drawing.Point(4, 22);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage21.Size = new System.Drawing.Size(977, 80);
            this.tabPage21.TabIndex = 0;
            this.tabPage21.Text = "DataSet";
            this.tabPage21.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.tB_Param_DB);
            this.groupBox16.Controls.Add(this.tB_Param_Srv);
            this.groupBox16.Controls.Add(this.checkBox2);
            this.groupBox16.Location = new System.Drawing.Point(356, 3);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(87, 72);
            this.groupBox16.TabIndex = 48;
            this.groupBox16.TabStop = false;
            // 
            // tB_Param_DB
            // 
            this.tB_Param_DB.Enabled = false;
            this.tB_Param_DB.Location = new System.Drawing.Point(3, 46);
            this.tB_Param_DB.Name = "tB_Param_DB";
            this.tB_Param_DB.Size = new System.Drawing.Size(76, 20);
            this.tB_Param_DB.TabIndex = 49;
            this.tB_Param_DB.TextChanged += new System.EventHandler(this.tB_Param_DB_TextChanged);
            // 
            // tB_Param_Srv
            // 
            this.tB_Param_Srv.Enabled = false;
            this.tB_Param_Srv.Location = new System.Drawing.Point(3, 26);
            this.tB_Param_Srv.Name = "tB_Param_Srv";
            this.tB_Param_Srv.Size = new System.Drawing.Size(76, 20);
            this.tB_Param_Srv.TabIndex = 48;
            this.tB_Param_Srv.TextChanged += new System.EventHandler(this.tB_Param_Srv_TextChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(5, 10);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(62, 17);
            this.checkBox2.TabIndex = 47;
            this.checkBox2.Text = "Srv/DB";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_3);
            // 
            // tabControl9
            // 
            this.tabControl9.Controls.Add(this.tabPage20);
            this.tabControl9.Controls.Add(this.tabPage18);
            this.tabControl9.Controls.Add(this.tabPage19);
            this.tabControl9.Controls.Add(this.tabPage6);
            this.tabControl9.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl9.Location = new System.Drawing.Point(3, 3);
            this.tabControl9.Name = "tabControl9";
            this.tabControl9.SelectedIndex = 0;
            this.tabControl9.Size = new System.Drawing.Size(297, 74);
            this.tabControl9.TabIndex = 2;
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.cB_SessionAutoRun_AfterChangeValue);
            this.tabPage20.Controls.Add(this.cB_SessionAutoRun);
            this.tabPage20.Controls.Add(this.cB_AutoRun_AfterChangeValue);
            this.tabPage20.Controls.Add(this.cB_AutoRun);
            this.tabPage20.Location = new System.Drawing.Point(4, 22);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage20.Size = new System.Drawing.Size(289, 48);
            this.tabPage20.TabIndex = 2;
            this.tabPage20.Text = "AutoRun";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // cB_SessionAutoRun_AfterChangeValue
            // 
            this.cB_SessionAutoRun_AfterChangeValue.AutoSize = true;
            this.cB_SessionAutoRun_AfterChangeValue.Location = new System.Drawing.Point(75, 25);
            this.cB_SessionAutoRun_AfterChangeValue.Name = "cB_SessionAutoRun_AfterChangeValue";
            this.cB_SessionAutoRun_AfterChangeValue.Size = new System.Drawing.Size(161, 17);
            this.cB_SessionAutoRun_AfterChangeValue.TabIndex = 53;
            this.cB_SessionAutoRun_AfterChangeValue.Text = "Session: After Change Value";
            this.cB_SessionAutoRun_AfterChangeValue.UseVisualStyleBackColor = true;
            this.cB_SessionAutoRun_AfterChangeValue.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            this.cB_SessionAutoRun_AfterChangeValue.CheckStateChanged += new System.EventHandler(this.cB_SessionAutoRun_AfterChangeValue_CheckStateChanged);
            // 
            // cB_SessionAutoRun
            // 
            this.cB_SessionAutoRun.AutoSize = true;
            this.cB_SessionAutoRun.Location = new System.Drawing.Point(5, 25);
            this.cB_SessionAutoRun.Name = "cB_SessionAutoRun";
            this.cB_SessionAutoRun.Size = new System.Drawing.Size(63, 17);
            this.cB_SessionAutoRun.TabIndex = 52;
            this.cB_SessionAutoRun.Text = "Session";
            this.cB_SessionAutoRun.UseVisualStyleBackColor = true;
            this.cB_SessionAutoRun.CheckedChanged += new System.EventHandler(this.cB_SessionAutoRun_CheckedChanged);
            this.cB_SessionAutoRun.CheckStateChanged += new System.EventHandler(this.cB_SessionAutoRun_CheckStateChanged);
            // 
            // cB_AutoRun_AfterChangeValue
            // 
            this.cB_AutoRun_AfterChangeValue.AutoSize = true;
            this.cB_AutoRun_AfterChangeValue.BackColor = System.Drawing.SystemColors.Control;
            this.cB_AutoRun_AfterChangeValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cB_AutoRun_AfterChangeValue.FlatAppearance.BorderSize = 2;
            this.cB_AutoRun_AfterChangeValue.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.cB_AutoRun_AfterChangeValue.Location = new System.Drawing.Point(75, 5);
            this.cB_AutoRun_AfterChangeValue.Name = "cB_AutoRun_AfterChangeValue";
            this.cB_AutoRun_AfterChangeValue.Size = new System.Drawing.Size(118, 17);
            this.cB_AutoRun_AfterChangeValue.TabIndex = 51;
            this.cB_AutoRun_AfterChangeValue.Text = "After Change Value";
            this.cB_AutoRun_AfterChangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cB_AutoRun_AfterChangeValue.UseVisualStyleBackColor = false;
            this.cB_AutoRun_AfterChangeValue.CheckedChanged += new System.EventHandler(this.cB_AutoRun_AfterChangeValue_CheckedChanged);
            this.cB_AutoRun_AfterChangeValue.CheckStateChanged += new System.EventHandler(this.cB_AutoRun_AfterChangeValue_CheckStateChanged);
            // 
            // cB_AutoRun
            // 
            this.cB_AutoRun.AutoSize = true;
            this.cB_AutoRun.Location = new System.Drawing.Point(5, 5);
            this.cB_AutoRun.Name = "cB_AutoRun";
            this.cB_AutoRun.Size = new System.Drawing.Size(45, 17);
            this.cB_AutoRun.TabIndex = 21;
            this.cB_AutoRun.Text = "Use";
            this.cB_AutoRun.UseVisualStyleBackColor = true;
            this.cB_AutoRun.CheckedChanged += new System.EventHandler(this.cB_AutoRun_CheckedChanged);
            this.cB_AutoRun.CheckStateChanged += new System.EventHandler(this.cB_AutoRun_CheckStateChanged);
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.label10);
            this.tabPage18.Controls.Add(this.nUD_BackFromResultAfterSeconds);
            this.tabPage18.Controls.Add(this.cB_BackFromResult);
            this.tabPage18.Controls.Add(this.cB_NotSwitch_ToDataSetResult);
            this.tabPage18.Controls.Add(this.nUD_DataSetOutNumber);
            this.tabPage18.Location = new System.Drawing.Point(4, 22);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage18.Size = new System.Drawing.Size(289, 48);
            this.tabPage18.TabIndex = 0;
            this.tabPage18.Text = "To";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Seconds.";
            // 
            // nUD_BackFromResultAfterSeconds
            // 
            this.nUD_BackFromResultAfterSeconds.Location = new System.Drawing.Point(175, 23);
            this.nUD_BackFromResultAfterSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_BackFromResultAfterSeconds.Name = "nUD_BackFromResultAfterSeconds";
            this.nUD_BackFromResultAfterSeconds.Size = new System.Drawing.Size(38, 20);
            this.nUD_BackFromResultAfterSeconds.TabIndex = 54;
            this.nUD_BackFromResultAfterSeconds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUD_BackFromResultAfterSeconds.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // cB_BackFromResult
            // 
            this.cB_BackFromResult.AutoSize = true;
            this.cB_BackFromResult.Location = new System.Drawing.Point(40, 24);
            this.cB_BackFromResult.Name = "cB_BackFromResult";
            this.cB_BackFromResult.Size = new System.Drawing.Size(138, 17);
            this.cB_BackFromResult.TabIndex = 53;
            this.cB_BackFromResult.Text = "Back From Result After:";
            this.cB_BackFromResult.UseVisualStyleBackColor = true;
            this.cB_BackFromResult.CheckedChanged += new System.EventHandler(this.cB_BackFromResult_CheckedChanged);
            // 
            // cB_NotSwitch_ToDataSetResult
            // 
            this.cB_NotSwitch_ToDataSetResult.AutoSize = true;
            this.cB_NotSwitch_ToDataSetResult.Location = new System.Drawing.Point(40, 4);
            this.cB_NotSwitch_ToDataSetResult.Name = "cB_NotSwitch_ToDataSetResult";
            this.cB_NotSwitch_ToDataSetResult.Size = new System.Drawing.Size(127, 17);
            this.cB_NotSwitch_ToDataSetResult.TabIndex = 52;
            this.cB_NotSwitch_ToDataSetResult.Text = "Not Switch To Result";
            this.cB_NotSwitch_ToDataSetResult.UseVisualStyleBackColor = true;
            this.cB_NotSwitch_ToDataSetResult.CheckedChanged += new System.EventHandler(this.cB_NotSwitchDataSet_CheckedChanged);
            // 
            // nUD_DataSetOutNumber
            // 
            this.nUD_DataSetOutNumber.Location = new System.Drawing.Point(3, 3);
            this.nUD_DataSetOutNumber.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUD_DataSetOutNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_DataSetOutNumber.Name = "nUD_DataSetOutNumber";
            this.nUD_DataSetOutNumber.Size = new System.Drawing.Size(31, 20);
            this.nUD_DataSetOutNumber.TabIndex = 0;
            this.nUD_DataSetOutNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_DataSetOutNumber.ValueChanged += new System.EventHandler(this.nUD_DataSet_OutNumber_ValueChanged);
            // 
            // tabPage19
            // 
            this.tabPage19.Controls.Add(this.cB_XML_Column);
            this.tabPage19.Controls.Add(this.cB_ListOfFields);
            this.tabPage19.Controls.Add(this.cB_FirstRow_Field_Value);
            this.tabPage19.Controls.Add(this.cB_DataSet_Text);
            this.tabPage19.Location = new System.Drawing.Point(4, 22);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage19.Size = new System.Drawing.Size(289, 48);
            this.tabPage19.TabIndex = 1;
            this.tabPage19.Text = "Txt";
            this.tabPage19.UseVisualStyleBackColor = true;
            // 
            // cB_XML_Column
            // 
            this.cB_XML_Column.AutoSize = true;
            this.cB_XML_Column.Location = new System.Drawing.Point(103, 25);
            this.cB_XML_Column.Name = "cB_XML_Column";
            this.cB_XML_Column.Size = new System.Drawing.Size(81, 17);
            this.cB_XML_Column.TabIndex = 4;
            this.cB_XML_Column.Text = "Xml Column";
            this.cB_XML_Column.UseVisualStyleBackColor = true;
            this.cB_XML_Column.CheckedChanged += new System.EventHandler(this.cB_XML_Column_CheckedChanged);
            // 
            // cB_ListOfFields
            // 
            this.cB_ListOfFields.AutoSize = true;
            this.cB_ListOfFields.Location = new System.Drawing.Point(4, 25);
            this.cB_ListOfFields.Name = "cB_ListOfFields";
            this.cB_ListOfFields.Size = new System.Drawing.Size(86, 17);
            this.cB_ListOfFields.TabIndex = 3;
            this.cB_ListOfFields.Text = "List Of Fields";
            this.cB_ListOfFields.UseVisualStyleBackColor = true;
            this.cB_ListOfFields.CheckedChanged += new System.EventHandler(this.cB_ListOfFields_CheckedChanged);
            // 
            // cB_FirstRow_Field_Value
            // 
            this.cB_FirstRow_Field_Value.AutoSize = true;
            this.cB_FirstRow_Field_Value.Location = new System.Drawing.Point(104, 5);
            this.cB_FirstRow_Field_Value.Name = "cB_FirstRow_Field_Value";
            this.cB_FirstRow_Field_Value.Size = new System.Drawing.Size(131, 17);
            this.cB_FirstRow_Field_Value.TabIndex = 2;
            this.cB_FirstRow_Field_Value.Text = "First Row: Field=Value";
            this.cB_FirstRow_Field_Value.UseVisualStyleBackColor = true;
            this.cB_FirstRow_Field_Value.CheckedChanged += new System.EventHandler(this.cB_FirstRow_Field_Value_CheckedChanged);
            // 
            // cB_DataSet_Text
            // 
            this.cB_DataSet_Text.AutoSize = true;
            this.cB_DataSet_Text.Location = new System.Drawing.Point(3, 5);
            this.cB_DataSet_Text.Name = "cB_DataSet_Text";
            this.cB_DataSet_Text.Size = new System.Drawing.Size(41, 17);
            this.cB_DataSet_Text.TabIndex = 1;
            this.cB_DataSet_Text.Text = "Txt";
            this.cB_DataSet_Text.UseVisualStyleBackColor = true;
            this.cB_DataSet_Text.CheckedChanged += new System.EventHandler(this.cB_DataSet_Text_CheckedChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button5);
            this.tabPage6.Controls.Add(this.cB_Output_ByVertical);
            this.tabPage6.Controls.Add(this.button4);
            this.tabPage6.Controls.Add(this.button3);
            this.tabPage6.Controls.Add(this.button2);
            this.tabPage6.Controls.Add(this.tB_Output_Schema);
            this.tabPage6.Controls.Add(this.cB_Output_Schema);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(289, 48);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Output";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(88, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 19);
            this.button5.TabIndex = 6;
            this.button5.Text = "check array";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cB_Output_ByVertical
            // 
            this.cB_Output_ByVertical.AutoSize = true;
            this.cB_Output_ByVertical.Location = new System.Drawing.Point(6, 27);
            this.cB_Output_ByVertical.Name = "cB_Output_ByVertical";
            this.cB_Output_ByVertical.Size = new System.Drawing.Size(76, 17);
            this.cB_Output_ByVertical.TabIndex = 5;
            this.cB_Output_ByVertical.Text = "By Vertical";
            this.cB_Output_ByVertical.UseVisualStyleBackColor = true;
            this.cB_Output_ByVertical.CheckedChanged += new System.EventHandler(this.cB_Output_ByVertical_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(213, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 19);
            this.button4.TabIndex = 4;
            this.button4.Text = "CLR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(235, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 21);
            this.button3.TabIndex = 3;
            this.button3.Text = "Left";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "Top";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tB_Output_Schema
            // 
            this.tB_Output_Schema.Enabled = false;
            this.tB_Output_Schema.Location = new System.Drawing.Point(55, 6);
            this.tB_Output_Schema.Name = "tB_Output_Schema";
            this.tB_Output_Schema.Size = new System.Drawing.Size(130, 20);
            this.tB_Output_Schema.TabIndex = 1;
            this.tB_Output_Schema.TextChanged += new System.EventHandler(this.tB_Output_Schema_TextChanged);
            // 
            // cB_Output_Schema
            // 
            this.cB_Output_Schema.AutoSize = true;
            this.cB_Output_Schema.Location = new System.Drawing.Point(6, 8);
            this.cB_Output_Schema.Name = "cB_Output_Schema";
            this.cB_Output_Schema.Size = new System.Drawing.Size(48, 17);
            this.cB_Output_Schema.TabIndex = 0;
            this.cB_Output_Schema.Text = "Use:";
            this.cB_Output_Schema.UseVisualStyleBackColor = true;
            this.cB_Output_Schema.CheckedChanged += new System.EventHandler(this.cB_Output_Schema_CheckedChanged);
            // 
            // tabPage22
            // 
            this.tabPage22.Controls.Add(this.dGV_Export_Values);
            this.tabPage22.Controls.Add(this.splitter6);
            this.tabPage22.Controls.Add(this.dGV_Export_Import);
            this.tabPage22.Controls.Add(this.panel4);
            this.tabPage22.Location = new System.Drawing.Point(4, 22);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage22.Size = new System.Drawing.Size(977, 80);
            this.tabPage22.TabIndex = 1;
            this.tabPage22.Text = "Export Values";
            this.tabPage22.UseVisualStyleBackColor = true;
            // 
            // dGV_Export_Values
            // 
            this.dGV_Export_Values.AllowUserToAddRows = false;
            this.dGV_Export_Values.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dGV_Export_Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Export_Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Export_Values.Location = new System.Drawing.Point(293, 3);
            this.dGV_Export_Values.Name = "dGV_Export_Values";
            this.dGV_Export_Values.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dGV_Export_Values.RowTemplate.Height = 24;
            this.dGV_Export_Values.Size = new System.Drawing.Size(514, 74);
            this.dGV_Export_Values.TabIndex = 0;
            this.dGV_Export_Values.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Export_Values_CellContentClick_1);
            this.dGV_Export_Values.SelectionChanged += new System.EventHandler(this.dGV_Export_Values_SelectionChanged);
            // 
            // splitter6
            // 
            this.splitter6.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter6.Location = new System.Drawing.Point(807, 3);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(3, 74);
            this.splitter6.TabIndex = 15;
            this.splitter6.TabStop = false;
            // 
            // dGV_Export_Import
            // 
            this.dGV_Export_Import.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Export_Import.Dock = System.Windows.Forms.DockStyle.Right;
            this.dGV_Export_Import.Location = new System.Drawing.Point(810, 3);
            this.dGV_Export_Import.Name = "dGV_Export_Import";
            this.dGV_Export_Import.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dGV_Export_Import.RowTemplate.Height = 24;
            this.dGV_Export_Import.Size = new System.Drawing.Size(164, 74);
            this.dGV_Export_Import.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.tB_Import_TransactionID);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.nUD_EV_cI);
            this.panel4.Controls.Add(this.nUD_EV_rI);
            this.panel4.Controls.Add(this.nUD_EV_tI);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.linkLabel1);
            this.panel4.Controls.Add(this.toolStrip7);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.tB_Export_Param);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 74);
            this.panel4.TabIndex = 13;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(362, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(114, 68);
            this.panel6.TabIndex = 15;
            // 
            // tB_Import_TransactionID
            // 
            this.tB_Import_TransactionID.Location = new System.Drawing.Point(236, 26);
            this.tB_Import_TransactionID.Name = "tB_Import_TransactionID";
            this.tB_Import_TransactionID.Size = new System.Drawing.Size(50, 20);
            this.tB_Import_TransactionID.TabIndex = 17;
            this.tB_Import_TransactionID.TextChanged += new System.EventHandler(this.tB_Import_TransactionID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "To TransID:";
            // 
            // nUD_EV_cI
            // 
            this.nUD_EV_cI.Location = new System.Drawing.Point(247, 5);
            this.nUD_EV_cI.Name = "nUD_EV_cI";
            this.nUD_EV_cI.Size = new System.Drawing.Size(40, 20);
            this.nUD_EV_cI.TabIndex = 15;
            this.nUD_EV_cI.ValueChanged += new System.EventHandler(this.nUD_EV_cI_ValueChanged);
            // 
            // nUD_EV_rI
            // 
            this.nUD_EV_rI.Location = new System.Drawing.Point(153, 4);
            this.nUD_EV_rI.Name = "nUD_EV_rI";
            this.nUD_EV_rI.Size = new System.Drawing.Size(40, 20);
            this.nUD_EV_rI.TabIndex = 14;
            this.nUD_EV_rI.ValueChanged += new System.EventHandler(this.nUD_EV_rI_ValueChanged);
            // 
            // nUD_EV_tI
            // 
            this.nUD_EV_tI.Location = new System.Drawing.Point(61, 4);
            this.nUD_EV_tI.Name = "nUD_EV_tI";
            this.nUD_EV_tI.Size = new System.Drawing.Size(40, 20);
            this.nUD_EV_tI.TabIndex = 13;
            this.nUD_EV_tI.ValueChanged += new System.EventHandler(this.nUD_EV_tI_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Param:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(127, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(37, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "check";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // toolStrip7
            // 
            this.toolStrip7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip7.Location = new System.Drawing.Point(0, 49);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(290, 25);
            this.toolStrip7.TabIndex = 11;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton7.Text = "Add/Upd";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click_1);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton8.Text = "Del>";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "colIndex:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "tableIndex:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "rowIndex:";
            // 
            // tB_Export_Param
            // 
            this.tB_Export_Param.Location = new System.Drawing.Point(41, 27);
            this.tB_Export_Param.Name = "tB_Export_Param";
            this.tB_Export_Param.Size = new System.Drawing.Size(80, 20);
            this.tB_Export_Param.TabIndex = 2;
            this.tB_Export_Param.TextChanged += new System.EventHandler(this.tB_Export_Param_TextChanged);
            // 
            // tabPage23
            // 
            this.tabPage23.Controls.Add(this.dGV_ColumnWidths);
            this.tabPage23.Controls.Add(this.panel5);
            this.tabPage23.Location = new System.Drawing.Point(4, 22);
            this.tabPage23.Name = "tabPage23";
            this.tabPage23.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage23.Size = new System.Drawing.Size(977, 80);
            this.tabPage23.TabIndex = 2;
            this.tabPage23.Text = "Column Widths";
            this.tabPage23.UseVisualStyleBackColor = true;
            // 
            // dGV_ColumnWidths
            // 
            this.dGV_ColumnWidths.AllowUserToAddRows = false;
            this.dGV_ColumnWidths.AllowUserToDeleteRows = false;
            this.dGV_ColumnWidths.AllowUserToResizeRows = false;
            this.dGV_ColumnWidths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_ColumnWidths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_ColumnWidths.Location = new System.Drawing.Point(302, 3);
            this.dGV_ColumnWidths.Name = "dGV_ColumnWidths";
            this.dGV_ColumnWidths.ReadOnly = true;
            this.dGV_ColumnWidths.RowTemplate.Height = 24;
            this.dGV_ColumnWidths.Size = new System.Drawing.Size(672, 74);
            this.dGV_ColumnWidths.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cB_Column_AutoSizeMode);
            this.panel5.Controls.Add(this.rB_CW_2);
            this.panel5.Controls.Add(this.rB_CW_1);
            this.panel5.Controls.Add(this.nUD_CW_W);
            this.panel5.Controls.Add(this.nUD_CW_cI);
            this.panel5.Controls.Add(this.nUD_CW_tI);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.toolStrip8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(299, 74);
            this.panel5.TabIndex = 0;
            // 
            // cB_Column_AutoSizeMode
            // 
            this.cB_Column_AutoSizeMode.FormattingEnabled = true;
            this.cB_Column_AutoSizeMode.Items.AddRange(new object[] {
            "ColumnHeader",
            "AllCellsExceptHeader",
            "AllCells",
            "DisplayedCellsExceptHeader",
            "DisplayedCells",
            "Fill"});
            this.cB_Column_AutoSizeMode.Location = new System.Drawing.Point(161, 25);
            this.cB_Column_AutoSizeMode.Name = "cB_Column_AutoSizeMode";
            this.cB_Column_AutoSizeMode.Size = new System.Drawing.Size(132, 21);
            this.cB_Column_AutoSizeMode.TabIndex = 9;
            // 
            // rB_CW_2
            // 
            this.rB_CW_2.AutoSize = true;
            this.rB_CW_2.Location = new System.Drawing.Point(121, 26);
            this.rB_CW_2.Name = "rB_CW_2";
            this.rB_CW_2.Size = new System.Drawing.Size(40, 17);
            this.rB_CW_2.TabIndex = 8;
            this.rB_CW_2.TabStop = true;
            this.rB_CW_2.Text = "By:";
            this.rB_CW_2.UseVisualStyleBackColor = true;
            this.rB_CW_2.CheckedChanged += new System.EventHandler(this.rB_CW_2_CheckedChanged);
            // 
            // rB_CW_1
            // 
            this.rB_CW_1.AutoSize = true;
            this.rB_CW_1.Checked = true;
            this.rB_CW_1.Location = new System.Drawing.Point(7, 26);
            this.rB_CW_1.Name = "rB_CW_1";
            this.rB_CW_1.Size = new System.Drawing.Size(56, 17);
            this.rB_CW_1.TabIndex = 7;
            this.rB_CW_1.TabStop = true;
            this.rB_CW_1.Text = "Width:";
            this.rB_CW_1.UseVisualStyleBackColor = true;
            // 
            // nUD_CW_W
            // 
            this.nUD_CW_W.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nUD_CW_W.Location = new System.Drawing.Point(67, 26);
            this.nUD_CW_W.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_CW_W.Name = "nUD_CW_W";
            this.nUD_CW_W.Size = new System.Drawing.Size(50, 20);
            this.nUD_CW_W.TabIndex = 6;
            this.nUD_CW_W.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            // 
            // nUD_CW_cI
            // 
            this.nUD_CW_cI.Location = new System.Drawing.Point(161, 4);
            this.nUD_CW_cI.Name = "nUD_CW_cI";
            this.nUD_CW_cI.Size = new System.Drawing.Size(40, 20);
            this.nUD_CW_cI.TabIndex = 5;
            // 
            // nUD_CW_tI
            // 
            this.nUD_CW_tI.Location = new System.Drawing.Point(67, 4);
            this.nUD_CW_tI.Name = "nUD_CW_tI";
            this.nUD_CW_tI.Size = new System.Drawing.Size(40, 20);
            this.nUD_CW_tI.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "colIndex:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "tableIndex:";
            // 
            // toolStrip8
            // 
            this.toolStrip8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton10,
            this.toolStripButton11});
            this.toolStrip8.Location = new System.Drawing.Point(0, 49);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(299, 25);
            this.toolStrip8.TabIndex = 0;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton10.Text = "Add";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton11.Text = "Del>";
            this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // tabPage34
            // 
            this.tabPage34.Controls.Add(this.groupBox3);
            this.tabPage34.Location = new System.Drawing.Point(4, 22);
            this.tabPage34.Name = "tabPage34";
            this.tabPage34.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage34.Size = new System.Drawing.Size(977, 80);
            this.tabPage34.TabIndex = 3;
            this.tabPage34.Text = "After Run";
            this.tabPage34.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cB_AfterRun);
            this.groupBox3.Controls.Add(this.tB_AfterRunTransID);
            this.groupBox3.Location = new System.Drawing.Point(6, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GoTo After Run";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "TransactionID:";
            // 
            // cB_AfterRun
            // 
            this.cB_AfterRun.FormattingEnabled = true;
            this.cB_AfterRun.Items.AddRange(new object[] {
            " 0   - Nothing",
            "-1   - Go To Parent",
            "NN - Go To TransactionID"});
            this.cB_AfterRun.Location = new System.Drawing.Point(6, 19);
            this.cB_AfterRun.Name = "cB_AfterRun";
            this.cB_AfterRun.Size = new System.Drawing.Size(180, 21);
            this.cB_AfterRun.TabIndex = 0;
            this.cB_AfterRun.SelectedIndexChanged += new System.EventHandler(this.cB_AfterRun_SelectedIndexChanged);
            // 
            // tB_AfterRunTransID
            // 
            this.tB_AfterRunTransID.Location = new System.Drawing.Point(86, 44);
            this.tB_AfterRunTransID.Name = "tB_AfterRunTransID";
            this.tB_AfterRunTransID.Size = new System.Drawing.Size(100, 20);
            this.tB_AfterRunTransID.TabIndex = 1;
            this.tB_AfterRunTransID.TextChanged += new System.EventHandler(this.tB_AfterRunTransID_TextChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.tDB_TransactionUpdateAndRun,
            this.toolStripSeparator3,
            this.tSB_TransactionUpdate,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.tSL_RunResult,
            this.toolStripSeparator9});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(999, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton3.Text = "Run";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tDB_TransactionUpdateAndRun
            // 
            this.tDB_TransactionUpdateAndRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tDB_TransactionUpdateAndRun.Enabled = false;
            this.tDB_TransactionUpdateAndRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tDB_TransactionUpdateAndRun.ForeColor = System.Drawing.Color.White;
            this.tDB_TransactionUpdateAndRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tDB_TransactionUpdateAndRun.Name = "tDB_TransactionUpdateAndRun";
            this.tDB_TransactionUpdateAndRun.Size = new System.Drawing.Size(88, 22);
            this.tDB_TransactionUpdateAndRun.Text = "Save and Run";
            this.tDB_TransactionUpdateAndRun.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tSB_TransactionUpdate
            // 
            this.tSB_TransactionUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tSB_TransactionUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_TransactionUpdate.Enabled = false;
            this.tSB_TransactionUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tSB_TransactionUpdate.ForeColor = System.Drawing.Color.White;
            this.tSB_TransactionUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_TransactionUpdate.Name = "tSB_TransactionUpdate";
            this.tSB_TransactionUpdate.Size = new System.Drawing.Size(39, 22);
            this.tSB_TransactionUpdate.Text = "Save";
            this.tSB_TransactionUpdate.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "Preview";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tSL_RunResult
            // 
            this.tSL_RunResult.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tSL_RunResult.ForeColor = System.Drawing.Color.White;
            this.tSL_RunResult.Name = "tSL_RunResult";
            this.tSL_RunResult.Size = new System.Drawing.Size(58, 22);
            this.tSL_RunResult.Text = "WAITING";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Desktop;
            this.splitter1.Location = new System.Drawing.Point(309, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 501);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 501);
            this.panel2.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(306, 501);
            this.treeView1.TabIndex = 0;
            this.treeView1.TabStop = false;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.ImeModeChanged += new System.EventHandler(this.treeView1_ImeModeChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator35,
            this.aDDChildToolStripMenuItem,
            this.toolStripSeparator34,
            this.moveNode1ToNode2ToolStripMenuItem,
            this.toolStripSeparator26,
            this.sortOrderToolStripMenuItem,
            this.toolStripSeparator27,
            this.runToolStripMenuItem1,
            this.toolStripSeparator25,
            this.importFromFileToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(195, 144);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // toolStripSeparator35
            // 
            this.toolStripSeparator35.Name = "toolStripSeparator35";
            this.toolStripSeparator35.Size = new System.Drawing.Size(191, 6);
            // 
            // aDDChildToolStripMenuItem
            // 
            this.aDDChildToolStripMenuItem.Name = "aDDChildToolStripMenuItem";
            this.aDDChildToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aDDChildToolStripMenuItem.Text = "ADD Child";
            this.aDDChildToolStripMenuItem.Click += new System.EventHandler(this.aDDChildToolStripMenuItem_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(191, 6);
            // 
            // moveNode1ToNode2ToolStripMenuItem
            // 
            this.moveNode1ToNode2ToolStripMenuItem.Name = "moveNode1ToNode2ToolStripMenuItem";
            this.moveNode1ToNode2ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.moveNode1ToNode2ToolStripMenuItem.Text = "Move Node1 to Node2";
            this.moveNode1ToNode2ToolStripMenuItem.Click += new System.EventHandler(this.moveNode1ToNode2ToolStripMenuItem_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(191, 6);
            // 
            // sortOrderToolStripMenuItem
            // 
            this.sortOrderToolStripMenuItem.Name = "sortOrderToolStripMenuItem";
            this.sortOrderToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.sortOrderToolStripMenuItem.Text = "SortOrder";
            this.sortOrderToolStripMenuItem.Click += new System.EventHandler(this.sortOrderToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(191, 6);
            // 
            // runToolStripMenuItem1
            // 
            this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
            this.runToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.runToolStripMenuItem1.Text = "Run";
            this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem1_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(191, 6);
            // 
            // importFromFileToolStripMenuItem
            // 
            this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
            this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.importFromFileToolStripMenuItem.Text = "Import From File";
            this.importFromFileToolStripMenuItem.Click += new System.EventHandler(this.importFromFileToolStripMenuItem_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.tabControl8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1315, 507);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "DataSets";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl8
            // 
            this.tabControl8.Controls.Add(this.tabPage_DataSet1);
            this.tabControl8.Controls.Add(this.tabPage_DataSet2);
            this.tabControl8.Controls.Add(this.tabPage_DataSet3);
            this.tabControl8.Controls.Add(this.tabPage_Table0_TabedText);
            this.tabControl8.Controls.Add(this.tabPage31);
            this.tabControl8.Controls.Add(this.tabPage33);
            this.tabControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl8.Location = new System.Drawing.Point(3, 3);
            this.tabControl8.Name = "tabControl8";
            this.tabControl8.SelectedIndex = 0;
            this.tabControl8.Size = new System.Drawing.Size(1309, 501);
            this.tabControl8.TabIndex = 0;
            // 
            // tabPage_DataSet1
            // 
            this.tabPage_DataSet1.AutoScroll = true;
            this.tabPage_DataSet1.BackColor = System.Drawing.Color.Silver;
            this.tabPage_DataSet1.ForeColor = System.Drawing.Color.Black;
            this.tabPage_DataSet1.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DataSet1.Name = "tabPage_DataSet1";
            this.tabPage_DataSet1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DataSet1.Size = new System.Drawing.Size(1301, 475);
            this.tabPage_DataSet1.TabIndex = 0;
            this.tabPage_DataSet1.Text = "DataSet1";
            // 
            // tabPage_DataSet2
            // 
            this.tabPage_DataSet2.AutoScroll = true;
            this.tabPage_DataSet2.BackColor = System.Drawing.Color.Silver;
            this.tabPage_DataSet2.ForeColor = System.Drawing.Color.Black;
            this.tabPage_DataSet2.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DataSet2.Name = "tabPage_DataSet2";
            this.tabPage_DataSet2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DataSet2.Size = new System.Drawing.Size(1301, 475);
            this.tabPage_DataSet2.TabIndex = 1;
            this.tabPage_DataSet2.Text = "DataSet2";
            // 
            // tabPage_DataSet3
            // 
            this.tabPage_DataSet3.AutoScroll = true;
            this.tabPage_DataSet3.BackColor = System.Drawing.Color.Silver;
            this.tabPage_DataSet3.ForeColor = System.Drawing.Color.Black;
            this.tabPage_DataSet3.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DataSet3.Name = "tabPage_DataSet3";
            this.tabPage_DataSet3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DataSet3.Size = new System.Drawing.Size(1301, 475);
            this.tabPage_DataSet3.TabIndex = 2;
            this.tabPage_DataSet3.Text = "DataSet3";
            // 
            // tabPage_Table0_TabedText
            // 
            this.tabPage_Table0_TabedText.Controls.Add(this.rTB_DataSet_Text);
            this.tabPage_Table0_TabedText.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Table0_TabedText.Name = "tabPage_Table0_TabedText";
            this.tabPage_Table0_TabedText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Table0_TabedText.Size = new System.Drawing.Size(1301, 475);
            this.tabPage_Table0_TabedText.TabIndex = 3;
            this.tabPage_Table0_TabedText.Text = "Table[0].TabedText";
            this.tabPage_Table0_TabedText.UseVisualStyleBackColor = true;
            // 
            // rTB_DataSet_Text
            // 
            this.rTB_DataSet_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_DataSet_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_DataSet_Text.ForeColor = System.Drawing.Color.White;
            this.rTB_DataSet_Text.Location = new System.Drawing.Point(3, 3);
            this.rTB_DataSet_Text.Name = "rTB_DataSet_Text";
            this.rTB_DataSet_Text.Size = new System.Drawing.Size(1295, 469);
            this.rTB_DataSet_Text.TabIndex = 0;
            this.rTB_DataSet_Text.Text = "";
            this.rTB_DataSet_Text.WordWrap = false;
            // 
            // tabPage31
            // 
            this.tabPage31.Controls.Add(this.rTB_XML_Column);
            this.tabPage31.Location = new System.Drawing.Point(4, 22);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage31.Size = new System.Drawing.Size(1301, 475);
            this.tabPage31.TabIndex = 4;
            this.tabPage31.Text = "XML Text Original";
            this.tabPage31.UseVisualStyleBackColor = true;
            // 
            // rTB_XML_Column
            // 
            this.rTB_XML_Column.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_XML_Column.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_XML_Column.ForeColor = System.Drawing.Color.White;
            this.rTB_XML_Column.Location = new System.Drawing.Point(3, 3);
            this.rTB_XML_Column.Name = "rTB_XML_Column";
            this.rTB_XML_Column.Size = new System.Drawing.Size(1295, 469);
            this.rTB_XML_Column.TabIndex = 0;
            this.rTB_XML_Column.Text = "";
            this.rTB_XML_Column.ZoomFactor = 2F;
            // 
            // tabPage33
            // 
            this.tabPage33.Controls.Add(this.rTB_XML_Column_Adjusted);
            this.tabPage33.Location = new System.Drawing.Point(4, 22);
            this.tabPage33.Name = "tabPage33";
            this.tabPage33.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage33.Size = new System.Drawing.Size(1301, 475);
            this.tabPage33.TabIndex = 5;
            this.tabPage33.Text = "XML Text Adjusted";
            this.tabPage33.UseVisualStyleBackColor = true;
            // 
            // rTB_XML_Column_Adjusted
            // 
            this.rTB_XML_Column_Adjusted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_XML_Column_Adjusted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_XML_Column_Adjusted.ForeColor = System.Drawing.Color.White;
            this.rTB_XML_Column_Adjusted.Location = new System.Drawing.Point(3, 3);
            this.rTB_XML_Column_Adjusted.Name = "rTB_XML_Column_Adjusted";
            this.rTB_XML_Column_Adjusted.Size = new System.Drawing.Size(1295, 469);
            this.rTB_XML_Column_Adjusted.TabIndex = 1;
            this.rTB_XML_Column_Adjusted.Text = "";
            this.rTB_XML_Column_Adjusted.ZoomFactor = 2F;
            // 
            // tP_Charts
            // 
            this.tP_Charts.Controls.Add(this.tabControl6);
            this.tP_Charts.Location = new System.Drawing.Point(4, 22);
            this.tP_Charts.Name = "tP_Charts";
            this.tP_Charts.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Charts.Size = new System.Drawing.Size(1315, 507);
            this.tP_Charts.TabIndex = 2;
            this.tP_Charts.Text = "Charts";
            this.tP_Charts.UseVisualStyleBackColor = true;
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tP_Chart_C);
            this.tabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl6.Location = new System.Drawing.Point(3, 3);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(1309, 501);
            this.tabControl6.TabIndex = 2;
            // 
            // tP_Chart_C
            // 
            this.tP_Chart_C.Controls.Add(this.chart1);
            this.tP_Chart_C.Location = new System.Drawing.Point(4, 22);
            this.tP_Chart_C.Name = "tP_Chart_C";
            this.tP_Chart_C.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Chart_C.Size = new System.Drawing.Size(1301, 475);
            this.tP_Chart_C.TabIndex = 0;
            this.tP_Chart_C.Text = "C#";
            this.tP_Chart_C.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1295, 469);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // tB_Trees
            // 
            this.tB_Trees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tB_Trees.ForeColor = System.Drawing.Color.White;
            this.tB_Trees.Location = new System.Drawing.Point(4, 22);
            this.tB_Trees.Name = "tB_Trees";
            this.tB_Trees.Padding = new System.Windows.Forms.Padding(3);
            this.tB_Trees.Size = new System.Drawing.Size(1315, 507);
            this.tB_Trees.TabIndex = 7;
            this.tB_Trees.Text = "Trees";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.textBox1);
            this.tabPage7.Controls.Add(this.toolStrip9);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1315, 507);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Dump Upload";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1309, 476);
            this.textBox1.TabIndex = 1;
            // 
            // toolStrip9
            // 
            this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.toolStripTextBox3,
            this.toolStripSeparator22,
            this.toolStripButton16,
            this.toolStripSeparator21,
            this.toolStripLabel7});
            this.toolStrip9.Location = new System.Drawing.Point(3, 3);
            this.toolStrip9.Name = "toolStrip9";
            this.toolStrip9.Size = new System.Drawing.Size(1309, 25);
            this.toolStrip9.TabIndex = 0;
            this.toolStrip9.Text = "toolStrip9";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(163, 22);
            this.toolStripLabel6.Text = "[Currenct Connect].DB..Table:";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton16.Text = "Upload";
            this.toolStripButton16.Click += new System.EventHandler(this.toolStripButton16_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(208, 22);
            this.toolStripLabel7.Text = "(1st row: columns, column delim: tab)";
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage10.Controls.Add(this.tabControl5);
            this.tabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1315, 507);
            this.tabPage10.TabIndex = 5;
            this.tabPage10.Text = "Errors/SQL";
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage13);
            this.tabControl5.Controls.Add(this.tabPage14);
            this.tabControl5.Controls.Add(this.tabPage1);
            this.tabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl5.Location = new System.Drawing.Point(3, 3);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(1309, 501);
            this.tabControl5.TabIndex = 1;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.rTB_Errors);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(1301, 475);
            this.tabPage13.TabIndex = 0;
            this.tabPage13.Text = "Errors History";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // rTB_Errors
            // 
            this.rTB_Errors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_Errors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_Errors.ForeColor = System.Drawing.Color.White;
            this.rTB_Errors.Location = new System.Drawing.Point(3, 3);
            this.rTB_Errors.Name = "rTB_Errors";
            this.rTB_Errors.Size = new System.Drawing.Size(1295, 469);
            this.rTB_Errors.TabIndex = 0;
            this.rTB_Errors.Text = "";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.rTB_SQL);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(1301, 475);
            this.tabPage14.TabIndex = 1;
            this.tabPage14.Text = "SQL History";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // rTB_SQL
            // 
            this.rTB_SQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_SQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_SQL.ForeColor = System.Drawing.Color.White;
            this.rTB_SQL.Location = new System.Drawing.Point(3, 3);
            this.rTB_SQL.Name = "rTB_SQL";
            this.rTB_SQL.Size = new System.Drawing.Size(1295, 469);
            this.rTB_SQL.TabIndex = 1;
            this.rTB_SQL.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rTB_SQL_Preview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1301, 475);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "SQL Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rTB_SQL_Preview
            // 
            this.rTB_SQL_Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rTB_SQL_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_SQL_Preview.ForeColor = System.Drawing.Color.White;
            this.rTB_SQL_Preview.Location = new System.Drawing.Point(3, 3);
            this.rTB_SQL_Preview.Name = "rTB_SQL_Preview";
            this.rTB_SQL_Preview.Size = new System.Drawing.Size(1295, 469);
            this.rTB_SQL_Preview.TabIndex = 2;
            this.rTB_SQL_Preview.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl7);
            this.tabPage2.Controls.Add(this.toolStrip4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1315, 507);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl7
            // 
            this.tabControl7.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl7.Controls.Add(this.tabPage16);
            this.tabControl7.Controls.Add(this.tabPage17);
            this.tabControl7.Controls.Add(this.tabPage24);
            this.tabControl7.Controls.Add(this.tabPage30);
            this.tabControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl7.Location = new System.Drawing.Point(3, 28);
            this.tabControl7.Multiline = true;
            this.tabControl7.Name = "tabControl7";
            this.tabControl7.SelectedIndex = 0;
            this.tabControl7.Size = new System.Drawing.Size(1309, 476);
            this.tabControl7.TabIndex = 1;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.webBrowser1);
            this.tabPage16.Controls.Add(this.statusStrip2);
            this.tabPage16.Location = new System.Drawing.Point(23, 4);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(1282, 468);
            this.tabPage16.TabIndex = 0;
            this.tabPage16.Text = "Browser";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1276, 440);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip2.Location = new System.Drawing.Point(3, 443);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1276, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(400, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.tB_NavigateHistory);
            this.tabPage17.Location = new System.Drawing.Point(23, 4);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(1282, 468);
            this.tabPage17.TabIndex = 1;
            this.tabPage17.Text = "History";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // tB_NavigateHistory
            // 
            this.tB_NavigateHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tB_NavigateHistory.Location = new System.Drawing.Point(3, 3);
            this.tB_NavigateHistory.Multiline = true;
            this.tB_NavigateHistory.Name = "tB_NavigateHistory";
            this.tB_NavigateHistory.Size = new System.Drawing.Size(1276, 462);
            this.tB_NavigateHistory.TabIndex = 0;
            // 
            // tabPage24
            // 
            this.tabPage24.Controls.Add(this.listBox1);
            this.tabPage24.Location = new System.Drawing.Point(23, 4);
            this.tabPage24.Name = "tabPage24";
            this.tabPage24.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage24.Size = new System.Drawing.Size(1282, 468);
            this.tabPage24.TabIndex = 2;
            this.tabPage24.Text = "Events";
            this.tabPage24.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1276, 462);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage30
            // 
            this.tabPage30.Controls.Add(this.listBox2);
            this.tabPage30.Location = new System.Drawing.Point(23, 4);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage30.Size = new System.Drawing.Size(1282, 468);
            this.tabPage30.TabIndex = 3;
            this.tabPage30.Text = "Errors";
            this.tabPage30.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(1276, 462);
            this.listBox2.TabIndex = 1;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tSTB_URL,
            this.toolStripComboBox2,
            this.toolStripLabel4,
            this.toolStripLabel5,
            this.tSTB_Substitution,
            this.toolStripButton2,
            this.toolStripSeparator5,
            this.toolStripButton17,
            this.toolStripButton12,
            this.toolStripSeparator19,
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSplitButton2,
            this.toolStripButton15,
            this.toolStripSeparator20,
            this.toolStripButton19});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(1309, 25);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            this.toolStrip4.TextChanged += new System.EventHandler(this.toolStrip4_TextChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem16});
            this.toolStripLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel3.Image")));
            this.toolStripLabel3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(13, 22);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem15.Text = "Add";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem16.Text = "Del";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // tSTB_URL
            // 
            this.tSTB_URL.MaxDropDownItems = 30;
            this.tSTB_URL.Name = "tSTB_URL";
            this.tSTB_URL.Size = new System.Drawing.Size(500, 25);
            this.tSTB_URL.Click += new System.EventHandler(this.tSTB_URL_Click);
            this.tSTB_URL.TextChanged += new System.EventHandler(this.tSTB_URL_TextChanged);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "Internal IE",
            "Chrome",
            "FireFox",
            "External IE"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel4.Image")));
            this.toolStripLabel4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel4.Text = "Substitution:";
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Checked = true;
            this.toolStripLabel5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel5.Image")));
            this.toolStripLabel5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel5.Text = "Auto:";
            this.toolStripLabel5.Click += new System.EventHandler(this.toolStripLabel5_Click);
            // 
            // tSTB_Substitution
            // 
            this.tSTB_Substitution.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tSTB_Substitution.Name = "tSTB_Substitution";
            this.tSTB_Substitution.Size = new System.Drawing.Size(100, 25);
            this.tSTB_Substitution.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tSTB_Substitution_KeyUp);
            this.tSTB_Substitution.Click += new System.EventHandler(this.tSTB_Substitution_Click);
            this.tSTB_Substitution.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tSTB_Substitution_MouseUp);
            this.tSTB_Substitution.TextChanged += new System.EventHandler(this.tSTB_Substitution_TextChanged);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 22);
            this.toolStripButton2.Text = "GO";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.Checked = true;
            this.toolStripButton17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton17.Text = "Auto:";
            this.toolStripButton17.Click += new System.EventHandler(this.toolStripButton17_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton12.Text = "STOP";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(27, 22);
            this.toolStripButton13.Text = "<=";
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(27, 22);
            this.toolStripButton14.Text = "=>";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton15.Text = "Refresh";
            this.toolStripButton15.Click += new System.EventHandler(this.toolStripButton15_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton19.Image")));
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton19.Text = "JS Errors";
            this.toolStripButton19.Click += new System.EventHandler(this.toolStripButton19_Click);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.tabControl4);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1315, 507);
            this.tabPage11.TabIndex = 8;
            this.tabPage11.Text = "Tools";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage12);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 3);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(1309, 501);
            this.tabControl4.TabIndex = 0;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.groupBox2);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(1301, 475);
            this.tabPage12.TabIndex = 0;
            this.tabPage12.Text = "Reverse Single Dump";
            this.tabPage12.UseVisualStyleBackColor = true;
            this.tabPage12.Enter += new System.EventHandler(this.tabPage12_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1237, 457);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox2.Location = new System.Drawing.Point(3, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(186, 438);
            this.textBox2.TabIndex = 0;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox3.Location = new System.Drawing.Point(988, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(246, 438);
            this.textBox3.TabIndex = 1;
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Location = new System.Drawing.Point(198, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 137);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From Column Or String";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(122, 19);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(97, 17);
            this.checkBox5.TabIndex = 16;
            this.checkBox5.Text = "Auto Sel, Jump";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(128, 43);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(77, 17);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.Text = "To Column";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(59, 66);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(69, 17);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "To String";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "From Column";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(38, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Text = "From String";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(59, 98);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(99, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "T R A N S F E R";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(195, 45);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(774, 202);
            this.textBox4.TabIndex = 2;
            this.textBox4.WordWrap = false;
            this.textBox4.Click += new System.EventHandler(this.textBox4_Click);
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(198, 422);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(225, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Click += new System.EventHandler(this.textBox5_Click);
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "{,}",
            "{TAB}"});
            this.comboBox2.Location = new System.Drawing.Point(280, 396);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "To Delimiter:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "{,}",
            "{TAB}"});
            this.comboBox1.Location = new System.Drawing.Point(277, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(195, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "From Delimiter:";
            // 
            // tabPage35
            // 
            this.tabPage35.Controls.Add(this.groupBox52);
            this.tabPage35.Location = new System.Drawing.Point(4, 22);
            this.tabPage35.Name = "tabPage35";
            this.tabPage35.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage35.Size = new System.Drawing.Size(1315, 507);
            this.tabPage35.TabIndex = 9;
            this.tabPage35.Text = "Servers & CONNECT";
            this.tabPage35.UseVisualStyleBackColor = true;
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.tabControl13);
            this.groupBox52.Controls.Add(this.panel11);
            this.groupBox52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox52.Location = new System.Drawing.Point(3, 3);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(1309, 501);
            this.groupBox52.TabIndex = 2;
            this.groupBox52.TabStop = false;
            this.groupBox52.Text = "CONNECT";
            // 
            // tabControl13
            // 
            this.tabControl13.Controls.Add(this.tabPage36);
            this.tabControl13.Controls.Add(this.tabPage37);
            this.tabControl13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl13.Location = new System.Drawing.Point(3, 73);
            this.tabControl13.Name = "tabControl13";
            this.tabControl13.SelectedIndex = 0;
            this.tabControl13.Size = new System.Drawing.Size(1303, 425);
            this.tabControl13.TabIndex = 5;
            // 
            // tabPage36
            // 
            this.tabPage36.Controls.Add(this.dataGridView1);
            this.tabPage36.Location = new System.Drawing.Point(4, 22);
            this.tabPage36.Name = "tabPage36";
            this.tabPage36.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage36.Size = new System.Drawing.Size(1295, 399);
            this.tabPage36.TabIndex = 0;
            this.tabPage36.Text = "tabPage36";
            this.tabPage36.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(1289, 393);
            this.dataGridView1.TabIndex = 4;
            // 
            // tabPage37
            // 
            this.tabPage37.Controls.Add(this.listBox3);
            this.tabPage37.Location = new System.Drawing.Point(4, 22);
            this.tabPage37.Name = "tabPage37";
            this.tabPage37.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage37.Size = new System.Drawing.Size(1295, 399);
            this.tabPage37.TabIndex = 1;
            this.tabPage37.Text = "tabPage37";
            this.tabPage37.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.ForeColor = System.Drawing.Color.White;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(3, 3);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(1289, 393);
            this.listBox3.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel11.Controls.Add(this.button37);
            this.panel11.Controls.Add(this.checkBox6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 16);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1303, 57);
            this.panel11.TabIndex = 3;
            // 
            // button37
            // 
            this.button37.ForeColor = System.Drawing.Color.Black;
            this.button37.Location = new System.Drawing.Point(126, 3);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(248, 26);
            this.button37.TabIndex = 0;
            this.button37.Text = "CONNECT";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(3, 9);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(108, 17);
            this.checkBox6.TabIndex = 1;
            this.checkBox6.Text = "Keep Connection";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // bindingSource_Servers
            // 
            this.bindingSource_Servers.Sort = "ID";
            // 
            // dataSet101
            // 
            this.dataSet101.DataSetName = "DataSet101";
            this.dataSet101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timer_Highlight
            // 
            this.timer_Highlight.Interval = 1000;
            this.timer_Highlight.Tick += new System.EventHandler(this.timer_Highlight_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Open SQL Project";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.sql";
            this.openFileDialog1.Filter = "SQL Files|*.sql";
            this.openFileDialog1.Title = "Choose sql file";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer_AfterSelect
            // 
            this.timer_AfterSelect.Interval = 10;
            this.timer_AfterSelect.Tick += new System.EventHandler(this.timer_AfterSelect_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1323, 604);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SSW";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.contextMenuStrip3.ResumeLayout(false);
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.tabControl11.ResumeLayout(false);
            this.tabPage25.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Session_Values)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tabPage26.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Import_Values)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage27.ResumeLayout(false);
            this.tabControl12.ResumeLayout(false);
            this.tabPage28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Dump_Values)).EndInit();
            this.tabPage29.ResumeLayout(false);
            this.tabPage29.PerformLayout();
            this.toolStrip10.ResumeLayout(false);
            this.toolStrip10.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Transaction_Params)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.tabPage32.ResumeLayout(false);
            this.tabPage32.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.tabControl10.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.tabControl9.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            this.tabPage18.ResumeLayout(false);
            this.tabPage18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_BackFromResultAfterSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_DataSetOutNumber)).EndInit();
            this.tabPage19.ResumeLayout(false);
            this.tabPage19.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Export_Values)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Export_Import)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_EV_cI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_EV_rI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_EV_tI)).EndInit();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.tabPage23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_ColumnWidths)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CW_W)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CW_cI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_CW_tI)).EndInit();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.tabPage34.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl8.ResumeLayout(false);
            this.tabPage_Table0_TabedText.ResumeLayout(false);
            this.tabPage31.ResumeLayout(false);
            this.tabPage33.ResumeLayout(false);
            this.tP_Charts.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tP_Chart_C.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.toolStrip9.ResumeLayout(false);
            this.toolStrip9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl7.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            this.tabPage24.ResumeLayout(false);
            this.tabPage30.ResumeLayout(false);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage35.ResumeLayout(false);
            this.groupBox52.ResumeLayout(false);
            this.tabControl13.ResumeLayout(false);
            this.tabPage36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage37.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Servers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet101)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tP_Charts;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.ToolStripButton tSB_TransactionUpdate;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton tDB_TransactionUpdateAndRun;
        private System.Windows.Forms.ToolStripMenuItem sQLTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_TransactionID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_Error;
        //private System.Windows.Forms.TextBox tB_Description;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showTransactionIDInNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel tSL_RunResult;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.RichTextBox rTB_Errors;
        private System.Windows.Forms.Timer timer_Highlight;
        //private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem countColumnsInGridsForDataSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.CheckBox cB_AutoRun;
        private System.Windows.Forms.CheckBox cB_Chart;
        private System.Windows.Forms.ComboBox cB_ChartType;
        private System.Windows.Forms.ComboBox cB_Param_Type;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndRunToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_Param_Name;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.CheckBox cB_Param_Value;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.RichTextBox rTB_SQL;
        private System.Windows.Forms.ToolStripMenuItem exportToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem saveParamsAndTransactionToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tP_Chart_C;
        //private AxActiveForm_DBChart.AxActiveFormX axActiveFormX1;
        private System.Windows.Forms.ComboBox cB_DelphiChartType;
        private System.Windows.Forms.CheckBox cB_DelphiChart;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tSCB_Srv;
        private System.Windows.Forms.ToolStripComboBox tSCB_DB;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox tB_Param_DB;
        private System.Windows.Forms.TextBox tB_Param_Srv;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox tB_Export_Param;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tB_Param_Import;
        private System.Windows.Forms.DataGridView dGV_Transaction_Params;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSetViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripTextBox Rows_Count;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rTB_SQL_Preview;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripMenuItem saveTreeToXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem disableAutoRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        //private AxDelphi_DBChartProj1.AxDelphi_DBChart axDelphi_DBChart1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Use_LinkedServer;
        private System.Windows.Forms.ToolStripTextBox LinkedServer_Name;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripComboBox tSTB_URL;
        private System.Windows.Forms.ToolStripTextBox tSTB_Substitution;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dGV_Session_Values;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem Auto_ReRun;
        private System.Windows.Forms.ToolStripTextBox tSTB_Auto_ReRun_Count;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.DataGridView dGV_Import_Values;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage15;
        private DataSchema.DataSet101 dataSet101;
        private System.Windows.Forms.ToolStripButton toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripComboBox tSCB_LinkedServers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl7;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.TextBox tB_NavigateHistory;
        private System.Windows.Forms.ToolStripButton toolStripLabel4;
        private System.Windows.Forms.TabControl tabControl8;
        private System.Windows.Forms.TabPage tabPage_DataSet1;
        private System.Windows.Forms.TabPage tabPage_DataSet2;
        private System.Windows.Forms.NumericUpDown nUD_DataSetOutNumber;
        private System.Windows.Forms.TabPage tabPage_DataSet3;
        private System.Windows.Forms.TabPage tabPage_Table0_TabedText;
        private System.Windows.Forms.CheckBox cB_DataSet_Text;
        private System.Windows.Forms.RichTextBox rTB_DataSet_Text;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton cB_Use_DB;
        private System.Windows.Forms.ToolStripTextBox tB_Use_DB;
        private System.Windows.Forms.ToolStripButton cB_Use_LinkedServer;
        private System.Windows.Forms.ToolStripTextBox tB_LinkedServer;
        private System.Windows.Forms.RichTextBox rTB_sqlTransaction;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel Pos_X;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel Pos_Y;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сУчшеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSQLProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSQLProjectToolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearUsedSQLProjectsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem importFromFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem1;
        private System.Windows.Forms.CheckBox cB_AutoRun_AfterChangeValue;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView dGV_Export_Values;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.CheckBox cB_NotSwitch_ToDataSetResult;
        private System.Windows.Forms.ToolStripButton toolStripSplitButton1;
        private System.Windows.Forms.TabControl tabControl9;
        private System.Windows.Forms.TabPage tabPage20;
        private System.Windows.Forms.CheckBox cB_FirstRow_Field_Value;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripTextBox ttB_Description;
        private System.Windows.Forms.ToolStripButton toolStripLabel5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.TabControl tabControl10;
        private System.Windows.Forms.TabPage tabPage21;
        private System.Windows.Forms.TabPage tabPage22;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage tabPage23;
        private System.Windows.Forms.DataGridView dGV_ColumnWidths;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nUD_CW_W;
        private System.Windows.Forms.NumericUpDown nUD_CW_cI;
        private System.Windows.Forms.NumericUpDown nUD_CW_tI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.NumericUpDown nUD_EV_tI;
        private System.Windows.Forms.NumericUpDown nUD_EV_rI;
        private System.Windows.Forms.TabPage tabPage18;
        private System.Windows.Forms.TabPage tabPage19;
        private System.Windows.Forms.NumericUpDown nUD_EV_cI;
        private System.Windows.Forms.ComboBox cB_Column_AutoSizeMode;
        private System.Windows.Forms.RadioButton rB_CW_2;
        private System.Windows.Forms.RadioButton rB_CW_1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripSeparator toolStripSplitButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.TabPage tabPage24;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripMenuItem exportTreeTransactionsToFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.CheckBox cB_ListOfFields;
        private System.Windows.Forms.TextBox tB_Import_TransactionID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dGV_Export_Import;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter6;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.CheckBox cB_SessionAutoRun;
        private System.Windows.Forms.TabControl tabControl11;
        private System.Windows.Forms.TabPage tabPage25;
        private System.Windows.Forms.TabPage tabPage26;
        private System.Windows.Forms.TabPage tabPage27;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TabControl tabControl12;
        private System.Windows.Forms.TabPage tabPage28;
        private System.Windows.Forms.TabPage tabPage29;
        private System.Windows.Forms.TextBox tB_DumpValues;
        private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton toolStripButton18;
        private System.Windows.Forms.DataGridView dGV_Dump_Values;
        private System.Windows.Forms.RadioButton tSB_UseDumpValues;
        private System.Windows.Forms.RadioButton tSB_UseImportValues;
        private System.Windows.Forms.RadioButton tSB_UseLastValues;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.TabPage tabPage30;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ToolStripMenuItem moveNode1ToNode2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripMenuItem sortOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator28;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.CheckBox cB_XML_Column;
        private System.Windows.Forms.RichTextBox rTB_XML_Column;
        private TabPage tabPage32;
        private CheckBox cB_Trees;
        private TabPage tB_Trees;
        private CheckBox cB_Tree_Expand;
        private TabPage tabPage33;
        private RichTextBox rTB_XML_Column_Adjusted;
        private ToolStripSplitButton toolStripSplitButton3;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem20;
        private CheckBox cB_SessionAutoRun_AfterChangeValue;
        private Panel panel8;
        private Splitter splitter2;
        private Splitter splitter4;
        private Timer timer_AfterSelect;
        private CheckBox cB_BackFromResult;
        private Label label10;
        private NumericUpDown nUD_BackFromResultAfterSeconds;
        private TabPage tabPage6;
        private TextBox tB_Output_Schema;
        private CheckBox cB_Output_Schema;
        private Button button3;
        private Button button2;
        private Button button4;
        private CheckBox cB_Output_ByVertical;
        private Button button5;
        private TabPage tabPage11;
        private TabControl tabControl4;
        private TabPage tabPage12;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label12;
        private Label label11;
        private Button button9;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private ComboBox tB_Param_Value;
        private Button button6;
        private ToolStripComboBox toolStripComboBox2;
        private CheckBox checkBox1;
        private TabPage tabPage34;
        private ComboBox cB_AfterRun;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox tB_AfterRunTransID;
        private ToolStripSeparator toolStripSeparator6;
        private CheckBox checkBox5;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripButton toolStripButton20;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripSeparator toolStripSeparator31;
        private ToolStripButton toolStripLabel9;
        private TabPage tabPage35;
        private GroupBox groupBox52;
        private ListBox listBox3;
        private Panel panel11;
        private Button button37;
        private CheckBox checkBox6;
        private Timer timer2;
        private ToolStripMenuItem sHOWToolStripMenuItem;
        private BindingSource bindingSource_Servers;
        private DataGridView dataGridView1;
        private TabControl tabControl13;
        private TabPage tabPage36;
        private TabPage tabPage37;
        private ToolStripButton toolStripButton21;
        private ToolStripButton toolStripButton22;
        private ToolStripLabel toolStripLabel10;
        private ToolStripSeparator toolStripSeparator32;
        private ToolStripSeparator toolStripSeparator33;
        private ToolStripSeparator toolStripSeparator35;
        private ToolStripMenuItem aDDChildToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator34;
    }
}

