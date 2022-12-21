using ShopManagement.application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class CartService : ICartService
    {
        public Cart Cart { get; set; }
        public Cart Get()
        {
            return this.Cart;
        }

        public void Set(Cart cart)
        {
            this.Cart = cart;
        }
    }
}
