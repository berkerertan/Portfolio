using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;

namespace Portfolio.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		MyPortfolioContext context = new();
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount = context.ToDoLists.Where(x => x.Status == false).Count();
			var values = context.ToDoLists.Where(x => x.Status == false).ToList();
			return View(values);
		}
	}
}
