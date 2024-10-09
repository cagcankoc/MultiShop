using Newtonsoft.Json;

namespace MultiShop.SignalR.Services.CommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/CommentStatistics");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            int count = JsonConvert.DeserializeObject<int>(jsonData);
            return count;
        }
    }
}
