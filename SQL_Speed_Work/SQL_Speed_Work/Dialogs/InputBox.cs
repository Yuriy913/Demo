using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQL_Speed_Work.Dialogs
{
    public partial class InputBox : Form
    {
        public string Caption = "";
        public string Value = "";
        public InputBox()
        {
            InitializeComponent();
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            l_Caption.Text = Caption;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Value = tB_Value.Text;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
