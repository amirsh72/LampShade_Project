using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DisCountContext _context;
        private readonly ShopContext _shopContext;
        public ColleagueDiscountRepository(DisCountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.colleagueDiscounts.Select(c => new EditColleagueDiscount
            {
                DiscountRate = c.DiscountRate,
                Id = c.Id,
                ProductId = c.ProductId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.colleagueDiscounts
                .Select(x => new ColleagueDiscountViewModel
                {
                    Id = x.Id,
                    CreationDate = x.CreationDate.ToFarsi(),
                    DiscountRate = x.DiscountRate,
                    IsRemoved = x.IsRemoved,
                    ProductId = x.ProductId,



                }).ToList();
            if (searchmodel.ProductId > 0)
                query.Where(x => x.ProductId == searchmodel.ProductId).ToList();


            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discount;
        }
    }
}
