namespace ReportingEngine.Option
{
    partial class OptionPrinter
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPrinter));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.tsb_New = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PRINTER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTER_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTER_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USE_YN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WORK_YN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.Color.Transparent;
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_New});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolBar.Size = new System.Drawing.Size(874, 78);
            this.ToolBar.TabIndex = 14;
            // 
            // tsb_New
            // 
            this.tsb_New.AutoSize = false;
            this.tsb_New.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsb_New.Image = ((System.Drawing.Image)(resources.GetObject("tsb_New.Image")));
            this.tsb_New.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_New.Name = "tsb_New";
            this.tsb_New.Size = new System.Drawing.Size(75, 75);
            this.tsb_New.Text = "儲存";
            this.tsb_New.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_New.Click += new System.EventHandler(this.tsb_New_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 454);
            this.panel1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRINTER_ID,
            this.PRINTER_NAME,
            this.PRINTER_IP,
            this.PRINTER_TYPE,
            this.USE_YN,
            this.WORK_YN,
            this.MEMO});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(874, 454);
            this.dataGridView1.TabIndex = 0;
            // 
            // PRINTER_ID
            // 
            this.PRINTER_ID.DataPropertyName = "PRINTER_ID";
            this.PRINTER_ID.HeaderText = "印表機ID";
            this.PRINTER_ID.Name = "PRINTER_ID";
            // 
            // PRINTER_NAME
            // 
            this.PRINTER_NAME.DataPropertyName = "PRINTER_NAME";
            this.PRINTER_NAME.HeaderText = "印表機名稱";
            this.PRINTER_NAME.Name = "PRINTER_NAME";
            // 
            // PRINTER_IP
            // 
            this.PRINTER_IP.DataPropertyName = "PRINTER_IP";
            this.PRINTER_IP.HeaderText = "印表機IP";
            this.PRINTER_IP.Name = "PRINTER_IP";
            // 
            // PRINTER_TYPE
            // 
            this.PRINTER_TYPE.DataPropertyName = "PRINTER_TYPE";
            this.PRINTER_TYPE.HeaderText = "印表機類別";
            this.PRINTER_TYPE.Name = "PRINTER_TYPE";
            // 
            // USE_YN
            // 
            this.USE_YN.DataPropertyName = "USE_YN";
            this.USE_YN.FalseValue = "False";
            this.USE_YN.HeaderText = "使用狀態";
            this.USE_YN.Name = "USE_YN";
            this.USE_YN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USE_YN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.USE_YN.TrueValue = "True";
            // 
            // WORK_YN
            // 
            this.WORK_YN.DataPropertyName = "WORK_YN";
            this.WORK_YN.FalseValue = "False";
            this.WORK_YN.HeaderText = "連線狀態";
            this.WORK_YN.Name = "WORK_YN";
            this.WORK_YN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WORK_YN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WORK_YN.TrueValue = "True";
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "備註";
            this.MEMO.Name = "MEMO";
            // 
            // OptionPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "OptionPrinter";
            this.Size = new System.Drawing.Size(874, 532);
            this.Load += new System.EventHandler(this.OptionPrinter_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton tsb_New;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTER_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTER_TYPE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn USE_YN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WORK_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}
