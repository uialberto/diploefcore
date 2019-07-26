using Core.Northwind.DataAccess;
using Core.Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCoreWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppCoreContext _context = null;

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppCoreContext();
            LoadCategories();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            var entity = new Category()
            {
                CategoryName = txtCategoryName.Text
            };
            _context.Categories.Add(entity);
            var records = _context.SaveChanges();
            LoadCategories();
        }

        void LoadCategories()
        {
            var result = _context.Categories.ToList();
            DGCategories.ItemsSource = result;
        }

        private void DGCategories_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = DGCategories.SelectedItem as Category;
            var ventana = new UpdateAndDelete(_context, category);
            ventana.ShowDialog();
        }

        private void BtnCargar_OnClick(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }
    }
}
