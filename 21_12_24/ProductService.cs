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
        private string FilePath = @"C:\Users\Narminjb\Source\Repos\21_12_24\21_12_24\example.txt";

        public void Create(Product product)
        {
            List<Product> products = new List<Product>();
            if (products == null) products = new List<Product>();

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
            File.AppendAllText(FilePath, json);
        }
    }
}


