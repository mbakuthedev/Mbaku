//using Mbaku.Viewmodels;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Mbaku.Models;

//namespace Mbaku.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly SignInManager<IdentityUser> _signInManager;

//        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }
//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> RegisterAsync(RegisterViewModel vm)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new ApplicationUser { userName = vm.EmailAddress, Email = vm.EmailAddress };
//                var result = await _userManager.CreateAsync(user, vm.Password);
//                if (result.Suceeded)
//                {
//                    await _signInManager.SignInAsync(user, false);
//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError("", error.Description);
//                    }
//                }
//            }
//            return View();
//        }
//    }
//}
