using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Cloud.Northwind.Entities;

namespace Cloud.AppXamForm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            using (var context = App.GetAppContext())
            { 
                Categories.ItemsSource = context.Categories.ToList();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var context = App.GetAppContext())
            {
                var entity = new Category()
                {
                    CategoryName = CategoryName.Text
                };

                context.Categories.Add(entity);
                context.SaveChanges();

                Categories.ItemsSource = context.Categories.ToList();

            }
        }
    }
}
