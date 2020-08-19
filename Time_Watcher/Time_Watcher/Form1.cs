using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Watcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "hh:mm:ss";
            dateTimePicker2.Value = dateTimePicker1.Value;

            button1.Enabled = false;
            button1.BackColor = Color.Silver;
            button2.Enabled = true;
            button2.BackColor = Color.Lime;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "hh:mm:ss";
            dateTimePicker3.Value = dateTimePicker1.Value;

            double diff = Math.Round(dateTimePicker3.Value.Subtract(dateTimePicker2.Value).TotalSeconds, 0);

            int Mins = (int)Math.Round((diff / 60), 0);
            int Secs = (int)Math.Round((diff % 60), 0);

            string sSecs = "";
            if (Secs < 10) sSecs = "0";
            sSecs += Secs.ToString();
            comboBox1.Text = Mins.ToString() + ":" + sSecs;
            comboBox1.Items.Add(comboBox1.Text);

            button1.Enabled = false;
            button2.Enabled = false;
            button2.BackColor = Color.Silver;
            button3.Enabled = true;
            button3.BackColor = Color.Lime;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = " ";
            dateTimePicker3.CustomFormat = " ";
            comboBox1.Text = "";

            button1.Enabled = true;
            button1.BackColor = Color.Lime;
            button2.Enabled = false;
            button3.Enabled = false;
            button3.BackColor = Color.Silver;

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
