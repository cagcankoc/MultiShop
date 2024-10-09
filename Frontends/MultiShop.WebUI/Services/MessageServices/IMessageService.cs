using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId);
        Task<int> GetInboxMessageCountByReceiverIdAsync(string receiverId);
    }
}
