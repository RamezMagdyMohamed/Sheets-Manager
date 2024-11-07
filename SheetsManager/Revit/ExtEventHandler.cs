using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SheetsManager.UI;
using System.Linq;

namespace SheetsManager.Revit
{
    public class ExtEventHandler : IExternalEventHandler
    {
        public Request Request { get; set; }
        public void Execute(UIApplication app)
        {
            switch (Request) 
            {
                case Request.CreateSheet:
                    using (Transaction trn = new Transaction(ExtCmd.doc,"Create Sheets"))
                    {
                        trn.Start();
                            for (int i = 0; i < RevitData.NumOfSheets; i++)
                            {
                            RevitUtils.CreateSheets(ExtCmd.doc,RevitData.MySheet, $"sheet {RevitUtils.Get_Sheets(ExtCmd.doc).Count()+1}");
                            }
                        trn.Commit();
                    }
                    ExtCmd.OnSheetsChanged();
                    break;
                case Request.CreateParameter:
                    using (Transaction trn = new Transaction(ExtCmd.doc, "Create Parameter"))
                    {
                        trn.Start();
                        RevitUtils.CreateParameter(ExtCmd.doc,"G2",ParameterType.Text);
                        trn.Commit();
                    }
                    ExtCmd.OnSheetsChanged();
                    break;
                case Request.ParameterEdited:
                    using (Transaction trn = new Transaction(ExtCmd.doc, "Edit Parameter"))
                    {
                        trn.Start();
                        RevitUtils.EditSheetPars(ExtCmd.doc, RevitData.SheetId, RevitData.ColName, RevitData.CellNewValue);
                        trn.Commit();
                    }
                    break;
                case Request.AddViewToSheet:
                    using(Transaction trn = new Transaction(ExtCmd.doc,"Add Views To Sheets"))
                    {
                        trn.Start();
                        RevitUtils.AddviewsToSheets(ExtCmd.doc);
                        trn.Commit();
                    }
                    break;
                case Request.RemoveView:
                    using (Transaction trn = new Transaction(ExtCmd.doc, "Remove Views From Sheets"))
                    {
                        trn.Start();
                        RevitUtils.RemoveViewFromSheet(ExtCmd.doc, RevitData.SheetName, RevitData.ViewName);
                        trn.Commit();
                    }
                    break;
                case Request.CreateSheetFromFile:
                    using (Transaction trn = new Transaction(ExtCmd.doc, "Create Sheets From File"))
                    {
                        trn.Start();
                        RevitData.ImportedSTable = RevitUtils.ImportDataFromFile(RevitData.ImportedSTable, ExportImportForm.IFpath);
                        RevitUtils.CreateSheetsFromImported(ExtCmd.doc, RevitData.ImportedSTable, RevitData.SheetTemplate);
                        trn.Commit();
                    }
                    break;
                case Request.CreateViewFromFile:
                    using (Transaction trn = new Transaction(ExtCmd.doc, "Add Views From File"))
                    {
                        trn.Start();
                        RevitUtils.CreateVFromImported(ExtCmd.doc, RevitData.ImportedVTable);
                        trn.Commit();
                    }
                    break;
            }
        }

        public string GetName()
        {
            return "Sheets Creator";
        }
    }
    public enum Request
    {
        CreateSheet,
        CreateParameter,
        ParameterEdited,
        AddViewToSheet,
        RemoveView,
        CreateSheetFromFile,
        CreateViewFromFile
    }
}
