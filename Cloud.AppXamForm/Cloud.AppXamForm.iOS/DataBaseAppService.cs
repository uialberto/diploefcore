using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cloud.AppXamForm.iOS;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DataBaseAppService))]

namespace Cloud.AppXamForm.iOS
{
    public class DataBaseAppService : IDataBaseAppService
    {
        public string GetFullPath(string dbFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "...", "Library", dbFileName);
        }
    }
}