using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public class AppDbContext
    {
        public ObservableCollection<Product> Products { get; set; } = new() { new Product(){Name="Ciyelek",Price=2.5,Quantity=10}
                                                                             , new Product(){Name="Gilas",Price=4,Quantity=10 } };

        public void AddProduct(Product product) => Products.Add(product);

        public void RemoveProduct(Product product) => Products.Remove(product);

        public void RemoveProduct(string id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);
            if (product is not null)
                Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            RemoveProduct(product.Id);
            Products.Add(product);
        }
    }
}
