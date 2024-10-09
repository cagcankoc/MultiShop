using MultiShop.DtoLayer.MessageDtos;
using NuGet.Protocol.Plugins;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string receiverId)
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/InboxMessages/" + receiverId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId)
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/SendboxMessages/" + senderId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values;
        }

        public async Task<int> GetInboxMessageCountByReceiverIdAsync(string receiverId)
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/InboxMessageCountByReceiverId/" + receiverId);
            int count = await responseMessage.Content.ReadFromJsonAsync<int>();
            return count;
        }
    }
}
