using Cloud.AppXamForm.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataBaseAppService))]
namespace Cloud.AppXamForm.UWP
{   
    public class DataBaseAppService : IDataBaseAppService
    {
        public string GetFullPath(string dbFileName)
        {
            return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbFileName);
        }
    }
}
