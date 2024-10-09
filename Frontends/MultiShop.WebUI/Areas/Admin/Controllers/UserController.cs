using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }

		void CommonUserViewBagList(string currentPage)
		{
			ViewBag.v0 = "Kullanıcı İşlemleri";
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Kullanıcılar";
			ViewBag.v3 = currentPage;
		}

		public async Task<IActionResult> UserList()
        {
            CommonUserViewBagList("Kullanıcı Listesi");

			var values = await _userIdentityService.GetUserListAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
			CommonUserViewBagList("Kullanıcı Adres Bilgisi");

			var values = await _cargoCustomerService.GetCargoCustomerByUserIdAsync(id);
            return View(values);
        }
    }
}
