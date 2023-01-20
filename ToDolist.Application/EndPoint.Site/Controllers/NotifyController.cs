using EndPoint.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class NotifyController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
       
    }
}
