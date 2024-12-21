using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _21_12_24
{
    public class ProductService
    {
        private string FilePath = @"C:\Users\ACER\source\repos\21_12_24\example.txt";
        private static int _nextId = 0;

        public void Create(Product product)
        {
            List<Product> products = new List<Product>();
            if (products == null) products = new List<Product>();

            product.SetId(_nextId++);

            products.Add(product);
            WriteToFile(products);
        }

        public Product Get(int id)
        {
            List<Product> products = GetAll();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                return products ?? new List<Product>();
            }
            return new List<Product>();
        }

        public void Delete(int id)
        {
            List<Product> products = GetAll();
            var productToDelete = products.FirstOrDefault(p => p.Id == id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                WriteToFile(products);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void WriteToFile(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products);
            File.WriteAllText(FilePath, json);
        }
    }
}


