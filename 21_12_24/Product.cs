using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_12_24
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public Product(string name, decimal costPrice, decimal salePrice)
        {
            Name= name;
            CostPrice= costPrice;
            SalePrice=salePrice>=costPrice? salePrice : throw new ArgumentException("Sale price cannot be less than cost price.");
        }
        internal void SetId(int id)
        {
            Id = id;
        }
    }
}
