using Microsoft.AspNetCore.Mvc;

namespace IT_Lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
