using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SheetsManager.Revit
{
    public class ViewsTable
    {
        public static void GenTable()
        {
            // Create a new DataTable.
            RevitData.VTable = new DataTable();
            List<ViewSheet> vSheetslist = RevitUtils.Get_Sheets(ExtCmd.doc);
            RevitData.ViewtableColumns = new List<string> { "Sheet Name", "Sheet Number" };
            //Get Number of Views in each Sheet
            List<int> intList = new List<int>();    
            foreach (ViewSheet s in vSheetslist)
            {
                int NumOfviewportsInSheet = new FilteredElementCollector(ExtCmd.doc)
                .OfClass(typeof(Viewport))
                .WhereElementIsNotElementType()
                .Where(vp => ((Viewport)vp).SheetId == s.Id).Count();
                intList.Add(NumOfviewportsInSheet);
            }
            if (intList.Count>0)
            {
                int maxnViews = intList.Max();
                for (int i = 0; i < maxnViews; i++)
                {
                    RevitData.ViewtableColumns.Add($"View {i + 1}");
                }
            }
            List<string> ViewtableColumns = RevitData.ViewtableColumns;//new
            foreach (string col in ViewtableColumns)
            {
                RevitData.VTable.Columns.Add(col);
            }
            _ = new List<ViewSheet>();
           
            for (int i = 0; i < vSheetslist.Count; i++)
            {
                DataRow row = RevitData.VTable.NewRow();
                for (int j = 0; j < ViewtableColumns.Count; j++)
                {

                    if (ViewtableColumns[j] == "Sheet Name")
                    {
                        row[ViewtableColumns[j]] = vSheetslist[i].LookupParameter(ViewtableColumns[j]).AsString();
                    }
                    if (ViewtableColumns[j] == "Sheet Number")
                    {
                        row[ViewtableColumns[j]] = vSheetslist[i].LookupParameter(ViewtableColumns[j]).AsString();
                    }

                }
                for (int x = 2; x < ViewtableColumns.Count; x++)
                {
                    if (ViewtableColumns[x].Contains("View"))
                    {
                        if (vSheetslist[i] != null)
                        {
                            List<Element> vplist = new List<Element>();
                            // Get all the viewports on the sheet
                            FilteredElementCollector viewportCollector = new FilteredElementCollector(ExtCmd.doc, vSheetslist[i].Id);
                            vplist = viewportCollector.OfClass(typeof(Viewport)).ToList();

                            if (vplist.Count > 0)
                            {
                                if (x - 1 <= vplist.Count)
                                {
                                    Viewport viewport = vplist[x - 2] as Viewport;
                                    ElementId viewId = viewport.ViewId;
                                    View view = ExtCmd.doc.GetElement(viewId) as View;
                                    row[ViewtableColumns[x]] = view.Name;
                                    continue;
                                }

                            }

                        }
                    }
                }
               RevitData.VTable.Rows.Add(row);
            }

        }
    }
}
