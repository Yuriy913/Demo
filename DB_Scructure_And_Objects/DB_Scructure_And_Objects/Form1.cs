using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DB_Scructure_And_Objects
{
    public partial class Form1 : Form
    {
        #region Variables
            DataSet1 dataSet1 = new DataSet1();
            string DataSet1_FileSpec = @"c:\Solutions\XML\DB_Structure_And_Objects\DataSet1.xml";
            DataView DV_Fields, DV_Links;
            String Table_Chain = "";
            string Dir_DB_Objects = @"c:\Databases\Asset_Manager\";
        bool table_oppening = true;
        TreeNode NewNode;//, ParentNode;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table_oppening = true;
            if (File.Exists(DataSet1_FileSpec))
                dataSet1.ReadXml(DataSet1_FileSpec);
            dataGridView1.DataSource = dataSet1.Tables["Tables"].DefaultView;

            dataGridView5.DataSource = dataSet1.Tables["Found_Tables"].DefaultView;
            dataGridView6.DataSource = dataSet1.Tables["Found_Fields"].DefaultView;
            dataGridView7.DataSource = dataSet1.Tables["Found_Links"].DefaultView;
            //---------------------------------------------------------------
            DV_Fields = new DataView(dataSet1.Tables["Fields"]);
            DV_Fields.RowFilter = "TableID=1";
            DV_Fields.Sort = "SqlName";
            dataGridView2.DataSource = DV_Fields;

            DV_Links = new DataView(dataSet1.Tables["Links"]);
            DV_Links.RowFilter = "TableID=1";
            DV_Links.Sort = "SqlName";
            dataGridView3.DataSource = DV_Links;
            //---------------------------------------------------------------

            dataGridView4.DataSource = dataSet1.Tables["Indixes"].DefaultView;

            table_oppening = false;
            dataGridView1_SelectionChanged(sender, e);
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://metanit.com/sharp/tutorial/16.2.php
            //http://csharp.net-informations.com/xml/how-to-read-xml.htm
            //http://www.java2s.com/Code/CSharp/XML/Loadxmldocumentfromxmlfile.htm
            //----------------------------------------------------------------
            //----------------------------------------
            // Part 1
            //----------------------------------------

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Dir_DB_Objects+"gbbase.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                //MessageBox.Show(xnode.Attributes.Count.ToString());
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("sqlname");
                    XmlNode attr2 = null;
                    XmlNode attr3 = null;
                    XmlNode attr4 = null;
                    try
                    {
                        attr2 = xnode.Attributes.GetNamedItem("name");
                        attr3 = xnode.Attributes.GetNamedItem("mainfield"); //attr3.Value //mainfield
                        attr4 = xnode.Attributes.GetNamedItem("mainindex");
                    }
                    catch
                    {
                        MessageBox.Show("CATCHED ERROR !!!");
                    }
                    if (attr != null)
                    {
                        bool Detected = false;
                        int TableID = 0;
                        foreach (DataRow row in dataSet1.Tables["Tables"].Rows)
                        {
                            if (row["Name"].ToString() == attr.Value)
                            {
                                Detected = true;
                                TableID = (int)row["ID"];
                                break;
                            }
                        }
                        if (!Detected)
                        {
                            DataRow newRow = dataSet1.Tables["Tables"].NewRow();
                            newRow["SqlName"] = attr.Value;
                            newRow["Name"]    = attr2.Value;
                            dataSet1.Tables["Tables"].Rows.Add(newRow);
                            //если не пойдет то определить последний номер и к нему прибавить 1
                            TableID = (int)newRow["ID"];
                        }

                        // обходим все дочерние узлы элемента user
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "field")
                            {
                                if (childnode.Attributes.Count > 0)
                                {
                                    //listBox1.Items.Add();
                                    string SqlName = childnode.Attributes["sqlname"].Value;
                                    string Name = childnode.Attributes["name"].Value;

                                    string Type = childnode.Attributes["type"].Value;
                                    string Size = childnode.Attributes["size"].Value;

                                    string UserType = "", UserTypeFormat = "";
                                    
                                    //if (TableID == 52)
                                    //{
                                    //    Size = childnode.Attributes["size"].Value;
                                    //}
                                    //if (attr.Value != null)
                                      //  if (attr.Value == "amWfSysActiv")
                                        //{
                                          //  UserType = childnode.Attributes["usertype"].Value;
                                       // }
                                    //
                                    try {
                                        UserType = childnode.Attributes["usertype"].Value;
                                        UserTypeFormat = childnode.Attributes["usertypeformat"].Value;
                                    }
                                    catch { }

                                    //MessageBox.Show(SqlName);
                                    if (SqlName != null)
                                        if (SqlName != "")
                                            if (attr3 != null)
                                                ADD_Field(TableID, SqlName, Name, attr3.Value,Type,Size, UserType, UserTypeFormat);//attr3.Value -- mainfield
                                            else
                                                ADD_Field(TableID, SqlName, Name, "", Type, Size);
                                }
                                else { }
                            }
                            else
                            if (childnode.Name == "link")
                            {
                                if (childnode.Attributes.Count > 0)
                                {
                                    string SqlName = childnode.Attributes["sqlname"].Value;
                                    string Name = childnode.Attributes["name"].Value;

                                    string DestTable = "";
                                    string DestField = "";
                                    string SrcField = "";
                                    string Type = "";
                                    string UserType = "";
                                    string Reverse = "";
                                    string TypeField = "";

                                    try
                                    {
                                        SrcField = childnode.Attributes["srcfield"].Value;
                                        Type = childnode.Attributes["type"].Value;
                                        UserType = childnode.Attributes["usertype"].Value;
                                    }
                                    catch (Exception ex)
                                    {
                                        listBox1.Items.Add("ERROR : Get General arg of Link");
                                        listBox1.Items.Add("Table: " + attr.Value);
                                        listBox1.Items.Add("Link : " + SqlName);
                                        listBox1.Items.Add(ex.Message);
                                    }

                                    try
                                    {
                                        TypeField = childnode.Attributes["typefield"].Value;
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                    try
                                    {
                                        Reverse = childnode.Attributes["reverse"].Value;
                                    }
                                    catch (Exception ex)
                                    {
                                    }


                                    try
                                    {
                                        DestTable = childnode.Attributes["desttable"].Value;
                                        DestField = childnode.Attributes["destfield"].Value;
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                    string Card11 = "";
                                    string RelTable = "";
                                    string RelDstField = "";
                                    string RelSrcField = "";

                                    try
                                    { 
                                        Card11 = childnode.Attributes["card11"].Value; } 
                                    catch (Exception ex)
                                    {
                                    }

                                    try {
                                        RelTable = childnode.Attributes["reltable"].Value;
                                        RelDstField = childnode.Attributes["reldstfield"].Value;
                                        RelSrcField = childnode.Attributes["relsrcfield"].Value;
                                    }
                                    catch (Exception ex) 
                                    {
                                    }

                                    if (SqlName != null)
                                        if (SqlName !="")
                                            ADD_Link(TableID, SqlName, Name, DestTable, DestField, SrcField, Type, UserType, Reverse, Card11, RelTable, RelDstField, RelSrcField, TypeField);
                                }
                                else { }
                            }
                            else
                            if (childnode.Name == "index")
                            {
                                // Console.WriteLine($"Возраст: {childnode.InnerText}");
                                //ADD_TableObject(TableID, 3,"Name");
                            }
                        }
                        //--------------------------------------------------------------------
                    }
                }
            }

            //----------------------------------------
            // Part 2
            //----------------------------------------
            xDoc = new XmlDocument();
            xDoc.Load(Dir_DB_Objects+"amProject_en.xml");
            xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                //MessageBox.Show(xnode.Attributes.Count.ToString());
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("sqlname");
                    XmlNode attr2 = null;
                    try
                    {
                        attr2 = xnode.Attributes.GetNamedItem("desc");
                    }
                    catch
                    {
                        //MessageBox.Show("CATCHED ERROR !!!");
                    }
                    if ((attr != null)&&(attr2 != null))
                    {
                        foreach (DataRow row in dataSet1.Tables["Tables"].Rows)
                        {
                            if (row["Name"].ToString() == attr.Value)
                            {
                                row["Desc"] = attr2.Value;
                                break;
                            }
                        }
                        //--------------------------------------------------------------------
                    }
                }
            }

            //---------------------------------------
            listBox1.Items.Add("Finished Import.");
        }

        private void ADD_Field(int TableID, string SqlName, string Name, string MainField, string Type="", string Size="", string UserType="", string UserTypeFormat="")
        {
            bool Detected = false;
            DataRow rowDetected = null;
            foreach (DataRow row in dataSet1.Tables["Fields"].Rows)
                if (((int)row["TableID"] == TableID) && ((string)row["SqlName"] == SqlName))
                {
                    Detected = true;
                    rowDetected = row;
                    break;
                }

            if (!Detected)
            {
                //MessageBox.Show("NOT DETECTED FIELD");
                DataRow NewRow = dataSet1.Tables["Fields"].NewRow();
                NewRow["TableID"] = TableID;
                NewRow["SqlName"] = SqlName;
                NewRow["Name"] = Name;
                NewRow["Type"] = Type;
                NewRow["Size"] = Size;
                if (SqlName== MainField)
                    NewRow["NPF"] = 1;
                else
                    if (Name.IndexOf('l')==0)
                        NewRow["NPF"] = 2;
                NewRow["UserType"] = UserType;
                NewRow["UserTypeFormat"] = UserTypeFormat;
                dataSet1.Tables["Fields"].Rows.Add(NewRow);
            }
            else //UPDATE ROW With Addition Fields
            {
                /*
                if (SqlName == MainField)
                {
                    if (rowDetected != null)
                    {
                        try
                        {
                            rowDetected["NPF"] = 1;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                if (Type !="")
                {
                    if (rowDetected != null)
                    {
                        try
                        {
                            rowDetected["Type"] = Type;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                if (Size != "")
                {
                    if (rowDetected != null)
                    {
                        try
                        {
                            rowDetected["Size"] = Size;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }*/
            }
        }

        private void ADD_Link(int TableID, string SqlName, string Name, string DestTable, string DestField, string SrcField, string Type, string UserType, string Reverse, string Card11, string RelTable, string RelDstField, string RelSrcField, string TypeField)
        {
            bool Detected = false;
            DataRow rowDetected = null;
            foreach (DataRow row in dataSet1.Tables["Links"].Rows)
                if (((int)row["TableID"] == TableID) && ((string)row["SqlName"] == SqlName))
                {
                    //listBox1.Items.Add("Link DETECTED");
                    Detected = true;
                    rowDetected = row;
                    break;
                }

            if (!Detected)
            {
                //MessageBox.Show("ADD LINK");
                //MessageBox.Show("NOT DETECTED FIELD");
                DataRow NewRow = dataSet1.Tables["Links"].NewRow();
                try
                {
                    NewRow["TableID"] = TableID;
                    NewRow["SqlName"] = SqlName;
                    NewRow["Name"] = Name;
                    NewRow["DestTable"] = DestTable;
                    NewRow["DestField"] = DestField;
                    NewRow["SrcField"] = SrcField;
                    NewRow["Type"] = Type;
                    NewRow["UserType"] = UserType;
                    NewRow["Reverse"] = Reverse;
                    NewRow["Card11"] = Card11;
                    NewRow["RelTable"] = RelTable;
                    NewRow["RelDstField"] = RelDstField;
                    NewRow["RelSrcField"] = RelSrcField;
                    NewRow["TypeField"] = TypeField;
                    dataSet1.Tables["Links"].Rows.Add(NewRow);
                    //listBox1.Items.Add("LINK ADDED");
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("FROM Add Link");
                    listBox1.Items.Add(ex.Message);
                }

            }
            else //UPDATE ROW With Addition Fields
            {
                /*
                if (SqlName == MainField)
                {
                    if (rowDetected != null)
                    {
                        try
                        {
                            rowDetected["NPF"] = 1;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                if (Type !="")
                {
                    if (rowDetected != null)
                    {
                        try
                        {
                            rowDetected["Type"] = Type;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                if (Size != "")
                {
                    if (rowDetected != null)
                    {
                        try
                        {
                            rowDetected["Size"] = Size;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }*/
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataSet1.WriteXml(DataSet1_FileSpec);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Find_Table_From(-1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Find_Table_From(dataGridView1.SelectedRows[0].Index);
        }


        private void Find_Table_From(int Start_Index)
        {
            //MessageBox.Show("HERE");
            string table_name = toolStripTextBox1.Text.Trim().ToLower();
            bool Found = false;
            string TableName_Value = "", Original_TableName="";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index > Start_Index)
                {
                    Original_TableName = row.Cells["Name"].Value.ToString();
                    TableName_Value = Original_TableName.ToLower();
                    if (TableName_Value.IndexOf(table_name) > -1)
                    {
                        Found = true;
                        dataGridView1.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            if (Found)
            {
                toolStripButton2.Enabled = true;
                //toolStripTextBox3.Text = Original_TableName;
                if (table_name == TableName_Value)
                {
                    toolStripTextBox1.BackColor = Color.Lime;
                }else
                    toolStripTextBox1.BackColor = Color.White;

            }
            else
            {
                toolStripButton2.Enabled = false;
                //toolStripTextBox3.Text = "---NOT FOUND---";
                toolStripTextBox1.BackColor = Color.White;
            }

        }


        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            //toolStripTextBox3.SelectAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Find_Field_From(-1, toolStripTextBox2.Text.Trim().ToLower(), dataGridView2, toolStripButton4, toolStripTextBox2);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Find_Field_From(dataGridView2.SelectedRows[0].Index, toolStripTextBox2.Text.Trim().ToLower(), dataGridView2, toolStripButton4, toolStripTextBox2);
        }

        private void Find_Field_From(int Start_Index, string field_name, DataGridView dataGridView, ToolStripButton Next_Find, ToolStripTextBox Field_Text)
        {
            bool Found = false;
            string fieldName_Value = "", sql_name_value="", name_value="";
            string Original_name_value = "";
            string Original_sql_name_value = "";
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Index > Start_Index)
                {
                    Original_name_value = row.Cells["Name"].Value.ToString();
                    fieldName_Value = Original_name_value.ToLower();
                    name_value = fieldName_Value;

                    Original_sql_name_value = row.Cells["SqlName"].Value.ToString();
                    fieldName_Value = Original_sql_name_value.ToLower();
                    sql_name_value = fieldName_Value;

                    if (fieldName_Value.IndexOf(field_name) > -1)
                    {
                        Found = true;
                        dataGridView.Rows[row.Index].Selected = true;
                        break;
                    }

                    fieldName_Value = row.Cells["Name"].Value.ToString().ToLower();
                    if (fieldName_Value.IndexOf(field_name) > -1)
                    {
                        Found = true;
                        dataGridView.Rows[row.Index].Selected = true;
                        break;
                    }

                }
            }
            if (Found)
            {
                Next_Find.Enabled = true;
                if (field_name == fieldName_Value)
                {
                    Field_Text.BackColor = Color.Lime;
                }
                else
                    Field_Text.BackColor = Color.White;

                Field_Text.BackColor = Color.Lime;
            }
            else
            {
                Next_Find.Enabled = false;
                Field_Text.BackColor = Color.White;
            }

        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            //toolStripTextBox4.Text = dataGridView2.SelectedRows[0].Cells["SqlName"].Value.ToString();
            //toolStripTextBox9.Text = dataGridView2.SelectedRows[0].Cells["Name"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = treeView1.SelectedNode;
            string FullPath = SelectedNode.FullPath;
            FullPath = FullPath.Replace(".Fields", "");
            FullPath = FullPath.Replace(".Primary Key", "");
            FullPath = FullPath.Replace(".Foreign Keys", "");
            FullPath = FullPath.Replace(".Links", "");
            int pos = FullPath.IndexOf("Table:");
            if (pos > -1)
                FullPath = FullPath.Substring(0, pos-1);
            textBox1.Text = FullPath;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text += textBox1.Text+ "\r\n";
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = "SqlName : " + dataGridView2.SelectedRows[0].Cells["SqlName"].Value.ToString() + "\r\n";
                richTextBox2.Text += "Name : " + dataGridView2.SelectedRows[0].Cells["Name"].Value.ToString() + "\r\n";
                richTextBox2.Text += "Type : " + dataGridView2.SelectedRows[0].Cells["Type"].Value.ToString() + "\r\n";
                richTextBox2.Text += "Size : " + dataGridView2.SelectedRows[0].Cells["Size"].Value.ToString();
            }
            catch { }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (table_oppening) return;
            if (dataGridView3.SelectedRows.Count == 0) return;

            string LinkPath = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            LinkPath += "." + dataGridView3.SelectedRows[0].Cells["SrcField"].Value.ToString();

            if (dataGridView3.SelectedRows[0].Cells["RelTable"].Value.ToString() != "")
            {
                LinkPath += " -> " + dataGridView3.SelectedRows[0].Cells["RelTable"].Value.ToString();
                LinkPath += "." + dataGridView3.SelectedRows[0].Cells["RelSrcField"].Value.ToString();

                LinkPath += " -> " + dataGridView3.SelectedRows[0].Cells["RelTable"].Value.ToString();
                LinkPath += "." + dataGridView3.SelectedRows[0].Cells["RelDstField"].Value.ToString();
            }

            LinkPath += " -> " + dataGridView3.SelectedRows[0].Cells["DestTable"].Value.ToString();
            LinkPath += "." + dataGridView3.SelectedRows[0].Cells["DestField"].Value.ToString();

            string TablePath = dataGridView1.SelectedRows[0].Cells["SqlName"].Value.ToString();
            TablePath += "." + dataGridView3.SelectedRows[0].Cells["SrcField"].Value.ToString();

            if (dataGridView3.SelectedRows[0].Cells["RelTable"].Value.ToString() != "")
            {
                TablePath += " -> " + dataGridView3.SelectedRows[0].Cells["RelTable"].Value.ToString();
                TablePath += "." + dataGridView3.SelectedRows[0].Cells["RelSrcField"].Value.ToString();

                TablePath += " -> " + dataGridView3.SelectedRows[0].Cells["RelTable"].Value.ToString();
                TablePath += "." + dataGridView3.SelectedRows[0].Cells["RelDstField"].Value.ToString();
            }

            TablePath += " -> " + dataGridView3.SelectedRows[0].Cells["DestTable"].Value.ToString();
            TablePath += "." + dataGridView3.SelectedRows[0].Cells["DestField"].Value.ToString();

            try
            {
                richTextBox4.Text = LinkPath + "\r\n";
                richTextBox4.Text += TablePath;
            }
            catch { }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.BackColor = Color.White;
            toolStripTextBox1.SelectAll();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (table_oppening) return;
            string ID = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            Table_Chain = "."+ dataGridView1.SelectedRows[0].Cells["SqlName"].Value.ToString() + ".";
            DV_Fields.RowFilter = "TableID=" + ID;
            DV_Links.RowFilter = "TableID=" + ID;
            //---------------------
            string TableName = dataGridView1.SelectedRows[0].Cells["SqlName"].Value.ToString();
            treeView1.Nodes.Clear();
            //Count_Levels = 2;
            ADD_Child_Objects("", null, TableName);
            //-----------------------------------
            treeView1.Nodes[0].Expand();
            //-----------------------------------
            try
            {
                richTextBox3.Text = "SqlName : " + dataGridView1.SelectedRows[0].Cells["SqlName"].Value.ToString() + "\r\n";
                richTextBox3.Text += "Name : " + dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString() + "\r\n";
                richTextBox3.Text += "Desc : " + dataGridView1.SelectedRows[0].Cells["Desc"].Value.ToString();
            }
            catch { }
        }

        void ADD_Child_Objects(string Table_Chain, TreeNode ParentNode, string NextTable_SqlName, int Count_Levels = 0)
        {
            Count_Levels++;
            if (Count_Levels == 3)
              return;

            if (Table_Chain.IndexOf("." + NextTable_SqlName + ".") > -1)
            {
                ParentNode.Nodes.Add("STOP : RING : "+ NextTable_SqlName);
                return;
            }
            Table_Chain += "." + NextTable_SqlName + ".";
            //listBox1.Items.Add(Table_Chain);
            //listBox1.Items.Add(NextTable_SqlName);
            //----------------------
            TreeNode Child_NewNode = new TreeNode(NextTable_SqlName);
            if (ParentNode == null)
            {
                ParentNode = treeView1.Nodes.Add(NextTable_SqlName);
            }
            else
            {
                Child_NewNode.Text = "Table: " + Child_NewNode.Text;
                ParentNode.Nodes.Add(Child_NewNode);
            }
            //----------------------
            int TableID = 0;
            DataRow[] Rows = dataSet1.Tables["Tables"].Select("Name = '"+ NextTable_SqlName+"'");
            if (Rows.Length == 1)
                TableID = int.Parse(Rows[0]["ID"].ToString());
            else
                return;
            //----------------------
            DataRow[] Fields = dataSet1.Tables["Fields"].Select("TableID=" + TableID.ToString(), "SqlName");
            DataRow[] Links = dataSet1.Tables["Links"].Select("TableID=" + TableID.ToString(), "SqlName");
            //----------------------
            TreeNode NODE_PrimaryKey = new TreeNode("Primary Key");
            ParentNode.Nodes.Add(NODE_PrimaryKey);

            //MessageBox.Show(DGV_Fields.Rows.Count.ToString());

            foreach (DataRow field in Fields)
                if (int.Parse(field["NPF"].ToString()) == 1)
                {
                    NewNode = new TreeNode(field["SqlName"].ToString());
                    NODE_PrimaryKey.Nodes.Add(NewNode);
                    break;
                }

            TreeNode FieldsNode = new TreeNode("Fields");
            ParentNode.Nodes.Add(FieldsNode);
            foreach (DataRow field in Fields)
                if (int.Parse(field["NPF"].ToString()) == 0)
                {
                    NewNode = new TreeNode(field["SqlName"].ToString());
                    FieldsNode.Nodes.Add(NewNode);
                }

            TreeNode ForeignKeysNode = new TreeNode("Foreign Keys");
            ParentNode.Nodes.Add(ForeignKeysNode);
            foreach (DataRow field in Fields)
                if (int.Parse(field["NPF"].ToString()) == 2)
                {
                    NewNode = new TreeNode(field["SqlName"].ToString());
                    ForeignKeysNode.Nodes.Add(NewNode);
                }

            TreeNode LinksNode = new TreeNode("Links");
            ParentNode.Nodes.Add(LinksNode);

            foreach (DataRow link in Links)
            {
                TreeNode NewNode = new TreeNode(link["SqlName"].ToString());
                LinksNode.Nodes.Add(NewNode);
                string DestTable = link["DestTable"].ToString();
                ADD_Child_Objects(Table_Chain, NewNode, DestTable, Count_Levels);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            dataSet1.Tables["Links"].Rows.Clear();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string FindFiled = toolStripTextBox10.Text;
            foreach(DataRow row in dataSet1.Tables["Fields"].Rows)
            {
                if (row["SqlName"].ToString() == FindFiled)
                {
                    int TableID = (int)row["TableID"];
                    foreach(DataRow TableRow in dataSet1.Tables["Tables"].Rows)
                    {
                        if ((int)TableRow["ID"] == TableID)
                        {
                            richTextBox1.Text += TableRow["SqlName"].ToString()+"\r\n";
                            break;
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            FIND_Rows();
        }

        private void FIND_Rows (bool FindLike = true)
        {
            string Find_Text = toolStripTextBox11.Text.Trim();
            dataSet1.Tables["Found_Tables"].Rows.Clear();
            dataSet1.Tables["Found_Fields"].Rows.Clear();
            dataSet1.Tables["Found_Links"].Rows.Clear();

            DataRow[] found_rows;
            if (FindLike)
                found_rows = dataSet1.Tables["Tables"].Select("SqlName LIKE '%" + Find_Text + "%'");
            else
                found_rows = dataSet1.Tables["Tables"].Select("SqlName = '" + Find_Text + "'");
            if (found_rows.Length > 0)
            {

                foreach (DataRow found_row in found_rows)
                {
                    DataRow New_Row = dataSet1.Tables["Found_Tables"].NewRow();
                    //New_Row["ID"] = found_row["ID"].ToString();
                    New_Row["Name"] = found_row["Name"].ToString();
                    New_Row["SqlName"] = found_row["SqlName"].ToString();
                    dataSet1.Tables["Found_Tables"].Rows.Add(New_Row);
                }
            }
            //----------------------------------------------------------------------
            if (FindLike)
                found_rows = dataSet1.Tables["Fields"].Select("SqlName LIKE '%" + Find_Text + "%'");
            else
                found_rows = dataSet1.Tables["Fields"].Select("SqlName LIKE '" + Find_Text + "'");
            if (found_rows.Length > 0)
            {
                foreach (DataRow found_row in found_rows)
                {
                    DataRow New_Row = dataSet1.Tables["Found_Fields"].NewRow();
                    //New_Row["ID"] = found_row["ID"].ToString();
                    string TableName = "";
                    DataRow[] found_table = dataSet1.Tables["Tables"].Select("ID =" + found_row["TableID"].ToString());
                    if (found_table.Length > 0)
                        TableName = found_table[0]["SqlName"].ToString();
                    New_Row["TableName"] = TableName;
                    New_Row["Name"] = found_row["Name"].ToString();
                    New_Row["SqlName"] = found_row["SqlName"].ToString();
                    dataSet1.Tables["Found_Fields"].Rows.Add(New_Row);
                }
            }
            //----------------------------------------------------------------------
            if (FindLike)
                found_rows = dataSet1.Tables["Links"].Select("SqlName LIKE '%" + Find_Text + "%'");
            else
                found_rows = dataSet1.Tables["Links"].Select("SqlName = '" + Find_Text + "'");
            if (found_rows.Length > 0)
            {
                foreach (DataRow found_row in found_rows)
                {
                    DataRow New_Row = dataSet1.Tables["Found_Links"].NewRow();
                    string TableName = "";
                    DataRow[] found_table = dataSet1.Tables["Tables"].Select("ID =" + found_row["TableID"].ToString());
                    if (found_table.Length > 0)
                        TableName = found_table[0]["SqlName"].ToString();
                    New_Row["TableName"] = TableName;
                    New_Row["Name"] = found_row["Name"].ToString();
                    New_Row["SqlName"] = found_row["SqlName"].ToString();
                    dataSet1.Tables["Found_Links"].Rows.Add(New_Row);
                }
            }
            //----------------------------------------------------------------------

        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            string List_Of_Fields = "";
            foreach(DataGridViewRow viewRow in dataGridView2.Rows)
            {
                List_Of_Fields += ","+viewRow.Cells["SqlName"].Value.ToString();
            }
            textBox2.AppendText(List_Of_Fields);
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            FIND_Rows(false);
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            richTextBox5.LoadFile(Dir_DB_Objects+"gbbase.xml", RichTextBoxStreamType.PlainText);
            tabControl4.SelectedIndex = 0;
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            tabControl4.SelectedIndex = 0;
            //amWfSysActiv
            int FromPos = int.Parse(toolStripTextBox13.Text);
            int LenRich = richTextBox5.TextLength;
            int pos = richTextBox5.Find(toolStripTextBox12.Text.Trim(), FromPos, LenRich, RichTextBoxFinds.MatchCase);
            toolStripTextBox13.Text = pos.ToString();
            if (pos > 0)
            {
                richTextBox5.SelectionStart = pos;
                richTextBox5.SelectionLength = toolStripTextBox12.Text.Trim().Length;
                richTextBox5.Select(richTextBox5.SelectionStart, richTextBox5.SelectionLength);
                richTextBox5.ScrollToCaret();
                richTextBox5.Focus();
            }
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Dir_DB_Objects+"gbbase.xml");
            tabControl4.SelectedIndex = 1;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach(DataRow row in dataSet1.Tables["Fields"].Rows)
            {
                if ((row["SqlName"].ToString().IndexOf('l') == 0)
                && (row["NPF"].ToString() != "1"))
                    row["NPF"] = 2;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataSet1.Tables["Fields"].Rows.Clear();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Find_Field_From(-1, toolStripTextBox6.Text.Trim().ToLower(), dataGridView3, toolStripButton9, toolStripTextBox6);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.SelectAll();
        }

        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {
            toolStripTextBox6.SelectAll();
        }

        private void toolStripTextBox8_Click(object sender, EventArgs e)
        {
            toolStripTextBox8.SelectAll();
        }

        private void toolStripTextBox11_Click(object sender, EventArgs e)
        {
            toolStripTextBox11.SelectAll();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Find_Field_From(dataGridView3.SelectedRows[0].Index, toolStripTextBox6.Text.Trim().ToLower(), dataGridView3, toolStripButton9, toolStripTextBox6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

    }
}
