using Bloginary.Data;
using Bloginary.DTOs;
using Bloginary.Interfaces;
using Bloginary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bloginary.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IPhotoService _photoService;

        public BlogController(AppDbContext db, IPhotoService photoService)
        {
            _db = db;
            _photoService = photoService;
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
        public async Task<IActionResult> CreateAsync(CreateBlogViewModel blogVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(blogVM.Image);
                var blog = new Blog
                {
                    Title = blogVM.Title,
                    Description = blogVM.Description,
                    Content = blogVM.Content,
                    PublicationDate = blogVM.PublicationDate,
                    EditedDate = blogVM.EditedDate,
                    Tag = blogVM.Tag,
                    Category = blogVM.Category,
                    Image = result.Url.ToString()
                };
                _db.Add(blog);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(blogVM);
        }
    }
}
