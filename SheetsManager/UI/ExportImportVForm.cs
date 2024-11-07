using SheetsManager.Revit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheetsManager.UI
{
    public partial class ExportImportVForm : Form
    {
        public static string VFpath { get; set; }
        public static string IVFpath { get; set; }
        public ExportImportVForm()
        {
            InitializeComponent();
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox1.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            VFpath = TextBox1.Text;
        }

        private void ExportBTN_Click(object sender, EventArgs e)
        {
            RevitUtils.ExportViewsReport(ExtCmd.doc, RevitData.VTable, VFpath, RevitData.ViewtableColumns);
        }

        private void Browse2BTN_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox2.Text = openFileDialog.FileName;
                }
            }
        }

        private void AddViewsBTN_Click(object sender, EventArgs e)
        {
            RevitData.ImportedVTable = RevitUtils.ImportVDataFromFile(RevitData.ImportedVTable, IVFpath);
            ExtCmd.ExtEventHandler.Request = Request.CreateViewFromFile;
            ExtCmd.ExtEvent.Raise();
            this.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            IVFpath = TextBox2.Text;
        }
    }
}
