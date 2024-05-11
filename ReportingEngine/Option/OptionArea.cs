using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using POP.Dao;

namespace ReportingEngine.Option
{
    public partial class OptionArea : UserControl
    {
        DaoPopArea daoArea = new DaoPopArea();

        #region Overriding Keydown in a User Control using ProcessKeyPreview
        //參考：http://www.codeproject.com/KB/cs/ProcessKeyPreview.aspx?msg=2375387
        //----------------------------------------------
        // Define the PeekMessage API call
        //----------------------------------------------

        private struct MSG
        {
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public int time;
            public int pt_x;
            public int pt_y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PeekMessage([In, Out] ref MSG msg,
            HandleRef hwnd, int msgMin, int msgMax, int remove);

        //----------------------------------------------

        /// <summary> 
        /// Trap any keypress before child controls get hold of them
        /// </summary>
        /// <param name="m">Windows message</param>
        /// <returns>True if the keypress is handled</returns>
        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_SYSKEYUP = 0x105;
            const int WM_IME_CHAR = 0x286;

            KeyEventArgs e = null;

            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
                if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                {
                    TrappedKeyDown(e);
                }
                //else
                //{
                //    TrappedKeyUp(e);
                //}

                // Remove any WM_CHAR type messages if supresskeypress is true.
                if (e.SuppressKeyPress)
                {
                    this.RemovePendingMessages(WM_CHAR, WM_CHAR);
                    this.RemovePendingMessages(WM_SYSCHAR, WM_SYSCHAR);
                    this.RemovePendingMessages(WM_IME_CHAR, WM_IME_CHAR);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        private void RemovePendingMessages(int msgMin, int msgMax)
        {
            if (!this.IsDisposed)
            {
                MSG msg = new MSG();
                IntPtr handle = this.Handle;
                while (PeekMessage(ref msg,
                new HandleRef(this, handle), msgMin, msgMax, 1))
                {
                }
            }
        }

        /// <summary>
        /// This routine gets called if a keydown has been trapped 
        /// before a child control can get it.
        /// </summary>
        /// <param name="e"></param>
        private void TrappedKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Clear_Area_Field();
            }
        }
        #endregion

        private void Clear_Area_Field()
        {
            btnNew.Text = "新增";
            btnModify.Text = "修改";
            btnDelete.Text = "刪除";

            btnQuery.Enabled = true;
            btnNew.Enabled = true;
            btnModify.Enabled = true;
            btnDelete.Enabled = true;

            txtArea.Text = string.Empty;
            txtMemo.Text = string.Empty;
            cbbType.SelectedIndex = 0;
            cbbPrinter.SelectedIndex = 0;

            txtArea.Enabled = true;
            cbbType.Enabled = false;
            cbbPrinter.Enabled = false;
            txtMemo.Enabled = false;
            ckbWork.Enabled = false;
            dgvArea.DataSource = daoArea.Get_Area(string.Empty);
            dgvArea.Enabled = true;
        }

