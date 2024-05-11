namespace ReportingEngine.Option
{
    partial class OptionPaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPaper));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.tsb_New = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KIND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.ToolBar.Size = new System.Drawing.Size(1059, 78);
            this.ToolBar.TabIndex = 13;
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 467);
            this.panel1.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NAME,
            this.KIND,
            this.DIRECTION,
            this.WIDTH,
            this.HEIGHT,
            this.ROW,
            this.COL,
            this.DATE,
            this.MEMO});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1059, 467);
            this.dataGridView1.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "PAPER_ID";
            this.ID.HeaderText = "紙張代號";
            this.ID.Name = "ID";
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "紙張名稱";
            this.NAME.Name = "NAME";
            // 
            // KIND
            // 
            this.KIND.DataPropertyName = "KIND";
            this.KIND.HeaderText = "紙張尺寸";
            this.KIND.Name = "KIND";
            // 
            // DIRECTION
            // 
            this.DIRECTION.DataPropertyName = "DIRECTION";
            this.DIRECTION.FalseValue = "False";
            this.DIRECTION.HeaderText = "橫向列印";
            this.DIRECTION.Name = "DIRECTION";
            this.DIRECTION.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DIRECTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DIRECTION.TrueValue = "True";
            // 
            // WIDTH
            // 
            this.WIDTH.DataPropertyName = "WIDTH";
            this.WIDTH.HeaderText = "紙張寬度";
            this.WIDTH.Name = "WIDTH";
            // 
            // HEIGHT
            // 
            this.HEIGHT.DataPropertyName = "HEIGHT";
            this.HEIGHT.HeaderText = "紙張高度";
            this.HEIGHT.Name = "HEIGHT";
            // 
            // ROW
            // 
            this.ROW.DataPropertyName = "ROW";
            this.ROW.HeaderText = "紙張列數";
            this.ROW.Name = "ROW";
            // 
            // COL
            // 
            this.COL.DataPropertyName = "COL";
            this.COL.HeaderText = "紙張行數";
            this.COL.Name = "COL";
            // 
            // DATE
            // 
            this.DATE.DataPropertyName = "DATE";
            this.DATE.HeaderText = "建立日期";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "備註";
            this.MEMO.Name = "MEMO";
            // 
            // OptionPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OptionPaper";
            this.Size = new System.Drawing.Size(1059, 545);
            this.Load += new System.EventHandler(this.OptionPaper_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn KIND;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIRECTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn WIDTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROW;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}
