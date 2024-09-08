using Bloginary.Data;
using Bloginary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bloginary.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _db.Blogs.ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var blogs = await _db.Blogs.FirstOrDefaultAsync(x=>x.Id==id);
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _db.Add(blog);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }
    }
}
