namespace JustBuy.Migrations
{
    using JustBuy.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JustBuy.Models.AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDataContext context)
        {
            this.seedCategory(context);
            this.seedProduct(context);
        }

        private void seedProduct(AppDataContext context)
        {
            context.Products.AddOrUpdate(x => x.Id, new Product()
            {
                Id = 1,
                CategoryId = 1,
                Description = "1",
                Images = "SWH-01__12398.1617327166_uyhfm7,SWH-07__48648.1617327181_ogksgl,SWH-05__22163.1617327176_p2wwa6,SWH-06__76517.1617327179_nyhn7x",
                Name = "Arla Glison",
                Price = 20.22,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 2,
                CategoryId = 1,
                Description = "1",
                Images = "SWH-01__12398.1617327166_uyhfm7,SWH-07__48648.1617327181_ogksgl,SWH-05__22163.1617327176_p2wwa6,SWH-06__76517.1617327179_nyhn7x",
                Name = "Arla Glison",
                Price = 20.22,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 3,
                CategoryId = 1,
                Description = "1",
                Images = "SWH-01__12398.1617327166_uyhfm7,SWH-07__48648.1617327181_ogksgl,SWH-05__22163.1617327176_p2wwa6,SWH-06__76517.1617327179_nyhn7x",
                Name = "Arla Glison",
                Price = 20.22,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
        }
        private void seedCategory(AppDataContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id, new Category()
            {
                Id = 1,
                Cover = "SWH-01__05279.1617326256_u4enwq",
                Description = "",
                Name = "Sandals",
                Status = Category.CategoryStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Category()
            {
                Id = 2,
                Cover = "SWH-01__72599.1617327154_jh6ltt",
                Description = "",
                Name = "Shoes",
                Status = Category.CategoryStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Category()
            {
                Id = 3,
                Cover = "SWH-01__13344.1615418383_cel7e8",
                Description = "",
                Name = "Sandals",
                Status = Category.CategoryStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
            );
        }
    }
}
