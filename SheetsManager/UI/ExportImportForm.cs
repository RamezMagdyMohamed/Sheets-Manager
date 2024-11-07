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
    public partial class ExportImportForm : Form
    {
        public static string Fpath { get; set; }
        public static string IFpath { get; set; }
        public ExportImportForm()
        {
            InitializeComponent();
            List<string> TittleblocksList = RevitUtils.Get_Sheets(ExtCmd.doc).Select(s => s.Name).ToList();
            TemplateCB.Items.AddRange(TittleblocksList.ToArray());
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Fpath = TextBox1.Text;
        }

        private void ExportBTN_Click(object sender, EventArgs e)
        {
            RevitUtils.ExportReport(ExtCmd.doc);
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

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            IFpath = TextBox2.Text;
        }

        private void CreateSheetsBTN_Click(object sender, EventArgs e)
        {
            
            ExtCmd.ExtEventHandler.Request = Request.CreateSheetFromFile;
            ExtCmd.ExtEvent.Raise();
        }

        private void TemplateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RevitData.SheetTemplate = RevitUtils.Get_Sheets(ExtCmd.doc).Where(s => s.Name.Contains(TemplateCB.Text)).First();
        }
    }
}
