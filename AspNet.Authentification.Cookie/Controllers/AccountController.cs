using AspNet.Authentification.Cookie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userM,SignInManager<User> signIn)
        {
            signInManager = signIn;
            userManager = userM;
        }

        public IActionResult Subscription()
        {
            return View(new SubscriptionViewModel()); 
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscription(SubscriptionViewModel subscriptionVM)
        {
            if (!ModelState.IsValid)
            {
                return View(subscriptionVM);
            }

            User user = new User()
            {
                Email = subscriptionVM.Email,
                UserName = subscriptionVM.Email,
                FirstName = subscriptionVM.FistName,
                LastName = subscriptionVM.LastName
            };
            var result = await userManager.CreateAsync(user, subscriptionVM.Password);

            if (result.Succeeded)
            {
                var resultRole = await userManager.AddToRoleAsync(user, subscriptionVM.RoleSelected);
                if (resultRole.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("Age", subscriptionVM.Age.ToString()));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return View(subscriptionVM);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(subscriptionVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var result = await signInManager.PasswordSignInAsync(
                userName:loginVm.Email,
                password: loginVm.Password,
                isPersistent:true,
                lockoutOnFailure:false      
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Identifiant incorrect", "Identifiant Incorrect");
                return View(loginVm);
            }
        }


    }
}
