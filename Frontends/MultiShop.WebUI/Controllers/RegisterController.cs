using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
		{
			if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				StringContent content = new StringContent(JsonConvert.SerializeObject(createRegisterDto), Encoding.UTF8, "application/json");
				var response = await client.PostAsync("https://localhost:5001/api/Register", content);

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}
