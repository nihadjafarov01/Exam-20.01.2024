using Exam6.Business.Services.Interfaces;
using Exam6.Business.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Mvc;

namespace Exam6.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _service {  get; }

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _service.Register(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(vm);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _service.Login(vm);
            if (result == null)
            {
                ModelState.AddModelError("", "Username or Passworg is wrong");
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Index", "Home");
        }
        public async Task<bool> CreateInits()
        {
            return await _service.CreateInits();
        }
    }
}
