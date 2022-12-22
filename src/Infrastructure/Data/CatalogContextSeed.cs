using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    catalogContext.Database.Migrate();
                }

                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogPrices.AnyAsync())
                {
                    await catalogContext.CatalogPrices.AddRangeAsync(
                        GetPreconfiguredCatalogPrices());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new("Clothing"),
                new("Accessories"),
                new("Drinkware")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new("Sweatshirts"),
                new("Crew Necks"),
                new("Tees & Tops"),
                new("Bottoms"),
                new("Face Masks"),
                new("Blankets"),
                new("Bottles"),
                new("Cups")
            };
        }

        static IEnumerable<CatalogPrice> GetPreconfiguredCatalogPrices()
        {
            return new List<CatalogPrice>
            {
                new("$0.99 - 4.99"),
                new("$5.00 - 14.99"),
                new("$15.00 - 24.99"),
                new("$25.00 - 34.99"),
                new("$35.00 - 49.99"),
                new("$50.00+")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                new(1,1,6, "League Essential Fleece Hood", "League Essential Fleece Hood", "Navy", 54.99M,  "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/d98e9824eafcdea23fa8d71f9dc22cc1_400x.jpg?v=1670533441"),
                new(1,1,5, "CI Sport Storm Hood", "CI Sport Storm Hood", "Sweet Ash", 49.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/image_261e7d5b-aad3-4274-8e77-46064295dc38_400x.png?v=1667058356"),//Sweet Ash
                new(1,2,6,"Gear Outta Town Crew", "Gear Outta Town Crew", "Light Blue", 54.99M,  "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/aac9023a831d39e5c48d37a641e08f0a_400x.jpg?v=1666904635"),//Light Blue
                new(1,2,5,"CI Sport Crewneck Storm", "CI Sport Crewneck Storm", "Sweet Mustard", 47.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/b587b01ebaef054337f64e67c7d4c5c9_400x.jpg?v=1668762285"),//Sweet Mustard
                new(1,3,3,"MV Sport Everest Sustainable Tee", "MV Sport Everest Sustainable Tee", "Dark Grey", 18.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/b3debab5239ee857fb7bed84682ce54a_400x.jpg?v=1669755808"),//Dark Grey
                new(1,3,5,"Nike Dri-Fit Cotton Long Sleeve Tee", "Nike Dri-Fit Cotton Long Sleeve Tee", "White", 42.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/0028fdcbaf70488838949f2c910f62bc_400x.jpg?v=1662138249"),//White
                new(1,4,4,"MV Sport Vintage Fleece Pant With Leg Graphic", "MV Sport Vintage Fleece Pant With Leg Graphic", "Black", 34.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/8e3146e65faa1b76a7f6f25bbc1a7a80_400x.jpg?v=1669759417"),//Black
                new(1,4,6,"Nike Club Fleece Jogger", "Nike Club Fleece Jogger", "Black", 65.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/af4e21f40652371b4bfa94ecb82352a0_400x.jpg?v=1666083965"),//Black
                new(2,5,1,"League Facemask", "League Facemask", "Blue/Yellow", 3.25M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/e4071fd90f4eeec37f47878645e03170_400x.jpg?v=1605562635"),//Blue/Yellow
                new(2,5,1,"League Heather Champ Face Covering", "League Heather Champ Face Covering", "Navy/Gold", 3.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/a8edef95b23b76d2808d4b7bfd5abe69_400x.jpg?v=1634829401"),//Navy/Gold
                new(2,6,5,"MV Sport Pro-Weave Sweatshirt Blanket", "MV Sport Pro-Weave Sweatshirt Blanket", "Navy", 44.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/4778081-3300-001-COLL0821P_400x.jpg?v=1661372900"),//Navy
                new(3,7,3,"Spirit Game Day Shaker Bottle", "Spirit Game Day Shaker Bottle", "Navy", 17.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/fa50f4b5f0cd6cc8f3fb045464a0227c_400x.jpg?v=1657731811"),//Navy
                new(3,7,3,"Spirit Omni Copper Lined Thermal Tumbler", "Spirit Omni Copper Lined Thermal Tumbler", "Navy", 19.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/3eca0d84076096d7f8d384811b63af9a_400x.jpg?v=1614938624"),//Navy
                new(3,8,2,"Traditional Coffee Mug", "Traditional Coffee Mug", "Navy", 12.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/e04dcfc93a945ea15c72fc2ee61b6d5c_400x.jpg?v=1637270049"),//Navy
                new(3,8,2,"Minolo Mug With Yellow Interior", "Minolo Mug", "White", 14.99M, "https://cdn.shopify.com/s/files/1/0008/6491/1404/products/f800ff89943a2d41561e5dea0999259b_400x.jpg?v=1637270061")//White
            };
        }
    }
}
