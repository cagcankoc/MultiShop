using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByUserIdDto> GetCargoCustomerByUserIdAsync(string userId)
        {
            var responseMessage = await _httpClient.GetAsync("cargocustomers/CargoCustomerByUserId/" + userId);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByUserIdDto>();
            return value;
        }
    }
}
