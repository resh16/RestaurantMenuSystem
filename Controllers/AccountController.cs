using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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


        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;

        public AccountController(IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> options)
        {
            _validatorService = validatorService;
            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
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

                if (!_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
                {
                    this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Please Enter Valid Captcha.");
                    return View("Login");
                }



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











        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(
            ErrorMessage = "Please Enter Valid Captcha",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]

       
            public async Task<IActionResult> Login(SignInModel signInModel)
            {
                if (ModelState.IsValid)
                {
                //var result = await _accountRepository.PasswordSignInAsync(signInModel);
                 Microsoft.AspNetCore.Identity.SignInResult result = await _accountRepository.PasswordSignInAsync(signInModel);

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
