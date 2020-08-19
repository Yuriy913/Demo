namespace SQL_Speed_Work
{
    partial class ServerAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.tB_ServerName = new System.Windows.Forms.TextBox();
            this.l_connectionnString = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tB_ConnectionString = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serversBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet101 = new DataSchema.DataSet101();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_DataBase = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet101)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tB_ServerName
            // 
            this.tB_ServerName.Location = new System.Drawing.Point(49, 4);
            this.tB_ServerName.Name = "tB_ServerName";
            this.tB_ServerName.Size = new System.Drawing.Size(174, 20);
            this.tB_ServerName.TabIndex = 1;
            // 
            // l_connectionnString
            // 
            this.l_connectionnString.AutoSize = true;
            this.l_connectionnString.Location = new System.Drawing.Point(5, 27);
            this.l_connectionnString.Name = "l_connectionnString";
            this.l_connectionnString.Size = new System.Drawing.Size(96, 13);
            this.l_connectionnString.TabIndex = 2;
            this.l_connectionnString.Text = "connectionnString:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(121, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tB_ConnectionString
            // 
            this.tB_ConnectionString.Location = new System.Drawing.Point(8, 44);
            this.tB_ConnectionString.Name = "tB_ConnectionString";
            this.tB_ConnectionString.Size = new System.Drawing.Size(421, 20);
            this.tB_ConnectionString.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.connectionStringDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.serversBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(459, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // connectionStringDataGridViewTextBoxColumn
            // 
            this.connectionStringDataGridViewTextBoxColumn.DataPropertyName = "connectionString";
            this.connectionStringDataGridViewTextBoxColumn.HeaderText = "connectionString";
            this.connectionStringDataGridViewTextBoxColumn.Name = "connectionStringDataGridViewTextBoxColumn";
            // 
            // serversBindingSource
            // 
            this.serversBindingSource.DataMember = "Servers";
            this.serversBindingSource.DataSource = this.dataSet101;
            // 
            // dataSet101
            // 
            this.dataSet101.DataSetName = "DataSet101";
            this.dataSet101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "DataBase:";
            // 
            // tB_DataBase
            // 
            this.tB_DataBase.Location = new System.Drawing.Point(293, 4);
            this.tB_DataBase.Name = "tB_DataBase";
            this.tB_DataBase.Size = new System.Drawing.Size(100, 20);
            this.tB_DataBase.TabIndex = 9;
            // 
            // ServerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 259);
            this.Controls.Add(this.tB_DataBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tB_ConnectionString);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.l_connectionnString);
            this.Controls.Add(this.tB_ServerName);
            this.Controls.Add(this.label1);
            this.Name = "ServerAdd";
            this.Text = "Server Add";
            this.Load += new System.EventHandler(this.ServerAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet101)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_ServerName;
        private System.Windows.Forms.Label l_connectionnString;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tB_ConnectionString;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn primaryDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn primaryDatabaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectionStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource serversBindingSource;
        private DataSchema.DataSet101 dataSet101;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_DataBase;
    }
}