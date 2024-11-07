using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SheetsManager.Revit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace SheetsManager.UI
{
    public partial class AddNewSheetForm : Form
    {
        public event Action DataUpdated;
        public AddNewSheetForm()
        {
            InitializeComponent();
            List<string> TittleblocksList = RevitUtils.Get_Sheets(ExtCmd.doc).Select(s=> s.Name).ToList();
            SheetsListCB.Items.AddRange(TittleblocksList.ToArray());

        }
        private void CreateSheetsBTN_Click(object sender, EventArgs e)
        {
            // Raise external event
            ExtCmd.ExtEventHandler.Request = Request.CreateSheet;
            ExtCmd.ExtEvent.Raise();

            // Subscribe to SheetsChanged event to close the form after data update
            ExtCmd.SheetsChanged += OnSheetsChanged;
            this.Close();
        }
        private void OnSheetsChanged()
        {
            // Unsubscribe from the SheetsChanged event to avoid multiple triggers
            ExtCmd.SheetsChanged -= OnSheetsChanged;

            // Trigger the DataUpdated event
            DataUpdated?.Invoke();

            // Close the form
            this.Close();
        }

        private void NOfSheetsTB_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(NOfSheetsTB.Text, out int numOfSheets))
            {
                RevitData.NumOfSheets = numOfSheets;
            }
            else if (NOfSheetsTB.Text == ""); //To Prevent The MeesageBox from showing again after TB is cleared
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NOfSheetsTB.Clear();
            }
        }

        private void SheetsListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RevitData.MySheet = RevitUtils.Get_Sheets(ExtCmd.doc).Where(s=>s.Name.Contains(SheetsListCB.Text)).First();
        }
    }
}
