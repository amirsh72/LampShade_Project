using _0_Framework.Application;
using _0_Framework.Application.Sms;
using Microsoft.Extensions.Configuration;
using ShopManagement.application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository;
        private readonly IShopInventoryAcl _shopInventoryAcl;
        private readonly ISmsService _smsService;
        private readonly IShopAccountAcl _shopAccountAcl;

        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper, IConfiguration configuration, IShopInventoryAcl shopInventoryAcl, ISmsService smsService, IShopAccountAcl shopAccountAcl)
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
            _configuration = configuration;
            _shopInventoryAcl = shopInventoryAcl;
            _smsService = smsService;
            _shopAccountAcl = shopAccountAcl;
        }

        public void Cancel(long id)
        {
           var order = _orderRepository.Get(id);
            order.IsCancel();
            _orderRepository.SaveChange();
        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
        }

        public List<OrderItemViewModel> GetItems(long orderId)
        {
            return _orderRepository.GetItems(orderId);
        }

        public string PaymentSucceeded(long orderId,long refId)
        {
            var order = _orderRepository.Get(orderId);
            order.PaymentSucceeded(refId);
            //var symbol = _configuration.GetValue<string>("Symbol");
            var issueTrackingNo = CodeGenerator.Generate("S");
            order.SetIssueTrackingNo(issueTrackingNo);
            if (!_shopInventoryAcl.ReduceFromInventory(order.Items))
            {
                return "";
            }

            _orderRepository.SaveChange();
            var (name,mobile)=_shopAccountAcl.GetAccountBy(order.AccountId);
            var CustomerMobile = _authHelper.CurrentAccountMobile();
            _smsService.Send(mobile,$"{name}کاربر گرامی سفارش شماباشماره پیگیر{issueTrackingNo}ی با موفقیت انجام شد");
            return issueTrackingNo;
        }

        public long PlaceOrder(Cart cart)
        {
            var currentAccountId = _authHelper.CurrentAccountId();
            
           
            var order = new Order(currentAccountId,cart.PaymentMethod,cart.TotalAmount,cart.DiscountAmount,cart.PayAmount);
            foreach(var cartItem in cart.Items)
            {
                var orderItem=new OrderItem(cartItem.Id,cartItem.Count,cartItem.UnitPrice,cartItem.DiscountRate);
                order.AddItem(orderItem);
            }
            _orderRepository.Create(order);
            _orderRepository.SaveChange();
            return order.Id;


        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            return _orderRepository.Search(searchModel);
        }
    }
}
