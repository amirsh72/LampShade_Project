

using _0_Framework.Application;
using _0_Framework.Infrastructure;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using System.Collections.Generic;
using System.Linq;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _commentContext1;

        public CommentRepository(CommentContext commentContext1) : base(commentContext1)
        {
            _commentContext1 = commentContext1;
        }


        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {

            var query = _commentContext1.comments


                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    Email = x.Email,
                    Website = x.Website,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    Type = x.Type,

                    CommentDate = x.CreationDate.ToFarsi(),
                });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email == searchModel.Email);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}


    

