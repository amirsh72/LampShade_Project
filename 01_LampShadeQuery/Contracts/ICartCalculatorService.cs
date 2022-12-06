using ShopManagement.application.Contracts.Order;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts
{
    public interface ICartCalculatorService
    {
       Cart ComputeCart(List<CartItem> cartItems);
    }
}
