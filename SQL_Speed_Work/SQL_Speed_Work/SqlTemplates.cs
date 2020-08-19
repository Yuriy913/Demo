using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sql_DataSet;


namespace SQL_Speed_Work
{
    public partial class SqlTemplates : Form
    {
        public string sqlTemplate = "", AppStartUpDir="";
        public int itemIndex;
        public int InsertIntoPositionInText = 2; // into begin of text
        int rowID = -1,  TemplateID, NewTemplateID;
        private List<Category> items = new List<Category>();
        public string connectionString = "";

        public SqlTemplates()
        {
            InitializeComponent();
        }

        private void SqlTemplates_Load(object sender, EventArgs e)
        {
            AppStartUpDir = Application.StartupPath;
            if (File.Exists(AppStartUpDir + "\\..\\..\\sqlTemplatesDataSet.xml"))
                sqlTemplatesDataSet.ReadXml(AppStartUpDir + "\\..\\..\\sqlTemplatesDataSet.xml");
            
            foreach (DataRow row in sqlTemplatesDataSet.sqlBlockTemplates.Rows)
                row["Choosed"] = false;

            toolStripButton3_Click_1(sender, e);
        }

        private void SqlTemplates_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlTemplatesDataSet.WriteXml(AppStartUpDir + "\\..\\..\\sqlTemplatesDataSet.xml");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            DataRow[] rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ID=" + rowID.ToString());
            if (rows.Length == 1)
            {
                rows[0]["BlockTemplate"] = rTB_Template.Text;
            }
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
        {
            public int ID;
            public int ParentID;
            public string NodeText;
            public Category(int ID, int ParentID, string NodeText)
            {
                this.ID = ID; this.ParentID = ParentID; this.NodeText = NodeText;
            }
            public override string ToString() { return this.NodeText; }
        }

        private void add_template(bool child)
        {
            if (!child)
                TemplateID = 0;
            TreeNode newNode = new TreeNode(tSTB_Description.Text);
            DataRow newRow = sqlTemplatesDataSet.Tables["sqlBlockTemplates"].NewRow();
            newRow["Description"] = newNode.Text;
            newRow["ParentID"] = TemplateID;
            sqlTemplatesDataSet.Tables["sqlBlockTemplates"].Rows.Add(newRow);

            int rowIndex = sqlTemplatesDataSet.Tables["sqlBlockTemplates"].Rows.Count - 1;
            NewTemplateID = (int)sqlTemplatesDataSet.Tables["sqlBlockTemplates"].Rows[rowIndex]["ID"];
            Category cat = new Category(NewTemplateID, TemplateID, newNode.Text);
            newNode.Tag = cat;

            TreeNode parentNode = null;
            if (child)
                parentNode = treeView1.SelectedNode;
            if (parentNode == null)
                treeView1.Nodes.Add(newNode);
            else
                parentNode.Nodes.Add(newNode);

            treeView1.SelectedNode = newNode;

            showNodeID(NewTemplateID);

            TreeViewEventArgs ea = new TreeViewEventArgs(newNode);
            if (toolStripButton10.Checked)
                tSTB_Description.Text = "";
            SaveDataSet();
        }
        private void showNodeID(int NewTransactionID)
        {
            //NodeID = NewNodeID;
            //tSSL_NodeID.Text = NodeID.ToString();
            //showTemplate(NodeID);
        }
        private void SaveDataSet()
        {
            sqlTemplatesDataSet.WriteXml(AppStartUpDir + "\\..\\..\\sqlTemplatesDataSet.xml");
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            Category cat = (Category)node.Tag;
            TemplateID = cat.ID;
            showTemplate(TemplateID);
            if (rTB_Template.Text == "")
                rTB_Template.Text = cat.NodeText;
            tSSL_NodeID.Text = TemplateID.ToString();
        }
        private void showTemplate(int TemplateID)
        {
            DataRow[] rows = sqlTemplatesDataSet.Tables["sqlBlockTemplates"].Select("ID=" + TemplateID);
            if (rows.Length == 1)
                if (rows[0]["BlockTemplate"] != DBNull.Value)
                    rTB_Template.Text = (string)rows[0]["BlockTemplate"];
                else
                    rTB_Template.Text = "";
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            add_template(true);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            add_template(false);
        }

