using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public void SetValue(Product p)
        {
            Name = p.Name;
            Quantity = p.Quantity;
            Price = p.Price;
        }

        public Product Clone() => new() { Id = Id, Name = Name, Price = Price, Quantity = Quantity };

    }
}
