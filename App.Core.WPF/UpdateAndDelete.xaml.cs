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
using System.Windows.Shapes;

namespace AppCoreWPF
{
    /// <summary>
    /// Lógica de interacción para UpdateAndDelete.xaml
    /// </summary>
    public partial class UpdateAndDelete : Window
    {
        private AppCoreContext _context = null;
        private Category _category = null;
        public UpdateAndDelete(AppCoreContext context, Category category)
        {
            InitializeComponent();
            _context = context;
            _category = category;

            txtCategoryId.Text = category?.CategoryID.ToString();
            txtCategoryName.Text = category?.CategoryName;
        }

        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            _category.CategoryName = txtCategoryName.Text;
            _context.Categories.Update(_category);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show("Datos Actualizados");
            }
        }

        private void BtnEliminar_OnClick(object sender, RoutedEventArgs e)
        {

            _context.Categories.Remove(_category);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show("Datos Eliminados");
            }
        }
    }
}
