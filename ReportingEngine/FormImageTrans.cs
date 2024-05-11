using POP.Dao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ReportingEngine
{
    public partial class FormImageTrans : Form
    {
        private IAsyncResult iar;
        DaoPopStore daoStore = new DaoPopStore();
        DaoPopImage daoImage = new DaoPopImage();
        public delegate void MyDelegate(string id, int status);

        public FormImageTrans()
        {
            InitializeComponent();
        }

        private void FormImageTrans_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("未下傳", 0));
            data.Add(new DictionaryEntry("下傳中", 1));
            data.Add(new DictionaryEntry("下傳完成", 2));
            data.Add(new DictionaryEntry("關閉下傳", 99));
            cbxStatus.DisplayMember = "Key";
            cbxStatus.ValueMember = "Value";
            cbxStatus.DataSource = data;

            dgViewer.DataSource = daoStore.Get_Store_Data();
        }

        private void dgViewer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string strStatus = ((DataGridView)sender).Rows[e.RowIndex].Cells["STATUS"].Value.ToString();
                switch (strStatus)
                {
                    case "0":
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "1":
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "2":
                        e.CellStyle.BackColor = Color.LawnGreen;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "99":
                        e.CellStyle.BackColor = Color.DimGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void btnSyncImage_Click(object sender, EventArgs e)
        {
            Thread thProcess = new Thread(DoWork);
            thProcess.Start();
        }

        private void DoWork()
        {
            DataTable table = daoStore.Get_Store_Data(0);

            foreach (DataRow dr in table.Rows)
            {
                string store_id = dr["ID"].ToString().Trim();
                string store_ip = dr["IP"].ToString().Trim();
                MyDelegate method = new MyDelegate(this.Update_Status);


                iar = this.BeginInvoke(method, new object[] { store_id, 1 });
                this.EndInvoke(iar);

                bool bSec = daoImage.Sync_Image(store_ip);                

                iar = this.BeginInvoke(method, new object[] { store_id, 2 });
                this.EndInvoke(iar);

                Thread.Sleep(1000);
            }
        }

        private void Update_Status(string id, int status)
        {
            daoStore.Set_Store_Status(id, status);
            dgViewer.DataSource = daoStore.Get_Store_Data();
        }

        private void btnResetStatus_Click(object sender, EventArgs e)
        {
            daoStore.Reset_Store_Status(Convert.ToInt32(cbxStatus.SelectedValue.ToString()));
            dgViewer.DataSource = daoStore.Get_Store_Data();
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
public bool Sync_Image(string source_ip, string dest_ip, string initialCatalog, string userId, string password)
{
  bool blSec = false;
  SqlConnection conn = new SqlConnection((new POP_DBConn(dest_ip, initialCatalog, userId, password)).GetConnString());

  try
  {
      string cmd = @"INSERT [172.31.34.3].[PXMSDE].[dbo].[POP_LABEL_IMG] 
                     SELECT * FROM [dbo].[POP_LABEL_IMG] AS S
                      WHERE NOT EXISTS (
                          SELECT 1 
                          FROM [172.31.34.3].[PXMSDE].[dbo].[POP_LABEL_IMG]
                          WHERE IMG_PATH = S.IMG_PATH);

                      DELETE FROM [172.31.34.3].[PXMSDE].[dbo].[POP_LABEL_IMG] 
                      WHERE NOT EXISTS
                        ( SELECT 
                              IMG_PATH
                          FROM
                              [dbo].[POP_LABEL_IMG] A
                           WHERE
                              A.IMG_PATH = IMG_PATH); ";
      SqlCommand com = new SqlCommand(cmd, conn);

      conn.Open();
      com.ExecuteNonQuery();
      blSec = true;
  }
  catch (Exception ex)
  {
      blSec = false;
      throw new Exception(ex.Message);
  }
  finally
  {
      conn.Close();
      conn.Dispose();
  }

  return blSec;
}
*/
    }
}
