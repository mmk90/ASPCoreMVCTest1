using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Data
{
    public class WebsiteDatabaseContext : DbContext
    {
        public WebsiteDatabaseContext(DbContextOptions<WebsiteDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorytoProduct> CategorytoProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region seed Category data
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    Name = "Category 1",
                    Description = "this is the first category"
                },
                new Category()
                {
                    ID = 2,
                    Name = "Category 2",
                    Description = "this is the second category"
                },
                new Category()
                {
                    ID = 3,
                    Name = "Category 3",
                    Description = "this is the third category"
                }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
