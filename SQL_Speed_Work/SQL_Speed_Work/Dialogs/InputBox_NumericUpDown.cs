﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQL_Speed_Work.Dialogs
{
    public partial class InputBox_NumericUpDown : Form
    {
        public string Caption = "";
        public decimal Value = -1;
        public InputBox_NumericUpDown()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value = numericUpDown1.Value;
            Close();
        }

        private void InputBox_NumericUpDown_Load(object sender, EventArgs e)
        {
            l_Caption.Text = Caption;
        }
    }
}
