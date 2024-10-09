using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        void CommonCommentViewBagList(string currentPage)
		{
			ViewBag.v0 = "Yorum İşlemleri";
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Yorumlar";
			ViewBag.v3 = currentPage;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            CommonCommentViewBagList("Yorum Listesi");

            var values = await _commentService.GetAllCommentsAsync();
            return View(values);
        }

        [HttpGet]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {
			CommonCommentViewBagList("Yorum Güncelleme");

            var value = await _commentService.GetByIdCommentAsync(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        [HttpGet]
        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }
    }
}