        public OptionArea()
        {
            InitializeComponent();

            dgvArea.AutoGenerateColumns = false;
            dgvArea.DataSource = daoArea.Get_Area(string.Empty);

            DaoPopPrinter daoPrinter = new DaoPopPrinter();
            cbbPrinter.DataSource = daoPrinter.Get_Printer(string.Empty);
            cbbPrinter.DisplayMember = "PRINTER_NAME";
            cbbPrinter.ValueMember = "PRINTER_ID";

            cbbType.SelectedIndex = 0;
            if (daoPrinter.Get_Printer(string.Empty).Rows.Count > 0)
                cbbPrinter.SelectedIndex = 0;

            Clear_Area_Field();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgvArea.DataSource = daoArea.Get_Area(txtArea.Text.Trim());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string area = txtArea.Text.Trim();

            if (btnNew.Text == "新增")
            {
                btnNew.Text = "確認新增";
                btnQuery.Enabled = false;
                btnModify.Enabled = false;
                btnDelete.Enabled = false;
                gpbArea.Enabled = true;
                cbbPrinter.Enabled = true;
                cbbType.Enabled = true;
                txtMemo.Enabled = true;
                ckbWork.Enabled = true;
                txtArea.Focus();
            }
            else if (btnNew.Text == "確認新增")
            {
                if (!New_Area(txtArea.Text.Trim().ToUpper(), cbbType.Text.ToUpper(), cbbPrinter.SelectedValue.ToString(), ckbWork.Checked, txtMemo.Text.Trim()))
                {
                    MessageBox.Show("新增失敗！", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                btnNew.Text = "新增";
                Clear_Area_Field();
                txtArea.Text = area;
                dgvArea.DataSource = daoArea.Get_Area(area);

            }
        }

        private bool New_Area(string area, string type, string printer, bool work, string memo)
        {
            bool blSec = false;

            if (area == string.Empty)
            {
                MessageBox.Show("區域名稱不可為空白！", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return blSec;
            }

            if (daoArea.Has_Area_Row(area, type, printer))
            {
                MessageBox.Show("此區域設定已存在！", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return blSec;
            }

            blSec = daoArea.Insert_Area(area, type, printer, work, memo);

            return blSec;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvArea.CurrentRow;
            int cRowIndex = dgvArea.CurrentRow.Index;
            int cColIndex = dgvArea.CurrentCell.ColumnIndex;
            int id = (int)dr.Cells["ID"].Value;
            string area = txtArea.Text.Trim();
            //dgv_Area.Enabled = false;

            if (btnModify.Text == "修改")
            {
                txtArea.Text = dr.Cells["AREA"].Value == DBNull.Value ? string.Empty : (string)dr.Cells["AREA"].Value;
                cbbPrinter.SelectedIndex = cbbPrinter.FindString((string)dr.Cells["PRINTER_ID"].Value);
                cbbType.SelectedIndex = cbbType.FindString((string)dr.Cells["TYPE"].Value);
                ckbWork.Checked = dr.Cells["WORK_YN"].Value == DBNull.Value ? false : (bool)dr.Cells["WORK_YN"].Value;
                txtMemo.Text = dr.Cells["MEMO"].Value == DBNull.Value ? string.Empty : (string)dr.Cells["MEMO"].Value;
                //dgv_Area.DataSource = daoArea.dtGetArea(txb_Area.Text.Trim());

                btnModify.Text = "確認修改";
                btnQuery.Enabled = false;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                gpbArea.Enabled = true;
                txtArea.Enabled = false;
                cbbType.Enabled = false;
                cbbPrinter.Enabled = true;
                txtMemo.Enabled = true;
                ckbWork.Enabled = true;
                txtMemo.Focus();
            }
            else if (btnModify.Text == "確認修改")
            {
                if (!Update_Area(id, cbbPrinter.SelectedValue.ToString(), ckbWork.Checked, txtMemo.Text.Trim()))
                {
                    MessageBox.Show("修改失敗！", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                btnModify.Text = "修改";
                Clear_Area_Field();
                dgvArea.CurrentCell = dgvArea[cColIndex, cRowIndex];
                dgvArea.FirstDisplayedScrollingRowIndex = cRowIndex;
                dgvArea.Rows[cRowIndex].Selected = true;
                txtArea.Text = area;
                dgvArea.DataSource = daoArea.Get_Area(area);
            }
        }

        private bool Update_Area(int id, string device, bool work, string memo)
        {
            if (id < 0)
            {
                MessageBox.Show("修改失敗！", "錯誤",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            return daoArea.Update_Area(id, device, work, memo);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvArea.CurrentRow;
            int id = (int)dr.Cells["ID"].Value;

            if (MessageBox.Show("確認刪除？", "刪除", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!Delete_Area(id))
                {
                    MessageBox.Show("刪除失敗！", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                btnDelete.Text = "刪除";
                Clear_Area_Field();

                btnNew.Enabled = true;
                btnModify.Enabled = true;
            }
        }

        private bool Delete_Area(int id)
        {
            if (id < 0)
            {
                MessageBox.Show("刪除失敗！", "錯誤",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            return daoArea.Delete_Area(id);
        }
    }
}
