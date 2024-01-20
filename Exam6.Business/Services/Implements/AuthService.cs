using Exam6.Business.Services.Interfaces;
using Exam6.Business.ViewModels.AuthVMs;
using Exam6.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Exam6.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AuthService(RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> CreateInits()
        {
            foreach (var item in Enum.GetNames(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item
                    });
                }
            }
            IdentityUser user = new IdentityUser
            {
                Email = "admin@gmail.com",
                UserName = "admin",
            };
            await _userManager.CreateAsync(user,"Admin123");
            IdentityUser user1 = await _userManager.FindByNameAsync("admin");
            await _userManager.AddToRoleAsync(user1, Roles.Admin.ToString());
            return true;
        }

        public async Task<SignInResult> Login(LoginVM vm)
        {
            IdentityUser user;
            if(vm.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            }
            SignInResult result;
            if (user != null)
            {
                result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
                return result;
            }
            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterVM vm)
        {
            IdentityUser user = new IdentityUser
            {
                Email = vm.Email,
                UserName = vm.Username
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            IdentityUser user1 = await _userManager.FindByNameAsync("admin");
            await _userManager.AddToRoleAsync(user1, Roles.Member.ToString());
            return result;
        }
    }
}
