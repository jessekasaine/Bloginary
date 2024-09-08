using System.ComponentModel.DataAnnotations;

namespace Bloginary.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public DateOnly PublicationDate { get; set; }
        public DateOnly? EditedDate { get; set; }
        public required string Image { get; set; }
        public List<Tag>? Tag { get; set; }
        public List<Category>? Category { get; set; }
    }
}
