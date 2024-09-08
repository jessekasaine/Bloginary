using Bloginary.Data;
using Bloginary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bloginary.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _db;

        public TagController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var tags = _db.Tags.ToList();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Add(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }
    }
}
