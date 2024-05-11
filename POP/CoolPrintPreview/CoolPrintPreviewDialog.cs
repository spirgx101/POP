using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace CoolPrintPreview
{
    /// <summary>
    /// Represents a dialog containing a <see cref="CoolPrintPreviewControl"/> control
    /// used to preview and print <see cref="PrintDocument"/> objects.
    /// </summary>
    /// <remarks>
    /// This dialog is similar to the standard <see cref="PrintPreviewDialog"/>
    /// but provides additional options such printer and page setup buttons,
    /// a better UI based on the <see cref="ToolStrip"/> control, and built-in
    /// PDF export.
    /// </remarks>
    internal partial class CoolPrintPreviewDialog : Form
    {
       
        //--------------------------------------------------------------------
        #region ** fields

        PrintDocument _doc;
        PrintSetting _setting = new PrintSetting();
        bool _printed = false;

        #endregion

        //--------------------------------------------------------------------
        #region ** ctor

        /// <summary>
        /// Initializes a new instance of a <see cref="CoolPrintPreviewDialog"/>.
        /// </summary>
        public CoolPrintPreviewDialog() : this(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of a <see cref="CoolPrintPreviewDialog"/>.
        /// </summary>
        /// <param name="parentForm">Parent form that defines the initial size for this dialog.</param>
        public CoolPrintPreviewDialog(Control parentForm)
        {
            InitializeComponent();
            if (parentForm != null)
            {
                Size = parentForm.Size;
            }           
        }
        public CoolPrintPreviewDialog(DataTable print_data, DataTable format_headers, DataTable format_details, string paper_id, int max_page, string printer, string print_source)
        {
            PrintData = print_data;
            Paper = paper_id;
            Max_Page = max_page;
            InitializeComponent();
            _preview.PrintData = PrintData;
            _preview.FormatHeaders = format_headers;
            _preview.FormatDetails = format_details;
            _preview.Paper = Paper;
            _preview.Max_Page = Max_Page;
            _preview.StartPage = 1;
            _preview.Printer = printer;
            _preview.Print_Source = print_source;
            _progress.Maximum = _preview.PageCount;
        }
        #endregion

        //--------------------------------------------------------------------
        #region ** object model

        /// <summary>
        /// Gets or sets the <see cref="PrintDocument"/> to preview.
        /// </summary>
        public PrintDocument Document
        {
            get { return _doc; }
            set
            {
                // unhook event handlers
                if (_doc != null)
                {
                    _doc.BeginPrint -= _doc_BeginPrint;
                    _doc.EndPrint -= _doc_EndPrint;
                }

                // save the value
                _doc = value;

                // hook up event handlers
                if (_doc != null)
                {
                    _doc.BeginPrint += _doc_BeginPrint;
                    _doc.EndPrint += _doc_EndPrint;
                }


                // don't assign document to preview until this form becomes visible
                if (Visible)
                {
                    _preview.Document = Document;
                }
            }
        }
        public DataTable PrintData { get; set; }
        public string Paper { get; set; }
        public int Max_Page { get; set; }
        public int Current_Page { get; set; }
        public bool Printed { get { return _printed; } }
        #endregion

        //--------------------------------------------------------------------
        #region ** overloads

        /// <summary>
        /// Overridden to assign document to preview control only after the 
        /// initial activation.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //_preview.Document = Document;
        }
        /// <summary>
        /// Overridden to cancel any ongoing previews when closing form.
        /// </summary>
        /// <param name="e"><see cref="FormClosingEventArgs"/> that contains the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_preview.IsRendering && !e.Cancel)
            {
                _preview.Cancel();
            }
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** main commands

        void _btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintDialog(Max_Page, _preview.Printer, ref _setting) == DialogResult.OK)
                {
                    _preview.StopPrint = false;
                    _progress.Maximum = _setting.ToPage - _setting.FromPage;
                    _progress.Value = 0;
                    _preview.Print(_setting);
                    if (_progress.Maximum > 1)
                    {
                        _btnCancel.Visible = true;
                        _progress.Visible = true;
                    }
                    _printed = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        public static DialogResult PrintDialog(int max_page, string printer, ref PrintSetting value)
        {
            Form frmPrintDialog = new Form();
            Label lbPrinter = new Label();
            ComboBox cbPrinter = new ComboBox();
            Label lbPaperSource = new Label();
            ComboBox cbPaperSource = new ComboBox();
            GroupBox gbPaperRange = new GroupBox();
            RadioButton rbFullPage = new RadioButton();
            RadioButton rbSelectPage = new RadioButton();
            TextBox txtPage = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            Label lbExample = new Label();
            PrintDocument printDoc = new PrintDocument();
            PaperSource pkSource;
            //string sDefaultString = "黑白";
            //frmPrintDialog.TopMost = true;

            //String sDefaultPrinter = printDoc.PrinterSettings.PrinterName;  // 取得預設的印表機名稱          

            frmPrintDialog.Text = "列印";
            lbPrinter.Text = "印表機";
            lbPaperSource.Text = "送紙匣";
            gbPaperRange.Text = "頁面範圍";
            rbFullPage.Text = "全部頁面";
            rbSelectPage.Text = "選擇頁數";
            lbExample.Text = "( 1-100 )";
            txtPage.Text = "1-" + max_page.ToString();

            buttonOk.Text = "列印(&P)";
            buttonCancel.Text = "取消(&C)";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            lbPrinter.SetBounds(10, 15, 45, 20);
            cbPrinter.SetBounds(90, 12, 250, 20);
            lbPaperSource.SetBounds(10, 50, 45, 25);
            cbPaperSource.SetBounds(90, 47, 250, 25);
            gbPaperRange.SetBounds(10, 80, 325, 90);
            txtPage.SetBounds(12, 36, 50, 20);
            buttonOk.SetBounds(220, 178, 80, 29);
            buttonCancel.SetBounds(305, 178, 80, 29);
            rbFullPage.Location = new Point(20, 25);
            rbSelectPage.Location = new Point(20, 55);
            txtPage.Location = new Point(120, 50);
            txtPage.Size = new Size(100, 20);
            lbExample.Location = new Point(240, 55);

            lbPrinter.AutoSize = true;
            cbPrinter.DropDownStyle = ComboBoxStyle.DropDownList;
            lbPaperSource.AutoSize = true;
            rbFullPage.AutoSize = true;
            rbSelectPage.AutoSize = true;
            lbExample.AutoSize = true;
            cbPaperSource.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPage.Anchor = txtPage.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbExample.ForeColor = Color.DimGray;
            rbFullPage.Checked = true;
            rbSelectPage.Checked = false;

            gbPaperRange.Controls.Add(rbFullPage);
            gbPaperRange.Controls.Add(rbSelectPage);
            gbPaperRange.Controls.Add(txtPage);
            gbPaperRange.Controls.Add(lbExample);

            frmPrintDialog.ClientSize = new Size(405, 215);
            frmPrintDialog.Controls.AddRange(new Control[] { lbPrinter, cbPrinter, lbPaperSource,
                cbPaperSource, gbPaperRange, buttonOk, buttonCancel });
            frmPrintDialog.ClientSize = new Size(Math.Max(355, lbPrinter.Right + 10), frmPrintDialog.ClientSize.Height);
            frmPrintDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmPrintDialog.StartPosition = FormStartPosition.CenterScreen;
            frmPrintDialog.MinimizeBox = false;
            frmPrintDialog.MaximizeBox = false;
            frmPrintDialog.AcceptButton = buttonOk;
            frmPrintDialog.CancelButton = buttonCancel;

            // 取得安裝於電腦上的所有印表機名稱，加入 ListBox (Name : lbInstalledPrinters) 中
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cbPrinter.Items.Add(strPrinter);
            }

            //MessageBox.Show(printer);

            // 2023.08.02 mdho 印表機名稱除去型號做模糊搜尋
            //if (printer.LastIndexOf('_') != -1)
            //{
            //    printer = printer.Substring(0, printer.LastIndexOf('_'));
            //    cbPrinter.SelectedIndex = cbPrinter.FindString(printer);
            //    //MessageBox.Show(printer);
            //}

            // ListBox (Name : lbInstalledPrinters) 選擇在預設印表機
            cbPrinter.SelectedIndex = cbPrinter.FindStringExact(printer);

            cbPaperSource.DisplayMember = "SourceName";


            try
            {
                for (int i = 0; i < printDoc.PrinterSettings.PaperSources.Count; i++)
                {
                    pkSource = printDoc.PrinterSettings.PaperSources[i];
                    cbPaperSource.Items.Add(pkSource);
                }

                //MessageBox.Show(cbPaperSource.Items.Count.ToString());
                //if (cbPaperSource.Items.Count != 0) cbPaperSource.SelectedIndex = 0;
                if (cbPaperSource.Items.Count != 0)
                {
                    for (int i = 0; i < cbPaperSource.Items.Count; i++)
                    {
                        cbPaperSource.SelectedIndex = i;
                        if (cbPrinter.Text.Contains(cbPaperSource.Text))
                        {
                            break;
                        }
                        else
                        {
                            cbPaperSource.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch { }
            


            DialogResult dialogResult = frmPrintDialog.ShowDialog();
               
            value.Printer = cbPrinter.Text;
            if (cbPaperSource.Items.Count != 0)
                value.Source = (PaperSource)cbPaperSource.SelectedItem;
            else
                value.Source = null;

            try
            {
                if (rbFullPage.Checked)
                    {
                        value.Range = PrintRange.AllPages;
                        value.SelectPage = txtPage.Text.Trim();
                    }

                    if (rbSelectPage.Checked)
                    {
                        value.Range = PrintRange.SomePages;
                        value.SelectPage = txtPage.Text.Trim();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dialogResult;
        }

       

        void _btnPageSetup_Click(object sender, EventArgs e)
        {
            using (var dlg = new PageSetupDialog())
            {
                dlg.Document = _preview.Document;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // to show new page layout
                    _preview.RefreshPreview();
                }
            }
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** zoom

        void _btnZoom_ButtonClick(object sender, EventArgs e)
        {
            _preview.ZoomMode = _preview.ZoomMode == ZoomMode.ActualSize
                ? ZoomMode.FullPage
                : ZoomMode.ActualSize;
        }
        void _btnZoom_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == _itemActualSize)
            {
                _preview.ZoomMode = ZoomMode.ActualSize;
            }
            else if (e.ClickedItem == _itemFullPage)
            {
                _preview.ZoomMode = ZoomMode.FullPage;
            }
            else if (e.ClickedItem == _itemPageWidth)
            {
                _preview.ZoomMode = ZoomMode.PageWidth;
            }
            else if (e.ClickedItem == _itemTwoPages)
            {
                _preview.ZoomMode = ZoomMode.TwoPages;
            }
            if (e.ClickedItem == _item10)
            {
                _preview.Zoom = .1;
            }
            else if (e.ClickedItem == _item100)
            {
                _preview.Zoom = 1;
            }
            else if (e.ClickedItem == _item150)
            {
                _preview.Zoom = 1.5;
            }
            else if (e.ClickedItem == _item200)
            {
                _preview.Zoom = 2;
            }
            else if (e.ClickedItem == _item25)
            {
                _preview.Zoom = .25;
            }
            else if (e.ClickedItem == _item50)
            {
                _preview.Zoom = .5;
            }
            else if (e.ClickedItem == _item500)
            {
                _preview.Zoom = 5;
            }
            else if (e.ClickedItem == _item75)
            {
                _preview.Zoom = .75;
            }
        }
        #endregion

        //--------------------------------------------------------------------
        #region ** page navigation

        void _btnFirst_Click(object sender, EventArgs e)
        {
            //_preview.StartPage = 0;
            _preview.StartPage = 1;
        }
        void _btnPrev_Click(object sender, EventArgs e)
        {
            _preview.StartPage--;
        }
        void _btnNext_Click(object sender, EventArgs e)
        {
            _preview.StartPage++;
        }
        void _btnLast_Click(object sender, EventArgs e)
        {
            //_preview.StartPage = _preview.PageCount - 1;
            _preview.StartPage = _preview.PageCount;
        }
        void _txtStartPage_Enter(object sender, EventArgs e)
        {
            _txtStartPage.SelectAll();
        }
        void _txtStartPage_Validating(object sender, CancelEventArgs e)
        {
            CommitPageNumber();
        }
        void _txtStartPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            if (c == (char)13)
            {
                CommitPageNumber();
                e.Handled = true;
            }
            else if (c > ' ' && !char.IsDigit(c))
            {
                e.Handled = true;
            }
        }
        void CommitPageNumber()
        {
            int page;
            if (int.TryParse(_txtStartPage.Text, out page))
            {
                //_preview.StartPage = page - 1;
                _preview.StartPage = page;
            }
        }
        void _preview_StartPageChanged(object sender, EventArgs e)
        {
            //var page = _preview.StartPage + 1;
            //var page = _preview.StartPage;
            _txtStartPage.Text = _preview.StartPage.ToString();
            if (_progress.Value + 1 < _progress.Maximum)
            {
                _progress.Value = _progress.Value + 1;
            }
            else
            {
                _progress.Maximum = _preview.PageCount;
                _progress.Visible = false;
                _btnCancel.Visible = false;
                this.MaximizeBox = true;
            }
        }
        private void _preview_PageCountChanged(object sender, EventArgs e)
        {
            this.Update();
            Application.DoEvents();
            _lblPageCount.Text = string.Format("of {0}", _preview.PageCount);           
        }

        #endregion

        //--------------------------------------------------------------------
        #region ** job control

        void _btnCancel_Click(object sender, EventArgs e)
        {
            //ResourceManager rm = new ResourceManager();

            if (_btnCancel.Text == "暫停列印")
            {
                _preview.StopPrint = true;
                _btnCancel.Image = POP.Properties.Resources.Play;
                _btnCancel.Text = "繼續列印";
                Current_Page = Convert.ToInt32(_txtStartPage.Text);
            }
            else
            {
                _preview.StopPrint = false;
                _setting.FromPage = Current_Page + 1;
                _preview.Print(_setting);
                _btnCancel.Image = POP.Properties.Resources.Pause;
                _btnCancel.Text = "暫停列印";
            }       
        }
        void _doc_BeginPrint(object sender, PrintEventArgs e)
        {
            _btnCancel.Text = "&Cancel";
            _btnPrint.Enabled = _btnPageSetup.Enabled = false;
        }
        void _doc_EndPrint(object sender, PrintEventArgs e)
        {
            _btnCancel.Text = "&Close";
            _btnPrint.Enabled = _btnPageSetup.Enabled = true;
        }

        #endregion

        private void _txtStartPage_TextChanged(object sender, EventArgs e)
        {
            if (_txtStartPage.Text.Trim() == Max_Page.ToString() && _btnCancel.Visible == true)
            {
                _btnCancel.Visible = false;
                _progress.Visible = false;
                this.MaximizeBox = true;
            }
        }

    }
}
