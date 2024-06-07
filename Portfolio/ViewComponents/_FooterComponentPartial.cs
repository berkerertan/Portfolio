using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;

namespace Portfolio.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
