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
    internal class RevitData
    {
        public static int NumOfSheets { get; set; }
        public static ViewSheet MySheet { get; set; }
        public static ViewSheet SheetTemplate { get; set; }
        public static List<string> ViewtableColumns = new List<string>() { "Sheet Name", "Sheet Number", "View 1", "View 2", "View 3", "View 4", "View 5" };
        public string TbID { get; set; }
        public static DataTable STable { get; set; }
        public static DataTable VTable { get; set; }
        public static List<object> SheetRows  { get; set; }
        public static List<string> SheetsIds { get; set; }
        public static string ColName { get; set; }
        public static string SheetName { get; set; }
        public static int SheetId { get; set; }
        public static string CellNewValue { get; set; }
        public static List<string> AvailableViewsNames { get; set; }
        public static  List<string> ViewsNames { get; set; }
        public static string ViewName { get; set; }

        public static DataTable ImportedSTable { get; set; }
        public static DataTable ImportedVTable { get; set; }

    }
}
