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
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        public ObservableCollection<CartItem> BasketItems { get; set; }
        public Basket()
        {
            InitializeComponent();
            BasketItems = ProductsData.Basket;
            DataContext = this;            
        }

        private void btnMakeOrder(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно оформили заказа", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnContinueShopping(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Catalog(ProductsData.Products));
        }

        private void btnDel(object sender, RoutedEventArgs e)
        {

        }
    }
}
