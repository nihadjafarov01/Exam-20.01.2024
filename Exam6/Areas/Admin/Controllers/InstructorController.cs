using Exam6.Business.Services.Interfaces;
using Exam6.Business.ViewModels.InstructorVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam6.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class InstructorController : Controller
    {
        IInstructorService _service {  get; }

        public InstructorController(IInstructorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InstructorCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await _service.UpdateAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, InstructorUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.UpdateAsync(id, vm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
