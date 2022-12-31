using EndPoint.Site.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Register(RegisterViewModels models)
        {
            return View();
        }
    }
}
