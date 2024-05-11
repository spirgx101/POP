namespace ReportingEngine
{
    partial class FormOption
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
            this.treeViewOption = new System.Windows.Forms.TreeView();
            this.panelTreeView = new System.Windows.Forms.Panel();
            this.panelOption = new System.Windows.Forms.Panel();
            this.panelTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewOption
            // 
            this.treeViewOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewOption.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.treeViewOption.Location = new System.Drawing.Point(0, 0);
            this.treeViewOption.Margin = new System.Windows.Forms.Padding(5);
            this.treeViewOption.Name = "treeViewOption";
            this.treeViewOption.Size = new System.Drawing.Size(146, 624);
            this.treeViewOption.TabIndex = 0;
            this.treeViewOption.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewOption_AfterSelect);
            // 
            // panelTreeView
            // 
            this.panelTreeView.Controls.Add(this.treeViewOption);
            this.panelTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTreeView.Location = new System.Drawing.Point(0, 0);
            this.panelTreeView.Name = "panelTreeView";
            this.panelTreeView.Size = new System.Drawing.Size(146, 624);
            this.panelTreeView.TabIndex = 5;
            // 
            // panelOption
            // 
            this.panelOption.AutoSize = true;
            this.panelOption.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOption.Location = new System.Drawing.Point(146, 0);
            this.panelOption.Name = "panelOption";
            this.panelOption.Size = new System.Drawing.Size(768, 624);
            this.panelOption.TabIndex = 6;
            this.panelOption.Resize += new System.EventHandler(this.panelOption_Resize);
            // 
            // FormOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 624);
            this.ControlBox = false;
            this.Controls.Add(this.panelOption);
            this.Controls.Add(this.panelTreeView);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPriceSetting";
            this.Load += new System.EventHandler(this.FormOption_Load);
            this.panelTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewOption;
        private System.Windows.Forms.Panel panelTreeView;
        private System.Windows.Forms.Panel panelOption;
    }
}