using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Portfolio.DAL.Context;
using Portfolio.DAL.Entities;

namespace Portfolio.Controllers
{
	public class ToDoListController : Controller
	{
		MyPortfolioContext context = new();
		public IActionResult Index()
		{
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var values = context.ToDoLists.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateToDoList() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateToDoList(ToDoList toDoList)
		{
			toDoList.Status = false;
			context.ToDoLists.Add(toDoList);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteToDoList(int id)
		{
			var value = context.ToDoLists.Find(id);
			context.ToDoLists.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateToDoList(int id)
		{
			var value = context.ToDoLists.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateToDoList(ToDoList toDoList)
		{
			context.ToDoLists.Update(toDoList);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult ChangeToDoListStatusToTrue(int id)
		{
			var value = context.ToDoLists.Find(id);
			value.Status = true;
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult ChangeToDoListStatusToFalse(int id)
		{
			var value = context.ToDoLists.Find(id);
			value.Status = false;
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}

	}
}
