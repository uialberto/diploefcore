using System.Linq;
using Diplomado.Entities;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Diplomado.DataAccess.AppContext _context = null;

        public MainWindow()
        {
            InitializeComponent();
            _context = new Diplomado.DataAccess.AppContext();
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
            var ventana = new UpdateAndDelete(_context,category);
            ventana.ShowDialog();
        }

        private void BtnCargar_OnClick(object sender, RoutedEventArgs e)
        {
           LoadCategories();
        }
    }
}
