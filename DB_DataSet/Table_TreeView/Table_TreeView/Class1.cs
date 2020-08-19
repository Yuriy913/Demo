using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Table_TreeView
{
    public class Table_TreeView
    {
        public void Load_Table_To_TreeView(DataTable dt, TreeView TreeView, TreeNode ParentNode = null, string Field_ID = "ID", string Field_ParentID = "ParentID", string Field_Name = "Name")
        {
            if (Field_ID == null) Field_ID = "ID";
            if (Field_ParentID == null) Field_ParentID = "ParentID";
            if (Field_Name == null) Field_Name = "Name";
            if ((TreeView == null) && (ParentNode == null))
                return;
            if ((TreeView != null) && (ParentNode != null))
                ParentNode = null;
            if (TreeView != null)
                if (TreeView.Nodes.Count > 0)
                    TreeView.Nodes.Clear();
            try
            {
                DataRow[] rows = dt.Select(Field_ParentID + "=" + (ParentNode == null ? "0" : ParentNode.Tag.ToString()));
                foreach (DataRow row in rows)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = row[Field_ID].ToString();
                    node.Text = row[Field_Name].ToString();
                    if (ParentNode == null)
                        TreeView.Nodes.Add(node);
                    else
                        ParentNode.Nodes.Add(node);
                    Load_Table_To_TreeView(dt, null, node, Field_ID, Field_ParentID, Field_Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

    }
}
