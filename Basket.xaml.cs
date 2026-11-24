using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class Basket : Page, INotifyPropertyChanged
    {
        public ObservableCollection<CartItem> BasketItems { get; set; }
        public CartItem SelectedItem { get; set; }

        private decimal _discountPercent = 0;

        private int _totalSum;
        public int TotalSum
        {
            get => _totalSum;
            set
            {
                _totalSum = value;
                OnPropertyChanged(nameof(TotalSum));
            }
        }

        public Basket()
        {
            InitializeComponent();
            BasketItems = ProductsData.Basket;
            DataContext = this;
            UpdateTotalSum();
        }

        private void UpdateTotalSum()
        {
            int rawTotal = BasketItems.Sum(x => x.TotalPrice);
            TotalSum = (int)(rawTotal * (1 - _discountPercent / 100m));
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.DataContext as CartItem;
            if (item != null)
            {
                item.Quantity++;
                UpdateTotalSum();
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.DataContext as CartItem;
            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                    UpdateTotalSum();
                }
                else
                {
                    var result = MessageBox.Show($"Удалить «{item.Product.Name}» из корзины?",
                                                 "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        BasketItems.Remove(item);
                        UpdateTotalSum();
                    }
                }
            }
        }

        private void ApplyPromocode_Click(object sender, RoutedEventArgs e)
        {
            string code = txtPromocode.Text.Trim().ToUpper();

            if (code == "SALE10")
            {
                _discountPercent = 10;
                MessageBox.Show("Промокод применен! Скидка 10%.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (code == "SALE20")
            {
                _discountPercent = 20;
                MessageBox.Show("Промокод применен! Скидка 20%.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _discountPercent = 0;
                MessageBox.Show("Неверный промокод.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            UpdateTotalSum();
        }

        private void btnMakeOrder(object sender, RoutedEventArgs e)
        {
            if (BasketItems.Count == 0)
            {
                MessageBox.Show("Корзина пуста!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Заказ на сумму {TotalSum} ₽ успешно оформлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            BasketItems.Clear();
            UpdateTotalSum();
        }

        private void btnContinueShopping(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Catalog(ProductsData.Products));
        }

        private void btnDel(object sender, RoutedEventArgs e)
        {
            var item = BasketListView.SelectedItem as CartItem;
            if (item == null)
            {
                MessageBox.Show("Выберите товар для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            BasketItems.Remove(item);
            UpdateTotalSum();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
