using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;

namespace Portfolio.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        MyPortfolioContext context = new();
        public IViewComponentResult Invoke() 
        {
            var values = context.Skills.ToList();
            return View(values); 
        }
    }
}
