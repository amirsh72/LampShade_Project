using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using _01_LampShadeQuery.Contracts.Slide;
using _01_LampShadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Aplication;
using ShopManagement.application.Contracts.Comment;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.application.Contracts.Slide;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagementInfrastructure.EFCore;
using ShopManagementInfrastructure.EFCore.Repository;
using System;

namespace ShopManagement.Configuration
{
    public  class ShopManagementBoostrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        { 
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoruRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication,SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
