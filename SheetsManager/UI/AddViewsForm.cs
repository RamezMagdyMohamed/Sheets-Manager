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
using View = Autodesk.Revit.DB.View;

namespace SheetsManager.UI
{
    public partial class AddViewsForm : Form
    {
        public AddViewsForm()
        {
            InitializeComponent();
            List<string> TittleblocksList = RevitUtils.Get_Sheets(ExtCmd.doc).Select(s => s.Name).ToList();
            SheetsCB.Items.AddRange(TittleblocksList.ToArray());
            RevitData.AvailableViewsNames = new FilteredElementCollector(ExtCmd.doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType().Cast<View>().Where(v =>
             v.ViewType == ViewType.FloorPlan ||
             v.ViewType == ViewType.CeilingPlan ||
             v.ViewType == ViewType.Section ||
             v.ViewType == ViewType.Elevation ||
             v.ViewType == ViewType.Detail ||
             v.ViewType == ViewType.EngineeringPlan ||
             v.ViewType == ViewType.Legend ||
             v.ViewType == ViewType.ThreeD ||
             v.ViewType == ViewType.Schedule).Where(v=>v.CanBePrinted).Select(v => v.Name).ToList();
            AdditemsToListBox();
            ExtCmd.SheetsChanged += AdditemsToListBox;
        }
        private void AdditemsToListBox()
        {
            List<string> list = RevitData.AvailableViewsNames;
            foreach (var dView in list)
            {
                listBox1.Items.Add(dView);
            }
        }

        private void AddViewsBTN_Click(object sender, EventArgs e)
        {
            var Selectedviews = listBox1.SelectedItems;
            List<string> l = new List<string>();
            foreach (var Selection in Selectedviews)
            {
                l.Add(Selection.ToString());
            }
            RevitData.ViewsNames = l;
            RevitData.SheetName = SheetsCB.Text;
            // Raise external event
            ExtCmd.ExtEventHandler.Request = Request.AddViewToSheet;
            ExtCmd.ExtEvent.Raise();
            this.Close();
            
        }


    }
}
