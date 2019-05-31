using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Univ.Northwind.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace UnivApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Univ.Northwind.DataAccess.AppContext())
            {
                var category = new Category()
                {
                    CategoryName = CategoryName.Text
                };

                context.Categories.Add(category);

                context.SaveChanges();

                Categories.ItemsSource = context.Categories.ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new Univ.Northwind.DataAccess.AppContext())
            {
                Categories.ItemsSource = context.Categories.ToList();
            }
        }
    }
}
