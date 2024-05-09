using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class Product
    {
        public string Id { get; set; }= Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity {  get; set; }


    }
}
