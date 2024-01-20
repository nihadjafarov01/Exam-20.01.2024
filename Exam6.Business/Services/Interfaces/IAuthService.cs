using Exam6.Business.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Identity;

namespace Exam6.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<SignInResult> Login(LoginVM vm);
        public Task<IdentityResult> Register(RegisterVM vm);
        public Task Logout();
        public Task<bool> CreateInits();
    }
}
