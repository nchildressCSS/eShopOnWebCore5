using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints
{
    public class UpdateCatalogItemRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int Id { get; set; }
        [Range(1, 10000)]
        public int CatalogBrandId { get; set; }
        [Range(1, 10000)]
        public int CatalogTypeId { get; set; }
        [Range(1, 10000)]
        public int CatalogPriceId { get; set; }
        [Required]
        public string Description { get; set; }
        public string ItemColor { get; set; }
        [Required]
        public string Name { get; set; }
        public string PictureBase64 { get; set; }
        public string PictureUri { get; set; }
        public string PictureName { get; set; }
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
}
