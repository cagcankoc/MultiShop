using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalR.Services.CommentServices;

namespace MultiShop.SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _commentService;

        public SignalRHub(ISignalRCommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task SendStatistics()
        {
            int totalCommentCount = await _commentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveTotalCommentCount", totalCommentCount);
        }
    }
}
