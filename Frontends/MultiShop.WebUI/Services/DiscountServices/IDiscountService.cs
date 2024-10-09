using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<ResultDiscountCouponDto> GetDiscountCouponByCodeAsync(string code);
        Task<int> GetDiscountCouponRateByCodeAsync(string code);
    }
}
