using _0_Framework.Application;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.Comment;
using BlogManagement.Infrastrcture.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;
        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article= _blogContext.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id= x.Id,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    Slug = x.Slug,
                    CanonicalAddress = x.CanonicalAddress,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                    Title = x.Title,


                }).FirstOrDefault(x=>x.Slug==slug);
            
            if (!string.IsNullOrEmpty(article.Keywords))
            article.KeywordList = article.Keywords.Split(",").ToList();

            var Comments = _commentContext.comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.Id)                
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    ParentId = x.ParentId,
                   
                    CreationDate=x.CreationDate.ToFarsi(),

                }).OrderByDescending(x => x.Id)
                .ToList();
            foreach (var comment in Comments)
            {
                if(comment.ParentId>0)
                    comment.ParentName=Comments.FirstOrDefault(x=>x.ParentId==comment.ParentId)?.Name;
            }
            article.Comments = Comments;
            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {

            return _blogContext.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    Slug = x.Slug,
                    CanonicalAddress = x.CanonicalAddress,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                    Title = x.Title,
            

                }).ToList();


        }
    }

}
