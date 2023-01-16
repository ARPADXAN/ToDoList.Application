using Domain.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EndPoint.Site.Models.RegisterViewModels;
using Microsoft.CodeAnalysis.VisualBasic;
using EndPoint.Site.Models.ViewModels;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> signInManager;
        public AccountController(UserManager<Users> usermaneger, SignInManager<Users> signInManager)
        {
            _userManager = usermaneger;
            this.signInManager = signInManager;
        }


        #region Register


        [HttpPost]
        public IActionResult Register(RegisterViewModels request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "خطایی رخ داد");

                return View(request);
            }
            Users user = new Users()
            {
                FirstName = request.FirstName,
                Lastname = request.LastName,
                UserName = request.Mobile,
                PhoneNumber = request.Mobile,
                Email = request.Email,
                PasswordHash = request.Password,



            };

            var result = _userManager.CreateAsync(user, request.Password).Result;

            if (result.Succeeded)
            {
               
                
                    
                    return Json("isuccess");

                

            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return Json(request);
        }
        #endregion


        #region signin
        public IActionResult login(string returnUrl = "/")
        {
            return View(new LoginViewModels
            {
                ReturnUrl = returnUrl,
            });
        }
        [HttpPost]
        public IActionResult login(LoginViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            var users = _userManager.FindByNameAsync(model.Mobile).Result;
            if (users == null)
            {
                ModelState.AddModelError("", "کاربر مورد نظر یافت نشد");
                return Json(model);
            }
            signInManager.SignOutAsync();
            var result = signInManager.PasswordSignInAsync(users, model.Password, model.IsPerssitence, true).Result;

            if (result.Succeeded)
            {

                return Json("isuccess");
            }
            if (result.RequiresTwoFactor)
            {
                //
            }
            return Json(model);
        }
        #endregion

        #region Sign Out
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }
        #endregion
    }
}
