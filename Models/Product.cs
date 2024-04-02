using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumenTechnology.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDesc { get; set; }
        public int categoryId { get; set; }
    }
}
