using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace DiscountManagement.Infrastructure.EFCore
{
    public class DisCountContext:DbContext
    {
       public DbSet<CustomerDiscount> customerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> colleagueDiscounts { get; set; }


        public DisCountContext(DbContextOptions<DisCountContext> options):base(options)
        {
           
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
