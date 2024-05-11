namespace ReportingEngine
{
    partial class FormImageTrans
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
            this.split = new System.Windows.Forms.SplitContainer();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.btnSetStatus = new System.Windows.Forms.Button();
            this.btnSyncImage = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lbDatabase = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lbSource = new System.Windows.Forms.Label();
            this.dgViewer = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTERVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Margin = new System.Windows.Forms.Padding(5);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.cbxStatus);
            this.split.Panel1.Controls.Add(this.btnSetStatus);
            this.split.Panel1.Controls.Add(this.btnSyncImage);
            this.split.Panel1.Controls.Add(this.txtDatabase);
            this.split.Panel1.Controls.Add(this.lbDatabase);
            this.split.Panel1.Controls.Add(this.txtSource);
            this.split.Panel1.Controls.Add(this.lbSource);
            this.split.Panel1MinSize = 350;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.dgViewer);
            this.split.Size = new System.Drawing.Size(1132, 507);
            this.split.SplitterDistance = 352;
            this.split.SplitterWidth = 7;
            this.split.TabIndex = 0;
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(17, 348);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(300, 28);
            this.cbxStatus.TabIndex = 6;
            this.cbxStatus.SelectedIndexChanged += new System.EventHandler(this.cbxStatus_SelectedIndexChanged);
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Location = new System.Drawing.Point(17, 392);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(300, 40);
            this.btnSetStatus.TabIndex = 5;
            this.btnSetStatus.Text = "重設狀態";
            this.btnSetStatus.UseVisualStyleBackColor = true;
            this.btnSetStatus.Click += new System.EventHandler(this.btnResetStatus_Click);
            // 
            // btnSyncImage
            // 
            this.btnSyncImage.Location = new System.Drawing.Point(17, 197);
            this.btnSyncImage.Name = "btnSyncImage";
            this.btnSyncImage.Size = new System.Drawing.Size(300, 40);
            this.btnSyncImage.TabIndex = 4;
            this.btnSyncImage.Text = "同步圖片";
            this.btnSyncImage.UseVisualStyleBackColor = true;
            this.btnSyncImage.Click += new System.EventHandler(this.btnSyncImage_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(17, 137);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(300, 29);
            this.txtDatabase.TabIndex = 3;
            this.txtDatabase.Text = "PXMSDE";
            // 
            // lbDatabase
            // 
            this.lbDatabase.AutoSize = true;
            this.lbDatabase.Location = new System.Drawing.Point(13, 101);
            this.lbDatabase.Name = "lbDatabase";
            this.lbDatabase.Size = new System.Drawing.Size(73, 20);
            this.lbDatabase.TabIndex = 2;
            this.lbDatabase.Text = "資料庫：";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(17, 47);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(300, 29);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = "172.31.31.250";
            // 
            // lbSource
            // 
            this.lbSource.AutoSize = true;
            this.lbSource.Location = new System.Drawing.Point(13, 13);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(89, 20);
            this.lbSource.TabIndex = 0;
            this.lbSource.Text = "來源電腦：";
            // 
            // dgViewer
            // 
            this.dgViewer.AllowUserToAddRows = false;
            this.dgViewer.AllowUserToDeleteRows = false;
            this.dgViewer.AllowUserToResizeRows = false;
            this.dgViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgViewer.ColumnHeadersHeight = 30;
            this.dgViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NAME,
            this.IP,
            this.B_DATE,
            this.E_DATE,
            this.INTERVAL,
            this.STATUS,
            this.MEMO});
            this.dgViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewer.Location = new System.Drawing.Point(0, 0);
            this.dgViewer.Name = "dgViewer";
            this.dgViewer.ReadOnly = true;
            this.dgViewer.RowTemplate.Height = 24;
            this.dgViewer.Size = new System.Drawing.Size(773, 507);
            this.dgViewer.TabIndex = 0;
            this.dgViewer.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgViewer_CellPainting);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "店舖代碼";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 98;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "店舖名稱";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 98;
            // 
            // IP
            // 
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "小黑IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 81;
            // 
            // B_DATE
            // 
            this.B_DATE.DataPropertyName = "B_DATE";
            this.B_DATE.HeaderText = "開始傳輸時間";
            this.B_DATE.Name = "B_DATE";
            this.B_DATE.ReadOnly = true;
            this.B_DATE.Width = 130;
            // 
            // E_DATE
            // 
            this.E_DATE.DataPropertyName = "E_DATE";
            this.E_DATE.HeaderText = "結束傳輸時間";
            this.E_DATE.Name = "E_DATE";
            this.E_DATE.ReadOnly = true;
            this.E_DATE.Width = 130;
            // 
            // INTERVAL
            // 
            this.INTERVAL.DataPropertyName = "INTERVAL";
            this.INTERVAL.HeaderText = "傳輸時間(s)";
            this.INTERVAL.Name = "INTERVAL";
            this.INTERVAL.ReadOnly = true;
            this.INTERVAL.Width = 115;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "狀態";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Width = 66;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "備註";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 66;
            // 
            // FormImageTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 507);
            this.ControlBox = false;
            this.Controls.Add(this.split);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImageTrans";
            this.Text = "FormImageTrans";
            this.Load += new System.EventHandler(this.FormImageTrans_Load);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel1.PerformLayout();
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Label lbSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.DataGridView dgViewer;
        private System.Windows.Forms.Button btnSyncImage;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lbDatabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn B_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTERVAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.Button btnSetStatus;
        private System.Windows.Forms.ComboBox cbxStatus;
    }
}