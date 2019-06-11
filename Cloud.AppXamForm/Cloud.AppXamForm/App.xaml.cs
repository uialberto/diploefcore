using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Cloud.Northwind.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Cloud.AppXamForm
{
    public partial class App : Application
    {
        public static Northwind.DataAccess.AppContext GetAppContext()
        {
            var dbPath = DependencyService.Get<IDataBaseAppService>().GetFullPath("CloudNorthWindLite.db");
            return new Northwind.DataAccess.AppContext(dbPath);
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
