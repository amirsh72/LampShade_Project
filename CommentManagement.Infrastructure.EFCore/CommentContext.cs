

using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.EFCore
{
    public class CommentContext:DbContext
    {
        public DbSet<Comment> comments { get; set; }

        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
