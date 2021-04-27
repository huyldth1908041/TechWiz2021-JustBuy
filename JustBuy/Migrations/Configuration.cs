namespace JustBuy.Migrations
{
    using JustBuy.IdentityConfig;
    using JustBuy.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

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
                Price = 55.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 9,
                CategoryId = 2,
                Description = "Enhance your natural style and comfort ideally with the SKECHERS Overhaul - Betley shoe. Smooth action leather, mesh fabric and synthetic upper in a lace up sporty walking and training sneaker with stitching accents and Air Cooled Memory Foam insole.",
                Images = "SWH-01__39812.1617080144_f0ezwd,SWH-03__14114.1617080149_xbd9oe",
                Name = "Overhaul - Betley",
                Price = 85.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 10,
                CategoryId = 2,
                Description = "Introducing the Anzarun Grid, a new, on-trend addition to one of our top ranges. This model retains the key markers of the classic shoe, while introducing fresh design elements such as synthetic leather detailing and a new tongue label.",
                Images = "SWH-01__41220.1617080146_p9rzbe,SWH-02__04416.1617080147_ryfdto,SWH-03__30510.1617080150_tnl6yr",
                Name = "Anzarun Grid",
                Price = 95.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 11,
                CategoryId = 2,
                Description = "Rockport's comfort technologies are on full display in this collection. This weekend or office-casual style is engineered for walkability with our molded EVA footbed with Memory Foam, EVA shock- absorbing midsole and moisture-wicking mesh lining.",
                Images = "SWH-01__87371.1615418394_baudgx,SWH-03__70038.1615418386_ffx2rg",
                Name = "Edge Hill",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 12,
                CategoryId = 3,
                Description = "Let's get dirty! Introducing Muddy, the comfiest gumboot around. Featuring a versatile ankle height, stretch panels and an easy-to-grab pull tab means no more tiresome tugging. Cute leopard print lining means the rain can't steal your thunder! - Durable",
                Images = "SWH-01__02652.1617064247_o5uve1,SWH-02__43422.1617064249_mf3fgk,SWH-03__30883.1617064261_lfi3t8",
                Name = "Muddy",
                Price = 89.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-700),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 13,
                CategoryId = 3,
                Description = "A timeless leather Chelsea boot featuring our inbuilt Bounce comfort pods for maximum shock absorption and energy return. The lightweight sole will also make sure your feet are comfy all day and night long.  Bounce Technology - Bounce pods built into the",
                Images = "SWH-01__35622.1617030719_zpwsgq,SWH-02__42907.1617030722_i57xqp,SWH-03__93166.1617030724_m9kpro",
                Name = "Kew",
                Price = 189.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 14,
                CategoryId = 3,
                Description = "Reg by JM",
                Images = "SWH-01__30217.1614206919_dfrqah,SWH-02__97408.1614206922_pvxylm,SWH-03__65717.1614206924_wte00i",
                Name = "Reg",
                Price = 89.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 15,
                CategoryId = 3,
                Description = "A timeless leather Chelsea boot featuring our inbuilt Bounce comfort pods for maximum shock absorption and energy return. The lightweight sole will also make sure your feet are comfy all day and night long.  Bounce Technology - Bounce pods built into the",
                Images = "SWH-03__65717.1614206924_wte00i,apihgtrh2__26905.1612596246_jpb6e6,apilndgiv__20514.1612596249_wwx8or,apibhktld__18641.1612596251_xktcew",
                Name = "Chelsea",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 15,
                CategoryId = 3,
                Description = "A timeless leather Chelsea boot featuring our inbuilt Bounce comfort pods for maximum shock absorption and energy return. The lightweight sole will also make sure your feet are comfy all day and night long.  Bounce Technology - Bounce pods built into the",
                Images = "SWH-03__65717.1614206924_wte00i,apihgtrh2__26905.1612596246_jpb6e6,apilndgiv__20514.1612596249_wwx8or,apibhktld__18641.1612596251_xktcew",
                Name = "Chelsea",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 16,
                CategoryId = 2,
                Description = "The Scorch Runner is your new go-to for a brisk run or a solid look. These kicks are made with a SoftFoam+ insert for plush, step-in comfort and zoned rubber for dependable stability. Whether you want to look fresh or stay fit–well, you get both.",
                Images = "SWH-01__43477.1617030725_rvbk0g,SWH-02__17534.1617030727_hfp9ca,SWH-03__39408.1617030730_xshhm0",
                Name = "Chelsea",
                Price = 95.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 17,
                CategoryId = 2,
                Description = "Manta by Lightning Bolt",
                Images = "SWH-01__08723.1615418398_u4zrqf,SWH-02__09143.1615418400_rvzldi,SWH-03__80106.1615418403_mbsnef",
                Name = "Manta",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 18,
                CategoryId = 2,
                Description = "It doesn't really matter whether or not a run is in the cards for the day. An ultra-breathable feel and cushy midsole that energises give these adidas running shoes an edge. Hit the pavement or hit the town. You've got the kicks for whatever unfolds.",
                Images = "SWH-01__87810.1617074230_wadalw,SWH-02__85252.1617074232_znooep,SWH-03__16626.1617074235_lehlma",
                Name = "Fluidflow 2.0 Men",
                Price = 99.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 19,
                CategoryId = 2,
                Description = "Introducing the Anzarun Grid, a new, on-trend addition to one of our top ranges. This model retains the key markers of the classic shoe, while introducing fresh design elements such as synthetic leather detailing and a new tongue label.",
                Images = "SWH-01__41923.1617030717_l5jqsv,SWH-02__33064.1617030734_wttmcc,SWH-03__49307.1617030718_u7urbd",
                Name = "Anzarun Grid",
                Price = 95.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 20,
                CategoryId = 2,
                Description = "Achieve peak comfort and athletic style wearing the SKECHERS Summits - Brisbane shoe. Nearly one piece soft engineered knit mesh fabric upper in a lace up athletic walking and training sneaker with woven-in accents. Memory Foam insole.",
                Images = "SWH-01__36334.1615418368_w944jl,SWH-02__67555.1615418370_nkpt7x,SWH-03__94895.1615418371_irhkdu",
                Name = "Summits- Brisbane",
                Price = 75.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 21,
                CategoryId = 2,
                Description = "Introducing the Anzarun Grid, a new, on-trend addition to one of our top ranges. This model retains the key markers of the classic shoe, while introducing fresh design elements such as synthetic leather detailing and a new tongue label.",
                Images = "SWH-01__41220.1617080146_o2caon,SWH-02__04416.1617080147_blq9at,SWH-03__30510.1617080150_rvs7k5",
                Name = "Anzarun Grid",
                Price = 95.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product
            {
                Id = 22,
                CategoryId = 2,
                Description = "Discover the ideal middle ground between lightweight comfort and sporty reliable style with the SKECHERS Summits shoe. Smooth action leather combines with textured mono mesh fabric in a lace up front athletic training sneaker with breathable panel",
                Images = "SWH-01__80323.1615418187_jurin2,SWH-02__92068.1615418189_azqmz0,SWH-03__98256.1615418192_ka6guj",
                Name = "Summits",
                Price = 75.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 23,
                CategoryId = 2,
                Description = "The Scorch Runner is your new go-to for a brisk run or a solid look. These kicks are made with a SoftFoam+ insert for plush, step-in comfort and zoned rubber for dependable stability. Whether you want to look fresh or stay fit–well, you get both.",
                Images = "SWH-01__43477.1617030725_dgffkx,SWH-02__17534.1617030727_u5han3",
                Name = "Scorch Runner",
                Price = 95.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 24,
                CategoryId = 2,
                Description = "Discover the ideal middle ground between lightweight comfort and sporty reliable style with the SKECHERS Summits - New World shoe. Smooth action leather combines with textured mono mesh fabric in a lace up front athletic training sneaker with breathable",
                Images = "SWH-01__71608.1615418142_g68b9n,SWH-02__27936.1615418145_nwhcte,SWH-03__75024.1615418148_mbyukg",
                Name = "Summits - New World",
                Price = 39.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 25,
                CategoryId = 2,
                Description = "Achieve peak comfort and athletic style wearing the SKECHERS Summits - Brisbane shoe. Nearly one piece soft engineered knit mesh fabric upper in a lace up athletic walking and training sneaker with woven-in accents. Memory Foam insole.",
                Images = "SWH-01__52638.1615418184_mlb5md,SWH-02__68301.1615418187_homaa4SWH-03__94868.1615418190_n3qndz",
                Name = "Summits- Brisbane",
                Price = 75.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 26,
                CategoryId = 2,
                Description = "Light, airy and full of style, the UltraRide Running Shoes are a hit both on and off the track. Featuring a ProFoam midsole for a responsive ride and a PROPLATE plate for quick turnover, these shoes are poised to become your all-time faves.",
                Images = "SWH-01__08772.1613952990_ashe5h,SWH-02__13061.1613952993_rcy5ob,SWH-03__02060.1613952996_quw5ta",
                Name = "Ultraride",
                Price = 99.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 27,
                CategoryId = 2,
                Description = "Light, airy and full of style, the UltraRide Running Shoes are a hit both on and off the track. Featuring a ProFoam midsole for a responsive ride and a PROPLATE plate for quick turnover, these shoes are poised to become your all-time faves.",
                Images = "SWH-01__87252.1613952982_er1iau,SWH-02__26239.1613952985_klk9z6,SWH-03__92933.1613952988_tyktbn",
                Name = "Ultraride",
                Price = 99.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 28,
                CategoryId = 2,
                Description = "Check out these form-fitting running shoes from Puma! With a breathable mesh upper, stylish colourway and low silhouette, the Comet 2 FS runners pack a serious punch - sure to up your game.",
                Images = "apihdfkmy__73363.1612597056_ae28re,apiiqokqi__09317.1612597058_i2m4zn,apievhdtv__25877.1612597061_yv0ecz",
                Name = "Comet",
                Price = 79.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 29,
                CategoryId = 2,
                Description = "Check out these form-fitting running shoes from Puma! With a breathable mesh upper, stylish colourway and low silhouette, the Comet 2 FS runners pack a serious punch - sure to up your game.",
                Images = "SWH-01__16767.1617023128_yzcslr,SWH-02__24860.1617023131_oks5bq,SWH-03__53196.1617023133_vx8rtz",
                Name = "Comet",
                Price = 79.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }, new Product()
            {
                Id = 30,
                CategoryId = 2,
                Description = "Feel the power of the fitness trends of the '80s. These shoes modernise a classic trainer with all-day style and comfort. They feature a coated leather upper and an iconic twin-cup midsole to give you more spring in your step.",
                Images = "SWH-01__99252.1617030692_v6cr63,SWH-02__06453.1617030694_fnnlgp,SWH-03__25400.1617030696_fjcnzs",
                Name = "Roguera Men",
                Price = 119.00,
                Quantity = 10,
                Status = Product.ProductStatus.Active,
                LaunchDate = DateTime.Now.AddDays(-365),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
            );
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
                Name = "Boots",
                Status = Category.CategoryStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
            );
        }
    }


}

