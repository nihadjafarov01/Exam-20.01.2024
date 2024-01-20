using Exam6.Business.Services.Interfaces;
using Exam6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam6.Controllers
{
    public class HomeController : Controller
    {
        IInstructorService _service {  get; }

        public HomeController(IInstructorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            var rdata = data.Where(i => !i.IsDeleted);
            return View(rdata);
        }
    }
}