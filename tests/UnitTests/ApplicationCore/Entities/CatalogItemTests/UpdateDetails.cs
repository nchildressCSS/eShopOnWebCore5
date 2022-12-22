using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.CatalogItemTests
{
    public class UpdateDetails
    {
        private CatalogItem _testItem;
        private int _validTypeId = 1;
        private int _validBrandId = 2;
        private int _validPriceId = 3;
        private string _validDescription = "test description";
        private string _validName = "test name";
        private string _validItemColor = "test color";
        private decimal _validPrice = 1.23m;
        private string _validUri = "/123";

        public UpdateDetails()
        {
            _testItem = new CatalogItem(_validTypeId, _validBrandId, _validPriceId, _validDescription, _validName, _validItemColor, _validPrice, _validUri);
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyName()
        {
            string newValue = "";
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(newValue, _validDescription, _validItemColor, _validPrice));
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyDescription()
        {
            string newValue = "";
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, newValue, _validItemColor, _validPrice));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullName()
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(null, _validDescription, _validItemColor, _validPrice));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullDescription()
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(_validName, null, _validItemColor, _validPrice));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1.23)]
        public void ThrowsArgumentExceptionGivenNonPositivePrice(decimal newPrice)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, _validDescription, _validItemColor, newPrice));
        }
    }
}
