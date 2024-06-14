using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;

namespace Portfolio.Controllers
{
	public class StatisticController : Controller
	{
		MyPortfolioContext context = new();
		public IActionResult Index()
		{
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.v1 = context.Skills.Count();
			ViewBag.v2 = context.Messages.Count();
			ViewBag.v3 = context.Messages.Where(x=>x.IsRead == false).Count();
			ViewBag.v4 = context.Messages.Where(x=>x.IsRead == true).Count();

			return View();
		}
	}
}
