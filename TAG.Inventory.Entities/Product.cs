using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG.Inventory.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; } = "DefaultProduct";
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
