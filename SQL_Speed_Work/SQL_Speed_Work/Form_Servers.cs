using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQL_Speed_Work
{
    public partial class Form_Servers : Form
    {
        public Form_Servers()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataSet101.EndInit();
        }
    }
}
