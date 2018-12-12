using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Product
    {
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public int idProduct { get; set; }

        public Product(string Name, float price, int amount, int idProduct)
        {
            this.name = Name;
            this.price = price;
            this.quantity = amount;
            this.idProduct = idProduct;
        }

        public Product()
        {

        }

        public float GetTotal()
        {
            return this.price * this.quantity;
        }
    }
}
