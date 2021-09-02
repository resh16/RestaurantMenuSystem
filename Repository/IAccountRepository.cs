using Microsoft.AspNetCore.Identity;
using RestaurantMenuSystem.Models;
using System.Threading.Tasks;

namespace RestaurantMenuSystem.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);

        Task SignOutAsync();

        //Task CreateUserAsync(SignUpUserModel userModel);
    }
}