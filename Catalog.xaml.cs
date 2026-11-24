using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace is_rpo_pract8_Savitsin
{
    public partial class Catalog : Page
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        private ObservableCollection<Product> _allProducts;

        public Catalog(ObservableCollection<Product> products)
        {
            InitializeComponent();

            _allProducts = new ObservableCollection<Product>(products);
            Products = new ObservableCollection<Product>(products);

            DataContext = this;
        }

        private void btnSortByPrice(object sender, RoutedEventArgs e)
        {
            var sorted = Products.OrderBy(p => p.Price).ToList();
            UpdateCollection(sorted);
        }

        private void btnSortByCategory(object sender, RoutedEventArgs e)
        {
            var sorted = Products.OrderBy(p => p.Category).ToList();
            UpdateCollection(sorted);
        }

        private void btnSortByBrand(object sender, RoutedEventArgs e)
        {
            var sorted = Products.OrderBy(p => p.Brand).ToList();
            UpdateCollection(sorted);
        }

        private void btnReset(object sender, RoutedEventArgs e)
        {
            Products.Clear();
            foreach (var p in _allProducts) Products.Add(p);
        }

        private void UpdateCollection(System.Collections.Generic.List<Product> newList)
        {
            Products.Clear();
            foreach (var p in newList) Products.Add(p);
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct == null) return;
            NavigationService.Navigate(new ProductDetail(SelectedProduct));
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.DataContext as Product;

            if (product != null)
            {
                var existingItem = ProductsData.Basket.FirstOrDefault(b => b.Product == product);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    ProductsData.Basket.Add(new CartItem(product));
                }
                MessageBox.Show($"Товар «{product.Name}» добавлен в корзину!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListView, e.OriginalSource as DependencyObject) as ListViewItem;
            if (item == null)
            {
                (sender as ListView).SelectedItem = null;
            }
        }
    }
}