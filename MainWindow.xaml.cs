using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Home());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Home());
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Catalog(ProductsData.Products));
        }

        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Basket());
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Contacts());
        }
    }
}