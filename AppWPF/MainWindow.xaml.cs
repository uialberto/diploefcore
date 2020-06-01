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
using Uialberto.Northwind.Bussines;
using Uialberto.Northwind.Entities;

namespace AppWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var repo = RepoFactory.GetCategoryRepo();
            var category = new Category() { 
                CategoryName = CategoryName.Text,
                Description = CategoryDescription.Text
            };
            category = repo.Create(category);
            var result = string.Empty;
            if (category != null)
            {
                result = $"Create Category:{category.CategoryID}";
                CategoryID.Text = category.CategoryID.ToString();
            }
            else {
                result = $"Not Inserted Category.";
            }

            MessageBox.Show(result);
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            var repo = RepoFactory.GetCategoryRepo();            
            var process = repo.GetById(int.Parse(CategoryID.Text));
            if (process != null)
            {              
                CategoryName.Text = process.CategoryName;
                CategoryDescription.Text = process.Description;
                MessageBox.Show("Categoria encontrada");
            }
            else 
            {
                MessageBox.Show("No se pudo encontrar la Categoria");
                CategoryName.Text = string.Empty;
                CategoryDescription.Text = string.Empty;
            }


            
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            var repo = RepoFactory.GetCategoryRepo();

            var category = new Category()
            {
                CategoryID = int.Parse(CategoryID.Text),
                CategoryName = CategoryName.Text,
                Description = CategoryDescription.Text

            };
            var process = repo.Update(category);
            if (process)
            {
                MessageBox.Show("Categoria Mofificada");
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la Categoria");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var repo = RepoFactory.GetCategoryRepo();
            var id = int.Parse(CategoryID.Text);
            var result = WithLog.IsChecked.Value ? repo.DeleteWithLog(id) : repo.Delete(id);
            if (result)
            {
                MessageBox.Show("Categoria Eliminada");
            }
            else {

                MessageBox.Show("Categoria No Eliminada");
            }
        }

        private void GetCategories(object sender, RoutedEventArgs e)
        {
            var repo = RepoFactory.GetCategoryRepo();
            Data.ItemsSource = repo.GetAll().Select(ele => new { 
                ele.CategoryID, ele.CategoryName, ele.Description
            });
            Data.Visibility = Visibility.Visible;
        }

        private void GetLogs(object sender, RoutedEventArgs e)
        {
            var repo = RepoFactory.GetLogRepo();
            Data.ItemsSource = repo.GetAll();
            Data.Visibility = Visibility.Visible;
        }
    }
}
