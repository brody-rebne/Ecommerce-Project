using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models
{
    public class CartItems
    {
        public int ID { get; set; }
        public string CartID { get; set; }
        public Cart Cart { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
