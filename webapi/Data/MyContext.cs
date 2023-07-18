using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("news");
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
        }

    }
}
