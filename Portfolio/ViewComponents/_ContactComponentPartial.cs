using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;
using Portfolio.DAL.Entities;

namespace Portfolio.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
