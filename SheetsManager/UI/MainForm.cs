using Autodesk.Revit.UI;
using SheetsManager.Revit;
using System;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;


namespace SheetsManager.UI
{
    public partial class MainForm : Form
    {
        public static string GAPIPath { get; set; }
        public MainForm()
        {
            
            InitializeComponent();
            InitializeSheetsTable();
            InitializeViewsTable();
            ExtCmd.SheetsChanged += UpdateData;
        }

        private void AddNewSheetBtn_Click(object sender, EventArgs e)
        {
            AddNewSheetForm addNewSheetForm = new AddNewSheetForm();
            addNewSheetForm.Show();
        }

        private void InitializeSheetsTable()
        {
            SheetsTable.DataSource = RevitData.STable;
            FlagVariable.PerformAction();
        }
        private void UpdateData()
        {
            InitializeSheetsTable();
            InitializeViewsTable();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            ExtCmd.SheetsChanged -= UpdateData;
        }

        private void AddParametersBTN_Click(object sender, EventArgs e)
        {
            ParametersForm parametersForm = new ParametersForm();
            parametersForm.Show();
        }


        private void InitializeViewsTable()
        {
            ViewsTable.DataSource = RevitData.VTable;
            FlagVariable.PerformAction();
        }
        private void SheetsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string selection = SheetsTable.SelectedCells[0].Value.ToString();
                RevitData.ColName = SheetsTable.SelectedCells[0].OwningColumn.Name;
                int colIndex = SheetsTable.SelectedCells[0].OwningColumn.Index;
                int rIndex = int.Parse(SheetsTable.SelectedCells[0].RowIndex.ToString());
                RevitData.SheetName = SheetsTable.Rows[rIndex].Cells[0].Value.ToString();
                RevitData.SheetId = int.Parse(SheetsTable.Rows[rIndex].Cells[3].Value.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void SheetsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string selection = SheetsTable.SelectedCells[0].Value.ToString();
                RevitData.ColName = SheetsTable.SelectedCells[0].OwningColumn.Name;
                int colIndex = SheetsTable.SelectedCells[0].OwningColumn.Index;
                int rIndex = int.Parse(SheetsTable.SelectedCells[0].RowIndex.ToString());
                RevitData.SheetName = SheetsTable.Rows[rIndex].Cells[0].Value.ToString();
                RevitData.SheetId = int.Parse(SheetsTable.Rows[rIndex].Cells[3].Value.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void SheetsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (SheetsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // Get the new value of the cell
                RevitData.CellNewValue = SheetsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                ExtCmd.ExtEventHandler.Request = Request.ParameterEdited;
                ExtCmd.ExtEvent.Raise();
            }
        }

        private void AddViewBTN_Click(object sender, EventArgs e)
        {
            AddViewsForm addViewsForm = new AddViewsForm();
            addViewsForm.Show();
        }
        private void ViewsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RevitData.ViewName = ViewsTable[e.ColumnIndex, e.RowIndex].Value.ToString();
            int rIndex = int.Parse(ViewsTable.SelectedCells[0].RowIndex.ToString());
            RevitData.SheetName = ViewsTable.Rows[rIndex].Cells[0].Value.ToString();
        }
        private void ViewsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RevitData.ViewName = ViewsTable[e.ColumnIndex, e.RowIndex].Value.ToString();
            int rIndex = int.Parse(ViewsTable.SelectedCells[0].RowIndex.ToString());
            RevitData.SheetName = ViewsTable.Rows[rIndex].Cells[0].Value.ToString();
        }
        private void RemoveViewBTN_Click(object sender, EventArgs e)
        {
            ExtCmd.ExtEventHandler.Request = Request.RemoveView;
            ExtCmd.ExtEvent.Raise();
        }

        private void ExportImportBTN_Click(object sender, EventArgs e)
        {
            ExportImportForm exportImportForm = new ExportImportForm();
            exportImportForm.Show();
        }

        private void ExportImport2BTN_Click(object sender, EventArgs e)
        {
            ExportImportVForm exportImportVForm = new ExportImportVForm();
            exportImportVForm.Show();
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            GAPIPath = TextBox1.Text;
        }

        private void ExportBTN_Click(object sender, EventArgs e)
        {
            if (GAPIPath == null)
            {
                TaskDialog.Show("Error", "Please Choose A File");
            }
            else
            {
                string CredentialsPath = "E:\\Downloads 2\\CFile.json";
                string FolderId = "12fcD0ukMJ8iYO_qWwuFQy-RczljYt1YL";
                string FileToUploadPath = GAPIPath;
                GooglAPI.UploadFilesToGoogleDrive(CredentialsPath, FolderId, FileToUploadPath);//The SystemIO Error was because diroots used 1.67 Google.Apis.Drive.v3 instead of 1.68 and also these files are in revit addins directory C:\ProgramData\Autodesk\Revit\Addins\2021 not that in bin/debug that is read
            }
        }
    }
}
