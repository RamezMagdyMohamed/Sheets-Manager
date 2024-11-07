using Autodesk.Revit.DB;
using SheetsManager.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsManager.Revit
{
    public class SheetsTable
    {
        public static List<object> SheetRows { get; set; }
        public static List<string> SheetsTableColumns = new List<string>() { "Sheet Name", "Sheet Number", "Sheet Type", "Id", "Sheet Issue Date", "Designed By", "Checked By", "Approved By" };
        public static void GenTable()
        {
            RevitData.STable = new DataTable();
            AddColumnstoTable();
            FillTable();

        }
        /// <summary>
        /// Adds Columns to The Table
        /// </summary>
        public static void AddColumnstoTable()
        {

            foreach (string col in SheetsTableColumns)
            {
                RevitData.STable.Columns.Add(col);
            }
        }
        /// <summary>
        /// Fills Table Cells with Data
        /// </summary>
        public static void FillTable()
        {
            
            List<ViewSheet> vSheetslist = RevitUtils.Get_Sheets(ExtCmd.doc);

            for (int i = 0; i < vSheetslist.Count; i++)
            {
                DataRow row = RevitData.STable.NewRow();
                foreach (var col in SheetsTableColumns)
                {
                    if (col == "Sheet Type")
                    {
                        row[col] = new FilteredElementCollector(ExtCmd.doc).OfCategory(BuiltInCategory.OST_TitleBlocks)
                       .WhereElementIsNotElementType()
                       .Where(tb => tb.OwnerViewId == vSheetslist[i].Id).FirstOrDefault().Name.ToString();
                        continue;
                    }
                    else if (col == "Id")
                    {
                        row[col] = vSheetslist[i].Id.ToString();
                        RevitData.SheetsIds.Add(vSheetslist[i].Id.ToString());
                    }
                    else
                    {
                        row[col] = vSheetslist[i].LookupParameter(col).AsString();
                    }
                }
                RevitData.STable.Rows.Add(row);
            }

        }
    }
}
