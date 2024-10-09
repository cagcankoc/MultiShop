using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            int discountRate = await _discountService.GetDiscountCouponRateByCodeAsync(code);

            var basketValues = await _basketService.GetBasketAsync();
            decimal totalPriceWithTax = basketValues.TotalPrice * 1.1m;
            decimal totalNewPriceWithDiscount = totalPriceWithTax * (1 - discountRate / 100m);

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = discountRate, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
