using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        void CommonProductDetailViewBagList(string currentPage)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = currentPage;
        }

        [HttpGet]
        [Route("UpdateProductDetail/{productId}")]
        public async Task<IActionResult> UpdateProductDetail(string productId)
        {
            CommonProductDetailViewBagList("Ürün Açıklama ve Bilgi Güncelleme");

            var value = await _productDetailService.GetByProductIdProductDetailAsync(productId);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }
    }
}
