using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Aplication;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
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
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
