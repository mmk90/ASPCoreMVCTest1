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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorytoProduct>().HasKey(cp => new { cp.CategoryID, cp.ProductID });

            modelBuilder.Entity<Product>(
                p =>
                {
                    p.HasKey(pk => pk.ID);

                    p.HasOne<Item>(fk => fk.Item).WithOne(product => product.Product).HasForeignKey<Item>(i => i.ID);
                }
                );

            modelBuilder.Entity<Item>(
                i =>
                {
                    i.HasKey(pk => pk.ID);

                    i.Property(p => p.Price).HasColumnType("Money");
                }
                );

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
            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ID = 1,
                    Price = 854.0M,
                    Qty = 5
                },
                new Item()
                {
                    ID = 2,
                    Price = 3302.0M,
                    Qty = 8
                },
                new Item()
                {
                    ID = 3,
                    Price = 2500,
                    Qty = 3
                });
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ID = 1,
                    Name = "Product 1",
                    Description = "this is the first Product",
                    ItemID = 1
                },
                new Product()
                {
                    ID = 2,
                    Name = "Product 2",
                    Description = "this is the second Product",
                    ItemID = 2
                },
                new Product()
                {
                    ID = 3,
                    Name = "Product 3",
                    Description = "this is the third Product",
                    ItemID = 3
                }
                );
            modelBuilder.Entity<CategorytoProduct>().HasData(
                new CategorytoProduct() { CategoryID = 1, ProductID = 1 },
                new CategorytoProduct() { CategoryID = 2, ProductID = 1 },
                new CategorytoProduct() { CategoryID = 3, ProductID = 1 },
                new CategorytoProduct() { CategoryID = 4, ProductID = 1 },
                new CategorytoProduct() { CategoryID = 1, ProductID = 2 },
                new CategorytoProduct() { CategoryID = 2, ProductID = 2 },
                new CategorytoProduct() { CategoryID = 3, ProductID = 2 },
                new CategorytoProduct() { CategoryID = 4, ProductID = 2 },
                new CategorytoProduct() { CategoryID = 1, ProductID = 3 },
                new CategorytoProduct() { CategoryID = 2, ProductID = 3 },
                new CategorytoProduct() { CategoryID = 3, ProductID = 3 },
                new CategorytoProduct() { CategoryID = 4, ProductID = 3 }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
