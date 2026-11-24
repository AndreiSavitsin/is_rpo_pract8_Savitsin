using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_rpo_pract8_Savitsin
{
    public static class ProductsData
    {
        public static ObservableCollection<Product> Products { get; } = new();
        public static ObservableCollection<CartItem> Basket { get; } = new();
    }
}
