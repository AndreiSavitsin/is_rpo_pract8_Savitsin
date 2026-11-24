using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_rpo_pract8_Savitsin
{
    public class CartItem : INotifyPropertyChanged
    {
        private int _quantity;
        public Product Product { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 1) value = 1;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        public int TotalPrice => Product.Price * Quantity;
        public CartItem(Product product, int quantity = 1)
        {
            Product = product;
            _quantity = quantity;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
