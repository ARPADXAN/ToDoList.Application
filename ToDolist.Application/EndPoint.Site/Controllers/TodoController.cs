using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
