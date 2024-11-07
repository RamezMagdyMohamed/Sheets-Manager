using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SheetsManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data;
using View = Autodesk.Revit.DB.View;
using OfficeOpenXml;

namespace SheetsManager.Revit
{
    internal class RevitUtils
    {
        public static string ParameterFilePath { get; set; }
        /// <summary>
        /// Gets All Sheets Types in Current Document 
        /// Hint: Default Type is A1
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="Sheet"></param>
        /// <returns></returns>
        public static Element get_TittleBlock(Document doc, ViewSheet Sheet)
        {
            if (Sheet != null)
            {
                string i = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_TitleBlocks)
                .WhereElementIsNotElementType()
                .Where(tb => tb.OwnerViewId == Sheet.Id)
                .FirstOrDefault().Name;
                return new FilteredElementCollector(doc)
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .WhereElementIsElementType()
                    .FirstOrDefault(tbid => tbid.Name.Contains(i));
            }
            else
            {
                return new FilteredElementCollector(doc)
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .WhereElementIsElementType()
                    .FirstOrDefault(tbid => tbid.Name.Contains("A1"));
            }

        }
        /// <summary>
        /// Gets All The Sheets In The Document
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<ViewSheet> Get_Sheets(Document doc)
        {
            return new FilteredElementCollector(doc)
                 .OfCategory(BuiltInCategory.OST_Sheets)
                 .WhereElementIsNotElementType()
                 .OfType<ViewSheet>()
                 .ToList();
        }
        /// <summary>
        /// Creates a New Sheet 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="Sheet"></param>
        /// <param name="sheetName"></param>
        public static void CreateSheets(Document doc, ViewSheet Sheet, string sheetName)
        {
            Element TB = get_TittleBlock(doc, Sheet);
            ViewSheet viewSheet = ViewSheet.Create(doc, TB.Id);
            viewSheet.SheetNumber = "S" + Get_Sheets(doc).Count().ToString();
            viewSheet.Name = sheetName;
        }
        /// <summary>
        /// Creates a New Parameter
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="groupName"></param>
        /// <param name="parameterType"></param>
        public static void CreateParameter(Document doc, string groupName,ParameterType pam )
        {
            string ParameterFilePath = "";
            string definitionName = ParametersForm.path;
            if (definitionName != null)
            {
                // Select Path of shared parameter file
                using (var folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        ParameterFilePath = Path.Combine(folderDialog.SelectedPath, "SharedParameters.txt");
                    }
                }

                // Create shared parameter file
                if (!File.Exists(ParameterFilePath))
                {
                    using (FileStream fs = File.Create(ParameterFilePath)) { }
                }

                // Set Shared Parameters Filename
                UIApplication uiapp = new UIApplication(doc.Application);
                uiapp.Application.SharedParametersFilename = ParameterFilePath;

                // Open shared parameter file
                DefinitionFile defFile = uiapp.Application.OpenSharedParameterFile();
                if (defFile == null)
                {
                    TaskDialog.Show("Error", "Failed to open shared parameter file.");
                    return;
                }

                // Create or get the definition group
                DefinitionGroup defGroup = defFile.Groups.get_Item(groupName) ?? defFile.Groups.Create(groupName);

                FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSheet));


                // Create the definition
                ExternalDefinitionCreationOptions options = new ExternalDefinitionCreationOptions(definitionName, pam);
                Definition definition = defGroup.Definitions.Create(options);

                // Set up the category set and instance binding
                CategorySet categorySet = new CategorySet();
                Category category = Category.GetCategory(doc, BuiltInCategory.OST_Sheets);
                categorySet.Insert(category);
                InstanceBinding instanceBinding = new InstanceBinding(categorySet);

                // Add the definition to the document's binding map
                BindingMap bindingMap = doc.ParameterBindings;


                bool bindingInserted = bindingMap.Insert(definition, instanceBinding, BuiltInParameterGroup.INVALID);
                if (!bindingInserted)
                {
                    TaskDialog.Show("Error", "Failed to bind shared parameter.");
                }
            }
            else
            {
                TaskDialog.Show("Error", " Please Enter Parameter Name");
            }
        }
        /// <summary>
        /// Get The Names of The Parameters of Sheets
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static IList<string> GetSheetParameterNames(Document doc)
        {
            // Collect all sheets
            IList<ViewSheet> sheets = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Sheets)
                .WhereElementIsNotElementType()
                .OfType<ViewSheet>()
                .ToList();

            // Create a hash set to store unique parameter names
            HashSet<string> parameterNames = new HashSet<string>();

            // Iterate through each sheet and collect parameter names
            foreach (ViewSheet sheet in sheets)
            {
                foreach (Parameter param in sheet.Parameters)
                {
                    parameterNames.Add(param.Definition.Name);
                }
            }

            // Convert the hash set to a list
            return parameterNames.ToList();
        }
        /// <summary>
        /// Edits Sheets Parameters In a Document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="elementId1"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        public static void EditSheetPars(Document doc, int elementId1, string parameterName, string value)
        {
            ElementId elementId = new ElementId(elementId1);
            Element element = doc.GetElement(elementId);
            if (parameterName == "Sheet Type" || parameterName == "Id")
            {
                MessageBox.Show("This Parameter Can't be Edited From Sheets Manager");
                ExtCmd.OnSheetsChanged();
            }
            else
            {
                Dictionary<InternalDefinition, ElementBinding> loadPars = ConvertBindingMapToDic(doc.ParameterBindings);
                Definition idPar = loadPars.FirstOrDefault(item => item.Key.Name == parameterName).Key;
                if (idPar != null)
                {
                    Parameter parameter = element.get_Parameter(idPar);
                    parameter.Set(value);
                }
            }
            Parameter parameter2 = element.GetParameters(parameterName).First();
            parameter2.Set(value);
        }
        public static Dictionary<InternalDefinition, ElementBinding> ConvertBindingMapToDic(BindingMap bindingMap)
        {
            Dictionary<InternalDefinition, ElementBinding> loadPars = new Dictionary<InternalDefinition, ElementBinding>();
            DefinitionBindingMapIterator iterator = bindingMap.ForwardIterator();
            while (iterator.MoveNext())
            {
                loadPars[iterator.Key as InternalDefinition] = iterator.Current as ElementBinding;
            }
            return loadPars;
        }
        /// <summary>
        /// Gets A Certain Sheet From Sheets
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static ViewSheet GetSheet(Document doc, string sheetName)
        {
            return new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>()
                .ToList().Where(sh=>sh.Name==sheetName).FirstOrDefault();
        }
        /// <summary>
        /// Gets A Certain View From Views
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="vName"></param>
        /// <returns></returns>
        public static View GetView(Document doc,string vName) 
        {
            View docView = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType().ToList().Where(ele=>ele.Name==vName).FirstOrDefault() as View;
            return docView;
        }
        /// <summary>
        /// Adds a Viewport To a Sheet
        /// </summary>
        /// <param name="doc"></param>
        public static void AddviewsToSheets(Document doc)
        {
            var Selectedviews = RevitData.ViewsNames;
            string shName = RevitData.SheetName;
            ViewSheet sheet = GetSheet(doc, shName);
            foreach (var selection in Selectedviews)
            {
                View sView = GetView(doc, selection.ToString());
                XYZ viewLocation = new XYZ(1, 1, 0); //location

                // Add the view to the sheet
                FilteredElementCollector collector = new FilteredElementCollector(doc).OfClass(typeof(Viewport));
                foreach (Viewport vp in collector)
                {
                    if (vp.ViewId == sView.Id)
                    {
                        TaskDialog.Show("Error", "View dosen't Exist or associated to another Sheet");
                    }
                }
                _ = Viewport.Create(doc, sheet.Id, sView.Id, viewLocation);
            }
        }
        /// <summary>
        /// Gets The Viewport of a view in a sheet
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="sheet"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static Viewport GetViewportByView(Document doc, ViewSheet sheet, View view)
        {
            // Find the viewport that contains the view on the sheet
            FilteredElementCollector collector = new FilteredElementCollector(doc, sheet.Id);
            ICollection<Element> viewports = collector.OfClass(typeof(Viewport)).ToElements();
            foreach (Element elem in viewports)
            {
                Viewport viewport = elem as Viewport;
                if (viewport != null && viewport.ViewId == view.Id)
                {
                    return viewport;
                }
            }

            // If no viewport is found, return null
            return null;
        }

        public static void RemoveViewFromSheet(Document doc, string sheetName, string viewName)
        {
            // Get the sheet by name
            ViewSheet sheet = GetSheet(doc, sheetName);

            if (sheet != null)
            {
                // Get the view by name
                View viewToRemove = GetView(doc, viewName);

                if (viewToRemove != null)
                {

                    // Find the viewport that contains the view on the sheet
                    Viewport viewportToRemove = GetViewportByView(doc, sheet, viewToRemove);

                    if (viewportToRemove != null)
                    {
                        // Delete the viewport to remove the view from the sheet
                        doc.Delete(viewportToRemove.Id);
                    }
                    else
                    {
                        TaskDialog.Show("Error", $"Viewport containing view '{viewName}' not found on sheet '{sheetName}'.");
                    }
                }
                else
                {
                    TaskDialog.Show("Error", $"View '{viewName}' not found.");
                }
            }
            else
            {
                TaskDialog.Show("Error", $"Sheet '{sheetName}' not found.");
            }
        }
        /// <summary>
        /// Exports Sheets Report To Excel
        /// </summary>
        /// <param name="doc"></param>
        public static void ExportReport(Document doc)
        {
            if (string.IsNullOrEmpty(ExportImportForm.Fpath))
            {
                TaskDialog.Show("Sheets Table", "Error, No path Selected");
                return;
            }
            //Create a new ExcelPackage
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Ramez";
                excelPackage.Workbook.Properties.Title = "Sheets Mangaer";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                List<string> Headers = SheetsTable.SheetsTableColumns;
                for(int i = 1; i<=Headers.Count; i++)
                {
                    worksheet.Cells[1, i].Value = Headers[i-1];
                }

                int countRow = 2;
                for (int i = 0; i < RevitData.STable.Rows.Count; i++)
                {
                    for (int j = 1; j <= RevitData.STable.Columns.Count; j++)
                    {
                        worksheet.Cells[countRow, j].Value = RevitData.STable.Rows[i][j-1];
                    }
                    countRow++;
                }

                string FULLPATH = ExtCmd.doc.PathName;
                string FILENAME = System.IO.Path.GetFileName(FULLPATH) + "-" + "Sheets Table" + " " + nowDate() + ".xlsx";

                string FILPTH = ExportImportForm.Fpath + "\\" + FILENAME;
                FileInfo ExcelFile = new FileInfo(FILPTH);
                excelPackage.SaveAs(ExcelFile);
                //Process.Start(new ProcessStartInfo(FILPTH) { UseShellExecute = true });
                TaskDialog.Show("Sheets Table", "Table Exported Successfully!");

            }
              string nowDate()
            {
                var NowTime = DateTime.Now;
                string NowDate = "[" + NowTime.Year.ToString() + "-" + NowTime.Month.ToString() + "-" + NowTime.Day.ToString() + "_" + NowTime.Hour.ToString() + "-" + NowTime.Minute.ToString() + "-" + NowTime.Second.ToString() + "]";
                return NowDate;

            }
        }
        /// <summary>
        /// Imports Sheets Report From Excel to a DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable ImportDataFromFile(DataTable dt,string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                TaskDialog.Show("Sheets Table", "Error, No path Selected");
                return null;
            }
            //Opening an existing Excel file
            FileInfo fi = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(fi))
            {
                //Get a WorkSheet by index. Note that EPPlus indexes are base 1, not base 0!
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];


                dt = new DataTable();
                List<string> columnNames = new List<string>();

                int currentColumn = 1;

                //For Headers
                foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    string columnName = cell.Text.Trim();

                    //check if the previous header was empty and add it if it was
                    if (cell.Start.Column != currentColumn)
                    {
                        columnNames.Add("Header_" + currentColumn);
                        dt.Columns.Add("Header_" + currentColumn);
                        currentColumn++;
                    }

                    //add the column name to the list to count the duplicates
                    columnNames.Add(columnName);

                    //count the duplicate column names and make them unique to avoid the exception
                    //A column named 'Name' already belongs to this DataTable
                    int occurrences = columnNames.Count(x => x.Equals(columnName));
                    if (occurrences > 1)
                    {
                        columnName = columnName + "_" + occurrences;
                    }

                    //add the column to the datatable
                    dt.Columns.Add(columnName);

                    currentColumn++;
                }
                //for Rest of The Table
                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                    DataRow newRow = dt.NewRow();

                    //loop all cells in the row
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }

                    dt.Rows.Add(newRow);
                }
                return dt;

            }
        }
        /// <summary>
        /// Creates Sheets From a DataTable
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="dt"></param>
        /// <param name="Sheet"></param>
        public static void CreateSheetsFromImported(Document doc, DataTable dt,ViewSheet Sheet)
        {
            List<string> SheetsNames = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ToString() == "Sheet Name")
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        SheetsNames.Add(dt.Rows[j][i].ToString());
                    }
                }
            }
            if (RevitData.SheetTemplate == null)
            {
                TaskDialog.Show("Error", "No Sheet Template is Chosen");
            }
            else
            {
                foreach (string sheetName in SheetsNames)
                {
                    CreateSheets(doc, Sheet, sheetName);
                }
            }

        }
        /// <summary>
        /// Exports Views Report to Excel
        /// </summary>
        /// <param name="doc"></param>
        public static void ExportViewsReport(Document doc,DataTable dt,string path,List<string> headers)
        {
            if (string.IsNullOrEmpty(path))
            {
                TaskDialog.Show("Sheets Table", "Error, No path Selected");
                return;
            }
            //Create a new ExcelPackage
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Ramez";
                excelPackage.Workbook.Properties.Title = "Sheets Mangaer";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                List<string> Headers = headers;
                for (int i = 1; i <= Headers.Count; i++)
                {
                    worksheet.Cells[1, i].Value = Headers[i - 1];
                }
                string[] validValues = new FilteredElementCollector(doc)
                 .OfCategory(BuiltInCategory.OST_Views)
                 .WhereElementIsNotElementType()
                 .Cast<View>() // Cast to View to access ViewType property
                 .Where(v =>
                  v.ViewType == ViewType.FloorPlan ||
                  v.ViewType == ViewType.CeilingPlan ||
                  v.ViewType == ViewType.Section ||
                  v.ViewType == ViewType.Elevation ||
                  v.ViewType == ViewType.Detail ||
                  v.ViewType == ViewType.EngineeringPlan ||
                  v.ViewType == ViewType.Legend ||
                  v.ViewType == ViewType.ThreeD ||
                  v.ViewType == ViewType.Schedule)
                 .Where(v=>v.CanBePrinted)
                 .Select(v => v.Name)
                 .ToArray();
                int countRow = 2;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 1; j <= dt.Columns.Count; j++)
                    {
                        worksheet.Cells[countRow, j].Value = dt.Rows[i][j - 1];
                        if (j>2)
                        {
                            var cellAddress = worksheet.Cells[countRow, j];
                            var validation = worksheet.DataValidations.AddListValidation(cellAddress.Address);
                            foreach (var value in validValues)
                            {
                                validation.Formula.Values.Add(value);
                            }
                        }
                        
                    }
                    countRow++;
                }

                string FULLPATH = doc.PathName;
                string FILENAME = System.IO.Path.GetFileName(FULLPATH) + "-" + "Views Table" + " " + nowDate() + ".xlsx";

                string FILPTH = ExportImportVForm.VFpath + "\\" + FILENAME;
                FileInfo ExcelFile = new FileInfo(FILPTH);
                excelPackage.SaveAs(ExcelFile);
                //Process.Start(new ProcessStartInfo(FILPTH) { UseShellExecute = true });
                TaskDialog.Show("Views Table", "Table Exported Successfully!");

            }
            string nowDate()
            {
                var NowTime = DateTime.Now;
                string NowDate = "[" + NowTime.Year.ToString() + "-" + NowTime.Month.ToString() + "-" + NowTime.Day.ToString() + "_" + NowTime.Hour.ToString() + "-" + NowTime.Minute.ToString() + "-" + NowTime.Second.ToString() + "]";
                return NowDate;

            }
        }
        /// <summary>
        /// Imports Views Report To a DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable ImportVDataFromFile(DataTable dt, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                TaskDialog.Show("Views Table", "Error, No path Selected");
                return null;
            }
            //Opening an existing Excel file
            FileInfo fi = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(fi))
            {
                //Get a WorkSheet by index. Note that EPPlus indexes are base 1, not base 0!
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];


                dt = new DataTable();
                List<string> columnNames = new List<string>();

                int currentColumn = 1;

                //For Headers
                foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    string columnName = cell.Text.Trim();

                    //check if the previous header was empty and add it if it was
                    if (cell.Start.Column != currentColumn)
                    {
                        columnNames.Add("Header_" + currentColumn);
                        dt.Columns.Add("Header_" + currentColumn);
                        currentColumn++;
                    }

                    //add the column name to the list to count the duplicates
                    columnNames.Add(columnName);

                    //count the duplicate column names and make them unique to avoid the exception
                    //A column named 'Name' already belongs to this DataTable
                    int occurrences = columnNames.Count(x => x.Equals(columnName));
                    if (occurrences > 1)
                    {
                        columnName = columnName + "_" + occurrences;
                    }

                    //add the column to the datatable
                    dt.Columns.Add(columnName);

                    currentColumn++;
                }
                //for Rest of The Table
                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                    DataRow newRow = dt.NewRow();

                    //loop all cells in the row
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }

                    dt.Rows.Add(newRow);
                }
                return dt;

            }
        }
        /// <summary>
        /// Creates Views From a DataTable
        /// </summary>
        public static void CreateVFromImported(Document doc, DataTable dt)
        {
            List<string> SheetsNames = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ToString() == "Sheet Name")
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        SheetsNames.Add(dt.Rows[j][i].ToString());
                    }
                }
            }
            List<List<string>> matrix = new List<List<string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List<string> SheetsViews = new List<string>();
                for (int j = 2; j < dt.Columns.Count; j++)
                {
                    SheetsViews.Add(dt.Rows[i][j].ToString());
                }
                matrix.Add(SheetsViews);
            }
            for (int i = 0; i < SheetsNames.Count; i++)
            {
                string shName = SheetsNames[i];
                List<string> views = matrix[i];
                ViewSheet sheet = GetSheet(doc, shName);
                foreach (var view in views)
                {
                    try
                    {
                        if (view != null || view != "")
                        {
                            View shView = GetView(ExtCmd.doc, view);
                            if (shView == null)
                            {
                                continue;
                            }
                            XYZ viewLocation = new XYZ(1, 1, 0); //location

                            // Add the view to the sheet
                            FilteredElementCollector collector = new FilteredElementCollector(ExtCmd.doc).OfClass(typeof(Viewport));
                            foreach (Viewport vp in collector)
                            {
                                if (vp.ViewId == shView.Id)
                                {
                                    TaskDialog.Show("Error", "View dosen't Exist or associated to another Sheet");
                                }
                            }
                            _ = Viewport.Create(doc, sheet.Id, shView.Id, viewLocation);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }

        }
    }
}
