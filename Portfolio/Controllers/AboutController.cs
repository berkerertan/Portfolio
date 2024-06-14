using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;
using Portfolio.DAL.Entities;

namespace Portfolio.Controllers
{
	public class AboutController : Controller
	{
		MyPortfolioContext context = new();
		public IActionResult AboutList()
		{
			var values = context.Abouts.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateAbout(About about)
		{
			context.Abouts.Add(about);
			context.SaveChanges();
			return RedirectToAction("AboutList");
		}


		public IActionResult DeleteAbout(int id)
		{
			var value = context.Abouts.Find(id);
			context.Abouts.Remove(value);
			context.SaveChanges();
			return RedirectToAction("AboutList");
		}

		[HttpGet]
		public IActionResult UpdateAbout(int id)
		{
			var value = context.Abouts.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateAbout(About about)
		{
			context.Abouts.Update(about);
			context.SaveChanges();
			return RedirectToAction("AboutList");
		}
	}
}
