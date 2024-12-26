
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Internet_1.Models;
using System.Linq;

namespace Internet_1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor for dependency injection
        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new AdminDashboardViewModel
            {
                TotalUsers = _context.Users.Count(),
                TotalListings = _context.Products.Count(),
                TotalCategories = _context.Categories.Count()
            };

            return View(model);
        }
    }
}
