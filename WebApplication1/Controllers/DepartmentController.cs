using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Services;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var departmentViewModel = await _departmentService.GetAllAsync();
            return View(departmentViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var departmentViewModel = await _departmentService.GetByIdAsync(id);
            return View(departmentViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentViewModel);

            await _departmentService.CreateAsync(departmentViewModel);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            var departmentViewModel = await _departmentService.GetByIdAsync(id);
            return View(departmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentViewModel);

            await _departmentService.UpdateAsync(departmentViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var departmentviewModel = await _departmentService.GetByIdAsync(id);
            return View(departmentviewModel);
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }






    }
}
