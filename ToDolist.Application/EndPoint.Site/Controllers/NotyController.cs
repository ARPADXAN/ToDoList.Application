using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class NotyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
