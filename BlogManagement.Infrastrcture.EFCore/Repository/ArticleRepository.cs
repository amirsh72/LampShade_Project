using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastrcture.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>,IArticleRepository
    {
        private readonly BlogContext _context;
        public ArticleRepository(BlogContext context) : base(context)
        {
            _context=context;
        }

        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Keywords = x.Keywords,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CanonicalAddress = x.CanonicalAddress,
            }).FirstOrDefault(x=>x.Id==id);
        }

        public Article GetWhitCategory(long id)
        {
            return _context.Articles.Include(x=>x.Category).FirstOrDefault(x=>x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Title = x.Title,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                CategoryId= x.CategoryId,

            });
            if(!string.IsNullOrWhiteSpace(searchModel.Title))
                query=query.Where(x=>x.Title.Contains(searchModel.Title));
            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
