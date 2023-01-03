using Domain.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EndPoint.Site.Models.RegisterViewModels;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Users> _userManager;
        public AccountController(UserManager<Users> usermaneger)
        {
            _userManager = usermaneger;

        }


        #region Register
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(RegisterViewModels request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            Users user = new Users()
            {
                FirstName = request.FirstName,
                Lastname = request.LastName,
                UserName = request.Mobile,
                PhoneNumber = request.Mobile,
                Email=request.Email,
                PasswordHash = request.Password,

              

            };
            var result = _userManager.CreateAsync(user, request.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("index","Home");

            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(request);
        }
        #endregion

    }
}
