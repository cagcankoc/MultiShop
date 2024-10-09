using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;

        public _AdminLayoutHeaderComponentPartial(IUserService userService, IMessageService messageService, ICommentService commentService)
        {
            _userService = userService;
            _messageService = messageService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int inboxMessageCount = await _messageService.GetInboxMessageCountByReceiverIdAsync(user.Id);
            ViewBag.inboxMessageCount = inboxMessageCount;

            int totalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.totalCommentCount = totalCommentCount;

            return View(user);
        }
    }
}
