using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand CatalogBrand { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType CatalogType { get; private set; }
        public int CatalogPriceId { get; private set; }
        public CatalogBrand CatalogPrice { get; private set; }
        public string ItemColor { get; private set; }

        public CatalogItem(int catalogBrandId,
            int catalogTypeId,
            int catalogPriceId,
            string description,
            string name,
            string itemColor,
            decimal price,
            string pictureUri)
        {
            CatalogBrandId = catalogBrandId;
            CatalogTypeId = catalogTypeId;
            CatalogPriceId = catalogPriceId;
            Description = description;
            Name = name;
            ItemColor = itemColor;
            Price = price;
            PictureUri = pictureUri;
        }

        public void UpdateDetails(string name, string description, string itemColor, decimal price)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrEmpty(itemColor, nameof(itemColor));
            Guard.Against.NegativeOrZero(price, nameof(price));

            Name = name;
            Description = description;
            ItemColor = itemColor;
            Price = price;
        }

        public void UpdateBrand(int catalogBrandId)
        {
            Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));
            CatalogBrandId = catalogBrandId;
        }

        public void UpdateType(int catalogTypeId)
        {
            Guard.Against.Zero(catalogTypeId, nameof(catalogTypeId));
            CatalogTypeId = catalogTypeId;
        }

        public void UpdatePrice(int catalogPriceId)
        {
            Guard.Against.Zero(catalogPriceId, nameof(catalogPriceId));
            CatalogPriceId = catalogPriceId;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                PictureUri = string.Empty;
                return;
            }
            PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
        }
    }
}