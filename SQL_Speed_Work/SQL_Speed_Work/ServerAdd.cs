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
    public partial class ServerAdd : Form
    {
        string serverName = "";
        string connectionString = "";
        string dataBase = "";
        public ServerAdd()
        {
            InitializeComponent();
        }

        public string DataBase
        {
            get { return dataBase; }
            set { dataBase = value; }
        }

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerName = tB_ServerName.Text;
            ConnectionString = tB_ConnectionString.Text;
            DataBase = tB_DataBase.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServerAdd_Load(object sender, EventArgs e)
        {
            //http://blogs.msdn.com/b/dchandnani/archive/2005/03/09/391308.aspx
        }
    }
}
