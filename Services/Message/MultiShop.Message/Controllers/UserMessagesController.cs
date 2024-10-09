using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var values = await _userMessageService.GetAllMessagesAsync();
            return Ok(values);
        }

        [HttpGet("SendboxMessages/{senderId}")]
        public async Task<IActionResult> GetSendboxMessages(string senderId)
        {
            var values = await _userMessageService.GetSendboxMessagesAsync(senderId);
            return Ok(values);
        }

        [HttpGet("InboxMessages/{receiverId}")]
        public async Task<IActionResult> GetInboxMessages(string receiverId)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(receiverId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj başarıyla silindi");
        }

        [HttpGet("InboxMessageCountByReceiverId/{receiverId}")]
        public async Task<IActionResult> GetInboxMessageCountByReceiverId(string receiverId)
        {
            int count = await _userMessageService.GetInboxMessageCountByReceiverIdAsync(receiverId);
            return Ok(count);
        }
    }
}
