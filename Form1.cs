using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace compbrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebBrowser web = new WebBrowser();
        int i = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i += 1;



        }

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();

        }

        private void addpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i += 1;

        }

        private void removepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
