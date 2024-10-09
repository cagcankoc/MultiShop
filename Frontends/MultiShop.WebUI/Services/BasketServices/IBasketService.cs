using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userId);
        Task AddBasketItemAsync(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItemAsync(string productId);
    }
}
