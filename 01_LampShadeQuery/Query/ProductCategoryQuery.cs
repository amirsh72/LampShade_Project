using _01_LampShadeQuery.Contracts.ProductCategory;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.productCategories
                .Select(x => new ProductCategoryQueryModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    Picture=x.Picture,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,
                    Slug=x.Slug,
                }).ToList();
        }
    }
}
