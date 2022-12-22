using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification
    {
        [Theory]
        [InlineData(null, null, null, 5)]
        [InlineData(1, null, null, 3)]
        [InlineData(2, null, null, 2)]
        [InlineData(null, 1, null, 2)]
        [InlineData(null, 3,null, 1)]
        [InlineData(1, 3, null, 1)]
        [InlineData(2, 3, null, 0)]
        public void MatchesExpectedNumberOfItems(int? brandId, int? typeId, int? priceId, int expectedCount)
        {
            var spec = new eShopWeb.ApplicationCore.Specifications.CatalogFilterSpecification(brandId, typeId, priceId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.Equal(expectedCount, result.Count());
        }

        public List<CatalogItem> GetTestItemCollection()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem(1, 1, 1, "Description", "Name", "test", 0, "FakePath"),
                new CatalogItem(2, 1, 3, "Description", "Name", "test", 0, "FakePath"),
                new CatalogItem(3, 1, 2, "Description", "Name", "test", 0, "FakePath"),
                new CatalogItem(1, 2, 3, "Description", "Name", "test", 0, "FakePath"),
                new CatalogItem(2, 2, 2, "Description", "Name", "test", 0, "FakePath"),  
            };
        }
    }
}
