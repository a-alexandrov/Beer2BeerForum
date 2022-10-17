using Microsoft.AspNetCore.Mvc;

namespace Beer2Beer.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
