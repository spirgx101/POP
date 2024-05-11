namespace ReportingEngine.Option
{
    partial class OptionArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionArea));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnQuery = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnModify = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpbArea = new System.Windows.Forms.GroupBox();
            this.ckbWork = new System.Windows.Forms.CheckBox();
            this.cbbPrinter = new System.Windows.Forms.ComboBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.lbPrinter = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.WORK_YN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AREA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpbArea.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.Transparent;
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnNew,
            this.btnModify,
            this.btnDelete});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolbar.Size = new System.Drawing.Size(838, 78);
            this.toolbar.TabIndex = 10;
            // 
            // btnQuery
            // 
            this.btnQuery.AutoSize = false;
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(68, 75);
            this.btnQuery.Text = "查詢";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 75);
            this.btnNew.Text = "新增";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnModify
            // 
            this.btnModify.AutoSize = false;
            this.btnModify.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(68, 75);
            this.btnModify.Text = "修改";
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 75);
            this.btnDelete.Text = "刪除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gpbArea);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 202);
            this.panel1.TabIndex = 11;
            // 
            // gpbArea
            // 
            this.gpbArea.Controls.Add(this.ckbWork);
            this.gpbArea.Controls.Add(this.cbbPrinter);
            this.gpbArea.Controls.Add(this.txtMemo);
            this.gpbArea.Controls.Add(this.lbComment);
            this.gpbArea.Controls.Add(this.cbbType);
            this.gpbArea.Controls.Add(this.lbType);
            this.gpbArea.Controls.Add(this.lbPrinter);
            this.gpbArea.Controls.Add(this.txtArea);
            this.gpbArea.Controls.Add(this.lbArea);
            this.gpbArea.Location = new System.Drawing.Point(5, 7);
            this.gpbArea.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.gpbArea.Name = "gpbArea";
            this.gpbArea.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.gpbArea.Size = new System.Drawing.Size(815, 183);
            this.gpbArea.TabIndex = 2;
            this.gpbArea.TabStop = false;
            // 
            // ckbWork
            // 
            this.ckbWork.AutoSize = true;
            this.ckbWork.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ckbWork.Location = new System.Drawing.Point(345, 30);
            this.ckbWork.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ckbWork.Name = "ckbWork";
            this.ckbWork.Size = new System.Drawing.Size(60, 24);
            this.ckbWork.TabIndex = 12;
            this.ckbWork.Text = "運作";
            this.ckbWork.UseVisualStyleBackColor = true;
            // 
            // cbbPrinter
            // 
            this.cbbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPrinter.FormattingEnabled = true;
            this.cbbPrinter.Location = new System.Drawing.Point(125, 70);
            this.cbbPrinter.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbbPrinter.Name = "cbbPrinter";
            this.cbbPrinter.Size = new System.Drawing.Size(199, 28);
            this.cbbPrinter.TabIndex = 1;
            // 
            // txtMemo
            // 
            this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMemo.Location = new System.Drawing.Point(408, 70);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMemo.Size = new System.Drawing.Size(389, 96);
            this.txtMemo.TabIndex = 3;
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbComment.Location = new System.Drawing.Point(341, 70);
            this.lbComment.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(57, 20);
            this.lbComment.TabIndex = 11;
            this.lbComment.Text = "註解：";
            // 
            // cbbType
            // 
            this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            "001",
            "002",
            "003",
            "004",
            "005",
            "006",
            "007",
            "008",
            "009",
            "010",
            "011",
            "012",
            "013",
            "014",
            "015",
            "016"});
            this.cbbType.Location = new System.Drawing.Point(125, 114);
            this.cbbType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(199, 28);
            this.cbbType.TabIndex = 2;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbType.Location = new System.Drawing.Point(10, 114);
            this.lbType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(105, 20);
            this.lbType.TabIndex = 6;
            this.lbType.Text = "印表機類型：";
            // 
            // lbPrinter
            // 
            this.lbPrinter.AutoSize = true;
            this.lbPrinter.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbPrinter.Location = new System.Drawing.Point(10, 70);
            this.lbPrinter.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPrinter.Name = "lbPrinter";
            this.lbPrinter.Size = new System.Drawing.Size(105, 20);
            this.lbPrinter.TabIndex = 4;
            this.lbPrinter.Text = "印表機名稱：";
            // 
            // txtArea
            // 
            this.txtArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArea.Location = new System.Drawing.Point(125, 28);
            this.txtArea.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(199, 29);
            this.txtArea.TabIndex = 0;
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbArea.Location = new System.Drawing.Point(10, 28);
            this.lbArea.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(89, 20);
            this.lbArea.TabIndex = 0;
            this.lbArea.Text = "區域名稱：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvArea);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 280);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 278);
            this.panel2.TabIndex = 12;
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToDeleteRows = false;
            this.dgvArea.AllowUserToResizeRows = false;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WORK_YN,
            this.ID,
            this.AREA,
            this.TYPE,
            this.PRINTER_ID,
            this.PRINTER_NAME,
            this.MEMO});
            this.dgvArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArea.Location = new System.Drawing.Point(0, 0);
            this.dgvArea.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.RowTemplate.Height = 24;
            this.dgvArea.Size = new System.Drawing.Size(838, 278);
            this.dgvArea.TabIndex = 11;
            // 
            // WORK_YN
            // 
            this.WORK_YN.DataPropertyName = "WORK_YN";
            this.WORK_YN.FalseValue = "0";
            this.WORK_YN.HeaderText = "運作";
            this.WORK_YN.Name = "WORK_YN";
            this.WORK_YN.ReadOnly = true;
            this.WORK_YN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WORK_YN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WORK_YN.TrueValue = "1";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // AREA
            // 
            this.AREA.DataPropertyName = "AREA";
            this.AREA.HeaderText = "區域";
            this.AREA.Name = "AREA";
            this.AREA.ReadOnly = true;
            // 
            // TYPE
            // 
            this.TYPE.DataPropertyName = "TYPE";
            this.TYPE.HeaderText = "類型";
            this.TYPE.Name = "TYPE";
            this.TYPE.ReadOnly = true;
            // 
            // PRINTER_ID
            // 
            this.PRINTER_ID.DataPropertyName = "PRINTER_ID";
            this.PRINTER_ID.HeaderText = "標籤機ID";
            this.PRINTER_ID.Name = "PRINTER_ID";
            this.PRINTER_ID.ReadOnly = true;
            // 
            // PRINTER_NAME
            // 
            this.PRINTER_NAME.DataPropertyName = "PRINTER_NAME";
            this.PRINTER_NAME.HeaderText = "標籤機名稱";
            this.PRINTER_NAME.Name = "PRINTER_NAME";
            this.PRINTER_NAME.ReadOnly = true;
            this.PRINTER_NAME.Width = 150;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "註解";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 200;
            // 
            // OptionArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolbar);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "OptionArea";
            this.Size = new System.Drawing.Size(838, 558);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gpbArea.ResumeLayout(false);
            this.gpbArea.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnQuery;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gpbArea;
        private System.Windows.Forms.CheckBox ckbWork;
        private System.Windows.Forms.ComboBox cbbPrinter;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbPrinter;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WORK_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AREA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}
