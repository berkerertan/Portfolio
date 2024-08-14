using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Context;
using Portfolio.DAL.Entities;

namespace Portfolio.Controllers
{
	public class MessageController : Controller
	{
		MyPortfolioContext context = new();
		public IActionResult Inbox()
		{
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var values = context.Messages.ToList();
			return View(values);
		}

        [HttpPost]
        public IActionResult Submit(Message message)
        {
            if (ModelState.IsValid)
            {
                context.Messages.Add(message);
                context.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(message);
        }

        public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = context.Messages.Find(id);
			value.IsRead = true;
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = context.Messages.Find(id);
			value.IsRead = false;
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult DeleteMessage(int id)
		{
			var value = context.Messages.Find(id);
			context.Messages.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult MessageDetail(int id)
		{
			var value = context.Messages.Find(id);
			return View(value);
		}

	}
}
