using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SheetsManager.Revit;
using System;
using System.Collections.Generic;
using System.Linq;
using Form = System.Windows.Forms.Form;

namespace SheetsManager.UI
{
    public partial class ParametersForm : Form
    {
        public static string path { get; set; }
        
        public ParametersForm()
        {
            InitializeComponent();
            IList<string> ParametersNames = RevitUtils.GetSheetParameterNames(ExtCmd.doc);
            ParametersCB.Items.AddRange(ParametersNames.ToArray());
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            ExtCmd.ExtEventHandler.Request = Request.CreateParameter;
            ExtCmd.ExtEvent.Raise();
            this.Close();
        }
        private void NewParameterTB_TextChanged(object sender, EventArgs e)
        {
            path = NewParameterTB.Text;
        }
        private void AddPToTable_Click(object sender, EventArgs e)
        {
            string par = ParametersCB.Text;
            try
            {
                RevitData.STable.Columns.Add(par);
                SheetsTable.SheetsTableColumns.Add(par);
                List<ViewSheet> vSheetslist = RevitUtils.Get_Sheets(ExtCmd.doc);
                for (int i = 0; i < RevitData.STable.Rows.Count; i++)
                {
                    if (i < vSheetslist.Count)
                    {
                        RevitData.STable.Rows[i][par] = vSheetslist[i].LookupParameter(par).AsString();
                    }
                }
                ExtCmd.OnSheetsChanged();
            }
            catch (Exception )
            {

                TaskDialog.Show("Error", "Invalid Parameter");
            }
            this.Close();
        }
    }
}
