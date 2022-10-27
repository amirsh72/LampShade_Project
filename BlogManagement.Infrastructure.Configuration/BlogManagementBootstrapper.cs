
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using _01_LampShadeQuery.Query;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastrcture.EFCore;
using BlogManagement.Infrastrcture.EFCore.Repository;
using BlogManagment.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogManagement.Infrastructure.Configuration
{
    public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string conectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            services.AddDbContext<BlogContext>(x => x.UseSqlServer(conectionString));
        }
           
    }
}
