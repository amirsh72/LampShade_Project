using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500);   
            builder.Property(x => x.Email).HasMaxLength(500);   
            builder.Property(x => x.Message).HasMaxLength(500);

            builder.HasOne(x => x.product).WithMany(x => x.comments).HasForeignKey(x => x.ProductId);
        }
    }
}
