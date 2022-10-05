using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
   public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _shopContext;

        public CommentRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _shopContext.comments
                .Include(x => x.product)
                .Select(x => new CommentViewModel
                {
                    Id=x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    Email = x.Email,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    ProductId = x.ProductId,
                    ProductName = x.product.Name,
                    CommentDate = x.CreationDate.ToFarsi(),
                });
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name==searchModel.Name);

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email == searchModel.Email);
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
