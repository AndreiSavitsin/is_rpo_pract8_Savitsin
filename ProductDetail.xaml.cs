using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace is_rpo_pract8_Savitsin
{
    public partial class ProductDetail : Page
    {
        private readonly Product _product;

        public ProductDetail(Product selectedProduct)
        {
            InitializeComponent();
            _product = selectedProduct;
            DataContext = _product;
        }

        private void btnAddToBasket(object sender, RoutedEventArgs e)
        {
            if (_product == null) return;

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 1) qty = 1;

            var existingItem = ProductsData.Basket.FirstOrDefault(b => b.Product == _product);

            if (existingItem != null)
            {
                existingItem.Quantity += qty;
            }
            else
            {
                ProductsData.Basket.Add(new CartItem(_product, qty));
            }

            MessageBox.Show($"Товар «{_product.Name}» ({qty} шт.) добавлен в корзину!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}