namespace ReportingEngine
{
    partial class FormImg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnImgDelete = new System.Windows.Forms.Button();
            this.txtAddMemo = new System.Windows.Forms.TextBox();
            this.lbAddMemo = new System.Windows.Forms.Label();
            this.lbAddUser = new System.Windows.Forms.Label();
            this.txtAddUser = new System.Windows.Forms.TextBox();
            this.btnImgAdd = new System.Windows.Forms.Button();
            this.txtImgAddPath = new System.Windows.Forms.TextBox();
            this.lbImgAddPath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgViewer = new System.Windows.Forms.DataGridView();
            this.IMG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMG_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRT_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnZoom = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbMemoCont = new System.Windows.Forms.Label();
            this.lbMemo = new System.Windows.Forms.Label();
            this.lbCrtUserCont = new System.Windows.Forms.Label();
            this.lbCrtUser = new System.Windows.Forms.Label();
            this.lbImgCrtDateCont = new System.Windows.Forms.Label();
            this.lbImgCrtDate = new System.Windows.Forms.Label();
            this.lbImgPathCont = new System.Windows.Forms.Label();
            this.lbImgPath = new System.Windows.Forms.Label();
            this.lbImgNameCont = new System.Windows.Forms.Label();
            this.lbImgName = new System.Windows.Forms.Label();
            this.lbImgIdCont = new System.Windows.Forms.Label();
            this.lbImgId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewer)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.btnImgDelete);
            this.groupBox1.Controls.Add(this.txtAddMemo);
            this.groupBox1.Controls.Add(this.lbAddMemo);
            this.groupBox1.Controls.Add(this.lbAddUser);
            this.groupBox1.Controls.Add(this.txtAddUser);
            this.groupBox1.Controls.Add(this.btnImgAdd);
            this.groupBox1.Controls.Add(this.txtImgAddPath);
            this.groupBox1.Controls.Add(this.lbImgAddPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1100, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增圖片";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(937, 28);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(98, 69);
            this.btnImport.TabIndex = 17;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnImgDelete
            // 
            this.btnImgDelete.Location = new System.Drawing.Point(833, 27);
            this.btnImgDelete.Name = "btnImgDelete";
            this.btnImgDelete.Size = new System.Drawing.Size(98, 69);
            this.btnImgDelete.TabIndex = 16;
            this.btnImgDelete.Text = "刪除";
            this.btnImgDelete.UseVisualStyleBackColor = true;
            this.btnImgDelete.Click += new System.EventHandler(this.btnImgDelete_Click);
            // 
            // txtAddMemo
            // 
            this.txtAddMemo.Location = new System.Drawing.Point(323, 67);
            this.txtAddMemo.Name = "txtAddMemo";
            this.txtAddMemo.Size = new System.Drawing.Size(400, 29);
            this.txtAddMemo.TabIndex = 15;
            // 
            // lbAddMemo
            // 
            this.lbAddMemo.AutoSize = true;
            this.lbAddMemo.Location = new System.Drawing.Point(259, 70);
            this.lbAddMemo.Name = "lbAddMemo";
            this.lbAddMemo.Size = new System.Drawing.Size(57, 20);
            this.lbAddMemo.TabIndex = 14;
            this.lbAddMemo.Text = "備註：";
            // 
            // lbAddUser
            // 
            this.lbAddUser.AutoSize = true;
            this.lbAddUser.Location = new System.Drawing.Point(24, 70);
            this.lbAddUser.Name = "lbAddUser";
            this.lbAddUser.Size = new System.Drawing.Size(89, 20);
            this.lbAddUser.TabIndex = 13;
            this.lbAddUser.Text = "新增人員：";
            // 
            // txtAddUser
            // 
            this.txtAddUser.Location = new System.Drawing.Point(119, 67);
            this.txtAddUser.Name = "txtAddUser";
            this.txtAddUser.Size = new System.Drawing.Size(119, 29);
            this.txtAddUser.TabIndex = 12;
            this.txtAddUser.Text = "SYSTEM";
            // 
            // btnImgAdd
            // 
            this.btnImgAdd.Location = new System.Drawing.Point(729, 27);
            this.btnImgAdd.Name = "btnImgAdd";
            this.btnImgAdd.Size = new System.Drawing.Size(98, 69);
            this.btnImgAdd.TabIndex = 2;
            this.btnImgAdd.Text = "新增";
            this.btnImgAdd.UseVisualStyleBackColor = true;
            this.btnImgAdd.Click += new System.EventHandler(this.btnImgAdd_Click);
            // 
            // txtImgAddPath
            // 
            this.txtImgAddPath.Location = new System.Drawing.Point(119, 28);
            this.txtImgAddPath.Name = "txtImgAddPath";
            this.txtImgAddPath.Size = new System.Drawing.Size(604, 29);
            this.txtImgAddPath.TabIndex = 1;
            this.txtImgAddPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtImgPath_MouseDoubleClick);
            // 
            // lbImgAddPath
            // 
            this.lbImgAddPath.AutoSize = true;
            this.lbImgAddPath.Location = new System.Drawing.Point(23, 31);
            this.lbImgAddPath.Name = "lbImgAddPath";
            this.lbImgAddPath.Size = new System.Drawing.Size(89, 20);
            this.lbImgAddPath.TabIndex = 0;
            this.lbImgAddPath.Text = "圖片路徑：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 109);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgViewer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1100, 525);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgViewer
            // 
            this.dgViewer.AllowUserToAddRows = false;
            this.dgViewer.AllowUserToDeleteRows = false;
            this.dgViewer.AllowUserToResizeRows = false;
            this.dgViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IMG_ID,
            this.IMG_NAME,
            this.CRT_DATE,
            this.CRT_USER});
            this.dgViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewer.Location = new System.Drawing.Point(0, 0);
            this.dgViewer.Name = "dgViewer";
            this.dgViewer.ReadOnly = true;
            this.dgViewer.RowTemplate.Height = 24;
            this.dgViewer.Size = new System.Drawing.Size(372, 525);
            this.dgViewer.TabIndex = 0;
            this.dgViewer.SelectionChanged += new System.EventHandler(this.dgViewer_SelectionChanged);
            // 
            // IMG_ID
            // 
            this.IMG_ID.DataPropertyName = "IMG_ID";
            this.IMG_ID.HeaderText = "圖片ID";
            this.IMG_ID.Name = "IMG_ID";
            this.IMG_ID.ReadOnly = true;
            this.IMG_ID.Visible = false;
            // 
            // IMG_NAME
            // 
            this.IMG_NAME.DataPropertyName = "IMG_NAME";
            this.IMG_NAME.HeaderText = "圖片名稱";
            this.IMG_NAME.Name = "IMG_NAME";
            this.IMG_NAME.ReadOnly = true;
            this.IMG_NAME.Width = 150;
            // 
            // CRT_DATE
            // 
            this.CRT_DATE.DataPropertyName = "CRT_DATE";
            this.CRT_DATE.HeaderText = "新增日期";
            this.CRT_DATE.Name = "CRT_DATE";
            this.CRT_DATE.ReadOnly = true;
            this.CRT_DATE.Width = 200;
            // 
            // CRT_USER
            // 
            this.CRT_USER.DataPropertyName = "CRT_USER";
            this.CRT_USER.HeaderText = "新增人員";
            this.CRT_USER.Name = "CRT_USER";
            this.CRT_USER.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnCenter);
            this.splitContainer2.Panel1.Controls.Add(this.btnZoom);
            this.splitContainer2.Panel1.Controls.Add(this.pbImage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbMemoCont);
            this.splitContainer2.Panel2.Controls.Add(this.lbMemo);
            this.splitContainer2.Panel2.Controls.Add(this.lbCrtUserCont);
            this.splitContainer2.Panel2.Controls.Add(this.lbCrtUser);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgCrtDateCont);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgCrtDate);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgPathCont);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgPath);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgNameCont);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgName);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgIdCont);
            this.splitContainer2.Panel2.Controls.Add(this.lbImgId);
            this.splitContainer2.Size = new System.Drawing.Size(724, 525);
            this.splitContainer2.SplitterDistance = 251;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnCenter
            // 
            this.btnCenter.Location = new System.Drawing.Point(12, 51);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(32, 30);
            this.btnCenter.TabIndex = 2;
            this.btnCenter.Text = "C";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Location = new System.Drawing.Point(12, 15);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(32, 30);
            this.btnZoom.TabIndex = 1;
            this.btnZoom.Text = "F";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(724, 251);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // lbMemoCont
            // 
            this.lbMemoCont.AutoSize = true;
            this.lbMemoCont.Location = new System.Drawing.Point(139, 204);
            this.lbMemoCont.Name = "lbMemoCont";
            this.lbMemoCont.Size = new System.Drawing.Size(30, 20);
            this.lbMemoCont.TabIndex = 11;
            this.lbMemoCont.Text = "---";
            // 
            // lbMemo
            // 
            this.lbMemo.AutoSize = true;
            this.lbMemo.Location = new System.Drawing.Point(19, 204);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(93, 20);
            this.lbMemo.TabIndex = 10;
            this.lbMemo.Text = "備        註 ：";
            // 
            // lbCrtUserCont
            // 
            this.lbCrtUserCont.AutoSize = true;
            this.lbCrtUserCont.Location = new System.Drawing.Point(139, 168);
            this.lbCrtUserCont.Name = "lbCrtUserCont";
            this.lbCrtUserCont.Size = new System.Drawing.Size(30, 20);
            this.lbCrtUserCont.TabIndex = 9;
            this.lbCrtUserCont.Text = "---";
            // 
            // lbCrtUser
            // 
            this.lbCrtUser.AutoSize = true;
            this.lbCrtUser.Location = new System.Drawing.Point(19, 168);
            this.lbCrtUser.Name = "lbCrtUser";
            this.lbCrtUser.Size = new System.Drawing.Size(93, 20);
            this.lbCrtUser.TabIndex = 8;
            this.lbCrtUser.Text = "新增人員 ：";
            // 
            // lbImgCrtDateCont
            // 
            this.lbImgCrtDateCont.AutoSize = true;
            this.lbImgCrtDateCont.Location = new System.Drawing.Point(139, 133);
            this.lbImgCrtDateCont.Name = "lbImgCrtDateCont";
            this.lbImgCrtDateCont.Size = new System.Drawing.Size(30, 20);
            this.lbImgCrtDateCont.TabIndex = 7;
            this.lbImgCrtDateCont.Text = "---";
            // 
            // lbImgCrtDate
            // 
            this.lbImgCrtDate.AutoSize = true;
            this.lbImgCrtDate.Location = new System.Drawing.Point(19, 133);
            this.lbImgCrtDate.Name = "lbImgCrtDate";
            this.lbImgCrtDate.Size = new System.Drawing.Size(93, 20);
            this.lbImgCrtDate.TabIndex = 6;
            this.lbImgCrtDate.Text = "新增日期 ：";
            // 
            // lbImgPathCont
            // 
            this.lbImgPathCont.AutoSize = true;
            this.lbImgPathCont.Location = new System.Drawing.Point(139, 96);
            this.lbImgPathCont.Name = "lbImgPathCont";
            this.lbImgPathCont.Size = new System.Drawing.Size(30, 20);
            this.lbImgPathCont.TabIndex = 5;
            this.lbImgPathCont.Text = "---";
            // 
            // lbImgPath
            // 
            this.lbImgPath.AutoSize = true;
            this.lbImgPath.Location = new System.Drawing.Point(19, 96);
            this.lbImgPath.Name = "lbImgPath";
            this.lbImgPath.Size = new System.Drawing.Size(93, 20);
            this.lbImgPath.TabIndex = 4;
            this.lbImgPath.Text = "圖片路徑 ：";
            // 
            // lbImgNameCont
            // 
            this.lbImgNameCont.AutoSize = true;
            this.lbImgNameCont.Location = new System.Drawing.Point(139, 58);
            this.lbImgNameCont.Name = "lbImgNameCont";
            this.lbImgNameCont.Size = new System.Drawing.Size(30, 20);
            this.lbImgNameCont.TabIndex = 3;
            this.lbImgNameCont.Text = "---";
            // 
            // lbImgName
            // 
            this.lbImgName.AutoSize = true;
            this.lbImgName.Location = new System.Drawing.Point(19, 58);
            this.lbImgName.Name = "lbImgName";
            this.lbImgName.Size = new System.Drawing.Size(89, 20);
            this.lbImgName.TabIndex = 2;
            this.lbImgName.Text = "圖片名稱：";
            // 
            // lbImgIdCont
            // 
            this.lbImgIdCont.AutoSize = true;
            this.lbImgIdCont.Location = new System.Drawing.Point(139, 21);
            this.lbImgIdCont.Name = "lbImgIdCont";
            this.lbImgIdCont.Size = new System.Drawing.Size(30, 20);
            this.lbImgIdCont.TabIndex = 1;
            this.lbImgIdCont.Text = "---";
            // 
            // lbImgId
            // 
            this.lbImgId.AutoSize = true;
            this.lbImgId.Location = new System.Drawing.Point(19, 21);
            this.lbImgId.Name = "lbImgId";
            this.lbImgId.Size = new System.Drawing.Size(42, 20);
            this.lbImgId.TabIndex = 0;
            this.lbImgId.Text = "ID：";
            // 
            // FormImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 634);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormImg";
            this.Text = "FormImg";
            this.Load += new System.EventHandler(this.FormImg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewer)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImgAdd;
        private System.Windows.Forms.TextBox txtImgAddPath;
        private System.Windows.Forms.Label lbImgAddPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgViewer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lbCrtUserCont;
        private System.Windows.Forms.Label lbCrtUser;
        private System.Windows.Forms.Label lbImgCrtDateCont;
        private System.Windows.Forms.Label lbImgCrtDate;
        private System.Windows.Forms.Label lbImgPathCont;
        private System.Windows.Forms.Label lbImgPath;
        private System.Windows.Forms.Label lbImgNameCont;
        private System.Windows.Forms.Label lbImgName;
        private System.Windows.Forms.Label lbImgIdCont;
        private System.Windows.Forms.Label lbImgId;
        private System.Windows.Forms.Label lbMemoCont;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtAddUser;
        private System.Windows.Forms.TextBox txtAddMemo;
        private System.Windows.Forms.Label lbAddMemo;
        private System.Windows.Forms.Label lbAddUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMG_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMG_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRT_USER;
        private System.Windows.Forms.Button btnImgDelete;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnZoom;
    }
}