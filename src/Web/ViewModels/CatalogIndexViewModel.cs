﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class CatalogIndexViewModel
    {
        public List<CatalogItemViewModel> CatalogItems { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem> Prices { get; set; }
        public int? BrandFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }
        public int? PricesFilterApplied { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
