using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task<int> GetInboxMessageCountByReceiverIdAsync(string receiverId);
    }
}
