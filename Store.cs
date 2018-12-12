using Newtonsoft.Json;
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
        public Product[] products { get; set; }    //0 = veg, 1 = brea, 2 = soda
        private Product[] empty = { new Product("Vegetable", 5, 0, 0), new Product("Bread", 10, 0, 0), new Product("Soda", 15, 0, 0) };
        
        public Store()
        {

        }

        public Store(int id, string name, Product[] products)
        {
            this.idStore = id;
            this.storeName = name;
            this.products = products;
            if(products.Length == 0)
            {
                products = empty;
            }
        }

        public Store (string str)
        {
            this.storeName = str;
            products = empty;

        }

        public float GetTotal()
        {
            float total = 0;
            foreach (Product i in this.products)
            {
                total += i.GetTotal();
            }
            return total;
        }


        public void GenerateImage()
        {
            string text = JsonConvert.SerializeObject(this);
            QrApi.CreateImage(text, this.storeName);
        }

        public void CheckEmpty()
        {
            if (this.products.Length == 0)
            {
                this.products = empty;
            }
        }

        public override string ToString()
        {
            return this.storeName;
        }
    }
}
