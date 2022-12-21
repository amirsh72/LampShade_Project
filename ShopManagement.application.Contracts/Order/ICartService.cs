using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.application.Contracts.Order
{
    public interface ICartService
    {
        Cart Get();
        void Set(Cart cart);
    }
}
