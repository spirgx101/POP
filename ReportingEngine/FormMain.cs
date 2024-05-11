using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportingEngine
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void NewForm(Form form)
        {
            try
            {
                foreach (Form child in this.MdiChildren)
                {
                    if (form.Name == child.Name)
                    {
                        return;
                    }
                    child.Close();
                }

                form.FormBorderStyle = FormBorderStyle.None;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系統異常請洽資訊部!!!" + ex.Message);
            }
        }

        private void MenuItemOption_Click(object sender, EventArgs e)
        {
            FormOption frmOption = new FormOption();
            NewForm(frmOption);
        }

        private void MenuItemImageLoad_Click(object sender, EventArgs e)
        {
            FormImg frmImg = new FormImg();
            NewForm(frmImg);
        }

        private void MenuItemImageTransfer_Click(object sender, EventArgs e)
        {
            //FormImageTest frmImgTest = new FormImageTest();
            FormImageTrans frmImageTrans = new FormImageTrans();
            NewForm(frmImageTrans);
        }

        private void MenuItemFileTrans_Click(object sender, EventArgs e)
        {
            FormFileTrans frmFileTrans = new FormFileTrans();
            NewForm(frmFileTrans);
        }

        private void MenuItemLinked_Click(object sender, EventArgs e)
        {
            FormLinkedServer frmLinkedServer = new FormLinkedServer();
            NewForm(frmLinkedServer);
        }
    }
}
