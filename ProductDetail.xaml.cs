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

namespace is_rpo_pract8_Savitsin
{
    /// <summary>
    /// Логика взаимодействия для ProductDetail.xaml
    /// </summary>
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
            var existingItem = ProductsData.Basket.FirstOrDefault(b => b.Product == _product);

            if (existingItem != null) existingItem.Quantity++;
            else
            {
                ProductsData.Basket.Add(new CartItem(_product));
                MessageBox.Show("Товар добавлен в корзину", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
