using Microsoft.AspNetCore.Mvc;

namespace Portfolio.ViewComponents
{
    public class _StatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
