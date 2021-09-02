using Microsoft.AspNetCore.Mvc;
using RestaurantMenuSystem.Models;
using RestaurantMenuSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuSystem.Controllers
{
   
        public class AccountController : Controller
        {

            private readonly IAccountRepository _accountRepository;
            private string returnUrl;

            public AccountController(IAccountRepository accountRepository)
            {
                _accountRepository = accountRepository;
            }

            [Route("signup")]
            public IActionResult Signup()
            {
                return View();
            }

            [HttpPost]
            [Route("signup")]
            public async Task<IActionResult> Signup(SignUpUserModel userModel)
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountRepository.CreateUserAsync(userModel);
                    if (!result.Succeeded)
                    {
                        foreach (var errorMessage in result.Errors)
                        {
                            ModelState.AddModelError("", errorMessage.Description);
                        }
                        return View(userModel);
                    }
                    ModelState.Clear();
                return View();
                }
            return View(userModel);
                
            }



        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }


           [Route("login")]
           [HttpPost]
            public async Task<IActionResult> Login(SignInModel signInModel)
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountRepository.PasswordSignInAsync(signInModel);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                        //if (!string.IsNullOrEmpty(returnUrl))
                        //{
                        //    //return LocalRedirect(returnUrl);

                        //}
                    

                    }
                    ModelState.AddModelError("", "Invalid credentials");

               
                }
                //return View(signInModel);
                return View(signInModel);
            }

            [Route("logout")]
            public async Task<IActionResult> Logout()
            {
                await _accountRepository.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }


        }

}
