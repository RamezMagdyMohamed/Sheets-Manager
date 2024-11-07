using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Auth;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Google.Apis.Drive.v3.DriveService;

namespace SheetsManager.Revit
{
    public class GooglAPI
    {
        

        public static void UploadFilesToGoogleDrive(string CredentialsPath, string FolderId, string FileToUploadPath)
        {
            GoogleCredential credential;
            try
            {
                using (var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
                    {
                    DriveService.ScopeConstants.DriveFile
                });
                    var service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Sheets Manager App"
                    });
                    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = FileToUploadPath,
                        Parents = new List<string> { FolderId }
                    };
                    FilesResource.CreateMediaUpload request;
                    using (var Stream = new FileStream(FileToUploadPath, FileMode.Open))
                    {
                        request = service.Files.Create(fileMetadata, Stream, "");
                        request.Fields = "id";
                        request.Upload();
                    }
                    var file = request.ResponseBody;
                    Console.WriteLine("File ID: " + file.Id);

                }
            }
            catch (Exception ex)
            {

                TaskDialog.Show("Error", ex.Message);
            }
            

        }
    }
}
