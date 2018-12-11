using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Store
    {
        public int idStore { get; set; }
        public string storeName { get; set; }
        public Product[] products { get; set; }
        public Image Image { get; set; }
        public string Json { get; set; }

        public Store(int id, string name, Product[] products)
        {
            this.idStore = id;
            this.storeName = name;
            this.products = products;
        }

        public Decimal GetTotal(Product[] products)
        {
            Decimal total = 0;
            foreach (Product i in products)
            {
                total += i.price * i.quantity;
            }
            return total;
        }

        public void GenerateJson()
        {

        }

        public void GenerateImage()
        {
            QrApi.GenerateImage(this.Json, this.storeName);
        }
    }
}
