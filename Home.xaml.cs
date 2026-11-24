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
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public ObservableCollection<Product> Products => ProductsData.Products;

        public Home()
        {
            if (ProductsData.Products.Count == 0)
            {
                Products.Add(new Product()
                {
                    Name = "Игровой ноутбук",
                    Description = "Мощный игровой ноутбук с производительной видеокартой, " +
                    "плавным экраном и эффективным охлаждением.",
                    Price = 100000,
                    Brand = "MSI",
                    Category = "Ноутбук",
                    PathPhoto = new BitmapImage(new Uri("pack://application:,,,/Images/Laptop.png", UriKind.Absolute))
                });

                Products.Add(new Product()
                {
                    Name = "Игровой компьютер",
                    Description = "Производительный игровой ПК с мощной видеокартой, " +
                    "быстрым процессором и продуманным охлаждением",
                    Price = 150000,
                    Brand = "Ardor Gaming",
                    Category = "Компьтер",
                    PathPhoto = new BitmapImage(new Uri("pack://application:,,,/Images/Computer.png", UriKind.Absolute))
                });

                Products.Add(new Product()
                {
                    Name = "Телефон",
                    Description = "Современный смартфон с ярким безрамочным дисплеем, " +
                    "мощным процессором и продвинутой камерой",
                    Price = 60000,
                    Brand = "Apple",
                    Category = "Телефон",
                    PathPhoto = new BitmapImage(new Uri("pack://application:,,,/Images/Phone.png", UriKind.Absolute))
                });

                Products.Add(new Product()
                {
                    Name = "Игровая мышка",
                    Description = "Эргономичная игровая мышь с высокоточным оптическим сенсором, " +
                    "мгновенным откликом переключателей и настраиваемой RGB-подсветкой",
                    Price = 5000,
                    Brand = "Logitech",
                    Category = "Периферия",
                    PathPhoto = new BitmapImage(new Uri("pack://application:,,,/Images/Mouse.png", UriKind.Absolute))
                });

                Products.Add(new Product()
                {
                    Name = "Игровая клавиатура",
                    Description = "Надёжная игровая клавиатура с отзывчивыми механическими переключателями",
                    Price = 7000,
                    Brand = "Aula",
                    Category = "Периферия",
                    PathPhoto = new BitmapImage(new Uri("pack://application:,,,/Images/Keyboard.png", UriKind.Absolute))
                });
            }

            InitializeComponent();
            DataContext = this;
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Catalog(Products));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Name.ToLower().Contains(txtInput.Text.ToLower()))
                {
                    found = true;
                }
            }

            if (found == true)
            {
                MessageBox.Show("Товар присутствует в каталоге", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Catalog(Products));
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Товар отсутствует в каталоге.\nПредлагаем ознакомиться с каталогом", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes) NavigationService.Navigate(new Catalog(Products));
            }
        }
    }
}
