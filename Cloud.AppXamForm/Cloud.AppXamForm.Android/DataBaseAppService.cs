using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cloud.AppXamForm.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DataBaseAppService))]

namespace Cloud.AppXamForm.Droid
{
    public class DataBaseAppService : IDataBaseAppService
    {
        public string GetFullPath(string dbFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbFileName);

        }
    }
}