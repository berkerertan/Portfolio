using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;

namespace Portfolio.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        MyPortfolioContext context = new();
        public IViewComponentResult Invoke() 
        {
            var values = context.Experiences.ToList();
            return View(values); 
        }
    }
}
