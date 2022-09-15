using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _Context;
        public ProductPictureRepository(ShopContext Context) : base(Context)
        {
            _Context = Context;
        }
        public EditProductPicture GetDetails(long id)
        {
            return _Context.productPictures
                .Select(p => new EditProductPicture
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    Picture = p.Picture,
                    PictureAlt = p.PictureAlt,
                    PictureTitle = p.PictureTitle,
                }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchmodel)
        {
            var query = _Context.productPictures.Include(x => x.product)
                .Select(x => new ProductPictureViewModel
                {
                    Id = x.Id,
                    Product = x.product.Name,
                    CreationDate = x.CreationDate.ToString(),
                    Picture = x.Picture,
                    ProductId = x.ProductId,
                   IsRemoved=x.IsRemoved,
                });
            if(searchmodel.ProductId!=0)
                query=query.Where(x=>x.ProductId==searchmodel.ProductId);
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
