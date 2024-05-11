using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportingEngine.Option;

namespace ReportingEngine
{
    public partial class FormOption : Form
    {
        //private OptionPaper optPaper = new OptionPaper();
        //private OptionFormat optFormat = new OptionFormat();
        //private OptionPrinter optPrinter = new OptionPrinter();
        //private OptionArea optArea = new OptionArea();
        private UserControl currentControl = new UserControl();

        public FormOption()
        {
            InitializeComponent();                       
        }


        private void FormOption_Load(object sender, EventArgs e)
        {

            this.Dock = DockStyle.Fill;

            TreeNode root = new TreeNode();
            root.Text = "列印設定";
            root.Tag = typeof(OptionFormat);
            treeViewOption.Nodes.Add(root);

            TreeNode paper = new TreeNode();
            paper.Text = "紙張設定";
            paper.Tag = typeof(OptionPaper);
            root.Nodes.Add(paper);

            TreeNode format = new TreeNode();
            format.Text = "格式設定";
            format.Tag = typeof(OptionFormat);
            root.Nodes.Add(format);

            TreeNode printer = new TreeNode();
            printer.Text = "印表機設定";
            printer.Tag = typeof(OptionPrinter);
            root.Nodes.Add(printer);

            TreeNode area = new TreeNode();
            area.Text = "列印區域設定";
            area.Tag = typeof(OptionArea);
            root.Nodes.Add(area);

            root.ExpandAll();
        }

        private void treeViewOption_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView item = (TreeView)sender;

            if (currentControl != null)
            {
                currentControl.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            if (item.SelectedNode.Tag == null)
                return;

            currentControl = (UserControl)Activator.CreateInstance((Type)item.SelectedNode.Tag);
            currentControl.Width = panelOption.Width;
            currentControl.Height = panelOption.Height;
            panelOption.Controls.Add(currentControl);

        }

        private void panelOption_Resize(object sender, EventArgs e)
        {
            currentControl.Width = panelOption.Width;
            currentControl.Height = panelOption.Height;
        }
    }
}
