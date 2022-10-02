using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DisCountContext _Context;
        private readonly ShopContext _shopContext;
        public CustomerDiscountRepository(DisCountContext Context,ShopContext shopContext) : base(Context)
        {
            _Context = Context;
            _shopContext = shopContext;
        }
        public EditCustomerDiscount GetDetails(long id)
        {
            return _Context.customerDiscounts
                .Select(x => new EditCustomerDiscount
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                    StartDate = x.StartDate.ToFarsi(),
                    EndDate = x.EndDate.ToFarsi(),
                    Reason = x.Reason,
                    

                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchmodel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _Context.customerDiscounts
                .Select(x => new CustomerDiscountViewModel
                {
                    Id = x.Id,
                    DiscountRate = x.DiscountRate,
                    EndDateGr = x.EndDate,
                    StartDateGr = x.StartDate,
                    EndDate = x.EndDate.ToFarsi(),
                    StartDate = x.StartDate.ToFarsi(),
                    ProductId = x.ProductId,
                    Reason = x.Reason,
                    CreationDate = x.CreationDate.ToFarsi(),

                }).ToList();
            if (searchmodel.ProductId > 0)
                query.Where(x => x.ProductId == searchmodel.ProductId).ToList();
            
         
            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount=>
            discount.Product=products.FirstOrDefault(x=>x.Id ==discount.ProductId)?.Name);
            return discount;


        }
    }
}
