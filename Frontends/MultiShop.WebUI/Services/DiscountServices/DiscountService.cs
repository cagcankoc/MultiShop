using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultDiscountCouponDto> GetDiscountCouponByCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/DiscountCouponByCode?code=" + code);
            var value = await responseMessage.Content.ReadFromJsonAsync<ResultDiscountCouponDto>();
            return value;
        }

        public async Task<int> GetDiscountCouponRateByCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/DiscountCouponRateByCode?code=" + code);
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
