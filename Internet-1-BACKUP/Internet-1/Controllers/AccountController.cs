using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Internet_1.Models; // AppUser'ın bulunduğu namespace'i ekleyin

namespace Internet_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Identity kullanarak çıkış yap
            return RedirectToAction("Index", "Home");
        }
    }
}
