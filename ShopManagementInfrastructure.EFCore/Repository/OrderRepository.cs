using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Infrustructure.EFCore;
using ShopManagement.application.Contracts;
using ShopManagement.application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class OrderRepository:RepositoryBase<long,Order>,IOrderRepository
    {
        private readonly ShopContext _Context;
        private readonly AccountContext1 _accountContext1;

        public OrderRepository(ShopContext context, AccountContext1 accountContext1) : base(context)
        {
            _Context = context;
            _accountContext1 = accountContext1;
        }

        public double GetAmountBy(long id)
        {
            var order= _Context.orders
                .Select(x=>new { x.PayAmount,x.Id })
                .FirstOrDefault(x=>x.Id == id);
            if (order != null)
                return order.PayAmount;
            return 0;
        }

        public List<OrderItemViewModel> GetItems(long orderId)
        {
            var products = _Context.products.Select(x => new {x.Id,x.Name}).ToList();
            var order = _Context.orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
            {
                return new List<OrderItemViewModel>();
            }
            var items=order.Items.Select(x=>new OrderItemViewModel
            {
                Id=x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProdouctId = x.ProdouctId,
                UnitPrice = x.UnitPrice,
            }).ToList();

            foreach(var item in items)
            {
                item.Prodouct = products.FirstOrDefault(x => x.Id == item.ProdouctId)?.Name;
            }
            return items;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchmodel)
        {
            var accounts = _accountContext1.Accounts.Select(x => new { x.Id, x.Fullname }).ToList();
            var query = _Context.orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                AccountId=x.AccountId,
                DiscountAmount=x.DiscountAmount,
                IsCanceled=x.IsCanceled,
                IsPaid=x.IsPaid,
                IssueTrackingNo=x.IssueTrackingNo,
                PayAmount=x.PayAmount,
                PaymentMethodId=x.PaymentMethod,
                RefId=x.RefId,
                TotalAmount=x.TotalAmount,
                CreationDate=x.CreationDate.ToFarsi(),

            });
            query = query.Where(x => x.IsCanceled == searchmodel.IsCanceled);
            if (searchmodel.AccountId > 0)
            {
                query=query.Where(x=>x.AccountId == searchmodel.AccountId);
            }
            var orders = query.OrderByDescending(x => x.Id).ToList();
            foreach(var order in orders)
            {
                order.AccountFullName = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.Fullname;
                order.PaymentMethod = PaymentMethod.GetBy(order.PaymentMethodId).Name;
            }
            return orders;
        }
    }
}
