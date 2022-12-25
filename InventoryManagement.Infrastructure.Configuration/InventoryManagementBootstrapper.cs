
using _0_Framework.Infrastructure;
using _01_LampShadeQuery.Contracts.Inventory;
using _01_LampShadeQuery.Query;
using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain;
using InventoryManagement.Infrastructure.Configuration.Permissions;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();
            services.AddTransient<IInventoryQuery, InventoryQuery>();
            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
