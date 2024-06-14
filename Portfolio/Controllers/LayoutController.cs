using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
