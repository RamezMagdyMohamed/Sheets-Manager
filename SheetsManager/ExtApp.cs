using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SheetsManager
{
    public class ExtApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string TabName = "KAITECH - BD - R06";
            string PanelName = "General";
            try
            {
                application.CreateRibbonTab(TabName);

            }
            catch (Exception) { }

            List<RibbonPanel> Panels = application.GetRibbonPanels(TabName);
            RibbonPanel Panel = Panels.FirstOrDefault(p => p.Name == PanelName);
            if (Panel == null)
            {
                Panel = application.CreateRibbonPanel(TabName, PanelName);
            }
            Assembly Assem = Assembly.GetExecutingAssembly();
            PushButtonData PBDATA = new PushButtonData("SheetsManagerBtn", "Sheets Manager", Assem.Location, "SheetsManager.ExtCmd");
            PushButton PBtn = Panel.AddItem(PBDATA) as PushButton;
            PBtn.ToolTip = "This Addin Manages All Sheets In Revit";
            PBtn.LargeImage = GetImgSource("SheetsManager.Resources.icons8-table-24.png");

            return Result.Succeeded;
        }
        private ImageSource GetImgSource(string ImageFullName)
        {
            Stream STREAM = Assembly.GetExecutingAssembly().GetManifestResourceStream(ImageFullName);
            PngBitmapDecoder DECODER = new PngBitmapDecoder(STREAM, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return DECODER.Frames[0];

        }
    }
}
