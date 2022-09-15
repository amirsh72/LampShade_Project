using _0_Framework.Infrastructure;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class ProductCategoruRepository :RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _Context;

        public ProductCategoruRepository(ShopContext Context):base(Context)
        {
            _Context = Context;
        }

        public EditProductCategory GetDetail(long id)
        {
            return _Context.productCategories.Select(x=>new EditProductCategory
            {
                Id =x.Id,
                Description = x.Description,
                Name =x.Name,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug,

            }).FirstOrDefault(X=>X.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _Context.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id=x.Id,
                Name=x.Name,


            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _Context.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(),

            });
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
