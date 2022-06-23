using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Services;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var userViewModel = await _userService.GetAllAsync();
            return View(userViewModel);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var userViewModel = await _userService.GetByIdAsync(id);

            return View(userViewModel);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
           if(!ModelState.IsValid)
                return View (userViewModel);

          await _userService.CreateAsync(userViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userViewModel = await _userService.GetByIdAsync(id);
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            await _userService.UpdateAsync(userViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userViewModel = await _userService.GetByIdAsync(id);
            return View(userViewModel);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
