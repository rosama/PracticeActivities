using Microsoft.EntityFrameworkCore;
using RestfulActivity.Entities;
using System;

namespace RestfulActivity.DBContexts
{
    public class ProductsContext : DbContext
    {
        public DbSet<Entities.Products> Products { set; get; }
        public DbSet<Entities.Category> Category { set; get; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Products>().HasData(
                new Products()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Word",
                    Price = 100.0M,
                    ImgURL = "http://google.com",
                    CategoryId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
                },
                new Products()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Excel",
                    Price = 200.0M,
                    ImgURL = "http://google.com",
                    CategoryId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")

                },
                new Products()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "PhotoShop",
                    Price = 100.0M,
                    ImgURL = "http://google.com",
                    CategoryId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
                }              
                );

            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   Name = "Microsoft Product",
               },
               new Category
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   Name = "Adobe",
               }
               );

            base.OnModelCreating(modelBuilder);
        }
        public ProductsContext(DbContextOptions<ProductsContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
