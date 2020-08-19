using Sql_DataSet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Table_Stars
{
    public partial class Form1 : Form
    {
        #region Variables
        Sql sql;
        DataSet1 dataSet1 = new DataSet1();
        string Node_Path = "";
        bool TreeView_Selected = false;
        string FileName = @"c:\Solutions\XML\SQL_Table_Stars\DataSet1.xml";
        string ms_sql_table_stars_script_FileName = @"c:\Solutions\XML\SQL_Table_Stars\ms_sql_table_stars_script.rtf";
        string Text_Node_Tree = "";
        DataView DV1, DV2,DV3, DV4;
        bool Table_Filling = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private bool GET_Tables()
        {
            bool result = false;
            //sql.Parameters = new SqlParameter[1];
            //sql.Parameters[0] = new SqlParameter("IO", 1);
            //sql.Execute("db_table_stars");

            string sqlString = richTextBox2.Text;
            sql.Execute(sqlString);
            if (sql.error)
                MessageBox.Show(sql.errorMessage);
            else
                result = true;
            return result;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void GET_Connection()
        {
            string ConnectionString = dataSet1.Tables["Connections"].Rows[dataGridView2.SelectedCells[0].RowIndex]["ConnectionString"].ToString();
            sql = new Sql(ConnectionString);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GET_Connection();
            if (!GET_Tables()) return;
            treeView1.Nodes.Clear();
            foreach (DataRow PK_Row in sql.dataSet.Tables[1].Rows)
            {
                string Node_Chain = ".";
                ADD_PK_Children(null, PK_Row, Node_Chain);
            }

            //treeView1.ExpandAll();
            //-----------------------------------------------
            // ADD from FK table and FL
            //-----------------------------------------------
            treeView2.Nodes.Clear();
            foreach (DataRow FK_Row in sql.dataSet.Tables[3].Rows)
            {
                string Node_Chain = ".";
                ADD_FK_Children(null, FK_Row, Node_Chain);
            }

            /*
            foreach (DataRow FK_Row in sql.dataSet.Tables[3].Rows)
            {
                TreeNode FK_Table_Name = treeView2.Nodes.Add(FK_Row["FK_Table_Name"].ToString());
                FK_Table_Name.Tag = "TABLE";

                TreeNode FK_Table_Name_FK = FK_Table_Name.Nodes.Add("FK");
                FK_Table_Name_FK.Tag = "FK";

                foreach (DataRow PK_Row in sql.dataSet.Tables[2].Rows)
                {
                    if (PK_Row["FK_Table_ID"].ToString() == FK_Row["FK_Table_ID"].ToString())
                    {
                        TreeNode FK_Table_Name_FK_Field = FK_Table_Name_FK.Nodes.Add(PK_Row["FK_Col_Name"].ToString());
                        FK_Table_Name_FK_Field.Tag = "FIELD";

                        TreeNode PK_Table_Name = FK_Table_Name_FK_Field.Nodes.Add(PK_Row["PK_Table_Name"].ToString());
                        PK_Table_Name.Tag = "TABLE";

                        TreeNode PK_Table_Name_PK = PK_Table_Name.Nodes.Add("PK");
                        PK_Table_Name_PK.Tag = "PK";

                        TreeNode PK_Table_Name_PK_Field = PK_Table_Name_PK.Nodes.Add(PK_Row["PK_Col_Name"].ToString());
                        PK_Table_Name_PK_Field.Tag = "FIELD";
                    }
                }
                //-------------------------------------------
                TreeNode FL_PK = null, FL_SM = null;
                foreach (DataRow FL_Row in sql.dataSet.Tables[4].Rows)
                {
                    if (FL_Row["FL_Table_ID"].ToString() == FK_Row["FK_Table_ID"].ToString())
                    {
                        if (FL_Row["FL"].ToString() == "1")
                        {
                            if (FL_PK == null)
                            {
                                FL_PK = FK_Table_Name.Nodes.Add("PK");
                                FL_PK.Tag = "PK";
                            }
                            TreeNode FL_PK_Field = FL_PK.Nodes.Add(FL_Row["FL_Col_Name"].ToString());
                            FL_PK_Field.Tag = "FIELD";
                        }
                        else
                            if (FL_Row["FL"].ToString() == "0")
                        {
                            if (FL_SM == null)
                            {
                                FL_SM = FK_Table_Name.Nodes.Add("FL");
                                FL_SM.Tag = "FL";
                            }
                            TreeNode FL_SM_Field = FL_SM.Nodes.Add(FL_Row["FL_Col_Name"].ToString());
                            FL_SM_Field.Tag = "FIELD";
                        }
                    }
                }
            }
            //-----------------------------------------------
            // ADD from FL Table
            //-----------------------------------------------
            foreach (DataRow FK_Row in sql.dataSet.Tables[5].Rows)
            {
                TreeNode FK_Table_Name = treeView2.Nodes.Add(FK_Row["FL_Table_Name"].ToString());
                FK_Table_Name.Tag = "TABLE";

                TreeNode FL_PK = null, FL_SM = null;
                foreach (DataRow FL_Row in sql.dataSet.Tables[4].Rows)
                {
                    if (FL_Row["FL_Table_ID"].ToString() == FK_Row["FL_Table_ID"].ToString())
                    {
                        if (FL_Row["FL"].ToString() == "1")
                        {
                            if (FL_PK == null)
                            {
                                FL_PK = FK_Table_Name.Nodes.Add("PK");
                                FL_PK.Tag = "PK";
                            }
                            TreeNode FL_PK_Field = FL_PK.Nodes.Add(FL_Row["FL_Col_Name"].ToString());
                            FL_PK_Field.Tag = "FIELD";
                        }
                        else
                            if (FL_Row["FL"].ToString() == "0")
                        {
                            if (FL_SM == null)
                            {
                                FL_SM = FK_Table_Name.Nodes.Add("FL");
                                FL_SM.Tag = "FL";
                            }
                            TreeNode FL_SM_Field = FL_SM.Nodes.Add(FL_Row["FL_Col_Name"].ToString());
                            FL_SM_Field.Tag = "FIELD";
                        }
                    }
                }
            }
            */
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeView_Selected) return;
            TreeView_Selected = true;
            //---------------------------------
            GET_NODE_PATH(e.Node);
            //---------------------------------
            FIND_Root_FK_Star(treeView1.SelectedNode.Text);
            TreeView_Selected = false;
        }

        private void Get_Nodes_Path(TreeNode LastNode)
        {
            string Tag = LastNode.Tag.ToString();

            if (Node_Path != "")
                Node_Path = "." + Node_Path;

            if (Tag == "FIELD")
                Node_Path = "[" + LastNode.Text + "]" + Node_Path;
            else
                Node_Path = LastNode.Text + Node_Path;

            if (LastNode.Parent != null)
                Get_Nodes_Path(LastNode.Parent);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox1.Text + "\r\n" + richTextBox1.Text;
        }

        private void showRootTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIND_Root_PK_Star(treeView1.SelectedNode.Text);
        }

        void FIND_Root_FK_Star(string Root_Name)
        {
            foreach (TreeNode Find_Root_Node in treeView2.Nodes)
            {
                if (Find_Root_Node.Parent == null)
                    if (Find_Root_Node.Text == Root_Name)
                    {
                        treeView2.SelectedNode = Find_Root_Node;
                        break;
                    }
            }
        }


        void FIND_Root_PK_Star(string Root_Name, bool ShowNoty = true)
        {
            bool node_found = false;
            foreach (TreeNode Find_Root_Node in treeView1.Nodes)
            {
                if (Find_Root_Node.Parent == null)
                    if (Find_Root_Node.Text == Root_Name)
                    {
                        //Find_Root_Node.ExpandAll();
                        treeView1.SelectedNode = Find_Root_Node;
                        node_found = true;
                        break;
                    }
            }
            if (ShowNoty)
                if (!node_found)
                    MessageBox.Show("Node not FOUND !!!");
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FIND_Root_Star(dataGridView1.SelectedRows[0].Cells["PK_Table_Name"].Value.ToString());
        }

        private void ADD_PK_Children(TreeNode Parent, DataRow PK_Row, string Node_Chain)
        {
            if (Node_Chain.IndexOf("." + PK_Row["PK_Table_ID"].ToString() + ".") > 0)
            {
                Parent.Nodes.Add("RING");
                return;
            }
            Node_Chain += PK_Row["PK_Table_ID"].ToString() + ".";

            TreeNode PK_Table_Name;
            if (Parent == null)
            {
                PK_Table_Name = treeView1.Nodes.Add(PK_Row["PK_Table_Name"].ToString());
                PK_Table_Name.Tag = "TABLE";
            }
            else
                PK_Table_Name = Parent;

            TreeNode PK_Table_Name_PK = PK_Table_Name.Nodes.Add("PK");
            PK_Table_Name_PK.Tag = "PK";
            TreeNode PK_Table_Name_PK_Field = PK_Table_Name_PK.Nodes.Add(PK_Row["PK_Col_Name"].ToString());
            PK_Table_Name_PK_Field.Tag = "FIELD";

            foreach (DataRow FK_Row in sql.dataSet.Tables[0].Rows)
            {
                if (FK_Row["PK_Table_ID"].ToString() == PK_Row["PK_Table_ID"].ToString())
                {
                    TreeNode FK_Table_Name = PK_Table_Name_PK_Field.Nodes.Add(FK_Row["FK_Table_Name"].ToString());
                    FK_Table_Name.Tag = "TABLE";
                    TreeNode FK_Table_Name_FK = FK_Table_Name.Nodes.Add("FK");
                    FK_Table_Name_FK.Tag = "FK";
                    TreeNode FK_Table_Name_FK_Field = FK_Table_Name_FK.Nodes.Add(FK_Row["FK_Col_Name"].ToString());
                    FK_Table_Name_FK_Field.Tag = "FIELD";
                    foreach (DataRow PK_Row_Next in sql.dataSet.Tables[1].Rows)
                    {
                        if (PK_Row_Next["PK_Table_ID"].ToString() == FK_Row["FK_Table_ID"].ToString())
                        {
                            ADD_PK_Children(FK_Table_Name, PK_Row_Next, Node_Chain);
                            break;
                        }
                    }
                }
            }

        }

        private void ADD_FK_Children(TreeNode Parent, DataRow FK_Row, string Node_Chain)
        {
            if (Node_Chain.IndexOf("." + FK_Row["FK_Table_ID"].ToString() + ".") > 0)
            {
                Parent.Nodes.Add("RING");
                return;
            }
            Node_Chain += FK_Row["FK_Table_ID"].ToString() + ".";

            TreeNode FK_Table_Name;
            if (Parent == null)
            {
                FK_Table_Name = treeView2.Nodes.Add(FK_Row["FK_Table_Name"].ToString());
                FK_Table_Name.Tag = "TABLE";
            }
            else
                FK_Table_Name = Parent;

            TreeNode FK_Table_Name_FK = FK_Table_Name.Nodes.Add("FK");
                     FK_Table_Name_FK.Tag = "FK";


            foreach (DataRow PK_Row in sql.dataSet.Tables[2].Rows)
            {
                if (PK_Row["FK_Table_ID"].ToString() == FK_Row["FK_Table_ID"].ToString())
                {
                    TreeNode FK_Table_Name_FK_Field = FK_Table_Name_FK.Nodes.Add(PK_Row["FK_Col_Name"].ToString());
                             FK_Table_Name_FK_Field.Tag = "FIELD";

                    TreeNode PK_Table_Name = FK_Table_Name_FK_Field.Nodes.Add(PK_Row["PK_Table_Name"].ToString());
                             PK_Table_Name.Tag = "TABLE";
                    TreeNode PK_Table_Name_PK = PK_Table_Name.Nodes.Add("PK");
                             PK_Table_Name_PK.Tag = "PK";
                    TreeNode PK_Table_Name_PK_Field = PK_Table_Name_PK.Nodes.Add(PK_Row["PK_Col_Name"].ToString());
                             PK_Table_Name_PK_Field.Tag = "FIELD";

                    foreach (DataRow FK_Row_Next in sql.dataSet.Tables[3].Rows)
                    {
                        if (FK_Row_Next["FK_Table_ID"].ToString() == PK_Row["PK_Table_ID"].ToString())
                        {
                            ADD_FK_Children(PK_Table_Name, FK_Row_Next, Node_Chain);
                            break;
                        }
                    }
                }
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void GET_NODE_PATH(TreeNode Node)
        {
            Node_Path = "";
            Get_Nodes_Path(Node);
            Node_Path += ".";
            Node_Path = Node_Path.Replace(".PK.", ".");
            Node_Path = Node_Path.Replace(".FK.", ".");
            Node_Path = Node_Path.Replace(".FL.", ".");
            Node_Path = Node_Path.Substring(0, Node_Path.Length - 1);
            textBox1.Text = Node_Path;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeView_Selected) return;
            TreeView_Selected = true;
            //---------------------------------
            GET_NODE_PATH(e.Node);
            //---------------------------------
            FIND_Root_PK_Star(treeView2.SelectedNode.Text, false);
            TreeView_Selected = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Table_Filling = true;
            treeView11.Nodes.Clear();
            TreeNode Node_Root = treeView11.Nodes.Add("PK");

            string Find_Text = textBox1.Text.Trim().ToLower();
            FIND_Nodes(Find_Text, 1, null, Node_Root);
            Node_Root.Collapse();

            Node_Root = treeView11.Nodes.Add("FK");
            FIND_Nodes(Find_Text, 2, null, Node_Root);

            treeView11.ExpandAll();
            treeView11.SelectedNode = treeView11.Nodes[0];
            Table_Filling = false;
        }
        private void FIND_Nodes(string Find_Text, int TreeViewN, TreeNode Node_Parent, TreeNode Node_Root)
        {
            TreeNodeCollection myNodeCollection;
            if (Node_Parent == null)
                if (TreeViewN == 1)
                    myNodeCollection = treeView1.Nodes;
                else
                    myNodeCollection = treeView2.Nodes;
            else
                myNodeCollection = Node_Parent.Nodes;

            IEnumerator myEnumerator = myNodeCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                TreeNode Node_Current = (TreeNode)myEnumerator.Current;
                string Node_Text = Node_Current.Text.ToLower();
                if (Node_Text.IndexOf(Find_Text) > -1)
                {
                    TreeNode PK_Node_Found = Node_Root.Nodes.Add(Node_Current.FullPath);
                    PK_Node_Found.Tag = Node_Current;
                }
                if (Node_Current.Nodes.Count > 0)
                    FIND_Nodes(Find_Text, TreeViewN, Node_Current, Node_Root);
            }
        }

        private void FIND_Tables_In_Node_Path(TreeNode Parent, int Path_ID)
        {
            if (Parent.Tag.ToString() == "FIELD")
            {
                string Field = "", Table = "", SubPath = "";
                Field = Parent.Text;
                if (Parent.Parent.Parent.Tag.ToString() == "TABLE")
                {
                    Table   = Parent.Parent.Parent.Text;
                    SubPath = Parent.FullPath;
                    //-----------------------------------------
                    int Table_ID = 0;
                    foreach (DataRow find_row in dataSet1.Tables["Tables"].Rows)
                    {
                        if (find_row["Table"].ToString()== Table)
                        {
                            Table_ID = int.Parse(find_row["ID"].ToString());
                            find_row["Cross_Count"] = int.Parse(find_row["Cross_Count"].ToString()) + 1;
                            break;
                        }
                    }
                    if (Table_ID == 0)
                    {
                        DataRow New_Row = dataSet1.Tables["Tables"].NewRow();
                        New_Row["Table"] = Table;
                        dataSet1.Tables["Tables"].Rows.Add(New_Row);
                        Table_ID = int.Parse(dataSet1.Tables["Tables"].Rows[dataSet1.Tables["Tables"].Rows.Count - 1]["ID"].ToString());
                    }
                    //-----------------------------------------
                    int Field_ID = 0;
                    foreach (DataRow find_row in dataSet1.Tables["Fields"].Rows)
                    {
                        if ((find_row["Field"].ToString() == Field)&&(find_row["Table_ID"].ToString() == Table_ID.ToString()))
                        {
                            Field_ID = int.Parse(find_row["ID"].ToString());
                            break;
                        }
                    }
                    if (Field_ID == 0)
                    {
                        DataRow New_Row = dataSet1.Tables["Fields"].NewRow();
                        New_Row["Table_ID"] = Table_ID;
                        New_Row["Field"] = Field;
                        dataSet1.Tables["Fields"].Rows.Add(New_Row);
                        Field_ID = int.Parse(dataSet1.Tables["Fields"].Rows[dataSet1.Tables["Fields"].Rows.Count - 1]["ID"].ToString());
                    }
                    //-----------------------------------------
                    int Table_Field_Path_ID = 0;
                    foreach (DataRow find_row in dataSet1.Tables["Table_Field_Path"].Rows)
                    {
                        if ((find_row["Table_ID"].ToString() == Table_ID.ToString()) &&(find_row["Field_ID"].ToString() == Field_ID.ToString()) &&(find_row["Path_ID"].ToString() == Path_ID.ToString()))
                        {
                            Table_Field_Path_ID = int.Parse(find_row["ID"].ToString());
                            break;
                        }
                    }
                    if (Table_Field_Path_ID == 0)
                    {
                        DataRow New_Row = dataSet1.Tables["Table_Field_Path"].NewRow();
                        New_Row["Table_ID"] = Table_ID;
                        New_Row["Field_ID"] = Field_ID;
                        New_Row["Path_ID"] = Path_ID;
                        New_Row["SubPath"] = SubPath;
                        dataSet1.Tables["Table_Field_Path"].Rows.Add(New_Row);
                        Table_Field_Path_ID = int.Parse(dataSet1.Tables["Table_Field_Path"].Rows[dataSet1.Tables["Table_Field_Path"].Rows.Count - 1]["ID"].ToString());
                    }
                }
            }
            if (Parent.Parent != null)
                FIND_Tables_In_Node_Path(Parent.Parent,Path_ID);
        }

        private void ADD_FK_To_Table(TreeNode FK_Node, string Table_Name)
        {
            /*
            bool detected = false;
            TreeNode tree_node = null;
            foreach(TreeNode root_node in treeView3.Nodes)
                if (root_node.Text == Table_Name)
                {
                    detected = true;
                    tree_node = root_node;
                    break;
                }

            TreeNode FK_Table_Name;
            if (!detected)
                FK_Table_Name = treeView3.Nodes.Add(Table_Name);
            else
                FK_Table_Name = tree_node;

            TreeNode new_node = (TreeNode)FK_Node.Clone();

            FK_Table_Name.Nodes.Add(new_node);
            if (toolStripButton8.Checked)
                treeView3.SelectedNode = new_node;
            */
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Table_Filling) return;
            if (TreeView_Selected) return;
            TreeView_Selected = true;
            if (treeView11.SelectedNode.Parent != null)
                if (treeView11.SelectedNode.Parent.Text == "PK")
                {
                    treeView1.SelectedNode = (TreeNode)treeView11.SelectedNode.Tag;
                    FIND_Root_FK_Star(treeView1.SelectedNode.Text);
                    //FIND_Tables_In_Node_Path(treeView1.SelectedNode);
                }
                if (treeView11.SelectedNode.Parent.Text == "FK")
                {
                    treeView2.SelectedNode = (TreeNode)treeView11.SelectedNode.Tag;
                    FIND_Root_PK_Star(treeView2.SelectedNode.Text,false);

                    string FullPath = treeView2.SelectedNode.FullPath;
                    //-----------------------------------------
                    int Path_ID = 0;
                    foreach (DataRow find_row in dataSet1.Tables["Paths"].Rows)
                    {
                        if (find_row["Path"].ToString() == FullPath)
                        {
                            Path_ID = int.Parse(find_row["ID"].ToString());
                            break;
                        }
                    }
                    if (Path_ID == 0)
                    {
                        DataRow New_Row = dataSet1.Tables["Paths"].NewRow();
                        New_Row["Path"] = FullPath;
                        dataSet1.Tables["Paths"].Rows.Add(New_Row);
                        Path_ID = int.Parse(dataSet1.Tables["Paths"].Rows[dataSet1.Tables["Paths"].Rows.Count - 1]["ID"].ToString());
                    }
                    FIND_Tables_In_Node_Path(treeView2.SelectedNode,Path_ID);
                }
            TreeView_Selected = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
            {
                dataSet1.ReadXml(FileName);
                dataGridView1.DataSource = dataSet1.Tables["ServerTypes"].DefaultView;
                dataGridView2.DataSource = dataSet1.Tables["Connections"].DefaultView;
                dataGridView2.Rows[0].Cells[0].Selected = true;
                DV1 = new DataView(dataSet1.Tables["Tables"]);
                DV2 = new DataView(dataSet1.Tables["Fields"]);
                DV3 = new DataView(dataSet1.Tables["Table_Field_Path"]);
                DV4 = new DataView(dataSet1.Tables["Paths"]);
                dataGridView3.DataSource = DV1;
                dataGridView4.DataSource = DV2;
                dataGridView5.DataSource = DV3;
                dataGridView6.DataSource = DV4;
            }
            if (File.Exists(ms_sql_table_stars_script_FileName))
                richTextBox2.LoadFile(ms_sql_table_stars_script_FileName, RichTextBoxStreamType.PlainText);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataSet1.WriteXml(FileName);
            richTextBox2.SaveFile(ms_sql_table_stars_script_FileName, RichTextBoxStreamType.PlainText);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            dataSet1.WriteXml(FileName);
        }

        private void cOPYNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COPY_TO_Clipboard(treeView1.SelectedNode);
        }

        private void Get_Text_Node_Tree(TreeNode Parent, int indent)
        {
            string Space = "" ;
            for (uint i = 0; i < indent; i++)
                Space += "\t";

            Text_Node_Tree = Text_Node_Tree + Space + Parent.Text+"\r\n";
            if (Parent.Nodes.Count > 0)
                foreach(TreeNode child in Parent.Nodes)
                    Get_Text_Node_Tree(child, indent+1);
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            COPY_TO_Clipboard(treeView2.SelectedNode);
        }

        private void COPY_TO_Clipboard(TreeNode Parent)
        {
            Text_Node_Tree = "";
            Get_Text_Node_Tree(Parent, 0);
            Clipboard.SetText(Text_Node_Tree);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox1.Text + "\r\n" + richTextBox1.Text;
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            treeView2.CollapseAll();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //treeView3.CollapseAll();
        }

        private void toolStripButton3_Click_2(object sender, EventArgs e)
        {
            //treeView3.Nodes.Clear();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            /*foreach(TreeNode Parent in treeView3.Nodes)
            {
                foreach(TreeNode Child in Parent.Nodes)
                    Child.Text = Child.Text + " [MARK]";
            }*/
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //toolStripButton8.Checked = !toolStripButton8.Checked;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DV2.RowFilter = null;
            DV3.RowFilter = null;
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count == 0) return;
            if (dataGridView3.SelectedRows.Count == 0) return;
            string Table_ID = dataGridView3.SelectedRows[0].Cells["ID"].Value.ToString();
            DV2.RowFilter = "Table_ID=" + Table_ID;
            DV3.RowFilter = "Table_ID=" + Table_ID;
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count == 0) return;
            if (dataGridView4.SelectedRows.Count == 0) return;
            string Field_ID = dataGridView4.SelectedRows[0].Cells["ID"].Value.ToString();
            string Table_ID = dataGridView4.SelectedRows[0].Cells["Table_ID"].Value.ToString();
            DV3.RowFilter = "Table_ID=" + Table_ID + " AND Field_ID=" + Field_ID;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Remove(dataGridView3.SelectedRows[0]);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Remove(dataGridView4.SelectedRows[0]);
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click_3(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click_2(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {
            dataGridView5.Rows.Remove(dataGridView5.SelectedRows[0]);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            dataGridView6.Rows.Remove(dataGridView6.SelectedRows[0]);
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //treeView3.Nodes.Remove(treeView3.SelectedNode);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dataSet1.Tables["Table_Field_Path"].Rows.Clear();
            dataSet1.Tables["Fields"].Rows.Clear();
            dataSet1.Tables["Tables"].Rows.Clear();
            dataSet1.Tables["Paths"].Rows.Clear();
        }
    }
}
