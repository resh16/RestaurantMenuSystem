using Microsoft.AspNetCore.Identity;
using RestaurantMenuSystem.Controllers;
using RestaurantMenuSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private  UserManager<IdentityUser> _userManager;
        private  SignInManager<IdentityUser> _signInManager;

       

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        //Task IAccountRepository.CreateUserAsync(SignUpUserModel userModel)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
           var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        //Task IAccountRepository.CreateUserAsync(SignUpUserModel userModel)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


    }
}
