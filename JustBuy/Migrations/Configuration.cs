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
                Description = "The Arla Glison from the Clarks® Cloudsteppers™ Collection provides the best of comfort technology with classic feminine appeal. A fabric upper gives it a playful edge and feels delicately soft between the toes. A Clarks Cushion Soft™ with OrthoLite®",
                Images = "SWH-01__12398.1617327166_uyhfm7,SWH-07__48648.1617327181_ogksgl,SWH-05__22163.1617327176_p2wwa6,SWH-06__76517.1617327179_nyhn7x",
                Name = "Arla Glison",
                Price = 69.99,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-730),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 2,
                CategoryId = 1,
                Description = "They say good shoes take you good places, so why not let the Charli shoe take you on an amazing adventure. With soft leather and interest uppers, flexible back strap and cute block heel, what's not to love? Plus, the super comfortable insole and padded",
                Images = "SWH-02__89173.1615418379_ihoztm,SWH-01__02787.1615418376_cknst4,SWH-03__91683.1615418368_hvpqh1,SWH-04__52782.1615418365_cwgwkx",
                Name = "Charli",
                Price = 73.99,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 3,
                CategoryId = 1,
                Description = "Sunny days were made for the sparkling style and easy comfort of the SKECHERS Rumblers - Mega Flash sandal. Soft microfiber fabric upper in a wedge heeled strappy slide sandal with rhinestone trim detailing. Memory Foam footbed for added comfort.",
                Images = "SWH-01__64228.1617030727_ddy7hw,SWH-03__03557.1617030714_mhczdf,SWH-02__83195.1617030712_frexk8",
                Name = "Rumblers - Mega Flash",
                Price = 99.99,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-730),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 4,
                CategoryId = 1,
                Description = "Reva Aries is a super-comfy addition to your summer wardrobe. Camel-coloured straps and a self-fastening ankle gives you a sandal that can handle long walks on the beach, and up the dunes as well. The slight lift in the heel and weave-look sole mean",
                Images = "SWH-02__54682.1617080407_wmcgzm,SWH-03__53797.1617080410_yob014,SWH-01__55182.1617080404_lk0tbw",
                Name = "Aries",
                Price = 99.99,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-730),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 5,
                CategoryId = 1,
                Description = "Riva Europe Queenie is a fun, comfy women’s summer sandal. With a flowery black leather toe strap and comfy leather footbed, they’re a dream to look at and a dream to wear. Being dead flat, they’re also fine for a full day’s wearing without being too",
                Images = "SWH-01__71708.1617080126_bqud2a,SWH-03__76949.1617080132_qrcvkh",
                Name = "Queenie",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 6,
                CategoryId = 1,
                Description = "Enjoy Everyday Comfort with the Bare Traps Summer style COLETTE. The ultra soft leather-look upper straps feature stitched edging and a simple Silver stud on the outside ankle. Both the front and ankle straps feature adjustable velcro for a more secure",
                Images = "SWH-03__58444.1617080119_imcdoh,SWH-02__29433.1617080116_oaw1km,SWH-01__31398.1617080114_ylmshq",
                Name = "Bare Traps",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 7,
                CategoryId = 2,
                Description = "With a contemporary look and feel, these women's lace-up shoes feature a contrasting rand and 4.5cm EVA wedge. Lightweight and flexible, the outsole features cleated detailing for grip, while stitch detail highlights the Clarks DNA. Finished off with our",
                Images = "SWH-01__57462.1617327164_tjmxg0",
                Name = "Sharon Noel",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 8,
                CategoryId = 2,
                Description = "With classic sports appeal, these casual shoes offer maximum comfort for all day wear. Try them on and feel the difference. Our Trigenic system gives ultralight, gait-reactive flex and engineered deconstruction, a foot-shaped fit and responsive",
                Images = "SWH-01__91413.1617326261_d8th86",
                Name = "Tri Knit",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
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
