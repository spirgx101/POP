namespace ReportingEngine
{
    partial class FormMain
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.MenuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImageManage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImageLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImageTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFileTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLinked = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOption,
            this.MenuItemImageManage,
            this.MenuItemFileTrans,
            this.MenuItemLinked,
            this.MenuItemExit});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.MenuBar.Size = new System.Drawing.Size(801, 30);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // MenuItemOption
            // 
            this.MenuItemOption.Name = "MenuItemOption";
            this.MenuItemOption.Size = new System.Drawing.Size(105, 24);
            this.MenuItemOption.Text = "列印設定(&P)";
            this.MenuItemOption.Click += new System.EventHandler(this.MenuItemOption_Click);
            // 
            // MenuItemImageManage
            // 
            this.MenuItemImageManage.Checked = true;
            this.MenuItemImageManage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemImageManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemImageLoad,
            this.MenuItemImageTransfer});
            this.MenuItemImageManage.Name = "MenuItemImageManage";
            this.MenuItemImageManage.Size = new System.Drawing.Size(110, 24);
            this.MenuItemImageManage.Text = "圖片管理(&M)";
            // 
            // MenuItemImageLoad
            // 
            this.MenuItemImageLoad.Name = "MenuItemImageLoad";
            this.MenuItemImageLoad.Size = new System.Drawing.Size(161, 24);
            this.MenuItemImageLoad.Text = "圖片載入(&L)";
            this.MenuItemImageLoad.Click += new System.EventHandler(this.MenuItemImageLoad_Click);
            // 
            // MenuItemImageTransfer
            // 
            this.MenuItemImageTransfer.Name = "MenuItemImageTransfer";
            this.MenuItemImageTransfer.Size = new System.Drawing.Size(161, 24);
            this.MenuItemImageTransfer.Text = "圖片下傳(&T)";
            this.MenuItemImageTransfer.Click += new System.EventHandler(this.MenuItemImageTransfer_Click);
            // 
            // MenuItemFileTrans
            // 
            this.MenuItemFileTrans.Name = "MenuItemFileTrans";
            this.MenuItemFileTrans.Size = new System.Drawing.Size(103, 24);
            this.MenuItemFileTrans.Text = "字型傳輸(&F)";
            this.MenuItemFileTrans.Click += new System.EventHandler(this.MenuItemFileTrans_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(73, 24);
            this.MenuItemExit.Text = "離開(&X)";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MenuItemLinked
            // 
            this.MenuItemLinked.Name = "MenuItemLinked";
            this.MenuItemLinked.Size = new System.Drawing.Size(89, 24);
            this.MenuItemLinked.Text = "Linked(&L)";
            this.MenuItemLinked.Click += new System.EventHandler(this.MenuItemLinked_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 405);
            this.Controls.Add(this.MenuBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuBar;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormMain";
            this.Text = "ReportingEngine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOption;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImageManage;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImageLoad;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImageTransfer;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFileTrans;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLinked;
    }
}

