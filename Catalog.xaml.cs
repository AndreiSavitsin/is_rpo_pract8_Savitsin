using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace is_rpo_pract8_Savitsin
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public Catalog(ObservableCollection<Product> products)
        {                        
            InitializeComponent();
            Products = products;
            DataContext = this;
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct == null) return;

            NavigationService.Navigate(new ProductDetail(SelectedProduct));
        }

        private void btnSortByPrice(object sender, RoutedEventArgs e)
        {
            var sorted = Products.OrderBy(p => p.Price).ToList();

            Products.Clear();
            foreach (var p in sorted)
                Products.Add(p);
        }

        private void btnSortByCategory(object sender, RoutedEventArgs e)
        {
            var sorted = Products.OrderBy(p => p.Category).ToList();

            Products.Clear();
            foreach (var p in sorted)
                Products.Add(p);
        }

        private void btnSortByBrand(object sender, RoutedEventArgs e)
        {
            var sorted = Products.OrderBy(p => p.Brand).ToList();

            Products.Clear();
            foreach (var p in sorted)
                Products.Add(p);
        }
    }
}
