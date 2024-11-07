using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using SheetsManager.Revit;
using SheetsManager.UI;
using System;
using System.Collections.Generic;

namespace SheetsManager
{
    [Transaction(TransactionMode.Manual)]
    public class ExtCmd : IExternalCommand

    {
        public static UIDocument uidoc { get; set; }
        public static Document doc { get; set; }
        public static ExtEventHandler ExtEventHandler { get; set; }
        public static ExternalEvent ExtEvent { get; set; }

        public static event Action SheetsChanged;
        public static Application app { get; set; }  //for parameters
        public static UIApplication uiApplication { get; set; }  //for parameters
        public static void OnSheetsChanged()
        {
            SheetsTable.GenTable();
            ViewsTable.GenTable();
            SheetsChanged?.Invoke();
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uidoc = commandData.Application.ActiveUIDocument;
            doc = uidoc.Document;
            uiApplication = commandData.Application;  //for parameters
            app = uiApplication.Application; //for parameters
            RevitData.SheetsIds = new List<string>();
            SheetsTable.GenTable();
            ViewsTable.GenTable();
            ExtEventHandler = new ExtEventHandler();
            ExtEvent = ExternalEvent.Create(ExtEventHandler);

            // Subscribe to DocumentChanged event
            commandData.Application.Application.DocumentChanged += OnDocumentChanged;
            MainForm mainForm = new MainForm();
            mainForm.Show(); // Modeless form

            return Result.Succeeded;
        }
        /// <summary>
        /// Invokes An Action if current Document Changes to Update Tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            // Check if any sheets are added, deleted, or modified
            bool sheetsChanging = false;

            foreach (ElementId addedId in e.GetAddedElementIds())
            {
                Element element = e.GetDocument().GetElement(addedId);
                if (element is ViewSheet)
                {
                    sheetsChanging = true;
                    break;
                }
            }
            if (FlagVariable.WasActionInvoked())
            {
                foreach (ElementId deletedId in e.GetDeletedElementIds())
                {
                    if (RevitData.SheetsIds.Contains(deletedId.ToString()))
                    {
                        sheetsChanging = true;
                        break;
                    }
                }
            }


            foreach (ElementId modifiedId in e.GetModifiedElementIds())
            {
                Element element = e.GetDocument().GetElement(modifiedId);
                if (element is ViewSheet)
                {
                    sheetsChanging = true;
                    break;
                }
            }

            if (sheetsChanging)
            {
                OnSheetsChanged();
            }
        }


    }
}
