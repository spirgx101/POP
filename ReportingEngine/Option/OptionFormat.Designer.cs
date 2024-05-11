namespace ReportingEngine.Option
{
    partial class OptionFormat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionFormat));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnPreviewAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtPaperId = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtListId = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cbbPrinter = new System.Windows.Forms.ToolStripComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewHead = new System.Windows.Forms.DataGridView();
            this.FORMAT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMAT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMAT_GROUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMAT_WIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMAT_HEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAMPLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this._ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FORMAT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FORMAT_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._PRINT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FONT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FONT_SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FONT_STYLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FONT_COLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._X_SITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Y_SITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._WIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._VERTICAL_ALIGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HORIZONTAL_ALIGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._MATRIX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._X_ZOOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Y_ZOOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._DIRECTION_VERTICAL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._CRT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDrawRect = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ToolBar.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHead)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.Color.Transparent;
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnCopy,
            this.btnPreview,
            this.btnPreviewAll,
            this.toolStripLabel1,
            this.txtPaperId,
            this.toolStripLabel2,
            this.txtListId,
            this.toolStripLabel3,
            this.cbbPrinter});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolBar.Size = new System.Drawing.Size(1338, 78);
            this.ToolBar.TabIndex = 12;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 75);
            this.btnRefresh.Text = "更新";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(77, 75);
            this.btnCopy.Text = "複製格式";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = false;
            this.btnPreview.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 75);
            this.btnPreview.Text = "單筆預覽";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPreviewAll
            // 
            this.btnPreviewAll.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPreviewAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewAll.Image")));
            this.btnPreviewAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPreviewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviewAll.Name = "btnPreviewAll";
            this.btnPreviewAll.Size = new System.Drawing.Size(77, 75);
            this.btnPreviewAll.Text = "批次預覽";
            this.btnPreviewAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreviewAll.Click += new System.EventHandler(this.btnPreviewAll_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 75);
            this.toolStripLabel1.Text = "紙張編號";
            this.toolStripLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // txtPaperId
            // 
            this.txtPaperId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPaperId.Name = "txtPaperId";
            this.txtPaperId.Size = new System.Drawing.Size(100, 78);
            this.txtPaperId.Text = "HOUR";
            this.txtPaperId.ToolTipText = "紙張編號";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 75);
            this.toolStripLabel2.Text = "列印編號";
            this.toolStripLabel2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            this.toolStripLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // txtListId
            // 
            this.txtListId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtListId.Name = "txtListId";
            this.txtListId.Size = new System.Drawing.Size(200, 78);
            this.txtListId.Text = "12345";
            this.txtListId.ToolTipText = "列印編號";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(20, 75);
            this.toolStripLabel3.Text = "印表機";
            this.toolStripLabel3.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            this.toolStripLabel3.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // cbbPrinter
            // 
            this.cbbPrinter.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbbPrinter.Name = "cbbPrinter";
            this.cbbPrinter.Size = new System.Drawing.Size(200, 78);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1338, 810);
            this.panel3.TabIndex = 18;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewHead);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1338, 810);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 16;
            // 
            // dataGridViewHead
            // 
            this.dataGridViewHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FORMAT_ID,
            this.FORMAT_NAME,
            this.FORMAT_GROUP,
            this.FORMAT_WIDTH,
            this.FORMAT_HEIGHT,
            this.MEMO,
            this.EXAMPLE});
            this.dataGridViewHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHead.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHead.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewHead.Name = "dataGridViewHead";
            this.dataGridViewHead.RowTemplate.Height = 24;
            this.dataGridViewHead.Size = new System.Drawing.Size(1338, 216);
            this.dataGridViewHead.TabIndex = 23;
            this.dataGridViewHead.SelectionChanged += new System.EventHandler(this.dataGridViewHead_SelectionChanged);
            // 
            // FORMAT_ID
            // 
            this.FORMAT_ID.DataPropertyName = "FORMAT_ID";
            this.FORMAT_ID.HeaderText = "格式代號";
            this.FORMAT_ID.Name = "FORMAT_ID";
            // 
            // FORMAT_NAME
            // 
            this.FORMAT_NAME.DataPropertyName = "FORMAT_NAME";
            this.FORMAT_NAME.HeaderText = "格式名稱";
            this.FORMAT_NAME.Name = "FORMAT_NAME";
            // 
            // FORMAT_GROUP
            // 
            this.FORMAT_GROUP.DataPropertyName = "FORMAT_GROUP";
            this.FORMAT_GROUP.HeaderText = "格式群組";
            this.FORMAT_GROUP.Name = "FORMAT_GROUP";
            // 
            // FORMAT_WIDTH
            // 
            this.FORMAT_WIDTH.DataPropertyName = "FORMAT_WIDTH";
            this.FORMAT_WIDTH.HeaderText = "格式寬度";
            this.FORMAT_WIDTH.Name = "FORMAT_WIDTH";
            // 
            // FORMAT_HEIGHT
            // 
            this.FORMAT_HEIGHT.DataPropertyName = "FORMAT_HEIGHT";
            this.FORMAT_HEIGHT.HeaderText = "格式高度";
            this.FORMAT_HEIGHT.Name = "FORMAT_HEIGHT";
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "備註";
            this.MEMO.Name = "MEMO";
            // 
            // EXAMPLE
            // 
            this.EXAMPLE.DataPropertyName = "EXAMPLE";
            this.EXAMPLE.HeaderText = "範列";
            this.EXAMPLE.Name = "EXAMPLE";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1338, 551);
            this.panel2.TabIndex = 25;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ID,
            this._FORMAT_ID,
            this._MEMO,
            this._FORMAT_SEQ,
            this._PRINT_TYPE,
            this._FONT_NAME,
            this._FONT_SIZE,
            this._FONT_STYLE,
            this._FONT_COLOR,
            this._X_SITE,
            this._Y_SITE,
            this._WIDTH,
            this._HEIGHT,
            this._VERTICAL_ALIGN,
            this._HORIZONTAL_ALIGN,
            this._MATRIX,
            this._X_ZOOM,
            this._Y_ZOOM,
            this._DIRECTION_VERTICAL,
            this._CRT_DATE});
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.RowTemplate.Height = 24;
            this.dataGridViewDetail.Size = new System.Drawing.Size(1338, 551);
            this.dataGridViewDetail.TabIndex = 16;
            // 
            // _ID
            // 
            this._ID.DataPropertyName = "ID";
            this._ID.HeaderText = "ID";
            this._ID.Name = "_ID";
            this._ID.Visible = false;
            // 
            // _FORMAT_ID
            // 
            this._FORMAT_ID.DataPropertyName = "FORMAT_ID";
            this._FORMAT_ID.HeaderText = "格式代號";
            this._FORMAT_ID.Name = "_FORMAT_ID";
            // 
            // _MEMO
            // 
            this._MEMO.DataPropertyName = "MEMO";
            this._MEMO.HeaderText = "備註";
            this._MEMO.MaxInputLength = 200;
            this._MEMO.Name = "_MEMO";
            // 
            // _FORMAT_SEQ
            // 
            this._FORMAT_SEQ.DataPropertyName = "FORMAT_SEQ";
            this._FORMAT_SEQ.HeaderText = "格式順序";
            this._FORMAT_SEQ.Name = "_FORMAT_SEQ";
            // 
            // _PRINT_TYPE
            // 
            this._PRINT_TYPE.DataPropertyName = "PRINT_TYPE";
            this._PRINT_TYPE.HeaderText = "列印類別";
            this._PRINT_TYPE.Name = "_PRINT_TYPE";
            this._PRINT_TYPE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._PRINT_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _FONT_NAME
            // 
            this._FONT_NAME.DataPropertyName = "FONT_NAME";
            this._FONT_NAME.HeaderText = "字型名稱";
            this._FONT_NAME.Name = "_FONT_NAME";
            // 
            // _FONT_SIZE
            // 
            this._FONT_SIZE.DataPropertyName = "FONT_SIZE";
            this._FONT_SIZE.HeaderText = "字型大小";
            this._FONT_SIZE.Name = "_FONT_SIZE";
            // 
            // _FONT_STYLE
            // 
            this._FONT_STYLE.DataPropertyName = "FONT_STYLE";
            this._FONT_STYLE.HeaderText = "字型Style";
            this._FONT_STYLE.Name = "_FONT_STYLE";
            // 
            // _FONT_COLOR
            // 
            this._FONT_COLOR.DataPropertyName = "FONT_COLOR";
            this._FONT_COLOR.HeaderText = "字型顏色 ";
            this._FONT_COLOR.Name = "_FONT_COLOR";
            // 
            // _X_SITE
            // 
            this._X_SITE.DataPropertyName = "X_SITE";
            this._X_SITE.HeaderText = "列印起點X";
            this._X_SITE.Name = "_X_SITE";
            // 
            // _Y_SITE
            // 
            this._Y_SITE.DataPropertyName = "Y_SITE";
            this._Y_SITE.HeaderText = "列印起點Y";
            this._Y_SITE.Name = "_Y_SITE";
            // 
            // _WIDTH
            // 
            this._WIDTH.DataPropertyName = "WIDTH";
            this._WIDTH.HeaderText = "列印寬度";
            this._WIDTH.Name = "_WIDTH";
            // 
            // _HEIGHT
            // 
            this._HEIGHT.DataPropertyName = "HEIGHT";
            this._HEIGHT.HeaderText = "列印高度";
            this._HEIGHT.Name = "_HEIGHT";
            // 
            // _VERTICAL_ALIGN
            // 
            this._VERTICAL_ALIGN.DataPropertyName = "VERTICAL_ALIGN";
            this._VERTICAL_ALIGN.HeaderText = "垂直對齊";
            this._VERTICAL_ALIGN.Name = "_VERTICAL_ALIGN";
            // 
            // _HORIZONTAL_ALIGN
            // 
            this._HORIZONTAL_ALIGN.DataPropertyName = "HORIZONTAL_ALIGN";
            this._HORIZONTAL_ALIGN.HeaderText = "水平對齊";
            this._HORIZONTAL_ALIGN.Name = "_HORIZONTAL_ALIGN";
            // 
            // _MATRIX
            // 
            this._MATRIX.DataPropertyName = "MATRIX";
            this._MATRIX.FalseValue = "False";
            this._MATRIX.HeaderText = "向量字";
            this._MATRIX.Name = "_MATRIX";
            this._MATRIX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._MATRIX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._MATRIX.TrueValue = "True";
            // 
            // _X_ZOOM
            // 
            this._X_ZOOM.DataPropertyName = "X_ZOOM";
            this._X_ZOOM.HeaderText = "縮放寬度倍數";
            this._X_ZOOM.Name = "_X_ZOOM";
            // 
            // _Y_ZOOM
            // 
            this._Y_ZOOM.DataPropertyName = "Y_ZOOM";
            this._Y_ZOOM.HeaderText = "縮放高度倍數";
            this._Y_ZOOM.Name = "_Y_ZOOM";
            // 
            // _DIRECTION_VERTICAL
            // 
            this._DIRECTION_VERTICAL.DataPropertyName = "DIRECTION_VERTICAL";
            this._DIRECTION_VERTICAL.FalseValue = "False";
            this._DIRECTION_VERTICAL.HeaderText = "直印文字";
            this._DIRECTION_VERTICAL.IndeterminateValue = "False";
            this._DIRECTION_VERTICAL.Name = "_DIRECTION_VERTICAL";
            this._DIRECTION_VERTICAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._DIRECTION_VERTICAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._DIRECTION_VERTICAL.TrueValue = "True";
            // 
            // _CRT_DATE
            // 
            this._CRT_DATE.DataPropertyName = "CRT_DATE";
            this._CRT_DATE.HeaderText = "建立日期";
            this._CRT_DATE.Name = "_CRT_DATE";
            this._CRT_DATE.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.chkDrawRect);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1338, 39);
            this.panel4.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "@@SIZE||COLOR||STYLE||ZOOMW||ZOOMH||BOX||BCODE||HEIGHT";
            this.ToolTip.SetToolTip(this.label2, "參數說明：\r\nSIZE：字型大小\r\nCOLOR：字串顏色\r\nSTYLE：字串樣式\r\nZOOMW：字串寬度放大倍率\r\nZOOMH：字串高度放大倍率\r\nBOX：顯示框" +
        "線\r\nBCODE：動態設定Barcode\r\nHEIGHT：動態調整高度\r\n");
            // 
            // chkDrawRect
            // 
            this.chkDrawRect.AutoSize = true;
            this.chkDrawRect.Location = new System.Drawing.Point(119, 11);
            this.chkDrawRect.Name = "chkDrawRect";
            this.chkDrawRect.Size = new System.Drawing.Size(124, 24);
            this.chkDrawRect.TabIndex = 19;
            this.chkDrawRect.Text = "顯示測式框線";
            this.chkDrawRect.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "格式Detail";
            // 
            // OptionFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OptionFormat";
            this.Size = new System.Drawing.Size(1338, 888);
            this.Load += new System.EventHandler(this.OptionFormat_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHead)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripTextBox txtPaperId;
        private System.Windows.Forms.ToolStripTextBox txtListId;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton btnPreviewAll;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStripComboBox cbbPrinter;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMAT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMAT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMAT_GROUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMAT_WIDTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMAT_HEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAMPLE;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _FORMAT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _FORMAT_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn _PRINT_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn _FONT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _FONT_SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn _FONT_STYLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn _FONT_COLOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn _X_SITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Y_SITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn _WIDTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn _VERTICAL_ALIGN;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HORIZONTAL_ALIGN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _MATRIX;
        private System.Windows.Forms.DataGridViewTextBoxColumn _X_ZOOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Y_ZOOM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _DIRECTION_VERTICAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CRT_DATE;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDrawRect;
        private System.Windows.Forms.Label label1;
    }
}