        private void rTB_Template_TextChanged(object sender, EventArgs e)
        {
            DataRow[] rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ID=" + TemplateID.ToString());
            if (rows.Length == 1)
                rows[0]["BlockTemplate"] = rTB_Template.Text;
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            Category cat = (Category)node.Tag;
            cat.NodeText = tSTB_Description.Text;
            node.Text = tSTB_Description.Text;
            DataRow[] rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ID=" + TemplateID.ToString());
            if (rows.Length == 1)
                rows[0]["Description"] = tSTB_Description.Text;
            if (toolStripButton10.Checked)
                tSTB_Description.Text = "";
            SaveDataSet();
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            toolStripButton10.Checked = !toolStripButton10.Checked;
        }

        private void insertIntoAtThePositionOfCursorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            beginOfTextToolStripMenuItem.Checked = false;
            endOfTextToolStripMenuItem.Checked = false;
            insertIntoAtThePositionOfCursorToolStripMenuItem1.Checked = true;
            InsertIntoPositionInText = 1;
        }

        private void endOfTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginOfTextToolStripMenuItem.Checked = false;
            endOfTextToolStripMenuItem.Checked = true;
            insertIntoAtThePositionOfCursorToolStripMenuItem1.Checked = false;
            InsertIntoPositionInText = 2;
        }

        private void beginOfTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginOfTextToolStripMenuItem.Checked = true;
            endOfTextToolStripMenuItem.Checked = false;
            insertIntoAtThePositionOfCursorToolStripMenuItem1.Checked = false;
            InsertIntoPositionInText = 0;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            prepare_templates(1);
            Close();
        }

        private void prepare_templates(int Number)
        {
            sqlTemplate = "";
            //int index = 0; 
            if ((toolStripButton5.Checked) || (Number == 1))
                foreach (DataRow row in sqlTemplatesDataSet.sqlBlockTemplates.Rows)
                    if ((bool)row["Choosed"] == true)
                    {
                        sqlTemplate += "\r\n\r\n";
                        sqlTemplate += row["BlockTemplate"].ToString();
                    }

            //int i=0, j = 0; 
            if ((toolStripButton5.Checked) || (Number == 2))
            {
                TreeNodeCollection tnc1 = treeView2.Nodes;
                foreach (TreeNode node1 in tnc1)
                {
                    sqlTemplate += "\r\n";
                    sqlTemplate += node1.Text.ToString();
                    if (node1.Nodes.Count > 0)
                    {
                        sqlTemplate += "\r\n";
                        TreeNodeCollection tnc2 = node1.Nodes;
                        foreach (TreeNode node2 in tnc2)
                            sqlTemplate += node2.Text.ToString();
                    }
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            Category cat = (Category)node.Tag;
            DataRow[] rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ID=" + cat.ID.ToString());
            if (rows.Length == 1)
                rows[0]["Choosed"] = node.Checked;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            Category cat = (Category)node.Tag;
            int ID = cat.ID, ParentID = cat.ParentID;

            DataRow[] rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ParentID=" + ID.ToString());
            if (rows.Length > 0)
                foreach (DataRow row in rows)
                    rows[0]["ParentID"] = ParentID;

            rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ID=" + ID.ToString());
            if (rows.Length > 0)
            {
                rows[0].Delete();
                treeView1.SelectedNode.Remove();
            }
            SaveDataSet();

        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            toolStripButton6.Enabled = false;
            try
            {
                if (toolStripTextBox2.Text.Length > 0)
                    if (int.Parse(toolStripTextBox2.Text) != -1)
                        toolStripButton6.Enabled = true;
            }
            catch { }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            Category cat = (Category)node.Tag;
            int ID = cat.ID;

            DataRow[] rows = sqlTemplatesDataSet.sqlBlockTemplates.Select("ID=" + ID.ToString());
            if (rows.Length > 0)
            {
                rows[0]["ParentID"] = int.Parse(toolStripTextBox2.Text);
                treeView1.SelectedNode.Remove();
                SaveDataSet();
                toolStripButton3_Click_1(sender, e);
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            items.Clear();

            sqlTemplatesDataSet.Tables["sqlBlockTemplates"].DefaultView.Sort = "ParentID ASC, SortOrder ASC, ID ASC";
            DataView dv = new DataView(sqlTemplatesDataSet.Tables["sqlBlockTemplates"]);
            dv.Sort = "ParentID ASC, SortOrder ASC, ID ASC";
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
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes[0].Expand();
                treeView1.Nodes[0].Checked = true;
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
        }

        private void cB_Databases_DropDown(object sender, EventArgs e)
        {
            if (cB_Databases.Items.Count == 0)
            {
                Sql sql_DB = new Sql(connectionString, true);
                //sql_DB.sqlCommandExecute_return_DataSet("SELECT ID=dbid, Name FROM master..sysdatabases");
                sql_DB.Execute("SELECT ID=dbid, Name FROM master..sysdatabases");
                //cB_Databases.DataSource = sql_DB.result_DataSet.Tables[0];
                cB_Databases.DataSource = sql_DB.dataSet.Tables[0];
                cB_PartOfTableName.Enabled = true;
                button3.Enabled = true;
                linkLabel1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = cB_PartOfTableName.Text;
            if (str.Length >= 3)
            {
                bool detected = false;
                foreach (DataRow row in sqlTemplatesDataSet.Tables["PartsOfTableNames"].Rows)
                {
                    if (str == (string)row["PartOfName"])
                        detected = true;
                }
                if (!detected)
                {
                    DataRow row = sqlTemplatesDataSet.Tables["PartsOfTableNames"].NewRow();
                    row["PartOfName"] = str;
                    sqlTemplatesDataSet.Tables["PartsOfTableNames"].Rows.Add(row);
                    cB_PartOfTableName.Items.Add(str);
                }
            }
            
            Sql sql_TablesAdnViews = new Sql(connectionString, true);
            string sqlCmd = "SELECT ID,Name FROM ";
            sqlCmd += cB_Databases.Text;
            sqlCmd += "..sysobjects WHERE xtype IN ('U','V'";
            if (checkBox1.Checked) sqlCmd += ",'S'";
            sqlCmd += ")";
            if (cB_PartOfTableName.Text != "")
                sqlCmd += " AND Name LIKE '%" + cB_PartOfTableName.Text + "%'";
            //sql_TablesAdnViews.sqlCommandExecute_return_DataSet(sqlCmd);
            sql_TablesAdnViews.Execute(sqlCmd);
            //cB_Tables.DataSource = sql_TablesAdnViews.result_DataSet.Tables[0];
            cB_Tables.DataSource = sql_TablesAdnViews.dataSet.Tables[0];
            cB_Tables.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string DB_Table = cB_Databases.Text + ".dbo." + cB_Tables.Text;
            cb_DB_Table.Enabled = true;
            cb_DB_Table.Text = DB_Table;
            cb_DB_Table.Items.Add(DB_Table);
            toolStripButton16.Enabled = true;
            toolStripButton17.Enabled = true;
            toolStripButton18.Enabled = true;
        }

        private void db_table_move(bool Up)
        {
            if (cb_DB_Table.Items.Count == 0) return;
            object item = cb_DB_Table.SelectedItem;
            if (item == null) return;
            int itemIndex = cb_DB_Table.SelectedIndex;

            if (Up)
                if (itemIndex > 0)
                {
                    cb_DB_Table.Items.RemoveAt(itemIndex);
                    itemIndex--;
                    cb_DB_Table.Items.Insert(itemIndex, item);
                }
                else { }
            else
                if (itemIndex < cb_DB_Table.Items.Count - 1)
                {
                    cb_DB_Table.Items.RemoveAt(itemIndex);
                    itemIndex++;
                    if (itemIndex > cb_DB_Table.Items.Count - 1)
                        cb_DB_Table.Items.Add(item);
                    else
                        cb_DB_Table.Items.Insert(itemIndex, item);
                }

        }

        private void tree_table_fields_move(bool Up)
        {
            if (treeView2.Nodes.Count == 0) return;
            TreeNode nodeMove = treeView2.SelectedNode;
            if (nodeMove == null) return;
            if (nodeMove.Level > 0) return;
            int nodeIndex = treeView2.SelectedNode.Index;
            if (Up)
            {
                if (nodeIndex > 0)
                {
                    nodeMove.Remove();
                    nodeIndex--;
                    treeView2.Nodes.Insert(nodeIndex, nodeMove);
                }
            }
            else
            {
                if (nodeIndex < treeView2.Nodes.Count - 1)
                {
                    nodeMove.Remove();
                    nodeIndex++;
                    if (nodeIndex > treeView2.Nodes.Count - 1)
                        treeView2.Nodes.Add(nodeMove);
                    else
                        treeView2.Nodes.Insert(nodeIndex, nodeMove);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = !toolStripButton1.Checked;
            if (toolStripButton1.Checked)
            {
                toolStripButton11.Enabled = true;
                toolStripButton1.Text = "DISABLE DELETION:";
            }
            else
            {
                toolStripButton11.Enabled = false;
                toolStripButton1.Text = "ENABLE DELETION:";
            }
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            toolStripButton5.Checked = !toolStripButton5.Checked;
            if (toolStripButton5.Checked)
                toolStripButton5.Text = "UNION";
            else
                toolStripButton5.Text = "not union";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            prepare_templates(2);
            Close();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree_table_fields_move(true);
        }

        private void downToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tree_table_fields_move(false);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            treeView2.SelectedNode.Remove();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            treeView2.Nodes.Clear();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            cb_DB_Table.Items.Remove(cb_DB_Table.SelectedItem);
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (cb_DB_Table.Text == "")
            {
                MessageBox.Show("Not Selected table !");
                return;
            }
            TreeNode nodeTable;
            int tableIndex = cb_DB_Table.SelectedIndex;
            string NodeText = cb_DB_Table.Text;
            if (toolStripButton22.Checked)
                NodeText += " as t" + tableIndex.ToString();
            nodeTable = treeView2.Nodes.Add(NodeText);
            foreach (int fieldIndex in cLB_Fields.CheckedIndices)
            {
                NodeText = cLB_Fields.GetItemText(cLB_Fields.Items[fieldIndex]) + ", ";
                if (toolStripButton22.Checked)
                    NodeText = "t" + tableIndex.ToString() + "." + NodeText;
                nodeTable.Nodes.Add(NodeText);
            }
            nodeTable.Expand();
            toolStripSplitButton1.Enabled = true;
            toolStrip4.Enabled = true;
            toolStripButton15.Enabled = true;
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            toolStripButton22.Checked = !toolStripButton22.Checked;
        }

        private void cb_DB_Table_TextChanged(object sender, EventArgs e)
        {
            if (cb_DB_Table.Text == "")
            {
                MessageBox.Show("Need table Name !");
                return;
            }
            string itemString = cb_DB_Table.Text;
            int pos = itemString.IndexOf(".");
            string DbName = itemString.Substring(0, pos);
            itemString = itemString.Remove(0, pos + 1);
            pos = itemString.IndexOf(".");
            string TableName = itemString.Substring(pos + 1);
            Sql sql_Fields = new Sql(connectionString, true);
            string sqlCmd = "SELECT ID, Name FROM " + DbName + ".dbo.syscolumns";
            sqlCmd += " WHERE ID=(SELECT TOP 1 ID FROM " + DbName + ".dbo.sysobjects WHERE name=";
            sqlCmd += "'" + TableName + "'";
            sqlCmd += ") ORDER BY 1";
            //sql_Fields.sqlCommandExecute_return_DataSet(sqlCmd);
            sql_Fields.Execute(sqlCmd);
            //cLB_Fields.DataSource = sql_Fields.result_DataSet.Tables[0];
            cLB_Fields.DataSource = sql_Fields.dataSet.Tables[0];
            cLB_Fields.DisplayMember = "Name";
            cLB_Fields.ValueMember = "ID";
        }

        private void upToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            db_table_move(false);
        }

        private void downToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            db_table_move(true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataRow[] rows = sqlTemplatesDataSet.Tables["PartsOfTableNames"].Select("PartOfName='" + cB_PartOfTableName.Text + "'");
            if (rows.Length > 0)
            {
                sqlTemplatesDataSet.Tables["PartsOfTableNames"].Rows.Remove(rows[0]);
                cB_PartOfTableName.Text = "";
            }
        }
    }
}
