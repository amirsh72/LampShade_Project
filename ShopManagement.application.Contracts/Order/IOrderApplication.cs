using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        double GetAmountBy(long id);
        void Cancel(long id);
        List<OrderItemViewModel> GetItems(long orderId);
        string PaymentSucceeded(long orderId, long refId);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    }
}
