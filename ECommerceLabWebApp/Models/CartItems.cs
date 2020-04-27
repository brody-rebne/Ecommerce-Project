using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models
{
    public class CartItems
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }

    }
}
