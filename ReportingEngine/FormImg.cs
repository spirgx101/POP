using System;
using System.IO;
using System.Windows.Forms;
using POP.Dao;
using System.Drawing;
using System.Data;

namespace ReportingEngine
{
    public partial class FormImg : Form
    {
        DaoPopImage daoImage = new DaoPopImage();

        public FormImg()
        {
            InitializeComponent();
        }

        private void FormImg_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            dgViewer.DataSource = daoImage.Get_Image_List();
        }

        private void txtImgPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "選擇檔案";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "jpg file (*.jpg)|*.jpg|png file (*.png)|*.png|bmp file (*.bmp)|*.bmp|all file (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtImgAddPath.Text = dialog.FileName;
            }
        }

        private void btnImgAdd_Click(object sender, EventArgs e)
        {
            string guid = (Guid.NewGuid()).ToString().ToUpper();
            string path = txtImgAddPath.Text.Trim().ToUpper();
            string fileName = Path.GetFileName(path).ToUpper();
            string user = txtAddUser.Text.Trim().ToUpper();
            string memo = txtAddMemo.Text.Trim();

            if (path == string.Empty)
            {
                MessageBox.Show("圖片路徑不可為空白！", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (daoImage.Exist_Image(path))
            {
                MessageBox.Show("圖片已經存在！", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!daoImage.Insert_Image(guid, fileName, path, ReadFile(path), user, memo))
            {
                MessageBox.Show("圖片新增錯誤！", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                MessageBox.Show("圖片新增成功！", "新增",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            dgViewer.DataSource = daoImage.Get_Image_List();

            ShowImage(path);
        }

        private void ShowImage(string path)
        {          
            using (MemoryStream ms = new MemoryStream(daoImage.Get_Image(path)))
            {
                pbImage.Image = Image.FromStream(ms);
            }
        }

        public byte[] ReadFile(string path)
        {
            byte[] data = null;

            FileInfo fInfo = new FileInfo(path);
            long length = fInfo.Length;
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)length);

            return data;
        }

        private void dgViewer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgViewer.CurrentRow != null &&
                    dgViewer.CurrentRow.Index >= 0
                        && dgViewer.CurrentRow.Index <= dgViewer.Rows.Count)
            {
                int index = dgViewer.CurrentCell.RowIndex;
                string img_id = dgViewer.Rows[index].Cells["IMG_ID"].Value.ToString();
                GetDetailData(img_id);
            }
        }

        private void GetDetailData(string img_id)
        {
            DataTable table = daoImage.Get_Image_Detail(img_id);

            foreach(DataRow dr in table.Rows)
            {
                lbImgIdCont.Text = dr["IMG_ID"].ToString();
                lbImgNameCont.Text = dr["IMG_NAME"].ToString();
                lbImgPathCont.Text = dr["IMG_PATH"].ToString();
                lbImgCrtDateCont.Text = dr["CRT_DATE"].ToString();
                lbCrtUserCont.Text = dr["CRT_USER"].ToString();
                lbMemoCont.Text = dr["MEMO"].ToString();

                ShowImage(lbImgPathCont.Text.Trim());
            }
        }

        private void btnImgDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgViewer.CurrentRow;
 
            string id = dr.Cells["IMG_ID"].Value.ToString();

            if (MessageBox.Show("確認刪除？", "刪除", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!daoImage.Delete_Image(id))
                {
                    MessageBox.Show("刪除失敗！", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    MessageBox.Show("刪除成功！", "刪除",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }

            dgViewer.DataSource = daoImage.Get_Image_List();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            string guid = string.Empty;
            string fileName = string.Empty;
            string fileLocalPath = string.Empty;
            string user = "SYSTEM";
            string memo = "IMPORT";

            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "請選擇資料夾";

            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {
                path = dilog.SelectedPath;
            }
            else
            {
                return;
            }

            foreach (string fname in System.IO.Directory.GetFileSystemEntries(path))
            {               
                if (Directory.Exists(fname))
                {
                    ProcessDirectory(fname);
                }
                else
                {
                    ProcessFile(fname);
                }                
            }
            dgViewer.DataSource = daoImage.Get_Image_List();
            MessageBox.Show("匯入完成！", "匯入",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public void ProcessFile(string fname)
        {
            string guid = (Guid.NewGuid()).ToString().ToUpper();
            string fileName = Path.GetFileName(fname).ToUpper();
            string fileLocalPath = (@"C:\pxmart\POP\img\" + fileName).ToUpper();
            string user = "SYSTEM";
            string memo = "IMPORT";

            if (daoImage.Exist_Image(fileLocalPath)) return;

            if (fileName == "THUMBS.DB") return;

            daoImage.Insert_Image(guid, fileName, fileLocalPath, ReadFile(fname), user, memo);
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            pbImage.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
