using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var products = categoryId == null
                ? await _productService.GetAllProductsWithCategoryAsync()
                : await _productService.GetProductsWithCategoryByCategoryIdAsync(categoryId);

            return View(products);
        }
    }
}
