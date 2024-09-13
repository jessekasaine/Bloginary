using Bloginary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloginary.DTOs
{
    public class CreateBlogViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public DateOnly PublicationDate { get; set; }
        public DateOnly? EditedDate { get; set; }
        public required IFormFile Image { get; set; }
        //public IEnumerable<SelectListItem>? Category { get; set; }
        //public IEnumerable<SelectListItem>? Tag { get; set; }

        public List<Tag>? Tag { get; set; }
        public List<Category>? Category { get; set; }
    }
}
