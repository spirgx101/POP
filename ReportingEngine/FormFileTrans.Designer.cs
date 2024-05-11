namespace ReportingEngine
{
    partial class FormFileTrans
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
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lbDestination = new System.Windows.Forms.Label();
            this.lbSource = new System.Windows.Forms.Label();
            this.dgViewer = new System.Windows.Forms.DataGridView();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.btnSetStatus = new System.Windows.Forms.Button();
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
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.cbxStatus);
            this.split.Panel1.Controls.Add(this.btnSetStatus);
            this.split.Panel1.Controls.Add(this.btnTransfer);
            this.split.Panel1.Controls.Add(this.txtDestination);
            this.split.Panel1.Controls.Add(this.txtSource);
            this.split.Panel1.Controls.Add(this.lbDestination);
            this.split.Panel1.Controls.Add(this.lbSource);
            this.split.Panel1MinSize = 100;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.dgViewer);
            this.split.Size = new System.Drawing.Size(964, 527);
            this.split.SplitterDistance = 106;
            this.split.TabIndex = 0;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(634, 21);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(95, 69);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "下傳";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(123, 61);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(483, 29);
            this.txtDestination.TabIndex = 3;
            this.txtDestination.Text = "C$\\Windows\\Fonts";
            // 
            // txtSource
            // 
            this.txtSource.Enabled = false;
            this.txtSource.Location = new System.Drawing.Point(123, 21);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(483, 29);
            this.txtSource.TabIndex = 2;
            this.txtSource.Text = "D:\\\\POP_Install\\FONTS";
            // 
            // lbDestination
            // 
            this.lbDestination.AutoSize = true;
            this.lbDestination.Location = new System.Drawing.Point(12, 64);
            this.lbDestination.Name = "lbDestination";
            this.lbDestination.Size = new System.Drawing.Size(105, 20);
            this.lbDestination.TabIndex = 1;
            this.lbDestination.Text = "目標資料夾：";
            // 
            // lbSource
            // 
            this.lbSource.AutoSize = true;
            this.lbSource.Location = new System.Drawing.Point(12, 24);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(105, 20);
            this.lbSource.TabIndex = 0;
            this.lbSource.Text = "來源資料夾：";
            // 
            // dgViewer
            // 
            this.dgViewer.AllowUserToAddRows = false;
            this.dgViewer.AllowUserToDeleteRows = false;
            this.dgViewer.AllowUserToResizeRows = false;
            this.dgViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewer.Location = new System.Drawing.Point(0, 0);
            this.dgViewer.Name = "dgViewer";
            this.dgViewer.ReadOnly = true;
            this.dgViewer.RowTemplate.Height = 24;
            this.dgViewer.Size = new System.Drawing.Size(964, 417);
            this.dgViewer.TabIndex = 0;
            this.dgViewer.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgViewer_CellPainting);
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(809, 21);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(111, 28);
            this.cbxStatus.TabIndex = 8;
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Location = new System.Drawing.Point(809, 59);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(111, 30);
            this.btnSetStatus.TabIndex = 7;
            this.btnSetStatus.Text = "重設狀態";
            this.btnSetStatus.UseVisualStyleBackColor = true;
            this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // FormFileTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 527);
            this.ControlBox = false;
            this.Controls.Add(this.split);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFileTrans";
            this.Text = "檔案傳輸";
            this.Load += new System.EventHandler(this.FormFileTrans_Load);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel1.PerformLayout();
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Label lbDestination;
        private System.Windows.Forms.Label lbSource;
        private System.Windows.Forms.DataGridView dgViewer;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Button btnSetStatus;
    }
}