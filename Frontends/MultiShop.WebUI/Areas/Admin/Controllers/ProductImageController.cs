using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        void CommonProductImageViewBagList(string currentPage)
        {
            ViewBag.v0 = "Ürün Görsel İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = currentPage;
        }

        [HttpGet]
        [Route("UpdateProductImage/{productId}")]
        public async Task<IActionResult> UpdateProductImage(string productId)
        {
            CommonProductImageViewBagList("Ürün Görsel Güncelleme");

            var value = await _productImageService.GetByProductIdProductImageAsync(productId);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateProductImage/{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }
    }
}
