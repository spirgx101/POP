namespace ReportingEngine
{
    partial class FormImageTest
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
            this.lbSource = new System.Windows.Forms.Label();
            this.txtSourceIp = new System.Windows.Forms.TextBox();
            this.txtSourceDB = new System.Windows.Forms.TextBox();
            this.txtDestDB = new System.Windows.Forms.TextBox();
            this.txtDestIp = new System.Windows.Forms.TextBox();
            this.lbDest = new System.Windows.Forms.Label();
            this.btnTransImag = new System.Windows.Forms.Button();
            this.lbStart = new System.Windows.Forms.Label();
            this.labEnd = new System.Windows.Forms.Label();
            this.lbStartValue = new System.Windows.Forms.Label();
            this.lbEndValue = new System.Windows.Forms.Label();
            this.lbBetween = new System.Windows.Forms.Label();
            this.lbBetweenValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSource
            // 
            this.lbSource.AutoSize = true;
            this.lbSource.Location = new System.Drawing.Point(34, 39);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(73, 20);
            this.lbSource.TabIndex = 0;
            this.lbSource.Text = "來    源：";
            // 
            // txtSourceIp
            // 
            this.txtSourceIp.Location = new System.Drawing.Point(114, 36);
            this.txtSourceIp.Name = "txtSourceIp";
            this.txtSourceIp.Size = new System.Drawing.Size(143, 29);
            this.txtSourceIp.TabIndex = 1;
            this.txtSourceIp.Text = "172.31.31.250";
            // 
            // txtSourceDB
            // 
            this.txtSourceDB.Location = new System.Drawing.Point(274, 36);
            this.txtSourceDB.Name = "txtSourceDB";
            this.txtSourceDB.Size = new System.Drawing.Size(100, 29);
            this.txtSourceDB.TabIndex = 2;
            this.txtSourceDB.Text = "PXMSDE";
            // 
            // txtDestDB
            // 
            this.txtDestDB.Location = new System.Drawing.Point(274, 82);
            this.txtDestDB.Name = "txtDestDB";
            this.txtDestDB.Size = new System.Drawing.Size(100, 29);
            this.txtDestDB.TabIndex = 5;
            this.txtDestDB.Text = "PXMSDE";
            // 
            // txtDestIp
            // 
            this.txtDestIp.Location = new System.Drawing.Point(114, 82);
            this.txtDestIp.Name = "txtDestIp";
            this.txtDestIp.Size = new System.Drawing.Size(143, 29);
            this.txtDestIp.TabIndex = 4;
            this.txtDestIp.Text = "172.31.34.3";
            // 
            // lbDest
            // 
            this.lbDest.AutoSize = true;
            this.lbDest.Location = new System.Drawing.Point(34, 85);
            this.lbDest.Name = "lbDest";
            this.lbDest.Size = new System.Drawing.Size(73, 20);
            this.lbDest.TabIndex = 3;
            this.lbDest.Text = "目的地：";
            // 
            // btnTransImag
            // 
            this.btnTransImag.Location = new System.Drawing.Point(410, 36);
            this.btnTransImag.Name = "btnTransImag";
            this.btnTransImag.Size = new System.Drawing.Size(172, 75);
            this.btnTransImag.TabIndex = 6;
            this.btnTransImag.Text = "傳送圖片";
            this.btnTransImag.UseVisualStyleBackColor = true;
            this.btnTransImag.Click += new System.EventHandler(this.btnTransImag_Click);
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(34, 138);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(89, 20);
            this.lbStart.TabIndex = 7;
            this.lbStart.Text = "開始時間：";
            // 
            // labEnd
            // 
            this.labEnd.AutoSize = true;
            this.labEnd.Location = new System.Drawing.Point(34, 176);
            this.labEnd.Name = "labEnd";
            this.labEnd.Size = new System.Drawing.Size(89, 20);
            this.labEnd.TabIndex = 8;
            this.labEnd.Text = "結束時間：";
            // 
            // lbStartValue
            // 
            this.lbStartValue.AutoSize = true;
            this.lbStartValue.Location = new System.Drawing.Point(129, 138);
            this.lbStartValue.Name = "lbStartValue";
            this.lbStartValue.Size = new System.Drawing.Size(161, 20);
            this.lbStartValue.TabIndex = 9;
            this.lbStartValue.Text = "0000/00/00 00:00:00";
            // 
            // lbEndValue
            // 
            this.lbEndValue.AutoSize = true;
            this.lbEndValue.Location = new System.Drawing.Point(129, 176);
            this.lbEndValue.Name = "lbEndValue";
            this.lbEndValue.Size = new System.Drawing.Size(161, 20);
            this.lbEndValue.TabIndex = 10;
            this.lbEndValue.Text = "0000/00/00 00:00:00";
            // 
            // lbBetween
            // 
            this.lbBetween.AutoSize = true;
            this.lbBetween.Location = new System.Drawing.Point(34, 215);
            this.lbBetween.Name = "lbBetween";
            this.lbBetween.Size = new System.Drawing.Size(89, 20);
            this.lbBetween.TabIndex = 11;
            this.lbBetween.Text = "經歷時間：";
            // 
            // lbBetweenValue
            // 
            this.lbBetweenValue.AutoSize = true;
            this.lbBetweenValue.Location = new System.Drawing.Point(133, 215);
            this.lbBetweenValue.Name = "lbBetweenValue";
            this.lbBetweenValue.Size = new System.Drawing.Size(30, 20);
            this.lbBetweenValue.TabIndex = 12;
            this.lbBetweenValue.Text = "---";
            // 
            // FormImageTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 258);
            this.Controls.Add(this.lbBetweenValue);
            this.Controls.Add(this.lbBetween);
            this.Controls.Add(this.lbEndValue);
            this.Controls.Add(this.lbStartValue);
            this.Controls.Add(this.labEnd);
            this.Controls.Add(this.lbStart);
            this.Controls.Add(this.btnTransImag);
            this.Controls.Add(this.txtDestDB);
            this.Controls.Add(this.txtDestIp);
            this.Controls.Add(this.lbDest);
            this.Controls.Add(this.txtSourceDB);
            this.Controls.Add(this.txtSourceIp);
            this.Controls.Add(this.lbSource);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormImageTest";
            this.Text = "圖檔傳送測試";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSource;
        private System.Windows.Forms.TextBox txtSourceIp;
        private System.Windows.Forms.TextBox txtSourceDB;
        private System.Windows.Forms.TextBox txtDestDB;
        private System.Windows.Forms.TextBox txtDestIp;
        private System.Windows.Forms.Label lbDest;
        private System.Windows.Forms.Button btnTransImag;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Label labEnd;
        private System.Windows.Forms.Label lbStartValue;
        private System.Windows.Forms.Label lbEndValue;
        private System.Windows.Forms.Label lbBetween;
        private System.Windows.Forms.Label lbBetweenValue;
    }
}