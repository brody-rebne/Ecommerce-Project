using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string Owner { get; set; }

        public List<CartItems> CartItems { get; set; }
    }
}
