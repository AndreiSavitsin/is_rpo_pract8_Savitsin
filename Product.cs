using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace is_rpo_pract8_Savitsin
{
    public class Product
    {
        private string name;
        private int price;
        private string description;
        private string category;
        private string brand;
        private ImageSource pathPhoto;

        public string Name
        { 
            get { return name; }
            set { name = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Description
        { 
            get { return description; }
            set { description = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public ImageSource PathPhoto
        {
            get { return pathPhoto; }
            set { pathPhoto = value; }
        }
    }
}
