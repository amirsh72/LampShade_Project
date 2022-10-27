﻿using _0_Framework.Application;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastrcture.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _context.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryQueryModel
                {
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    ArticlesCount = x.Articles.Count,

                }).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var articleCategory= _context.ArticleCategories
                .Include(x=> x.Articles)
                .Select(x=>new ArticleCategoryQueryModel
                {
                    Slug=x.Slug,
                    Name=x.Name,
                    Description=x.Description,
                    Picture=x.Picture,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,
                    Keywords=x.Keywords,
                    MetaDescription=x.MetaDescription,
                    CanonicalAddress=x.CanonicalAddress,
                    Articles=MapArticles(x.Articles),
                    ArticlesCount=x.Articles.Count,


                }).FirstOrDefault(x=>x.Slug == slug);
            if(!string.IsNullOrWhiteSpace(articleCategory.Keywords))
            articleCategory.KeywordsList = articleCategory.Keywords.Split(",").ToList();

            return articleCategory;
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
            return articles.Select(x => new ArticleQueryModel
            {
                Slug = x.Slug,
                ShortDescription=x.ShortDescription,
                Title=x.Title,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle= x.PictureTitle,
                PublishDate=x.PublishDate.ToFarsi(),


            }).ToList();
            
        }
    }
}
