using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Context;
using Portfolio.Models;

namespace Portfolio.Controllers
{
	public class AccountController : Controller
	{
		MyPortfolioContext context = new();
		//public AccountController(MyPortfolioContext context)
		//{
		//	_context = context;
		//}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await context.Users
					.SingleOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

				if (user != null)
				{
					// Giriş başarılı
					HttpContext.Session.SetString("Username", user.Username);
					return RedirectToAction("Index", "Statistic");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre");
				}
			}
			return View(model);
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("Username");
			return RedirectToAction("Login");
		}
	}
}
