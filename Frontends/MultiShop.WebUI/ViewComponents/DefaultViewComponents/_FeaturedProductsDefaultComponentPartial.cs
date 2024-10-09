﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeaturedProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}