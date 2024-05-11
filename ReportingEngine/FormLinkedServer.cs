using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POP.Dao;
using System.Threading;

namespace ReportingEngine
{
    public partial class FormLinkedServer : Form
    {
        public FormLinkedServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DaoLinkedServer server = new DaoLinkedServer();
            DaoPopStore daoStore = new DaoPopStore();

            DataTable table = daoStore.Get_Store_Data(0);

            foreach (DataRow dr in table.Rows)
            {
                string store_ip = dr["IP"].ToString().Trim();
                server.RunSP_Linked_Server(store_ip);
                Thread.Sleep(1);
            }

            MessageBox.Show("Finish!!!");
        }
    }
}
